using MultiRisWeb.ConsumirServicios;
using MultiRisWeb.Data.DataAccess;
using MultiRisWeb.Data.Domain;
using MultiRisWeb.Data.Util;
using MultiRisWeb.Encrypt.Util;
using MultiRisWeb.ResponseEntity;
using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultiRisWeb.Web.Examen
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private static string jsonEstudiosRelacionados(string id_paciente) => "{" + "\"id_paciente\":\"" + id_paciente + "\"" + "}";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["val"] != null)
            {
                if (HttpContext.Current.Session["id_usuario"] == null) HttpContext.Current.Response.Redirect("../../Default.aspx");

                ConfiguracionGeneralDomain tipoEncrip = ConfiguracionGeneralDataAccess.GetById(1L);
                ConfiguracionGeneralDomain passEncrip = ConfiguracionGeneralDataAccess.GetById(2L);

                string _query = Request.QueryString["val"].ToString();

                string[] _array = EncCode.Decode(_query.Replace(" ", "+"), tipoEncrip.valor1, passEncrip.valor1).Split('&', '=');

                RisExamenDomain examen = null;
                var _codExamen = string.Empty;
                var _informe = "0";

                for (int i=0; i < _array.Length; i++) {
                    if (_array[i].ToUpper().Equals("CODEXAMEN")) _codExamen = _array[i + 1];
                    if (_array[i].ToUpper().Equals("ID_INFORME")) { _informe = _array[i + 1]; }
                    if (_array[i].ToUpper().Equals("IDPRESTACION")) contenido.Value = _array[i + 1];
                }

                examen = RisExamenDataAccess.GetByCodExamen(_codExamen);

                if(!_informe.Equals("0")) contenido.Value = RisInformePrestacionDataAccess.GetByCodExamen(examen.codexamen)[0].id_prestacion.ToString();

                risExamen.Value = examen.id_ris_examen.ToString();
                codExamen.Value = examen.codexamen;
                institucion.Value = examen.id_institucion.ToString();
                prestacion.Value = GeneraPrestaciones(contenido.Value);
                informe.Value = _informe;

                UsuarioDomain usuario = UsuarioDataAccess.GetById(Convert.ToInt32(this.Session["id_usuario"].ToString()));

                tMedico.Value = usuario.nombre + " " + usuario.apellido_paterno + " " + usuario.apellido_materno + " / " + usuario.rut;
                
                usuarioNombre.Value = string.Format("{0}", usuario.nombre_completo.Equals("") ? usuario.nombre + " " + usuario.apellido_paterno : usuario.nombre_completo);
                perfilNombre.Value = usuario.nombre_perfil;

                try
                {
                    if (examen.aetitle.Equals("CODELCO"))
                    {
                        var _user = ConfigurationManager.AppSettings["UserWsCodelco"].ToString();
                        var _pass = ConfigurationManager.AppSettings["PassWsCodelco"].ToString();

                       

                        var name = string.Empty;

                        tTencologo.Value = name;
                    }
                    else tTencologo.Value = examen.tecnologo;
                }
                catch (Exception ex)
                {
                    string message = ex.Message + "---" + examen.codexamen;
                    Log.Error(ex, message);
                    
                }
            }
        }
        private string GeneraPrestaciones(string prestaciones)
        {
            string _string = string.Empty;

            foreach (string row in prestaciones.Split(','))
            {
                if (!_string.Equals(string.Empty)) _string += ",";

                _string += RisPrestacionDataAccess.GetById(Convert.ToInt64(row)).nombre;
            }

            return _string;
        }
        public static string NormalizarEstudios(DataTable dtEstudios, InstitucionDomain institucion, RisExamenDomain examen)
        {
            string str = string.Empty;
            var usuario = HttpContext.Current.Session["id_usuario"].ToString();

            MeddreamsUtil meddreamsUtil = new MeddreamsUtil();

            foreach (DataRow row in (InternalDataCollectionBase)dtEstudios.Rows) {
                if (row["descripcion"].ToString() == "Estudio Solo Con Imagenes") {
                    str += "<tr><td>" + institucion.nombre +"</td>";
                    str += "<td>" + row["fecha_examen"].ToString() + "</td>";
                    str += "<td>" + row["descripcion"].ToString() +"</td>";
                    str += "<td>" + row["modalidad"].ToString() + "</td>";
                    str += "<td>";
                    str = str ?? "";
                    str += "</td>";
                    str += "<td>" + meddreamsUtil.generarStringVisores(row["codexamen"].ToString(), institucion.id_institucion, false, Convert.ToInt64(usuario)) +"</td>";
                    str += "</tr>";
                }
                else
                {
                    str += "<tr>";
                    str += "<td>"+ institucion.nombre + "</td>";
                    str += "<td>" + row["fecha_examen"].ToString() + "</td>";
                    str += "<td>" + row["descripcion"].ToString() + "</td>";
                    str += "<td>" + row["modalidad"].ToString() + "</td>";
                    str += "<td>";
                    str = str + "<a href='#' data-toggle='modal' data-target='#modalVerInforme' onclick='ObtenerTodosInformesPrevios(&#34;" + examen.idpaciente + "&#34;, " + institucion.id_institucion.ToString() + ", &#34;" + institucion.url_informe.Replace("#AETITLE#", institucion.aetitle).Replace("#CODEXAMEN#", row["codexamen"].ToString()).Replace("#IDINFORME#", row["idinforme"].ToString()) + "&#34;); return false;' target='_blank' title='Ver Informe'><img style='width: 13px;' src='../icon/pdf.png' /></a>";
                    str += "</td>";
                    str += "<td>" + meddreamsUtil.generarStringVisores(row["codexamen"].ToString(), institucion.id_institucion, false, Convert.ToInt64(usuario)) +"</td>";
                    str += "</tr>";
                }
            }
            return str.Equals(string.Empty) ? "<tr><td>Sin información disponible</td></tr>" : str;
        }

        private static List<Documentos> NormalizaDocumentos(DataTable table, int id_institucion)
        {
            var list = new List<Documentos>(); 
            try
            {
                foreach (DataRow row in table.Rows) {
                    var ins = new Documentos() { 
                        id = row["id"].ToString(),
                        descripcion = row["descripcion"].ToString(),
                        filename = row["filename"].ToString(),
                        webfolder = row["webfolder"].ToString(),
                        fecha = row["fecha"].ToString(),
                        size = row["size"].ToString(),
                        archivo = row["filename"].ToString().Contains(".pdf") ? "pdf" : "other"

                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }
        
        #region Wenethod
        [WebMethod]
        public static JsonResult DatosPaciente(string risExamen)
        {
            if (HttpContext.Current.Session["id_usuario"] == null) HttpContext.Current.Response.Redirect("../../Default.aspx");

            try
            {
                var data = RisExamenDataAccess.GetById(Convert.ToInt64(risExamen));

                var institucion = InstitucionDataAccess.GetById(data.id_institucion);

                data.institucion = institucion.nombre;

                return new JsonResult()
                {
                    Data = (object)new ResponseApp() { Ejecutado = true, Mensaje = "", Data = data }
                };
            }
            catch (Exception ex)
            {
                return new JsonResult()
                {
                    Data = (object)new ResponseApp() { Ejecutado = false, Mensaje = ex.Message.ToString(), Data = null }
                };
            }
        }

        [WebMethod]
        public static JsonResult ObtieneVisores(string codExamen)
        {
            if (HttpContext.Current.Session["id_usuario"] == null) HttpContext.Current.Response.Redirect("../../Default.aspx");

            try
            {
                var data = RisExamenDataAccess.GetByCodExamen(codExamen);
                var institucion = InstitucionDataAccess.GetById(Convert.ToInt32(data.id_institucion));
                var usuario = HttpContext.Current.Session["id_usuario"].ToString();

                if (data.id_ris_examen <= 0L) throw new Exception("Sin risExamen");

                MeddreamsUtil meddreamsUtil = new MeddreamsUtil();

                var visor = meddreamsUtil.generarStringVisores(data.codexamen, data.id_institucion, true, Convert.ToInt64(usuario));

                return new JsonResult()
                {
                    Data = (object)new ResponseApp() { Ejecutado = true, Mensaje = "", Data = visor }
                };
            }
            catch (Exception ex)
            {
                return new JsonResult()
                {
                    Data = (object)new ResponseApp() { Ejecutado = false, Mensaje = ex.Message.ToString(), Data = null }
                };
            }
        }

        [WebMethod]
        public static JsonResult ObtieneRelacionados(string codExamen)
        {
            string empty = string.Empty;

            if (HttpContext.Current.Session["id_usuario"] == null) HttpContext.Current.Response.Redirect("../../Default.aspx");

            try
            {
                var examen = RisExamenDataAccess.GetByCodExamen(codExamen);
                var institucion = InstitucionDataAccess.GetById(examen.id_institucion);

                string tabla = string.Empty + "<table cellspacing='0' rules='all' border='1' id='tableEstudiosAnteriores' style='width: 100%; border-collapse: collapse;'>" + "<tr style='background-color: #352d5c;'>" + "<th style='width: 10%'><b>Centro</b></th>" + "<th style='width: 20%'><b>Fecha Ex.</b></th>" + "<th style='width: 30%'><b>Desc.</b></th>" + "<th style='width: 10%'><b>Mod.</b></th>" + "<th style='width: 10%'><b>Doc.</b></th>" + "<th style='width: 20%'><b>Visores</b></th>" + "</tr>";

                if (ConfigurationManager.AppSettings["ActivarWSAPISalida"].ToString().Equals("1") && examen.id_institucion > 0 && examen.id_ris_examen > 0L)
                {
                    if (institucion.id_grupo.Equals(0))
                    {
                        DataTable dtEstudios = ConsumirWS.GetEstudiosRelacionados(examen.idpaciente, examen.id_institucion);
                        if (dtEstudios.Rows.Count > 0)
                        {
                            DataView defaultView = dtEstudios.DefaultView;
                            defaultView.Sort = "Fecha_examen DESC";
                            dtEstudios = defaultView.ToTable();
                        }
                        tabla += NormalizarEstudios(dtEstudios, institucion, examen);
                    }
                    else
                    {
                        foreach (InstitucionDomain row in InstitucionDataAccess.GetAll())
                        {
                            if (institucion.id_grupo == institucion.id_grupo)
                            {
                                DataTable dtEstudios = ConsumirWS.GetEstudiosRelacionados(examen.idpaciente, institucion.id_institucion);

                                if (dtEstudios.Rows.Count > 0)
                                {
                                    DataView defaultView = dtEstudios.DefaultView;
                                    defaultView.Sort = "Fecha_examen DESC";
                                    dtEstudios = defaultView.ToTable();
                                }

                                tabla += NormalizarEstudios(dtEstudios, institucion, examen);
                            }
                        }
                    }
                }

                string response = tabla + "</table>";

                return new JsonResult()
                {
                    Data = (object)new ResponseApp() { Ejecutado = true, Mensaje = "", Data = response }
                };
            }
            catch (Exception ex)
            {
                return new JsonResult()
                {
                    Data = (object)new ResponseApp() { Ejecutado = false, Mensaje = ex.Message.ToString(), Data = null }
                };
            }
        }

        [WebMethod]
        public static JsonResult DocumentosExamen(string risExamen)
        {
            if (HttpContext.Current.Session["id_usuario"] == null) HttpContext.Current.Response.Redirect("../../Default.aspx");

            DataTable _dtable = new DataTable();

            try
            {
                RisExamenDomain examen = RisExamenDataAccess.GetById(Convert.ToInt64(risExamen));

                if (examen.id_institucion > 0)
                {
                    InstitucionDatosDomain _method = InstitucionDatosDataAccess.GetByIdMethodAndInstitucion(10, examen.id_institucion);

                    if (ConfigurationManager.AppSettings["ActivarWSAPISalida"].ToString().Equals("1"))
                    {
                        var _ws = new ConsumirWS();
                        var _api = new ConsumirApi();
                        var _send = InstitucionDataAccess.GetById(examen.id_institucion);

                        if (_send.id_tipo_conexion.Equals(1))
                            _dtable = _api.ApiObtenerDataTable(_method.url, _method.metodo, jsonEstudiosRelacionados(examen.idpaciente), examen.id_institucion);
                        else if (_send.id_tipo_conexion.Equals(2))
                            _dtable = ConsumirWS.GetDocumentosExamen(examen.id_institucion, examen.codexamen, examen.numeroacceso);
                    }
                }

                return new JsonResult()
                {
                    Data = (object)new ResponseApp() { Ejecutado = true, Mensaje = "", Data = NormalizaDocumentos(_dtable, examen.id_institucion) }
                };
            }
            catch (Exception e)
            {
                return new JsonResult()
                {
                    Data = new ResponseApp() { Ejecutado = false, Mensaje = e.Message.ToString(), Data = null }
                };
            }
        }

        [WebMethod]
        public static JsonResult SaveInforme(RequestInforme request) {
            try
            {
                if (HttpContext.Current.Session["id_usuario"] == null) HttpContext.Current.Response.Redirect("../../Default.aspx");

                var data = RisExamenDataAccess.GetById(Convert.ToInt64(request.RISEXAMEN));

                request.IDUSUARIO = HttpContext.Current.Session["id_usuario"].ToString();
                request.CODEXAMEN = data.codexamen;

                var send = RequestInforme.ConvertTo(request);

                var response = RisInformeDataAccess.SaveOIT(send);

                return new JsonResult() { Data = (object)new ResponseApp() { Ejecutado = true, Mensaje = "", Data = response } };
            }
            catch (Exception e)
            {
                return new JsonResult() { Data = new ResponseApp() { Ejecutado = false, Mensaje = e.Message.ToString(), Data = null } };
            }
        }

        [WebMethod]
        public static JsonResult ObtieneInforme(string codExamen, string informe) 
        {
            try
            {
                var data = RequestInforme.ConvertTo(RisInformeDataAccess.ObtieneInformeOIT(codExamen, Convert.ToInt64(informe)));

                return new JsonResult()
                {
                    Data = (object)new ResponseApp() { Ejecutado = true, Mensaje = "", Data = data }
                };
            }
            catch (Exception e)
            {
                return new JsonResult()
                {
                    Data = (object)new ResponseApp() { Ejecutado = true, Mensaje = e.Message.ToString(), Data = null }
                };
            }
        }

        [WebMethod]
        public static JsonResult ObtieneComentarioTM(string risExamen)
        {
            try
            {
                var data = RisExamenDataAccess.GetById(Convert.ToInt64(risExamen));

                var _comm = ConsumirWS.ObtenerComentarioTM(data.id_institucion, data.codexamen);

                return new JsonResult()
                {
                    Data = (object)new ResponseApp() { Ejecutado = true, Mensaje = "", Data = _comm }
                };
            }
            catch (Exception e)
            {
                return new JsonResult()
                {
                    Data = (object)new ResponseApp() { Ejecutado = true, Mensaje = e.Message.ToString(), Data = null }
                };
            }
        }

        [WebMethod]
        public static JsonResult ObtieneAntecedentes(string risExamen) {
            try
            {
                var data = RisExamenDataAccess.GetById(Convert.ToInt64(risExamen));

                var _comm = ConsumirWS.ObtenerAntecedenteClinico(data.id_institucion, data.codexamen);

                return new JsonResult()
                {
                    Data = (object)new ResponseApp() { Ejecutado = true, Mensaje = "", Data = _comm }
                };
            }
            catch (Exception e)
            {
                return new JsonResult()
                {
                    Data = (object)new ResponseApp() { Ejecutado = true, Mensaje = e.Message.ToString(), Data = null }
                };
            }
        }

        [WebMethod]
        public static JsonResult GuardaComentario(string risExamen, string comentario)
        {
            long res = 0;

            try
            {
                var data = RisExamenDataAccess.GetById(Convert.ToInt64(risExamen));
                var inst = InstitucionDataAccess.GetById(data.id_institucion);
                var meth = InstitucionDatosDataAccess.GetByIdMethodAndInstitucion(11, data.id_institucion);
                var user = UsuarioDataAccess.GetById(Convert.ToInt32(HttpContext.Current.Session["id_usuario"].ToString()));

                if (ConfigurationManager.AppSettings["ActivarWSAPISalida"].ToString().Equals("1"))
                {
                    var consumirApi = new ConsumirApi();

                    if (inst.id_tipo_conexion.Equals(1)) {
                        string json = "{\"id\":0,\"idInforme\":0,\"codExamen\":\"" + data.codexamen + "\",\"cantidad\":0,\"fecha\":\"" + DateTime.Now.ToString() + "\",\"aetitle\":\"" + data.aetitle + "\"\"texto\":\"" + comentario + "\"\"username\":\"" + user.username + "\"}";
                        res = consumirApi.ApiObtenerIdRemoto(meth.url, meth.metodo, json, data.id_institucion);
                    } else if (inst.id_tipo_conexion == 2) {
                        res = ConsumirWS.saveComentario(data.id_institucion, data.codexamen, comentario, user.username);
                    }
                }

                return new JsonResult()
                {
                    Data = (object)new ResponseApp() { Ejecutado = true, Mensaje = "OK", Data = res }
                };
            }
            catch (Exception e)
            {
                return new JsonResult()
                {
                    Data = (object)new ResponseApp() { Ejecutado = false, Mensaje = e.Message.ToString(), Data = null }
                };
            }
        }

        [WebMethod]
        public static JsonResult ObtenerComentario(string risExamen)
        {
            var dTable = new DataTable();
            var strTable = string.Empty;

            if (HttpContext.Current.Session["id_usuario"] == null) HttpContext.Current.Response.Redirect("../../Default.aspx");

            try
            {
                var data = RisExamenDataAccess.GetById(Convert.ToInt64(risExamen));
                var inst = InstitucionDataAccess.GetById(data.id_institucion);
                var meth = InstitucionDatosDataAccess.GetByIdMethodAndInstitucion(7, data.id_institucion);

                if (ConfigurationManager.AppSettings["ActivarWSAPISalida"].ToString().Equals("1"))
                {
                    ConsumirApi _Api = new ConsumirApi();

                    if (inst.id_tipo_conexion.Equals(1))
                    {
                        string json = "{\"codExamen\":\"" + data.codexamen + "\",\"numeroAcceso\":\"" + data.numeroacceso + "\"}";
                        dTable = _Api.ApiObtenerDataTable(meth.url, meth.metodo, json, data.id_institucion);
                    }
                    else if (inst.id_tipo_conexion == 2)
                    {
                        dTable = ConsumirWS.GetComentarios(data.id_institucion, data.codexamen, data.numeroacceso);
                    }
                }

                if (dTable.Rows.Count > 0)
                {
                    strTable = "<table><tr><th style='width: 70%;'><label>Comentario</label></th>"+
                               "<th style='width: 15%; text-align: center'><label>Fecha</label></th>"+
                               "<th style='width: 15%; text-align: center'><label>Usuario</label></th></tr>";
                    
                    foreach (DataRow row in dTable.Rows)
                    {
                        strTable += "<tr>";
                        strTable += "<td><label>" + row["texto"]?.ToString().ToUpper() + "</label></td>";
                        strTable += "<td style='text-align: center;'><label>" + Convert.ToDateTime(row["fecha"]).ToString("dd-MM-yyyy HH:mm") + "</label></td>";
                        strTable += "<td style='text-align: center;'><label>" + row["username"]?.ToString().ToUpper() + "</label></td>";
                        strTable += "</tr>";
                    }

                    strTable += "</table>";
                }

                return new JsonResult()
                {
                    Data = (object)new ResponseApp() { Ejecutado = true, Mensaje = "OK", Data = strTable }
                };
            }
            catch (Exception e)
            {
                return new JsonResult()
                {
                    Data = (object)new ResponseApp() { Ejecutado = false, Mensaje = e.Message.ToString(), Data = null }
                };
            }
        }
        #endregion Wenethod
    }
}