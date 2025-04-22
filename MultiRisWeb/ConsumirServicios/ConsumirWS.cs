// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.ConsumirServicios.ConsumirWS
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using MultiRisWeb.Data.DataAccess;
using MultiRisWeb.Data.Domain;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace MultiRisWeb.ConsumirServicios
{
    public class ConsumirWS
    {
        public static string ObtenerAntecedenteClinico(int idInstitucion, string codexamen)
        {
            InstitucionCredencialesDomain byId = InstitucionCredencialesDataAccess.GetById(InstitucionDataAccess.GetById(idInstitucion).id_institucion);
            InstitucionDomain byId1 = InstitucionDataAccess.GetById(idInstitucion);
            string result = string.Empty;
            try
            {
                switch (idInstitucion)
                {
                    case 1:
                        MultiRisWeb.WsCordillera.ServiceMultiris serviceMultirisWsCordillera = new MultiRisWeb.WsCordillera.ServiceMultiris();
                        MultiRisWeb.WsCordillera.CredencialesParameters credenciales = new MultiRisWeb.WsCordillera.CredencialesParameters();
                        credenciales.username = byId.username;
                        credenciales.password = byId.password;
                        result = serviceMultirisWsCordillera.GetAntecedentesClinicos(credenciales, codexamen);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                new IradLogFile.LogFile(ex.ToString());
            }
            return result;
        }
         
        public static string ObtenerComentarioTM(int idInstitucion, string codexamen)
        {
            InstitucionCredencialesDomain institucionCredenciales = InstitucionCredencialesDataAccess.GetById(idInstitucion);
            string result = string.Empty;
            try
            {
                switch (idInstitucion)
                {
                    case 1:
                        MultiRisWeb.WsCordillera.ServiceMultiris serviceMultirisWsCordillera = new MultiRisWeb.WsCordillera.ServiceMultiris();
                        MultiRisWeb.WsCordillera.CredencialesParameters credenciales = new MultiRisWeb.WsCordillera.CredencialesParameters();
                        credenciales.username = institucionCredenciales.username;
                        credenciales.password = institucionCredenciales.password;
                        result = serviceMultirisWsCordillera.GetcomentarioTM(credenciales, codexamen);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                new IradLogFile.LogFile(ex.ToString());
            }
            return result;
        }

        public static void SolicitarImagenes(int idInstitucion, string codexamen, UsuarioDomain usuario)
        {
            InstitucionCredencialesDomain institucionCredenciales = InstitucionCredencialesDataAccess.GetById(idInstitucion);
            RisExamenDomain examen = RisExamenDataAccess.GetByCodExamen(codexamen);
            try
            {
                switch (idInstitucion)
                {
                    case 1:
                        MultiRisWeb.WsCordillera.ServiceMultiris serviceMultirisWsCordillera = new MultiRisWeb.WsCordillera.ServiceMultiris();
                        MultiRisWeb.WsCordillera.CredencialesParameters credenciales = new MultiRisWeb.WsCordillera.CredencialesParameters();
                        credenciales.username = institucionCredenciales.username;
                        credenciales.password = institucionCredenciales.password;
                        serviceMultirisWsCordillera.SolicitudExamen(credenciales, codexamen, "");
                        break;
                    default:
                        break;
                }
                if (examen.id_ris_examen <= 0L)
                    return;
            }
            catch (Exception ex)
            {
                new IradLogFile.LogFile(ex.ToString());
                if (examen.id_ris_examen <= 0L)
                    return;
            }
        }

        public static DataTable GetDocumentosExamen(int idInstitucion, string codExamen, string numeroAcceso)
        {
            DataTable documentosExamen = new DataTable();
            InstitucionCredencialesDomain institucionCredenciales = InstitucionCredencialesDataAccess.GetById(idInstitucion);
            try
            {
                switch (idInstitucion)
                {
                    case 1:
                        MultiRisWeb.WsCordillera.ServiceMultiris serviceMultirisWsCordillera = new MultiRisWeb.WsCordillera.ServiceMultiris();
                        MultiRisWeb.WsCordillera.DocumentosParameters documentos = new MultiRisWeb.WsCordillera.DocumentosParameters();
                        MultiRisWeb.WsCordillera.CredencialesParameters credenciales = new MultiRisWeb.WsCordillera.CredencialesParameters();

                        credenciales.username = institucionCredenciales.username;
                        credenciales.password = institucionCredenciales.password;
                        documentos.codExamen = codExamen;
                        documentos.numeroAcceso = numeroAcceso;
                        documentosExamen = serviceMultirisWsCordillera.GetDocumentosExamen(credenciales, documentos);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                new IradLogFile.LogFile(ex.ToString());
            }
            return documentosExamen;
        }

        public static DataTable GetEstudiosRelacionados(string idPaciente, int idInstitucion)
        {
            DataTable estudiosRelacionados = new DataTable();
            InstitucionCredencialesDomain institucionCredenciales = InstitucionCredencialesDataAccess.GetById(idInstitucion);
            try
            {
                switch (idInstitucion)
                {
                    case 1:
                        MultiRisWeb.WsCordillera.ServiceMultiris serviceMultirisWsCordillera = new MultiRisWeb.WsCordillera.ServiceMultiris();
                        MultiRisWeb.WsCordillera.CredencialesParameters credenciales = new MultiRisWeb.WsCordillera.CredencialesParameters();
                        credenciales.username = institucionCredenciales.username;
                        credenciales.password = institucionCredenciales.password;
                        estudiosRelacionados = serviceMultirisWsCordillera.GetEstudiosRelacionados(credenciales, idPaciente);
                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                new IradLogFile.LogFile(ex.ToString());
            }
            return estudiosRelacionados;
        }

        public static void WriteLog(string message, string nombreInstitucion)
        {
            string path = ConfigurationManager.AppSettings["RutaArchivoLog"] + "\\LogServicioEnviarInforme_" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";
            StreamWriter streamWriter = (StreamWriter)null;
            try
            {
                streamWriter = System.IO.File.AppendText(path);
                streamWriter.WriteLine(string.Format("{0} - {1} - {2}.", (object)DateTime.Now, (object)nombreInstitucion, (object)message));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                streamWriter?.Close();
            }
        }

        public static byte[] GetBytesFromUrl(string url)
        {
            WebResponse response = WebRequest.Create(url).GetResponse();
            byte[] bytesFromUrl;
            using (BinaryReader binaryReader = new BinaryReader(response.GetResponseStream()))
            {
                bytesFromUrl = binaryReader.ReadBytes(500000);
                binaryReader.Close();
            }
            response.Close();
            return bytesFromUrl;
        }

        public static long InsertInformeOIT(int idInstitucion, RisInformeOITDomain informeOIT)
        {
            long result = 0;           
            InstitucionCredencialesDomain byId2 = InstitucionCredencialesDataAccess.GetById(idInstitucion);
            try
            {
                switch (idInstitucion)
                {
                    case 2:
                        MultiRisWeb.WsCordillera.ServiceMultiris serviceMultirisWsCordillera = new MultiRisWeb.WsCordillera.ServiceMultiris();
                        MultiRisWeb.WsCordillera.InformeOITParameters informeOit = new MultiRisWeb.WsCordillera.InformeOITParameters();
                        MultiRisWeb.WsCordillera.CredencialesParameters credenciales = new MultiRisWeb.WsCordillera.CredencialesParameters();
                        credenciales.username = byId2.username;
                        credenciales.password = byId2.password;
                        informeOit.id = informeOIT.id;
                        informeOit.nombre = informeOIT.nombre;
                        informeOit.idpaciente = informeOIT.idPaciente;
                        informeOit.fecha_radiografia = informeOIT.fechaRadiografia;
                        informeOit.numero_radiografia = informeOIT.numeroRadiografia;
                        informeOit.radiografia_digital = Convert.ToInt32(informeOIT.radiografiaDigital);
                        informeOit.lectura_negatoscopio = Convert.ToInt32(informeOIT.lecturaNegatoscopio);
                        informeOit.tecnica_qualidaden = Convert.ToInt32(informeOIT.tecnicaQualidaden);
                        informeOit.radiografia_normal = Convert.ToInt32(informeOIT.radiografiaNormal);
                        informeOit.comentario = informeOIT.comentario;
                        informeOit.anormalidad_parenquimatosa = Convert.ToInt32(informeOIT.anormalidadParenquimatosa);
                        informeOit.primaria1 = Convert.ToInt32(informeOIT.primaria1);
                        informeOit.primaria2 = Convert.ToInt32(informeOIT.primaria2);
                        informeOit.primaria3 = Convert.ToInt32(informeOIT.primaria3);
                        informeOit.secundaria1 = Convert.ToInt32(informeOIT.secundaria1);
                        informeOit.secundaria2 = Convert.ToInt32(informeOIT.secundaria2);
                        informeOit.secundaria3 = Convert.ToInt32(informeOIT.secundaria3);
                        informeOit.zonas1 = Convert.ToInt32(informeOIT.zonas1);
                        informeOit.profusion1 = Convert.ToInt32(informeOIT.profusion1);
                        informeOit.profusion2 = Convert.ToInt32(informeOIT.profusion2);
                        informeOit.profusion3 = Convert.ToInt32(informeOIT.profusion3);
                        informeOit.profusion4 = Convert.ToInt32(informeOIT.profusion4);
                        informeOit.opacidades_pequenas1 = Convert.ToInt32(informeOIT.opacidadesPequenas1);
                        informeOit.anormalidad_pleural = Convert.ToInt32(informeOIT.anormalidadPleural);
                        informeOit.placas_pleurales = Convert.ToInt32(informeOIT.placasPleurales);
                        informeOit.placas_pleurales_sitio_perfil = Convert.ToInt32(informeOIT.placasPleuralesSitioPerfil);
                        informeOit.placas_pleurales_sitio_frente = Convert.ToInt32(informeOIT.placasPleuralesSitioFrente);
                        informeOit.placas_pleurales_sitio_diagrama = Convert.ToInt32(informeOIT.placasPleuralesSitioDiagrama);
                        informeOit.placas_pleurales_sitio_otro = Convert.ToInt32(informeOIT.placasPleuralesSitioOtro);
                        informeOit.placas_pleurales_calcificacion_perfil = Convert.ToInt32(informeOIT.placasPleuralesCalcificacionPerfil);
                        informeOit.placas_pleurales_calcificacion_frente = Convert.ToInt32(informeOIT.placasPleuralesCalcificacionFrente);
                        informeOit.placas_pleurales_calcificacion_diagrama = Convert.ToInt32(informeOIT.placasPleuralesCalcificacionDiagrama);
                        informeOit.placas_pleurales_calcificacion_otro = Convert.ToInt32(informeOIT.placasPleuralesCalcificacionOtro);
                        informeOit.placas_pleurales_extencion_pared1 = Convert.ToInt32(informeOIT.placasPleuralesExtencionPared1);
                        informeOit.placas_pleurales_extencion_pared2 = Convert.ToInt32(informeOIT.placasPleuralesExtencionPared2);
                        informeOit.placas_pleurales_ancho1 = Convert.ToInt32(informeOIT.placasPleuralesAncho1);
                        informeOit.placas_pleurales_ancho2 = Convert.ToInt32(informeOIT.placasPleuralesAncho2);
                        informeOit.obliteracion_angulo_costofrenico = Convert.ToInt32(informeOIT.obliteracionAnguloCostofrenico);
                        informeOit.engrosamiento_pleural_difuso = Convert.ToInt32(informeOIT.engrosamientoPleuralDifuso);
                        informeOit.engrosamiento_pleural_difuso_sitio_perfil = Convert.ToInt32(informeOIT.engrosamientoPleuralDifusoSitioPerfil);
                        informeOit.engrosamiento_pleural_difuso_sitio_frente = Convert.ToInt32(informeOIT.engrosamientoPleuralDifusoSitioFrente);
                        informeOit.engrosamiento_pleural_difuso_calcificacion_perfil = Convert.ToInt32(informeOIT.engrosamientoPleuralDifusoCalcificacionPerfil);
                        informeOit.engrosamiento_pleural_difuso_calcificacion_frente = Convert.ToInt32(informeOIT.engrosamientoPleuralDifusoCalcificacionFrente);
                        informeOit.engrosamiento_pleural_difuso_extencion_pared1 = Convert.ToInt32(informeOIT.engrosamientoPleuralDifusoExtencionPared1);
                        informeOit.engrosamiento_pleural_difuso_extencion_pared2 = Convert.ToInt32(informeOIT.engrosamientoPleuralDifusoExtencionPared2);
                        informeOit.engrosamiento_pleural_difuso_ancho1 = Convert.ToInt32(informeOIT.engrosamientoPleuralDifusoAncho1);
                        informeOit.engrosamiento_pleural_difuso_ancho2 = Convert.ToInt32(informeOIT.engrosamientoPleuralDifusoAncho2);
                        informeOit.otras_anormalidades = Convert.ToInt32(informeOIT.otrasAnormalidades);
                        informeOit.simbolo_aa = informeOIT.simbolo_aa;
                        informeOit.simbolo_at = informeOIT.simbolo_at;
                        informeOit.simbolo_ax = informeOIT.simbolo_ax;
                        informeOit.simbolo_bu = informeOIT.simbolo_bu;
                        informeOit.simbolo_ca = informeOIT.simbolo_ca;
                        informeOit.simbolo_cg = informeOIT.simbolo_cg;
                        informeOit.simbolo_cn = informeOIT.simbolo_cn;
                        informeOit.simbolo_co = informeOIT.simbolo_co;
                        informeOit.simbolo_cp = informeOIT.simbolo_cp;
                        informeOit.simbolo_cv = informeOIT.simbolo_cv;
                        informeOit.simbolo_di = informeOIT.simbolo_di;
                        informeOit.simbolo_ef = informeOIT.simbolo_ef;
                        informeOit.simbolo_em = informeOIT.simbolo_em;
                        informeOit.simbolo_es = informeOIT.simbolo_es;
                        informeOit.simbolo_fr = informeOIT.simbolo_fr;
                        informeOit.simbolo_hi = informeOIT.simbolo_hi;
                        informeOit.simbolo_ho = informeOIT.simbolo_ho;
                        informeOit.simbolo_id = informeOIT.simbolo_id;
                        informeOit.simbolo_ih = informeOIT.simbolo_ih;
                        informeOit.simbolo_kl = informeOIT.simbolo_kl;
                        informeOit.simbolo_me = informeOIT.simbolo_me;
                        informeOit.simbolo_pa = informeOIT.simbolo_pa;
                        informeOit.simbolo_pb = informeOIT.simbolo_pb;
                        informeOit.simbolo_pi = informeOIT.simbolo_pi;
                        informeOit.simbolo_px = informeOIT.simbolo_px;
                        informeOit.simbolo_ra = informeOIT.simbolo_ra;
                        informeOit.simbolo_rp = informeOIT.simbolo_rp;
                        informeOit.simbolo_tb = informeOIT.simbolo_tb;
                        informeOit.simbolo_od = informeOIT.simbolo_od;
                        informeOit.comentario_general = informeOIT.comentarioGeneral;
                        informeOit.fecha_lectura = informeOIT.fechaLectura;
                        informeOit.codexamen = informeOIT.codexamen;
                        informeOit.estado = informeOIT.estado;
                        informeOit.username_radiologo = "admin";
                   
                        result = serviceMultirisWsCordillera.InsertInformeOIT(credenciales, informeOit);
                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                new IradLogFile.LogFile(ex.ToString());               
            }
            return result;
        }

        public static DataTable GetComentarios(int idInstitucion,string codExamen,string numeroAcceso)
        {
            DataTable comentarios = new DataTable();
            InstitucionDomain institucion = InstitucionDataAccess.GetById(idInstitucion);
            InstitucionCredencialesDomain byId2 = InstitucionCredencialesDataAccess.GetById(institucion.id_institucion);
            try
            {
                switch (idInstitucion)
                {
                    case 1:
                        MultiRisWeb.WsCordillera.ServiceMultiris serviceMultirisWSCordillera = new MultiRisWeb.WsCordillera.ServiceMultiris();
                        MultiRisWeb.WsCordillera.DocumentosParameters documentos = new MultiRisWeb.WsCordillera.DocumentosParameters();
                        MultiRisWeb.WsCordillera.CredencialesParameters credenciales = new MultiRisWeb.WsCordillera.CredencialesParameters();
                        credenciales.username = byId2.username;
                        credenciales.password = byId2.password;
                        documentos.codExamen = codExamen;
                        documentos.numeroAcceso = numeroAcceso;                       
                        comentarios = serviceMultirisWSCordillera.GetComentarios(credenciales, documentos);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                InstitucionDataAccess.UpdateFlagComentarios(idInstitucion, 1);
                if (ConfigurationManager.AppSettings["EnviaMailSoporte"].ToString().Equals("1"))
                    clsCorreo.EnvioMail(institucion.nombre, institucion.aetitle);

                new IradLogFile.LogFile(ex.ToString());
            }
            return comentarios;
        }

        public static async Task<DataTable> GetComentariosWS(int idInstitucion,string codExamen,string numeroAcceso)
        {
            DataTable comentariosWs = new DataTable();
            InstitucionDomain institucion = InstitucionDataAccess.GetById(idInstitucion);
            InstitucionCredencialesDomain credencialesInstitucion = InstitucionCredencialesDataAccess.GetById(institucion.id_institucion);
            try
            {
                switch (idInstitucion)
                {
                    case 1:
                        MultiRisWeb.WsCordillera.ServiceMultiris serviceMultirisWsCordillera = new MultiRisWeb.WsCordillera.ServiceMultiris();
                        MultiRisWeb.WsCordillera.DocumentosParameters documentos = new MultiRisWeb.WsCordillera.DocumentosParameters();
                        MultiRisWeb.WsCordillera.CredencialesParameters credenciales = new MultiRisWeb.WsCordillera.CredencialesParameters();
                        credenciales.username = credencialesInstitucion.username;
                        credenciales.password = credencialesInstitucion.password;
                        documentos.codExamen = codExamen;
                        documentos.numeroAcceso = numeroAcceso;                       
                        comentariosWs = serviceMultirisWsCordillera.GetComentarios(credenciales, documentos);
                        break;
                    default:

                        break;
                }
            }
            catch (Exception ex)
            {
                InstitucionDataAccess.UpdateFlagComentarios(institucion.id_institucion, 1);
                if (ConfigurationManager.AppSettings["EnviaMailSoporte"].ToString().Equals("1"))
                    clsCorreo.EnvioMail(institucion.nombre, institucion.aetitle);

                new IradLogFile.LogFile(ex.ToString());
            }
            return comentariosWs;
        }

        public static long saveComentario(int idInstitucion,string codExamen,string comentario,string userName)
        {
            long result = 0;           
            InstitucionCredencialesDomain institucionCredenciales = InstitucionCredencialesDataAccess.GetById(idInstitucion);
            RisExamenDomain byCodExamen = RisExamenDataAccess.GetByCodExamen(codExamen);
            try
            {
                switch (idInstitucion)
                {
                    case 1:
                        MultiRisWeb.WsCordillera.ServiceMultiris serviceMultirisWsCordillera = new MultiRisWeb.WsCordillera.ServiceMultiris();
                        MultiRisWeb.WsCordillera.ComentariosParameters comentarios = new MultiRisWeb.WsCordillera.ComentariosParameters();
                        MultiRisWeb.WsCordillera.CredencialesParameters credenciales = new MultiRisWeb.WsCordillera.CredencialesParameters();
                        credenciales.username = institucionCredenciales.username;
                        credenciales.password = institucionCredenciales.password;
                        comentarios.codExamen = byCodExamen.codexamen;
                        comentarios.cantidad = 1;
                        comentarios.fecha = DateTime.Now;
                        comentarios.aetitle = byCodExamen.aetitle;
                        comentarios.texto = comentario;
                        comentarios.username = userName;
                       
                        result = serviceMultirisWsCordillera.SaveComentario(credenciales, comentarios);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                new IradLogFile.LogFile(ex.ToString());
            }
            return result;
        }
    }
}
