// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Web.Control.Index
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using MultiRisWeb.Data.DataAccess;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultiRisWeb.Web.Control
{
  public class Index : Page
  {
    protected Label lblUrgentes;
    protected Label lblHospitalizados;
    protected Label lblAmbulatorios;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Session["id_usuario"] != null)
      {
        if (this.IsPostBack)
          return;
        this.cargarDashboard();
        this.Response.Redirect("../Examen/ListaExamen.aspx");
      }
      else
        this.Response.Redirect("../Control/CerrarSesion.aspx");
    }

    private void cargarDashboard()
    {
      try
      {
        DataTable quantityUsername = RisExamenDataAccess.GetQuantityUsername(UsuarioDataAccess.GetById(Convert.ToInt64(this.Session["id_usuario"].ToString())).username);
        if (quantityUsername.Rows.Count <= 0)
          return;
        foreach (DataRow row in (InternalDataCollectionBase) quantityUsername.Rows)
        {
          this.lblAmbulatorios.Text = row["AMBULATORIO"].ToString();
          this.lblHospitalizados.Text = row["HOSPITALIZADOS"].ToString();
          this.lblUrgentes.Text = row["URGENCIA"].ToString();
        }
      }
      catch (Exception ex)
      {
        this.LogError(ex, "Index CargarDashboard");
      }
    }

    public void LogError(Exception ex, string paginaEvento) => ControlErrorDataAccess.ControlErrorSave(ex.HResult, ex.GetType().Name, ex.Message, 1, paginaEvento, int.Parse(this.Session["id_usuario"].ToString()));
  }
}
