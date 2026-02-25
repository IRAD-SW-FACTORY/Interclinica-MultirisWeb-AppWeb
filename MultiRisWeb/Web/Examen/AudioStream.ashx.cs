using MultiRisWeb.Data.DataAccess;
using MultiRisWeb.Data.Domain;
using MultiRisWeb.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace MultiRisWeb.Web.Examen
{
    public class AudioStream : IHttpHandler, IReadOnlySessionState
    {
        private static readonly Dictionary<string, string> MimeTypes = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { ".mp3", "audio/mpeg" },
            { ".m4a", "audio/mp4" },
            { ".mp4", "audio/mp4" },
            { ".ogg", "audio/ogg" },
            { ".opus", "audio/ogg" },
            { ".webm", "audio/webm" },
            { ".aac", "audio/aac" },
            { ".wav", "audio/wav" }
        };

        public bool IsReusable { get { return false; } }

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                // Validar sesión
                if (context.Session == null || context.Session["id_usuario"] == null)
                {
                    new LogApp("AudioStream - Acceso no autorizado. IP: " + context.Request.UserHostAddress, "logAudios.log");
                    context.Response.StatusCode = 401;
                    context.Response.End();
                    return;
                }

                int idUsuario = int.Parse(context.Session["id_usuario"].ToString());

                // Leer parámetros
                string idParam = context.Request.QueryString["id"];
                string codExamen = context.Request.QueryString["cod"];
                string instParam = context.Request.QueryString["inst"];

                long idArchivoAudio;
                int idInstitucion;

                if (string.IsNullOrEmpty(idParam) || !long.TryParse(idParam, out idArchivoAudio) ||
                    string.IsNullOrEmpty(codExamen) ||
                    string.IsNullOrEmpty(instParam) || !int.TryParse(instParam, out idInstitucion))
                {
                    new LogApp("AudioStream - Parametros invalidos. id: " + idParam + ", cod: " + codExamen + ", inst: " + instParam + ", usuario: " + idUsuario, "logAudios.log");
                    context.Response.StatusCode = 400;
                    context.Response.End();
                    return;
                }

                new LogApp("AudioStream - Inicio. idAudio: " + idArchivoAudio + ", codExamen: " + codExamen + ", usuario: " + idUsuario, "logAudios.log");

                // Obtener metadatos del audio desde BD
                var dt = RisArchivoAudioDataAccess.Get(codExamen, idInstitucion);
                var audios = RisArchivoAudioDomain.ConvertTo(dt);
                var audio = audios.FirstOrDefault(a => a.id_audio == idArchivoAudio);

                if (audio == null)
                {
                    new LogApp("AudioStream - Audio no encontrado en BD. idAudio: " + idArchivoAudio + ", codExamen: " + codExamen, "logAudios.log");
                    context.Response.StatusCode = 404;
                    context.Response.End();
                    return;
                }

                // Construir ruta del archivo
                var institucion = InstitucionDataAccess.GetById(idInstitucion);
                string aetitle = !string.IsNullOrEmpty(institucion.aetitle) ? institucion.aetitle : idInstitucion.ToString();
                string rutaBase = ConfigurationManager.AppSettings["RutaAudiosExamen"];
                string rutaArchivo = Path.Combine(rutaBase, SanitizarNombreCarpeta(aetitle), SanitizarNombreCarpeta(codExamen), audio.nombre_archivo);

                if (!File.Exists(rutaArchivo))
                {
                    new LogApp("AudioStream - Archivo no encontrado en disco. idAudio: " + idArchivoAudio + ", ruta: " + rutaArchivo, "logAudios.log");
                    context.Response.StatusCode = 404;
                    context.Response.End();
                    return;
                }

                var fileInfo = new FileInfo(rutaArchivo);
                long fileLength = fileInfo.Length;

                // Determinar Content-Type
                string contentType;
                if (!MimeTypes.TryGetValue(audio.tipo_archivo, out contentType))
                    contentType = "application/octet-stream";

                // Soporte de Range requests para seeking eficiente
                string rangeHeader = context.Request.Headers["Range"];

                if (!string.IsNullOrEmpty(rangeHeader) && rangeHeader.StartsWith("bytes="))
                {
                    // Parsear Range header
                    string rangeValue = rangeHeader.Substring(6);
                    string[] rangeParts = rangeValue.Split('-');
                    long start = 0;
                    long end = fileLength - 1;

                    if (!string.IsNullOrEmpty(rangeParts[0]))
                        long.TryParse(rangeParts[0], out start);

                    if (rangeParts.Length > 1 && !string.IsNullOrEmpty(rangeParts[1]))
                        long.TryParse(rangeParts[1], out end);

                    if (start < 0) start = 0;
                    if (end >= fileLength) end = fileLength - 1;
                    if (start > end)
                    {
                        new LogApp("AudioStream - Range invalido. idAudio: " + idArchivoAudio + ", start: " + start + ", end: " + end + ", fileLength: " + fileLength, "logAudios.log");
                        context.Response.StatusCode = 416;
                        context.Response.AddHeader("Content-Range", "bytes */" + fileLength);
                        context.Response.End();
                        return;
                    }

                    long contentLength = end - start + 1;

                    new LogApp("AudioStream - Streaming parcial (206). idAudio: " + idArchivoAudio + ", bytes: " + start + "-" + end + "/" + fileLength + ", usuario: " + idUsuario, "logAudios.log");

                    context.Response.StatusCode = 206;
                    context.Response.AddHeader("Content-Range", "bytes " + start + "-" + end + "/" + fileLength);
                    context.Response.AddHeader("Content-Length", contentLength.ToString());
                    context.Response.ContentType = contentType;
                    context.Response.AddHeader("Accept-Ranges", "bytes");
                    context.Response.Cache.SetCacheability(HttpCacheability.Private);
                    context.Response.Cache.SetMaxAge(TimeSpan.FromHours(1));

                    WriteFileRange(context, rutaArchivo, start, contentLength);
                }
                else
                {
                    // Respuesta completa
                    new LogApp("AudioStream - Streaming completo (200). idAudio: " + idArchivoAudio + ", tamano: " + fileLength + " bytes, usuario: " + idUsuario, "logAudios.log");

                    context.Response.StatusCode = 200;
                    context.Response.ContentType = contentType;
                    context.Response.AddHeader("Content-Length", fileLength.ToString());
                    context.Response.AddHeader("Accept-Ranges", "bytes");
                    context.Response.Cache.SetCacheability(HttpCacheability.Private);
                    context.Response.Cache.SetMaxAge(TimeSpan.FromHours(1));

                    context.Response.TransmitFile(rutaArchivo);
                }

                new LogApp("AudioStream - Exito. idAudio: " + idArchivoAudio, "logAudios.log");
            }
            catch (HttpException)
            {
                // Cliente desconectado, ignorar (no logueamos para evitar spam en logs)
            }
            catch (Exception ex)
            {
                new LogApp("AudioStream - Error al transmitir audio. Exception: " + ex.ToString(), "logAudios.log");
                try
                {
                    context.Response.StatusCode = 500;
                    context.Response.End();
                }
                catch { }
            }
        }

        private static void WriteFileRange(HttpContext context, string filePath, long start, long length)
        {
            const int bufferSize = 64 * 1024; // 64 KB
            byte[] buffer = new byte[bufferSize];

            using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                fs.Seek(start, SeekOrigin.Begin);
                long remaining = length;

                while (remaining > 0 && context.Response.IsClientConnected)
                {
                    int toRead = (int)Math.Min(bufferSize, remaining);
                    int bytesRead = fs.Read(buffer, 0, toRead);
                    if (bytesRead == 0) break;

                    context.Response.OutputStream.Write(buffer, 0, bytesRead);
                    context.Response.Flush();
                    remaining -= bytesRead;
                }
            }
        }

        private static string SanitizarNombreCarpeta(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
                return "sin_codigo";

            char[] invalidChars = Path.GetInvalidPathChars();
            foreach (char c in invalidChars)
                nombre = nombre.Replace(c, '_');

            nombre = nombre.Replace("\\", "_").Replace("/", "_").Replace(":", "_").Replace("*", "_")
                           .Replace("?", "_").Replace("\"", "_").Replace("<", "_").Replace(">", "_").Replace("|", "_");

            return nombre;
        }
    }
}
