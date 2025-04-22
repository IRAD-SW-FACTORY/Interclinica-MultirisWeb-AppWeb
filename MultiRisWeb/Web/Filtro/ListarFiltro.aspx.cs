// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Web.Filtro.ListarFiltro
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using MultiRisWeb.Data.DataAccess;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultiRisWeb.Web.Filtro
{
  public class ListarFiltro : Page
  {
    protected GridView gvDatos;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Session["id_usuario"] != null)
      {
        if (this.IsPostBack)
          return;
        this.cargarDatos();
      }
      else
        this.Response.Redirect("../Control/CerrarSesion.aspx");
    }

    private void cargarDatos()
    {
      this.gvDatos.DataSource = (object) FiltroDataAccess.GetDataTableByUser(Convert.ToInt64(this.Session["id_usuario"].ToString()));
      this.gvDatos.DataBind();
    }
  }
}
