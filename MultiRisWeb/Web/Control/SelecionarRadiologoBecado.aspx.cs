// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Web.Control.SelecionarRadiologoBecado
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using MultiRisWeb.Data.DataAccess;
using MultiRisWeb.Data.Domain;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MultiRisWeb.Web.Control
{
  public class SelecionarRadiologoBecado : Page
  {
    protected HtmlForm form1;
    protected Label lblUsername;
    protected DropDownList ddlRadiologo;
    protected Button btnIngresar;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.IsPostBack)
        return;
      List<UsuarioRadiologoBecadoDomain> radiologoBecadoDomainList = UsuarioRadiologoBecadoDataAccess.Listar(long.Parse(this.Session["id_usuario"].ToString()));
      ListItem listItem = new ListItem();
      foreach (UsuarioRadiologoBecadoDomain radiologoBecadoDomain in radiologoBecadoDomainList)
        this.ddlRadiologo.Items.Add(new ListItem()
        {
          Text = radiologoBecadoDomain.NombreRadiologo,
          Value = radiologoBecadoDomain.IdUsuarioRadiologo.ToString()
        });
    }

    protected void btnIngresar_Click(object sender, EventArgs e)
    {
      SessionApp.Set("KeyRadiolpogoBecado", (object) UsuarioDataAccess.GetById(long.Parse(this.ddlRadiologo.SelectedValue)));
      this.Session["medico"] = (object) this.ddlRadiologo.SelectedValue;
      this.Response.Redirect("../../Web/Control/Index.aspx");
    }
  }
}
