using MultiRisWeb.Data.DataAccess;
using MultiRisWeb.Data.Domain;
using MultiRisWeb.ResponseEntity;
using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;

namespace MultiRisWeb.Web.Examen
{
    public class AudioExamen : Page
    {
        private static readonly string[] ExtensionesPermitidas = { ".mp3", ".m4a", ".mp4", ".ogg", ".opus", ".webm", ".aac" };

        private static readonly int TamanoMaximoBytes = 10 * 1024 * 1024; // 10 MB

        private static readonly int MaximoAudiosPorExamen = 10;

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod == "POST" && Request.Files.Count > 0)
                UploadAudio();
        }
        #endregion

        #region WebMethods

        [WebMethod]
        public static ResponseApp ListarAudioExamen(string codExamen, int idInstitucion)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
            {
                Log.Warning("AudioExamen.ListarAudioExamen - Acceso no autorizado. codExamen: {CodExamen}", codExamen);
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            }

            try
            {
                int idUsuario = int.Parse(HttpContext.Current.Session["id_usuario"].ToString());
                Log.Information("AudioExamen.ListarAudioExamen - Inicio. codExamen: {CodExamen}, idInstitucion: {IdInstitucion}, usuario: {IdUsuario}", codExamen, idInstitucion, idUsuario);

                var dt = RisArchivoAudioDataAccess.Get(codExamen, idInstitucion);
                var data = RisArchivoAudioDomain.ConvertTo(dt);

                Log.Information("AudioExamen.ListarAudioExamen - Exito. codExamen: {CodExamen}, audios encontrados: {Count}", codExamen, data.Count);

                return new ResponseApp() { Data = data, Ejecutado = true, Mensaje = "" };
            }
            catch (Exception ex)
            {
                Log.Error(ex, "AudioExamen.ListarAudioExamen - Error. codExamen: {CodExamen}, idInstitucion: {IdInstitucion}", codExamen, idInstitucion);
                LogError(ex, "ListarAudioExamen");
                return new ResponseApp() { Data = null, Ejecutado = false, Mensaje = "Error al listar audios." };
            }
        }

        /// <summary>
        /// OBSOLETO: Este método ya no se usa desde la implementación de streaming HTTP.
        /// Se mantiene para compatibilidad con código legacy.
        /// Usar AudioStream.ashx en su lugar para reproducción eficiente.
        /// </summary>
        [Obsolete("Usar AudioStream.ashx para streaming eficiente en lugar de descargar Base64")]
        [WebMethod]
        public static ResponseApp ObtenerAudioExamen(long idArchivoAudio, string codExamen, int idInstitucion)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
            {
                Log.Warning("AudioExamen.ObtenerAudioExamen - Acceso no autorizado. idAudio: {IdAudio}", idArchivoAudio);
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            }

            try
            {
                int idUsuario = int.Parse(HttpContext.Current.Session["id_usuario"].ToString());
                Log.Warning("AudioExamen.ObtenerAudioExamen - Metodo obsoleto invocado. idAudio: {IdAudio}, usuario: {IdUsuario}. Usar AudioStream.ashx", idArchivoAudio, idUsuario);

                var dt = RisArchivoAudioDataAccess.Get(codExamen, idInstitucion);
                var audios = RisArchivoAudioDomain.ConvertTo(dt);
                var audio = audios.FirstOrDefault(a => a.id_audio == idArchivoAudio);

                if (audio == null)
                {
                    Log.Warning("AudioExamen.ObtenerAudioExamen - Audio no encontrado. idAudio: {IdAudio}, codExamen: {CodExamen}", idArchivoAudio, codExamen);
                    return new ResponseApp() { Data = null, Ejecutado = false, Mensaje = "Audio no encontrado." };
                }

                string aetitle = ObtenerAetitle(idInstitucion);
                string rutaArchivo = ObtenerRutaAudio(aetitle, codExamen, audio.nombre_archivo);

                if (!File.Exists(rutaArchivo))
                {
                    Log.Warning("AudioExamen.ObtenerAudioExamen - Archivo no encontrado en disco. idAudio: {IdAudio}, ruta: {Ruta}", idArchivoAudio, rutaArchivo);
                    return new ResponseApp() { Data = null, Ejecutado = false, Mensaje = "Archivo de audio no encontrado en el servidor." };
                }

                byte[] bytes = File.ReadAllBytes(rutaArchivo);
                string base64 = Convert.ToBase64String(bytes);

                Log.Information("AudioExamen.ObtenerAudioExamen - Audio convertido a Base64. idAudio: {IdAudio}, tamano: {Tamano} bytes", idArchivoAudio, bytes.Length);

                return new ResponseApp()
                {
                    Data = new { Base64 = base64, TipoArchivo = audio.tipo_archivo, NombreOriginal = audio.nombre_original },
                    Ejecutado = true,
                    Mensaje = ""
                };
            }
            catch (Exception ex)
            {
                Log.Error(ex, "AudioExamen.ObtenerAudioExamen - Error. idAudio: {IdAudio}, codExamen: {CodExamen}", idArchivoAudio, codExamen);
                LogError(ex, "ObtenerAudioExamen");
                return new ResponseApp() { Data = null, Ejecutado = false, Mensaje = "Error al obtener audio." };
            }
        }

        [WebMethod]
        public static ResponseApp EliminarAudioExamen(long idArchivoAudio, string codExamen, int idInstitucion)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
            {
                Log.Warning("AudioExamen.EliminarAudioExamen - Acceso no autorizado. idAudio: {IdAudio}", idArchivoAudio);
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            }

            try
            {
                int idUsuario = int.Parse(HttpContext.Current.Session["id_usuario"].ToString());
                Log.Information("AudioExamen.EliminarAudioExamen - Inicio. idAudio: {IdAudio}, codExamen: {CodExamen}, usuario: {IdUsuario}", idArchivoAudio, codExamen, idUsuario);

                var dt = RisArchivoAudioDataAccess.Delete(idArchivoAudio, idUsuario);

                if (dt.Rows.Count == 0 || string.IsNullOrEmpty(dt.Rows[0]["nombre_archivo"].ToString()))
                {
                    Log.Warning("AudioExamen.EliminarAudioExamen - Audio no encontrado o ya eliminado. idAudio: {IdAudio}, usuario: {IdUsuario}", idArchivoAudio, idUsuario);
                    return new ResponseApp() { Data = null, Ejecutado = false, Mensaje = "Audio no encontrado o ya fue eliminado." };
                }

                string nombreArchivo = dt.Rows[0]["nombre_archivo"].ToString();
                string aetitle = ObtenerAetitle(idInstitucion);
                string rutaArchivo = ObtenerRutaAudio(aetitle, codExamen, nombreArchivo);

                try
                {
                    if (File.Exists(rutaArchivo))
                    {
                        File.Delete(rutaArchivo);
                        Log.Information("AudioExamen.EliminarAudioExamen - Archivo fisico eliminado. ruta: {Ruta}", rutaArchivo);
                    }
                    else
                    {
                        Log.Warning("AudioExamen.EliminarAudioExamen - Archivo fisico no encontrado en disco. ruta: {Ruta}", rutaArchivo);
                    }
                }
                catch (Exception exFile)
                {
                    Log.Error(exFile, "AudioExamen.EliminarAudioExamen - Error al eliminar archivo fisico. ruta: {Ruta}", rutaArchivo);
                    LogError(exFile, "EliminarAudioExamen_File");
                }

                Log.Information("AudioExamen.EliminarAudioExamen - Exito. idAudio: {IdAudio}, codExamen: {CodExamen}", idArchivoAudio, codExamen);
                return new ResponseApp() { Data = null, Ejecutado = true, Mensaje = "Audio eliminado exitosamente." };
            }
            catch (Exception ex)
            {
                Log.Error(ex, "AudioExamen.EliminarAudioExamen - Error. idAudio: {IdAudio}, codExamen: {CodExamen}", idArchivoAudio, codExamen);
                LogError(ex, "EliminarAudioExamen");
                return new ResponseApp() { Data = null, Ejecutado = false, Mensaje = "Error al eliminar audio." };
            }
        }

        #endregion

        #region Upload

        private void UploadAudio()
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
            {
                Log.Warning("AudioExamen.UploadAudio - Acceso no autorizado. IP: {IP}", Request.UserHostAddress);
                Response.StatusCode = 401;
                Response.Write("401|Sesión expirada.");
                Response.End();
                return;
            }

            Response.ContentType = "text/plain";

            try
            {
                int idUsuario = int.Parse(Session["id_usuario"].ToString());
                HttpPostedFile file = Request.Files["audioFile"];
                string codExamen = Request.Form["codExamen"];
                int idInstitucion = int.Parse(Request.Form["idInstitucion"]);
                long idRisExamen = long.Parse(Request.Form["idRisExamen"]);

                Log.Information("AudioExamen.UploadAudio - Inicio. codExamen: {CodExamen}, usuario: {IdUsuario}, tamano: {Tamano} bytes", codExamen, idUsuario, file?.ContentLength ?? 0);

                if (file == null || file.ContentLength == 0)
                {
                    Log.Warning("AudioExamen.UploadAudio - Archivo vacio. codExamen: {CodExamen}, usuario: {IdUsuario}", codExamen, idUsuario);
                    Response.Write("400|No se recibió ningún archivo.");
                    Response.End();
                    return;
                }

                // Validar tamaño
                if (file.ContentLength > TamanoMaximoBytes)
                {
                    Log.Warning("AudioExamen.UploadAudio - Archivo excede tamano maximo. codExamen: {CodExamen}, tamano: {Tamano} bytes, usuario: {IdUsuario}", codExamen, file.ContentLength, idUsuario);
                    Response.Write("413|El archivo excede el tamaño máximo de 10MB.");
                    Response.End();
                    return;
                }

                // Validar extensión
                string extension = Path.GetExtension(file.FileName).ToLowerInvariant();
                if (!ExtensionesPermitidas.Contains(extension))
                {
                    Log.Warning("AudioExamen.UploadAudio - Extension no permitida. codExamen: {CodExamen}, extension: {Extension}, usuario: {IdUsuario}", codExamen, extension, idUsuario);
                    Response.Write("415|Formato de audio no permitido. Formatos válidos: " + string.Join(", ", ExtensionesPermitidas));
                    Response.End();
                    return;
                }

                // Validar magic bytes
                if (!ValidarMagicBytes(file.InputStream, extension))
                {
                    Log.Warning("AudioExamen.UploadAudio - Magic bytes invalidos. codExamen: {CodExamen}, extension: {Extension}, usuario: {IdUsuario}, IP: {IP}", codExamen, extension, idUsuario, Request.UserHostAddress);
                    Response.Write("415|El archivo no corresponde a un formato de audio válido.");
                    Response.End();
                    return;
                }

                // Generar nombre seguro
                string nombreOriginal = SanitizarNombreArchivo(Path.GetFileName(file.FileName));
                string nombreArchivo = Guid.NewGuid().ToString("N") + extension;

                // Obtener aetitle de la institución para la estructura de carpetas
                string aetitle = ObtenerAetitle(idInstitucion);

                // Crear directorio
                string rutaCarpeta = ObtenerRutaCarpeta(aetitle, codExamen);

                if (!Directory.Exists(rutaCarpeta))
                {
                    Directory.CreateDirectory(rutaCarpeta);
                    Log.Information("AudioExamen.UploadAudio - Directorio creado. ruta: {Ruta}", rutaCarpeta);
                }

                string rutaCompleta = ObtenerRutaAudio(aetitle, codExamen, nombreArchivo);

                // Guardar archivo en disco
                file.SaveAs(rutaCompleta);

                // Guardar metadatos en BD
                var domain = new RisArchivoAudioDomain()
                {
                    id_ris_examen = idRisExamen,
                    codexamen = codExamen,
                    id_institucion = idInstitucion,
                    nombre_original = nombreOriginal,
                    nombre_archivo = nombreArchivo,
                    tipo_archivo = extension,
                    tamano_bytes = file.ContentLength,
                    id_usuario_creacion = idUsuario
                };

                long resultado = RisArchivoAudioDataAccess.Set(domain);

                if (resultado == -1)
                {
                    // Límite alcanzado, borrar archivo recién guardado
                    try { File.Delete(rutaCompleta); } catch { }
                    Log.Warning("AudioExamen.UploadAudio - Limite de audios alcanzado. codExamen: {CodExamen}, usuario: {IdUsuario}", codExamen, idUsuario);
                    Response.Write("422|Se alcanzó el límite máximo de " + MaximoAudiosPorExamen + " audios por examen.");
                }
                else
                {
                    Log.Information("AudioExamen.UploadAudio - Exito. codExamen: {CodExamen}, archivo: {Archivo}, id_audio: {IdAudio}, tamano: {Tamano} bytes, usuario: {IdUsuario}", codExamen, nombreOriginal, resultado, file.ContentLength, idUsuario);
                    Response.Write("200|" + resultado.ToString());
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "AudioExamen.UploadAudio - Error. usuario: {IdUsuario}", Session["id_usuario"]);
                LogError(ex, "UploadAudio");
                Response.Write("500|Error al subir audio: " + ex.Message);
            }
            finally
            {
                Response.End();
            }
        }

        #endregion

        #region Rutas

        /// <summary>
        /// Obtiene el aetitle de una institución por su id.
        /// Se usa como nombre de carpeta para mejorar legibilidad en el filesystem.
        /// </summary>
        private static string ObtenerAetitle(int idInstitucion)
        {
            var institucion = InstitucionDataAccess.GetById(idInstitucion);
            return !string.IsNullOrEmpty(institucion.aetitle) ? institucion.aetitle : idInstitucion.ToString();
        }

        /// <summary>
        /// Construye la ruta completa del archivo de audio en disco.
        /// Centraliza la lógica para evitar inconsistencias entre Upload, Obtener y Eliminar.
        /// </summary>
        private static string ObtenerRutaAudio(string aetitle, string codexamen, string nombreArchivo)
        {
            string rutaBase = ConfigurationManager.AppSettings["RutaAudiosExamen"];
            return Path.Combine(rutaBase, SanitizarNombreCarpeta(aetitle), SanitizarNombreCarpeta(codexamen), nombreArchivo);
        }

        /// <summary>
        /// Construye la ruta de la carpeta del examen en disco.
        /// </summary>
        private static string ObtenerRutaCarpeta(string aetitle, string codexamen)
        {
            string rutaBase = ConfigurationManager.AppSettings["RutaAudiosExamen"];
            return Path.Combine(rutaBase, SanitizarNombreCarpeta(aetitle), SanitizarNombreCarpeta(codexamen));
        }

        #endregion

        #region Validaciones de seguridad

        private static bool ValidarMagicBytes(Stream stream, string extension)
        {
            if (stream == null || !stream.CanRead)
                return false;

            long posicionOriginal = stream.Position;
            stream.Position = 0;

            byte[] header = new byte[12];
            int bytesLeidos = stream.Read(header, 0, header.Length);
            stream.Position = posicionOriginal;

            if (bytesLeidos < 4)
                return false;

            // MP3: ID3 tag (0x49 0x44 0x33) o frame sync (0xFF 0xFB / 0xFF 0xF3 / 0xFF 0xF2)
            if (extension == ".mp3")
            {
                if (header[0] == 0x49 && header[1] == 0x44 && header[2] == 0x33) return true;
                if (header[0] == 0xFF && (header[1] & 0xE0) == 0xE0) return true;
                return false;
            }

            // M4A/MP4/AAC container: ftyp en posición 4
            if (extension == ".m4a" || extension == ".mp4" || extension == ".aac")
            {
                if (bytesLeidos >= 8 && header[4] == 0x66 && header[5] == 0x74 && header[6] == 0x79 && header[7] == 0x70) return true;
                // AAC raw: ADTS sync word
                if (header[0] == 0xFF && (header[1] & 0xF0) == 0xF0) return true;
                return false;
            }

            // OGG/OPUS: "OggS"
            if (extension == ".ogg" || extension == ".opus")
                return header[0] == 0x4F && header[1] == 0x67 && header[2] == 0x67 && header[3] == 0x53;

            // WAV: "RIFF"
            if (extension == ".wav")
            {
                if (bytesLeidos < 12) return false;
                // Valida "RIFF" y luego "WAVE"
                return header[0] == 0x52 && header[1] == 0x49 && header[2] == 0x46 && header[3] == 0x46 &&
                       header[8] == 0x57 && header[9] == 0x41 && header[10] == 0x56 && header[11] == 0x45;
            }

            // WEBM: EBML header (0x1A 0x45 0xDF 0xA3)
            if (extension == ".webm")
                return header[0] == 0x1A && header[1] == 0x45 && header[2] == 0xDF && header[3] == 0xA3;

            return false;
        }

        private static string SanitizarNombreArchivo(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
                return "audio";

            char[] invalidChars = Path.GetInvalidFileNameChars();
            foreach (char c in invalidChars)
                nombre = nombre.Replace(c, '_');

            if (nombre.Length > 200)
                nombre = nombre.Substring(0, 200);

            return nombre;
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

        #endregion

        #region Log

        private static void LogError(Exception ex, string metodo)
        {
            try
            {
                if (HttpContext.Current.Session["id_usuario"] != null)
                    ControlErrorDataAccess.ControlErrorSave(ex.HResult, ex.GetType().Name, ex.ToString(), 1, "AudioExamen." + metodo, int.Parse(HttpContext.Current.Session["id_usuario"].ToString()));
            }
            catch { }
        }

        #endregion
    }
}

