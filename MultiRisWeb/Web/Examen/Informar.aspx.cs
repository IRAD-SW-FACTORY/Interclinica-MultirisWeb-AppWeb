using MultiRisWeb.ConsumirServicios;
using MultiRisWeb.Data.DataAccess;
using MultiRisWeb.Data.Domain;
using MultiRisWeb.Data.Util;
using MultiRisWeb.Encrypt.Util;
using MultiRisWeb.ResponseEntity;
using MultiRisWeb.Util;
using MultiRisWeb.Web.Control;
using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MultiRisWeb.Web.Examen
{
    public class Informar : Page
    {
        protected HtmlInputHidden val_actual;
        protected HtmlInputHidden val_modalidad;
        protected HtmlInputHidden val_estado;
        protected HtmlInputHidden usuarioNombre;
        protected HtmlInputHidden perfilNombre;
        protected HtmlInputHidden risExamen;
        protected HtmlInputHidden comunica;
        protected HiddenField hddInstitucion;
        protected HiddenField hddCod;
        protected HiddenField hddIdInforme;
        protected HiddenField hddIdPrestacion;
        protected Label lblCentro;
        protected Label lblIdPaciente;
        protected Label lblNombre;
        protected Label lblAcc;
        protected Label lblSexo;
        protected Label lblEdad;
        protected Label lblModalidad;
        protected Label lblVisores;
        protected GridView gvPrestaciones;
        protected TextBox txtAntecedentesClinicosLocal;
        protected GridView gvDocumentosRelacionados;
        protected TextBox lblComentarioTM;
        protected Label Label1;
        protected Label lblTitulo;
        protected TextBox txtTitulo;
        protected TextBox txtTecnica;
        protected TextBox txtAntecedentesClinicos;
        protected TextBox txtHallazgos;
        protected TextBox txtImpresion;
        protected HtmlAnchor aVerImagenes;
        protected DropDownList ddlVisor;
        protected Label lblPatologia;
        protected Panel divSi;
        protected Panel divNo;
        protected HtmlGenericControl divMensaje;
        protected Label lblMensajeError;
        protected HtmlAnchor aComentarios;
        protected HtmlAnchor aDescargarExamen;
        protected HtmlGenericControl modalInicioPopUpHabil;
        protected HtmlGenericControl modalInicioPopUpNoHabil;
        protected Button Button1;
        protected Button Button2;

        //public string val
        //{
        //    get
        //    {
        //        this.Session["p_val"] = (object)ParamUtil.GetParamString((object)this.Request[nameof(val)], "");

        //        if (this.Session["p_val"] != null && this.Session["p_val"].ToString() != "")
        //        {
        //            this.val_actual.Value = this.Session["p_val"].ToString();
        //            ConfiguracionGeneralDomain byId1 = ConfiguracionGeneralDataAccess.GetById(1L);
        //            ConfiguracionGeneralDomain byId2 = ConfiguracionGeneralDataAccess.GetById(2L);

        //            string[] strArray = EncCode.Decode(this.Session["p_val"].ToString().Replace(" ", "+"), byId1.valor1, byId2.valor1).Split('&', '=');

        //            for (int index = 0; index < strArray.Length; ++index)
        //            {
        //                if (strArray[index] == "id_ris_examen") this.Session["id_ris_examen"] = (object)Convert.ToInt64(strArray[index + 1]);

        //                if (strArray[index] == "codexamen") this.Session["codExamen"] = (object)strArray[index + 1];

        //                if (strArray[index] == "idInstitucion") this.Session["id_institucion"] = (object)Convert.ToInt64(strArray[index + 1]);

        //                if (strArray[index] == "id_informe") this.Session["id_informe"] = (object)Convert.ToInt64(strArray[index + 1]);

        //                if (strArray[index] == "idprestacion") this.Session["id_prestacion"] = (object)ParamUtil.GetParamLongValues((object)strArray[index + 1], new long[0]);

        //                if (strArray[index] == "clave") this.Session["clave"] = (object)strArray[index + 1];
        //            }

        //            bool flag = false;

        //            for (int index = 0; index < strArray.Length; ++index)
        //            {
        //                if (strArray[index] == "id_informe") flag = true;
        //            }

        //            if (!flag) this.Session["id_informe"] = (object)0;
        //        }
        //        else this.Session["p_val"] = (object)ParamUtil.GetParamString((object)this.val_actual.Value, "");

        //        return this.Session["p_val"].ToString();
        //    }
        //    set
        //    {
        //        this.Session["p_val"] = (object)value;
        //        this.val_actual.Value = value.ToString();
        //    }
        //}

        #region Codigo C# propio .NET
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.HttpMethod == "POST" && Request.Files.Count > 0) UploadFile();
                else
                {
                    //if (!this.IsPostBack) this.Session["SelectedPatologiaCritica"] = (object)-2;

                    if (!this.IsPostBack)
                    {
                        if (this.Request.UrlReferrer == (Uri)null) this.Response.Redirect("../../Default.aspx");



                        if (this.Session["id_usuario"] != null)
                        {
                            if (this.IsPostBack) return;

                            //string val = this.val;

                            ConfiguracionGeneralDomain byId = ConfiguracionGeneralDataAccess.GetById(3L);

                            var usuario = UsuarioDataAccess.GetById(Convert.ToInt64(this.Session["id_usuario"].ToString()));

                            string[] data = GetData(ParamUtil.GetParamString(this.Request["val"], ""));

                            if (data[2] == "id_informe")
                            {
                                hddCod.Value = data[5];
                                hddInstitucion.Value = data[7];
                                hddIdInforme.Value = data[3];
                                hddIdPrestacion.Value = string.Empty;

                                int contador = 0;
                                foreach (RisInformePrestacionDomain informePrestacion in RisInformePrestacionDataAccess.GetListByIdInforme(long.Parse(hddIdInforme.Value)))
                                {
                                    if (contador > 0)
                                        hddIdPrestacion.Value += ",";
                                    hddIdPrestacion.Value += informePrestacion.id_prestacion.ToString();
                                    contador++;
                                }
                            }
                            else
                            {
                                hddCod.Value = data[3];
                                hddInstitucion.Value = data[5];
                                hddIdInforme.Value = "0";
                                hddIdPrestacion.Value = data[7];
                            }

                            if (usuario.meddreams_automatico.Equals(1)) this.EnviarInstruccionMeddreams(int.Parse(hddInstitucion.Value), hddCod.Value);

                            usuarioNombre.Value = string.Format("{0}", usuario.nombre_completo.Equals("") ? usuario.nombre + " " + usuario.apellido_paterno : usuario.nombre_completo);
                            perfilNombre.Value = usuario.nombre_perfil;



                            if (byId.valor1 == data[1])
                            {
                                if (data[2] == "id_informe")
                                {
                                    this.cargarVisor(int.Parse(hddInstitucion.Value), hddCod.Value);
                                    this.cargarDatos(int.Parse(hddInstitucion.Value), hddCod.Value, hddIdPrestacion.Value);
                                }
                                else
                                {
                                    this.cargarVisor(int.Parse(hddInstitucion.Value), hddCod.Value);
                                    this.cargarDatos(int.Parse(hddInstitucion.Value), hddCod.Value, hddIdPrestacion.Value);
                                }
                            }
                            else this.Response.Redirect("");
                        }
                        else this.Response.Redirect("../Control/CerrarSesion.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                Informar.LogError(ex, nameof(Page_Load));
            }
        }

        protected void ddlVisor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["id_usuario"] == null) HttpContext.Current.Response.Redirect("../../Default.aspx");

            try
            {
                int int32 = Convert.ToInt32(this.ddlVisor.SelectedValue);
                InstitucionDomain byId = InstitucionDataAccess.GetById(Convert.ToInt32(hddInstitucion.Value));
                RisExamenDomain institucionCodExamen = RisExamenDataAccess.GetByInstitucionCodExamen(Convert.ToInt64(hddInstitucion.Value), byId.aetitle, hddCod.Value);
                UsuarioDataAccess.GetById(Convert.ToInt64(this.Session["id_usuario"].ToString()));
                InstitucionVisorDomain institucionAndVisor = InstitucionVisorDataAccess.GetAllForInstitucionAndVisor(byId.id_institucion, int32);
                this.aVerImagenes.Attributes.Remove("href");
                this.aVerImagenes.Attributes.Add("href", institucionAndVisor.url.Replace("#AETITLE#", institucionCodExamen.aetitle).Replace("#CODEXAMEN#", institucionCodExamen.codexamen));
            }
            catch (Exception ex)
            {
                Informar.LogError(ex, nameof(ddlVisor_SelectedIndexChanged));
            }
        }

        protected void btnPendiente_Click(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["id_usuario"] != null)
                return;
            HttpContext.Current.Response.Redirect("../../Default.aspx");
        }
        #endregion Codigo C# propio .NET

        [WebMethod]
        public static ResponseApp ValidarInforme(InformeDomain informe)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            try
            {
                int num = Informar.Guardar(informe, 3, 3, 1);
                return new ResponseApp()
                {
                    Data = new { Result = (object)num },
                    Ejecutado = true,
                    Mensaje = num.Equals(1) ? "El Informe ya se Encuentra Validado." : (num.Equals(2) ? "El Informe no puede ser validado porque fue creado con esta misma Prestación. Consultar al administrador." : "El Informe se valido Exitosamente.")
                };
            }
            catch (Exception ex)
            {
                Informar.LogError(ex, "btnInformar");
                return new ResponseApp()
                {
                    Data = (object)null,
                    Ejecutado = false,
                    Mensaje = "Error en sistema Multiris"
                };
            }
        }

        [WebMethod]
        public static ResponseApp InformarInforme(InformeDomain informe)
        {
            if (HttpContext.Current.Session["id_usuario"] == null) HttpContext.Current.Response.Redirect("../../Default.aspx");

            try
            {
                var num = 0;

                if (informe.Estado.Equals(1)) num = Informar.Guardar(informe, 1, 2, 1); else num = Informar.Guardar(informe, 2, 2, 1);

                return new ResponseApp()
                {
                    Data = (object)num,
                    Ejecutado = true,
                    Mensaje = num.Equals(1) ? "El Informe ya se Encuentra Validado." : (num.Equals(2) ? "El Informe ya fue creado con esta Prestación." : "El Informe se almaceno Exitosamente.")
                };
            }
            catch (Exception ex)
            {
                Informar.LogError(ex, "btnGuardar");

                return new ResponseApp() { Data = (object)null, Ejecutado = false, Mensaje = "Error en sistema Multiris" };
            }
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true)]
        public static ResponseApp ValidarUsuarioBecado()
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            UsuarioDomain byId = UsuarioDataAccess.GetById(Convert.ToInt64(HttpContext.Current.Session["id_usuario"].ToString()));
            bool flag = false;
            if (byId.id_perfil == 7 || byId.id_perfil == 10)
                flag = true;
            return new ResponseApp()
            {
                Data = (object)flag,
                Ejecutado = true,
                Mensaje = string.Empty
            };
        }

        //[WebMethod]
        //public static string ObtenerURLMeddreams()
        //{
        //    if (HttpContext.Current.Session["id_usuario"] == null)
        //        HttpContext.Current.Response.Redirect("../../Default.aspx");
        //    MeddreamsUtil meddreamsUtil = new MeddreamsUtil();
        //    InstitucionDomain byId = InstitucionDataAccess.GetById(Convert.ToInt32(HttpContext.Current.Session["id_institucion"].ToString()));
        //    RisExamenDomain institucionCodExamen = RisExamenDataAccess.GetByInstitucionCodExamen((long)Convert.ToInt32(HttpContext.Current.Session["id_institucion"].ToString()), byId.aetitle, HttpContext.Current.Session["codExamen"].ToString());
        //    string codexamen1 = institucionCodExamen.codexamen;
        //    string codexamen2 = institucionCodExamen.codexamen;
        //    int idInstitucion = byId.id_institucion;
        //    return meddreamsUtil.generarStringMeddreams(codexamen1, codexamen2, idInstitucion, true);
        //}

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true)]
        public static UsuarioDomain ObtenerUsuarioVocali()
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            return UsuarioDataAccess.GetById(Convert.ToInt64(HttpContext.Current.Session["id_usuario"].ToString()));
        }

        [WebMethod]
        public static ArrayList obtenerCredenciales()
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            ArrayList arrayList = new ArrayList();
            VocaliDomain byId1 = VocaliDataAccess.GetById(1);
            UsuarioDomain byId2 = UsuarioDataAccess.GetById(Convert.ToInt64(HttpContext.Current.Session["id_usuario"].ToString()));
            if (byId1.estado == 1 && byId2.vocali == 1)
                arrayList.Add((object)new
                {
                    username = byId2.username,
                    password = byId2.password,
                    host = byId1.direccion_url,
                    port = byId1.puerto,
                    agent = byId2.agente_vocali,
                    urlImagenes = "",
                    activarVocali = byId2.vocali
                });
            else
                arrayList.Add((object)new
                {
                    username = "",
                    password = "",
                    host = "",
                    port = "",
                    agent = "",
                    activarVocali = 0
                });
            return arrayList;
        }

        [WebMethod]
        public static ArrayList ObtenerDatos(string codExamen)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            ArrayList arrayList = new ArrayList();
            RisExamenDomain risExamenDomain = new RisExamenDomain();


            RisExamenDomain byCodExamen = RisExamenDataAccess.GetByCodExamen(codExamen);
            arrayList.Add((object)new
            {
                codexamen = codExamen,
                id_institucion = byCodExamen.id_institucion
            });

            return arrayList;
        }

        [WebMethod]
        public static long actualizarBloqueoExamen(string codExamen)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            long num = 0;
            if (codExamen != null)
            {
                RisExamenDomain byCodExamen = RisExamenDataAccess.GetByCodExamen(codExamen);
                UsuarioDomain byId = UsuarioDataAccess.GetById(Convert.ToInt64(HttpContext.Current.Session["id_usuario"].ToString()));
                if (byCodExamen.id_ris_examen > 0L)
                {
                    byCodExamen.bloqueado = 1;
                    byCodExamen.fecha_bloqueo = DateTime.Now;
                    byCodExamen.id_usuario_bloqueo = Convert.ToInt32(byId.id_usuario);
                    RisExamenDataAccess.Save(byCodExamen);
                    num = byCodExamen.id_ris_examen;
                }
            }
            return num;
        }

        [WebMethod]
        public static long guardarComentario(string codExamen, string numeroAcceso, int id_institucion, string comentario)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            long num = 0;
            InstitucionDomain byId1 = InstitucionDataAccess.GetById(id_institucion);
            DataTable dataTable = new DataTable();
            if (byId1.id_institucion > 0)
            {
                InstitucionDatosDomain methodAndInstitucion = InstitucionDatosDataAccess.GetByIdMethodAndInstitucion(11, byId1.id_institucion);
                UsuarioDomain byId2 = UsuarioDataAccess.GetById((long)Convert.ToInt32(HttpContext.Current.Session["id_usuario"].ToString()));
                RisExamenDomain byCodExamen = RisExamenDataAccess.GetByCodExamen(codExamen);
                if (ConfigurationManager.AppSettings["ActivarWSAPISalida"].ToString().Equals("1"))
                {
                    ConsumirWS consumirWs = new ConsumirWS();
                    ConsumirApi consumirApi = new ConsumirApi();
                    if (byId1.id_tipo_conexion == 1)
                    {
                        string json = "{\"id\":0,\"idInforme\":0,\"codExamen\":\"" + codExamen + "\",\"cantidad\":0,\"fecha\":\"" + DateTime.Now.ToString() + "\",\"aetitle\":\"" + byCodExamen.aetitle + "\"\"texto\":\"" + comentario + "\"\"username\":\"" + byId2.username + "\"}";
                        num = consumirApi.ApiObtenerIdRemoto(methodAndInstitucion.url, methodAndInstitucion.metodo, json, byId1.id_institucion);
                    }
                    else if (byId1.id_tipo_conexion == 2)
                        num = ConsumirWS.saveComentario(id_institucion, codExamen, comentario, byId2.username);
                }
            }
            return num;
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
                                Url = ConfigurationManager.AppSettings["HostApp"].ToString() + "/Web/Examen/InformarExamenPrevios.aspx?idPaciente="
                            });
                        }
                    }
                }
                else
                {
                    foreach (InstitucionDomain institucionDb in (IEnumerable<InstitucionDomain>)InstitucionDataAccess.GetAll().Where(x => x.estado.Equals(1)))
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
        [WebMethod]
        public static long guardarPlantilla(string tecnica, string hallazgos, string nombre_plantilla, string impresion, string titulo, string cod_examen)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            long num = 0;
            try
            {
                RisPlantillaDomain plantilla = new RisPlantillaDomain();
                UsuarioDomain byId = UsuarioDataAccess.GetById((long)Convert.ToInt32(HttpContext.Current.Session["id_usuario"].ToString()));
                ModalidadDomain byName = ModalidadDataAccess.GetByName(RisExamenDataAccess.GetByCodExamen(cod_examen).modalidad);
                plantilla.hallazgos = hallazgos;
                plantilla.impresion = impresion;
                plantilla.nombre = nombre_plantilla;
                plantilla.titulo = titulo;
                plantilla.tecnica = tecnica;
                plantilla.id_usuario = byId.id_usuario;
                plantilla.id_modalidad = byName.id_modalidad;
                num = RisPlantillaDataAccess.Save(plantilla);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                Log.Error(ex, message);
            }
            return num;
        }

        [WebMethod]
        public static string obtenerComentarios(string codExamen, string numeroAcceso, int id_institucion)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            string str1 = "";
            InstitucionDomain byId = InstitucionDataAccess.GetById(id_institucion);
            DataTable dataTable = new DataTable();
            if (byId.id_institucion > 0)
            {
                InstitucionDatosDomain methodAndInstitucion = InstitucionDatosDataAccess.GetByIdMethodAndInstitucion(7, byId.id_institucion);
                if (ConfigurationManager.AppSettings["ActivarWSAPISalida"].ToString().Equals("1"))
                {
                    ConsumirWS consumirWs = new ConsumirWS();
                    ConsumirApi consumirApi = new ConsumirApi();
                    if (byId.id_tipo_conexion == 1)
                    {
                        string json = "{\"codExamen\":\"" + codExamen + "\",\"numeroAcceso\":\"" + numeroAcceso + "\"}";
                        dataTable = consumirApi.ApiObtenerDataTable(methodAndInstitucion.url, methodAndInstitucion.metodo, json, byId.id_institucion);
                    }
                    else if (byId.id_tipo_conexion == 2)
                        dataTable = ConsumirWS.GetComentarios(byId.id_institucion, codExamen, numeroAcceso);
                }
            }
            if (dataTable.Rows.Count > 0)
            {
                string str2 = str1 + "<table><tr><th style='width: 70%;'><label>Comentario</label></th><th style='width: 15%; text-align: center'><label>Fecha</label></th><th style='width: 15%; text-align: center'><label>Usuario</label></th></tr>";
                foreach (DataRow row in (InternalDataCollectionBase)dataTable.Rows)
                {
                    str2 += "<tr>";
                    str2 += "<td>";
                    str2 = str2 + "<label>" + row["texto"]?.ToString() + "</label>";
                    str2 += "</td>";
                    str2 += "<td style='text-align: center;'>";
                    str2 = str2 + "<label>" + Convert.ToDateTime(row["fecha"]).ToString("dd-MM-yyyy HH:mm") + "</label>";
                    str2 += "</td>";
                    str2 += "<td style='text-align: center;'>";
                    str2 = str2 + "<label>" + row["username"]?.ToString() + "</label>";
                    str2 += "</td>";
                    str2 += "</tr>";
                }
                str1 = str2 + "</table>";
            }
            return str1;
        }

        [WebMethod]
        public static ResponseApp CargarPatologias(int idInstitucion)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            List<RisPatologiaCriticaDomain> patologiaCriticaDomainList = RisPatologiaCriticaDataAccess.Listar(idInstitucion);
            List<RisPatologiaCriticaDomain> source = patologiaCriticaDomainList == null ? new List<RisPatologiaCriticaDomain>() : patologiaCriticaDomainList;

            if (!source.Any())
                source.Add(new RisPatologiaCriticaDomain() { id_patologia_critica = -1, nombre = "- No existe patologias para esta institucion -" });

            return new ResponseApp()
            {
                Data = (object)source,
                Ejecutado = source.Any<RisPatologiaCriticaDomain>(),
                Mensaje = string.Empty
            };
        }

        [WebMethod]
        public static ResponseApp GetInforme(string codExamen, int idInstitucion, int idInforme)
        {
            if (HttpContext.Current.Session["id_usuario"] == null) HttpContext.Current.Response.Redirect("../../Default.aspx");

            RisInformeDomain byId = RisInformeDataAccess.GetByID(Convert.ToInt64(idInforme.ToString()));
            RisExamenDomain byCodExamen = RisExamenDataAccess.GetByCodExamen(codExamen);
            InformeDomain informeDomain = new InformeDomain();

            if (byId.id_ris_informe > 0L)
            {
                informeDomain.Titulo = Informar.reemplazarTextoCargar(byId.descripcion);
                RisInformeDatoDomain byMultuple1 = RisInformeDatoDataAccess.GetByMultuple(byId.id_ris_informe, byCodExamen.id_institucion, byCodExamen.codexamen, 11);
                informeDomain.AntecedentesClinicos = Informar.reemplazarTextoCargar(byMultuple1.valor);
                RisInformeDatoDomain byMultuple2 = RisInformeDatoDataAccess.GetByMultuple(byId.id_ris_informe, byCodExamen.id_institucion, byCodExamen.codexamen, 12);
                informeDomain.Hallazgos = Informar.reemplazarTextoCargar(byMultuple2.valor);
                RisInformeDatoDomain byMultuple3 = RisInformeDatoDataAccess.GetByMultuple(byId.id_ris_informe, byCodExamen.id_institucion, byCodExamen.codexamen, 13);
                informeDomain.Impresion = Informar.reemplazarTextoCargar(byMultuple3.valor);
                RisInformeDatoDomain byMultuple4 = RisInformeDatoDataAccess.GetByMultuple(byId.id_ris_informe, byCodExamen.id_institucion, byCodExamen.codexamen, 16);
                informeDomain.Tecnica = Informar.reemplazarTextoCargar(byMultuple4.valor);
                informeDomain.SeleccionPatologiaCritica = byId.flag_patologia_grave;
                informeDomain.IdPatologiaCritica = byId.id_patologia_grave;
                informeDomain.IdInforme = byId.id_ris_informe;
                informeDomain.Aetitle = byCodExamen.aetitle;
                informeDomain.Estado = byCodExamen.id_estado_examen;
            }
            return new ResponseApp()
            {
                Data = (object)informeDomain,
                Ejecutado = informeDomain.IdInforme > 0L,
                Mensaje = string.Empty
            };
        }

        [WebMethod]
        public static ResponseApp ExamenNuevo(string codExamen)
        {
            RisExamenDomain byCodExamen = RisExamenDataAccess.GetByCodExamen(codExamen);
            return new ResponseApp()
            {
                Mensaje = string.Empty,
                Ejecutado = byCodExamen != null,
                Data = (object)(byCodExamen.id_estado_examen == 0)
            };
        }

        [WebMethod]
        public static ResponseApp GetPlantillas(string codExamen)
        {
            if (HttpContext.Current.Session["id_usuario"] == null) HttpContext.Current.Response.Redirect("../../Default.aspx");

            List<RisPlantillaDomain> risPlantillaDomainList = RisPlantillaDataAccess.Listar(int.Parse(HttpContext.Current.Session["id_usuario"].ToString()), RisExamenDataAccess.GetByCodExamen(codExamen).modalidad);
            List<RisPlantillaDomain> source = risPlantillaDomainList == null ? new List<RisPlantillaDomain>() : risPlantillaDomainList;
            source.Insert(0, new RisPlantillaDomain()
            {
                id_plantilla = 0L,
                nombre = "- Seleccione -"
            });
            return new ResponseApp()
            {
                Data = (object)source.OrderBy<RisPlantillaDomain, string>((System.Func<RisPlantillaDomain, string>)(o => o.nombre)).ToList<RisPlantillaDomain>(),
                Ejecutado = source.Any<RisPlantillaDomain>(),
                Mensaje = !source.Any<RisPlantillaDomain>() ? "No existen planillas para la modalidad del examen seleccionado" : string.Empty
            };
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true)]
        public static ResponseApp GetPlantilla(int idPlantilla)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            RisPlantillaDomain byId = RisPlantillaDataAccess.GetById((long)idPlantilla);
            RisPlantillaDomain risPlantillaDomain = byId == null ? new RisPlantillaDomain() : byId;
            return new ResponseApp()
            {
                Data = (object)risPlantillaDomain,
                Ejecutado = risPlantillaDomain.id_plantilla != 0L,
                Mensaje = string.Empty
            };
        }

        [WebMethod]
        public static ResponseApp CrearPlantilla(RisPlantillaDomain plantilla)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            ModalidadDomain byName = ModalidadDataAccess.GetByName(RisExamenDataAccess.GetByCodExamen(plantilla.CodExamen).modalidad);
            RisPlantillaDomain byId = RisPlantillaDataAccess.GetById(Convert.ToInt64(plantilla.id_plantilla));
            byId.nombre = plantilla.nombre;
            byId.titulo = plantilla.titulo;
            byId.tecnica = plantilla.tecnica;
            byId.hallazgos = plantilla.hallazgos;
            byId.impresion = plantilla.impresion;
            byId.id_usuario = Convert.ToInt64(HttpContext.Current.Session["id_usuario"].ToString());
            byId.id_modalidad = byName.id_modalidad;
            long num = RisPlantillaDataAccess.Save(byId);
            return new ResponseApp()
            {
                Data = (object)num,
                Ejecutado = num > 0L,
                Mensaje = num > 0L ? "Plantilla se creo o actualizo con exito" : "Plantilla no se creo o actualizo con exito"
            };
        }

        [WebMethod]
        public static ResponseApp ActualizarPlantilla(RisPlantillaDomain plantilla)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            ModalidadDomain byName = ModalidadDataAccess.GetByName(RisExamenDataAccess.GetByCodExamen(plantilla.CodExamen).modalidad);
            RisPlantillaDomain byId = RisPlantillaDataAccess.GetById(Convert.ToInt64(plantilla.id_plantilla));
            byId.titulo = plantilla.titulo;
            byId.tecnica = plantilla.tecnica;
            byId.hallazgos = plantilla.hallazgos;
            byId.impresion = plantilla.impresion;
            byId.id_usuario = Convert.ToInt64(HttpContext.Current.Session["id_usuario"].ToString());
            byId.id_modalidad = byName.id_modalidad;
            long num = RisPlantillaDataAccess.Save(byId);
            return new ResponseApp()
            {
                Data = (object)num,
                Ejecutado = num > 0L,
                Mensaje = num > 0L ? "Plantilla se creo o actualizo con exito" : "Plantilla no se creo o actualizo con exito"
            };
        }

        [WebMethod]
        public static ResponseApp ListarTagsExamen(string codExamen)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            List<TagExamenListarDomain> source = TagExamenDataAccess.ListarExamenTag(codExamen);
            return new ResponseApp()
            {
                Data = (object)source,
                Ejecutado = source.Any<TagExamenListarDomain>(),
                Mensaje = string.Empty
            };
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true)]
        public static ResponseApp ListarTags()
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            List<TagExamenDomain> source = TagExamenDataAccess.ListarVigenteUsuario(HttpContext.Current.Session["username"].ToString());
            return new ResponseApp()
            {
                Data = (object)source,
                Ejecutado = source.Any<TagExamenDomain>(),
                Mensaje = !source.Any<TagExamenDomain>() ? "No existen Tags para el usuario" : string.Empty
            };
        }

        #region Metodos internos										  
        private void EnviarInstruccionMeddreams(int institucion, string codExamen)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            MeddreamsUtil meddreamsUtil = new MeddreamsUtil();
            InstitucionDomain byId = InstitucionDataAccess.GetById(institucion);
            RisExamenDomain institucionCodExamen = RisExamenDataAccess.GetByInstitucionCodExamen(institucion, byId.aetitle, codExamen);
            string codexamen1 = institucionCodExamen.codexamen;
            string codexamen2 = institucionCodExamen.codexamen;
            int idInstitucion = byId.id_institucion;
            meddreamsUtil.generarStringMeddreams(codexamen1, codexamen2, idInstitucion, true);
        }

        private static string encriptarInformar(string texto)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            ConfiguracionGeneralDomain byId1 = ConfiguracionGeneralDataAccess.GetById(1L);
            ConfiguracionGeneralDomain byId2 = ConfiguracionGeneralDataAccess.GetById(2L);
            return "Informar.aspx?val=" + EncCode.Encode("clave=" + ConfiguracionGeneralDataAccess.GetById(3L).valor1 + texto, byId1.valor1, byId2.valor1);
        }

        private void cargarVisor(int idInstitucion, string codExamen)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            MeddreamsUtil meddreamsUtil = new MeddreamsUtil();
            InstitucionDomain byId = InstitucionDataAccess.GetById(idInstitucion);
            RisExamenDomain institucionCodExamen = RisExamenDataAccess.GetByInstitucionCodExamen(idInstitucion, byId.aetitle, codExamen);
            if (institucionCodExamen.id_ris_examen <= 0L)
                return;
            this.lblVisores.Text = meddreamsUtil.generarStringVisores(institucionCodExamen.codexamen, byId.id_institucion, true, Convert.ToInt64(this.Session["id_usuario"].ToString()));
        }

        private static string reemplazarTextoGuardar(string texto)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            texto = texto.Replace("&Aacute;", "Á");
            texto = texto.Replace("&aacute;", "á");
            texto = texto.Replace("&Eacute;", "É");
            texto = texto.Replace("&eacute;", "é");
            texto = texto.Replace("&Iacute;", "I");
            texto = texto.Replace("&iacute;", "í");
            texto = texto.Replace("&Oacute;", "Ó");
            texto = texto.Replace("&oacute;", "ó");
            texto = texto.Replace("&Uacute;", "Ú");
            texto = texto.Replace("&uacute;", "ú");
            texto = texto.Replace("&Ntilde;", "Ñ");
            texto = texto.Replace("&ntilde;", "ñ");
            texto = texto.Replace("&nbsp;", " ");
            texto = texto.Replace("</p>\r\n\r\n<p>", "\r\n\r\n");
            return texto;
        }

        private static string reemplazarTextoCargar(string texto)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            texto = texto.Replace("Á", "&Aacute;");
            texto = texto.Replace("á", "&aacute;");
            texto = texto.Replace("É", "&Eacute;");
            texto = texto.Replace("é", "&eacute;");
            texto = texto.Replace("I", "&Iacute;");
            texto = texto.Replace("í", "&iacute;");
            texto = texto.Replace("Ó", "&Oacute;");
            texto = texto.Replace("ó", "&oacute;");
            texto = texto.Replace("Ú", "&Uacute;");
            texto = texto.Replace("ú", "&uacute;");
            texto = texto.Replace("Ñ", "&Ntilde;");
            texto = texto.Replace("ñ", "&ntilde;");
            texto = texto.Replace("\r\n\r\n", "</p>\r\n\r\n<p>");
            texto = texto.Replace("&nbsp;", " ");
            return texto;
        }

        public void ObtenerComentarioTM(int id_institucion, string codexamen)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            this.lblComentarioTM.Text = ConsumirWS.ObtenerComentarioTM(id_institucion, codexamen);
        }

        private void cargarDatos(int idInstitucion, string codExamen, string prestaciones)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");

            InstitucionDomain byId1 = InstitucionDataAccess.GetById(idInstitucion);

            RisExamenDomain institucionCodExamen = RisExamenDataAccess.GetByInstitucionCodExamen(idInstitucion, byId1.aetitle, codExamen);

            this.val_estado.Value = institucionCodExamen.id_estado_examen.ToString();

            ConfiguracionGeneralDataAccess.GetById(6L);

            if (ConfigurationManager.AppSettings["ActivarWSAPISalida"].ToString().Equals("1"))
                this.ObtenerComentarioTM(byId1.id_institucion, institucionCodExamen.codexamen);

            this.val_modalidad.Value = institucionCodExamen.modalidad;
            this.lblCentro.Text = byId1.nombre;
            this.cargarDocumentosRelacionados(byId1.id_institucion, institucionCodExamen.idpaciente, institucionCodExamen.codexamen, codExamen);

            if (institucionCodExamen.id_ris_examen > 0L)
            {
                this.lblIdPaciente.Text = institucionCodExamen.idpaciente;
                this.lblNombre.Text = institucionCodExamen.nombre + " " + institucionCodExamen.apellidopaterno + " " + institucionCodExamen.apellidomaterno;
                this.lblNombre.Text = this.lblNombre.Text.Replace("^", " ");
                this.lblEdad.Text = institucionCodExamen.edad;
                this.txtAntecedentesClinicosLocal.Text = ConsumirWS.ObtenerAntecedenteClinico(byId1.id_institucion, institucionCodExamen.codexamen);
                this.lblAcc.Text = institucionCodExamen.numeroacceso;
                this.lblSexo.Text = institucionCodExamen.sexo;
                this.aComentarios.Attributes.Add("OnClick", "obtenerComentarios('" + institucionCodExamen.codexamen + "','" + institucionCodExamen.numeroacceso + "'," + institucionCodExamen.id_institucion.ToString() + "); return false;");
                UsuarioDomain byId2 = UsuarioDataAccess.GetById(Convert.ToInt64(this.Session["id_usuario"].ToString()));
                this.aVerImagenes.Attributes.Add("href", InstitucionVisorDataAccess.GetAllForInstitucionAndVisor(byId1.id_institucion, byId2.id_visor).url.Replace("#AETITLE#", institucionCodExamen.aetitle).Replace("#CODEXAMEN#", institucionCodExamen.codexamen));
                this.aDescargarExamen.Attributes.Add("href", byId1.url_descarga.Replace("#CODEXAMEN#", institucionCodExamen.codexamen).Replace("#AETITLE#", institucionCodExamen.aetitle));
            }

            this.risExamen.Value = institucionCodExamen.id_ris_examen.ToString();

            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("nombrePrestacion");

            for (int index = 0; index < prestaciones.Split(',').Length; ++index)
            {
                DataRow row = dataTable.NewRow();
                RisPrestacionDomain byId3 = RisPrestacionDataAccess.GetById(long.Parse(prestaciones.Split(',')[index]));
                row["nombrePrestacion"] = (object)byId3.nombre;
                dataTable.Rows.Add(row);
            }



            this.gvPrestaciones.DataSource = (object)dataTable;
            this.gvPrestaciones.DataBind();
        }

        //private static void resetearValores()
        //{
        //    if (HttpContext.Current.Session["id_usuario"] == null)
        //        HttpContext.Current.Response.Redirect("../../Default.aspx");

        //    HttpContext.Current.Session["id_ris_examen"] = (object)0;
        //    HttpContext.Current.Session["codExamen"] = (object)string.Empty;
        //    HttpContext.Current.Session["id_institucion"] = (object)0;
        //    HttpContext.Current.Session["id_prestacion"] = (object)new long[0];
        //    HttpContext.Current.Session["clave"] = (object)"";

        //    ConfiguracionGeneralDomain byId1 = ConfiguracionGeneralDataAccess.GetById(1L);
        //    ConfiguracionGeneralDomain byId2 = ConfiguracionGeneralDataAccess.GetById(2L);

        //    string[] strArray = EncCode.Decode(HttpContext.Current.Session["p_val"].ToString().Replace(" ", "+"), byId1.valor1, byId2.valor1).Split('&', '=');

        //    for (int index = 0; index < strArray.Length; ++index)
        //    {
        //        if (strArray[index] == "id_ris_examen")
        //            HttpContext.Current.Session["id_ris_examen"] = (object)Convert.ToInt64(strArray[index + 1]);
        //        if (strArray[index] == "codexamen")
        //            HttpContext.Current.Session["codExamen"] = (object)strArray[index + 1];
        //        if (strArray[index] == "idInstitucion")
        //            HttpContext.Current.Session["id_institucion"] = (object)Convert.ToInt64(strArray[index + 1]);
        //        if (strArray[index] == "id_informe")
        //            HttpContext.Current.Session["id_informe"] = (object)Convert.ToInt64(strArray[index + 1]);
        //        if (strArray[index] == "idprestacion")
        //            HttpContext.Current.Session["id_prestacion"] = (object)ParamUtil.GetParamLongValues((object)strArray[index + 1], new long[0]);
        //        if (strArray[index] == "clave")
        //            HttpContext.Current.Session["clave"] = (object)strArray[index + 1];
        //    }
        //}

        private static int Guardar(InformeDomain informe, int id_estado_examen, int id_estado_informe, int accion)
        {
            if (HttpContext.Current.Session["id_usuario"] == null) HttpContext.Current.Response.Redirect("../../Default.aspx");

            id_estado_informe = id_estado_examen.Equals(1) ? id_estado_examen : id_estado_informe;

            try
            {
                //Informar.resetearValores();

                List<TagExamenDomain> tagsExamen = new List<TagExamenDomain>();

                foreach (int idTag in informe.IdTags)
                    tagsExamen.Add(new TagExamenDomain()
                    {
                        Id = 0,
                        IdTag = idTag,
                        CodExamen = informe.CodExamen,
                        UsuarioCreacion = HttpContext.Current.Session["username"].ToString()
                    });

                InstitucionDomain byId1 = InstitucionDataAccess.GetById(informe.IdInstitucion);

                //string id_prestacion = string.Empty;
                //long[] numArray = (long[])HttpContext.Current.Session["id_prestacion"];

                //List<RisInformePrestacionDomain> prestacionDomainList = new List<RisInformePrestacionDomain>();

                //int num1 = numArray.Length;

                //if (num1.Equals(0)) RisInformePrestacionDataAccess.GetByCodExamen(informe.CodExamen);

                //num1 = numArray.Length;

                //if (!num1.Equals(0))
                //{
                  //  for (int index = 0; index <= numArray.Length - 1; ++index)
                    //    id_prestacion = id_prestacion + numArray[index].ToString() + ",";
                    //id_prestacion = id_prestacion.Substring(0, id_prestacion.Length - 1);
                //}

                //HttpContext.Current.Session["id_prestacion"] = (object)id_prestacion;
                //object obj = HttpContext.Current.Session["id_prestacion"];

                RisExamenDomain institucionCodExamen = RisExamenDataAccess.GetByInstitucionCodExamen(informe.IdInstitucion, byId1.aetitle, informe.CodExamen);
                UsuarioDomain byId2 = UsuarioDataAccess.GetById(Convert.ToInt64(HttpContext.Current.Session["id_usuario"]));
                DataTable dataTable = RisInformeDataAccess.SaveControlado(informe.CodExamen, informe.IdInstitucion, (int)informe.IdInforme, id_estado_informe, informe.IdPrestaciones, byId2.id_perfil == 9 || byId2.id_perfil == 7 ? (int)SessionApp.Get<UsuarioDomain>("KeyRadiolpogoBecado").id_usuario : int.Parse(HttpContext.Current.Session["id_usuario"].ToString()), informe.SeleccionPatologiaCritica == 0 ? -1 : informe.SeleccionPatologiaCritica, informe.PatologiaCritica == "--Seleccione--" ? "0" : informe.PatologiaCritica, Informar.reemplazarTextoGuardar(informe.Titulo), Informar.reemplazarTextoGuardar(informe.AntecedentesClinicos), Informar.reemplazarTextoGuardar(informe.Hallazgos), Informar.reemplazarTextoGuardar(informe.Impresion), Informar.reemplazarTextoGuardar(informe.Tecnica), informe.SeleccionPatologiaCritica == 1 ? informe.IdPatologiaCritica : 0, tagsExamen, byId2.id_perfil == 9 || byId2.id_perfil == 7 ? long.Parse(HttpContext.Current.Session["id_usuario"].ToString()) : 0L);

                int num2 = 0;
                int num1 = dataTable.Rows.Count;

                if (!num1.Equals(0))
                    num2 = int.Parse(dataTable.Rows[0].ItemArray[0].ToString());

                string str = num2.Equals(1) ? string.Empty : (num2.Equals(2) ? "El Informe ya fue creado con esta Prestación." : "Usuario " + byId2.username + " genero un informe con id " + num2.ToString());

                RisLogDataAccess.SaveReturn(new RisLogDomain()
                {
                    sistema = "MULTIRISWEB",
                    observacion = str,
                    id_institucion = institucionCodExamen.id_institucion,
                    codexamen = institucionCodExamen.codexamen,
                    id_ris_examen = institucionCodExamen.id_ris_examen,
                    id_usuario = byId2.id_usuario,
                    tipoAccion = (long)accion
                });
                
                num1 = num2;
                return num1;
            }
            catch
            {
                throw;
            }
        }

        private void cargarDocumentosRelacionados(int id_institucion, string id_paciente, string cod_examen, string codExamen)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            DataTable dtDatos = new DataTable();
            RisExamenDomain byCodExamen = RisExamenDataAccess.GetByCodExamen(codExamen);
            InstitucionDomain byId = InstitucionDataAccess.GetById(id_institucion);
            if (byId.id_institucion > 0)
            {
                InstitucionDatosDomain methodAndInstitucion = InstitucionDatosDataAccess.GetByIdMethodAndInstitucion(10, byId.id_institucion);
                if (ConfigurationManager.AppSettings["ActivarWSAPISalida"].ToString().Equals("1"))
                {
                    ConsumirWS consumirWs = new ConsumirWS();
                    ConsumirApi consumirApi = new ConsumirApi();
                    if (byId.id_tipo_conexion == 1)
                        dtDatos = consumirApi.ApiObtenerDataTable(methodAndInstitucion.url, methodAndInstitucion.metodo, Informar.jsonEstudiosRelacionados(id_paciente), id_institucion);
                    else if (byId.id_tipo_conexion == 2)
                        dtDatos = ConsumirWS.GetDocumentosExamen(byId.id_institucion, cod_examen, byCodExamen.numeroacceso);
                }
            }
            if (dtDatos.Rows.Count <= 0)
                return;
            this.gvDocumentosRelacionados.DataSource = (object)this.normalizaDocumentosDelExamen(dtDatos, byId.id_institucion);
            this.gvDocumentosRelacionados.DataBind();
        }

        private DataTable normalizaDocumentosDelExamen(DataTable dtDatos, int id_institucion)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
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
                else if (row1["filename"].ToString().Contains(".jpg") || row1["filename"].ToString().Contains(".png") || row1["filename"].ToString().Contains(".PNG") || row1["filename"].ToString().Contains(".JFIF") || row1["filename"].ToString().Contains(".jfif"))
                    row2["archivo"] = (object)("<a href='#' onclick='cargarDocumento(&#34" + byId.url_pagina + row1["webfolder"]?.ToString() + row1["filename"]?.ToString() + "&#34); return false;' target='_blank' title='" + row1["descripcion"]?.ToString() + "'><img src='../icon/visor.sl.png' /></a>");
                dataTable.Rows.Add(row2);
            }
            return dataTable;
        }

        private static DataTable normalizaOrdenMedica(DataTable dt, int id_institucion)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            InstitucionDomain byId = InstitucionDataAccess.GetById(id_institucion);
            for (int index = 0; index <= dt.Rows.Count; ++index)
                dt.Rows[index]["orden_medica"] = (object)(byId.url_base + dt.Rows[index]["orden_medica"]?.ToString());
            return dt;
        }

        private static DataTable normalizaDataTableEstudiosRelacionados(DataTable dtOrigen, int id_institucion, string id_paciente, string codexamen)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
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

        private static string reemplazarTextoCargar2(string texto)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            texto = texto.Replace("Á", "&Aacute;");
            texto = texto.Replace("á", "&aacute;");
            texto = texto.Replace("É", "&Eacute;");
            texto = texto.Replace("é", "&eacute;");
            texto = texto.Replace("I", "&Iacute;");
            texto = texto.Replace("í", "&iacute;");
            texto = texto.Replace("Ó", "&Oacute;");
            texto = texto.Replace("ó", "&oacute;");
            texto = texto.Replace("Ú", "&Uacute;");
            texto = texto.Replace("ú", "&uacute;");
            texto = texto.Replace("Ñ", "&Ntilde;");
            texto = texto.Replace("ñ", "&ntilde;");
            texto = texto.Replace("<p>", "");
            texto = texto.Replace("</p>", "");
            texto = texto.Replace("<u>", "");
            texto = texto.Replace("</u>", "");
            texto = texto.Replace("<em>", "");
            texto = texto.Replace("</em>", "");
            texto = texto.Replace("<strong>", "");
            texto = texto.Replace("</strong>", "");
            texto = texto.Replace("<n>", "");
            texto = texto.Replace("</n>", "");
            texto = texto.Replace("<hr />", "");
            texto = texto.Replace("</BR>", "");
            texto = texto.Replace("</br>", "");
            texto = texto.Replace("&nbsp;", " ");
            return texto;
        }

        private static string jsonEstudiosRelacionados(string id_paciente)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            return "{\"id_paciente\":\"" + id_paciente + "\"}";
        }

        public static void LogError(Exception ex, string paginaEvento)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            ControlErrorDataAccess.ControlErrorSave(ex.HResult, ex.GetType().Name, ex.ToString(), 1, paginaEvento, int.Parse(HttpContext.Current.Session["id_usuario"].ToString()));
        }

        protected void ddlSeleccionePatologia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            this.lblPatologia.ForeColor = Color.White;
            this.divMensaje.Visible = false;
        }
        #endregion Metodos internos

        /*Desde Aqui comienza chat pendiente CRM*/
        #region Metodos nuevos para Notificacion pendiente
        [WebMethod]
        public static JsonResult CargaChat(long risExamen)
        {
            if (HttpContext.Current.Session["id_usuario"] == null) HttpContext.Current.Response.Redirect("../../Default.aspx");

            try
            {
                List<MessageDomain> data = MessageDomain.ConvertTo(CanalDataAccess.Get(Convert.ToInt32(risExamen)));

                return new JsonResult() { Data = new ResponseApp() { Data = data, Ejecutado = true, Mensaje = "" } };
            }
            catch (Exception ex)
            {
                Informar.LogError(ex, "CargaChat");

                return new JsonResult() { Data = new ResponseApp() { Data = null, Ejecutado = false, Mensaje = ex.Message.ToString() } };
            }
        }

        [WebMethod]
        public static ResponseApp CargaCategoria()
        {
            if (HttpContext.Current.Session["id_usuario"] == null) HttpContext.Current.Response.Redirect("../../Default.aspx");

            try
            {
                var data = CategoriaDataAccess.GetAll();

                return new ResponseApp() { Data = data, Ejecutado = true, Mensaje = "" };
            }
            catch (Exception ex)
            {
                Informar.LogError(ex, "CargaCategoria");

                return new ResponseApp() { Data = null, Ejecutado = false, Mensaje = ex.Message.ToString() };
            }
        }

        [WebMethod]
        public static ResponseApp VerificaCanal(string risExamen)
        {
            if (HttpContext.Current.Session["id_usuario"] == null) HttpContext.Current.Response.Redirect("../../Default.aspx");

            try
            {
                var usu = Convert.ToInt32(HttpContext.Current.Session["id_usuario"].ToString());
                var data = CanalDataAccess.Get(risExamen, usu);

                return new ResponseApp() { Data = data, Ejecutado = true, Mensaje = "" };
            }
            catch (Exception ex)
            {
                Informar.LogError(ex, "VerificaCanal");

                return new ResponseApp() { Data = null, Ejecutado = false, Mensaje = ex.Message.ToString() };
            }
        }

        [WebMethod]
        public static ResponseApp InsertaChat(string risExamen, int categoria, string fechaCreacion, string mensaje, int tipo)
        {
            if (HttpContext.Current.Session["id_usuario"] == null) HttpContext.Current.Response.Redirect("../../Default.aspx");

            try
            {
                ChatDomain chat = new ChatDomain()
                {
                    risExamen = Convert.ToInt32(risExamen),
                    usuarioCreador = Convert.ToInt32(HttpContext.Current.Session["id_usuario"].ToString()),
                    categoriaId = categoria,
                    fechaCreacion = ParserDateTime(fechaCreacion),
                    mensaje = mensaje,
                    tipoMensajeId = tipo
                };

                var data = CanalDataAccess.Set(chat);

                return new ResponseApp() { Data = null, Ejecutado = true, Mensaje = "" };
            }
            catch (Exception ex)
            {
                Informar.LogError(ex, "InsertaChat");

                return new ResponseApp() { Data = null, Ejecutado = false, Mensaje = ex.Message.ToString() };
            }
        }

        [WebMethod]
        public static ResponseApp CierraPendiente(string risExamen)
        {
            if (HttpContext.Current.Session["id_usuario"] == null) HttpContext.Current.Response.Redirect("../../Default.aspx");

            try
            {
                var usu = Convert.ToInt32(HttpContext.Current.Session["id_usuario"].ToString());
                var data = CanalDataAccess.Set(risExamen, 3, usu);

                return new ResponseApp() { Data = data, Ejecutado = true, Mensaje = "" };
            }
            catch (Exception ex)
            {
                Informar.LogError(ex, "InsertaChat");

                return new ResponseApp() { Data = null, Ejecutado = false, Mensaje = ex.Message.ToString() };
            }
        }

        [WebMethod]
        public static ResponseApp ListaArchivo(string risExamen)
        {
            if (HttpContext.Current.Session["id_usuario"] == null) HttpContext.Current.Response.Redirect("../../Default.aspx");

            try
            {
                var data = ArchivoDomain.ConvertTo(ArchivoPendienteDataAccess.Get(new ArchivoDomain() { id_ris_examen_canal = Convert.ToInt64(risExamen) }));

                return new ResponseApp() { Data = data, Ejecutado = true, Mensaje = "" };
            }
            catch (Exception ex)
            {
                return new ResponseApp() { Data = null, Ejecutado = false, Mensaje = ex.Message.ToString() };
            }
        }

        [WebMethod]
        public static ResponseApp DescargaArchivo(string risExamen, string fileId, string userCreate, string fileName)
        {
            long data = 0;

            if (HttpContext.Current.Session["id_usuario"] == null) HttpContext.Current.Response.Redirect("../../Default.aspx");

            var usuarioActual = Convert.ToInt64(HttpContext.Current.Session["id_usuario"].ToString());
            var usuarioCreador = Convert.ToInt64(userCreate);

            try
            {
                if (!usuarioActual.Equals(usuarioCreador))
                {
                    data = ArchivoPendienteDataAccess.Put(new ArchivoDomain() { id_ris_examen_canal = Convert.ToInt64(risExamen), id_archivo = Convert.ToInt64(fileId), usuarioEnvio = usuarioActual });
                }

                return new ResponseApp() { Data = Convert.ToBase64String(DownloadFile(fileName)), Mensaje = data.ToString(), Ejecutado = true };
            }
            catch (Exception ex)
            {
                return new ResponseApp() { Data = "", Mensaje = ex.Message.ToString(), Ejecutado = false };
            }
        }

        [WebMethod]
        public static void SendMail(string risExamen, int tipo, string msg, string ctg) {

            if (tipo.Equals(1))
                try
                {
                    var usuario = Convert.ToInt64(HttpContext.Current.Session["id_usuario"].ToString());

                    var _examen = RisExamenDataAccess.GetById(Convert.ToInt64(risExamen));
                    var _institucion = InstitucionDataAccess.GetById(_examen.id_institucion);
                    var _usuario = UsuarioDataAccess.GetById(usuario);
                    var _tipoUrgencia = TipoUrgenciaDataAccess.GetByCod(_examen.idtipoorden);

                    EnviaCorreoPendiente(_examen, _institucion, _tipoUrgencia, _usuario, msg, ctg);
                }
                catch { }
        }

        public void UploadFile()
        {
            if (HttpContext.Current.Session["id_usuario"] == null) HttpContext.Current.Response.Redirect("../../Default.aspx");

            var usuario = Convert.ToInt64(HttpContext.Current.Session["id_usuario"].ToString());

            Response.ContentType = "text/plain";

            try
            {
                string ftpUrl = ConfigurationManager.AppSettings["FTPIPChat"].ToString();
                string ftpUser = ConfigurationManager.AppSettings["FTPUSERChat"].ToString();
                string ftpPass = ConfigurationManager.AppSettings["FTPPASSChat"].ToString();

                var _ftp = string.Format("ftp://{0}@{1}/", ftpUser, ftpUrl);

                HttpPostedFile file = Request.Files["file"];
                var risExamen = Request.Form["risExamen"];

                string fileName = Path.GetFileName(file.FileName);
                string ftpPath = _ftp + fileName;

                using (Stream stream = file.InputStream)
                {
                    FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(ftpPath);
                    ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
                    ftpRequest.Credentials = new NetworkCredential(ftpUser, ftpPass);
                    ftpRequest.ContentLength = file.ContentLength;

                    using (Stream requestStream = ftpRequest.GetRequestStream()) { stream.CopyTo(requestStream); }

                    using (FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse())
                    {
                        if (response.StatusDescription.ToString().Contains("226"))
                        {
                            var status = ArchivoPendienteDataAccess.Set(
                                new ArchivoDomain() { id_ris_examen_canal = Convert.ToInt64(risExamen), nombre = fileName, usuarioEnvio = usuario, tipoMensajeId = 0 }
                            );

                            if (status.Equals(200))
                                Response.Write(string.Format("200|{0}", response.StatusDescription));
                            else
                            {
                                Response.Write(string.Format("210|{0}", "Se copio el archivo, pero hubo errores el la grabacion"));
                            }
                        }
                        else
                            Response.Write(string.Format("{0}|{1}", response.StatusCode.ToString(), response.StatusDescription));
                    }
                }
            }
            catch (Exception e)
            {
                Response.Write(string.Format("{0}|{1} {2}", "500", "Error al subir archivo", e.Message.ToString()));
            }
            finally
            {
                Response.End();
            }
        }

        public static byte[] DownloadFile(string fileName)
        {
            try
            {
                string ftpUrl = ConfigurationManager.AppSettings["FTPIPChat"].ToString();
                string ftpUser = ConfigurationManager.AppSettings["FTPUSERChat"].ToString();
                string ftpPass = ConfigurationManager.AppSettings["FTPPASSChat"].ToString(); ;

                System.Net.ServicePointManager.Expect100Continue = true;
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;

                string rutaComplete = string.Format(@"ftp://{0}@{1}/{2}", ftpUser, ftpUrl, fileName.Trim());

                System.Net.FtpWebRequest ftpRequest = (System.Net.FtpWebRequest)System.Net.WebRequest.Create(rutaComplete);

                ftpRequest.Method = System.Net.WebRequestMethods.Ftp.DownloadFile;

                ftpRequest.Credentials = new System.Net.NetworkCredential(ftpUser, ftpPass);

                using (System.Net.FtpWebResponse response = (System.Net.FtpWebResponse)ftpRequest.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            responseStream.CopyTo(memoryStream);
                            return memoryStream.ToArray();  // Devuelve el archivo como un arreglo de bytes
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la descarga: " + ex.Message);
            }
        }
        #endregion Metodos nuevos para Notificacion pendiente

        #region Metodos privados nuevos
        private static string ParserDateTime(string fecha)
        {
            var hora = fecha.Split(' ')[1];

            fecha = fecha.Replace("-", "").Replace("/", "");

            return fecha.Substring(2, 2) + "-" + fecha.Substring(0, 2) + "-" + fecha.Substring(4, 4) + " " + hora;
        }

        private static void EnviaCorreoPendiente(RisExamenDomain examen, InstitucionDomain institucion, TipoUrgenciaDomain urgencia, UsuarioDomain radiologo, string msg, string ctg)
        {
            string emailcc = radiologo.email1;

            var mensaje = "Señores <br />" +
                          "<b> " + institucion.nombre + " </b><br /><br />" +
                          "El siguiente examen requiere de documentación o antecedentes faltantes para elaborar su informe: <br /><br />" +
                          "Tipo Categoría: <b>" + ctg + "</b><br />" +
                          "Tipo Atención: <b>" + urgencia.nombre + "</b><br />" +
                          "Paciente: <b>" + examen.nombre + "</b><br />" +
                          "Rut: <b>" + examen.idpaciente + "</b><br />" +
                          "Fecha/Hora Examen: <b>" + examen.fechaexamen + "</b><br /><br />" +
                          "Mensaje del Radiologo: <br /><b>" + msg + "</b><br /><br /><br />" +
                          "Por favor acceder con su usuario y credencales a nuestra plaforma para revisar más detalles " + @"https://multiris.irad.cl/multirisweb" +
                          "<br /><br /><br />Atte.<br /><br /> <b>Diagnóstico por Imágenes</b><br />";

            string appSetting1 = ConfigurationManager.AppSettings["emailfrom"];
            string appSetting2 = institucion.correo_pendiente;
            string appSetting3 = "Notificación de Examen Pendiente";
            string appSetting4 = ConfigurationManager.AppSettings["emailpass"];
            string appSetting6 = ConfigurationManager.AppSettings["institucion"];
            string asunto = "Notificación de Examen Pendiente : ";
            string cuerpo = mensaje;

            MailUtil.SendMail(appSetting3, appSetting1, appSetting4, appSetting2, emailcc, asunto, cuerpo);
        }
        #endregion Metodos privados nuevos

        protected void btnRegresar_Click(object sender, EventArgs e) { }

        #region SessionInformar
        public static string[] GetData(string data)
        {
            return EncCode.Decode(data.Replace(" ", "+"), "@1B2c3D4e5F6g7H8", "Ingmedical").Split('&', '=');
        }
        #endregion
    }
}
