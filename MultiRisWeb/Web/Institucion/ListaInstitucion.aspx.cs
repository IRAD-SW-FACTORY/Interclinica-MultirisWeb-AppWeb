// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Web.Institucion.ListaInstitucion
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using MultiRisWeb.Data.DataAccess;
using MultiRisWeb.Data.Domain;
using System;
using System.Collections;
using System.Data;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultiRisWeb.Web.Institucion
{
  public class ListaInstitucion : Page
  {
    protected GridView gvDatos;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.IsPostBack)
        return;
      UsuarioDomain byId = UsuarioDataAccess.GetById(Convert.ToInt64(this.Session["id_usuario"]));
      if (byId.id_perfil == 1 && byId.estado == 1)
        this.cargarDatos();
      else
        this.Response.Redirect("../Control/CerrarSesion.aspx");
    }

    private void cargarDatos()
    {
      this.gvDatos.DataSource = (object) InstitucionDataAccess.GetAll();
      this.gvDatos.DataBind();
    }

    [WebMethod]
    public static ArrayList cargarInstitucion(int id_institucion)
    {
      ArrayList arrayList = new ArrayList();
      InstitucionDomain byId = InstitucionDataAccess.GetById(id_institucion);
      arrayList.Add((object) new
      {
        nombre = byId.nombre,
        descripcion = byId.descripcion,
        estado = byId.estado,
        urlPagina = byId.url_pagina,
        urlDescarga = byId.url_descarga,
        urlInforme = byId.url_informe,
        urlBase = byId.url_base,
        id_tipo_conexion = byId.id_tipo_conexion,
        addendum = byId.addendum,
        formulario_unico = byId.formulario_unico,
        url_informe_oit = byId.url_informe_oit,
        aetitle = byId.aetitle
      });
      return arrayList;
    }

    [WebMethod]
    public static bool guardarInstitucion(
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
      return InstitucionDataAccess.Save(byId) > 0L;
    }

    protected void gvDatos_Sorting(object sender, GridViewSortEventArgs e)
    {
      this.Session["direction"].ToString();
      if (this.Session["direction"].ToString() == "Asc")
        this.Session["direction"] = (object) "Desc";
      else if (this.Session["direction"].ToString() == "Desc")
        this.Session["direction"] = (object) "Asc";
      this.gvDatos.DataSource = (object) new DataView(InstitucionDataAccess.GetAllDataTable())
      {
        Sort = (e.SortExpression + " " + this.Session["direction"].ToString())
      };
      this.gvDatos.DataBind();
    }
  }
}
