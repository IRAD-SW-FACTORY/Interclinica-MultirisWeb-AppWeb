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
                    case 2:
                        MultiRisWeb.WsLosCarrera.ServiceMultiris serviceMultirisWsLosCarrera = new MultiRisWeb.WsLosCarrera.ServiceMultiris();
                        MultiRisWeb.WsLosCarrera.CredencialesParameters credencialesLosCarrera = new MultiRisWeb.WsLosCarrera.CredencialesParameters();
                        credencialesLosCarrera.username = byId.username;
                        credencialesLosCarrera.password = byId.password;
                        result = serviceMultirisWsLosCarrera.GetAntecedentesClinicos(credencialesLosCarrera, codexamen);
                        break;
                    case 3:
                        MultiRisWeb.WsTarapaca.ServiceMultiris serviceMultirisWsTarapaca = new MultiRisWeb.WsTarapaca.ServiceMultiris();
                        MultiRisWeb.WsTarapaca.CredencialesParameters credencialesTarapaca = new MultiRisWeb.WsTarapaca.CredencialesParameters();
                        credencialesTarapaca.username = byId.username;
                        credencialesTarapaca.password = byId.password;
                        result = serviceMultirisWsTarapaca.GetAntecedentesClinicos(credencialesTarapaca, codexamen);
                        break;
                    case 4:
                        MultiRisWeb.WsLosLeones.ServiceMultiris serviceMultirisWsLosLeones = new MultiRisWeb.WsLosLeones.ServiceMultiris();
                        MultiRisWeb.WsLosLeones.CredencialesParameters credencialesLosLeones = new MultiRisWeb.WsLosLeones.CredencialesParameters();
                        credencialesLosLeones.username = byId.username;
                        credencialesLosLeones.password = byId.password;
                        result = serviceMultirisWsLosLeones.GetAntecedentesClinicos(credencialesLosLeones, codexamen);
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
            new IradLogFile.LogFile("Institucion : " + idInstitucion.ToString());
            InstitucionCredencialesDomain institucionCredenciales = InstitucionCredencialesDataAccess.GetById(idInstitucion);
            new IradLogFile.LogFile("username : " + institucionCredenciales.username);
            new IradLogFile.LogFile("pass : " + institucionCredenciales.password);
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
                    case 2:
                        MultiRisWeb.WsLosCarrera.ServiceMultiris serviceMultirisWsLosCarrera = new MultiRisWeb.WsLosCarrera.ServiceMultiris();
                        MultiRisWeb.WsLosCarrera.CredencialesParameters credencialesLosCarrera = new MultiRisWeb.WsLosCarrera.CredencialesParameters();
                        credencialesLosCarrera.username = institucionCredenciales.username;
                        credencialesLosCarrera.password = institucionCredenciales.password;                      
                        result = serviceMultirisWsLosCarrera.GetcomentarioTM(credencialesLosCarrera, codexamen);                        
                        break;
                    case 3:
                        MultiRisWeb.WsTarapaca.ServiceMultiris serviceMultirisWsTarapaca = new MultiRisWeb.WsTarapaca.ServiceMultiris();
                        MultiRisWeb.WsTarapaca.CredencialesParameters credencialesTarapaca = new MultiRisWeb.WsTarapaca.CredencialesParameters();
                        credencialesTarapaca.username = institucionCredenciales.username;
                        credencialesTarapaca.password = institucionCredenciales.password;                       
                        result = serviceMultirisWsTarapaca.GetcomentarioTM(credencialesTarapaca, codexamen);
                        break;
                    case 4:
                        MultiRisWeb.WsLosLeones.ServiceMultiris serviceMultirisWsLosLeones = new MultiRisWeb.WsLosLeones.ServiceMultiris();
                        MultiRisWeb.WsLosLeones.CredencialesParameters credencialesLosLeones = new MultiRisWeb.WsLosLeones.CredencialesParameters();
                        credencialesLosLeones.username = institucionCredenciales.username;
                        credencialesLosLeones.password = institucionCredenciales.password;
                        result = serviceMultirisWsLosLeones.GetcomentarioTM(credencialesLosLeones, codexamen);
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
                    case 2:
                        MultiRisWeb.WsLosCarrera.ServiceMultiris serviceMultirisWsLosCarrera = new MultiRisWeb.WsLosCarrera.ServiceMultiris();
                        MultiRisWeb.WsLosCarrera.CredencialesParameters credencialesLosCarrera = new MultiRisWeb.WsLosCarrera.CredencialesParameters();
                        credencialesLosCarrera.username = institucionCredenciales.username;
                        credencialesLosCarrera.password = institucionCredenciales.password;
                        serviceMultirisWsLosCarrera.SolicitudExamen(credencialesLosCarrera, codexamen, "");
                        break;
                    case 3:
                        MultiRisWeb.WsTarapaca.ServiceMultiris serviceMultirisWsTarapaca = new MultiRisWeb.WsTarapaca.ServiceMultiris();
                        MultiRisWeb.WsTarapaca.CredencialesParameters credencialesTarapaca = new MultiRisWeb.WsTarapaca.CredencialesParameters();
                        credencialesTarapaca.username = institucionCredenciales.username;
                        credencialesTarapaca.password = institucionCredenciales.password;
                        serviceMultirisWsTarapaca.SolicitudExamen(credencialesTarapaca, codexamen, "");
                        break;
                    case 4:
                        MultiRisWeb.WsLosLeones.ServiceMultiris serviceMultirisWsLosLeones = new MultiRisWeb.WsLosLeones.ServiceMultiris();
                        MultiRisWeb.WsLosLeones.CredencialesParameters credencialesLosLeones = new MultiRisWeb.WsLosLeones.CredencialesParameters();
                        credencialesLosLeones.username = institucionCredenciales.username;
                        credencialesLosLeones.password = institucionCredenciales.password;
                        serviceMultirisWsLosLeones.SolicitudExamen(credencialesLosLeones, codexamen, "");
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
                    case 2:
                        MultiRisWeb.WsLosCarrera.ServiceMultiris serviceMultirisWsLosCarrera = new MultiRisWeb.WsLosCarrera.ServiceMultiris();
                        MultiRisWeb.WsLosCarrera.DocumentosParameters documentosLosCarrera = new MultiRisWeb.WsLosCarrera.DocumentosParameters();
                        MultiRisWeb.WsLosCarrera.CredencialesParameters credencialesLosCarrera = new MultiRisWeb.WsLosCarrera.CredencialesParameters();

                        credencialesLosCarrera.username = institucionCredenciales.username;
                        credencialesLosCarrera.password = institucionCredenciales.password;
                        documentosLosCarrera.codExamen = codExamen;
                        documentosLosCarrera.numeroAcceso = numeroAcceso;
                        documentosExamen = serviceMultirisWsLosCarrera.GetDocumentosExamen(credencialesLosCarrera, documentosLosCarrera);
                        break;
                    case 3:
                        MultiRisWeb.WsTarapaca.ServiceMultiris serviceMultirisWsTarapaca = new MultiRisWeb.WsTarapaca.ServiceMultiris();
                        MultiRisWeb.WsTarapaca.DocumentosParameters documentosTarapaca = new MultiRisWeb.WsTarapaca.DocumentosParameters();
                        MultiRisWeb.WsTarapaca.CredencialesParameters credencialesTarapaca = new MultiRisWeb.WsTarapaca.CredencialesParameters();

                        credencialesTarapaca.username = institucionCredenciales.username;
                        credencialesTarapaca.password = institucionCredenciales.password;
                        documentosTarapaca.codExamen = codExamen;
                        documentosTarapaca.numeroAcceso = numeroAcceso;
                        documentosExamen = serviceMultirisWsTarapaca.GetDocumentosExamen(credencialesTarapaca, documentosTarapaca);
                        break;
                    case 4:
                        MultiRisWeb.WsLosLeones.ServiceMultiris serviceMultirisWsLosLeones = new MultiRisWeb.WsLosLeones.ServiceMultiris();
                        MultiRisWeb.WsLosLeones.DocumentosParameters documentosLosLeones = new MultiRisWeb.WsLosLeones.DocumentosParameters();
                        MultiRisWeb.WsLosLeones.CredencialesParameters credencialesLosLeones = new MultiRisWeb.WsLosLeones.CredencialesParameters();

                        credencialesLosLeones.username = institucionCredenciales.username;
                        credencialesLosLeones.password = institucionCredenciales.password;
                        documentosLosLeones.codExamen = codExamen;
                        documentosLosLeones.numeroAcceso = numeroAcceso;
                        documentosExamen = serviceMultirisWsLosLeones.GetDocumentosExamen(credencialesLosLeones, documentosLosLeones);
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
                    case 2:
                        MultiRisWeb.WsLosCarrera.ServiceMultiris serviceMultirisWsLosCarrra = new MultiRisWeb.WsLosCarrera.ServiceMultiris();
                        MultiRisWeb.WsLosCarrera.CredencialesParameters credencialesLosCarrra = new MultiRisWeb.WsLosCarrera.CredencialesParameters();
                        credencialesLosCarrra.username = institucionCredenciales.username;
                        credencialesLosCarrra.password = institucionCredenciales.password;
                        estudiosRelacionados = serviceMultirisWsLosCarrra.GetEstudiosRelacionados(credencialesLosCarrra, idPaciente);
                        break;
                    case 3:
                        MultiRisWeb.WsTarapaca.ServiceMultiris serviceMultirisWsTarapaca = new MultiRisWeb.WsTarapaca.ServiceMultiris();
                        MultiRisWeb.WsTarapaca.CredencialesParameters credencialesTarapaca = new MultiRisWeb.WsTarapaca.CredencialesParameters();
                        credencialesTarapaca.username = institucionCredenciales.username;
                        credencialesTarapaca.password = institucionCredenciales.password;
                        estudiosRelacionados = serviceMultirisWsTarapaca.GetEstudiosRelacionados(credencialesTarapaca, idPaciente);
                        break;
                    case 4:
                        MultiRisWeb.WsLosLeones.ServiceMultiris serviceMultirisWsLosLeones = new MultiRisWeb.WsLosLeones.ServiceMultiris();
                        MultiRisWeb.WsLosLeones.CredencialesParameters credencialesLosLeones = new MultiRisWeb.WsLosLeones.CredencialesParameters();
                        credencialesLosLeones.username = institucionCredenciales.username;
                        credencialesLosLeones.password = institucionCredenciales.password;
                        estudiosRelacionados = serviceMultirisWsLosLeones.GetEstudiosRelacionados(credencialesLosLeones, idPaciente);
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
                    case 1:
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
                    case 2:
                        MultiRisWeb.WsLosCarrera.ServiceMultiris serviceMultirisWsLosCarrera = new MultiRisWeb.WsLosCarrera.ServiceMultiris();
                        MultiRisWeb.WsLosCarrera.InformeOITParameters informeOitLosCarrera = new MultiRisWeb.WsLosCarrera.InformeOITParameters();
                        MultiRisWeb.WsLosCarrera.CredencialesParameters credencialesLosCarrera = new MultiRisWeb.WsLosCarrera.CredencialesParameters();
                        credencialesLosCarrera.username = byId2.username;
                        credencialesLosCarrera.password = byId2.password;
                        informeOitLosCarrera.id = informeOIT.id;
                        informeOitLosCarrera.nombre = informeOIT.nombre;
                        informeOitLosCarrera.idpaciente = informeOIT.idPaciente;
                        informeOitLosCarrera.fecha_radiografia = informeOIT.fechaRadiografia;
                        informeOitLosCarrera.numero_radiografia = informeOIT.numeroRadiografia;
                        informeOitLosCarrera.radiografia_digital = Convert.ToInt32(informeOIT.radiografiaDigital);
                        informeOitLosCarrera.lectura_negatoscopio = Convert.ToInt32(informeOIT.lecturaNegatoscopio);
                        informeOitLosCarrera.tecnica_qualidaden = Convert.ToInt32(informeOIT.tecnicaQualidaden);
                        informeOitLosCarrera.radiografia_normal = Convert.ToInt32(informeOIT.radiografiaNormal);
                        informeOitLosCarrera.comentario = informeOIT.comentario;
                        informeOitLosCarrera.anormalidad_parenquimatosa = Convert.ToInt32(informeOIT.anormalidadParenquimatosa);
                        informeOitLosCarrera.primaria1 = Convert.ToInt32(informeOIT.primaria1);
                        informeOitLosCarrera.primaria2 = Convert.ToInt32(informeOIT.primaria2);
                        informeOitLosCarrera.primaria3 = Convert.ToInt32(informeOIT.primaria3);
                        informeOitLosCarrera.secundaria1 = Convert.ToInt32(informeOIT.secundaria1);
                        informeOitLosCarrera.secundaria2 = Convert.ToInt32(informeOIT.secundaria2);
                        informeOitLosCarrera.secundaria3 = Convert.ToInt32(informeOIT.secundaria3);
                        informeOitLosCarrera.zonas1 = Convert.ToInt32(informeOIT.zonas1);
                        informeOitLosCarrera.profusion1 = Convert.ToInt32(informeOIT.profusion1);
                        informeOitLosCarrera.profusion2 = Convert.ToInt32(informeOIT.profusion2);
                        informeOitLosCarrera.profusion3 = Convert.ToInt32(informeOIT.profusion3);
                        informeOitLosCarrera.profusion4 = Convert.ToInt32(informeOIT.profusion4);
                        informeOitLosCarrera.opacidades_pequenas1 = Convert.ToInt32(informeOIT.opacidadesPequenas1);
                        informeOitLosCarrera.anormalidad_pleural = Convert.ToInt32(informeOIT.anormalidadPleural);
                        informeOitLosCarrera.placas_pleurales = Convert.ToInt32(informeOIT.placasPleurales);
                        informeOitLosCarrera.placas_pleurales_sitio_perfil = Convert.ToInt32(informeOIT.placasPleuralesSitioPerfil);
                        informeOitLosCarrera.placas_pleurales_sitio_frente = Convert.ToInt32(informeOIT.placasPleuralesSitioFrente);
                        informeOitLosCarrera.placas_pleurales_sitio_diagrama = Convert.ToInt32(informeOIT.placasPleuralesSitioDiagrama);
                        informeOitLosCarrera.placas_pleurales_sitio_otro = Convert.ToInt32(informeOIT.placasPleuralesSitioOtro);
                        informeOitLosCarrera.placas_pleurales_calcificacion_perfil = Convert.ToInt32(informeOIT.placasPleuralesCalcificacionPerfil);
                        informeOitLosCarrera.placas_pleurales_calcificacion_frente = Convert.ToInt32(informeOIT.placasPleuralesCalcificacionFrente);
                        informeOitLosCarrera.placas_pleurales_calcificacion_diagrama = Convert.ToInt32(informeOIT.placasPleuralesCalcificacionDiagrama);
                        informeOitLosCarrera.placas_pleurales_calcificacion_otro = Convert.ToInt32(informeOIT.placasPleuralesCalcificacionOtro);
                        informeOitLosCarrera.placas_pleurales_extencion_pared1 = Convert.ToInt32(informeOIT.placasPleuralesExtencionPared1);
                        informeOitLosCarrera.placas_pleurales_extencion_pared2 = Convert.ToInt32(informeOIT.placasPleuralesExtencionPared2);
                        informeOitLosCarrera.placas_pleurales_ancho1 = Convert.ToInt32(informeOIT.placasPleuralesAncho1);
                        informeOitLosCarrera.placas_pleurales_ancho2 = Convert.ToInt32(informeOIT.placasPleuralesAncho2);
                        informeOitLosCarrera.obliteracion_angulo_costofrenico = Convert.ToInt32(informeOIT.obliteracionAnguloCostofrenico);
                        informeOitLosCarrera.engrosamiento_pleural_difuso = Convert.ToInt32(informeOIT.engrosamientoPleuralDifuso);
                        informeOitLosCarrera.engrosamiento_pleural_difuso_sitio_perfil = Convert.ToInt32(informeOIT.engrosamientoPleuralDifusoSitioPerfil);
                        informeOitLosCarrera.engrosamiento_pleural_difuso_sitio_frente = Convert.ToInt32(informeOIT.engrosamientoPleuralDifusoSitioFrente);
                        informeOitLosCarrera.engrosamiento_pleural_difuso_calcificacion_perfil = Convert.ToInt32(informeOIT.engrosamientoPleuralDifusoCalcificacionPerfil);
                        informeOitLosCarrera.engrosamiento_pleural_difuso_calcificacion_frente = Convert.ToInt32(informeOIT.engrosamientoPleuralDifusoCalcificacionFrente);
                        informeOitLosCarrera.engrosamiento_pleural_difuso_extencion_pared1 = Convert.ToInt32(informeOIT.engrosamientoPleuralDifusoExtencionPared1);
                        informeOitLosCarrera.engrosamiento_pleural_difuso_extencion_pared2 = Convert.ToInt32(informeOIT.engrosamientoPleuralDifusoExtencionPared2);
                        informeOitLosCarrera.engrosamiento_pleural_difuso_ancho1 = Convert.ToInt32(informeOIT.engrosamientoPleuralDifusoAncho1);
                        informeOitLosCarrera.engrosamiento_pleural_difuso_ancho2 = Convert.ToInt32(informeOIT.engrosamientoPleuralDifusoAncho2);
                        informeOitLosCarrera.otras_anormalidades = Convert.ToInt32(informeOIT.otrasAnormalidades);
                        informeOitLosCarrera.simbolo_aa = informeOIT.simbolo_aa;
                        informeOitLosCarrera.simbolo_at = informeOIT.simbolo_at;
                        informeOitLosCarrera.simbolo_ax = informeOIT.simbolo_ax;
                        informeOitLosCarrera.simbolo_bu = informeOIT.simbolo_bu;
                        informeOitLosCarrera.simbolo_ca = informeOIT.simbolo_ca;
                        informeOitLosCarrera.simbolo_cg = informeOIT.simbolo_cg;
                        informeOitLosCarrera.simbolo_cn = informeOIT.simbolo_cn;
                        informeOitLosCarrera.simbolo_co = informeOIT.simbolo_co;
                        informeOitLosCarrera.simbolo_cp = informeOIT.simbolo_cp;
                        informeOitLosCarrera.simbolo_cv = informeOIT.simbolo_cv;
                        informeOitLosCarrera.simbolo_di = informeOIT.simbolo_di;
                        informeOitLosCarrera.simbolo_ef = informeOIT.simbolo_ef;
                        informeOitLosCarrera.simbolo_em = informeOIT.simbolo_em;
                        informeOitLosCarrera.simbolo_es = informeOIT.simbolo_es;
                        informeOitLosCarrera.simbolo_fr = informeOIT.simbolo_fr;
                        informeOitLosCarrera.simbolo_hi = informeOIT.simbolo_hi;
                        informeOitLosCarrera.simbolo_ho = informeOIT.simbolo_ho;
                        informeOitLosCarrera.simbolo_id = informeOIT.simbolo_id;
                        informeOitLosCarrera.simbolo_ih = informeOIT.simbolo_ih;
                        informeOitLosCarrera.simbolo_kl = informeOIT.simbolo_kl;
                        informeOitLosCarrera.simbolo_me = informeOIT.simbolo_me;
                        informeOitLosCarrera.simbolo_pa = informeOIT.simbolo_pa;
                        informeOitLosCarrera.simbolo_pb = informeOIT.simbolo_pb;
                        informeOitLosCarrera.simbolo_pi = informeOIT.simbolo_pi;
                        informeOitLosCarrera.simbolo_px = informeOIT.simbolo_px;
                        informeOitLosCarrera.simbolo_ra = informeOIT.simbolo_ra;
                        informeOitLosCarrera.simbolo_rp = informeOIT.simbolo_rp;
                        informeOitLosCarrera.simbolo_tb = informeOIT.simbolo_tb;
                        informeOitLosCarrera.simbolo_od = informeOIT.simbolo_od;
                        informeOitLosCarrera.comentario_general = informeOIT.comentarioGeneral;
                        informeOitLosCarrera.fecha_lectura = informeOIT.fechaLectura;
                        informeOitLosCarrera.codexamen = informeOIT.codexamen;
                        informeOitLosCarrera.estado = informeOIT.estado;
                        informeOitLosCarrera.username_radiologo = "admin";

                        result = serviceMultirisWsLosCarrera.InsertInformeOIT(credencialesLosCarrera, informeOitLosCarrera);
                        break;
                    case 3:
                        MultiRisWeb.WsTarapaca.ServiceMultiris serviceMultirisWsTarapaca = new MultiRisWeb.WsTarapaca.ServiceMultiris();
                        MultiRisWeb.WsTarapaca.InformeOITParameters informeOitTarapaca = new MultiRisWeb.WsTarapaca.InformeOITParameters();
                        MultiRisWeb.WsTarapaca.CredencialesParameters credencialesTarapaca = new MultiRisWeb.WsTarapaca.CredencialesParameters();
                        credencialesTarapaca.username = byId2.username;
                        credencialesTarapaca.password = byId2.password;
                        informeOitTarapaca.id = informeOIT.id;
                        informeOitTarapaca.nombre = informeOIT.nombre;
                        informeOitTarapaca.idpaciente = informeOIT.idPaciente;
                        informeOitTarapaca.fecha_radiografia = informeOIT.fechaRadiografia;
                        informeOitTarapaca.numero_radiografia = informeOIT.numeroRadiografia;
                        informeOitTarapaca.radiografia_digital = Convert.ToInt32(informeOIT.radiografiaDigital);
                        informeOitTarapaca.lectura_negatoscopio = Convert.ToInt32(informeOIT.lecturaNegatoscopio);
                        informeOitTarapaca.tecnica_qualidaden = Convert.ToInt32(informeOIT.tecnicaQualidaden);
                        informeOitTarapaca.radiografia_normal = Convert.ToInt32(informeOIT.radiografiaNormal);
                        informeOitTarapaca.comentario = informeOIT.comentario;
                        informeOitTarapaca.anormalidad_parenquimatosa = Convert.ToInt32(informeOIT.anormalidadParenquimatosa);
                        informeOitTarapaca.primaria1 = Convert.ToInt32(informeOIT.primaria1);
                        informeOitTarapaca.primaria2 = Convert.ToInt32(informeOIT.primaria2);
                        informeOitTarapaca.primaria3 = Convert.ToInt32(informeOIT.primaria3);
                        informeOitTarapaca.secundaria1 = Convert.ToInt32(informeOIT.secundaria1);
                        informeOitTarapaca.secundaria2 = Convert.ToInt32(informeOIT.secundaria2);
                        informeOitTarapaca.secundaria3 = Convert.ToInt32(informeOIT.secundaria3);
                        informeOitTarapaca.zonas1 = Convert.ToInt32(informeOIT.zonas1);
                        informeOitTarapaca.profusion1 = Convert.ToInt32(informeOIT.profusion1);
                        informeOitTarapaca.profusion2 = Convert.ToInt32(informeOIT.profusion2);
                        informeOitTarapaca.profusion3 = Convert.ToInt32(informeOIT.profusion3);
                        informeOitTarapaca.profusion4 = Convert.ToInt32(informeOIT.profusion4);
                        informeOitTarapaca.opacidades_pequenas1 = Convert.ToInt32(informeOIT.opacidadesPequenas1);
                        informeOitTarapaca.anormalidad_pleural = Convert.ToInt32(informeOIT.anormalidadPleural);
                        informeOitTarapaca.placas_pleurales = Convert.ToInt32(informeOIT.placasPleurales);
                        informeOitTarapaca.placas_pleurales_sitio_perfil = Convert.ToInt32(informeOIT.placasPleuralesSitioPerfil);
                        informeOitTarapaca.placas_pleurales_sitio_frente = Convert.ToInt32(informeOIT.placasPleuralesSitioFrente);
                        informeOitTarapaca.placas_pleurales_sitio_diagrama = Convert.ToInt32(informeOIT.placasPleuralesSitioDiagrama);
                        informeOitTarapaca.placas_pleurales_sitio_otro = Convert.ToInt32(informeOIT.placasPleuralesSitioOtro);
                        informeOitTarapaca.placas_pleurales_calcificacion_perfil = Convert.ToInt32(informeOIT.placasPleuralesCalcificacionPerfil);
                        informeOitTarapaca.placas_pleurales_calcificacion_frente = Convert.ToInt32(informeOIT.placasPleuralesCalcificacionFrente);
                        informeOitTarapaca.placas_pleurales_calcificacion_diagrama = Convert.ToInt32(informeOIT.placasPleuralesCalcificacionDiagrama);
                        informeOitTarapaca.placas_pleurales_calcificacion_otro = Convert.ToInt32(informeOIT.placasPleuralesCalcificacionOtro);
                        informeOitTarapaca.placas_pleurales_extencion_pared1 = Convert.ToInt32(informeOIT.placasPleuralesExtencionPared1);
                        informeOitTarapaca.placas_pleurales_extencion_pared2 = Convert.ToInt32(informeOIT.placasPleuralesExtencionPared2);
                        informeOitTarapaca.placas_pleurales_ancho1 = Convert.ToInt32(informeOIT.placasPleuralesAncho1);
                        informeOitTarapaca.placas_pleurales_ancho2 = Convert.ToInt32(informeOIT.placasPleuralesAncho2);
                        informeOitTarapaca.obliteracion_angulo_costofrenico = Convert.ToInt32(informeOIT.obliteracionAnguloCostofrenico);
                        informeOitTarapaca.engrosamiento_pleural_difuso = Convert.ToInt32(informeOIT.engrosamientoPleuralDifuso);
                        informeOitTarapaca.engrosamiento_pleural_difuso_sitio_perfil = Convert.ToInt32(informeOIT.engrosamientoPleuralDifusoSitioPerfil);
                        informeOitTarapaca.engrosamiento_pleural_difuso_sitio_frente = Convert.ToInt32(informeOIT.engrosamientoPleuralDifusoSitioFrente);
                        informeOitTarapaca.engrosamiento_pleural_difuso_calcificacion_perfil = Convert.ToInt32(informeOIT.engrosamientoPleuralDifusoCalcificacionPerfil);
                        informeOitTarapaca.engrosamiento_pleural_difuso_calcificacion_frente = Convert.ToInt32(informeOIT.engrosamientoPleuralDifusoCalcificacionFrente);
                        informeOitTarapaca.engrosamiento_pleural_difuso_extencion_pared1 = Convert.ToInt32(informeOIT.engrosamientoPleuralDifusoExtencionPared1);
                        informeOitTarapaca.engrosamiento_pleural_difuso_extencion_pared2 = Convert.ToInt32(informeOIT.engrosamientoPleuralDifusoExtencionPared2);
                        informeOitTarapaca.engrosamiento_pleural_difuso_ancho1 = Convert.ToInt32(informeOIT.engrosamientoPleuralDifusoAncho1);
                        informeOitTarapaca.engrosamiento_pleural_difuso_ancho2 = Convert.ToInt32(informeOIT.engrosamientoPleuralDifusoAncho2);
                        informeOitTarapaca.otras_anormalidades = Convert.ToInt32(informeOIT.otrasAnormalidades);
                        informeOitTarapaca.simbolo_aa = informeOIT.simbolo_aa;
                        informeOitTarapaca.simbolo_at = informeOIT.simbolo_at;
                        informeOitTarapaca.simbolo_ax = informeOIT.simbolo_ax;
                        informeOitTarapaca.simbolo_bu = informeOIT.simbolo_bu;
                        informeOitTarapaca.simbolo_ca = informeOIT.simbolo_ca;
                        informeOitTarapaca.simbolo_cg = informeOIT.simbolo_cg;
                        informeOitTarapaca.simbolo_cn = informeOIT.simbolo_cn;
                        informeOitTarapaca.simbolo_co = informeOIT.simbolo_co;
                        informeOitTarapaca.simbolo_cp = informeOIT.simbolo_cp;
                        informeOitTarapaca.simbolo_cv = informeOIT.simbolo_cv;
                        informeOitTarapaca.simbolo_di = informeOIT.simbolo_di;
                        informeOitTarapaca.simbolo_ef = informeOIT.simbolo_ef;
                        informeOitTarapaca.simbolo_em = informeOIT.simbolo_em;
                        informeOitTarapaca.simbolo_es = informeOIT.simbolo_es;
                        informeOitTarapaca.simbolo_fr = informeOIT.simbolo_fr;
                        informeOitTarapaca.simbolo_hi = informeOIT.simbolo_hi;
                        informeOitTarapaca.simbolo_ho = informeOIT.simbolo_ho;
                        informeOitTarapaca.simbolo_id = informeOIT.simbolo_id;
                        informeOitTarapaca.simbolo_ih = informeOIT.simbolo_ih;
                        informeOitTarapaca.simbolo_kl = informeOIT.simbolo_kl;
                        informeOitTarapaca.simbolo_me = informeOIT.simbolo_me;
                        informeOitTarapaca.simbolo_pa = informeOIT.simbolo_pa;
                        informeOitTarapaca.simbolo_pb = informeOIT.simbolo_pb;
                        informeOitTarapaca.simbolo_pi = informeOIT.simbolo_pi;
                        informeOitTarapaca.simbolo_px = informeOIT.simbolo_px;
                        informeOitTarapaca.simbolo_ra = informeOIT.simbolo_ra;
                        informeOitTarapaca.simbolo_rp = informeOIT.simbolo_rp;
                        informeOitTarapaca.simbolo_tb = informeOIT.simbolo_tb;
                        informeOitTarapaca.simbolo_od = informeOIT.simbolo_od;
                        informeOitTarapaca.comentario_general = informeOIT.comentarioGeneral;
                        informeOitTarapaca.fecha_lectura = informeOIT.fechaLectura;
                        informeOitTarapaca.codexamen = informeOIT.codexamen;
                        informeOitTarapaca.estado = informeOIT.estado;
                        informeOitTarapaca.username_radiologo = "admin";

                        result = serviceMultirisWsTarapaca.InsertInformeOIT(credencialesTarapaca, informeOitTarapaca);
                        break;
                    case 4:
                        MultiRisWeb.WsLosLeones.ServiceMultiris serviceMultirisWsLosLeones = new MultiRisWeb.WsLosLeones.ServiceMultiris();
                        MultiRisWeb.WsLosLeones.InformeOITParameters informeOitLosLeones = new MultiRisWeb.WsLosLeones.InformeOITParameters();
                        MultiRisWeb.WsLosLeones.CredencialesParameters credencialesLosLeones = new MultiRisWeb.WsLosLeones.CredencialesParameters();
                        credencialesLosLeones.username = byId2.username;
                        credencialesLosLeones.password = byId2.password;
                        informeOitLosLeones.id = informeOIT.id;
                        informeOitLosLeones.nombre = informeOIT.nombre;
                        informeOitLosLeones.idpaciente = informeOIT.idPaciente;
                        informeOitLosLeones.fecha_radiografia = informeOIT.fechaRadiografia;
                        informeOitLosLeones.numero_radiografia = informeOIT.numeroRadiografia;
                        informeOitLosLeones.radiografia_digital = Convert.ToInt32(informeOIT.radiografiaDigital);
                        informeOitLosLeones.lectura_negatoscopio = Convert.ToInt32(informeOIT.lecturaNegatoscopio);
                        informeOitLosLeones.tecnica_qualidaden = Convert.ToInt32(informeOIT.tecnicaQualidaden);
                        informeOitLosLeones.radiografia_normal = Convert.ToInt32(informeOIT.radiografiaNormal);
                        informeOitLosLeones.comentario = informeOIT.comentario;
                        informeOitLosLeones.anormalidad_parenquimatosa = Convert.ToInt32(informeOIT.anormalidadParenquimatosa);
                        informeOitLosLeones.primaria1 = Convert.ToInt32(informeOIT.primaria1);
                        informeOitLosLeones.primaria2 = Convert.ToInt32(informeOIT.primaria2);
                        informeOitLosLeones.primaria3 = Convert.ToInt32(informeOIT.primaria3);
                        informeOitLosLeones.secundaria1 = Convert.ToInt32(informeOIT.secundaria1);
                        informeOitLosLeones.secundaria2 = Convert.ToInt32(informeOIT.secundaria2);
                        informeOitLosLeones.secundaria3 = Convert.ToInt32(informeOIT.secundaria3);
                        informeOitLosLeones.zonas1 = Convert.ToInt32(informeOIT.zonas1);
                        informeOitLosLeones.profusion1 = Convert.ToInt32(informeOIT.profusion1);
                        informeOitLosLeones.profusion2 = Convert.ToInt32(informeOIT.profusion2);
                        informeOitLosLeones.profusion3 = Convert.ToInt32(informeOIT.profusion3);
                        informeOitLosLeones.profusion4 = Convert.ToInt32(informeOIT.profusion4);
                        informeOitLosLeones.opacidades_pequenas1 = Convert.ToInt32(informeOIT.opacidadesPequenas1);
                        informeOitLosLeones.anormalidad_pleural = Convert.ToInt32(informeOIT.anormalidadPleural);
                        informeOitLosLeones.placas_pleurales = Convert.ToInt32(informeOIT.placasPleurales);
                        informeOitLosLeones.placas_pleurales_sitio_perfil = Convert.ToInt32(informeOIT.placasPleuralesSitioPerfil);
                        informeOitLosLeones.placas_pleurales_sitio_frente = Convert.ToInt32(informeOIT.placasPleuralesSitioFrente);
                        informeOitLosLeones.placas_pleurales_sitio_diagrama = Convert.ToInt32(informeOIT.placasPleuralesSitioDiagrama);
                        informeOitLosLeones.placas_pleurales_sitio_otro = Convert.ToInt32(informeOIT.placasPleuralesSitioOtro);
                        informeOitLosLeones.placas_pleurales_calcificacion_perfil = Convert.ToInt32(informeOIT.placasPleuralesCalcificacionPerfil);
                        informeOitLosLeones.placas_pleurales_calcificacion_frente = Convert.ToInt32(informeOIT.placasPleuralesCalcificacionFrente);
                        informeOitLosLeones.placas_pleurales_calcificacion_diagrama = Convert.ToInt32(informeOIT.placasPleuralesCalcificacionDiagrama);
                        informeOitLosLeones.placas_pleurales_calcificacion_otro = Convert.ToInt32(informeOIT.placasPleuralesCalcificacionOtro);
                        informeOitLosLeones.placas_pleurales_extencion_pared1 = Convert.ToInt32(informeOIT.placasPleuralesExtencionPared1);
                        informeOitLosLeones.placas_pleurales_extencion_pared2 = Convert.ToInt32(informeOIT.placasPleuralesExtencionPared2);
                        informeOitLosLeones.placas_pleurales_ancho1 = Convert.ToInt32(informeOIT.placasPleuralesAncho1);
                        informeOitLosLeones.placas_pleurales_ancho2 = Convert.ToInt32(informeOIT.placasPleuralesAncho2);
                        informeOitLosLeones.obliteracion_angulo_costofrenico = Convert.ToInt32(informeOIT.obliteracionAnguloCostofrenico);
                        informeOitLosLeones.engrosamiento_pleural_difuso = Convert.ToInt32(informeOIT.engrosamientoPleuralDifuso);
                        informeOitLosLeones.engrosamiento_pleural_difuso_sitio_perfil = Convert.ToInt32(informeOIT.engrosamientoPleuralDifusoSitioPerfil);
                        informeOitLosLeones.engrosamiento_pleural_difuso_sitio_frente = Convert.ToInt32(informeOIT.engrosamientoPleuralDifusoSitioFrente);
                        informeOitLosLeones.engrosamiento_pleural_difuso_calcificacion_perfil = Convert.ToInt32(informeOIT.engrosamientoPleuralDifusoCalcificacionPerfil);
                        informeOitLosLeones.engrosamiento_pleural_difuso_calcificacion_frente = Convert.ToInt32(informeOIT.engrosamientoPleuralDifusoCalcificacionFrente);
                        informeOitLosLeones.engrosamiento_pleural_difuso_extencion_pared1 = Convert.ToInt32(informeOIT.engrosamientoPleuralDifusoExtencionPared1);
                        informeOitLosLeones.engrosamiento_pleural_difuso_extencion_pared2 = Convert.ToInt32(informeOIT.engrosamientoPleuralDifusoExtencionPared2);
                        informeOitLosLeones.engrosamiento_pleural_difuso_ancho1 = Convert.ToInt32(informeOIT.engrosamientoPleuralDifusoAncho1);
                        informeOitLosLeones.engrosamiento_pleural_difuso_ancho2 = Convert.ToInt32(informeOIT.engrosamientoPleuralDifusoAncho2);
                        informeOitLosLeones.otras_anormalidades = Convert.ToInt32(informeOIT.otrasAnormalidades);
                        informeOitLosLeones.simbolo_aa = informeOIT.simbolo_aa;
                        informeOitLosLeones.simbolo_at = informeOIT.simbolo_at;
                        informeOitLosLeones.simbolo_ax = informeOIT.simbolo_ax;
                        informeOitLosLeones.simbolo_bu = informeOIT.simbolo_bu;
                        informeOitLosLeones.simbolo_ca = informeOIT.simbolo_ca;
                        informeOitLosLeones.simbolo_cg = informeOIT.simbolo_cg;
                        informeOitLosLeones.simbolo_cn = informeOIT.simbolo_cn;
                        informeOitLosLeones.simbolo_co = informeOIT.simbolo_co;
                        informeOitLosLeones.simbolo_cp = informeOIT.simbolo_cp;
                        informeOitLosLeones.simbolo_cv = informeOIT.simbolo_cv;
                        informeOitLosLeones.simbolo_di = informeOIT.simbolo_di;
                        informeOitLosLeones.simbolo_ef = informeOIT.simbolo_ef;
                        informeOitLosLeones.simbolo_em = informeOIT.simbolo_em;
                        informeOitLosLeones.simbolo_es = informeOIT.simbolo_es;
                        informeOitLosLeones.simbolo_fr = informeOIT.simbolo_fr;
                        informeOitLosLeones.simbolo_hi = informeOIT.simbolo_hi;
                        informeOitLosLeones.simbolo_ho = informeOIT.simbolo_ho;
                        informeOitLosLeones.simbolo_id = informeOIT.simbolo_id;
                        informeOitLosLeones.simbolo_ih = informeOIT.simbolo_ih;
                        informeOitLosLeones.simbolo_kl = informeOIT.simbolo_kl;
                        informeOitLosLeones.simbolo_me = informeOIT.simbolo_me;
                        informeOitLosLeones.simbolo_pa = informeOIT.simbolo_pa;
                        informeOitLosLeones.simbolo_pb = informeOIT.simbolo_pb;
                        informeOitLosLeones.simbolo_pi = informeOIT.simbolo_pi;
                        informeOitLosLeones.simbolo_px = informeOIT.simbolo_px;
                        informeOitLosLeones.simbolo_ra = informeOIT.simbolo_ra;
                        informeOitLosLeones.simbolo_rp = informeOIT.simbolo_rp;
                        informeOitLosLeones.simbolo_tb = informeOIT.simbolo_tb;
                        informeOitLosLeones.simbolo_od = informeOIT.simbolo_od;
                        informeOitLosLeones.comentario_general = informeOIT.comentarioGeneral;
                        informeOitLosLeones.fecha_lectura = informeOIT.fechaLectura;
                        informeOitLosLeones.codexamen = informeOIT.codexamen;
                        informeOitLosLeones.estado = informeOIT.estado;
                        informeOitLosLeones.username_radiologo = "admin";

                        result = serviceMultirisWsLosLeones.InsertInformeOIT(credencialesLosLeones, informeOitLosLeones);
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
                    case 2:
                        MultiRisWeb.WsLosCarrera.ServiceMultiris serviceMultirisWSLosCarrera = new MultiRisWeb.WsLosCarrera.ServiceMultiris();
                        MultiRisWeb.WsLosCarrera.DocumentosParameters documentosLosCarrera = new MultiRisWeb.WsLosCarrera.DocumentosParameters();
                        MultiRisWeb.WsLosCarrera.CredencialesParameters credencialesLosCarrera = new MultiRisWeb.WsLosCarrera.CredencialesParameters();
                        credencialesLosCarrera.username = byId2.username;
                        credencialesLosCarrera.password = byId2.password;
                        documentosLosCarrera.codExamen = codExamen;
                        documentosLosCarrera.numeroAcceso = numeroAcceso;
                        comentarios = serviceMultirisWSLosCarrera.GetComentarios(credencialesLosCarrera, documentosLosCarrera);
                        break;
                    case 3:
                        MultiRisWeb.WsTarapaca.ServiceMultiris serviceMultirisWSTarapaca = new MultiRisWeb.WsTarapaca.ServiceMultiris();
                        MultiRisWeb.WsTarapaca.DocumentosParameters documentosTarapaca = new MultiRisWeb.WsTarapaca.DocumentosParameters();
                        MultiRisWeb.WsTarapaca.CredencialesParameters credencialesTarapaca = new MultiRisWeb.WsTarapaca.CredencialesParameters();
                        credencialesTarapaca.username = byId2.username;
                        credencialesTarapaca.password = byId2.password;
                        documentosTarapaca.codExamen = codExamen;
                        documentosTarapaca.numeroAcceso = numeroAcceso;
                        comentarios = serviceMultirisWSTarapaca.GetComentarios(credencialesTarapaca, documentosTarapaca);
                        break;
                    case 4:
                        MultiRisWeb.WsLosLeones.ServiceMultiris serviceMultirisWSLosLeones = new MultiRisWeb.WsLosLeones.ServiceMultiris();
                        MultiRisWeb.WsLosLeones.DocumentosParameters documentosLosLeones = new MultiRisWeb.WsLosLeones.DocumentosParameters();
                        MultiRisWeb.WsLosLeones.CredencialesParameters credencialesLosLeones = new MultiRisWeb.WsLosLeones.CredencialesParameters();
                        credencialesLosLeones.username = byId2.username;
                        credencialesLosLeones.password = byId2.password;
                        documentosLosLeones.codExamen = codExamen;
                        documentosLosLeones.numeroAcceso = numeroAcceso;
                        comentarios = serviceMultirisWSLosLeones.GetComentarios(credencialesLosLeones, documentosLosLeones);
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
                    case 2:
                        MultiRisWeb.WsLosCarrera.ServiceMultiris serviceMultirisWsLosCarrera = new MultiRisWeb.WsLosCarrera.ServiceMultiris();
                        MultiRisWeb.WsLosCarrera.DocumentosParameters documentosLosCarrera = new MultiRisWeb.WsLosCarrera.DocumentosParameters();
                        MultiRisWeb.WsLosCarrera.CredencialesParameters credencialesLosCarrera = new MultiRisWeb.WsLosCarrera.CredencialesParameters();
                        credencialesLosCarrera.username = credencialesInstitucion.username;
                        credencialesLosCarrera.password = credencialesInstitucion.password;
                        documentosLosCarrera.codExamen = codExamen;
                        documentosLosCarrera.numeroAcceso = numeroAcceso;
                        comentariosWs = serviceMultirisWsLosCarrera.GetComentarios(credencialesLosCarrera, documentosLosCarrera);
                        break;
                    case 3:
                        MultiRisWeb.WsTarapaca.ServiceMultiris serviceMultirisWsTarapaca = new MultiRisWeb.WsTarapaca.ServiceMultiris();
                        MultiRisWeb.WsTarapaca.DocumentosParameters documentosTarapaca = new MultiRisWeb.WsTarapaca.DocumentosParameters();
                        MultiRisWeb.WsTarapaca.CredencialesParameters credencialesTarapaca = new MultiRisWeb.WsTarapaca.CredencialesParameters();
                        credencialesTarapaca.username = credencialesInstitucion.username;
                        credencialesTarapaca.password = credencialesInstitucion.password;
                        documentosTarapaca.codExamen = codExamen;
                        documentosTarapaca.numeroAcceso = numeroAcceso;
                        comentariosWs = serviceMultirisWsTarapaca.GetComentarios(credencialesTarapaca, documentosTarapaca);
                        break;
                    case 4:
                        MultiRisWeb.WsLosLeones.ServiceMultiris serviceMultirisWsLosLeones = new MultiRisWeb.WsLosLeones.ServiceMultiris();
                        MultiRisWeb.WsLosLeones.DocumentosParameters documentosLosLeones = new MultiRisWeb.WsLosLeones.DocumentosParameters();
                        MultiRisWeb.WsLosLeones.CredencialesParameters credencialesLosLeones = new MultiRisWeb.WsLosLeones.CredencialesParameters();
                        credencialesLosLeones.username = credencialesInstitucion.username;
                        credencialesLosLeones.password = credencialesInstitucion.password;
                        documentosLosLeones.codExamen = codExamen;
                        documentosLosLeones.numeroAcceso = numeroAcceso;
                        comentariosWs = serviceMultirisWsLosLeones.GetComentarios(credencialesLosLeones, documentosLosLeones);
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
                    case 2:
                        MultiRisWeb.WsLosCarrera.ServiceMultiris serviceMultirisWsLosCarrera = new MultiRisWeb.WsLosCarrera.ServiceMultiris();
                        MultiRisWeb.WsLosCarrera.ComentariosParameters comentariosLosCarrera = new MultiRisWeb.WsLosCarrera.ComentariosParameters();
                        MultiRisWeb.WsLosCarrera.CredencialesParameters credencialesLosCarrera = new MultiRisWeb.WsLosCarrera.CredencialesParameters();
                        credencialesLosCarrera.username = institucionCredenciales.username;
                        credencialesLosCarrera.password = institucionCredenciales.password;
                        comentariosLosCarrera.codExamen = byCodExamen.codexamen;
                        comentariosLosCarrera.cantidad = 1;
                        comentariosLosCarrera.fecha = DateTime.Now;
                        comentariosLosCarrera.aetitle = byCodExamen.aetitle;
                        comentariosLosCarrera.texto = comentario;
                        comentariosLosCarrera.username = userName;

                        result = serviceMultirisWsLosCarrera.SaveComentario(credencialesLosCarrera, comentariosLosCarrera);
                        break;
                    case 3:
                        MultiRisWeb.WsTarapaca.ServiceMultiris serviceMultirisWsTarapaca = new MultiRisWeb.WsTarapaca.ServiceMultiris();
                        MultiRisWeb.WsTarapaca.ComentariosParameters comentariosTarapaca = new MultiRisWeb.WsTarapaca.ComentariosParameters();
                        MultiRisWeb.WsTarapaca.CredencialesParameters credencialesTarapaca = new MultiRisWeb.WsTarapaca.CredencialesParameters();
                        credencialesTarapaca.username = institucionCredenciales.username;
                        credencialesTarapaca.password = institucionCredenciales.password;
                        comentariosTarapaca.codExamen = byCodExamen.codexamen;
                        comentariosTarapaca.cantidad = 1;
                        comentariosTarapaca.fecha = DateTime.Now;
                        comentariosTarapaca.aetitle = byCodExamen.aetitle;
                        comentariosTarapaca.texto = comentario;
                        comentariosTarapaca.username = userName;

                        result = serviceMultirisWsTarapaca.SaveComentario(credencialesTarapaca, comentariosTarapaca);
                        break;
                    case 4:
                        MultiRisWeb.WsLosLeones.ServiceMultiris serviceMultirisWsLosLeones = new MultiRisWeb.WsLosLeones.ServiceMultiris();
                        MultiRisWeb.WsLosLeones.ComentariosParameters comentariosLosLeones = new MultiRisWeb.WsLosLeones.ComentariosParameters();
                        MultiRisWeb.WsLosLeones.CredencialesParameters credencialesLosLeones = new MultiRisWeb.WsLosLeones.CredencialesParameters();
                        credencialesLosLeones.username = institucionCredenciales.username;
                        credencialesLosLeones.password = institucionCredenciales.password;
                        comentariosLosLeones.codExamen = byCodExamen.codexamen;
                        comentariosLosLeones.cantidad = 1;
                        comentariosLosLeones.fecha = DateTime.Now;
                        comentariosLosLeones.aetitle = byCodExamen.aetitle;
                        comentariosLosLeones.texto = comentario;
                        comentariosLosLeones.username = userName;

                        result = serviceMultirisWsLosLeones.SaveComentario(credencialesLosLeones, comentariosLosLeones);
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
