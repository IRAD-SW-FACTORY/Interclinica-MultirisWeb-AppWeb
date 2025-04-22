// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Web.Control.UpdateClaveAcceso
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using MultiRisWeb.Data.DataAccess;
using MultiRisWeb.Data.Domain;
using System;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MultiRisWeb.Web.Control
{
  public class UpdateClaveAcceso : Page
  {
    protected HtmlForm form1;
    protected Label lblUsuario;
    protected TextBox txtPassActual;
    protected TextBox txtPassNueva;
    protected TextBox txtPassNueva2;
    protected Button btnValidar;
    protected Label lblError;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.IsPostBack)
        return;
      UsuarioDomain byId = UsuarioDataAccess.GetById(long.Parse(this.Session["id_usuario"].ToString()));
      this.lblError.Text = string.Empty;
      this.lblUsuario.Text = byId.nombre + " " + byId.apellido_paterno;
    }

    private void Actualizar()
    {
      this.lblError.Text = "";
      string str = this.Validar();
      if (string.IsNullOrEmpty(str))
      {
        long num = long.Parse(this.Session["id_usuario"].ToString());
        if (UsuarioDataAccess.Login(UsuarioDataAccess.GetById(num).username, this.txtPassActual.Text).id_usuario == 0L)
        {
          this.lblError.Text = "- Clave Actual no es correcta.";
        }
        else
        {
          DateTime fechaProxModificacion = DateTime.Now.AddDays((double) int.Parse(WebConfigurationManager.AppSettings["DiasCaducidadClave"].ToString()));
          if (!AutenticacionDataAccess.UpdateClaveAcceso(num, this.txtPassNueva.Text, fechaProxModificacion))
          {
            this.lblError.Text = "No fue posible modificar su clave de acceso favor intentar nuevamente";
            this.txtPassActual.Text = string.Empty;
            this.txtPassNueva.Text = string.Empty;
            this.txtPassNueva2.Text = string.Empty;
          }
          else
          {
            this.Response.AppendHeader("Refresh", "3;url=../../Default.aspx");
            this.lblError.Text = "Clave de acceso se modifico correctamente.";
          }
        }
      }
      else
        this.lblError.Text = str;
    }

    private string Validar()
    {
      string empty = string.Empty;
      if (string.IsNullOrEmpty(this.txtPassActual.Text))
        empty += "- Clave Actual es obligatoria.<br/>";
      if (string.IsNullOrEmpty(this.txtPassNueva.Text))
        empty += "- Clave Nueva es obligatoria.<br/>";
      if (string.IsNullOrEmpty(this.txtPassNueva2.Text))
        empty += "- Reingreso Clave Nueva es obligatoria.<br/>";
      if (!string.IsNullOrEmpty(this.txtPassNueva.Text) && this.txtPassNueva.Text.Length < 8)
        empty += "- Clave Nueva debe ser minimo 8 caracteres.<br/>";
      if (this.txtPassNueva.Text != this.txtPassNueva2.Text)
        empty += "- Clave nueva no es igual al reingreso de nueva clave de acceso.<br/>";
      if (!string.IsNullOrEmpty(this.txtPassActual.Text) && !string.IsNullOrEmpty(this.txtPassNueva.Text) && this.txtPassActual.Text == this.txtPassNueva.Text)
        empty += "- Clave Actual no puede ser igual a Nueva Clave de Acceso.<br/>";
      return empty;
    }

    protected void btnValidar_Click(object sender, EventArgs e) => this.Actualizar();
  }
}
