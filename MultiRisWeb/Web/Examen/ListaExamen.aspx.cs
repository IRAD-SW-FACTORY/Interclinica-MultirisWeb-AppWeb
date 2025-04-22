// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Web.Examen.ListaExamen
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5A45DC1A-20EF-4D43-BF8F-C48627E6FD9C
// Assembly location: D:\Descompilacion8\Multiris\Compilado\bin\MultiRisWeb.dll

using IradDBNet.Dto;
using MultiRisWeb.ConsumirServicios;
using MultiRisWeb.Data.DataAccess;
using MultiRisWeb.Data.Domain;
using MultiRisWeb.Data.Enum;
using MultiRisWeb.Data.Models;
using MultiRisWeb.Data.ResponseEntity;
using MultiRisWeb.Data.Util;
using MultiRisWeb.Data.WSChillan;
using MultiRisWeb.Encrypt.Util;
using MultiRisWeb.ResponseEntity;
using MultiRisWeb.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using RisExamenDomain = MultiRisWeb.Data.Domain.RisExamenDomain;
using RisPrestacionDomain = MultiRisWeb.Data.Domain.RisPrestacionDomain;

namespace MultiRisWeb.Web.Examen
{
    public class ListaExamen : Page
    {
        public static int numero;
        public string paginaActual;
        public string cantidadDeRegistros;
        public string totalRegistros;
        public static int numeroIncremental;
        public static string direccion;
        public static string columna;
        public string idFiltro;
        public int cantidadRegistrosSinFormula;
        public int totalRegistrosSinFormula;
        public static int registroPaginaTotal;
        public static string fechaInicio;
        public static string UsuMultiris;
        public UsuarioDomain usuario;
        public PerfilDomain perfil;
        protected HiddenField returnPage;
        protected HiddenField hddPerfil;
        protected HiddenField hddUser;
        protected HiddenField hddVisualiza;
        protected HiddenField hddName;
        protected HiddenField hddfilter;
        protected HiddenField hddPageInfo;
        protected HiddenField hddTotalRegister;
        protected HiddenField swPagina;
        protected HiddenField rowComentario;
        protected HiddenField selFiltroReturn;
        protected HiddenField timerID;
        protected HiddenField hEliminaPrestacion;
        protected HiddenField hEliminaPrestacionArray;
        protected HiddenField hEliminaPrestacionId;
        protected HiddenField hEliminaPrestacionAccion;
        protected HtmlGenericControl modalMessageBox;
        protected HtmlGenericControl modalInicioPopUpHabil;
        protected HtmlGenericControl modalInicioPopUpNoHabil;
        protected HtmlInputHidden usuarioNombre;
        protected HtmlInputHidden perfilNombre;
        protected HtmlInputHidden comunica;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.Request.UrlReferrer == (Uri)null) this.Response.Redirect("../../Default.aspx");

                ListaExamen.numeroIncremental = Convert.ToInt32(this.Session["numeroIncremental"]);

                if (this.Session["id_usuario"] == null) return;

                ListaExamen.actualizarDesbloqueoExamen();

                this.usuario = UsuarioDataAccess.GetById(Convert.ToInt64(this.Session["id_usuario"].ToString()));
                this.perfil = PerfilDataAccess.GetById(this.usuario.id_perfil);
                this.hddPerfil.Value = this.perfil.id_perfil.ToString();
                this.hddUser.Value = ListaExamen.Encriptar(this.Session["id_usuario"].ToString());
                this.hddVisualiza.Value = ListaExamen.Encriptar(this.perfil.id_perfil_visualizacion.ToString());
                this.hddName.Value = ListaExamen.Encriptar(this.usuario.username);
                this.selFiltroReturn.Value = HttpContext.Current.Session["opfiltro"] == null ? "0" : HttpContext.Current.Session["opfiltro"].ToString();

                this.usuarioNombre.Value = string.Format("{0}", usuario.nombre_completo.Equals("") ? usuario.nombre + " " + usuario.apellido_paterno : usuario.nombre_completo);
                this.perfilNombre.Value = usuario.nombre_perfil;

                if (this.Session["returpage"] == null)
                {
                    this.returnPage.Value = "0";
                    HttpContext.Current.Session["opfiltro"] = (object)null;
                }
                else
                {
                    this.returnPage.Value = "1";
                    this.Session.Remove("returpage");
                    HttpContext.Current.Session["opfiltro"] = (object)null;
                }
            }
            catch (Exception ex)
            {
                this.LogError(ex, nameof(Page_Load));
            }
        }

        [WebMethod]
        public static int RecargaEnvioInforme(int id_ris_examen, string numeroacceso)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            int num = 0;
            try
            {
                RisInformeDomain risInformeDomain = new RisInformeDomain();
                RisInformeDataAccess.GetRecargaEnvioInforme(id_ris_examen, numeroacceso.Trim());
                return num;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                Log.Error(ex, message);
                return 1;
            }
        }

        public void runMetodoJavascript() => this.Request.QueryString["Id"].ToString();

        [WebMethod]
        public static string ObtenerUrlInformar(
          string cod_examen,
          string id_institucion,
          string prestaciones)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            return ListaExamen.encriptarInformar("&codexamen=" + cod_examen + "&idInstitucion=" + id_institucion + "&idprestacion=" + prestaciones);
        }

        [WebMethod]
        public static string ObtenerURLInformarOIT(string cod_examen, string id_institucion, string prestaciones)
		{
            if (HttpContext.Current.Session["id_usuario"] == null) HttpContext.Current.Response.Redirect("../../Default.aspx");
            
			return ListaExamen.encriptarInformarOIT("&codexamen=" + cod_examen + "&idInstitucion=" + id_institucion + "&idprestacion=" + prestaciones);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true)]
        public static ResponseApp GetExamenSolicitudAddendumEdit(long idExamen, int IdSolicitud)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            UsuarioDomain byId1 = UsuarioDataAccess.GetById(Convert.ToInt64(HttpContext.Current.Session["id_usuario"].ToString()));
            RisExamenDomain byId2 = RisExamenDataAccess.GetById(idExamen);
            InstitucionDomain byId3 = InstitucionDataAccess.GetById(byId2.id_institucion);
            SolicitudAddendumInstitucionDomain byId4 = SolicitudAddendumInstitucionAccess.GetById(idExamen, IdSolicitud);
            var data = new
            {
                IdRisExamen = byId4.IdRisExamen,
                FechaIngreso = DateTime.Now.ToString("dd-MM-yyyy HH:mm"),
                Usuario = byId1.nombre + " " + byId1.apellido_paterno,
                Mail = byId1.email1 == null ? "--" : byId1.email1,
                Institucion = byId3.nombre,
                TipoAtencion = byId2.idtipoorden == "A" ? "Ambulatoria" : (byId2.idtipoorden == "U" ? "Urgencia" : "Hospitalizacion"),
                Modalidad = byId2.modalidad,
                FechaExamen = byId2.fechaexamen.ToString("dd-MM-yyyy HH:mm"),
                IdPaciente = byId2.idpaciente,
                Paciente = byId2.nombre,
                Medico = byId2.medicosolicitante,
                TipoSolicitud = byId4.TipoSolicitud,
                Detalle = byId4.Detalle,
                estado = byId4.estado,
                EstadoSolicitudAdedemdum = byId4.EstadoSolicitudAdedemdum,
                Id = byId4.Id,
                NomTipoSolicitud = byId4.NomTipoSolicitud,
                Perfil = byId1.id_perfil,
                Comentario = byId4.Comentario,
                UsuarioInformadorExamen = byId4.UsuarioInformadorExamen,
                UsuarioValidadorExamen = byId4.UsuarioValidadorExamen,
                UsuarioValidadorAddendum = byId4.UsuarioValidadorAddendum
            };
            return new ResponseApp()
            {
                Ejecutado = true,
                Mensaje = string.Empty,
                Data = (object)data
            };
        }

        public static long actualizarDesbloqueoExamen()
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            long num = 0;
            if (HttpContext.Current.Session["codExamen"] != null)
            {
                RisExamenDomain byCodExamen = RisExamenDataAccess.GetByCodExamen(HttpContext.Current.Session["codExamen"].ToString());
                UsuarioDomain byId = UsuarioDataAccess.GetById(Convert.ToInt64(HttpContext.Current.Session["id_usuario"].ToString()));
                if (byCodExamen.id_ris_examen > 0L)
                {
                    byCodExamen.bloqueado = 0;
                    byCodExamen.fecha_bloqueo = DateTime.Now;
                    byCodExamen.id_usuario_bloqueo = Convert.ToInt32(byId.id_usuario);
                    RisExamenDataAccess.Save(byCodExamen);
                    num = byCodExamen.id_ris_examen;
                }
            }
            return num;
        }

        private void EnviarInstruccionMeddreams()
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            MeddreamsUtil meddreamsUtil = new MeddreamsUtil();
        }

        private static string encriptarInformar(string texto)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            ConfiguracionGeneralDomain byId1 = ConfiguracionGeneralDataAccess.GetById(1L);
            ConfiguracionGeneralDomain byId2 = ConfiguracionGeneralDataAccess.GetById(2L);
            return "Informar.aspx?val=" + EncCode.Encode("clave=" + ConfiguracionGeneralDataAccess.GetById(3L).valor1 + texto, byId1.valor1, byId2.valor1);
        }

        private static string encriptarInformarOIT(string texto)
        {
            if (HttpContext.Current.Session["id_usuario"] == null) HttpContext.Current.Response.Redirect("../../Default.aspx");

            ConfiguracionGeneralDomain byId1 = ConfiguracionGeneralDataAccess.GetById(1L);
            ConfiguracionGeneralDomain byId2 = ConfiguracionGeneralDataAccess.GetById(2L);
			
			//return "InformarOIT.aspx?val=" + EncCode.Encode("clave=" + ConfiguracionGeneralDataAccess.GetById(3L).valor1 + texto, byId1.valor1, byId2.valor1);
            return "InformaOIT.aspx?val=" + EncCode.Encode("clave=" + ConfiguracionGeneralDataAccess.GetById(3L).valor1 + texto, byId1.valor1, byId2.valor1);		
        }

        private static string encriptarAddendum(string texto)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            ConfiguracionGeneralDomain byId1 = ConfiguracionGeneralDataAccess.GetById(1L);
            ConfiguracionGeneralDomain byId2 = ConfiguracionGeneralDataAccess.GetById(2L);
            return "Addendum.aspx?val=" + EncCode.Encode("clave=" + ConfiguracionGeneralDataAccess.GetById(3L).valor1 + texto, byId1.valor1, byId2.valor1);
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            try
            {
                GridViewRow row = e.Row;
                if (this.Session["id_perfil"].ToString() == "8")
                {
                    if (e.Row.RowType == DataControlRowType.Header)
                        e.Row.Cells[17].Visible = false;
                    if (e.Row.RowType == DataControlRowType.DataRow)
                        e.Row.Cells[17].Visible = false;
                }
                if (row.Cells[4].Text.Equals("0"))
                    e.Row.BackColor = Color.Red;
                if (!row.Cells[4].Text.Equals("1"))
                    return;
                e.Row.BackColor = Color.Green;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                Log.Error(ex, message);
            }
        }

        public static string Imagenes(long id_ris_examen, string numeroacceso, long idperfil)
        {
            if (HttpContext.Current.Session["id_usuario"] == null) HttpContext.Current.Response.Redirect("../../Default.aspx");

            string str = string.Empty;
            
            RisExamenDomain byIdAndAcc = RisExamenDataAccess.GetByIdAndAcc(id_ris_examen, numeroacceso);
            MeddreamsUtil meddreamsUtil = new MeddreamsUtil();
            InstitucionDomain byId = InstitucionDataAccess.GetById(Convert.ToInt32(byIdAndAcc.id_institucion));
            
            if (byIdAndAcc.id_ris_examen > 0L && !idperfil.Equals(8)) str = meddreamsUtil.generarStringVisoresSinImportar(byIdAndAcc.codexamen, byId.id_institucion, true);
            
            return str;
        }

        public static string PrestacionesResumido(long id_ris_examen, string numeroacceso)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            RisExamenDomain byIdAndAcc = RisExamenDataAccess.GetByIdAndAcc(id_ris_examen, numeroacceso);
            InstitucionDomain byId = InstitucionDataAccess.GetById(byIdAndAcc.id_institucion);
            IList<RisPrestacionDomain> prestacionDomainList = RisPrestacionDataAccess.PrestacionesInformar(byIdAndAcc.usernameRadiologo, byId.id_institucion, byIdAndAcc.id_ris_examen, byIdAndAcc.codexamen, numeroacceso);
            string str1 = "<table style='margin-top: 20px;' class=\"tablaPrestaciones\" id=\"tablaPrestaciones\"><tr><td><b class='texto1'><label>LISTADO DE PRESTACIONES</label></b></td></tr>";
            string str2;
            if (prestacionDomainList.Count > 0)
            {
                foreach (RisPrestacionDomain prestacionDomain in (IEnumerable<RisPrestacionDomain>)prestacionDomainList)
                {
                    str1 += "<tr>";
                    str1 += "<td>";
                    str1 = str1 + "<input type=\"checkbox\" id=\"" + prestacionDomain.id_prestacion.ToString() + "\" value=\"" + prestacionDomain.id_prestacion.ToString() + "\" text=\"" + prestacionDomain.nombre + "\" class=\"chkprestacionclass\" checked/><label class=\"nombre_prestacion\">" + prestacionDomain.nombre + "</label>";
                    str1 += "</td>";
                    str1 += "</tr>";
                }
                str2 = str1 + "<tr><td><input href='#' id='aInformar' class='btn btn-primary btn-informar2' value='Informar' style='margin-left:5px; cursor:pointer; padding-top: 3px;' onclick='informar(\"" + byIdAndAcc.codexamen + "\", " + byId.id_institucion.ToString() + ");' /></td></tr>";
            }
            else
                str2 = str1 + "<tr><td>Sin Prestaciones</td></tr>";
            return str2 + "</table> ";
        }

        public static string InformesResumido(long id_ris_examen, string numeroacceso)
        {
            if (HttpContext.Current.Session["id_usuario"] == null) HttpContext.Current.Response.Redirect("../../Default.aspx");

            var usuario = UsuarioDataAccess.GetById(Convert.ToInt64(HttpContext.Current.Session["id_usuario"].ToString()));

            ArrayList arrayList = new ArrayList();
            RisExamenDomain byIdAndAcc = RisExamenDataAccess.GetByIdAndAcc(id_ris_examen, numeroacceso);
            InstitucionDomain byId1 = InstitucionDataAccess.GetById(byIdAndAcc.id_institucion);
            IList<RisInformeDomain> examenNoValidado = RisInformeDataAccess.GetByCodExamenNoValidado(byIdAndAcc.codexamen, 3, numeroacceso, byId1.id_institucion);
            IList<RisInformeDomain> codExamenValidado = RisInformeDataAccess.GetByCodExamenValidado(byIdAndAcc.codexamen, 3, numeroacceso, byId1.id_institucion);
            RisEstadoExamenDomain estadoExamenDomain = new RisEstadoExamenDomain();

            string str1 = "<b class='texto1'><label>LISTADO DE INFORMES</label></b><table class=\"tablaInformes\" style=\"width: 100% !important;\" id=\"tablaInformes\">";
            string str2;

            if (examenNoValidado.Count > 0 || codExamenValidado.Count > 0)
            {
                str2 = str1 + "<tr><th style=\"width: 40%\"><label>Informe</label></th><th style=\"width: 20%\"><label>Acciones</label></th><th style=\"width: 20%\"><label>Estado</label></th><th style=\"width: 20%\"><label>Radiologo</label></th>";

                if (codExamenValidado.Count > 0 && byIdAndAcc.id_estado_examen.Equals(3))
                    str2 += "<th style=\"width: 5%\"><label>Reenviar</label></th></tr>";

                foreach (RisInformeDomain risInformeDomain in (IEnumerable<RisInformeDomain>)codExamenValidado)
                {
                    RisEstadoExamenDomain byId2 = RisEstadoExamenDataAccess.GetById(risInformeDomain.id_estado_informe);
                    long num1;
                    int num2;

                    switch (risInformeDomain.id_tipo_informe)
                    {
                        case 1:
                            str2 += "<tr>";
                            str2 += "<td>";
                            str2 += "<div class='row'>";

                            string[] strArray1 = new string[8];

                            strArray1[0] = str2;
                            strArray1[1] = "<a title=\"Ver Informe\"href='VerInforme.aspx?idinforme=";

                            num1 = risInformeDomain.id_ris_informe;
                            strArray1[2] = num1.ToString();
                            strArray1[3] = "&aetitle=";
                            strArray1[4] = byId1.aetitle;
                            strArray1[5] = "' style=\"color: white;\" target='_blank' ><img src='../icon/pdf.png' style='width: 14px'/>";
                            strArray1[6] = ListaExamen.eliminarHtml(risInformeDomain.descripcion);
                            strArray1[7] = "</a>";
                            str2 = string.Concat(strArray1);
                            str2 += "</div></td>";
                            str2 += "<td>";

                            num2 = risInformeDomain.id_estado_informe;

                            if (!num2.Equals(3))
                            {
                                string str3 = str2;
                                string[] strArray2 = new string[6];

                                strArray2[0] = "&id_informe=";
                                num1 = risInformeDomain.id_ris_informe;
                                strArray2[1] = num1.ToString();
                                strArray2[2] = "&codexamen=";
                                strArray2[3] = risInformeDomain.codExamen;
                                strArray2[4] = "&idInstitucion=";

                                string[] strArray3 = strArray2;

                                num2 = byId1.id_institucion;
                                strArray3[5] = num2.ToString();

                                string str4 = ListaExamen.encriptarInformar(string.Concat(strArray3));
                                str2 = str3 + "<a href=\"" + str4 + "\" style=\"color: white;\" title='Solicitar Corrección'><img src='../icon/corregir.png' style='width: 14px'/></a>";
                            }

                            if (byId1.addendum == 1)
                            {
                                RisAddendumDomain risAddendumDomain = RisAddendumDataAccess.GetlatestByActive(risInformeDomain.id_ris_informe);
                                string str5 = "";

                                if (risAddendumDomain.id_addendum > 0L)
                                    str5 = "Crear Addendum.";
                                else if (risAddendumDomain.id_addendum == 0L)
                                    str5 = "Crear Addendum.";

                                string[] strArray4 = new string[6] { str2, "<a href=\"", null, null, null, null };

                                string[] strArray5 = new string[8];

                                strArray5[0] = "&id_addendum=";
                                num1 = risAddendumDomain.id_addendum;
                                strArray5[1] = num1.ToString();
                                strArray5[2] = "&id_informe=";
                                num1 = risInformeDomain.id_ris_informe;
                                strArray5[3] = num1.ToString();
                                strArray5[4] = "&cod_examen=";
                                strArray5[5] = risInformeDomain.codExamen;
                                strArray5[6] = "&id_institucion=";

                                string[] strArray6 = strArray5;

                                num2 = byId1.id_institucion;
                                strArray6[7] = num2.ToString();
                                strArray4[2] = ListaExamen.encriptarAddendum(string.Concat(strArray6));
                                strArray4[3] = "\" style=\"color: white;\" title='";
                                strArray4[4] = str5;
                                strArray4[5] = "'><img id='imgAddendum' src='../icon/corregir.png' style='width: 14px'/></a>";
                                str2 = string.Concat(strArray4);
                            }

                            str2 += "</td>";
                            break;
                        case 2:
                            DateTime now = DateTime.Now;
                            DateTime fechaValidacion = risInformeDomain.fecha_validacion;

                            str2 += "<tr>";
                            str2 += "<td><div class='row'>";

                            string[] strArray7 = new string[8];

                            strArray7[0] = str2;
                            strArray7[1] = "<a title=\"Ver Informe\"href='VerInforme.aspx?idinforme=";
                            num1 = risInformeDomain.id_ris_informe;
                            strArray7[2] = num1.ToString();
                            strArray7[3] = "&aetitle=";
                            strArray7[4] = byId1.aetitle;
                            strArray7[5] = "' style=\"color: white;\" target='_blank' ><img src='../icon/pdf.png' style='width: 14px'/>";
                            strArray7[6] = ListaExamen.eliminarHtml(risInformeDomain.descripcion);
                            strArray7[7] = "</a>";
                            str2 = string.Concat(strArray7);
                            str2 += "</div></td>";
                            str2 += "<td>";
                            num2 = risInformeDomain.id_estado_informe;

                            if (!num2.Equals(3))
                            {
                                string str6 = str2;
                                string[] strArray8 = new string[6];

                                strArray8[0] = "&id_informe=";
                                num1 = risInformeDomain.id_ris_informe;
                                strArray8[1] = num1.ToString();
                                strArray8[2] = "&codexamen=";
                                strArray8[3] = risInformeDomain.codExamen;
                                strArray8[4] = "&idInstitucion=";

                                string[] strArray9 = strArray8;

                                num2 = byId1.id_institucion;
                                strArray9[5] = num2.ToString();

                                string str7 = ListaExamen.encriptarInformarOIT(string.Concat(strArray9));

                                str2 = str6 + "<a href=\"" + str7 + "\" style=\"color: white;\" title='Solicitar Corrección'><img src='../icon/corregir.png' style='width: 14px'/></a>";
                            }

                            if (byId1.addendum == 1)
                            {
                                RisAddendumDomain risAddendumDomain = RisAddendumDataAccess.GetlatestByActive(risInformeDomain.id_ris_informe);

                                bool flag = false;
                                int num3 = RisAddendumDataAccess.NuevasSolProcesadas(id_ris_examen);
                                string usernameRadiologo = risInformeDomain.username_radiologo;

                                if (risInformeDomain.username_radiologo.Equals(usuario.username) && num3 > 0) flag = true;
                                else if (usuario.id_perfil.Equals(6) && num3 > 0) flag = true;

                                if (!flag)
                                {
                                    string str8 = "No puede Crear Addendum.";
                                    str2 = str2 + "<a title='" + str8 + "'><img id='imgAddendum-no' src='../icon/corregir-no.png' style='width: 14px'/></a>";
                                }
                                else if (risAddendumDomain.id_addendum > 0L)
                                {
                                    string str9 = "Crear Addendum.";
                                    string[] strArray10 = new string[6] { str2, "<a href=\"", null, null, null, null };

                                    string[] strArray11 = new string[8];
                                    strArray11[0] = "&id_addendum=";
                                    num1 = risAddendumDomain.id_addendum;
                                    strArray11[1] = num1.ToString();
                                    strArray11[2] = "&id_informe=";
                                    num1 = risInformeDomain.id_ris_informe;
                                    strArray11[3] = num1.ToString();
                                    strArray11[4] = "&cod_examen=";
                                    strArray11[5] = risInformeDomain.codExamen;
                                    strArray11[6] = "&id_institucion=";

                                    string[] strArray12 = strArray11;
                                    num2 = byId1.id_institucion;
                                    strArray12[7] = num2.ToString();
                                    strArray10[2] = ListaExamen.encriptarAddendum(string.Concat(strArray12));
                                    strArray10[3] = "\" style=\"color: white;\" title='";
                                    strArray10[4] = str9;
                                    strArray10[5] = "'><img id='imgAddendum' src='../icon/corregir.png' style='width: 14px'/></a>";
                                    str2 = string.Concat(strArray10);
                                }
                                else if (risAddendumDomain.id_addendum == 0L)
                                {
                                    string str10 = "Crear Addendum.";
                                    string[] strArray13 = new string[6] { str2, "<a href=\"", null, null, null, null };
                                    string[] strArray14 = new string[8];

                                    strArray14[0] = "&id_addendum=";
                                    num1 = risAddendumDomain.id_addendum;
                                    strArray14[1] = num1.ToString();
                                    strArray14[2] = "&id_informe=";
                                    num1 = risInformeDomain.id_ris_informe;
                                    strArray14[3] = num1.ToString();
                                    strArray14[4] = "&cod_examen=";
                                    strArray14[5] = risInformeDomain.codExamen;
                                    strArray14[6] = "&id_institucion=";

                                    string[] strArray15 = strArray14;
                                    num2 = byId1.id_institucion;
                                    strArray15[7] = num2.ToString();
                                    strArray13[2] = ListaExamen.encriptarAddendum(string.Concat(strArray15));
                                    strArray13[3] = "\" style=\"color: white;\" title='";
                                    strArray13[4] = str10;
                                    strArray13[5] = "'><img id='imgAddendum' src='../icon/corregir.png' style='width: 14px'/></a>";
                                    str2 = string.Concat(strArray13);
                                }
                            }

                            str2 += "</td>";
                            break;
                        case 3:
                            str2 += "<tr>";
                            str2 += "<td><div class='row'>";
                            string[] strArray16 = new string[6] { str2, "<a title=\"Ver Informe OIT\"href='", null, null, null, null };
                            string str11 = byId1.url_informe_oit.Replace("#CODEXAMEN#", ListaExamen.Encriptar(byIdAndAcc.codexamen));
                            num1 = risInformeDomain.id_informe_remoto;
                            string newValue1 = num1.ToString();
                            string str12 = str11.Replace("#IDINFORME#", newValue1);
                            num1 = risInformeDomain.id_informe_remoto;
                            string newValue2 = num1.ToString();
                            strArray16[2] = str12.Replace("#IDINFORME#", newValue2);
                            strArray16[3] = "' style=\"color: white;\" target='_blank' ><img src='../icon/pdf.png' style='width: 14px'/>";
                            strArray16[4] = ListaExamen.eliminarHtml(risInformeDomain.descripcion);
                            strArray16[5] = "</a>";
                            str2 = string.Concat(strArray16);
                            str2 += "</div></td>";
                            str2 += "<td>";
                            num2 = risInformeDomain.id_estado_informe;

                            if (!num2.Equals(3))
                            {
                                string str13 = str2;
                                string[] strArray17 = new string[6];
                                strArray17[0] = "&id_informe=";
                                num1 = risInformeDomain.id_ris_informe;
                                strArray17[1] = num1.ToString();
                                strArray17[2] = "&codexamen=";
                                strArray17[3] = risInformeDomain.codExamen;
                                strArray17[4] = "&idInstitucion=";
                                string[] strArray18 = strArray17;
                                num2 = byId1.id_institucion;
                                strArray18[5] = num2.ToString();
                                string str14 = ListaExamen.encriptarInformarOIT(string.Concat(strArray18));
                                str2 = str13 + "<a href=\"" + str14 + "\" style=\"color: white;\" title='Solicitar Corrección'><img src='../icon/corregir.png' style='width: 14px'/></a>";
                            }
                            str2 += "</td>";
                            break;
                        default:
                            str2 += "<tr>";
                            str2 += "<td>";
                            string[] strArray19 = new string[6] { str2, "<a title=\"Ver Informe\"href='", null, null, null, null };
                            string str15 = byId1.url_informe.Replace("#CODEXAMEN#", byIdAndAcc.codexamen);
                            num1 = risInformeDomain.id_informe_remoto;
                            string newValue3 = num1.ToString();
                            string str16 = str15.Replace("#IDINFORME#", newValue3);
                            num1 = risInformeDomain.id_informe_remoto;
                            string newValue4 = num1.ToString();
                            strArray19[2] = str16.Replace("#IDINFORME#", newValue4);
                            strArray19[3] = "' style=\"color: white;\" target='_blank' ><img src='../icon/pdf.png' style='width: 14px'/>";
                            strArray19[4] = ListaExamen.eliminarHtml(risInformeDomain.descripcion);
                            strArray19[5] = "</a>";
                            str2 = string.Concat(strArray19);
                            str2 += "</td>";
                            str2 += "<td>";
                            num2 = risInformeDomain.id_estado_informe;

                            if (!num2.Equals(3))
                            {
                                string str17 = str2;
                                string[] strArray20 = new string[6];
                                strArray20[0] = "&id_informe=";
                                num1 = risInformeDomain.id_ris_informe;
                                strArray20[1] = num1.ToString();
                                strArray20[2] = "&codexamen=";
                                strArray20[3] = risInformeDomain.codExamen;
                                strArray20[4] = "&idInstitucion=";
                                string[] strArray21 = strArray20;
                                num2 = byId1.id_institucion;
                                strArray21[5] = num2.ToString();
                                string str18 = ListaExamen.encriptarInformar(string.Concat(strArray21));
                                str2 = str17 + "<a href=\"" + str18 + "\" style=\"color: white;\" title='Solicitar Corrección'><img src='../icon/corregir.png' style='width: 14px'/></a>";
                            }
                            if (byId1.addendum == 1)
                            {
                                RisAddendumDomain risAddendumDomain = RisAddendumDataAccess.GetlatestByActive(risInformeDomain.id_ris_informe);
                                string str19 = "";
                                if (risAddendumDomain.id_addendum > 0L)
                                    str19 = "Crear Addendum.";
                                else if (risAddendumDomain.id_addendum == 0L)
                                    str19 = "Crear Addendum.";
                                string[] strArray22 = new string[6] { str2, "<a href=\"", null, null, null, null };
                                string[] strArray23 = new string[8];
                                strArray23[0] = "&id_addendum=";
                                num1 = risAddendumDomain.id_addendum;
                                strArray23[1] = num1.ToString();
                                strArray23[2] = "&id_informe=";
                                num1 = risInformeDomain.id_ris_informe;
                                strArray23[3] = num1.ToString();
                                strArray23[4] = "&cod_examen=";
                                strArray23[5] = risInformeDomain.codExamen;
                                strArray23[6] = "&id_institucion=";
                                string[] strArray24 = strArray23;
                                num2 = byId1.id_institucion;
                                strArray24[7] = num2.ToString();
                                strArray22[2] = ListaExamen.encriptarAddendum(string.Concat(strArray24));
                                strArray22[3] = "\" style=\"color: white;\" title='";
                                strArray22[4] = str19;
                                strArray22[5] = "'><img id='imgAddendum' src='../icon/corregir.png' style='width: 14px'/></a>";
                                str2 = string.Concat(strArray22);
                            }
                            str2 += "</td>";
                            break;
                    }
                    str2 += "<td>";
                    str2 = str2 + "<label>" + byId2.nombre + "</label>";
                    str2 += "</td>";
                    str2 += "<td>";
                    str2 = str2 + "<label>" + byIdAndAcc.usuarioValidadorExamen + "</label>";                   
                    str2 += "</td>";
                    if (byIdAndAcc.id_estado_examen.Equals(3))
                    {
                        str2 += "<td>";
                        string[] strArray25 = new string[6] {
                            str2,
                            "<img src='../icon/recargar.png' style = 'width: 20px; cursor: pointer' id = 'btnRecargarEstudiosAnteriores' title = 'Reenvio de Informe.' onclick='RecargaEnvioInforme(",
                            null,
                            null,
                            null,
                            null
                        };

                        num1 = byIdAndAcc.id_ris_examen;
                        strArray25[2] = num1.ToString();
                        strArray25[3] = ", &#34 ";
                        strArray25[4] = byIdAndAcc.numeroacceso;
                        strArray25[5] = " &#34); return false;' />";
                        str2 = string.Concat(strArray25);
                        str2 += "<div id='divEstudiosRelacionados'></div>";
                        str2 += "</td>";
                    }
                    str2 += "</tr>";
                }

                foreach (RisInformeDomain risInformeDomain in (IEnumerable<RisInformeDomain>)examenNoValidado)
                {
                    RisEstadoExamenDomain byId3 = RisEstadoExamenDataAccess.GetById(risInformeDomain.id_estado_informe);
                    switch (risInformeDomain.id_tipo_informe)
                    {
                        case 1:
                            str2 += "<tr>";
                            str2 += "<td>";
                            string[] strArray26 = new string[6] { str2, "<a style=\"color: white;\" href=\"", null, null, null, null };
                            string[] strArray27 = new string[6];
                            strArray27[0] = "&id_informe=";
                            long idRisInforme1 = risInformeDomain.id_ris_informe;
                            strArray27[1] = idRisInforme1.ToString();
                            strArray27[2] = "&codexamen=";
                            strArray27[3] = risInformeDomain.codExamen;
                            strArray27[4] = "&idInstitucion=";
                            strArray27[5] = byId1.id_institucion.ToString();
                            strArray26[2] = ListaExamen.encriptarInformar(string.Concat(strArray27));
                            strArray26[3] = "\">";
                            strArray26[4] = risInformeDomain.descripcion;
                            strArray26[5] = "</a>";
                            str2 = string.Concat(strArray26);
                            str2 += "</td>";
                            str2 += "<td>";
                            string str20 = str2;
                            string[] strArray28 = new string[6];
                            strArray28[0] = "&id_informe=";
                            long idRisInforme2 = risInformeDomain.id_ris_informe;
                            strArray28[1] = idRisInforme2.ToString();
                            strArray28[2] = "&codexamen=";
                            strArray28[3] = risInformeDomain.codExamen;
                            strArray28[4] = "&idInstitucion=";
                            strArray28[5] = byId1.id_institucion.ToString();
                            string str21 = ListaExamen.encriptarInformar(string.Concat(strArray28));
                            str2 = str20 + "<a href=\"" + str21 + "\" style=\"color: white;\" title='Continuar Informando'><img src='../icon/corregir.png' style='width: 14px'/></a>";
                            str2 += "</td>";
                            break;
                        case 2:
                            str2 += "<tr>";
                            str2 += "<td>";

                            string[] strArray29 = new string[6] { str2, "<a style=\"color: white;\" href=\"", null, null, null, null };
                            string[] strArray30 = new string[6];
                            strArray30[0] = "&id_informe=";
                            long idRisInforme3 = risInformeDomain.id_ris_informe;
                            strArray30[1] = idRisInforme3.ToString();
                            strArray30[2] = "&codexamen=";
                            strArray30[3] = risInformeDomain.codExamen;
                            strArray30[4] = "&idInstitucion=";
                            strArray30[5] = byId1.id_institucion.ToString();
                            strArray29[2] = ListaExamen.encriptarInformar(string.Concat(strArray30));
                            strArray29[3] = "\">";
                            strArray29[4] = risInformeDomain.descripcion;
                            strArray29[5] = "</a>";
                            str2 = string.Concat(strArray29);
                            str2 += "</td>";
                            str2 += "<td>";
                            string str22 = str2;
                            string[] strArray31 = new string[6];
                            strArray31[0] = "&id_informe=";
                            long idRisInforme4 = risInformeDomain.id_ris_informe;
                            strArray31[1] = idRisInforme4.ToString();
                            strArray31[2] = "&codexamen=";
                            strArray31[3] = risInformeDomain.codExamen;
                            strArray31[4] = "&idInstitucion=";
                            strArray31[5] = byId1.id_institucion.ToString();
                            string str23 = ListaExamen.encriptarInformar(string.Concat(strArray31));
                            str2 = str22 + "<a href=\"" + str23 + "\" style=\"color: white;\" title='Continuar Informando'><img src='../icon/corregir.png' style='width: 14px'/></a>";
                            str2 += "</td>";
                            break;
                        case 3:
                            str2 += "<tr>";
                            str2 += "<td>";
                            string[] strArray32 = new string[6] { str2, "<a style=\"color: white;\" href=\"", null, null, null, null };
                            string[] strArray33 = new string[6];
                            strArray33[0] = "&id_informe=";
                            long idRisInforme5 = risInformeDomain.id_ris_informe;
                            strArray33[1] = idRisInforme5.ToString();
                            strArray33[2] = "&codexamen=";
                            strArray33[3] = risInformeDomain.codExamen;
                            strArray33[4] = "&idInstitucion=";
                            strArray33[5] = byId1.id_institucion.ToString();
                            strArray32[2] = ListaExamen.encriptarInformarOIT(string.Concat(strArray33));
                            strArray32[3] = "\">";
                            strArray32[4] = risInformeDomain.descripcion;
                            strArray32[5] = "</a>";
                            str2 = string.Concat(strArray32);
                            str2 += "</td>";
                            str2 += "<td>";
                            string str24 = str2;
                            string[] strArray34 = new string[6];
                            strArray34[0] = "&id_informe=";
                            long idRisInforme6 = risInformeDomain.id_ris_informe;
                            strArray34[1] = idRisInforme6.ToString();
                            strArray34[2] = "&codexamen=";
                            strArray34[3] = risInformeDomain.codExamen;
                            strArray34[4] = "&idInstitucion=";
                            strArray34[5] = byId1.id_institucion.ToString();
                            string str25 = ListaExamen.encriptarInformarOIT(string.Concat(strArray34));
                            str2 = str24 + "<a href=\"" + str25 + "\" style=\"color: white;\" title='Continuar Informando'><img src='../icon/corregir.png' style='width: 14px'/></a>";
                            str2 += "</td>";
                            break;
                        default:
                            str2 += "<tr>";
                            str2 += "<td>";
                            string[] strArray35 = new string[6] { str2, "<a style=\"color: white;\" href=\"", null, null, null, null };
                            string[] strArray36 = new string[6];
                            strArray36[0] = "&id_informe=";
                            long idRisInforme7 = risInformeDomain.id_ris_informe;
                            strArray36[1] = idRisInforme7.ToString();
                            strArray36[2] = "&codexamen=";
                            strArray36[3] = risInformeDomain.codExamen;
                            strArray36[4] = "&idInstitucion=";
                            strArray36[5] = byId1.id_institucion.ToString();
                            strArray35[2] = ListaExamen.encriptarInformar(string.Concat(strArray36));
                            strArray35[3] = "\">";
                            strArray35[4] = risInformeDomain.descripcion;
                            strArray35[5] = "</a>";
                            str2 = string.Concat(strArray35);
                            str2 += "</td>";
                            str2 += "<td>";
                            string str26 = str2;
                            string[] strArray37 = new string[6];
                            strArray37[0] = "&id_informe=";
                            long idRisInforme8 = risInformeDomain.id_ris_informe;
                            strArray37[1] = idRisInforme8.ToString();
                            strArray37[2] = "&codexamen=";
                            strArray37[3] = risInformeDomain.codExamen;
                            strArray37[4] = "&idInstitucion=";
                            strArray37[5] = byId1.id_institucion.ToString();
                            string str27 = ListaExamen.encriptarInformar(string.Concat(strArray37));
                            str2 = str26 + "<a href=\"" + str27 + "\" style=\"color: white;\" title='Continuar Informando'><img src='../icon/corregir.png' style='width: 14px'/></a>";
                            str2 += "</td>";
                            break;
                    }
                    str2 += "<td>";
                    str2 = str2 + "<label>" + byId3.nombre + "</label>";
                    str2 += "</td>";
                    str2 += "<td>";
                    str2 = str2 + "<label>" + byIdAndAcc.usuarioValidadorExamen + "</label>";                    
                    str2 += "</td>";
                    str2 += "</tr>";
                }
            }
            else str2 = str1 + "<tr><td>Sin Informes</td></tr>";

            return str2 + "</table>";
        }

        private void limpiarSeleccionDias(int cantidad)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            DateTime now = DateTime.Now;
            this.Session["direction"] = (object)"2";
        }

        public static string eliminarHtml(string texto)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            texto = texto.Replace("<p>", "");
            texto = texto.Replace("</p>", "");
            return texto;
        }

        [WebMethod(EnableSession = true)]
        [HttpPost]
        public static ResponseApp InsertarSolicitudAdeendum(long idExamen, string detalle, int tipoSolicitud, string adjunto)
        {
            if (HttpContext.Current.Session["id_usuario"] == null) HttpContext.Current.Response.Redirect("../../Default.aspx");

            UsuarioDomain byId1 = UsuarioDataAccess.GetById(Convert.ToInt64(HttpContext.Current.Session["id_usuario"].ToString()));
            RisExamenDomain byId2 = RisExamenDataAccess.GetById(idExamen);
            SolicitudAddendumInstitucionDomain solicitud = new SolicitudAddendumInstitucionDomain()
            {
                Usuario = byId1.username,
                UsuarioMail = byId1.email1,
                UsuarioInstitucion = byId2.id_institucion,
                IdRisExamen = byId2.id_ris_examen,
                Detalle = detalle,
                TipoSolicitud = tipoSolicitud,
                Adjunto = adjunto
            };

            bool flag = SolicitudAddendumInstitucionAccess.Insertar(solicitud);

            ListaExamen.EnviaCorreoCreacionSolAdd(solicitud.Usuario, solicitud.UsuarioInstitucion, solicitud.UsuarioMail, solicitud.IdRisExamen, solicitud.Detalle, solicitud.TipoSolicitud);

            return new ResponseApp()
            {
                Ejecutado = flag,
                Mensaje = flag ? "Se ha creado una solicitud de evaluación del examen correctamente" : "No se realizo la creacion de evaluacion del examen correctamente, favor intentar nuevamente",
                Data = (object)null
            };
        }

        [WebMethod(EnableSession = true)]
        [HttpGet]
        public static ResponseApp ListarSolicitudAdeendum(int idEstado, int idInstitucion, int idUsuarioValidador)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            UsuarioDomain byId = UsuarioDataAccess.GetById(Convert.ToInt64(HttpContext.Current.Session["id_usuario"]));
            List<SolicitudAddendumInstitucionDomain> source = SolicitudAddendumInstitucionAccess.ListarSolicitudAdd(idInstitucion, idEstado, byId.id_perfil, byId.username, idUsuarioValidador);
            return new ResponseApp()
            {
                Ejecutado = source.Any<SolicitudAddendumInstitucionDomain>(),
                Mensaje = source.Any<SolicitudAddendumInstitucionDomain>() ? "" : "No se encontraron resultados segun los parametros de busqueda ingresados",
                Data = (object)source
            };
        }

        [WebMethod(EnableSession = true)]
        [HttpGet]
        public static ResponseApp GetSolicitudAddendum(int id)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            SolicitudAddendumInstitucionDomain institucionDomain = SolicitudAddendumInstitucionAccess.Detalle(id);
            return new ResponseApp()
            {
                Ejecutado = true,
                Mensaje = "",
                Data = (object)institucionDomain
            };
        }

        [WebMethod(EnableSession = true)]
        [HttpPost]
        public static ResponseApp UpdateSolicitudAdeendum(int id, int idEstado, string sComentario)
        {
            if (HttpContext.Current.Session["id_usuario"] == null) HttpContext.Current.Response.Redirect("../../Default.aspx");

            bool flag = SolicitudAddendumInstitucionAccess.Update(id, idEstado, sComentario);

            try
            {
                if (idEstado == 4) ListaExamen.EnviaCorreoRechazo(id);
                if (idEstado == 2) ListaExamen.EnviaCorreoProcesoAddendum(id);

                return new ResponseApp()
                {
                    Ejecutado = flag,
                    Mensaje = flag ? "" : "No se modifico solicitud Addendum en el sistema",
                    Data = (object)null
                };
            }
            catch (Exception e)
            {
                return new ResponseApp()
                {
                    Ejecutado = flag,
                    Mensaje = flag ? "Grabacion correcta, problemas al enviar email" : e.Message.ToString(),
                    Data = (object)null
                };
            }
        }

        [WebMethod(EnableSession = true)]
        [HttpGet]
        public static ResponseApp ListarSolicitudAdeendumTodos()
        {
            if (HttpContext.Current.Session["id_usuario"] == null) HttpContext.Current.Response.Redirect("../../Default.aspx");

            UsuarioDomain byId = UsuarioDataAccess.GetById(Convert.ToInt64(HttpContext.Current.Session["id_usuario"]));
            List<SolicitudAddendumInstitucionDomain> source = SolicitudAddendumInstitucionAccess.ListarSolicitudAdd(0, 1, byId.id_perfil, byId.username,0);

            return new ResponseApp()
            {
                Ejecutado = source.Any<SolicitudAddendumInstitucionDomain>(),
                Mensaje = source.Any<SolicitudAddendumInstitucionDomain>() ? "" : "No se encontraron resultados segun los parametros de busqueda ingresados",
                Data = (object)source
            };
        }

        [WebMethod(EnableSession = true)]
        [HttpGet]
        public static ResponseApp InformesResumido2(long idExamen)
        {
            if (HttpContext.Current.Session["id_usuario"] == null) HttpContext.Current.Response.Redirect("../../Default.aspx");

            var usuario = UsuarioDataAccess.GetById(Convert.ToInt64(HttpContext.Current.Session["id_usuario"].ToString()));

            ArrayList arrayList = new ArrayList();
            RisEstadoExamenDomain estadoExamenDomain = new RisEstadoExamenDomain();
            RisExamenDomain byIdAndAcc2 = RisExamenDataAccess.GetByIdAndAcc2(idExamen);
            InstitucionDomain byId1 = InstitucionDataAccess.GetById(byIdAndAcc2.id_institucion);
            IList<RisInformeDomain> codExamenValidado2 = RisInformeDataAccess.GetByCodExamenValidado2(byIdAndAcc2.codexamen, 3, byId1.id_institucion);

            string str1 = string.Empty + "<div class='col-12'>";

            foreach (RisInformeDomain risInformeDomain in (IEnumerable<RisInformeDomain>)codExamenValidado2)
            {
                RisEstadoExamenDomain byId2 = RisEstadoExamenDataAccess.GetById(risInformeDomain.id_estado_informe);
                int num1 = risInformeDomain.id_tipo_informe;
                long num2;
                int num3;

                switch (num1)
                {
                    case 1:
                        str1 += "<div class='row'>";
                        str1 += "<div class='col-sm-1'>";
                        string[] strArray1 = new string[8];
                        strArray1[0] = str1;
                        strArray1[1] = "<a title='Ver Informe' href='VerInforme.aspx?idinforme=";
                        num2 = risInformeDomain.id_ris_informe;
                        strArray1[2] = num2.ToString();
                        strArray1[3] = "&aetitle=";
                        strArray1[4] = byId1.aetitle;
                        strArray1[5] = "' style='color: white; font-size:11px' target ='_blank' >&nbsp<img src='../icon/pdf.png' style='width:20px'/>";
                        strArray1[6] = ListaExamen.eliminarHtml(risInformeDomain.descripcion);
                        strArray1[7] = "</a>";
                        str1 = string.Concat(strArray1);
                        str1 += "</div>";
                        str1 += "<div class='col-sm-5'>";
                        num3 = risInformeDomain.id_estado_informe;

                        if (!num3.Equals(3))
                        {
                            string str2 = str1;
                            string[] strArray2 = new string[6];
                            strArray2[0] = "&id_informe=";
                            num2 = risInformeDomain.id_ris_informe;
                            strArray2[1] = num2.ToString();
                            strArray2[2] = "&codexamen=";
                            strArray2[3] = risInformeDomain.codExamen;
                            strArray2[4] = "&idInstitucion=";
                            num3 = byId1.id_institucion;
                            strArray2[5] = num3.ToString();
                            string str3 = ListaExamen.encriptarInformar(string.Concat(strArray2));
                            str1 = str2 + "<a href='" + str3 + "' style='color: white;font-size:11px' title='Solicitar Corrección'>&nbsp;&nbsp;<img src='../icon/corregir.png' style='width: 15px'/></a>";
                        }

                        num3 = byId1.addendum;

                        if (num3.Equals(1))
                        {
                            RisAddendumDomain risAddendumDomain = RisAddendumDataAccess.GetlatestByActive(risInformeDomain.id_ris_informe);
                            string str4 = "";

                            if (risAddendumDomain.id_addendum > 0L) str4 = "Crear Addendum.";
                            else if (risAddendumDomain.id_addendum == 0L) str4 = "Crear Addendum.";

                            string[] strArray3 = new string[6] { str1, "<a href=\"", null, null, null, null };
                            string[] strArray4 = new string[8];
                            strArray4[0] = "&id_addendum=";
                            num2 = risAddendumDomain.id_addendum;
                            strArray4[1] = num2.ToString();
                            strArray4[2] = "&id_informe=";
                            num2 = risInformeDomain.id_ris_informe;
                            strArray4[3] = num2.ToString();
                            strArray4[4] = "&cod_examen=";
                            strArray4[5] = risInformeDomain.codExamen;
                            strArray4[6] = "&id_institucion=";
                            num3 = byId1.id_institucion;
                            strArray4[7] = num3.ToString();
                            strArray3[2] = ListaExamen.encriptarAddendum(string.Concat(strArray4));
                            strArray3[3] = "\" style=\"color: white;font-size:11px\" title='";
                            strArray3[4] = str4;
                            strArray3[5] = "'>&nbsp;&nbsp;<img id='imgAddendum' src='../icon/corregir.png' style='width: 15px'/></a>";
                            str1 = string.Concat(strArray3);
                        }

                        str1 += "</div>";
                        break;
                    case 2:
                        DateTime now = DateTime.Now;
                        DateTime fechaValidacion = risInformeDomain.fecha_validacion;
                        str1 += "<div class='row'>";
                        str1 += "<div class='col-sm-1'>";
                        str1 += string.Format("<a title='Ver Informe' href='VerInforme.aspx?idinforme={0}&aetitle={1}' target='_blank' >&nbsp;&nbsp; <img src='../icon/pdf.png' style='width: 15px'/>", (object)risInformeDomain.id_ris_informe, (object)byId1.aetitle);
                        str1 += "</div>";
                        str1 += "<div class='col-sm-5'>";
                        str1 += string.Format("<a href='VerInforme.aspx?idinforme={0}&aetitle={1}' style='color: white;font-size:11px' target='_blank'>{2}", (object)risInformeDomain.id_ris_informe, (object)byId1.aetitle, (object)ListaExamen.eliminarHtml(risInformeDomain.descripcion));
                        str1 += "</div>";
                        str1 += "<div class='col-sm-1'>";
                        num3 = risInformeDomain.id_estado_informe;

                        if (!num3.Equals(3))
                        {
                            string str5 = str1;
                            string[] strArray5 = new string[6];
                            strArray5[0] = "&id_informe=";
                            num2 = risInformeDomain.id_ris_informe;
                            strArray5[1] = num2.ToString();
                            strArray5[2] = "&codexamen=";
                            strArray5[3] = risInformeDomain.codExamen;
                            strArray5[4] = "&idInstitucion=";
                            num3 = byId1.id_institucion;
                            strArray5[5] = num3.ToString();
                            string str6 = ListaExamen.encriptarInformarOIT(string.Concat(strArray5));
                            str1 = str5 + "<a href='" + str6 + "' style='color: white;font-size:11px' title='Solicitar Corrección'>&nbsp;&nbsp;<img src='../icon/corregir.png' style='width: 15px'/></a>";
                        }

                        if (byId1.addendum == 1)
                        {
                            bool flag = false;

                            RisAddendumDomain risAddendumDomain = RisAddendumDataAccess.GetlatestByActive(risInformeDomain.id_ris_informe);
                            int num4 = RisAddendumDataAccess.NuevasSolProcesadas(idExamen);
                            string usernameRadiologo = risInformeDomain.username_radiologo;

                            if (num4 > 0)
                            {
                                if (usuario.username.Equals(risInformeDomain.username_radiologo)) flag = true;
                                if (usuario.id_perfil.Equals(6)) flag = true;
                            }

                            string str7 = string.Empty;
                            string str8 = string.Empty;
                            string empty = string.Empty;

                            if (!flag)
                            {
                                str7 = "No puede Crear Addendum.";
                                str8 = "#";
                            }
                            else if (risAddendumDomain.id_addendum > 0L)
                            {
                                str7 = "Crear Addendum.";
                                string[] strArray6 = new string[8];
                                strArray6[0] = "&id_addendum=";
                                num2 = risAddendumDomain.id_addendum;
                                strArray6[1] = num2.ToString();
                                strArray6[2] = "&id_informe=";
                                num2 = risInformeDomain.id_ris_informe;
                                strArray6[3] = num2.ToString();
                                strArray6[4] = "&cod_examen=";
                                strArray6[5] = risInformeDomain.codExamen;
                                strArray6[6] = "&id_institucion=";
                                num3 = byId1.id_institucion;
                                strArray6[7] = num3.ToString();
                                str8 = ListaExamen.encriptarAddendum(string.Concat(strArray6));
                            }
                            else if (risAddendumDomain.id_addendum == 0L)
                            {
                                str7 = "Crear Addendum.";
                                string[] strArray7 = new string[8];
                                strArray7[0] = "&id_addendum=";
                                num2 = risAddendumDomain.id_addendum;
                                strArray7[1] = num2.ToString();
                                strArray7[2] = "&id_informe=";
                                num2 = risInformeDomain.id_ris_informe;
                                strArray7[3] = num2.ToString();
                                strArray7[4] = "&cod_examen=";
                                strArray7[5] = risInformeDomain.codExamen;
                                strArray7[6] = "&id_institucion=";
                                num3 = byId1.id_institucion;
                                strArray7[7] = num3.ToString();
                                str8 = ListaExamen.encriptarAddendum(string.Concat(strArray7));
                            }

                            if (!str7.Equals(string.Empty)) str1 = str1 + "<a title='" + str7 + "' href='" + str8 + "' style='color: white;font-size:11px'>&nbsp;<img id='imgAddendum' src='../icon/corregir.png' style='width: 15px'/></a>";
                        }

                        str1 += "</div>";
                        break;
                    case 3:
                        str1 += "<div class='row'>";
                        str1 += "<div class='col-sm-1'>";

                        string[] strArray8 = new string[6] { str1, "<a title='Ver Informe OIT' href='", null, null, null, null };
                        string str9 = byId1.url_informe_oit.Replace("#CODEXAMEN#", byIdAndAcc2.codexamen);

                        num2 = risInformeDomain.id_informe_remoto;

                        string newValue1 = num2.ToString();
                        string str10 = str9.Replace("#IDINFORME#", newValue1);

                        num2 = risInformeDomain.id_informe_remoto;

                        string newValue2 = num2.ToString();

                        strArray8[2] = str10.Replace("#IDINFORME#", newValue2);
                        strArray8[3] = "' style='color: white; font-size:11px' target='_blank' >&nbsp;&nbsp;<img src='../icon/pdf.png' style='width: 15px'/>";
                        strArray8[4] = ListaExamen.eliminarHtml(risInformeDomain.descripcion);
                        strArray8[5] = "</a>";
                        str1 = string.Concat(strArray8);
                        str1 += "</div>";
                        str1 += "<div class='col-sm-6'>";
                        num3 = risInformeDomain.id_estado_informe;

                        if (!num3.Equals(3))
                        {
                            string str11 = str1;
                            string[] strArray9 = new string[6];
                            strArray9[0] = "&id_informe=";
                            num2 = risInformeDomain.id_ris_informe;
                            strArray9[1] = num2.ToString();
                            strArray9[2] = "&codexamen=";
                            strArray9[3] = risInformeDomain.codExamen;
                            strArray9[4] = "&idInstitucion=";
                            num3 = byId1.id_institucion;
                            strArray9[5] = num3.ToString();
                            string str12 = ListaExamen.encriptarInformarOIT(string.Concat(strArray9));
                            str1 = str11 + "<a href='" + str12 + "' style='color: white; font-size:18px' title='Solicitar Corrección'>&nbsp;&nbsp;<img src='../icon/corregir.png' style='width: 15px'/></a>";
                        }

                        str1 += "</div>";
                        break;
                    default:
                        str1 += "<div class='row'>";
                        str1 += "<div class='col-sm-1'>";

                        string[] strArray10 = new string[6] { str1, "2222<a title=\"Ver Informe\"href='", null, null, null, null };
                        string str13 = byId1.url_informe.Replace("#CODEXAMEN#", byIdAndAcc2.codexamen);
                        num2 = risInformeDomain.id_informe_remoto;
                        string newValue3 = num2.ToString();
                        string str14 = str13.Replace("#IDINFORME#", newValue3);
                        num2 = risInformeDomain.id_informe_remoto;
                        string newValue4 = num2.ToString();
                        strArray10[2] = str14.Replace("#IDINFORME#", newValue4);
                        strArray10[3] = "' style=\"color: white;font-size:18px\" target='_blank' >&nbsp;&nbsp;<img src='../icon/pdf.png' style='width: 20px'/>";
                        strArray10[4] = ListaExamen.eliminarHtml(risInformeDomain.descripcion);
                        strArray10[5] = "</a>";
                        str1 = string.Concat(strArray10);
                        str1 += "</div>";
                        str1 += "<div class='col-sm-6'>";
                        num3 = risInformeDomain.id_estado_informe;

                        if (!num3.Equals(3))
                        {
                            string str15 = str1;
                            string[] strArray11 = new string[6];
                            strArray11[0] = "&id_informe=";
                            num2 = risInformeDomain.id_ris_informe;
                            strArray11[1] = num2.ToString();
                            strArray11[2] = "&codexamen=";
                            strArray11[3] = risInformeDomain.codExamen;
                            strArray11[4] = "&idInstitucion=";
                            num3 = byId1.id_institucion;
                            strArray11[5] = num3.ToString();
                            string str16 = ListaExamen.encriptarInformar(string.Concat(strArray11));
                            str1 = str15 + "<a href='" + str16 + "' style='color: white;font-size:11px' title='Solicitar Corrección'>&nbsp;&nbsp;<img src='../icon/corregir.png' style='width: 15px'/></a>";
                        }

                        if (byId1.addendum == 1)
                        {
                            RisAddendumDomain risAddendumDomain = RisAddendumDataAccess.GetlatestByActive(risInformeDomain.id_ris_informe);
                            string str17 = "";

                            if (risAddendumDomain.id_addendum > 0L) str17 = "Crear Addendum.";
                            else if (risAddendumDomain.id_addendum == 0L) str17 = "Crear Addendum.";

                            string[] strArray12 = new string[6] { str1, "<a href='", null, null, null, null };
                            string[] strArray13 = new string[8];
                            strArray13[0] = "&id_addendum=";
                            num2 = risAddendumDomain.id_addendum;
                            strArray13[1] = num2.ToString();
                            strArray13[2] = "&id_informe=";
                            num2 = risInformeDomain.id_ris_informe;
                            strArray13[3] = num2.ToString();
                            strArray13[4] = "&cod_examen=";
                            strArray13[5] = risInformeDomain.codExamen;
                            strArray13[6] = "&id_institucion=";
                            num3 = byId1.id_institucion;
                            strArray13[7] = num3.ToString();
                            strArray12[2] = ListaExamen.encriptarAddendum(string.Concat(strArray13));
                            strArray12[3] = "' style='color: white;font-size:11px' title='";
                            strArray12[4] = str17;
                            strArray12[5] = "'>&nbsp;&nbsp;<img id='imgAddendum' src='../icon/corregir.png' style='width:15px'/></a>";
                            str1 = string.Concat(strArray12);
                        }

                        str1 += "</div>";
                        break;
                }

                str1 += "<div class='col-sm-2'>";
                str1 = str1 + "<label style='font-size:11px'>" + byId2.nombre + "</label>";
                str1 += "</div>";
                str1 += "<div class='col-sm-2'>";
                str1 = str1 + "<label style='font-size:11px'>" + byIdAndAcc2.usuarioValidadorExamen + "</label>";              
                str1 += "</div>";
                num1 = byIdAndAcc2.id_estado_examen;

                if (num1.Equals(3))
                {
                    str1 += "<div class='col-sm-1'>";
                    string[] strArray14 = new string[6] {
                        str1,
                        "<img src='../icon/recargar.png' style='width: 15px; cursor: pointer' id='btnRecargarEstudiosAnteriores' title='Reenvio de Informe.' onclick='RecargaEnvioInforme(",
                        null,
                        null,
                        null,
                        null
                    };

                    num2 = byIdAndAcc2.id_ris_examen;
                    strArray14[2] = num2.ToString();
                    strArray14[3] = ", &#34 ";
                    strArray14[4] = byIdAndAcc2.numeroacceso;
                    strArray14[5] = " &#34); return false;' />";
                    str1 = string.Concat(strArray14);
                    str1 += "<div id='divEstudiosRelacionados'></div>";
                    str1 += "</div>";
                }

                str1 += "</div>";
            }

            string str18 = str1;

            return new ResponseApp() { Ejecutado = true, Mensaje = string.Empty, Data = (object)str18.ToString().Replace("\"", "'") };
        }

        [WebMethod(EnableSession = true)]
        [HttpPost]
        public static List<SelectListItem> ListarInstitucionesAddendum()
        {
            if (HttpContext.Current.Session["id_usuario"] == null) HttpContext.Current.Response.Redirect("../../Default.aspx");

            List<SolicitudAddendumInstitucionDomain> institucionDomainList = SolicitudAddendumInstitucionAccess.Instituciones();
            List<UsuarioInstitucionDomain> source = UsuarioInstitucionDataAccess.ListarUsuarioInstitucion(HttpContext.Current.Session["username"].ToString());
            List<SelectListItem> selectListItemList = new List<SelectListItem>();

            foreach (SolicitudAddendumInstitucionDomain institucionDomain in institucionDomainList)
            {
                if (source.Select<UsuarioInstitucionDomain, string>((System.Func<UsuarioInstitucionDomain, string>)(s => s.nombre_institucion)).ToList<string>().Contains(institucionDomain.Nombre))
                    selectListItemList.Add(new SelectListItem() { Value = institucionDomain.UsuarioInstitucion.ToString(), Text = institucionDomain.Nombre });
            }

            return selectListItemList;
        }


        [WebMethod(EnableSession = true)]
        [HttpPost]
        public static List<SelectListItem> InstitucionesAddendum()
        {
            List<SelectListItem> select = new List<SelectListItem>();

            if (HttpContext.Current.Session["id_usuario"] == null) HttpContext.Current.Response.Redirect("../../Default.aspx");

            foreach (UsuarioInstitucionDomain row in UsuarioInstitucionDataAccess.Get(HttpContext.Current.Session["username"].ToString()))
            {
                select.Add(new SelectListItem() { Value = row.id_institucion.ToString(), Text = row.nombre_institucion });
            }

            if (HttpContext.Current.Session["id_perfil"].ToString() == "8" || HttpContext.Current.Session["id_perfil"].ToString() == "4")
                select.Remove(select.SingleOrDefault(s => s.Value == "0"));

                return select;
        }


        [WebMethod(EnableSession = true)]
        [HttpPost]
        public static List<SelectListItem> MedInformateInformeAddendum()
        {
            if (HttpContext.Current.Session["id_usuario"] == null) HttpContext.Current.Response.Redirect("../../Default.aspx");

            if (HttpContext.Current.Session["id_perfil"].ToString() == "8" || HttpContext.Current.Session["id_perfil"].ToString() == "4")
                return new List<SelectListItem>();

            List<SelectListItem> medicosInformantesAddendum = new List<SelectListItem>();
            List<UsuarioDomain> medicos = UsuarioDataAccess.ListarMedicosInformadores();

            medicosInformantesAddendum.Add(new SelectListItem() { Value = "0", Text = "- Todos -" });
            foreach (UsuarioDomain medico in medicos)
            {
                medicosInformantesAddendum.Add(new SelectListItem() { Value = medico.id_usuario.ToString(), Text = medico.username });
            }
            return medicosInformantesAddendum;
        }


        [WebMethod(EnableSession = true)]
        [HttpPost]
        public static ResponseApp ProcesarPrestacionesExamen(long idExamen)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            List<RisExamenPrestacionDomain> prestacionDomainList1 = new List<RisExamenPrestacionDomain>();
            List<RisExamenPrestacionDomain> prestacionDomainList2 = new List<RisExamenPrestacionDomain>();
            List<ResponseInformePrestacionEliminar> prestacionEliminarList = new List<ResponseInformePrestacionEliminar>();
            ResponsePrestacionExamen prestacionExamen = ListaExamen.SessionMantenedorPrestacion<ResponsePrestacionExamen>(2);
            List<ExamenPrestacionMantenedorDomain> prestacionesExamenMantenedor = prestacionExamen.PrestacionesExamen;
            RisExamenDomain byId = RisExamenDataAccess.GetById(idExamen);
            IList<RisExamenPrestacionDomain> pestacionesExamenDb = RisExamenPrestacionDataAccess.GetByCodExamen(byId.codexamen);
            RisInformeDataAccess.GetByMultiple(byId.codexamen, byId.numeroacceso, byId.id_institucion);
            IList<RisInformePrestacionDomain> byCodExamen = RisInformePrestacionDataAccess.GetByCodExamen(byId.codexamen);
            List<long> list1 = pestacionesExamenDb.Where<RisExamenPrestacionDomain>((System.Func<RisExamenPrestacionDomain, bool>)(c => !prestacionesExamenMantenedor.Select<ExamenPrestacionMantenedorDomain, long>((System.Func<ExamenPrestacionMantenedorDomain, long>)(s => s.IdPrestacion)).Contains<long>(c.id_prestacion))).Select<RisExamenPrestacionDomain, long>((System.Func<RisExamenPrestacionDomain, long>)(s => s.id_prestacion)).ToList<long>();
            List<long> list2 = prestacionesExamenMantenedor.Where<ExamenPrestacionMantenedorDomain>((System.Func<ExamenPrestacionMantenedorDomain, bool>)(c => !pestacionesExamenDb.Select<RisExamenPrestacionDomain, long>((System.Func<RisExamenPrestacionDomain, long>)(s => s.id_prestacion)).Contains<long>(c.IdPrestacion))).Select<ExamenPrestacionMantenedorDomain, long>((System.Func<ExamenPrestacionMantenedorDomain, long>)(s => s.IdPrestacion)).ToList<long>();
            List<ResponseInformePrestacionEliminar> list3 = byCodExamen.Where<RisInformePrestacionDomain>((System.Func<RisInformePrestacionDomain, bool>)(c => !prestacionesExamenMantenedor.Select<ExamenPrestacionMantenedorDomain, long>((System.Func<ExamenPrestacionMantenedorDomain, long>)(s => s.IdPrestacion)).Contains<long>(c.id_prestacion))).Select<RisInformePrestacionDomain, ResponseInformePrestacionEliminar>((System.Func<RisInformePrestacionDomain, ResponseInformePrestacionEliminar>)(c => new ResponseInformePrestacionEliminar()
            {
                IdInforme = c.id_informe,
                IdPrestacion = c.id_prestacion
            })).ToList<ResponseInformePrestacionEliminar>();
            foreach (long num in list1)
                prestacionDomainList1.Add(new RisExamenPrestacionDomain()
                {
                    id_ris_examen = byId.id_ris_examen,
                    id_examen_prestacion_remoto = byId.id_examen_remoto,
                    codExamen = byId.codexamen,
                    id_prestacion = num,
                    id_institucion = byId.id_institucion,
                    username = byId.usernameRadiologo
                });
            foreach (long num in list2)
            {
                long prestacionExamenInsertar = num;
                prestacionDomainList2.Add(new RisExamenPrestacionDomain()
                {
                    id_ris_examen = byId.id_ris_examen,
                    id_examen_prestacion_remoto = byId.id_examen_remoto,
                    codExamen = byId.codexamen,
                    id_prestacion = prestacionExamenInsertar,
                    id_institucion = byId.id_institucion,
                    id_prestacion_remoto = prestacionExamen.Prestaciones.SingleOrDefault<ExamenPrestacionMantenedorDomain>((System.Func<ExamenPrestacionMantenedorDomain, bool>)(s => s.IdPrestacion == prestacionExamenInsertar)).IdPrestacionRemoto,
                    username = byId.usernameRadiologo
                });
            }
            if (!prestacionDomainList1.Any<RisExamenPrestacionDomain>() && !prestacionDomainList2.Any<RisExamenPrestacionDomain>())
                return new ResponseApp()
                {
                    Ejecutado = false,
                    Mensaje = "No existen prestacion(es) modificadas para su ejecucion. Favor modificar y realizar nuevamente",
                    Data = (object)null
                };
            ResultEjecucion resultEjecucion = ExamenPrestacionMantenedorDataAccess.InsertOrDeletePrestacionExamen(prestacionDomainList1, prestacionDomainList2, list3, byId.id_ris_examen, byId.codexamen);
            return new ResponseApp()
            {
                Ejecutado = resultEjecucion.Ejecutado,
                Mensaje = resultEjecucion.Ejecutado ? "Modificacion de prestacion examen se realizo correctamente" : "No se realizo modificacion de las prestaciones del examen, favor intentar nuevamente",
                Data = (object)null
            };
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true)]
        public static ResponseApp EliminarPrestacionExamen(int idPrestacion, int count, int risExamen)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            try
            {
                if (count.Equals(1))
                    return new ResponseApp()
                    {
                        Ejecutado = false,
                        Mensaje = "No se puede eliminar debido a que es la unica prestacion del examen, favor agregar una prestacion nueva antes de eliminar",
                        Data = (object)null
                    };
                ExamenPrestacionMantenedorDataAccess.SingleDelete(new RisExamenPrestacionDomain()
                {
                    id_prestacion = (long)idPrestacion,
                    id_ris_examen = (long)risExamen
                });
                return new ResponseApp()
                {
                    Ejecutado = true,
                    Mensaje = string.Empty,
                    Data = (object)null
                };
            }
            catch (Exception ex)
            {
                return new ResponseApp()
                {
                    Ejecutado = false,
                    Mensaje = ex.Message.ToString(),
                    Data = (object)null
                };
            }
        }

        public static T SessionMantenedorPrestacion<T>(int accion, object data = null)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            if (accion == 0)
            {
                HttpContext.Current.Session.Remove("SessionPrestacionExamenMantenedor");
                return default(T);
            }
            if (accion != 1)
                return JsonConvert.DeserializeObject<T>(HttpContext.Current.Session["SessionPrestacionExamenMantenedor"].ToString());
            HttpContext.Current.Session["SessionPrestacionExamenMantenedor"] = (object)JsonConvert.SerializeObject(data);
            return default(T);
        }

        public void LogError(Exception ex, string paginaEvento) => this.Response.Redirect("../../Default.aspx");

        public static void EnviaCorreoRechazo(int idSol)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            SolicitudAddendumInstitucionDomain institucionDomain = SolicitudAddendumInstitucionAccess.Detalle(idSol);
            string appSetting1 = ConfigurationManager.AppSettings["emailfrom"];
            string appSetting2 = ConfigurationManager.AppSettings["emailto"];
            string appSetting3 = ConfigurationManager.AppSettings["emailname"];
            string appSetting4 = ConfigurationManager.AppSettings["emailpass"];
            string appSetting5 = ConfigurationManager.AppSettings["urlris"];
            string nombre = InstitucionDataAccess.GetById(institucionDomain.UsuarioInstitucion).nombre;
            long idRisExamen = institucionDomain.IdRisExamen;
            string str = idRisExamen.ToString();
            string correoSolicitanteAddendum = string.IsNullOrEmpty(institucionDomain.UsuarioMail) ? "" : institucionDomain.UsuarioMail;

            RisExamenDomain byId = RisExamenDataAccess.GetById(institucionDomain.IdRisExamen);
            idRisExamen = institucionDomain.IdRisExamen;
            string asunto = "Rechazo solicitud Addendum Examen : " + idRisExamen.ToString() + " Institución : " + nombre;

            string cuerpo = "Estimado(a), nos dirigimos a usted para informar sobre su solicitud de evaluación de examen. Esta ha sido rechazado adminstrativamente. Examen : <b>" + str + "</b> a paciente:<br /><br />" + byId.nombre + " " + byId.apellidopaterno + " " + byId.apellidomaterno + " (" + byId.idpaciente + ")<br />" + byId.descripcion + "<br />" + byId.fechaexamen.ToString() + "<br /> Comentario Rechazo:<br />" + institucionDomain.Comentario + "<br /><br /> Favor tomar conocimiento <b>";
            MailUtil.SendMail(appSetting3, appSetting1, appSetting4, appSetting2, "", asunto, cuerpo);

            if (correoSolicitanteAddendum != "")
            {
                cuerpo = "Estimado(a), nos dirigimos a usted para informar sobre su solicitud de evaluación de examen. Esta ha sido rechazado adminstrativamente. Examen : <b>" + str + "</b> a paciente:<br /><br />" + byId.nombre + " " + byId.apellidopaterno + " " + byId.apellidomaterno + " (" + byId.idpaciente + ")<br />" + byId.descripcion + "<br />" + byId.fechaexamen.ToString() + "<br /> Comentario Rechazo:<br />" + institucionDomain.Comentario + "<br /><br /> Favor tomar conocimiento <b>";
                MailUtil.SendMail(appSetting3, appSetting1, appSetting4, correoSolicitanteAddendum, "", asunto, cuerpo);
            }
        }

        public static void EnviaCorreoCreacionSolAdd(string Usuario, int UsuarioInstitucion, string UsuarioMail, long IdRisExamen, string Detalle, int TipoSolicitud)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            string appSetting1 = ConfigurationManager.AppSettings["emailfrom"];
            string appSetting2 = ConfigurationManager.AppSettings["emailto"] + (string.IsNullOrEmpty(UsuarioMail) ? "" : ";" + UsuarioMail);
            string appSetting3 = ConfigurationManager.AppSettings["emailname"];
            string appSetting4 = ConfigurationManager.AppSettings["emailpass"];
            string appSetting5 = ConfigurationManager.AppSettings["urlris"];
            string nombre = InstitucionDataAccess.GetById(UsuarioInstitucion).nombre;
            Convert.ToInt32(IdRisExamen);
            string str = Convert.ToString(IdRisExamen);
            RisExamenDomain byId = RisExamenDataAccess.GetById(IdRisExamen);
            UsuarioDomain byUsername = UsuarioDataAccess.GetByUsername(Usuario);
            string asunto = "Creación solicitud Addendum Examen : " + IdRisExamen.ToString() + " Institución : " + nombre + ", Usuario : " + byUsername.nombre + " " + byUsername.apellido_paterno + " " + byUsername.apellido_materno;
            string cuerpo = "Estimado(a), nos dirigimos a usted para informar que se ha creado una solicitud para reevaluación del examen : <b>" + str + "</b> a paciente:<br /><br />" + byId.nombre + " " + byId.apellidopaterno + " " + byId.apellidomaterno + " (" + byId.idpaciente + ")<br />" + byId.descripcion + "<br />" + byId.fechaexamen.ToString() + "<br /> con las siguientes indicaciones : <br />" + Detalle + "<br /><br /> Favor atender. <b>";

            MailUtil.SendMail(appSetting3, appSetting1, appSetting4, appSetting2, "", asunto, cuerpo);
        }

        public static void EnviaCorreoProcesoAddendum(int idSol)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            SolicitudAddendumInstitucionDomain institucionDomain = SolicitudAddendumInstitucionAccess.Detalle(idSol);          
            string appSetting1 = ConfigurationManager.AppSettings["emailfrom"];
            string appSetting2 = ConfigurationManager.AppSettings["emailto"];
            string appSetting3 = ConfigurationManager.AppSettings["emailname"];
            string appSetting4 = ConfigurationManager.AppSettings["emailpass"];
            string appSetting5 = ConfigurationManager.AppSettings["urlris"];
            string nombre = InstitucionDataAccess.GetById(institucionDomain.UsuarioInstitucion).nombre;
            long idRisExamen = institucionDomain.IdRisExamen;
            string str = idRisExamen.ToString();
            string correoSolicitanteAddendum = string.IsNullOrEmpty(institucionDomain.UsuarioMail) ? "" : institucionDomain.UsuarioMail;
            string correoMedInformador = UsuarioDataAccess.GetByUsername(institucionDomain.UsuarioInformadorExamen).email1;

            RisExamenDomain byId = RisExamenDataAccess.GetById(institucionDomain.IdRisExamen);
            RisInformeDataAccess.GetByID(Convert.ToInt64(institucionDomain.IdRisExamen));
            UsuarioDomain byUsername = UsuarioDataAccess.GetByUsername(institucionDomain.UsuarioMail);
            

            string[] strArray = new string[10];
            strArray[0] = "Notificación proceso solicitud Addendum Examen : ";
            idRisExamen = institucionDomain.IdRisExamen;
            strArray[1] = idRisExamen.ToString();
            strArray[2] = " Institución : ";
            strArray[3] = nombre;
            strArray[4] = ", Radiologo : ";
            strArray[5] = byUsername.nombre;
            strArray[6] = " ";
            strArray[7] = byUsername.apellido_paterno;
            strArray[8] = " ";
            strArray[9] = byUsername.apellido_materno;

            string asunto = string.Concat(strArray);
            string cuerpo = "Estimado(a), nos dirigimos a usted para informar sobre su solicitud de evaluación de examen. Esta ha cambiado al estado En Proceso. Examen : <b>" + str + "</b> a paciente:<br /><br />" + byId.nombre + " " + byId.apellidopaterno + " " + byId.apellidomaterno + " (" + byId.idpaciente + ")<br />" + byId.descripcion + "<br />" + byId.fechaexamen.ToString() + "<br /> Detalle solicitud : <br />" + institucionDomain.Detalle + "<br /><br /> Favor tomar conocimiento <b>";
            MailUtil.SendMail(appSetting3, appSetting1, appSetting4, appSetting2, "", asunto, cuerpo);

            if(!string.IsNullOrEmpty(correoMedInformador))
            {
                cuerpo = "Estimado(a) Dr(a), nos dirigimos a usted para informar que se ha generado una solicitud de evaluacion del examen. Examen : <b>" + str + "</b> a paciente:<br /><br />" + byId.nombre + " " + byId.apellidopaterno + " " + byId.apellidomaterno + " (" + byId.idpaciente + ")<br />" + byId.descripcion + "<br />" + byId.fechaexamen.ToString() + "<br /> Detalle solicitud : <br />" + institucionDomain.Detalle + "<br /><br /> Favor tomar conocimiento <b>";
                MailUtil.SendMail(appSetting3, appSetting1, appSetting4, correoMedInformador, "", asunto, cuerpo);
            }

            if (correoSolicitanteAddendum != "")
            {
                cuerpo = "Estimado(a), nos dirigimos a usted para informar sobre su solicitud de evaluación de examen. Esta ha cambiado al estado En Proceso. Examen : <b>" + str + "</b> a paciente:<br /><br />" + byId.nombre + " " + byId.apellidopaterno + " " + byId.apellidomaterno + " (" + byId.idpaciente + ")<br />" + byId.descripcion + "<br />" + byId.fechaexamen.ToString() + "<br /> Detalle solicitud : <br />" + institucionDomain.Detalle + "<br /><br /> Favor tomar conocimiento <b>";
                MailUtil.SendMail(appSetting3, appSetting1, appSetting4, correoSolicitanteAddendum, "", asunto, cuerpo);
            }
        }

        [WebMethod(EnableSession = true)]
        [HttpPost]
        public static ResponseApp EliminaSolicitudAdeendum(int id)
        {
            if (HttpContext.Current.Session["id_usuario"] == null) HttpContext.Current.Response.Redirect("../../Default.aspx");

            bool flag = SolicitudAddendumInstitucionAccess.Delete(id);

            return new ResponseApp()
            {
                Ejecutado = flag,
                Mensaje = flag ? "" : "No se pudo eliminar la solicitud Addendum",
                Data = (object)null
            };
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true)]
        public static ArrayList InformarResumido(string id_ris_examen, string numeroacceso)
        { 
            if (HttpContext.Current.Session["id_usuario"] == null) HttpContext.Current.Response.Redirect("../../Default.aspx");
			
            DateTime now = DateTime.Now;
            ArrayList arrayList = new ArrayList();
			int _timeBloqueo = Convert.ToInt16(ConfigurationManager.AppSettings["TimeBloqueo"].ToString());

            try
            {
                string str1 = "";
                string str2 = "";
                long id_ris_examen1 = long.Parse(id_ris_examen.ToString().Split('-')[0]);
                


                RisExamenDomain byIdAndAcc = RisExamenDataAccess.GetByIdAndAcc(id_ris_examen1, numeroacceso);
                InstitucionDomain byId1 = InstitucionDataAccess.GetById(byIdAndAcc.id_institucion);
                IList<RisInformeDomain> codExamenValidado = RisInformeDataAccess.GetByCodExamenValidado(byIdAndAcc.codexamen, 3, numeroacceso, byId1.id_institucion);
                RisEstadoExamenDomain estadoExamenDomain = new RisEstadoExamenDomain();
                UsuarioDomain byUsername = UsuarioDataAccess.GetByUsername("NOAMIS");
                UsuarioDomain usuario = UsuarioDataAccess.GetById(Convert.ToInt64(HttpContext.Current.Session["id_usuario"].ToString()));

                bool flag = false;
                
                foreach (RisInformeDomain risInformeDomain in (IEnumerable<RisInformeDomain>)codExamenValidado) {
                    if (risInformeDomain.username_radiologo == byUsername.username) flag = true;
                }

                string str3 = "";
                long int64 = Convert.ToInt64(HttpContext.Current.Session["id_usuario"].ToString());
                TimeSpan timeSpan = now - byIdAndAcc.fecha_bloqueo;
                int seconds = timeSpan.Seconds;
                timeSpan = now - byIdAndAcc.fecha_bloqueo;
                int num1 = timeSpan.Days * 86400;
                timeSpan = now - byIdAndAcc.fecha_bloqueo;
                int num2 = timeSpan.Minutes * 60;
                timeSpan = now - byIdAndAcc.fecha_bloqueo;
                int num3 = timeSpan.Hours * 3600;
                int num4 = seconds + num1 + num2 + num3;
                string str4 = !usuario.id_perfil.Equals(8) ? "<div id='divImagenesReales'><b class='texto1'><label>IMAGENES</b></b><br />" + ListaExamen.Imagenes(byIdAndAcc.id_ris_examen, byIdAndAcc.numeroacceso, usuario.id_perfil) + "</div>" : "";
                string str5;




                
                if (byIdAndAcc.id_estado_examen == 0 && byIdAndAcc.bloqueado == 1 && num4 / 60 < _timeBloqueo && (long)byIdAndAcc.id_usuario_bloqueo != int64)
                {
                    UsuarioDomain byId2 = UsuarioDataAccess.GetById((long)byIdAndAcc.id_usuario_bloqueo);
                    string usuarioBloqueo = "Estudio siendo visualizado por el Dr(a) " + byId2.nombre.ToUpper() + " " + byId2.apellido_paterno.ToUpper() + " " + byId2.apellido_materno.ToUpper();
                    string mensaje = HttpContext.Current.Session["id_perfil"].ToString() == "1" 
                        ? "<table><tr><td><p id='pExamenBloqueado'>Este exámen se encuentra bloqueado. "+ usuarioBloqueo + "</p></td></tr><tr><td><input type='button' class='btn btn-primary btn-informar2' value='Desbloquear Examen' onclick='DesbloquearExamen("+ byIdAndAcc.id_ris_examen + ")' style='min-width:130px !important' /></td></tr></table></br>"
                        : "<table><tr><td><p id='pExamenBloqueado'>Este exámen se encuentra bloqueado</p></td></tr></table>";
                    str5 = str2 + mensaje;
                }
                else if (flag || (long)byIdAndAcc.idradiologo == byUsername.id_usuario || byIdAndAcc.usernameRadiologo == byUsername.username || byIdAndAcc.id_estado_examen == 3 && codExamenValidado.Count == 0)
                    str5 = str2 + "<table><tr><td><p id='pExamenBloqueado'>Estudio reasignado localmente. Si desea informarlo, debe ser actualizado en el sistema de origen</p></td></tr></table>";
                else if (byIdAndAcc.id_estado_examen == 10)
                    str5 = str2 + "<table><tr><td><p id='pExamenBloqueado'>El estudio en estado Eliminado. Para informar debe ser consultado al Administrador del Sistema.</p></td></tr></table>";
                else if (byIdAndAcc.id_estado_examen == 9)
                {
                    str5 = str2 + "<table><tr><td><p id='pExamenBloqueado'>El estudio en estado Pendiente. Para informar debe ser consultado al Administrador del Sistema.</p></td></tr></table>";
                }
                else
                {
                    str1 = ListaExamen.PrestacionesResumido(id_ris_examen1, numeroacceso);
                    str5 = ListaExamen.InformesResumido(id_ris_examen1, numeroacceso);
                    IList<RisPrestacionDomain> prestacionDomainList = RisPrestacionDataAccess.PrestacionesInformar(byIdAndAcc.usernameRadiologo, byId1.id_institucion, byIdAndAcc.id_ris_examen, byIdAndAcc.codexamen, numeroacceso);
                    IList<RisInformeDomain> examenNoValidado = RisInformeDataAccess.GetByCodExamenNoValidado(byIdAndAcc.codexamen, 3, numeroacceso, byId1.id_institucion);
                    if (prestacionDomainList.Count == 1 && examenNoValidado.Count == 0 && codExamenValidado.Count == 0)
                    {
                        ConfiguracionGeneralDataAccess.GetById(1L);
                        ConfiguracionGeneralDataAccess.GetById(2L);
                        ConfiguracionGeneralDataAccess.GetById(3L);
                        foreach (RisPrestacionDomain prestacionDomain in (IEnumerable<RisPrestacionDomain>)prestacionDomainList)
                        {
                            string str6;
                            if (prestacionDomain.oit)
                                str6 = ListaExamen.encriptarInformarOIT("&codexamen=" + byIdAndAcc.codexamen + "&idInstitucion=" + byId1.id_institucion.ToString() + "&idprestacion=" + prestacionDomainList[0].id_prestacion.ToString());
                            else
                                str6 = ListaExamen.encriptarInformar("&codexamen=" + byIdAndAcc.codexamen + "&idInstitucion=" + byId1.id_institucion.ToString() + "&idprestacion=" + prestacionDomainList[0].id_prestacion.ToString());
                            str3 = str6;
                        }
                    }
                }
                arrayList.Add((object)new
                {
                    tablaPrestaciones = str1,
                    tablaInformes = str5,
                    urlPrestacion = str3,
                    imagenes = str4,
                    estadoExamen = byIdAndAcc.id_estado_examen
                });
                return arrayList;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                Log.Error(ex, message);
                return arrayList;
            }
        }

         [WebMethod(EnableSession = true)]
        [HttpPost]
        public static bool DesbloqueoExamen(long idExamen)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");

            return RisExamenDataAccess.DesbloqueoExamen(idExamen);
        }

        [WebMethod]
        public static string obtenerAcciones(string id_ris_examen)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            DataTable dataTable = new DataTable();
            DataTable risWebParaAcciones = RisExamenDataAccess.GetByFilterMultiRisWebParaAcciones(int.Parse(id_ris_examen));
            string str1 = "";
            if (risWebParaAcciones.Rows.Count > 0)
            {
                string str2 = str1 + "<table><tr><th style='width: 15%; text-align: center'><label>Fecha</label></th><th style='width: 15%; text-align: center'><label>Usuario</label></th><th style='width: 70%;'><label>Acciones</label></th></tr>";
                foreach (DataRow row in (InternalDataCollectionBase)risWebParaAcciones.Rows)
                {
                    str2 += "<tr>";
                    str2 += "<td style='text-align: center;'>";
                    str2 = str2 + "<label>" + Convert.ToDateTime(row["fecha"]).ToString("dd-MM-yyyy HH:mm") + "</label>";
                    str2 += "</td>";
                    str2 += "<td style='text-align: center;'>";
                    str2 = str2 + "<label>" + row["NombreUsuario"]?.ToString() + "</label>";
                    str2 += "</td>";
                    str2 += "<td>";
                    str2 = str2 + "<label>" + row["observacion"]?.ToString() + "</label>";
                    str2 += "</td>";
                    str2 += "</tr>";
                }
                str1 = str2 + "</table>";
            }
            return str1;
        }

        [WebMethod]
        public static ResponseApp AddPrestacionExamen(int institucion, int examen, int prestacion)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            try
            {
                RisExamenPrestacionDomain examenPrestacion = new RisExamenPrestacionDomain()
                {
                    id_ris_examen = (long)examen,
                    id_institucion = institucion,
                    id_prestacion = (long)prestacion
                };
                ExamenPrestacionMantenedorDataAccess.SingleSave(examenPrestacion);
                return new ResponseApp()
                {
                    Ejecutado = true,
                    Mensaje = string.Empty,
                    Data = (object)new
                    {
                        Prestaciones = examenPrestacion
                    }
                };
            }
            catch (Exception ex)
            {
                return new ResponseApp()
                {
                    Ejecutado = false,
                    Mensaje = ex.Message.ToString(),
                    Data = (object)null
                };
            }
        }

        [WebMethod]
        public static ResponseApp GetMantedorPrestacion(int idExamen)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            ExamenPrestacionMantenedorDomain mantenedorDomain1 = ExamenPrestacionMantenedorDataAccess.Get(idExamen);
            List<ExamenPrestacionMantenedorDomain> source = ExamenPrestacionMantenedorDataAccess.ListarPrestaciones(mantenedorDomain1.IdInstitucion);
            List<ExamenPrestacionMantenedorDomain> prestacionesExamenMantenedor = ExamenPrestacionMantenedorDataAccess.ListarPrestacionesExamen(mantenedorDomain1.IdExamen);
            ListaExamen.SessionMantenedorPrestacion<ResponsePrestacionExamen>(1, (object)new ResponsePrestacionExamen()
            {
                Prestaciones = source,
                PrestacionesExamen = prestacionesExamenMantenedor
            });
            List<ExamenPrestacionMantenedorDomain> list = source.Where<ExamenPrestacionMantenedorDomain>((System.Func<ExamenPrestacionMantenedorDomain, bool>)(c => !prestacionesExamenMantenedor.Select<ExamenPrestacionMantenedorDomain, long>((System.Func<ExamenPrestacionMantenedorDomain, long>)(s => s.IdPrestacion)).Contains<long>(c.IdPrestacion))).ToList<ExamenPrestacionMantenedorDomain>();
            List<SelectListItem> selectListItemList = new List<SelectListItem>();
            foreach (ExamenPrestacionMantenedorDomain mantenedorDomain2 in list)
                selectListItemList.Add(new SelectListItem()
                {
                    Value = mantenedorDomain2.IdPrestacion.ToString(),
                    Text = mantenedorDomain2.NombrePrestacion + (!string.IsNullOrEmpty(mantenedorDomain2.CodigoPrestacion) ? "  - " + mantenedorDomain2.CodigoPrestacion : string.Empty)
                });
            return new ResponseApp()
            {
                Ejecutado = true,
                Mensaje = string.Empty,
                Data = (object)new
                {
                    MantendorPrestacion = mantenedorDomain1,
                    PrestacionesExamen = prestacionesExamenMantenedor,
                    Prestaciones = selectListItemList
                }
            };
        }

        [WebMethod]
        public static ResponseApp UpdatePacienteInforme(
          string idExamen,
          string idPaciente,
          string nombre,
          string paterno,
          string materno,
          string genero)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            bool flag = TituloPacienteAperturaInformeDataAccess.UpdatePaciente((long)int.Parse(idExamen), idPaciente, nombre, paterno, materno, genero);
            return new ResponseApp()
            {
                Ejecutado = flag,
                Mensaje = flag ? "Datos del paciente se modificaron correcatmente" : "No se modificaron datos del paciente en el sistema, favor intentar nuevamente",
                Data = (object)null
            };
        }

        [WebMethod]
        public static ResponseApp UpdateTituloInforme(long idInforme, string titulo)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            if (string.IsNullOrEmpty(titulo))
                return new ResponseApp()
                {
                    Ejecutado = false,
                    Mensaje = "Favor ingresar Titulo del Informe a Modificar",
                    Data = (object)null
                };
            bool flag = TituloPacienteAperturaInformeDataAccess.UpdateTitulo(idInforme, titulo);
            return new ResponseApp()
            {
                Ejecutado = flag,
                Mensaje = flag ? "Titulo del informe se modifico correctamente" : "No se modifico el titulo del informe en el sistema favor intentar nuevamente",
                Data = (object)null
            };
        }

        [WebMethod]
        public static ResponseApp AperturarInforme(long idInforme)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            bool flag = TituloPacienteAperturaInformeDataAccess.AperturarInforme(idInforme);
            return new ResponseApp()
            {
                Ejecutado = flag,
                Mensaje = flag ? "Informe se re-aperturo correctamente en el sistema, recuerde que aun queda una copia actual del informe en el Ris local. Una vez que se valide nuevamente el informe se reemplazara" : "No fue posible re aperturar informe seleccionado",
                Data = (object)null
            };
        }

        [WebMethod]
        public static ResponseApp GetInfoTituloPaciente(long idExamen)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            List<ResponseTituloPacienteInforme> source = TituloPacienteAperturaInformeDataAccess.Listar(idExamen);
            return new ResponseApp()
            {
                Ejecutado = source.Any<ResponseTituloPacienteInforme>(),
                Data = (object)source,
                Mensaje = !source.Any<ResponseTituloPacienteInforme>() ? "No existen informes para su modificacion" : ""
            };
        }

        [WebMethod]
        public static string obtenerComentarios(string codExamen)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            string cod_examen = (string)null;
            string numero_acceso = (string)null;
            int id_institucion = 0;
            DataTable dataTable1 = new DataTable();
            foreach (DataRow row in (InternalDataCollectionBase)RisExamenDataAccess.GetByFilterMultiRisWebParaComentarios(codExamen).Rows)
            {
                cod_examen = row["codexamen"].ToString();
                numero_acceso = row["numeroacceso"].ToString();
                id_institucion = Convert.ToInt32(row["id_institucion"].ToString());
            }
            string str1 = "";
            InstitucionDomain byId = InstitucionDataAccess.GetById(id_institucion);
            DataTable dataTable2 = new DataTable();
            if (byId.id_institucion > 0)
            {
                InstitucionDatosDomain methodAndInstitucion = InstitucionDatosDataAccess.GetByIdMethodAndInstitucion(7, byId.id_institucion);
                if (ConfigurationManager.AppSettings["ActivarWSAPISalida"].ToString().Equals("1"))
                {
                    ConsumirWS consumirWs = new ConsumirWS();
                    ConsumirApi consumirApi = new ConsumirApi();
                    if (byId.id_tipo_conexion == 1)
                    {
                        string json = "{\"codExamen\":\"" + codExamen + "\",\"numeroAcceso\":\"" + numero_acceso + "\"}";
                        dataTable2 = consumirApi.ApiObtenerDataTable(methodAndInstitucion.url, methodAndInstitucion.metodo, json, byId.id_institucion);
                    }
                    else if (byId.id_tipo_conexion == 2)
                        dataTable2 = ConsumirWS.GetComentarios(byId.id_institucion, cod_examen, numero_acceso);
                }
            }
            if (dataTable2.Rows.Count > 0)
            {
                string str2 = str1 + "<table><tr><th style='width: 70%;'><label>Comentario</label></th><th style='width: 15%; text-align: center'><label>Fecha</label></th><th style='width: 15%; text-align: center'><label>Usuario</label></th></tr>";
                foreach (DataRow row in (InternalDataCollectionBase)dataTable2.Rows)
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
        public static List<SelectListItem> TipoSolicitudAddendum()
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            List<TipoSolicitudAddendumDomain> solicitudAddendumDomainList = TipoSolicitudAddendumDataAccess.Listar();
            List<SelectListItem> selectListItemList = new List<SelectListItem>();
            foreach (TipoSolicitudAddendumDomain solicitudAddendumDomain in solicitudAddendumDomainList)
                selectListItemList.Add(new SelectListItem()
                {
                    Value = solicitudAddendumDomain.Id.ToString(),
                    Text = solicitudAddendumDomain.Nombre
                });
            return selectListItemList;
        }

        [WebMethod]
        public static ResponseApp SolicitudAddendum(long idExamen, string usuario)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            RisExamenDomain byId1 = RisExamenDataAccess.GetById(idExamen);
            InstitucionDomain byId2 = InstitucionDataAccess.GetById(byId1.id_institucion);
            UsuarioDomain byId3 = UsuarioDataAccess.GetById(Convert.ToInt64(ListaExamen.Desencriptar(usuario).ToString()));
            var data = new
            {
                Id = byId1.id_ris_examen,
                FechaIngreso = DateTime.Now.ToString("dd-MM-yyyy HH:mm"),
                Usuario = string.Format("{0} {1}", (object)byId3.nombre, (object)byId3.apellido_paterno),
                Mail = byId3.email1 == null ? "--" : byId3.email1,
                Institucion = byId2.nombre,
                TipoAtencion = byId1.idtipoorden.Equals("A") ? "Ambulatoria" : (byId1.idtipoorden.Equals("U") ? "Urgencia" : "Hospitalizacion"),
                Modalidad = byId1.modalidad,
                FechaExamen = byId1.fechaexamen.ToString("dd-MM-yyyy HH:mm"),
                IdPaciente = byId1.idpaciente,
                Paciente = byId1.nombre,
                Medico = byId1.medicosolicitante,
                Estado = 3,
                Perfil = byId3.id_perfil
            };
            return new ResponseApp()
            {
                Ejecutado = true,
                Mensaje = string.Empty,
                Data = (object)data
            };
        }

        [WebMethod]
        public static string VisorDescarga(long id_ris_examen, string numeroacceso)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            string str = "";
            RisExamenDomain byIdAndAcc = RisExamenDataAccess.GetByIdAndAcc(id_ris_examen, numeroacceso);
            InstitucionDomain byAetitle = InstitucionDataAccess.GetByAetitle(byIdAndAcc.aetitle);
            foreach (VisorDomain visorDomain in (IEnumerable<VisorDomain>)VisorDataAccess.GetAllForState(1))
            {
                InstitucionVisorDomain institucionAndVisor = InstitucionVisorDataAccess.GetAllForInstitucionAndVisor(byAetitle.id_institucion, visorDomain.id_visor);
                if (institucionAndVisor.id_institucion_visor > 0)
                {
                    if (byAetitle.flagContingencia == 1)
                    {
                        if (visorDomain.id_visor == 6)
                            str = institucionAndVisor.url.Replace("#AETITLE#", byAetitle.aetitle).Replace("#CODEXAMEN#", byIdAndAcc.codexamen).Replace("#modalidad#", byIdAndAcc.modalidad);
                    }
                    else
                        str = "https://demo.irad.cl/MultiRisWeb_DownLoad/Download.aspx?codexamen=" + byIdAndAcc.codexamen + "&aetitle=" + byIdAndAcc.aetitle + "&";
                }
            }
            return str;
        }

        [WebMethod]
        public static JsonResult EliminaFiltro(int filtroId, string usuario)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            long num = 0;
            try
            {
                FiltroDomain byIdAndUser = FiltroDataAccess.GetByIdAndUser((long)filtroId, long.Parse(ListaExamen.Desencriptar(usuario)));
                if (byIdAndUser.id_filtro > 0L)
                {
                    byIdAndUser.id_estado = 0;
                    num = FiltroDataAccess.Save(byIdAndUser);
                }
                return new JsonResult()
                {
                    Data = (object)new ResponseApp()
                    {
                        Ejecutado = true,
                        Mensaje = "",
                        Data = (object)num.ToString()
                    }
                };
            }
            catch (Exception ex)
            {
                return new JsonResult()
                {
                    Data = (object)new ResponseApp()
                    {
                        Ejecutado = false,
                        Mensaje = ex.Message.ToString(),
                        Data = (object)null
                    }
                };
            }
        }

        [WebMethod]
        public static JsonResult ObtieneMisFiltros(string usuario)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            try
            {
                IList<FiltroDomain> byUserAndState = FiltroDataAccess.GetByUserAndState(Convert.ToInt64(ListaExamen.Desencriptar(usuario)), 1);
                byUserAndState = (from c in byUserAndState
                                  where c.tipo_filtro == "Personal"
                                  select c).ToList();

                return new JsonResult()
                {
                    Data = (object)new ResponseApp()
                    {
                        Ejecutado = true,
                        Mensaje = "",
                        Data = (object)byUserAndState
                    }
                };
            }
            catch (Exception ex)
            {
                return new JsonResult()
                {
                    Data = (object)new ResponseApp()
                    {
                        Ejecutado = false,
                        Mensaje = ex.Message.ToString(),
                        Data = (object)null
                    }
                };
            }
        }

        [WebMethod]
        public static JsonResult GuardaFiltro(RequestFiltro filters)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            try
            {
                int sw = 0;
                FiltroDomain filtro = new FiltroDomain();
                filtro.id_filtro = filters.filtroId.Equals("0") ? 0L : (long)int.Parse(filters.filtroId);
                filtro.nombre = filters.nombre.Replace("P - ", "").ToUpper();
                filtro.id_usuario = long.Parse(ListaExamen.Desencriptar(filters.usuario));
                filtro.id_estado = 1;
                filtro.tipo_filtro = "Personal";
                long num = FiltroDataAccess.Save(filtro);
                if (filtro.id_filtro.Equals(num))
                    sw = 1;
                string filtro_institucion = string.Empty;
                string filtro_modalidad = string.Empty;
                string filtro_tipo_urgencia = string.Empty;
                string filtro_usuario = string.Empty;
                string filtro_estado = string.Empty;
                int id;
                foreach (Generico generico in filters.institucion)
                {
                    string str1 = filtro_institucion;
                    string str2;
                    if (!filtro_institucion.Equals(""))
                    {
                        id = generico.id;
                        str2 = string.Format(",{0}", (object)id.ToString());
                    }
                    else
                    {
                        id = generico.id;
                        str2 = id.ToString();
                    }
                    filtro_institucion = str1 + str2;
                }
                foreach (Generico generico in filters.modalidad)
                {
                    string str3 = filtro_modalidad;
                    string str4;
                    if (!filtro_modalidad.Equals(""))
                    {
                        id = generico.id;
                        str4 = string.Format(",{0}", (object)id.ToString());
                    }
                    else
                    {
                        id = generico.id;
                        str4 = id.ToString();
                    }
                    filtro_modalidad = str3 + str4;
                }
                foreach (Generico generico in filters.atencion)
                {
                    string str5 = filtro_tipo_urgencia;
                    string str6;
                    if (!filtro_tipo_urgencia.Equals(""))
                    {
                        id = generico.id;
                        str6 = string.Format(",{0}", (object)id.ToString());
                    }
                    else
                    {
                        id = generico.id;
                        str6 = id.ToString();
                    }
                    filtro_tipo_urgencia = str5 + str6;
                }
                foreach (Generico generico in filters.medico)
                {
                    string str7 = filtro_usuario;
                    string str8;
                    if (!filtro_usuario.Equals(""))
                    {
                        id = generico.id;
                        str8 = string.Format(",{0}", (object)id.ToString());
                    }
                    else
                    {
                        id = generico.id;
                        str8 = id.ToString();
                    }
                    filtro_usuario = str7 + str8;
                }
                foreach (Generico generico in filters.estado)
                {
                    string str9 = filtro_estado;
                    string str10;
                    if (!filtro_estado.Equals(""))
                    {
                        id = generico.id;
                        str10 = string.Format(",{0}", (object)id.ToString());
                    }
                    else
                    {
                        id = generico.id;
                        str10 = id.ToString();
                    }
                    filtro_estado = str9 + str10;
                }
                if (!filtro_institucion.Equals(string.Empty))
                    FiltroInstitucionDataAccess.Save(filtro_institucion, int.Parse(num.ToString()), sw);
                if (!filtro_modalidad.Equals(string.Empty))
                    FiltroModalidadDataAccess.Save(filtro_modalidad, int.Parse(num.ToString()), sw);
                if (!filtro_tipo_urgencia.Equals(string.Empty))
                    FiltroTipoUrgenciaDataAccess.Save(filtro_tipo_urgencia, int.Parse(num.ToString()), sw);
                if (!filtro_usuario.Equals(string.Empty))
                    FiltroUsuarioDataAccess.Save(filtro_usuario, int.Parse(num.ToString()), sw);
                if (!filtro_estado.Equals(string.Empty))
                    FiltroEstadoDataAccess.Save(filtro_estado, int.Parse(num.ToString()), sw);
                return new JsonResult()
                {
                    Data = (object)new ResponseApp()
                    {
                        Ejecutado = true,
                        Mensaje = "",
                        Data = (object)num
                    }
                };
            }
            catch (Exception ex)
            {
                return new JsonResult()
                {
                    Data = (object)new ResponseApp()
                    {
                        Ejecutado = false,
                        Mensaje = ex.Message.ToString(),
                        Data = (object)null
                    }
                };
            }
        }

        [WebMethod]
        public static JsonResult SeleccionFiltro(string userId, string filtroId)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            try
            {
                FiltroDomain byIdAndUser = FiltroDataAccess.GetByIdAndUser(Convert.ToInt64(filtroId), Convert.ToInt64(ListaExamen.Desencriptar(userId)));
                ++byIdAndUser.veces_usado;
                byIdAndUser.fecha_ultimo_uso = DateTime.Now;
                FiltroDataAccess.Save(byIdAndUser);
                List<Generico> genericoList1 = new List<Generico>();
                foreach (FiltroInstitucionDomain institucionDomain in (IEnumerable<FiltroInstitucionDomain>)FiltroInstitucionDataAccess.GetCollectionByIdFiltro(byIdAndUser.id_filtro))
                    genericoList1.Add(new Generico()
                    {
                        id = institucionDomain.id_institucion
                    });
                List<Generico> genericoList2 = new List<Generico>();
                foreach (FiltroModalidadDomain filtroModalidadDomain in (IEnumerable<FiltroModalidadDomain>)FiltroModalidadDataAccess.GetCollectionByIdFiltro(byIdAndUser.id_filtro))
                    genericoList2.Add(new Generico()
                    {
                        id = filtroModalidadDomain.id_modalidad
                    });
                List<Generico> genericoList3 = new List<Generico>();
                foreach (FiltroTipoUrgenciaDomain tipoUrgenciaDomain in (IEnumerable<FiltroTipoUrgenciaDomain>)FiltroTipoUrgenciaDataAccess.GetCollectionByIdFiltro(byIdAndUser.id_filtro))
                    genericoList3.Add(new Generico()
                    {
                        id = tipoUrgenciaDomain.id_tipo_urgencia
                    });
                List<Generico> genericoList4 = new List<Generico>();
                foreach (FiltroUsuarioDomain filtroUsuarioDomain in (IEnumerable<FiltroUsuarioDomain>)FiltroUsuarioDataAccess.GetCollectionByIdFiltro(byIdAndUser.id_filtro))
                    genericoList4.Add(new Generico()
                    {
                        id = int.Parse(filtroUsuarioDomain.id_usuario.ToString())
                    });
                List<Generico> genericoList5 = new List<Generico>();
                foreach (FiltroEstadoDomain filtroEstadoDomain in (IEnumerable<FiltroEstadoDomain>)FiltroEstadoDataAccess.GetCollectionByIdFiltro(byIdAndUser.id_filtro))
                    genericoList5.Add(new Generico()
                    {
                        id = int.Parse(filtroEstadoDomain.id_estado_examen.ToString())
                    });
                MultiRisWeb.ResponseEntity.Request request = new MultiRisWeb.ResponseEntity.Request()
                {
                    usuario = ListaExamen.Encriptar(userId),
                    institucion = genericoList1.ToArray(),
                    modalidad = genericoList2.ToArray(),
                    atencion = genericoList3.ToArray(),
                    medico = genericoList4.ToArray(),
                    estado = genericoList5.ToArray()
                };
                return new JsonResult()
                {
                    Data = (object)new ResponseApp()
                    {
                        Ejecutado = true,
                        Mensaje = "",
                        Data = (object)request
                    }
                };
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return new JsonResult()
                {
                    Data = (object)new ResponseApp()
                    {
                        Ejecutado = false,
                        Mensaje = ex.Message.ToString(),
                        Data = (object)null
                    }
                };
            }
        }

        [WebMethod(EnableSession = true)]
        public static JsonResult ConsultaComentarios(string idExamen, string codigo)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            ResponseModalDT responseModalDt = new ResponseModalDT()
            {
                comentario = "",
                bloqueo = "0"
            };
            int id_institucion = 0;
            string cod_examen = (string)null;
            string str = (string)null;
            foreach (DataRow row in (InternalDataCollectionBase)RisExamenDataAccess.GetByFilterMultiRisWebParaComentarios(codigo).Rows)
            {
                cod_examen = row["codexamen"].ToString();
                str = row["numeroacceso"].ToString();
                id_institucion = Convert.ToInt32(row["id_institucion"].ToString());
            }
            InstitucionDomain idConComentarios = InstitucionDataAccess.GetByIdConComentarios(id_institucion);
            DataTable dataTable = new DataTable();
            if (idConComentarios.id_institucion > 0)
            {
                InstitucionDatosDomain methodAndInstitucion = InstitucionDatosDataAccess.GetByIdMethodAndInstitucion(7, idConComentarios.id_institucion);
                switch (idConComentarios.id_tipo_conexion)
                {
                    case 1:
                        string json = "{" + string.Format("codExamen: {0}, numeroAcceso: {1}", (object)cod_examen, (object)str) + "}";
                        ConsumirApi consumirApi = new ConsumirApi();
                        dataTable = new ConsumirApi().ApiObtenerDataTable(methodAndInstitucion.url, methodAndInstitucion.metodo, json, idConComentarios.id_institucion);
                        break;
                    case 2:
                        if (ConfigurationManager.AppSettings["ActivarWSAPISalida"].ToString().Equals("1") && idConComentarios.flagObtenerComentarios.Equals(0))
                        {
                            dataTable = ConsumirWS.GetComentarios(idConComentarios.id_institucion, cod_examen, str);
                            break;
                        }
                        break;
                }
                responseModalDt.comentario = dataTable.Rows.Count.ToString();
                RisExamenDomain byIdAndAcc = RisExamenDataAccess.GetByIdAndAcc((long)Convert.ToDouble(codigo), str);
                DateTime now = DateTime.Now;
                int num = (now - byIdAndAcc.fecha_bloqueo).Seconds + (now - byIdAndAcc.fecha_bloqueo).Days * 86400 + (now - byIdAndAcc.fecha_bloqueo).Minutes * 60 + (now - byIdAndAcc.fecha_bloqueo).Hours * 3600;
                responseModalDt.bloqueo = "0";
                try
                {
                    if (int.Parse(responseModalDt.comentario) > 0)
                    {
                        if (byIdAndAcc.id_estado_examen == 0)
                        {
                            if (byIdAndAcc.bloqueado.Equals(1))
                            {
                                if (num < 15)
                                {
                                    if (byIdAndAcc.id_usuario_bloqueo.ToString().Equals((object)1))
                                    {
                                        responseModalDt.bloqueo = "1";
                                        responseModalDt.comentario = "0";
                                    }
                                }
                            }
                        }
                    }
                }
                catch
                {
                    responseModalDt.bloqueo = "0";
                    responseModalDt.comentario = "0";
                }
            }
            return new JsonResult()
            {
                Data = (object)new ResponseApp()
                {
                    Ejecutado = true,
                    Mensaje = "",
                    Data = (object)responseModalDt
                }
            };
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public static async Task<JsonResult> AsyncConsultaComentariosAPI(string codExamen, string numAcceso, string url, string metodo, int institucion)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            string _mensaje = "";
            bool _ejecucion = true;
            ResponseModalDT _response = new ResponseModalDT()
            {
                comentario = "0",
                bloqueo = "0"
            };
            try
            {
                ResponseModalDT responseModalDt = _response;
                responseModalDt.comentario = (await new ConsumirApi().ApiDataTable(url, metodo, "{" + string.Format("codExamen: {0}, numeroAcceso: {1}", (object)codExamen, (object)numAcceso) + "}", institucion)).Rows.Count.ToString();
                responseModalDt = (ResponseModalDT)null;
            }
            catch (Exception ex)
            {
                _mensaje = ex.Message.ToString();
                _ejecucion = false;
                _response.bloqueo = "0";
                _response.comentario = "0";
            }
            JsonResult jsonResult1 = new JsonResult()
            {
                Data = (object)new ResponseApp()
                {
                    Ejecutado = _ejecucion,
                    Mensaje = _mensaje,
                    Data = (object)_response
                }
            };
            _mensaje = (string)null;
            _response = (ResponseModalDT)null;
            JsonResult jsonResult2 = jsonResult1;
            _mensaje = (string)null;
            _response = (ResponseModalDT)null;
            return jsonResult2;
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public static async Task<JsonResult> AsyncConsultaComentariosWS(
          string codExamen,
          string numAcceso,
          int institucion)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            string _mensaje = "";
            bool _ejecucion = true;
            ResponseModalDT _response = new ResponseModalDT()
            {
                comentario = "0",
                bloqueo = "0"
            };
            if (ConfigurationManager.AppSettings["ActivarWSAPISalida"].ToString().Equals("1"))
            {
                try
                {
                    ResponseModalDT responseModalDt = _response;
                    responseModalDt.comentario = (await ConsumirWS.GetComentariosWS(institucion, codExamen, numAcceso)).Rows.Count.ToString();
                    responseModalDt = (ResponseModalDT)null;
                }
                catch (Exception ex)
                {
                    _mensaje = ex.Message.ToString();
                    _ejecucion = false;
                    _response.bloqueo = "0";
                    _response.comentario = "0";
                }
            }
            JsonResult jsonResult1 = new JsonResult()
            {
                Data = (object)new ResponseApp()
                {
                    Ejecutado = _ejecucion,
                    Mensaje = _mensaje,
                    Data = (object)_response
                }
            };
            _mensaje = (string)null;
            _response = (ResponseModalDT)null;
            JsonResult jsonResult2 = jsonResult1;
            _mensaje = (string)null;
            _response = (ResponseModalDT)null;
            return jsonResult2;
        }

        [WebMethod]
        public static JsonResult ModificaPrestacion(
          string prestacion,
          string accion,
          string risExamen,
          string estado,
          string usuario,
          string id)
        {
            try
            {
                int num1 = 0;
                string[] strArray1 = accion.Split(',');
                string[] strArray2 = prestacion.Split(',');
                string[] strArray3 = id.Split(',');
                for (int index = 0; index < strArray2.Length; ++index)
                {
                    int num2 = int.Parse(strArray1[index]);
                    long num3 = num2.Equals(1) ? long.Parse(strArray2[index]) : long.Parse(strArray3[index]);
                    num2 = ExamenPrestacionMantenedorDataAccess.MantenedorSave(new RisExamenPrestacionDomain()
                    {
                        id_prestacion = num3,
                        id_ris_examen = (long)int.Parse(risExamen),
                        username = ListaExamen.Desencriptar(usuario).ToString()
                    }, int.Parse(strArray1[index]), estado);
                    if (num2.Equals(0))
                        num1 = 1;
                }
                return new JsonResult()
                {
                    Data = (object)new ResponseApp()
                    {
                        Ejecutado = true,
                        Mensaje = (num1.Equals(1) ? "Algunas prestaciones no pueden ser borradas por encontrarse validadas" : "OK"),
                        Data = (object)null
                    }
                };
            }
            catch (Exception ex)
            {
                return new JsonResult()
                {
                    Data = (object)new ResponseApp()
                    {
                        Ejecutado = false,
                        Mensaje = ex.Message.ToString(),
                        Data = (object)null
                    }
                };
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public static async Task<JsonResult> AsyncConsultaComentarios(string codigo, string usuario)
        {
            if (HttpContext.Current.Session["id_usuario"] == null) HttpContext.Current.Response.Redirect("../../Default.aspx");

            int _timeBloqueo = Convert.ToInt16(ConfigurationManager.AppSettings["TimeBloqueo"].ToString());

            ResponseModalDT _response = new ResponseModalDT()
            {
                comentario = "0",
                bloqueo = "0"
            };

            int id_institucion = 0;
            string cod_examen = (string)null;
            string numeroAcceso = (string)null;
            foreach (DataRow row in (InternalDataCollectionBase)RisExamenDataAccess.GetByFilterMultiRisWebParaComentarios(codigo).Rows)
            {
                cod_examen = row["codexamen"].ToString();
                numeroAcceso = row["numeroacceso"].ToString();
                id_institucion = Convert.ToInt32(row["id_institucion"].ToString());
            }
            InstitucionDomain idConComentarios = InstitucionDataAccess.GetByIdConComentarios(id_institucion);
            DataTable dataTable = new DataTable();
            if (idConComentarios.id_institucion > 0)
            {
                InstitucionDatosDomain methodAndInstitucion = InstitucionDatosDataAccess.GetByIdMethodAndInstitucion(7, idConComentarios.id_institucion);
                switch (idConComentarios.id_tipo_conexion)
                {
                    case 1:
                        string json = "{" + string.Format("codExamen: {0}, numeroAcceso: {1}", (object)cod_examen, (object)numeroAcceso) + "}";
                        dataTable = await new ConsumirApi().ApiDataTable(methodAndInstitucion.url, methodAndInstitucion.metodo, json, idConComentarios.id_institucion);
                        break;
                    case 2:
                        if (ConfigurationManager.AppSettings["ActivarWSAPISalida"].ToString().Equals("1") && idConComentarios.flagObtenerComentarios.Equals(0))
                        {
                            dataTable = ConsumirWS.GetComentarios(idConComentarios.id_institucion, cod_examen, numeroAcceso);
                            break;
                        }
                        break;
                }
                
                _response.comentario = dataTable.Rows.Count.ToString();
                
                RisExamenDomain byIdAndAcc = RisExamenDataAccess.GetByIdAndAcc((long)Convert.ToDouble(codigo), numeroAcceso);
                DateTime now = DateTime.Now;
                TimeSpan timeSpan = now - byIdAndAcc.fecha_bloqueo;
                int seconds = timeSpan.Seconds;
                timeSpan = now - byIdAndAcc.fecha_bloqueo;
                int num1 = timeSpan.Days * 86400;
                int num2 = seconds + num1;
                timeSpan = now - byIdAndAcc.fecha_bloqueo;
                int num3 = timeSpan.Minutes * 60;
                int num4 = num2 + num3;
                timeSpan = now - byIdAndAcc.fecha_bloqueo;
                int num5 = timeSpan.Hours * 3600;
                int num6 = num4 + num5;
                
                _response.bloqueo = "0";
                
                try
                {
                    if (int.Parse(_response.comentario) > 0)
                    {
                        if (byIdAndAcc.id_estado_examen == 0)
                        {
                            if (byIdAndAcc.bloqueado.Equals(1))
                            {
                                if (num6 < _timeBloqueo)
                                {
                                    if (byIdAndAcc.id_usuario_bloqueo.ToString().Equals(ListaExamen.Desencriptar(usuario)))
                                        _response.bloqueo = "1";
                                }
                            }
                        }
                    }
                }
                catch
                {
                    _response.bloqueo = "0";
                    _response.comentario = "0";
                }
            }
            JsonResult jsonResult1 = new JsonResult()
            {
                Data = (object)new ResponseApp()
                {
                    Ejecutado = true,
                    Mensaje = "",
                    Data = (object)_response
                }
            };
            _response = (ResponseModalDT)null;
            numeroAcceso = (string)null;
            JsonResult jsonResult2 = jsonResult1;
            _response = (ResponseModalDT)null;
            numeroAcceso = (string)null;
            return jsonResult2;
        }

        [WebMethod]
        public static JsonResult ConsultaExamenes(MultiRisWeb.ResponseEntity.Request simpleFilter)
        {
            if (HttpContext.Current.Session["id_usuario"] == null) HttpContext.Current.Response.Redirect("../../Default.aspx");

            string perfil = simpleFilter.perfil;
            string str1 = ListaExamen.Desencriptar(simpleFilter.visualiza);
            int int32 = Convert.ToInt32(ListaExamen.Desencriptar(simpleFilter.usuario));

            try
            {
                UsuarioDomain byUsername = UsuarioDataAccess.GetByUsername("amis");
                if (simpleFilter.perfil.Equals((object)8))
                {
                    ((IEnumerable<Generico>)simpleFilter.institucion).ToList<Generico>().Add(new Generico()
                    {
                        id = PerfilDataAccess.InstExter((long)int32)
                    });

                    simpleFilter.estado = new Generico[1] { new Generico() { id = 3 } };
                    simpleFilter.medico = new Generico[1] { new Generico() { id = 0 } };
                }
                else if (simpleFilter.medico.Length.Equals(0))
                {
                    if (str1.Equals(PerfilVisualizacionEnum.AmisYMisAsignaciones.ToString()))
                        ((IEnumerable<Generico>)simpleFilter.medico).ToList<Generico>().Add(new Generico() { id = (int)byUsername.id_usuario });
                    else if (str1.Equals(PerfilVisualizacionEnum.AmisYMisAsignaciones.ToString()))
                    {
                        ((IEnumerable<Generico>)simpleFilter.medico).ToList<Generico>().Add(new Generico() { id = (int)byUsername.id_usuario });
                        ((IEnumerable<Generico>)simpleFilter.medico).ToList<Generico>().Add(new Generico() { id = Convert.ToInt32(ListaExamen.Desencriptar(simpleFilter.usuario.ToString())) });
                    }
                    else if (str1.Equals((object)4))
                        ((IEnumerable<Generico>)simpleFilter.medico).ToList<Generico>().Add(new Generico() { id = Convert.ToInt32(ListaExamen.Desencriptar(simpleFilter.usuario.ToString())) });
                }

                long num = int.Parse(perfil) == 9 || int.Parse(perfil) == 7 ? SessionApp.Get<UsuarioDomain>("KeyRadiolpogoBecado").id_usuario : Convert.ToInt64(int32);
                long usuarioBecado = int.Parse(perfil) == 9 || int.Parse(perfil) == 7 ? num : 0L;
                string str2 = "";
                string str3 = "";
                string str4 = "";
                string estadoInformeID = "";
                string str5 = "";
                string str6 = "";

                foreach (Generico generico in simpleFilter.medico)
                    str2 = str2.Equals("") ? generico.id.ToString() : string.Format("{0},{1}", (object)str2, (object)generico.id.ToString());
                foreach (Generico generico in simpleFilter.institucion)
                    str3 = str3.Equals("") ? generico.id.ToString() : string.Format("{0},{1}", (object)str3, (object)generico.id.ToString());
                foreach (Generico generico in simpleFilter.estado)
                    str4 = str4.Equals("") ? generico.id.ToString() : string.Format("{0},{1}", (object)str4, (object)generico.id.ToString());
                foreach (Generico generico in simpleFilter.modalidad)
                    str5 = str5.Equals("") ? generico.id.ToString() : string.Format("{0},{1}", (object)str5, (object)generico.id.ToString());
                foreach (Generico generico in simpleFilter.atencion)
                    str6 = str6.Equals("") ? generico.id.ToString() : string.Format("{0},{1}", (object)str6, (object)generico.id.ToString());

                List<ExamenShow> onject = ExamenShow.ConvertDataTableToOnject(
                    RisExamenDataAccess.GetByFilterMultiRisWebCRM(
                        Convert.ToInt32(simpleFilter.perfil),
                        str2.Equals("") ? "0" : str2,
                        simpleFilter.pagina,
                        simpleFilter.cantidad,
                        simpleFilter.numeroAcceso,
                        simpleFilter.paciente,
                        simpleFilter.nombre,
                        ListaExamen.ParserDateTime(simpleFilter.fechaDesde, " 00:00:00.000"),
                        ListaExamen.ParserDateTime(simpleFilter.fechaHasta, " 23:59:59.000"),
                        str3.Equals("") ? "0" : str3,
                        str4.Equals("") ? "-1" : str4,
                        estadoInformeID,
                        str5.Equals("") ? "0" : str5,
                        str6.Equals("") ? "0" : str6,
                        simpleFilter.descripcion,
                        simpleFilter.rangoEtario,
                        (long)int32,
                        simpleFilter.pendiente,
                        usuarioBecado)
                    );

                return new JsonResult()
                {
                    Data = (object)new ResponseApp()
                    {
                        Ejecutado = true,
                        Mensaje = "",
                        Data = (object)onject.ToArray()
                    }
                };
            }
            catch (Exception ex)
            {
                return new JsonResult()
                {
                    Data = (object)new ResponseApp()
                    {
                        Ejecutado = false,
                        Mensaje = ex.Message.ToString(),
                        Data = (object)null
                    }
                };
            }
        }

        [WebMethod]
        public static JsonResult ConsultaTotalRegistros(MultiRisWeb.ResponseEntity.Request simpleFilter)
        {
            if (HttpContext.Current.Session["id_usuario"] == null) HttpContext.Current.Response.Redirect("../../Default.aspx");

            string perfil = simpleFilter.perfil;
            string str1 = ListaExamen.Desencriptar(simpleFilter.visualiza);
            int int32 = Convert.ToInt32(ListaExamen.Desencriptar(simpleFilter.usuario));

            try
            {
                UsuarioDomain byUsername = UsuarioDataAccess.GetByUsername("amis");

                if (simpleFilter.perfil.Equals((object)8))
                {
                    ((IEnumerable<Generico>)simpleFilter.institucion).ToList<Generico>().Add(new Generico()
                    {
                        id = PerfilDataAccess.InstExter((long)int32)
                    });
                    simpleFilter.estado = new Generico[1]
                    {
            new Generico() { id = 3 }
                    };
                    simpleFilter.medico = new Generico[1]
                    {
            new Generico() { id = 0 }
                    };
                }
                else if (simpleFilter.medico.Length.Equals(0))
                {
                    if (str1.Equals(PerfilVisualizacionEnum.AmisYMisAsignaciones.ToString()))
                        ((IEnumerable<Generico>)simpleFilter.medico).ToList<Generico>().Add(new Generico()
                        {
                            id = (int)byUsername.id_usuario
                        });
                    else if (str1.Equals(PerfilVisualizacionEnum.AmisYMisAsignaciones.ToString()))
                    {
                        ((IEnumerable<Generico>)simpleFilter.medico).ToList<Generico>().Add(new Generico()
                        {
                            id = (int)byUsername.id_usuario
                        });
                        ((IEnumerable<Generico>)simpleFilter.medico).ToList<Generico>().Add(new Generico()
                        {
                            id = Convert.ToInt32(ListaExamen.Desencriptar(simpleFilter.usuario.ToString()))
                        });
                    }
                    else if (str1.Equals((object)4))
                        ((IEnumerable<Generico>)simpleFilter.medico).ToList<Generico>().Add(new Generico()
                        {
                            id = Convert.ToInt32(ListaExamen.Desencriptar(simpleFilter.usuario.ToString()))
                        });
                }

                long num = perfil.Equals((object)PerfilUsuarioEnum.MedicoRadiologoBecadoValidador) || perfil.Equals((object)PerfilUsuarioEnum.MedicoRadiologoBecado) ? SessionApp.Get<UsuarioDomain>("KeyRadiolpogoBecado").id_usuario : Convert.ToInt64(int32);
                long usuarioBecado = int.Parse(perfil) == 9 || int.Parse(perfil) == 7 ? num : 0L;

                if (!perfil.Equals((object)PerfilUsuarioEnum.MedicoRadiologoBecadoValidador)) perfil.Equals((object)PerfilUsuarioEnum.MedicoRadiologoBecado);

                string str2 = "";
                string str3 = "";
                string str4 = "";
                string estadoInformeID = "";
                string str5 = "";
                string str6 = "";

                foreach (Generico generico in simpleFilter.medico)
                    str2 = str2.Equals("") ? generico.id.ToString() : string.Format("{0},{1}", (object)str2, (object)generico.id.ToString());

                foreach (Generico generico in simpleFilter.institucion)
                    str3 = str3.Equals("") ? generico.id.ToString() : string.Format("{0},{1}", (object)str3, (object)generico.id.ToString());

                foreach (Generico generico in simpleFilter.estado)
                    str4 = str4.Equals("") ? generico.id.ToString() : string.Format("{0},{1}", (object)str4, (object)generico.id.ToString());

                foreach (Generico generico in simpleFilter.modalidad)
                    str5 = str5.Equals("") ? generico.id.ToString() : string.Format("{0},{1}", (object)str5, (object)generico.id.ToString());

                foreach (Generico generico in simpleFilter.atencion)
                    str6 = str6.Equals("") ? generico.id.ToString() : string.Format("{0},{1}", (object)str6, (object)generico.id.ToString());

                string str7 = RisExamenDataAccess.GetMultiRisWebPaginadoCRM(
                                    Convert.ToInt32(simpleFilter.perfil),
                                    str2.Equals("") ? "0" : str2,
                                    simpleFilter.numeroAcceso,
                                    simpleFilter.paciente,
                                    simpleFilter.nombre,
                                    str3.Equals("") ? "0" : str3,
                                    str4.Equals("") ? "-1" : str4,
                                    estadoInformeID,
                                    ListaExamen.ParserDateTime(simpleFilter.fechaDesde, " 00:00:00.000"),
                                    ListaExamen.ParserDateTime(simpleFilter.fechaHasta, " 23:59:59.000"),
                                    str5.Equals("") ? "0" : str5,
                                    str6.Equals("") ? "0" : str6,
                                    simpleFilter.descripcion,
                                    simpleFilter.rangoEtario,
                                    (long)int32,
                                    simpleFilter.pendiente,
                                    usuarioBecado).Rows[0][0].ToString();

                return new JsonResult()
                {
                    Data = (object)new ResponseApp()
                    {
                        Ejecutado = true,
                        Mensaje = "",
                        Data = (object)str7
                    }
                };
            }
            catch (Exception ex)
            {
                return new JsonResult()
                {
                    Data = (object)new ResponseApp()
                    {
                        Ejecutado = false,
                        Mensaje = ex.Message.ToString(),
                        Data = (object)null
                    }
                };
            }
        }

        [WebMethod]
        public static string CargaEstado()
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            try
            {
                return ListaExamen.ConvertDataTableToJson(RisEstadoExamenDataAccess.ListarTodo());
            }
            catch (Exception ex)
            {
                return ListaExamen.ConvertSimpleToJason("", false, ex.Message.ToString());
            }
        }

        [WebMethod]
        public static JsonResult CargaMedico(
          string visualiza,
          string userId,
          int perfil,
          string username)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            IList<UsuarioDomain> source = (IList<UsuarioDomain>)null;
            int int32 = Convert.ToInt32(ListaExamen.Desencriptar(visualiza));
            int _userId = Convert.ToInt32(ListaExamen.Desencriptar(userId));
            string _username = ListaExamen.Desencriptar(username);
            try
            {
                UsuarioDataAccess.GetAll();
                switch (int32)
                {
                    case 1:
                        source = (IList<UsuarioDomain>)UsuarioDataAccess.GetAll().Where<UsuarioDomain>((System.Func<UsuarioDomain, bool>)(row =>
                      {
                          if (!row.estado.Equals(1))
                              return false;
                          return row.id_perfil.Equals(3) || row.id_perfil.Equals(7) || row.id_perfil.Equals(6) || row.id_perfil.Equals(10);
                      })).ToList<UsuarioDomain>();
                        break;
                    case 2:
                        source = (IList<UsuarioDomain>)UsuarioDataAccess.GetAll().Where<UsuarioDomain>((System.Func<UsuarioDomain, bool>)(row => row.username.Equals("Amis"))).ToList<UsuarioDomain>();
                        break;
                    case 3:
                        source = (IList<UsuarioDomain>)UsuarioDataAccess.GetAll().Where<UsuarioDomain>((System.Func<UsuarioDomain, bool>)(row => row.username.Equals("Amis") || row.id_usuario.Equals((long)_userId))).ToList<UsuarioDomain>();
                        break;
                    case 4:
                        source = (IList<UsuarioDomain>)UsuarioDataAccess.GetAll().Where(w => w.id_usuario == int.Parse(HttpContext.Current.Session["medico"].ToString())).ToList();
                        break;
                }
                return new JsonResult()
                {
                    Data = (object)new ResponseApp()
                    {
                        Ejecutado = true,
                        Mensaje = "",
                        Data = (object)source.ToArray<UsuarioDomain>()
                    }
                };
            }
            catch (Exception ex)
            {
                return new JsonResult()
                {
                    Data = (object)new ResponseApp()
                    {
                        Ejecutado = false,
                        Mensaje = ex.Message.ToString(),
                        Data = (object)null
                    }
                };
            }
        }

        [WebMethod]
        public static string CargaAtencion(int estado)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            try
            {
                return ListaExamen.ConvertDataTableToJson(TipoUrgenciaDataAccess.ListarPorEstado(estado));
            }
            catch (Exception ex)
            {
                return ListaExamen.ConvertSimpleToJason("", false, ex.Message.ToString());
            }
        }

        [WebMethod]
        public static string CargaModalidad(int estado)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            try
            {
                return ListaExamen.ConvertDataTableToJson(ModalidadDataAccess.ListarPorEstado(estado));
            }
            catch (Exception ex)
            {
                return ListaExamen.ConvertSimpleToJason("", false, ex.Message.ToString());
            }
        }

        [WebMethod]
        public static string CargaInstitucion(string usuario)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            try
            {
                return ListaExamen.ConvertDataTableToJson(UsuarioInstitucionDataAccess.ListByUserAndInstActive((long)int.Parse(ListaExamen.Desencriptar(usuario))));
            }
            catch (Exception ex)
            {
                return ListaExamen.ConvertSimpleToJason("", false, ex.Message.ToString());
            }
        }

        [WebMethod]
        public static JsonResult CargaEstadoPendiente()
        {
            if (HttpContext.Current.Session["id_usuario"] == null) HttpContext.Current.Response.Redirect("../../Default.aspx");

            try
            {
                return new JsonResult() { Data = new ResponseApp() { Ejecutado = true, Mensaje = "", Data = EstadoPendienteDataAccess.Get() } };
            }
            catch (Exception ex)
            {
                return new JsonResult() { Data = new ResponseApp() { Ejecutado = false, Mensaje = ex.Message.ToString(), Data = null } };
            }
        }

        [WebMethod]
        public static string ExtraeDiasExamen(string user)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            try
            {
                return ListaExamen.ConvertSimpleToJason(UsuarioDataAccess.GetById(Convert.ToInt64(ListaExamen.Desencriptar(user))).dias_examenes.ToString(), true, "");
            }
            catch (Exception ex)
            {
                return ListaExamen.ConvertSimpleToJason("", false, ex.Message.ToString());
            }
        }

        [WebMethod]
        public static JsonResult CargaFiltros(string user)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            try
            {
                IList<FiltroDomain> byUserAndState = FiltroDataAccess.GetByUserAndState(Convert.ToInt64(ListaExamen.Desencriptar(user)), 1);
                byUserAndState.Add(new FiltroDomain()
                {
                    id_filtro = 0L,
                    nombre = "Ninguno",
                    tipo_filtro = ""
                });
                FiltroDomain[] array = byUserAndState.OrderBy<FiltroDomain, long>((System.Func<FiltroDomain, long>)(x => x.id_filtro)).ToArray<FiltroDomain>();
                return new JsonResult()
                {
                    Data = (object)new ResponseApp()
                    {
                        Ejecutado = true,
                        Mensaje = "",
                        Data = (object)array
                    }
                };
            }
            catch (Exception ex)
            {
                return new JsonResult()
                {
                    Data = (object)new ResponseApp()
                    {
                        Ejecutado = false,
                        Mensaje = ex.Message.ToString(),
                        Data = (object)null
                    }
                };
            }
        }

        private static string ConvertDataTableToJson(DataTable dTable)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            JObject jobject = new JObject();
            try
            {
                string json = ListaExamen.DataTableToJson(dTable);
                jobject.Add("Ejecutado", (JToken)true);
                jobject.Add("Mensaje", (JToken)"");
                jobject.Add("JData", (JToken)json);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return jobject.ToString(Formatting.Indented);
        }

        private static string DataTableToJson(DataTable dTable)
        {
            if (HttpContext.Current.Session["id_usuario"] == null) HttpContext.Current.Response.Redirect("../../Default.aspx");

            if (dTable == null || dTable.Rows.Count < 1) return "[]";

            JArray jarray = new JArray();

            foreach (DataRow row in (InternalDataCollectionBase)dTable.Rows)
            {
                JObject jobject = new JObject();

                foreach (DataColumn column in (InternalDataCollectionBase)dTable.Columns)
                    jobject.Add(column.ColumnName, (JToken)row[column.ColumnName]?.ToString());

                jarray.Add((JToken)jobject);
            }

            return jarray.ToString(Formatting.Indented);
        }

        private static string ConvertSimpleToJason(string data, bool sw, string message)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            return new JObject()
      {
        {
          "Ejecutado",
          (JToken) sw
        },
        {
          "Mensaje",
          (JToken) message
        },
        {
          "JData",
          (JToken) data
        }
      }.ToString(Formatting.Indented);
        }

        private static string ParserDateTime(string fechaIngreso, string hora)
        {
            if (HttpContext.Current.Session["id_usuario"] == null) HttpContext.Current.Response.Redirect("../../Default.aspx");

            try
            {
                if (!(fechaIngreso != "")) return DateTime.Now.ToString();

                fechaIngreso = fechaIngreso.Replace("-", "");
                fechaIngreso = fechaIngreso.Replace("/", "");

                string str = fechaIngreso.Substring(4, 4);
                
                return fechaIngreso.Substring(2, 2) + "-" + fechaIngreso.Substring(0, 2) + "-" + str + " " + hora;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                Log.Error(ex, message);
                ex.ToString();
                
                return DateTime.Now.ToString();
            }
        }

        public static string Encriptar(string cadena)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            string empty = string.Empty;
            return Convert.ToBase64String(Encoding.Unicode.GetBytes(cadena));
        }

        private static string Desencriptar(string cadena)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            string empty = string.Empty;
            return Encoding.Unicode.GetString(Convert.FromBase64String(cadena));
        }

        [WebMethod]
        public static void SetSession(MultiRisWeb.ResponseEntity.Request request)
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            string str1 = string.Empty;
            string str2 = string.Empty;
            string str3 = string.Empty;
            string str4 = string.Empty;
            string str5 = string.Empty;
            foreach (Generico generico in request.institucion)
                str1 = str1.Equals(string.Empty) ? generico.id.ToString() : string.Format("{0},{1}", (object)str1, (object)generico.id.ToString());
            foreach (Generico generico in request.modalidad)
                str2 = str2.Equals(string.Empty) ? generico.id.ToString() : string.Format("{0},{1}", (object)str2, (object)generico.id.ToString());
            foreach (Generico generico in request.atencion)
                str3 = str3.Equals(string.Empty) ? generico.id.ToString() : string.Format("{0},{1}", (object)str3, (object)generico.id.ToString());
            foreach (Generico generico in request.medico)
                str4 = str4.Equals(string.Empty) ? generico.id.ToString() : string.Format("{0},{1}", (object)str4, (object)generico.id.ToString());
            foreach (Generico generico in request.estado)
                str5 = str5.Equals(string.Empty) ? generico.id.ToString() : string.Format("{0},{1}", (object)str5, (object)generico.id.ToString());
            HttpContext.Current.Session["returpage"] = (object)1;
            HttpContext.Current.Session["institucion"] = (object)str1;
            HttpContext.Current.Session["fechaInicio"] = (object)request.fechaDesde;
            HttpContext.Current.Session["fechaTermino"] = (object)request.fechaHasta;
            HttpContext.Current.Session["periodo"] = (object)request.periodo;
            HttpContext.Current.Session["modalidad"] = (object)str2;
            HttpContext.Current.Session["atencion"] = (object)str3;
            HttpContext.Current.Session["medico"] = (object)str4;
            HttpContext.Current.Session["estado"] = (object)str5;
            HttpContext.Current.Session["paciente"] = (object)request.paciente;
            HttpContext.Current.Session["nombre"] = (object)request.nombre;
            HttpContext.Current.Session["numeroAcceso"] = (object)request.numeroAcceso;
            HttpContext.Current.Session["tipoExamen"] = (object)request.periodo;
            HttpContext.Current.Session["descripcion"] = (object)request.descripcion;
            HttpContext.Current.Session["rangoEtario"] = (object)request.rangoEtario;
            HttpContext.Current.Session["opfiltro"] = (object)request.opfiltro;
            HttpContext.Current.Session["cantida"] = (object)request.cantidad;
            HttpContext.Current.Session["pagina"] = (object)request.pagina;
        }

        [WebMethod(EnableSession = true)]
        public static JsonResult GetSession()
        {
            if (HttpContext.Current.Session["id_usuario"] == null)
                HttpContext.Current.Response.Redirect("../../Default.aspx");
            List<Generico> genericoList1 = new List<Generico>();
            List<Generico> genericoList2 = new List<Generico>();
            List<Generico> genericoList3 = new List<Generico>();
            List<Generico> genericoList4 = new List<Generico>();
            List<Generico> genericoList5 = new List<Generico>();
            string str1 = HttpContext.Current.Session["institucion"].ToString();
            char[] chArray1 = new char[1] { ',' };
            foreach (string s in str1.Split(chArray1))
            {
                if (!s.Equals(string.Empty))
                    genericoList1.Add(new Generico()
                    {
                        id = int.Parse(s)
                    });
            }
            string str2 = HttpContext.Current.Session["modalidad"].ToString();
            char[] chArray2 = new char[1] { ',' };
            foreach (string s in str2.Split(chArray2))
            {
                if (!s.Equals(string.Empty))
                    genericoList2.Add(new Generico()
                    {
                        id = int.Parse(s)
                    });
            }
            string str3 = HttpContext.Current.Session["atencion"].ToString();
            char[] chArray3 = new char[1] { ',' };
            foreach (string s in str3.Split(chArray3))
            {
                if (!s.Equals(string.Empty))
                    genericoList3.Add(new Generico()
                    {
                        id = int.Parse(s)
                    });
            }
            string str4 = HttpContext.Current.Session["medico"].ToString();
            char[] chArray4 = new char[1] { ',' };
            foreach (string s in str4.Split(chArray4))
            {
                if (!s.Equals(string.Empty))
                    genericoList4.Add(new Generico()
                    {
                        id = int.Parse(s)
                    });
            }
            string str5 = HttpContext.Current.Session["estado"].ToString();
            char[] chArray5 = new char[1] { ',' };
            foreach (string s in str5.Split(chArray5))
            {
                if (!s.Equals(string.Empty))
                    genericoList5.Add(new Generico()
                    {
                        id = int.Parse(s)
                    });
            }
            return new JsonResult()
            {
                Data = (object)new ResponseApp()
                {
                    Ejecutado = true,
                    Mensaje = "",
                    Data = (object)new MultiRisWeb.ResponseEntity.Request()
                    {
                        institucion = genericoList1.ToArray(),
                        modalidad = genericoList2.ToArray(),
                        atencion = genericoList3.ToArray(),
                        medico = genericoList4.ToArray(),
                        estado = genericoList5.ToArray(),
                        fechaDesde = HttpContext.Current.Session["fechaInicio"].ToString(),
                        fechaHasta = HttpContext.Current.Session["fechaTermino"].ToString(),
                        periodo = HttpContext.Current.Session["periodo"].ToString(),
                        paciente = HttpContext.Current.Session["paciente"].ToString(),
                        nombre = HttpContext.Current.Session["nombre"].ToString(),
                        numeroAcceso = HttpContext.Current.Session["numeroAcceso"].ToString(),
                        descripcion = HttpContext.Current.Session["descripcion"].ToString(),
                        rangoEtario = int.Parse(HttpContext.Current.Session["rangoEtario"].ToString()),
                        cantidad = int.Parse(HttpContext.Current.Session["cantida"].ToString()),
                        pagina = int.Parse(HttpContext.Current.Session["pagina"].ToString()),
                        opfiltro = (HttpContext.Current.Session["opfiltro"] != null ? int.Parse(HttpContext.Current.Session["opfiltro"].ToString()) : 0)
                    }
                }
            };
        }
        [WebMethod(EnableSession = true)]
        [HttpGet]
        public static ResponseApp SolicitudAdeendum()
        {
            if (HttpContext.Current.Session["id_usuario"] == null) HttpContext.Current.Response.Redirect("../../Default.aspx");

            UsuarioDomain byId = UsuarioDataAccess.GetById(Convert.ToInt64(HttpContext.Current.Session["id_usuario"]));
            List<SolicitudAddendumInstitucionDomain> source = SolicitudAddendumInstitucionAccess.ListarSolicitudAdd(0, 1, byId.id_perfil, byId.username,0);

            return new ResponseApp()
            {
                Ejecutado = source.Any<SolicitudAddendumInstitucionDomain>(),
                Mensaje = source.Any<SolicitudAddendumInstitucionDomain>() ? "" : "No se encontraron resultados segun los parametros de busqueda ingresados",
                Data = (object)source
            };
        }
    }
}
