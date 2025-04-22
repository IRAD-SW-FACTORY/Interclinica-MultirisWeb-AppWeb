using MultiRisWeb.ConsumirServicios;
using MultiRisWeb.Data.DataAccess;
using MultiRisWeb.Data.Domain;
using MultiRisWeb.Data.Util;
using MultiRisWeb.Encrypt.Util;
using MultiRisWeb.ResponseEntity;
using MultiRisWeb.Util;
using MultiRisWeb.Web.Configuracion;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using static iTextSharp.text.pdf.events.IndexEvents;

namespace MultiRisWeb.Web.Examen
{
    public partial class Addendum : System.Web.UI.Page
    {
        public string val
        {
            get
            {
                string paramString = ParamUtil.GetParamString((object)this.Request[nameof(val)], "");
                if (paramString != "")
                {
                    this.val_actual.Value = paramString.ToString();
                    ConfiguracionGeneralDomain byId1 = ConfiguracionGeneralDataAccess.GetById(1L);
                    ConfiguracionGeneralDomain byId2 = ConfiguracionGeneralDataAccess.GetById(2L);
                    string[] strArray = EncCode.Decode(paramString.Replace(" ", "+"), byId1.valor1, byId2.valor1).Split('&', '=');
                    for (int index = 0; index < strArray.Length; ++index)
                    {
                        if (strArray[index] == "id_informe")
                            this.Session["id_informe_addendum"] = (object)Convert.ToInt64(strArray[index + 1]);
                        if (strArray[index] == "id_institucion")
                            this.Session["id_institucion_addendum"] = (object)Convert.ToInt32(strArray[index + 1]);
                        if (strArray[index] == "id_ris_examen")
                            this.Session["id_ris_examen_addendum"] = (object)Convert.ToInt64(strArray[index + 1]);
                        int num = strArray[index] == "id_addendum" ? 1 : 0;
                        if (strArray[index] == "cod_examen")
                            this.Session["cod_examen_addendum"] = (object)strArray[index + 1];
                        if (strArray[index] == "clave")
                            this.Session["clave_addendum"] = (object)strArray[index + 1];
                    }
                }
                else
                    paramString = ParamUtil.GetParamString((object)this.val_actual.Value, "");
                return paramString;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");

            if (!IsPostBack)
            {
                lblMensaje.Text = string.Empty;
                try
                {
                    if (this.IsPostBack)
                        return;
                    if (this.Request.UrlReferrer == (Uri)null)
                        this.Response.Redirect("../../Default.aspx");
                    this.CargarDesplegables();
                    if (this.Session["id_usuario"] == null || this.IsPostBack)
                        return;
                    string val = this.val;
                    if (!(ConfiguracionGeneralDataAccess.GetById(3L).valor1 == this.Session["clave_addendum"].ToString()))
                        return;
                    this.cargarDatos();

                }
                catch (Exception ex)
                {

                }
            }
        }
        [WebMethod]
        public static ArrayList ObtenerDatos()
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");

            ArrayList arrayList = new ArrayList();
            RisExamenDomain risExamenDomain = new RisExamenDomain();
            if (HttpContext.Current.Session["cod_examen_addendum"] != null)
            {
                RisExamenDomain byCodExamen = RisExamenDataAccess.GetByCodExamen(HttpContext.Current.Session["cod_examen_addendum"].ToString());
                arrayList.Add((object)new
                {
                    codexamen = HttpContext.Current.Session["cod_examen_addendum"].ToString(),
                    id_institucion = byCodExamen.id_institucion
                });
            }
            return arrayList;
        }
        [WebMethod]
        public static string ObtenerInformesPrevios(string id_paciente, int id_institucion, string codexamen)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");

            InstitucionDomain byId = InstitucionDataAccess.GetById(id_institucion);
            DataTable dataTable = new DataTable();
            string urlInforme = InstitucionDataAccess.getURLInforme();
            string str1 = "";
            if (byId.id_institucion > 0)
            {
                InstitucionDatosDomain methodAndInstitucion = InstitucionDatosDataAccess.GetByIdMethodAndInstitucion(9, byId.id_institucion);
                if (byId.id_tipo_conexion == 1)
                    dataTable = Addendum.normalizaDataTableEstudiosRelacionados(new ConsumirApi().ApiObtenerDataTable(methodAndInstitucion.url, methodAndInstitucion.metodo, Addendum.jsonEstudiosRelacionados(id_paciente), id_institucion), id_institucion, id_paciente, codexamen);
                else if (byId.id_tipo_conexion == 2)
                {
                    ConsumirWS consumirWs = new ConsumirWS();
                    dataTable = Addendum.normalizaDataTableEstudiosRelacionados(ConsumirWS.GetEstudiosRelacionados(id_paciente, id_institucion), id_institucion, id_paciente, codexamen);
                }
            }
            if (dataTable.Rows.Count > 0)
            {
                DataView defaultView = dataTable.DefaultView;
                defaultView.Sort = "Fecha_examen DESC";
                DataTable table = defaultView.ToTable();
                string str2 = str1 + "<table class=\"table_informes_previos\">";
                int num = 0;
                foreach (DataRow row in (InternalDataCollectionBase)table.Rows)
                {
                    ++num;
                    string str3 = "btn_identificador" + num.ToString();
                    if (!(row["descripcion"].ToString() == "ESTUDIO SOLO CON IMAGENES"))
                    {
                        str2 += "<tr>";
                        str2 += "<td>";
                        string codeExamen = row["informe"].ToString().Split('=')[1].Split('&')[0];
                        int examenConteo = RisExamenDataAccess.GetExamenConteo(codeExamen);
                        string examenAetitle = RisExamenDataAccess.GetExamenAetitle(codeExamen);
                        string informeIdInforme = RisInformeDataAccess.GetInformeIdInforme(codeExamen);
                        if (examenConteo > 0)
                            str2 = str2 + "<button id=\"" + str3 + "\" class=\"btn_informes_previos\" onclick=\"cargarInforme('" + urlInforme.Replace("#IDINFORME#", informeIdInforme).Replace("#AETITLE#", examenAetitle) + "'); return false;\">" + row["descripcion"].ToString().ToUpper() + "</button>";
                        else
                            str2 = str2 + "<button id=\"" + str3 + "\" class=\"btn_informes_previos\" onclick=\"cargarInforme('" + row["informe"]?.ToString() + "', '" + str3 + "'); return false;\">" + row["descripcion"].ToString().ToUpper() + "</button>";
                        str2 += "</td>";
                        str2 += "</tr>";
                    }
                }
                str1 = str2 + "</table>";
            }
            return str1;
        }
        [WebMethod]
        public static string Validar(int esPatologiaCritica, string addendumText, string patologiaCritica)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");

            try
            {
                long id_ris_informe = long.Parse(HttpContext.Current.Session["id_informe_addendum"].ToString());
                int id_institucion = int.Parse(HttpContext.Current.Session["id_institucion_addendum"].ToString());
                string codExamen = HttpContext.Current.Session["cod_examen_addendum"].ToString();
                RisAddendumDomain addendum = new RisAddendumDomain();
                RisInformeDataAccess.GetByID(id_ris_informe);
                UsuarioDomain byId = UsuarioDataAccess.GetById((long)Convert.ToInt32(HttpContext.Current.Session["id_usuario"]));
                InstitucionDataAccess.GetById(id_institucion);
                RisExamenDomain byCodExamen = RisExamenDataAccess.GetByCodExamen(codExamen);
                SolicitudAddendumInstitucionDomain byIdExa = SolicitudAddendumInstitucionAccess.GetByIdExa(byCodExamen.id_ris_examen);
                string correoUsuario = byIdExa.UsuarioMail;


                addendum.id_informe = id_ris_informe;
                addendum.username = byId.username;
                addendum.cod_examen = codExamen;
                addendum.fecha_hora = DateTime.Now;
                addendum.addendum = addendumText;
                addendum.estado_visible = 1;
                addendum.estado_bloqueo = 0;
                addendum.flag_patologia_grave = esPatologiaCritica;//this.rbtnPatologiaGrave.SelectedValue == "" ? -1 : Convert.ToInt32(this.rbtnPatologiaGrave.SelectedValue);
                addendum.patologia_grave = patologiaCritica;
                long num = 0;
                addendum.id_addendum_remoto = num;
                RisAddendumDataAccess.Save(addendum);


                foreach (SolicitudAddendumDomain solicitudAddendum in (IEnumerable<SolicitudAddendumDomain>)SolicitudAddendumDataAccess.GetByCodExamenInstitucion(byCodExamen.codexamen, byCodExamen.id_institucion))
                {
                    solicitudAddendum.id_estado_addendum = 2;
                    solicitudAddendum.fecha_resolucion = DateTime.Now;
                    SolicitudAddendumDataAccess.Save(solicitudAddendum);

                }

                byCodExamen.entregado = false;
                RisExamenDataAccess.Save(byCodExamen);
                RisLogDataAccess.SaveReturn(new RisLogDomain()
                {
                    sistema = "MULTIRISWEB",
                    observacion = "Usuario " + byId.username + " genero un addendum asociado al informe " + id_ris_informe.ToString() + " estado Validado, Texto del addendum: " + addendum.addendum,
                    id_institucion = byCodExamen.id_institucion,
                    codexamen = byCodExamen.codexamen,
                    id_ris_examen = byCodExamen.id_ris_examen,
                    id_usuario = byId.id_usuario,
                    tipoAccion = 4L
                });
                if (SolicitudAddendumInstitucionAccess.UpdateFinalizacion(byCodExamen.id_ris_examen))
                {
                    EnviaCorreoFinalizacion(addendum.cod_examen, correoUsuario);
                }
                return "true";
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }
        }
        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true)]
        public static ResponseApp CargarPatologias()
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");

            List<RisPatologiaCriticaDomain> patologiaCriticaDomainList = RisPatologiaCriticaDataAccess.Listar(Convert.ToInt64(HttpContext.Current.Session["id_institucion_addendum"].ToString()));
            List<RisPatologiaCriticaDomain> source = patologiaCriticaDomainList == null ? new List<RisPatologiaCriticaDomain>() : patologiaCriticaDomainList;
            return new ResponseApp()
            {
                Data = (object)source,
                Ejecutado = source.Any<RisPatologiaCriticaDomain>(),
                Mensaje = string.Empty
            };
        }
        [WebMethod]
        public static ResponseApp GetExamenesPrevios(string codExamen, int idInstitucion)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");

            string empty = string.Empty;
            RisExamenDomain examen = RisExamenDataAccess.GetByCodExamen(codExamen);
            InstitucionDomain institucion = InstitucionDataAccess.GetById(idInstitucion);
            MeddreamsUtil meddreamsUtil = new MeddreamsUtil();
            List<ResponseEntity.ResponseEstudiosPrevios> estudiosPrevios = new List<ResponseEstudiosPrevios>();

            if (ConfigurationManager.AppSettings["ActivarWSAPISalida"].ToString().Equals("1") && institucion.id_institucion > 0 && examen.id_ris_examen > 0L)
            {
                if (institucion.id_grupo == 0)
                {
                    DataTable dtEstudios = ConsumirWS.GetEstudiosRelacionados(examen.idpaciente, institucion.id_institucion);
                    if (dtEstudios.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtEstudios.Rows.Count; i++)
                        {
                            estudiosPrevios.Add(new ResponseEstudiosPrevios()
                            {
                                IdPaciente = dtEstudios.Rows[i][0].ToString(),
                                Centro = institucion.nombre,
                                Fecha = DateTime.Parse(dtEstudios.Rows[i][4].ToString()),
                                Descripcion = dtEstudios.Rows[i][2].ToString(),
                                Modalidad = dtEstudios.Rows[i][5].ToString(),
                                Visores = meddreamsUtil.generarStringVisores(dtEstudios.Rows[i][3].ToString(), institucion.id_institucion, false, Convert.ToInt64(HttpContext.Current.Session["id_usuario"].ToString())),
                                CodExamen = dtEstudios.Rows[i][3].ToString(),
                                IdInstitucion = institucion.id_institucion,
                                Url = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.AbsolutePath, "") + "/multirisweb/Web/Examen/AddendumExamenPrevios.aspx?idPaciente="
                            });
                        }
                    }
                }
                else
                {
                    foreach (InstitucionDomain institucionDb in (IEnumerable<InstitucionDomain>)InstitucionDataAccess.GetAll())
                    {
                        if (institucionDb.id_grupo == institucionDb.id_grupo)
                        {
                            DataTable dtEstudios = ConsumirWS.GetEstudiosRelacionados(examen.idpaciente, institucionDb.id_institucion);
                            if (dtEstudios.Rows.Count > 0)
                            {
                                for (int i = 0; i < dtEstudios.Rows.Count; i++)
                                {
                                    estudiosPrevios.Add(new ResponseEstudiosPrevios()
                                    {
                                        IdPaciente = dtEstudios.Rows[i][0].ToString(),
                                        Centro = institucion.nombre,
                                        Fecha = DateTime.Parse(dtEstudios.Rows[i][4].ToString()),
                                        Descripcion = dtEstudios.Rows[i][2].ToString(),
                                        Modalidad = dtEstudios.Rows[i][5].ToString(),
                                        Visores = meddreamsUtil.generarStringVisores(dtEstudios.Rows[i][3].ToString(), institucion.id_institucion, false, Convert.ToInt64(HttpContext.Current.Session["id_usuario"].ToString())),
                                        CodExamen = dtEstudios.Rows[i][3].ToString(),
                                        IdInstitucion = institucion.id_institucion,
                                        Url = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.AbsolutePath, "") + "/multirisweb/Web/Examen/AddendumExamenPrevios.aspx?idPaciente="
                                    });
                                }
                            }
                        }
                    }
                }
            }
            return new ResponseApp()
            {
                Ejecutado = estudiosPrevios.Any(),
                Data = estudiosPrevios.OrderByDescending(o => o.Fecha).ToList()
            };
        }
        private static void EnviaCorreoFinalizacion(string codExamen, string mailUsuario)
        {
            RisExamenDomain byCodExamen = RisExamenDataAccess.GetByCodExamen(codExamen);
            string emailcc = "";
            string appSetting1 = ConfigurationManager.AppSettings["emailfrom"];
            string appSetting2 = ConfigurationManager.AppSettings["emailto"];
            string appSetting3 = ConfigurationManager.AppSettings["emailname"];
            string appSetting4 = ConfigurationManager.AppSettings["emailpass"];
            string appSetting5 = ConfigurationManager.AppSettings["urlris"];
            string appSetting6 = ConfigurationManager.AppSettings["institucion"];
            string asunto = "Finalización Addendum Examen : " + byCodExamen.id_ris_examen.ToString();

            string cuerpo = "Estimado(a), nos dirigimos a usted para informar que su solicitud de evaluación del examen ha sido resuelta. Puede revisar el addendum al final del informe. Examen <b>" + byCodExamen.id_ris_examen.ToString() + "</b> a paciente:<br /><br />" + byCodExamen.nombre + " " + byCodExamen.apellidopaterno + " " + byCodExamen.apellidomaterno + " (" + byCodExamen.idpaciente + ")<br />" + byCodExamen.descripcion + "<br />" + byCodExamen.fechaexamen.ToString() + "<br /><br /> Favor tomar conocimiento <b>";
            MailUtil.SendMail(appSetting3, appSetting1, appSetting4, appSetting2, emailcc, asunto, cuerpo);

            if (mailUsuario != null && !string.IsNullOrEmpty(mailUsuario.Trim()))
            {                
                cuerpo = "Estimado(a), nos dirigimos a usted para informar que su solicitud de evaluación del examen ha sido resuelta. Puede revisar el addendum al final del informe. Examen <b>" + byCodExamen.id_ris_examen.ToString() + "</b> a paciente:<br /><br />" + byCodExamen.nombre + " " + byCodExamen.apellidopaterno + " " + byCodExamen.apellidomaterno + " (" + byCodExamen.idpaciente + ")<br />" + byCodExamen.descripcion + "<br />" + byCodExamen.fechaexamen.ToString() + "<br /><br /> Puede validar su solicitud en el informe inicial <b>";
                MailUtil.SendMail(appSetting3, appSetting1, appSetting4, mailUsuario, emailcc, asunto, cuerpo);
            }
        }
        public static void EnviaCorreoRechazo(int idSol, string mailUsuario)
        {
            SolicitudAddendumInstitucionDomain institucionDomain = SolicitudAddendumInstitucionAccess.Detalle(idSol);
            string appSetting1 = ConfigurationManager.AppSettings["emailfrom"];
            string appSetting5 = ConfigurationManager.AppSettings["emailto"];
            string appSetting2 = ConfigurationManager.AppSettings["emailname"];
            string appSetting3 = ConfigurationManager.AppSettings["emailpass"];
            string appSetting4 = ConfigurationManager.AppSettings["urlris"];
            string nombre = InstitucionDataAccess.GetById(institucionDomain.UsuarioInstitucion).nombre;
            string str = institucionDomain.IdRisExamen.ToString();
            RisExamenDomain byId = RisExamenDataAccess.GetById(institucionDomain.IdRisExamen);
            string asunto = "Rechazo solicitud Addendum Examen : " + institucionDomain.IdRisExamen.ToString() + " Institución : " + nombre;

            string cuerpo = "Estimado(a), nos dirigimos a usted para informar sobre su solicitud. Se realiza evaluacion del examen, no efectuando modificaciones al cuerpo del informe. Se realizan comentarios pertinentes.<br /> Examen : <b>" + str + "</b> a paciente:<br /><br />" + byId.nombre + " " + byId.apellidopaterno + " " + byId.apellidomaterno + " (" + byId.idpaciente + ")<br />" + byId.descripcion + "<br />" + byId.fechaexamen.ToString() + "<br /> Comentario de la evaluación:<br />" + institucionDomain.Comentario + "<br /><br /> Favor tomar conocimiento. <b>";
            MailUtil.SendMail(appSetting2, appSetting1, appSetting3, appSetting5, "", asunto, cuerpo);

            if (mailUsuario != null && !string.IsNullOrEmpty(mailUsuario.Trim()))
            {
                cuerpo = "Estimado(a), nos dirigimos a usted para informar sobre su solicitud. Se realiza evaluacion del examen, no efectuando modificaciones al cuerpo del informe. Se realizan comentarios pertinentes.<br /> Examen : <b>" + str + "</b> a paciente:<br /><br />" + byId.nombre + " " + byId.apellidopaterno + " " + byId.apellidomaterno + " (" + byId.idpaciente + ")<br />" + byId.descripcion + "<br />" + byId.fechaexamen.ToString() + "<br /> Comentario de la evaluación:<br />" + institucionDomain.Comentario + "<br /><br /> Favor tomar conocimiento. <b>";
                MailUtil.SendMail(appSetting2, appSetting1, appSetting3, mailUsuario, "", asunto, cuerpo);
            }
        }
        private void CargarDesplegables()
        {
            this.ddlEstadoAddendum.DataSource = (object)EstadoAddendumDataAccess.ListAll();
            this.ddlEstadoAddendum.DataBind();
        }
        private void cargarDatos()
        {
            long id_ris_informe = long.Parse(this.Session["id_informe_addendum"].ToString());
            long id_institucion = long.Parse(this.Session["id_institucion_addendum"].ToString());
            string codExamen = this.Session["cod_examen_addendum"].ToString();
            RisInformeDomain byId1 = RisInformeDataAccess.GetByID(id_ris_informe);
            RisExamenDomain byCodExamen = RisExamenDataAccess.GetByCodExamen(codExamen);
            InstitucionDomain byId2 = InstitucionDataAccess.GetById(byCodExamen.id_institucion);
            this.ObtenerComentarioTM(byId2.id_institucion, byCodExamen.codexamen);
            this.lblCentro.Text = byId2.nombre;
            if (byCodExamen.id_ris_examen <= 0L)
                return;
            this.cargarVisor();
            this.lblIdPaciente.Text = byCodExamen.idpaciente.ToString().ToUpper();
            this.lblNombre.Text = (byCodExamen.nombre + " " + byCodExamen.apellidopaterno + " " + byCodExamen.apellidomaterno).ToString().ToUpper();
            this.lblNombre.Text = this.lblNombre.Text.Replace("^", " ");
            this.lblEdad.Text = byCodExamen.edad.ToString().ToUpper();
            this.lblAcc.Text = byCodExamen.numeroacceso.ToString().ToUpper();
            this.lblSexo.Text = byCodExamen.sexo.ToString().ToUpper();
            IList<RisInformeDomain> codExamenValidado = RisInformeDataAccess.GetByCodExamenValidado(byCodExamen.codexamen, 3, byCodExamen.numeroacceso, byId2.id_institucion);
            string str1 = string.Empty;
            foreach (RisInformeDomain risInformeDomain in (IEnumerable<RisInformeDomain>)codExamenValidado)
                str1 = str1 + "<a href='VerInforme.aspx?idinforme=" + risInformeDomain.id_ris_informe.ToString() + "&AETITLE=" + byId2.aetitle + "' target='_blank'><img class='imgvisor' src='../icon/pdf.png' style='max-width:25px !important'/></a>";
            this.lblInformes.Text = str1;
            IList<SolicitudAddendumDomain> examenInstitucion = SolicitudAddendumDataAccess.GetByCodExamenInstitucion(byCodExamen.codexamen, byCodExamen.id_institucion);
            if (examenInstitucion.Count > 0)
            {
                string str2 = string.Empty;
                foreach (SolicitudAddendumDomain solicitudAddendumDomain in (IEnumerable<SolicitudAddendumDomain>)examenInstitucion)
                {
                    if (solicitudAddendumDomain.id_estado_addendum == 1)
                    {
                        str2 = str2 + "<b>Fecha solicitud:</b> " + solicitudAddendumDomain.fecha_solicitud.ToString("dd-MM-yyyy HH:mm");
                        str2 += "<br />";
                        str2 = str2 + "<b>Solicitante:</b> " + solicitudAddendumDomain.usuario;
                        str2 += "<br />";
                        str2 = str2 + "<b>Motivo:</b> " + solicitudAddendumDomain.motivo;
                        str2 += "<br />";
                        str2 += "<br />";
                    }
                }
                if (str2 != "")
                {
                    this.trEstadoAddendum.Visible = true;
                    this.lblSolicitudAddendum.Text = str2;
                }
                //this.rbtnPatologiaGrave.SelectedValue = byId1.flag_patologia_grave.ToString();
                //if (this.rbtnPatologiaGrave.SelectedValue == "1")
                //    this.ddlSeleccionePatologia.Visible = true;
            }
            cargarDocumentosRelacionados(int.Parse(id_institucion.ToString()), byCodExamen.idpaciente, byCodExamen.codexamen);
            //this.cargarPatologias(id_institucion);
        }
        public void ObtenerComentarioTM(int id_institucion, string codexamen) => this.lblComentarioTM.Text = ConsumirWS.ObtenerComentarioTM(id_institucion, codexamen);
        private void cargarVisor()
        {
            long.Parse(this.Session["id_informe_addendum"].ToString());
            int id_institucion = int.Parse(this.Session["id_institucion_addendum"].ToString());
            string cod_examen = this.Session["cod_examen_addendum"].ToString();
            MeddreamsUtil meddreamsUtil = new MeddreamsUtil();
            InstitucionDomain byId = InstitucionDataAccess.GetById(id_institucion);
            RisExamenDomain institucionCodExamen = RisExamenDataAccess.GetByInstitucionCodExamen((long)id_institucion, byId.aetitle, cod_examen);
            if (institucionCodExamen.id_ris_examen <= 0L)
                return;
            this.lblVisores.Text = meddreamsUtil.generarStringVisores(institucionCodExamen.codexamen, byId.id_institucion, true, Convert.ToInt64(this.Session["id_usuario"].ToString()));
        }
        private static string jsonEstudiosRelacionados(string id_paciente) => "{\"id_paciente\":\"" + id_paciente + "\"}";
        private static DataTable normalizaDataTableEstudiosRelacionados(DataTable dtOrigen, int id_institucion, string id_paciente, string codexamen)
        {
            InstitucionDomain byId = InstitucionDataAccess.GetById(id_institucion);
            DataTable dataTable = new DataTable();
            int num = 0;
            dataTable.Columns.Add("fecha_examen");
            dataTable.Columns.Add("descripcion");
            dataTable.Columns.Add("modalidad");
            dataTable.Columns.Add("informe");
            dataTable.Columns.Add("descargar_examen");
            dataTable.Columns.Add("visualizadores");
            dataTable.Columns.Add(nameof(id_institucion));
            dataTable.Columns.Add(nameof(id_paciente));
            dataTable.Columns.Add("identificador");
            MeddreamsUtil meddreamsUtil = new MeddreamsUtil();
            foreach (DataRow row1 in (InternalDataCollectionBase)dtOrigen.Rows)
            {
                DataRow row2 = dataTable.NewRow();
                ++num;
                string str = "btn_identificador" + num.ToString();
                row2["fecha_examen"] = row1["fecha_examen"];
                row2["descripcion"] = (object)row1["descripcion"].ToString().ToUpper();
                row2["modalidad"] = row1["modalidad"];
                row2["informe"] = (object)byId.url_informe.Replace("#AETITLE#", byId.aetitle).Replace("#CODEXAMEN#", row1[nameof(codexamen)].ToString()).Replace("#IDINFORME#", row1["idinforme"].ToString());
                row2["descargar_examen"] = (object)byId.url_descarga.Replace("#AETITLE#", byId.aetitle).Replace("#CODEXAMEN#", row1[nameof(codexamen)].ToString());
                row2[nameof(id_institucion)] = (object)id_institucion;
                row2[nameof(id_paciente)] = (object)id_paciente;
                row2["identificador"] = (object)str;
                row2["visualizadores"] = (object)meddreamsUtil.generarStringVisores(row1[nameof(codexamen)].ToString(), byId.id_institucion, false, Convert.ToInt64(HttpContext.Current.Session["id_usuario"].ToString()));
                dataTable.Rows.Add(row2);
            }
            return dataTable;
        }
        private void cargarDocumentosRelacionados(int id_institucion, string id_paciente, string cod_examen)
        {
            ConsumirWS consumirWs = new ConsumirWS();
            ConsumirApi consumirApi = new ConsumirApi();
            DataTable dtDatos = new DataTable();
            RisExamenDomain byCodExamen = RisExamenDataAccess.GetByCodExamen(this.Session["cod_examen_addendum"].ToString());
            InstitucionDomain byId = InstitucionDataAccess.GetById(id_institucion);
            if (byId.id_institucion > 0)
            {
                InstitucionDatosDomain methodAndInstitucion = InstitucionDatosDataAccess.GetByIdMethodAndInstitucion(10, byId.id_institucion);
                if (byId.id_tipo_conexion == 1)
                    dtDatos = consumirApi.ApiObtenerDataTable(methodAndInstitucion.url, methodAndInstitucion.metodo, Addendum.jsonEstudiosRelacionados(id_paciente), id_institucion);
                else if (byId.id_tipo_conexion == 2)
                    dtDatos = ConsumirWS.GetDocumentosExamen(byId.id_institucion, cod_examen, byCodExamen.numeroacceso);
            }
            if (dtDatos.Rows.Count <= 0)
                return;
            this.gvDocumentosRelacionados.DataSource = (object)normalizaDocumentosDelExamen(dtDatos, byId.id_institucion);
            this.gvDocumentosRelacionados.DataBind();
        }
        private DataTable normalizaDocumentosDelExamen(DataTable dtDatos, int id_institucion)
        {
            InstitucionDomain byId = InstitucionDataAccess.GetById(id_institucion);
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("id");
            dataTable.Columns.Add("descripcion");
            dataTable.Columns.Add("filename");
            dataTable.Columns.Add("webfolder");
            dataTable.Columns.Add("fecha");
            dataTable.Columns.Add("size");
            dataTable.Columns.Add("archivo");
            foreach (DataRow row1 in (InternalDataCollectionBase)dtDatos.Rows)
            {
                DataRow row2 = dataTable.NewRow();
                row2["id"] = (object)row1["id"].ToString();
                row2["descripcion"] = (object)row1["descripcion"].ToString();
                row2["filename"] = (object)row1["filename"].ToString();
                row2["webfolder"] = (object)row1["webfolder"].ToString();
                row2["fecha"] = (object)row1["fecha"].ToString();
                row2["size"] = (object)row1["size"].ToString();
                if (row1["filename"].ToString().Contains(".pdf"))
                    row2["archivo"] = (object)("<a href='#' onclick='cargarDocumentoPDF(&#34" + byId.url_pagina + row1["webfolder"]?.ToString() + row1["filename"]?.ToString() + "&#34); return false;' target='_blank' title='" + row1["descripcion"]?.ToString() + "'><img src='../icon/visor.sl.png' /></a>");
                else if (row1["filename"].ToString().Contains(".jpg") || row1["filename"].ToString().Contains(".png") || row1["filename"].ToString().Contains(".PNG"))
                    row2["archivo"] = (object)("<a href='#' onclick='cargarDocumento(&#34" + byId.url_pagina + row1["webfolder"]?.ToString() + row1["filename"]?.ToString() + "&#34); return false;' target='_blank' title='" + row1["descripcion"]?.ToString() + "'><img src='../icon/visor.sl.png' /></a>");
                dataTable.Rows.Add(row2);
            }
            return dataTable;
        }
        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");

            this.Response.Redirect("ListaExamen.aspx", false);
        }
        protected void btnRechazo_Click(object sender, EventArgs e)
        {
            if (Session["id_usuario"] == null)
                Response.Redirect("../../Default.aspx");

            if (string.IsNullOrEmpty(txtComentarioRechazo.Text))
            {
                lblMensaje.Text = "- Debe ingresar el motivo del rechazo del presente Addendum";
                return;
            }

            long.Parse(Session["id_informe_addendum"].ToString());
            long.Parse(HttpContext.Current.Session["id_institucion_addendum"].ToString());
            RisExamenDomain byCodExamen = RisExamenDataAccess.GetByCodExamen(Session["cod_examen_addendum"].ToString());
            SolicitudAddendumInstitucionDomain byIdExa = SolicitudAddendumInstitucionAccess.GetByIdExa(byCodExamen.id_ris_examen);
            UsuarioDomain usuario = UsuarioDataAccess.GetById((long)Convert.ToInt32(Session["id_usuario"]));
            InstitucionDataAccess.GetById(byCodExamen.id_institucion);
            int id = byIdExa.Id;
            SolicitudAddendumInstitucionAccess.Update(id, 4, txtComentarioRechazo.Text);
            string correoUsuario = byIdExa.UsuarioMail;

            if (!string.IsNullOrEmpty(byIdExa.UsuarioMail))
                Addendum.EnviaCorreoRechazo(id,correoUsuario);

            this.Response.Redirect("ListaExamen.aspx", false);
        }

        [WebMethod]
        public static ResponseApp LogMeddreamsInsert(int idExamen)
        {
            RisExamenDomain examen = RisExamenDataAccess.GetById(idExamen);
            LogMeddreamsDomain log = new LogMeddreamsDomain()
            {
                CodExamen = examen.codexamen,
                EsInformeActual = 0,
                FechaExamen = examen.fechaexamen,
                FechaAsignacion = examen.fechaasignacion,
                Fecha = DateTime.Now,
                IdPaciente = examen.idpaciente,
                IdLogMeddreams = 0,
                TipoAtencion = examen.idtipoorden,
                NombrePaciente = examen.nombre,
                Usuario = UsuarioDataAccess.GetById(long.Parse(HttpContext.Current.Session["id_usuario"].ToString())).username
            };

            bool result = LogMeddreamsDataAccess.Insertar(log);

            return new ResponseApp()
            {
                Ejecutado = result,
                Data = null,
                Mensaje = string.Empty
            };
        }
    }
}