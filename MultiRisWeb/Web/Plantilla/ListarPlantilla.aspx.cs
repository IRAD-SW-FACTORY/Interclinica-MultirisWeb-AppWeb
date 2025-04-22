// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Web.Plantilla.ListarPlantilla
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using MultiRisWeb.Data.DataAccess;
using MultiRisWeb.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MultiRisWeb.Web.Plantilla
{
  public class ListarPlantilla : Page
  {
    protected DropDownList ddlmodalidad;
    protected GridView gvDatos;
    protected HtmlGenericControl modalInicioPopUpHabil;
    protected HtmlGenericControl modalInicioPopUpNoHabil;

    protected void Page_Load(object sender, EventArgs e)
    {
      try
      {
        if (this.Session["id_usuario"] == null || this.IsPostBack)
          return;
        if (this.Request.UrlReferrer == (Uri) null)
          this.Response.Redirect("../../Default.aspx");
        this.cargarDesplegables();
        this.cargarDatos();
        if (UsuarioDataAccess.GetById(Convert.ToInt64(this.Session["id_usuario"].ToString())).meddreams_automatico != 1)
          return;
        this.EnviarInstruccionMeddreams();
      }
      catch (Exception ex)
      {
        this.LogError(ex, nameof (Page_Load));
      }
    }

    public void LogError(Exception ex, string paginaEvento) => ControlErrorDataAccess.ControlErrorSave(ex.HResult, ex.GetType().Name, ex.Message, 1, paginaEvento, int.Parse(this.Session["id_usuario"].ToString()));

    private void EnviarInstruccionMeddreams()
    {
    }

    private void cargarDatos()
    {
      DataTable dataTable1 = new DataTable();
      dataTable1.Columns.Add("id_plantilla");
      dataTable1.Columns.Add("nombre");
      dataTable1.Columns.Add("modalidad");
      DataTable dataTable2 = new DataTable();
      DataTable dataTable3 = RisPlantillaDataAccess.ListByUserState(Convert.ToInt64(this.Session["id_usuario"].ToString()), 1);
      if (dataTable3 != null)
      {
        foreach (DataRow row1 in (InternalDataCollectionBase) dataTable3.Rows)
        {
          DataRow row2 = dataTable1.NewRow();
          row2["id_plantilla"] = (object) row1["id_plantilla"].ToString();
          row2["nombre"] = (object) row1["nombre"].ToString();
          row2["modalidad"] = (object) string.Empty;
          foreach (PlantillaModalidadDomain plantillaModalidadDomain in (IEnumerable<PlantillaModalidadDomain>) PlantillaModalidadDataAccess.GetByPlantilla(Convert.ToInt64(row1["id_plantilla"].ToString())))
          {
            ModalidadDomain byId = ModalidadDataAccess.GetByID(plantillaModalidadDomain.id_modalidad);
            row2["modalidad"] = !string.IsNullOrEmpty(row2["modalidad"].ToString()) ? (object) (row2["modalidad"]?.ToString() + " - " + byId.nombre) : (object) byId.nombre;
          }
          dataTable1.Rows.Add(row2);
        }
      }
      this.gvDatos.DataSource = (object) dataTable1;
      this.gvDatos.DataBind();
    }

    private void cargarDesplegables()
    {
      this.ddlmodalidad.DataSource = (object) ModalidadDataAccess.ListarPorEstado(1);
      this.ddlmodalidad.DataBind();
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.ddlmodalidad.SelectedValue != "0")
          this.gvDatos.DataSource = (object) RisPlantillaDataAccess.ListByUserStateAndModalidad(Convert.ToInt64(this.Session["id_usuario"].ToString()), this.ddlmodalidad.SelectedValue);
        else
          this.gvDatos.DataSource = (object) RisPlantillaDataAccess.ListByUserState(Convert.ToInt64(this.Session["id_usuario"].ToString()), 1);
        this.gvDatos.DataBind();
      }
      catch (Exception ex)
      {
        this.LogError(ex, "Page_Load");
      }
    }

    protected void gvDatos_Sorting(object sender, GridViewSortEventArgs e)
    {
    }
  }
}
