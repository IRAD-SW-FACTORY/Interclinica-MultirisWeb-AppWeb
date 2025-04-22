// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Web.Control.Autenticacion
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using MultiRisWeb.ConsumirServicios;
using MultiRisWeb.Data.DataAccess;
using MultiRisWeb.Data.Domain;
using MultiRisWeb.ResponseEntity;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MultiRisWeb.Web.Control
{
  public class Autenticacion : Page
  {
    protected HtmlForm form1;
    protected Label lblUsuario;
    protected Label lblCelular;
    protected TextBox txtCodigoSms;
    protected Button btnValidar;
    protected Label lblError;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.IsPostBack)
        return;
      UsuarioDomain byId = UsuarioDataAccess.GetById(long.Parse(this.Session["id_usuario"].ToString()));
      this.lblError.Text = string.Empty;
      this.lblUsuario.Text = byId.nombre + " " + byId.apellido_paterno;
      this.lblCelular.Text = this.GetCelular(byId.telefono1);
      int codigo = new Random().Next(11111, 99999);
      this.EnviarRegistrarCodigo(codigo);
      if (this.EnviarCodigoSMS(byId.telefono1, codigo))
        return;
      this.lblError.Text = "No fue posible enviar codigo";
    }

    private string GetCelular(string celular) => celular.Substring(0, 4) + "XXXX" + celular.Substring(celular.Length - 4, 4);

    private bool EnviarRegistrarCodigo(int codigo) => AutenticacionDataAccess.InsertOrUpdate(new AutenticacionDomain()
    {
      IdUsuario = long.Parse(this.Session["id_usuario"].ToString()),
      Codigo = codigo,
      UserAgent = this.Request.UserAgent
    });

    private bool EnviarCodigoSMS(string celular, int codigo)
    {
      ResponseSmsWs result = AutenticacionWS.GetToken().Result;
      return !(result.codigo != "0") && AutenticacionWS.EnviarSms(result.descripcion, celular, codigo.ToString()).Result.codigo == "0";
    }

    protected void btnValidar_Click(object sender, EventArgs e)
    {
      this.lblError.Text = string.Empty;
      long num = long.Parse(this.Session["id_usuario"].ToString());
      string text = this.txtCodigoSms.Text;
      if (string.IsNullOrEmpty(text))
      {
        this.lblError.Text = "Codigo SMS es obligatorio.";
      }
      else
      {
        int result = 0;
        if (!int.TryParse(text, out result))
          this.lblError.Text = "Codigo SMS debe ser solo numerico";
        else if (AutenticacionDataAccess.Validar(num, int.Parse(text)) == null)
        {
          this.lblError.Text = "Codigo SMS no es valido!";
        }
        else
        {
          AutenticacionDataAccess.Update(num);
          UsuarioDomain byId = UsuarioDataAccess.GetById(num);
          if (byId.id_perfil == 7 || byId.id_perfil == 9)
          {
            List<UsuarioRadiologoBecadoDomain> radiologoBecadoDomainList = UsuarioRadiologoBecadoDataAccess.Listar(byId.id_usuario);
            if (radiologoBecadoDomainList.Count > 1)
            {
              this.Response.Redirect("SelecionarRadiologoBecado.aspx");
            }
            else
            {
              SessionApp.Set("KeyRadiolpogoBecado", (object) UsuarioDataAccess.GetById(radiologoBecadoDomainList[0].IdUsuarioRadiologo));
              this.Session["medico"] = (object) radiologoBecadoDomainList[0].IdUsuarioRadiologo;
            }
          }
          this.Response.Redirect("Index.aspx");
        }
      }
    }
  }
}
