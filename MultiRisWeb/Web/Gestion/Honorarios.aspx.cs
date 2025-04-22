// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Web.Gestion.Honorarios
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using MultiRisWeb.Data.DataAccess;
using MultiRisWeb.Data.Parameters;
using Serilog;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MultiRisWeb.Web.Gestion
{
    public class Honorarios : Page
    {
        public static int numero;
        private string paginaActual;
        private string cantidadDeRegistros;
        private string totalRegistros;
        private string fechaInicio;
        private string fechaFinal;
        protected TextBox txtFechaTermino;
        protected TextBox txtFechaInicio;
        protected Button btnDescargarInforme;
        protected GridView gvDatos;
        protected Label lblNumeroPagina;
        protected Label lblCantidadRegistros;
        protected Label lblTotalRegistros;
        protected LinkButton btnSiguiente;
        protected LinkButton btnAtras;
        protected HtmlGenericControl modalInicioPopUpHabil;
        protected HtmlGenericControl modalInicioPopUpNoHabil;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Request.UrlReferrer == (Uri)null) this.Response.Redirect("../../Default.aspx");
            
            try
            {
                if (this.IsPostBack) return;
        
                if (Honorarios.numero == 0) Honorarios.numero = 1;
                
                this.Session["direction"] = (object) "Asc";
                this.cargarFechas();
                this.cargarDatos(this.txtFechaInicio.Text, this.txtFechaTermino.Text);
            }
            catch (Exception ex)
            {
                this.LogError(ex, nameof (Page_Load));
            }
        }

    public void LogError(Exception ex, string paginaEvento) => ControlErrorDataAccess.ControlErrorSave(ex.HResult, ex.GetType().Name, ex.Message, 1, paginaEvento, int.Parse(this.Session["id_usuario"].ToString()));

    private void cargarDatos(string fechaInicio, string fechaFinal)
    {
      if (fechaInicio.Equals(string.Empty))
      {
        fechaInicio = this.txtFechaInicio.Text;
        fechaFinal = this.txtFechaTermino.Text;
      }
      fechaInicio = string.Format("{0:dd-MM-yyyy}", (object) DateTime.ParseExact(fechaInicio, "yyyy-MM-dd", (IFormatProvider) CultureInfo.InvariantCulture));
      fechaFinal = string.Format("{0:dd-MM-yyyy}", (object) DateTime.ParseExact(fechaFinal, "yyyy-MM-dd", (IFormatProvider) CultureInfo.InvariantCulture));
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = new DataTable();
      DataTable honorariosWebPag = RisExamenDataAccess.GetByFilterHonorariosWebPag(Honorarios.numero, this.ParserDateTime(fechaInicio, " 00:00:00.000"), this.ParserDateTime(fechaFinal, " 23:59:59.000"), this.Session["username"].ToString());
      DataTable webPaginadoFecha = RisExamenDataAccess.GetByFilterHonorariosWebPaginadoFecha(Honorarios.numero, this.ParserDateTime(fechaInicio, " 00:00:00.000"), this.ParserDateTime(fechaFinal, " 23:59:59.000"), this.Session["username"].ToString());
      for (int index = 0; index < webPaginadoFecha.Rows.Count; ++index)
      {
        this.paginaActual = webPaginadoFecha.Rows[index]["PaginaActual"].ToString();
        this.cantidadDeRegistros = webPaginadoFecha.Rows[index]["CantidadDeRegistros"].ToString();
        this.totalRegistros = webPaginadoFecha.Rows[index]["TotalRegistros"].ToString();
      }
      this.lblNumeroPagina.Text = this.paginaActual.ToString();
      this.lblCantidadRegistros.Text = this.cantidadDeRegistros.ToString();
      this.lblTotalRegistros.Text = this.totalRegistros.ToString();
      this.gvDatos.DataSource = (object) honorariosWebPag;
      this.gvDatos.DataBind();
    }

    private void cargarFechas()
    {
      DateTime now = DateTime.Now;
      this.txtFechaInicio.Text = now.AddDays(0.0).ToString("yyyy/MM/dd");
      this.txtFechaTermino.Text = now.ToString("yyyy/MM/dd");
    }

    protected void btnFiltrarFecha_Click(object sender, EventArgs e)
    {
      try
      {
        this.cargarDatos(this.txtFechaInicio.Text, this.txtFechaTermino.Text);
      }
      catch (Exception ex)
      {
        this.LogError(ex, "Page_Load");
      }
    }

        protected void btnDescargarInforme_Click(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["id_usuario"] == null) HttpContext.Current.Response.Redirect("../../Default.aspx");

            try
            {
                if (this.gvDatos.Rows.Count.Equals(0))
                {
                    System.Web.UI.ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "showalert", "alert('No existen registros cargados para Descargar el Informe.');", true);
                }
                else
                {
                    string script = "CargaDatosActivo();";
                    System.Web.UI.ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "script", script, true);

                    ClsHonorarios clsHonorarios = new ClsHonorarios();

                    this.Response.Clear();
                    this.fechaInicio = string.Format("{0:dd-MM-yyyy}", (object)DateTime.ParseExact(this.txtFechaInicio.Text, "yyyy-MM-dd", (IFormatProvider)CultureInfo.InvariantCulture));
                    this.fechaFinal = string.Format("{0:dd-MM-yyyy}", (object)DateTime.ParseExact(this.txtFechaTermino.Text, "yyyy-MM-dd", (IFormatProvider)CultureInfo.InvariantCulture));

                    DateTime fechaInicio = this.ParserDateTime(this.fechaInicio, " 00:00:00.000");
                    DateTime fechaFinal = this.ParserDateTime(this.fechaFinal, " 23:59:59.000");

                    System.Web.UI.ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "showalert", "alert('La descarga comenzará en breve.');", true);

                    clsHonorarios.descargarExcelHonorarios(fechaInicio, fechaFinal);
                }
            }
            catch (Exception ex)
            {
                this.LogError(ex, "Page_Load");
            }
        }

    protected void btnSiguiente_Click(object sender, EventArgs e)
    {
      try
      {
        if (Honorarios.numero >= 1)
          ++Honorarios.numero;
        this.cargarDatos(this.txtFechaInicio.Text, this.txtFechaTermino.Text);
      }
      catch (Exception ex)
      {
        this.LogError(ex, "Page_Load");
      }
    }

    protected void btnAtras_Click(object sender, EventArgs e)
    {
      try
      {
        if (Honorarios.numero > 1)
          --Honorarios.numero;
        this.cargarDatos(this.txtFechaInicio.Text, this.txtFechaTermino.Text);
      }
      catch (Exception ex)
      {
        this.LogError(ex, "Page_Load");
      }
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
      this.Session["direction"] = (object) "Asc";
      this.cargarFechas();
      this.cargarDatos(string.Empty, string.Empty);
    }

    private DateTime ParserDateTime(string fechaIngreso, string hora)
    {
      try
      {
        if (!(fechaIngreso != ""))
          return DateTime.Now;
        fechaIngreso = fechaIngreso.Replace("-", "");
        fechaIngreso = fechaIngreso.Replace("/", "");
        string str = fechaIngreso.Substring(4, 4);
        return Convert.ToDateTime(fechaIngreso.Substring(0, 2) + "-" + fechaIngreso.Substring(2, 2) + "-" + str + " " + hora);
      }
      catch (Exception ex)
      {
        string message = ex.Message;
        Log.Error(ex, message);
        ex.ToString();
        return DateTime.Now;
      }
    }
    }
}
