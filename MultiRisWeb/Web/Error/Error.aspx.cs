// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Web.Error.Error
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using MultiRisWeb.Data.DataAccess;
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MultiRisWeb.Web.Error
{
  public class Error : Page
  {
    protected HtmlForm form1;
    protected Image Image2;
    protected Image Image1;
    protected Label Label1;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.IsPostBack)
        return;
      int id_usuario = -1;
      if (this.Session[nameof (Error)] == null)
      {
        this.Label1.Text = "Estimados a ocurrido un error en el sistema. El codigo de error es 000001,  favor enviar este numero al area de soporte del sistema para su analisis. .";
      }
      else
      {
        string s = this.Request.QueryString["cError"].ToString();
        this.Label1.Text = "Estimados a ocurrido un error en el sistema. El codigo de error es " + s + ",  favor enviar este numero al area de soporte del sistema para su analisis. ";
        if (this.Session["id_usuario"] != null)
          id_usuario = int.Parse(this.Session["id_usuario"].ToString());
        ControlErrorDataAccess.ControlErrorSave(int.Parse(s), this.Session["ErrorDescripcion"].ToString(), this.Session[nameof (Error)].ToString(), 1, this.Session["Evento"].ToString(), id_usuario);
        this.Session["ErrorDescripcion"] = (object) null;
        this.Session[nameof (Error)] = (object) null;
        this.Session["Evento"] = (object) null;
      }
    }
  }
}
