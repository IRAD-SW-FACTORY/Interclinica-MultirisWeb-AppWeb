// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Web.TagExamen.TagExamenProfesional
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using MultiRisWeb.Data.DataAccess;
using MultiRisWeb.Data.Domain;
using MultiRisWeb.ResponseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace MultiRisWeb.Web.TagExamen
{
  public class TagExamenProfesional : Page
  {
    protected HtmlGenericControl modalMensajeInfoTag;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.IsPostBack)
        return;
      if (this.Request.UrlReferrer == (Uri) null)
        this.Response.Redirect("../../Default.aspx");
      UsuarioDomain byId = UsuarioDataAccess.GetById(Convert.ToInt64(this.Session["id_usuario"]));
      if (byId.id_perfil == 1 || byId.estado != 0)
        return;
      this.Response.Redirect("../Control/CerrarSesion.aspx");
    }

    [WebMethod(EnableSession = true)]
    [HttpPost]
    public static ResponseApp Insertar(string nombre, int vigente)
    {
      bool flag = TagExamenDataAccess.Insertar(new TagExamenDomain()
      {
        Id = 0,
        Nombre = nombre,
        TagGeneral = 0,
        Usuario = HttpContext.Current.Session["username"].ToString(),
        Vigente = vigente
      });
      return new ResponseApp()
      {
        Ejecutado = flag,
        Mensaje = flag ? "Tag Examen se ingreso correctamente" : "No se ingreso tag examen, favor intentar nuevamente",
        Data = (object) null
      };
    }

    [WebMethod(EnableSession = true)]
    [HttpPost]
    public static ResponseApp Update(int id, string nombre, int vigente)
    {
      bool flag = TagExamenDataAccess.Modificar(new TagExamenDomain()
      {
        Id = id,
        Nombre = nombre,
        UsuarioEliminacion = HttpContext.Current.Session["username"].ToString(),
        Vigente = vigente
      });
      return new ResponseApp()
      {
        Ejecutado = flag,
        Mensaje = flag ? "Tag Examen se ingreso correctamente" : "No se ingreso tag examen, favor intentar nuevamente",
        Data = (object) null
      };
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(UseHttpGet = true)]
    public static ResponseApp Listar(string nombre)
    {
      nombre = string.IsNullOrEmpty(nombre) ? string.Empty : nombre;
      List<TagExamenDomain> source = TagExamenDataAccess.Listar(0, nombre, HttpContext.Current.Session["username"].ToString());
      return new ResponseApp()
      {
        Ejecutado = source.Any<TagExamenDomain>(),
        Mensaje = "",
        Data = (object) source
      };
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(UseHttpGet = true)]
    public static ResponseApp Get(int id)
    {
      TagExamenDomain tagExamenDomain = TagExamenDataAccess.Get(id);
      return new ResponseApp()
      {
        Ejecutado = tagExamenDomain != null,
        Mensaje = "",
        Data = (object) tagExamenDomain
      };
    }
  }
}
