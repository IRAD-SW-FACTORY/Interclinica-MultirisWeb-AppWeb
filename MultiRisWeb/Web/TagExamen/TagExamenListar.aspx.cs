// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Web.TagExamen.TagExamenListar
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
  public class TagExamenListar : Page
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
    [ScriptMethod(UseHttpGet = true)]
    public static ResponseApp ListarExamenes(
      int nroPagina,
      long idInstitucion,
      string modalidad,
      string tipoAtencion,
      string estadoExamen,
      int rangoEtario,
      string idPaciente,
      string nombrePaciente,
      string nroAcceso,
      string fechaInicio,
      string fechaTermino,
      int tagExamen)
    {
      idPaciente = string.IsNullOrEmpty(idPaciente) ? string.Empty : idPaciente;
      nombrePaciente = string.IsNullOrEmpty(nombrePaciente) ? string.Empty : nombrePaciente;
      nroAcceso = string.IsNullOrEmpty(nroAcceso) ? string.Empty : nroAcceso;
      fechaInicio = fechaInicio.Length == 7 ? "0" + fechaInicio : fechaInicio;
      fechaTermino = fechaTermino.Length == 7 ? "0" + fechaTermino : fechaTermino;
      DateTime fechaInicio1 = new DateTime(int.Parse(fechaInicio.Substring(4, 4)), int.Parse(fechaInicio.Substring(2, 2)), int.Parse(fechaInicio.Substring(0, 2)));
      DateTime fechaTermino1 = new DateTime(int.Parse(fechaTermino.Substring(4, 4)), int.Parse(fechaTermino.Substring(2, 2)), int.Parse(fechaTermino.Substring(0, 2)), 23, 59, 59);
      List<ExamenTagDomain> source = TagExamenDataAccess.ListarExamenesTagProfesional(nroPagina, idInstitucion, modalidad, tipoAtencion, estadoExamen, rangoEtario, idPaciente, nombrePaciente, nroAcceso, HttpContext.Current.Session["username"].ToString(), fechaInicio1, fechaTermino1, tagExamen);
      return new ResponseApp()
      {
        Ejecutado = source.Any<ExamenTagDomain>(),
        Mensaje = "",
        Data = (object) source
      };
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(UseHttpGet = true)]
    public static ResponseApp ListarInstitucion()
    {
      List<UsuarioInstitucionDomain> source = UsuarioInstitucionDataAccess.ListarUsuarioInstitucion(HttpContext.Current.Session["username"].ToString());
      return new ResponseApp()
      {
        Ejecutado = source.Any<UsuarioInstitucionDomain>(),
        Mensaje = "",
        Data = (object) source
      };
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(UseHttpGet = true)]
    public static ResponseApp ListarModalidad()
    {
      List<ModalidadDomain> source = ModalidadDataAccess.Listar(1);
      return new ResponseApp()
      {
        Ejecutado = source.Any<ModalidadDomain>(),
        Mensaje = "",
        Data = (object) source
      };
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(UseHttpGet = true)]
    public static ResponseApp ListarTipoAtencion()
    {
      List<TipoUrgenciaDomain> source = TipoUrgenciaDataAccess.Listar(1);
      return new ResponseApp()
      {
        Ejecutado = source.Any<TipoUrgenciaDomain>(),
        Mensaje = "",
        Data = (object) source
      };
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(UseHttpGet = true)]
    public static ResponseApp ListarEstadoExamen()
    {
      List<RisEstadoExamenDomain> source = RisEstadoInformeDataAccess.Listar();
      return new ResponseApp()
      {
        Ejecutado = source.Any<RisEstadoExamenDomain>(),
        Mensaje = "",
        Data = (object) source
      };
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(UseHttpGet = true)]
    public static ResponseApp ListarTagExamen()
    {
      List<TagExamenDomain> source = TagExamenDataAccess.ListarVigenteUsuario(HttpContext.Current.Session["username"].ToString());
      return new ResponseApp()
      {
        Ejecutado = source.Any<TagExamenDomain>(),
        Mensaje = "",
        Data = (object) source
      };
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(UseHttpGet = true)]
    public static ResponseApp ListarTagExamenInformes(long id)
    {
      List<TagExamenVerInformeDomain> source = TagExamenDataAccess.ListarInformes(id);
      return new ResponseApp()
      {
        Ejecutado = source.Any<TagExamenVerInformeDomain>(),
        Mensaje = "",
        Data = (object) source
      };
    }

    [WebMethod(EnableSession = true)]
    [HttpPost]
    public static ResponseApp InsertOrUpdateComentario(long idExamen, string Comentario)
    {
      bool flag = ComentarioGeneralTagDartaAccess.InsertOrUpdate(new ComentarioGeneralTagDomain()
      {
        IdExamen = idExamen,
        ComentarioGeneral = Comentario,
        Usuario = HttpContext.Current.Session["username"].ToString()
      });
      return new ResponseApp()
      {
        Ejecutado = flag,
        Mensaje = flag ? "Comentario General Tag Examen se ingreso correctamente" : "No se ingreso comentario general tag examen, favor intentar nuevamente",
        Data = (object) null
      };
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(UseHttpGet = true)]
    public static ResponseApp GetComentarioGeneral(long id)
    {
      ComentarioGeneralTagDomain generalTagDomain = ComentarioGeneralTagDartaAccess.Get(HttpContext.Current.Session["username"].ToString(), id);
      return new ResponseApp()
      {
        Ejecutado = generalTagDomain != null,
        Mensaje = "",
        Data = generalTagDomain == null ? (object) new ComentarioGeneralTagDomain() : (object) generalTagDomain
      };
    }
  }
}
