// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Web.Configuracion.Instituciones
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using MultiRisWeb.Data.DataAccess;
using MultiRisWeb.Data.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultiRisWeb.Web.Configuracion
{
  public class Instituciones : Page
  {
    protected TextBox txtFiltro;
    protected Button btnFiltrar;
    protected GridView gvDatos;
    protected TextBox txtNombreInstitucion;
    protected TextBox txtdescripcion;
    protected TextBox txtUrlPagina;
    protected TextBox txtAetitle;
    protected TextBox txtUrlDescarga;
    protected TextBox txtUrlInforme;
    protected TextBox txtUrlBase;
    protected TextBox txtUrlInformeOIT;
    protected TextBox txtUrlWSInstitucion;
    protected TextBox txtInstitucionPadre;
    protected TextBox txtLogo;
    protected TextBox txtEstruturaHTML;
    protected TextBox txtMargenSuperior;
    protected TextBox txtMargenInferior;
    protected TextBox txtMargenIzquierda;
    protected TextBox txtMargenDerecha;
    protected TextBox txtCodigoQA;
    protected TextBox txtTipoBecado;
    protected TextBox txtGrupo;
    protected TextBox txtCorreoPatologia;
    protected TextBox txtCorreoPatologiaCC;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.IsPostBack)
        return;
      if (this.Request.UrlReferrer == (Uri) null)
        this.Response.Redirect("../../Default.aspx");
      UsuarioDomain byId = UsuarioDataAccess.GetById(Convert.ToInt64(this.Session["id_usuario"]));
      if (byId.id_perfil == 1 && byId.estado == 1)
        this.cargarDatos(this.txtFiltro.Text);
      else
        this.Response.Redirect("../Control/CerrarSesion.aspx");
    }

    private void cargarDatos(string filtro)
    {
      this.gvDatos.DataSource = (object) InstitucionDataAccess.GetAllFiltro(this.txtFiltro.Text);
      this.gvDatos.DataBind();
    }

    [WebMethod]
    public static ArrayList cargarInstitucion(int id_institucion)
    {
      ArrayList arrayList = new ArrayList();
      InstitucionDomain byIdAdmin = InstitucionDataAccess.GetByIdAdmin(id_institucion);
      arrayList.Add((object) new
      {
        nombre = byIdAdmin.nombre,
        descripcion = byIdAdmin.descripcion,
        estado = byIdAdmin.estado,
        urlPagina = byIdAdmin.url_pagina,
        aetitle = byIdAdmin.aetitle,
        urlDescarga = byIdAdmin.url_descarga,
        urlInforme = byIdAdmin.url_informe,
        urlBase = byIdAdmin.url_base,
        id_tipo_conexion = byIdAdmin.id_tipo_conexion,
        addendum = byIdAdmin.addendum,
        formulario_unico = byIdAdmin.formulario_unico,
        url_informe_oit = byIdAdmin.url_informe_oit,
        id_institucion_padre = byIdAdmin.id_institucion_padre,
        logo = byIdAdmin.logo,
        estrutura = byIdAdmin.estructura,
        margen_superior = byIdAdmin.margen_superior,
        margen_inferior = byIdAdmin.margen_inferior,
        margen_izquierda = byIdAdmin.margen_izquierda,
        margen_derecha = byIdAdmin.margen_derecha,
        codigo_qr = byIdAdmin.codigo_qr,
        id_tipo_becado = byIdAdmin.id_tipo_becado,
        id_grupo = byIdAdmin.id_grupo,
        correo_patologia_critica = byIdAdmin.correo_patologia_critica,
        correo_patologia_criticaCC = byIdAdmin.correo_cc_patologia_critica,
        url_wsInstitucion = byIdAdmin.url_wsInstitucion,
        contingencia = byIdAdmin.flagContingencia
      });
      return arrayList;
    }

    private static bool ValidadGuardaInstitucion(string nombre, string aetitle) => !aetitle.Equals(string.Empty) || !nombre.Equals(string.Empty);

    [WebMethod]
    public static bool CrearInstitucion(
      int id_institucion,
      string nombre,
      string descripcion,
      int estado,
      string url_pagina,
      string aetitle,
      string url_descarga,
      string url_informe,
      string url_base,
      int id_tipo_conexion,
      int addendum,
      int formulario_unico,
      string url_informe_oit)
    {
      InstitucionDomain byId = InstitucionDataAccess.GetById(id_institucion);
      byId.nombre = nombre;
      byId.descripcion = descripcion;
      byId.estado = estado;
      byId.url_pagina = url_pagina;
      byId.aetitle = aetitle;
      byId.url_descarga = url_descarga;
      byId.url_informe = url_informe;
      byId.url_base = url_base;
      byId.id_tipo_conexion = id_tipo_conexion;
      byId.addendum = addendum;
      byId.formulario_unico = formulario_unico;
      byId.url_informe_oit = url_informe_oit;
      return InstitucionDataAccess.Create(byId) > 0;
    }

    [WebMethod]
    public static long guardarInstitucion(
      int id_institucion,
      string nombre,
      string descripcion,
      int estado,
      string url_pagina,
      string aetitle,
      string url_descarga,
      string url_informe,
      string url_base,
      int id_tipo_conexion,
      int addendum,
      int formulario_unico,
      int contingencia,
      string url_informe_oit,
      int id_institucion_padre,
      string logo,
      string estrutura,
      int margen_superior,
      int margen_inferior,
      int margen_izquierda,
      int margen_derecha,
      string codigo_qr,
      int id_tipo_becado,
      int id_grupo,
      string correo_patologia_critica,
      string correo_patologia_criticaCC,
      string url_wsInstitucion)
    {
      long num = 0;
      try
      {
        if (!Instituciones.ValidadGuardaInstitucion(nombre, aetitle))
          return -2;
        InstitucionDomain byId = InstitucionDataAccess.GetById(id_institucion);
        byId.nombre = nombre;
        byId.descripcion = descripcion;
        byId.estado = estado;
        byId.url_pagina = url_pagina;
        byId.aetitle = aetitle;
        byId.url_descarga = url_descarga;
        byId.url_informe = url_informe;
        byId.url_base = url_base;
        byId.id_tipo_conexion = id_tipo_conexion;
        byId.addendum = addendum;
        byId.formulario_unico = formulario_unico;
        byId.url_informe_oit = url_informe_oit;
        byId.flagContingencia = contingencia;
        byId.id_institucion_padre = id_institucion_padre;
        byId.logo = logo;
        byId.estructura = estrutura.Replace("'", "\"");
        byId.margen_superior = margen_superior;
        byId.margen_inferior = margen_inferior;
        byId.margen_izquierda = margen_izquierda;
        byId.margen_derecha = margen_derecha;
        byId.codigo_qr = codigo_qr;
        byId.id_tipo_becado = id_tipo_becado;
        byId.id_grupo = id_grupo;
        byId.correo_patologia_critica = correo_patologia_critica;
        byId.correo_cc_patologia_critica = correo_patologia_criticaCC;
        byId.url_wsInstitucion = url_wsInstitucion;
        byId.flagContingencia = contingencia;
        num = InstitucionDataAccess.SaveModal(byId);
      }
      catch (Exception ex)
      {
        Instituciones.LogError(ex, "Page_Load", id_institucion);
      }
      return num;
    }

    public static void LogError(Exception ex, string paginaEvento, int id_usuario) => ControlErrorDataAccess.ControlErrorSave(ex.HResult, ex.GetType().Name, ex.Message, 1, paginaEvento, id_usuario);

    protected void gvDatos_Sorting(object sender, GridViewSortEventArgs e)
    {
      if (this.Session["direction"].ToString().Equals("0"))
        this.Session["direction"] = (object) "Asc";
      else if (this.Session["direction"].ToString() == "Asc")
        this.Session["direction"] = (object) "Desc";
      else if (this.Session["direction"].ToString() == "Desc")
        this.Session["direction"] = (object) "Asc";
      this.gvDatos.DataSource = (object) new DataView(InstitucionDataAccess.GetAllDataTable())
      {
        Sort = (e.SortExpression + " " + this.Session["direction"].ToString())
      };
      this.gvDatos.DataBind();
    }

    protected void btnFiltrar_Click(object sender, EventArgs e) => this.cargarDatos(this.txtFiltro.Text);

    protected void gvDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      DataTable allDataTable = InstitucionDataAccess.GetAllDataTable();
      this.gvDatos.PageIndex = e.NewPageIndex;
      this.gvDatos.DataSource = (object) allDataTable;
      this.gvDatos.DataBind();
    }

    protected void gvDatos_Sorting1(object sender, GridViewSortEventArgs e)
    {
      if (this.Session["direction"].ToString().Equals("0"))
        this.Session["direction"] = (object) "Asc";
      else if (this.Session["direction"].ToString() == "Asc")
        this.Session["direction"] = (object) "Desc";
      else if (this.Session["direction"].ToString() == "Desc")
        this.Session["direction"] = (object) "Asc";
      DataTable allDataTable = InstitucionDataAccess.GetAllDataTable();
      List<DataRow> dataRowList = new List<DataRow>();
      foreach (DataRow row in (InternalDataCollectionBase) allDataTable.Rows)
        dataRowList.Add(row);
      this.gvDatos.DataSource = (object) new DataView(allDataTable)
      {
        Sort = (e.SortExpression + " " + this.Session["direction"].ToString())
      };
      this.gvDatos.DataBind();
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
    }
  }
}
