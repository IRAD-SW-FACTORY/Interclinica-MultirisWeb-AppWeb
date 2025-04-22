// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Web.LogAsignaciones
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using MultiRisWeb.Data.DataAccess;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MultiRisWeb.Web
{
  public class LogAsignaciones : Page
  {
    public static int numero;
    public string paginaActual;
    public string cantidadDeRegistros;
    public string totalRegistros;
    public static int numeroIncremental;
    public static string direccion;
    public static string columna;
    protected TextBox txtFechaInicio;
    protected TextBox txtFechaTermino;
    protected GridView gvDatos;
    protected Label lblNumeroPagina;
    protected Label lblTotalRegistros;
    protected LinkButton btnSiguiente;
    protected LinkButton btnAtras;
    protected HtmlGenericControl modalInicioPopUpHabil;
    protected HtmlGenericControl modalInicioPopUpNoHabil;

    protected void Page_Load(object sender, EventArgs e)
    {
      int int32 = Convert.ToInt32(this.Session["numeroIncremental"]);
      if (this.IsPostBack)
        return;
      if (this.Request.UrlReferrer == (Uri) null)
        this.Response.Redirect("../../Default.aspx");
      if (int32 == 0)
      {
        LogAsignaciones.numeroIncremental = 1;
        HttpContext.Current.Session["numeroIncremental"] = (object) LogAsignaciones.numeroIncremental;
      }
      else
      {
        LogAsignaciones.numeroIncremental = 1;
        HttpContext.Current.Session["numeroIncremental"] = (object) LogAsignaciones.numeroIncremental;
      }
      this.Session["direction"] = (object) "Asc";
      this.cargarDatos("", "");
    }

    private void cargarDatos(string fechaInicio, string fechaFinal)
    {
      fechaInicio = this.txtFechaTermino.Text;
      fechaFinal = this.txtFechaInicio.Text;
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = new DataTable();
      DataTable asignacionesWebPag = RisExamenDataAccess.GetByLogAsignacionesWebPag(Convert.ToInt32(this.Session["numeroIncremental"]), fechaInicio, fechaFinal);
      DataTable honorariosWebPaginado = RisExamenDataAccess.GetByFilterHonorariosWebPaginado(Convert.ToInt32(this.Session["numeroIncremental"]), fechaInicio, fechaFinal, this.Session["username"].ToString());
      for (int index = 0; index < honorariosWebPaginado.Rows.Count; ++index)
      {
        this.paginaActual = honorariosWebPaginado.Rows[index]["PaginaActual"].ToString();
        this.cantidadDeRegistros = honorariosWebPaginado.Rows[index]["CantidadDeRegistros"].ToString();
        this.totalRegistros = honorariosWebPaginado.Rows[index]["TotalRegistros"].ToString();
      }
      this.lblNumeroPagina.Text = this.paginaActual.ToString();
      this.lblTotalRegistros.Text = this.totalRegistros.ToString();
      this.gvDatos.DataSource = (object) asignacionesWebPag;
      this.gvDatos.DataBind();
    }

    protected void Unnamed_Click(object sender, EventArgs e)
    {
      this.txtFechaInicio.Text = "";
      this.txtFechaTermino.Text = "";
      LogAsignaciones.numero = 1;
      HttpContext.Current.Session["numeroIncremental"] = (object) LogAsignaciones.numero;
      this.cargarDatos("", "");
    }

    protected void Unnamed_Click1(object sender, EventArgs e)
    {
      LogAsignaciones.numeroIncremental = 1;
      HttpContext.Current.Session["numeroIncremental"] = (object) LogAsignaciones.numeroIncremental;
      this.cargarDatos(this.txtFechaInicio.Text, this.txtFechaTermino.Text);
    }

    protected void btnSiguiente_Click(object sender, EventArgs e)
    {
      DataTable dataTable = new DataTable();
      DataTable honorariosWebPaginado = RisExamenDataAccess.GetByFilterHonorariosWebPaginado(Convert.ToInt32(this.Session["numeroIncremental"]), this.txtFechaTermino.Text, this.txtFechaInicio.Text, this.Session["username"].ToString());
      for (int index = 0; index < honorariosWebPaginado.Rows.Count; ++index)
      {
        this.paginaActual = honorariosWebPaginado.Rows[index]["PaginaActual"].ToString();
        this.cantidadDeRegistros = honorariosWebPaginado.Rows[index]["CantidadDeRegistros"].ToString();
        this.totalRegistros = honorariosWebPaginado.Rows[index]["TotalRegistros"].ToString();
      }
      if (Convert.ToInt32(this.totalRegistros) >= Convert.ToInt32(this.cantidadDeRegistros))
      {
        if (LogAsignaciones.numeroIncremental >= 1)
        {
          ++LogAsignaciones.numeroIncremental;
          HttpContext.Current.Session["numeroIncremental"] = (object) LogAsignaciones.numeroIncremental;
        }
        this.cargarDatos("", "");
      }
      this.cargarDatos("", "");
    }

    protected void btnAtras_Click(object sender, EventArgs e)
    {
      if (LogAsignaciones.numeroIncremental > 1)
      {
        --LogAsignaciones.numeroIncremental;
        HttpContext.Current.Session["numeroIncremental"] = (object) LogAsignaciones.numeroIncremental;
      }
      this.cargarDatos("", "");
    }

    protected void gvDatos_Sorting(object sender, GridViewSortEventArgs e)
    {
    }

    protected void gvDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
    }
  }
}
