// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Web.Configuracion.Visores
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using MultiRisWeb.Data.DataAccess;
using MultiRisWeb.Data.Domain;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultiRisWeb.Web.Configuracion
{
  public class Visores : Page
  {
    protected GridView gvDatos;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.IsPostBack)
        return;
      if (this.Request.UrlReferrer == (Uri) null)
        this.Response.Redirect("../../Default.aspx");
      UsuarioDomain byId = UsuarioDataAccess.GetById(Convert.ToInt64(this.Session["id_usuario"]));
      if (byId.id_perfil == 1 && byId.estado == 1)
        this.cargarDatos();
      else
        this.Response.Redirect("../Control/CerrarSesion.aspx");
    }

    private void cargarDatos()
    {
      this.gvDatos.DataSource = (object) VisorDataAccess.GetAllDataTable();
      this.gvDatos.DataBind();
    }

    protected void gvDatos_Sorting(object sender, GridViewSortEventArgs e)
    {
      this.Session["direction"].ToString();
      if (this.Session["direction"].ToString() == "Asc")
        this.Session["direction"] = (object) "Desc";
      else if (this.Session["direction"].ToString() == "Desc")
        this.Session["direction"] = (object) "Asc";
      this.gvDatos.DataSource = (object) new DataView(VisorDataAccess.GetAllDataTable())
      {
        Sort = (e.SortExpression + " " + this.Session["direction"].ToString())
      };
      this.gvDatos.DataBind();
    }
  }
}
