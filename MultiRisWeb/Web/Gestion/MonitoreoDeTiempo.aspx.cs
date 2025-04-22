// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Web.Gestion.MonitoreoDeTiempo
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using MultiRisWeb.ConsumirServicios;
using MultiRisWeb.Data.DataAccess;
using MultiRisWeb.Data.Domain;
using MultiRisWeb.Data.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MultiRisWeb.Web.Gestion
{
  public class MonitoreoDeTiempo : Page
  {
    public static int numero;
    public string paginaActual;
    public string cantidadDeRegistros;
    public string totalRegistros;
    public static int numeroIncremental;
    public static string direccion;
    public static string columna;
    public string idFiltro;
    public int cantidadRegistrosSinFormula;
    public int totalRegistrosSinFormula;
    public static int registroPaginaTotal;
    protected GridView gvDatos;
    protected HtmlTableCell FechasExamenInforme;
    protected ListBox Institucion;
    protected TextBox txtFechaDesde;
    protected TextBox txtFechaHasta;
    protected Button btn1Day;
    protected Button btn3Days;
    protected Button btn1Week;
    protected Button btn1Month;
    protected Button btn1Year;
    protected ListBox Modalidad;
    protected ListBox TipoUrgencia;
    protected ListBox Medico;
    protected ListBox Estado;
    protected TextBox txtIdPaciente;
    protected TextBox txtNombre;
    protected TextBox txtNumeroAcceso;
    protected TextBox txtDescripcion;
    protected TextBox txtFiltroNombre;
    protected Button btnGuardarFiltro;
    protected Label lblNumeroPagina;
    protected Label lblCantidadPaginas;
    protected Label lblCantidadRegistros;
    protected Label lblTotalRegistros;
    protected LinkButton btnSiguiente;
    protected LinkButton btnAtras;
    protected HtmlGenericControl modalInicioPopUpHabil;
    protected HtmlGenericControl modalInicioPopUpNoHabil;

    protected void Page_Load(object sender, EventArgs e)
    {
      try
      {
        if (this.Request.UrlReferrer == (Uri) null)
          this.Response.Redirect("../../Default.aspx");
        int num1 = MonitoreoDeTiempo.numeroIncremental = Convert.ToInt32(this.Session["numeroIncremental"]);
        if (this.Session["id_usuario"] == null || this.IsPostBack)
          return;
        if (num1 == 0)
        {
          MonitoreoDeTiempo.numeroIncremental = 1;
          HttpContext.Current.Session["numeroIncremental"] = (object) MonitoreoDeTiempo.numeroIncremental;
        }
        else
        {
          MonitoreoDeTiempo.numeroIncremental = 1;
          HttpContext.Current.Session["numeroIncremental"] = (object) MonitoreoDeTiempo.numeroIncremental;
        }
        this.Session["direction"] = (object) "Asc";
        this.cargarFechas();
        this.cargarDesplegables();
        this.cargarFiltroSession();
        this.SeteaNombreFiltroFechas();
        this.cargarDatos();
        UsuarioDomain byId1 = UsuarioDataAccess.GetById(Convert.ToInt64(this.Session["id_usuario"].ToString()));
        PerfilDomain byId2 = PerfilDataAccess.GetById(byId1.id_perfil);
        if (byId1.meddreams_automatico == 1)
          this.EnviarInstruccionMeddreams();
        int num2 = byId2.asignar ? 1 : 0;
      }
      catch (Exception ex)
      {
        this.LogError(ex, nameof (Page_Load));
      }
    }

    protected void gvDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      try
      {
        this.guardarFiltrosSession();
        UsuarioDomain byId1 = UsuarioDataAccess.GetById(Convert.ToInt64(this.Session["id_usuario"].ToString()));
        PerfilDomain byId2 = PerfilDataAccess.GetById(byId1.id_perfil);
        this.gvDatos.PageIndex = e.NewPageIndex;
        DataTable dataTable = new DataTable();
        if (byId2.id_perfil_visualizacion == 2)
        {
          if (this.Session["medico"].ToString() == string.Empty || this.Session["medico"].ToString() == "0")
            this.Session["medico"] = (object) UsuarioDataAccess.GetByUsername("amis").id_usuario.ToString();
        }
        else if (byId2.id_perfil_visualizacion == 3)
        {
          if (this.Session["medico"].ToString() == string.Empty || this.Session["medico"].ToString() == "0")
          {
            UsuarioDomain byUsername = UsuarioDataAccess.GetByUsername("amis");
            HttpSessionState session = this.Session;
            long idUsuario = byUsername.id_usuario;
            string str1 = idUsuario.ToString();
            idUsuario = byId1.id_usuario;
            string str2 = idUsuario.ToString();
            string str3 = str1 + "," + str2;
            session["medico"] = (object) str3;
          }
        }
        else if (byId2.id_perfil_visualizacion == 4 && (this.Session["medico"].ToString() == string.Empty || this.Session["medico"].ToString() == "0"))
          this.Session["medico"] = (object) byId1.id_usuario;
        if (this.Session["CampoOrden"] != null)
          int.Parse(this.Session["CampoOrden"].ToString());
        int.Parse(this.Session["direction"].ToString());
        this.gvDatos.DataSource = (object) RisExamenDataAccess.GetByFilterMultiRisWebCalculoTiempo(Convert.ToInt32(this.Session["numeroIncremental"]), this.Session["medico"].ToString(), this.txtNumeroAcceso.Text, this.txtIdPaciente.Text, this.txtNombre.Text, this.Session["institucion"].ToString(), this.Session["estado"].ToString(), this.Session["estadoInforme"].ToString(), this.ParserDateTime(this.txtFechaDesde.Text, " 00:00:00.000"), this.ParserDateTime(this.txtFechaHasta.Text, " 23:59:59.000"), this.Session["modalidad"].ToString(), this.Session["atencion"].ToString(), this.txtDescripcion.Text);
        this.gvDatos.DataBind();
      }
      catch (Exception ex)
      {
        this.LogError(ex, nameof (gvDatos_PageIndexChanging));
      }
    }

    protected void gvDatos_Sorting(object sender, GridViewSortEventArgs e)
    {
    }

    protected void gvDatos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }

    protected void btn1Day_Click(object sender, EventArgs e)
    {
      try
      {
        int cantidad = 1;
        this.limpiarSeleccionDias(cantidad);
        this.btn1Day.Attributes.CssStyle.Add("background-color", "#E67C00 !important;");
        this.Session["dias"] = (object) cantidad;
        this.guardarFiltrosSession();
      }
      catch (Exception ex)
      {
        this.LogError(ex, nameof (btn1Day_Click));
      }
    }

    protected void btn3Days_Click(object sender, EventArgs e)
    {
      try
      {
        int cantidad = 3;
        this.limpiarSeleccionDias(cantidad);
        this.btn3Days.Attributes.CssStyle.Add("background-color", "#E67C00 !important;");
        this.Session["dias"] = (object) cantidad;
        this.guardarFiltrosSession();
      }
      catch (Exception ex)
      {
        this.LogError(ex, nameof (btn3Days_Click));
      }
    }

    protected void btn1Week_Click(object sender, EventArgs e)
    {
      try
      {
        int cantidad = 7;
        this.limpiarSeleccionDias(cantidad);
        this.btn1Week.Attributes.CssStyle.Add("background-color", "#E67C00 !important;");
        this.Session["dias"] = (object) cantidad;
        this.guardarFiltrosSession();
      }
      catch (Exception ex)
      {
        this.LogError(ex, nameof (btn1Week_Click));
      }
    }

    protected void btn1Month_Click(object sender, EventArgs e)
    {
      try
      {
        int cantidad = 31;
        this.limpiarSeleccionDias(cantidad);
        this.btn1Month.Attributes.CssStyle.Add("background-color", "#E67C00 !important;");
        this.Session["dias"] = (object) cantidad;
        this.guardarFiltrosSession();
      }
      catch (Exception ex)
      {
        this.LogError(ex, nameof (btn1Month_Click));
      }
    }

    protected void btn1Year_Click(object sender, EventArgs e)
    {
      try
      {
        int cantidad = 365;
        this.limpiarSeleccionDias(cantidad);
        this.btn1Year.Attributes.CssStyle.Add("background-color", "#E67C00 !important;");
        this.Session["dias"] = (object) cantidad;
        this.guardarFiltrosSession();
      }
      catch (Exception ex)
      {
        this.LogError(ex, nameof (btn1Year_Click));
      }
    }

    protected void Unnamed_Click(object sender, EventArgs e)
    {
      try
      {
        MonitoreoDeTiempo.numeroIncremental = 1;
        HttpContext.Current.Session["numeroIncremental"] = (object) MonitoreoDeTiempo.numeroIncremental;
        this.cargarDatos();
        this.limpiarSeleccionFiltro();
      }
      catch (Exception ex)
      {
        this.LogError(ex, nameof (Unnamed_Click));
      }
    }

    protected void Unnamed_Click1(object sender, EventArgs e)
    {
      try
      {
        this.limpiarFiltros();
        this.SeteaNombreFiltroFechas();
        this.cargarFechas();
        this.limpiarSeleccionFiltro();
        this.guardarFiltrosSession();
        this.cargarDatos();
      }
      catch (Exception ex)
      {
        this.LogError(ex, nameof (Unnamed_Click1));
      }
    }

    protected void btnGuardarFiltro_Click(object sender, EventArgs e)
    {
      try
      {
        this.guardarFiltro(0L, 1);
      }
      catch (Exception ex)
      {
        this.LogError(ex, nameof (btnGuardarFiltro_Click));
      }
    }

    protected void btnSiguiente_Click(object sender, EventArgs e)
    {
      try
      {
        this.cargarDatos();
        if (Convert.ToInt32(this.totalRegistros) < Convert.ToInt32(this.cantidadDeRegistros))
          return;
        if (MonitoreoDeTiempo.numeroIncremental >= 1)
        {
          ++MonitoreoDeTiempo.numeroIncremental;
          HttpContext.Current.Session["numeroIncremental"] = (object) MonitoreoDeTiempo.numeroIncremental;
        }
        this.cargarDatos();
      }
      catch (Exception ex)
      {
        this.LogError(ex, nameof (btnSiguiente_Click));
      }
    }

    protected void btnAtras_Click(object sender, EventArgs e)
    {
      try
      {
        if (MonitoreoDeTiempo.numeroIncremental > 1)
        {
          --MonitoreoDeTiempo.numeroIncremental;
          HttpContext.Current.Session["numeroIncremental"] = (object) MonitoreoDeTiempo.numeroIncremental;
        }
        this.cargarDatos();
      }
      catch (Exception ex)
      {
        this.LogError(ex, nameof (btnAtras_Click));
      }
    }

    public void LogError(Exception ex, string paginaEvento) => ControlErrorDataAccess.ControlErrorSave(ex.HResult, ex.GetType().Name, ex.Message, 1, paginaEvento, int.Parse(this.Session["id_usuario"].ToString()));

    private void limpiarFiltros()
    {
      this.txtIdPaciente.Text = "";
      this.txtNumeroAcceso.Text = "";
      this.txtDescripcion.Text = "";
      this.txtNombre.Text = "";
      this.Institucion.ClearSelection();
      this.TipoUrgencia.ClearSelection();
      this.Modalidad.ClearSelection();
      this.Medico.ClearSelection();
      this.Estado.ClearSelection();
    }

    private void limpiarSeleccionDias(int cantidad)
    {
      this.limpiarSeleccionFiltro();
      DateTime now = DateTime.Now;
      this.txtFechaHasta.Text = now.ToString("dd/MM/yyyy");
      this.txtFechaDesde.Text = now.AddDays((double) -cantidad).ToString("dd/MM/yyyy");
      this.cargarDatos();
    }

    public bool guardarFiltro(long id_filtro, int estado)
    {
      this.eliminarFiltros(id_filtro);
      FiltroDomain byId = FiltroDataAccess.GetById(id_filtro);
      byId.nombre = this.txtFiltroNombre.Text == "" ? "Sin Nombre" : this.txtFiltroNombre.Text;
      byId.id_usuario = Convert.ToInt64(this.Session["id_usuario"].ToString());
      byId.id_estado = estado;
      byId.tipo_filtro = "Personal";
      long num = FiltroDataAccess.Save(byId);
      foreach (object obj in ParamUtil.GetValoresStrListbox(this.Estado))
        FiltroEstadoDataAccess.Save(new FiltroEstadoDomain()
        {
          id_filtro_estado = 0L,
          id_filtro = num,
          id_estado_examen = Convert.ToInt32(obj.ToString())
        });
      foreach (object obj in ParamUtil.GetValoresStrListbox(this.Institucion))
        FiltroInstitucionDataAccess.Save(new FiltroInstitucionDomain()
        {
          id_filtro_institucion = 0L,
          id_filtro = num,
          id_institucion = Convert.ToInt32(obj.ToString())
        });
      foreach (object obj in ParamUtil.GetValoresStrListbox(this.Modalidad))
        FiltroModalidadDataAccess.Save(new FiltroModalidadDomain()
        {
          id_filtro_modalidad = 0L,
          id_filtro = num,
          id_modalidad = Convert.ToInt32(obj.ToString())
        });
      foreach (object obj in ParamUtil.GetValoresStrListbox(this.TipoUrgencia))
        FiltroTipoUrgenciaDataAccess.Save(new FiltroTipoUrgenciaDomain()
        {
          id_filtro_tipo_urgencia = 0L,
          id_filtro = num,
          id_tipo_urgencia = Convert.ToInt32(obj.ToString())
        });
      foreach (object obj in ParamUtil.GetValoresStrListbox(this.Medico))
        FiltroUsuarioDataAccess.Save(new FiltroUsuarioDomain()
        {
          id_filtro_usuario = 0L,
          id_filtro = num,
          id_usuario = (long) Convert.ToInt32(obj.ToString())
        });
      this.cargarDatos();
      return true;
    }

    private void eliminarFiltros(long id_filtro)
    {
      FiltroEstadoDataAccess.DeleteByIdFiltro(id_filtro);
      FiltroInstitucionDataAccess.DeleteByIdFiltro(id_filtro);
      FiltroModalidadDataAccess.DeleteByIdFiltro(id_filtro);
      FiltroTipoUrgenciaDataAccess.DeleteByIdFiltro(id_filtro);
      FiltroEstadoInformeDataAccess.DeleteByIdFiltro(id_filtro);
    }

    private void limpiarSeleccionFiltro()
    {
      this.btn1Day.BackColor = Color.Empty;
      this.btn3Days.BackColor = Color.Empty;
      this.btn1Week.BackColor = Color.Empty;
      this.btn1Month.BackColor = Color.Empty;
      this.btn1Year.BackColor = Color.Empty;
      this.btn1Day.Attributes.CssStyle.Remove("background-color");
      this.btn3Days.Attributes.CssStyle.Remove("background-color");
      this.btn1Week.Attributes.CssStyle.Remove("background-color");
      this.btn1Month.Attributes.CssStyle.Remove("background-color");
      this.btn1Year.Attributes.CssStyle.Remove("background-color");
      this.btn1Day.Attributes.CssStyle.Add("background-color", "rgb(101, 96, 95) !important");
      this.btn3Days.Attributes.CssStyle.Add("background-color", "rgb(101, 96, 95) !important");
      this.btn1Week.Attributes.CssStyle.Add("background-color", "rgb(101, 96, 95) !important");
      this.btn1Month.Attributes.CssStyle.Add("background-color", "rgb(101, 96, 95) !important");
      this.btn1Year.Attributes.CssStyle.Add("background-color", "rgb(101, 96, 95) !important");
    }

    private void cargarFechas()
    {
      UsuarioDomain byId = UsuarioDataAccess.GetById(Convert.ToInt64(this.Session["id_usuario"].ToString()));
      DateTime now = DateTime.Now;
      this.txtFechaDesde.Text = now.AddDays((double) -byId.dias_examenes).ToString("dd/MM/yyyy");
      this.txtFechaHasta.Text = now.ToString("dd/MM/yyyy");
    }

    private void cargarDesplegables()
    {
      UsuarioDomain byId1 = UsuarioDataAccess.GetById(Convert.ToInt64(this.Session["id_usuario"].ToString()));
      PerfilDomain byId2 = PerfilDataAccess.GetById(byId1.id_perfil);
      this.Institucion.DataSource = (object) UsuarioInstitucionDataAccess.ListByUserAndInstActive(Convert.ToInt64(this.Session["id_usuario"].ToString()));
      this.Institucion.DataBind();
      this.Estado.DataSource = (object) RisEstadoExamenDataAccess.ListarTodo();
      this.Estado.DataBind();
      this.Modalidad.DataSource = (object) ModalidadDataAccess.ListarPorEstado(1);
      this.Modalidad.DataBind();
      if (byId2.id_perfil_visualizacion == 1)
      {
        IList<UsuarioDomain> all = UsuarioDataAccess.GetAll();
        IList<UsuarioDomain> usuarioDomainList = (IList<UsuarioDomain>) new List<UsuarioDomain>();
        foreach (UsuarioDomain usuarioDomain in (IEnumerable<UsuarioDomain>) all)
        {
          if (usuarioDomain.estado == 1 && (usuarioDomain.id_perfil == 3 || usuarioDomain.id_perfil == 7 || usuarioDomain.id_perfil == 6))
            usuarioDomainList.Add(usuarioDomain);
        }
        this.Medico.DataSource = (object) usuarioDomainList;
        this.Medico.DataBind();
      }
      else if (byId2.id_perfil_visualizacion == 2)
      {
        this.Medico.DataSource = (object) UsuarioDataAccess.GetTableByUsername("Amis");
        this.Medico.DataBind();
      }
      else if (byId2.id_perfil_visualizacion == 3)
      {
        this.Medico.DataSource = (object) UsuarioDataAccess.GetLitByUsernameAndIdUsuario("Amis", byId1.id_usuario);
        this.Medico.DataBind();
      }
      else if (byId2.id_perfil_visualizacion == 4)
      {
        this.Medico.DataSource = (object) UsuarioDataAccess.GetTableByUsername(byId1.username);
        this.Medico.DataBind();
      }
      this.TipoUrgencia.DataSource = (object) TipoUrgenciaDataAccess.ListarPorEstado(1);
      this.TipoUrgencia.DataBind();
    }

    private void cargarFiltroSession()
    {
      if (this.Session["institucion"] != null)
      {
        string[] strArray = this.Session["institucion"].ToString().Split(',');
        this.Institucion.ClearSelection();
        int count = this.Institucion.Items.Count;
        for (int index1 = 0; index1 < count; ++index1)
        {
          for (int index2 = 0; index2 < strArray.Length; ++index2)
          {
            if (this.Institucion.Items[index1].Value == strArray[index2].ToString())
              this.Institucion.Items[index1].Selected = true;
          }
        }
      }
      if (this.Session["dias"] != null)
      {
        DateTime now = DateTime.Now;
        this.txtFechaHasta.Text = now.ToString("dd/MM/yyyy");
        this.txtFechaDesde.Text = now.AddDays((double) -Convert.ToInt32(this.Session["dias"].ToString())).ToString("dd/MM/yyyy");
      }
      else
      {
        if (this.Session["fecha_inicio"] != null)
          this.txtFechaDesde.Text = this.Session["fecha_inicio"].ToString();
        if (this.Session["fecha_termino"] != null)
          this.txtFechaHasta.Text = this.Session["fecha_termino"].ToString();
      }
      if (this.Session["id_paciente"] != null)
        this.txtIdPaciente.Text = this.Session["id_paciente"].ToString();
      if (this.Session["nombre"] != null)
        this.txtNombre.Text = this.Session["nombre"].ToString();
      if (this.Session["numero_acceso"] != null)
        this.txtNumeroAcceso.Text = this.Session["numero_acceso"].ToString();
      if (this.Session["descripcion"] != null)
        this.txtDescripcion.Text = this.Session["descripcion"].ToString();
      if (this.Session["modalidad"] != null)
      {
        string[] strArray = this.Session["modalidad"].ToString().Split(',');
        this.Modalidad.ClearSelection();
        int count = this.Modalidad.Items.Count;
        for (int index3 = 0; index3 < count; ++index3)
        {
          for (int index4 = 0; index4 < strArray.Length; ++index4)
          {
            if (this.Modalidad.Items[index3].Value == strArray[index4].ToString())
              this.Modalidad.Items[index3].Selected = true;
          }
        }
      }
      if (this.Session["atencion"] != null)
      {
        string[] strArray = this.Session["atencion"].ToString().Split(',');
        this.TipoUrgencia.ClearSelection();
        int count = this.TipoUrgencia.Items.Count;
        for (int index5 = 0; index5 < count; ++index5)
        {
          for (int index6 = 0; index6 < strArray.Length; ++index6)
          {
            if (this.TipoUrgencia.Items[index5].Value == strArray[index6].ToString())
              this.TipoUrgencia.Items[index5].Selected = true;
          }
        }
      }
      if (this.Session["medico"] != null)
      {
        string[] strArray = this.Session["medico"].ToString().Split(',');
        this.Medico.ClearSelection();
        int count = this.Medico.Items.Count;
        for (int index7 = 0; index7 < count; ++index7)
        {
          for (int index8 = 0; index8 < strArray.Length; ++index8)
          {
            if (this.Medico.Items[index7].Value == strArray[index8].ToString())
              this.Medico.Items[index7].Selected = true;
          }
        }
      }
      if (this.Session["estado"] == null)
        return;
      string[] strArray1 = this.Session["estado"].ToString().Split(',');
      this.Estado.ClearSelection();
      int count1 = this.Estado.Items.Count;
      for (int index9 = 0; index9 < count1; ++index9)
      {
        for (int index10 = 0; index10 < strArray1.Length; ++index10)
        {
          if (this.Estado.Items[index9].Value == strArray1[index10].ToString())
            this.Estado.Items[index9].Selected = true;
        }
      }
    }

    private void SeteaNombreFiltroFechas()
    {
    }

    private void cargarDatos()
    {
      this.guardarFiltrosSession();
      UsuarioDomain byId1 = UsuarioDataAccess.GetById(Convert.ToInt64(this.Session["id_usuario"].ToString()));
      PerfilDomain byId2 = PerfilDataAccess.GetById(byId1.id_perfil);
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = new DataTable();
      if (byId2.id_perfil_visualizacion == 2)
      {
        if (this.Session["medico"].ToString() == string.Empty || this.Session["medico"].ToString() == "0")
          this.Session["medico"] = (object) UsuarioDataAccess.GetByUsername("amis").id_usuario.ToString();
      }
      else if (byId2.id_perfil_visualizacion == 3)
      {
        if (this.Session["medico"].ToString() == string.Empty || this.Session["medico"].ToString() == "0")
        {
          UsuarioDomain byUsername = UsuarioDataAccess.GetByUsername("amis");
          HttpSessionState session = this.Session;
          long idUsuario = byUsername.id_usuario;
          string str1 = idUsuario.ToString();
          idUsuario = byId1.id_usuario;
          string str2 = idUsuario.ToString();
          string str3 = str1 + "," + str2;
          session["medico"] = (object) str3;
        }
      }
      else if (byId2.id_perfil_visualizacion == 4 && (this.Session["medico"].ToString() == string.Empty || this.Session["medico"].ToString() == "0"))
        this.Session["medico"] = (object) byId1.id_usuario;
      DataTable webCalculoTiempo = RisExamenDataAccess.GetByFilterMultiRisWebCalculoTiempo(Convert.ToInt32(this.Session["numeroIncremental"]), this.Session["medico"].ToString(), this.txtNumeroAcceso.Text, this.txtIdPaciente.Text, this.txtNombre.Text, this.Session["institucion"].ToString(), this.Session["estado"].ToString(), this.Session["estadoInforme"].ToString(), this.ParserDateTime(this.txtFechaDesde.Text, " 00:00:00.000"), this.ParserDateTime(this.txtFechaHasta.Text, " 23:59:59.000"), this.Session["modalidad"].ToString(), this.Session["atencion"].ToString(), this.txtDescripcion.Text);
      DataTable calculoTiempoPaginado = RisExamenDataAccess.GetByFilterMultiRisWebCalculoTiempoPaginado(Convert.ToInt32(this.Session["numeroIncremental"]), this.Session["medico"].ToString(), this.txtNumeroAcceso.Text, this.txtIdPaciente.Text, this.txtNombre.Text, this.Session["institucion"].ToString(), this.Session["estado"].ToString(), this.Session["estadoInforme"].ToString(), this.ParserDateTime(this.txtFechaDesde.Text, " 00:00:00.000"), this.ParserDateTime(this.txtFechaHasta.Text, " 23:59:59.000"), this.Session["modalidad"].ToString(), this.Session["atencion"].ToString(), this.txtDescripcion.Text);
      for (int index = 0; index < calculoTiempoPaginado.Rows.Count; ++index)
      {
        this.paginaActual = calculoTiempoPaginado.Rows[index]["PaginaActual"].ToString();
        this.cantidadDeRegistros = calculoTiempoPaginado.Rows[index]["CantidadDeRegistros"].ToString();
        this.totalRegistros = calculoTiempoPaginado.Rows[index]["TotalRegistros"].ToString();
        this.cantidadRegistrosSinFormula = Convert.ToInt32(calculoTiempoPaginado.Rows[index]["CantidadDeRegistros"]);
        this.totalRegistrosSinFormula = Convert.ToInt32(calculoTiempoPaginado.Rows[index]["TotalRegistros"]);
      }
      int num1 = this.totalRegistrosSinFormula / int.Parse("20") == 0 ? 1 : this.totalRegistrosSinFormula / int.Parse("20");
      int num2 = this.totalRegistrosSinFormula - num1 * int.Parse("20") > 0 ? num1 + 1 : num1;
      this.lblNumeroPagina.Text = this.paginaActual.ToString();
      this.lblCantidadPaginas.Text = num2.ToString();
      this.lblCantidadRegistros.Text = (int.Parse(this.Session["numeroIncremental"].ToString()) * int.Parse("20") - int.Parse("20") + webCalculoTiempo.Rows.Count).ToString();
      this.lblTotalRegistros.Text = this.totalRegistros.ToString();
      int index1 = 0;
      for (int index2 = 0; index2 < webCalculoTiempo.Rows.Count; ++index2)
      {
        string codExamen = webCalculoTiempo.Rows[index2]["id_ris_examen"].ToString();
        int int32 = Convert.ToInt32(webCalculoTiempo.Rows[index2]["Porcentaje"] is DBNull ? (object) 0 : webCalculoTiempo.Rows[index2]["Porcentaje"]);
        string cod_examen = (string) null;
        string str = (string) null;
        int id_institucion = 0;
        DataTable dataTable3 = new DataTable();
        foreach (DataRow row in (InternalDataCollectionBase) RisExamenDataAccess.GetByFilterMultiRisWebParaComentarios(codExamen).Rows)
        {
          cod_examen = row["codexamen"].ToString();
          str = row["numeroacceso"].ToString();
          id_institucion = Convert.ToInt32(row["id_institucion"].ToString());
        }
        InstitucionDomain byId3 = InstitucionDataAccess.GetById(id_institucion);
        DataTable dataTable4 = new DataTable();
        if (byId3.id_institucion > 0)
        {
          InstitucionDatosDomain methodAndInstitucion = InstitucionDatosDataAccess.GetByIdMethodAndInstitucion(7, byId3.id_institucion);
          if (ConfigurationManager.AppSettings["ActivarWSAPISalida"].ToString().Equals("1"))
          {
            ConsumirWS consumirWs = new ConsumirWS();
            ConsumirApi consumirApi = new ConsumirApi();
            if (byId3.id_tipo_conexion == 1)
            {
              string json = "{\"codExamen\":\"" + codExamen + "\",\"numeroAcceso\":\"" + str + "\"}";
              consumirApi.ApiObtenerDataTable(methodAndInstitucion.url, methodAndInstitucion.metodo, json, byId3.id_institucion);
            }
            else if (byId3.id_tipo_conexion == 2)
            {
              ConsumirWS.GetComentarios(byId3.id_institucion, cod_examen, str).Rows.Count.ToString();
              Convert.ToInt64(HttpContext.Current.Session["id_usuario"].ToString());
              RisExamenDomain byIdAndAcc = RisExamenDataAccess.GetByIdAndAcc((long) Convert.ToDouble(codExamen), str);
              DateTime now = DateTime.Now;
              int seconds = (now - byIdAndAcc.fecha_bloqueo).Seconds;
              int days = (now - byIdAndAcc.fecha_bloqueo).Days;
              TimeSpan timeSpan = now - byIdAndAcc.fecha_bloqueo;
              int minutes = timeSpan.Minutes;
              timeSpan = now - byIdAndAcc.fecha_bloqueo;
              int hours = timeSpan.Hours;
              ++index1;
              webCalculoTiempo.Columns[31].ReadOnly = false;
              webCalculoTiempo.Columns[32].ReadOnly = false;
              webCalculoTiempo.Columns[index1].ReadOnly = false;
              webCalculoTiempo.Columns[2].ReadOnly = false;
              webCalculoTiempo.Columns[1].ReadOnly = false;
              webCalculoTiempo.Columns[3].ReadOnly = false;
              webCalculoTiempo.Columns[4].ReadOnly = false;
              webCalculoTiempo.Columns[5].ReadOnly = false;
              webCalculoTiempo.Columns[6].ReadOnly = false;
              webCalculoTiempo.Columns[7].ReadOnly = false;
              webCalculoTiempo.Columns[8].ReadOnly = false;
              webCalculoTiempo.Columns[0].ReadOnly = false;
              string appSetting1 = ConfigurationManager.AppSettings["Verde"];
              string appSetting2 = ConfigurationManager.AppSettings["Amarillo"];
              string appSetting3 = ConfigurationManager.AppSettings["Rojo"];
              string appSetting4 = ConfigurationManager.AppSettings["Gris"];
              if (int32 == 0)
                webCalculoTiempo.Rows[index1 - 1]["Porcentaje"] = (object) "0";
              else if (int32 >= Convert.ToInt32(appSetting4))
                webCalculoTiempo.Rows[index1 - 1]["Porcentaje"] = (object) "3";
              else if (int32 >= Convert.ToInt32(appSetting1))
                webCalculoTiempo.Rows[index1 - 1]["Porcentaje"] = (object) "0";
              else if (int32 >= Convert.ToInt32(appSetting2))
                webCalculoTiempo.Rows[index1 - 1]["Porcentaje"] = (object) "1";
              else if (int32 >= Convert.ToInt32(appSetting3))
                webCalculoTiempo.Rows[index1 - 1]["Porcentaje"] = (object) "2";
              else if (int32 >= Convert.ToInt32(appSetting4))
                webCalculoTiempo.Rows[index1 - 1]["Porcentaje"] = (object) "3";
              else if (int32 <= Convert.ToInt32(appSetting4))
                webCalculoTiempo.Rows[index1 - 1]["Porcentaje"] = (object) "3";
            }
          }
        }
      }
      this.gvDatos.DataSource = (object) webCalculoTiempo;
      this.gvDatos.DataBind();
      GridViewRowCollection rows = this.gvDatos.Rows;
      foreach (GridViewRow row in this.gvDatos.Rows)
      {
        if (row.Cells[0].Text == "0")
        {
          row.Cells[0].BackColor = Color.SpringGreen;
          row.Cells[0].ForeColor = Color.SpringGreen;
        }
        else if (row.Cells[0].Text == "1")
        {
          row.Cells[0].BackColor = Color.Yellow;
          row.Cells[0].ForeColor = Color.Yellow;
        }
        else if (row.Cells[0].Text == "2")
        {
          row.Cells[0].BackColor = Color.Red;
          row.Cells[0].ForeColor = Color.Red;
        }
        else if (row.Cells[0].Text == "3")
        {
          row.Cells[0].BackColor = Color.Gray;
          row.Cells[0].ForeColor = Color.Gray;
        }
        else if (row.Cells[0].Text == "-53883600")
        {
          row.Cells[0].BackColor = Color.Gray;
          row.Cells[0].ForeColor = Color.Gray;
        }
      }
      int num3 = 0;
      foreach (DataRow row in (InternalDataCollectionBase) webCalculoTiempo.Rows)
      {
        if (Convert.ToInt32(row["id_estado_examen"].ToString()) != 3)
          ++num3;
      }
      this.Session["dias"] = (object) null;
      this.guardarFiltrosSession();
    }

    private void EnviarInstruccionMeddreams()
    {
      MeddreamsUtil meddreamsUtil = new MeddreamsUtil();
    }

    private void guardarFiltrosSession()
    {
      string[] valor1 = ParamUtil.GetValoresStrListbox(this.Modalidad);
      if (valor1.Length == 0)
        valor1 = new string[1]{ "0" };
      string[] valor2 = ParamUtil.GetValoresStrListbox(this.TipoUrgencia);
      if (valor2.Length == 0)
        valor2 = new string[1]{ "0" };
      string[] valor3 = ParamUtil.GetValoresStrListbox(this.Estado);
      if (valor3.Length == 0)
        valor3 = new string[1]{ "-1" };
      string[] valor4 = ParamUtil.GetValoresStrListbox(this.Institucion);
      if (valor4.Length == 0)
        valor4 = new string[1]{ "0" };
      string[] valor5 = ParamUtil.GetValoresStrListbox(this.Medico);
      if (valor5.Length == 0)
        valor5 = new string[1]{ "0" };
      this.Session["institucion"] = (object) ParamUtil.GetInParam(valor4);
      this.Session["fecha_inicio"] = (object) this.txtFechaDesde.Text;
      this.Session["fecha_termino"] = (object) this.txtFechaHasta.Text;
      this.Session["id_paciente"] = (object) this.txtIdPaciente.Text;
      this.Session["nombre"] = (object) this.txtNombre.Text;
      this.Session["numero_acceso"] = (object) this.txtNumeroAcceso.Text;
      this.Session["descripcion"] = (object) this.txtDescripcion.Text;
      this.Session["modalidad"] = (object) ParamUtil.GetInParam(valor1);
      this.Session["atencion"] = (object) ParamUtil.GetInParam(valor2);
      this.Session["medico"] = (object) ParamUtil.GetInParam(valor5);
      this.Session["estado"] = (object) ParamUtil.GetInParam(valor3);
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
        ex.ToString();
        return DateTime.Now;
      }
    }
  }
}
