// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Default
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using MultiRisWeb.Data.DataAccess;
using MultiRisWeb.Data.Domain;
using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Net;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MultiRisWeb
{
    public class Default : Page
    {
        protected HtmlForm form1;
        protected Label lblUsername;
        protected TextBox txtUsername;
        protected Label lblPassword;
        protected TextBox txtPassword;
        protected Label lblMensaje;
        protected Button btnLogin;
        protected HtmlGenericControl modalInicioPopUpHabil;
        protected HtmlGenericControl modalInicioPopUpNoHabil;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack || !(ConfigurationManager.AppSettings["EnCatalogacion"] == "1"))
                return;
            this.Response.Redirect("Catalogacion.aspx");
        }
        private bool validarCampos()
        {
            bool flag = true;
            if (string.IsNullOrEmpty(this.txtUsername.Text))
            {
                flag = false;
                this.validar(this.lblUsername, false);
            }
            else
                this.validar(this.lblUsername, true);
            if (string.IsNullOrEmpty(this.txtPassword.Text))
            {
                flag = false;
                this.validar(this.lblPassword, false);
            }
            else
                this.validar(this.lblPassword, true);
            if (!flag)
            {
                this.lblMensaje.Visible = true;
                this.lblMensaje.Text = "Favor Completar los campos";
            }
            return flag;
        }
        private void validar(Label lbl, bool estado)
        {
            if (estado)
                lbl.ForeColor = Color.White;
            else
                lbl.ForeColor = Color.Red;
        }
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (!this.validarCampos())
                    return;
                UsuarioDomain usuarioDomain = UsuarioDataAccess.Login(this.txtUsername.Text, this.txtPassword.Text);
                if (usuarioDomain.id_usuario > 0L)
                {
                    InsertLogAcceso(usuarioDomain);
                    this.Session["id_usuario"] = (object)usuarioDomain.id_usuario;
                    this.Session["username"] = (object)usuarioDomain.username;
                    this.Session["id_perfil"] = (object)usuarioDomain.id_perfil;
                    DateTime? modificacionPass = usuarioDomain.fecha_modificacion_pass;
                    if (modificacionPass.HasValue)
                    {
                        modificacionPass = usuarioDomain.fecha_modificacion_pass;
                        DateTime now = DateTime.Now;
                        if ((modificacionPass.HasValue ? (modificacionPass.GetValueOrDefault() <= now ? 1 : 0) : 0) != 0)
                            this.Response.Redirect("Web/Control/UpdateClaveAcceso.aspx");
                    }
                    if (AutenticacionConfigDataAccess.Get().Valida == 1 && usuarioDomain.autentica_sms == 1)
                    {
                        AutenticacionDomain autenticacionDomain = AutenticacionDataAccess.Get(usuarioDomain.id_usuario);
                        if (autenticacionDomain == null || autenticacionDomain.CodigoValidado == 0)
                            this.Response.Redirect("Web/Control/Autenticacion.aspx");
                    }
                    if (usuarioDomain.id_perfil == 7 || usuarioDomain.id_perfil == 9)
                    {
                        List<UsuarioRadiologoBecadoDomain> radiologoBecadoDomainList = UsuarioRadiologoBecadoDataAccess.Listar(usuarioDomain.id_usuario);
                        if (radiologoBecadoDomainList.Count > 1)
                        {
                            this.Response.Redirect("Web/Control/SelecionarRadiologoBecado.aspx");
                        }
                        else
                        {
                            SessionApp.Set("KeyRadiolpogoBecado", (object)UsuarioDataAccess.GetById(radiologoBecadoDomainList[0].IdUsuarioRadiologo));
                            this.Session["medico"] = (object)radiologoBecadoDomainList[0].IdUsuarioRadiologo;
                        }
                    }
                    this.Response.Redirect("Web/Control/Index.aspx");
                }
                else
                {                   
                    this.lblMensaje.Text = "Credenciales Incorrectas";
                    this.lblMensaje.Visible = true;
                }
            }
            catch (Exception ex)
            {
                new IradLogFile.LogFile(ex.ToString());
            }
        }
        private void InsertLogAcceso(UsuarioDomain usuario)
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());// objeto para guardar la ip
            string localIP = string.Empty;

            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();// esta es nuestra ip
                }
            }

            LogControlAccesoDomain logControlAcceso = new LogControlAccesoDomain()
            {
                Usuario = usuario.username,
                Nombre = usuario.nombre + " " + usuario.apellido_paterno,
                Perfil = usuario.id_perfil,
                UserAgent = Request.UserAgent,
                Ip = localIP
            };

            LogControlAccesoDataAccess.Insertar(logControlAcceso);
        }
    }
}
