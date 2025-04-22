// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Web.Configuracion.TiempoInstitucion
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
  public class TiempoInstitucion : Page
  {
    private string filtro;
    private clsAccesoBD objConexion = new clsAccesoBD();
    private List<clsInstitucion> Lista = new List<clsInstitucion>();
    private List<clsUrgencia> Lista1 = new List<clsUrgencia>();
    protected TextBox txtFiltro;
    protected Button btnFiltrar;
    protected GridView gvDatos;
    protected DropDownList txtNombreInstitucionAgregar;
    protected DropDownList txtNombreUrgenciaAgregar;
    protected TextBox txtTiempoAgregar;
    protected RegularExpressionValidator RegularExpressionValidator1;
    protected LinkButton LinkButton2;
    protected TextBox txtIdModificarBloqueado;
    protected TextBox txtIdModificar;
    protected DropDownList txtNombreInstitucionModificar;
    protected DropDownList txtNombreUrgenciaModificar;
    protected TextBox txtTiempoModificar;
    protected RegularExpressionValidator RegularExpressionValidator2;
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
        SqlCommand sqlCommand1 = new SqlCommand("sp_RisWeb_ObtenerInstitucion", this.objConexion.cmdBDMultiRis);
        sqlCommand1.CommandType = CommandType.StoredProcedure;
        SqlDataReader sqlDataReader1 = sqlCommand1.ExecuteReader();
        while (sqlDataReader1.Read())
        {
          clsInstitucion clsInstitucion = new clsInstitucion();
          this.txtNombreInstitucionAgregar.Items.Add(clsInstitucion.strNombreInstitucion = sqlDataReader1["nombre"].ToString());
          this.txtNombreInstitucionModificar.Items.Add(clsInstitucion.strNombreInstitucion = sqlDataReader1["nombre"].ToString());
          this.Lista.Add(clsInstitucion);
        }
        sqlDataReader1.Close();
        SqlCommand sqlCommand2 = new SqlCommand("sp_RisWeb_ObtenerUrgencia", this.objConexion.cmdBDMultiRis);
        sqlCommand2.CommandType = CommandType.StoredProcedure;
        SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
        while (sqlDataReader2.Read())
        {
          clsUrgencia clsUrgencia = new clsUrgencia();
          this.txtNombreUrgenciaAgregar.Items.Add(clsUrgencia.strNombreUrgencia = sqlDataReader2["nombre"].ToString());
          this.txtNombreUrgenciaModificar.Items.Add(clsUrgencia.strNombreUrgencia = sqlDataReader2["nombre"].ToString());
          this.Lista1.Add(clsUrgencia);
        }
        sqlDataReader2.Close();
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
      this.gvDatos.DataSource = (object) RisExamenDataAccess.GetByFilterePrestacionesWebTiempo(this.filtro);
      this.gvDatos.DataBind();
    }

    protected void btnFiltrar_Click(object sender, EventArgs e)
    {
    }

    protected void gvDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvDatos.PageIndex = e.NewPageIndex;
      DataTable dataTable = new DataTable();
      this.gvDatos.DataSource = (object) RisExamenDataAccess.GetByFilterePrestacionesWebTiempo(this.filtro);
      this.gvDatos.DataBind();
    }

    protected void gvDatos_Sorting(object sender, GridViewSortEventArgs e)
    {
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
      string nombreInstitucion = this.txtNombreInstitucionAgregar.SelectedItem.Value;
      string text1 = this.txtNombreUrgenciaAgregar.Text;
      string text2 = this.txtTiempoAgregar.Text;
      string nombreUrgencia = text1;
      string tiempo = text2;
      RisExamenDataAccess.GetByCreatePrestacionesWebTiempo(nombreInstitucion, nombreUrgencia, tiempo);
      string script = string.Format("alert('Se crea tiempo de prestacion');");
      this.ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
      this.cargarDatos();
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
      string text1 = this.txtIdModificar.Text;
      string str = this.txtNombreInstitucionModificar.SelectedItem.Value;
      string text2 = this.txtNombreUrgenciaModificar.Text;
      string text3 = this.txtTiempoModificar.Text;
      string nombreInstitucion = str;
      string nombreUrgencia = text2;
      string tiempo = text3;
      RisExamenDataAccess.GetByUpdatePrestacionesWebTiempo(text1, nombreInstitucion, nombreUrgencia, tiempo);
      string script = string.Format("alert('Se modifica tiempo prestacion');");
      this.ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
      this.cargarDatos();
    }
  }
}
