// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Web.Configuracion.Prestaciones
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using MultiRisWeb.Data.DataAccess;
using MultiRisWeb.Data.Parameters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultiRisWeb.Web.Configuracion
{
  public class Prestaciones : Page
  {
    private string filtro;
    private clsAccesoBD objConexion = new clsAccesoBD();
    private List<clsInstitucion> Lista = new List<clsInstitucion>();
    protected TextBox txtFiltro;
    protected Button btnFiltrar;
    protected GridView gvDatos;
    protected TextBox txtIdPrestacionRemotaAgregar;
    protected DropDownList lblNombreInstitucionAgregar;
    protected TextBox txtNombrePrestacionAgregar;
    protected TextBox txtcodigoAgregar;
    protected TextBox txtIDPrestacionBloqueadoModificar;
    protected TextBox txtIDPrestacionModificar;
    protected TextBox txtIdPrestacionRemotaModificar;
    protected DropDownList lblNombreInstitucionModificar;
    protected TextBox txtNombrePrestacionModificar;
    protected TextBox txtCodigoModificar;
    protected LinkButton LinkButton1;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Request.UrlReferrer == (Uri) null)
        this.Response.Redirect("../../Default.aspx");
      this.Session["direction"] = (object) "Asc";
      this.cargarDatos();
      try
      {
        this.objConexion.ConectarMultiRis();
        SqlCommand sqlCommand = new SqlCommand("sp_RisWeb_ObtenerInstitucion", this.objConexion.cmdBDMultiRis);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
        while (sqlDataReader.Read())
        {
          clsInstitucion clsInstitucion = new clsInstitucion();
          this.lblNombreInstitucionAgregar.Items.Add(clsInstitucion.strNombreInstitucion = sqlDataReader["nombre"].ToString());
          this.lblNombreInstitucionModificar.Items.Add(clsInstitucion.strNombreInstitucion = sqlDataReader["nombre"].ToString());
          this.Lista.Add(clsInstitucion);
        }
      }
      catch (Exception ex)
      {
      }
      finally
      {
        this.objConexion.DesconectarMultiRis();
      }
    }

    private void cargarDatos()
    {
      this.filtro = this.txtFiltro.Text;
      DataTable dataTable = new DataTable();
      this.gvDatos.DataSource = (object) RisExamenDataAccess.GetByFilterePrestacionesWeb(this.filtro);
      this.gvDatos.DataBind();
    }

    protected void btnCrearPrestacion_Click(object sender, EventArgs e)
    {
    }

    protected void btnFiltrar_Click(object sender, EventArgs e)
    {
    }

    protected void gvDatos_Sorting(object sender, GridViewSortEventArgs e)
    {
      this.Session["direction"].ToString();
      if (this.Session["direction"].ToString() == "Asc")
        this.Session["direction"] = (object) "Desc";
      else if (this.Session["direction"].ToString() == "Desc")
        this.Session["direction"] = (object) "Asc";
      DataTable dataTable = new DataTable();
      this.gvDatos.DataSource = (object) new DataView(RisExamenDataAccess.GetByFilterePrestacionesWeb(this.filtro))
      {
        Sort = (e.SortExpression + " " + this.Session["direction"].ToString())
      };
      this.gvDatos.DataBind();
    }

    protected void gvDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvDatos.PageIndex = e.NewPageIndex;
      DataTable dataTable = new DataTable();
      this.gvDatos.DataSource = (object) RisExamenDataAccess.GetByFilterePrestacionesWeb(this.filtro);
      this.gvDatos.DataBind();
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
      string text1 = this.txtIdPrestacionRemotaAgregar.Text;
      string str = this.lblNombreInstitucionAgregar.SelectedItem.Value;
      string text2 = this.txtNombrePrestacionAgregar.Text;
      string text3 = this.txtcodigoAgregar.Text;
      string nombreInstitucion = str;
      string nombrePrestacion = text2;
      string codigo = text3;
      RisExamenDataAccess.GetByInsertPrestacionesWeb(text1, nombreInstitucion, nombrePrestacion, codigo);
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
      string text1 = this.txtIDPrestacionModificar.Text;
      string text2 = this.txtIdPrestacionRemotaModificar.Text;
      string str = this.lblNombreInstitucionModificar.SelectedItem.Value;
      string text3 = this.txtNombrePrestacionModificar.Text;
      string text4 = this.txtCodigoModificar.Text;
      string idPrestacionRemoto = text2;
      string nombreInstitucion = str;
      string nombrePrestacion = text3;
      string codigo = text4;
      RisExamenDataAccess.GetByUpdatePrestacionesWeb(text1, idPrestacionRemoto, nombreInstitucion, nombrePrestacion, codigo);
      this.cargarDatos();
    }
  }
}
