using MultiRisWeb.Data.DataAccess;
using MultiRisWeb.Data.Domain;
using MultiRisWeb.ResponseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultiRisWeb.Web.MaestroFiltro
{
  public partial class Mantenedor : Page
  {
    //protected Button btnRegresar;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (HttpContext.Current.Session["id_usuario"] == null)
        HttpContext.Current.Response.Redirect("../../Default.aspx");
      if (this.IsPostBack)
        return;
      this.Session["idFiltro"] = (object) this.Request.QueryString["id"].ToString();
    }

    [WebMethod]
    public static ResponseApp CargaInstitucion()
    {
      if (HttpContext.Current.Session["id_usuario"] == null)
        HttpContext.Current.Response.Redirect("../../Default.aspx");
      List<InstitucionDomain> source = InstitucionDatosDataAccess.Listar();
      return new ResponseApp()
      {
        Data = (object) source,
        Ejecutado = source.Any<InstitucionDomain>(),
        Mensaje = string.Empty
      };
    }

    [WebMethod]
    public static ResponseApp CargaModalidad()
    {
      if (HttpContext.Current.Session["id_usuario"] == null)
        HttpContext.Current.Response.Redirect("../../Default.aspx");
      List<ModalidadDomain> source = ModalidadDataAccess.Listar(1);
      return new ResponseApp()
      {
        Data = (object) source,
        Ejecutado = source.Any<ModalidadDomain>(),
        Mensaje = string.Empty
      };
    }

    [WebMethod]
    public static ResponseApp CargaAtencion()
    {
      if (HttpContext.Current.Session["id_usuario"] == null)
        HttpContext.Current.Response.Redirect("../../Default.aspx");
      List<TipoUrgenciaDomain> source = TipoUrgenciaDataAccess.Listar(1);
      return new ResponseApp()
      {
        Data = (object) source,
        Ejecutado = source.Any<TipoUrgenciaDomain>(),
        Mensaje = string.Empty
      };
    }

    [WebMethod]
    public static ResponseApp CargaEstado()
    {
      if (HttpContext.Current.Session["id_usuario"] == null)
        HttpContext.Current.Response.Redirect("../../Default.aspx");
      List<RisEstadoExamenDomain> source = RisEstadoExamenDataAccess.ListarTodoEntidad();
      return new ResponseApp()
      {
        Data = (object) source,
        Ejecutado = source.Any<RisEstadoExamenDomain>(),
        Mensaje = string.Empty
      };
    }

    [WebMethod]
    public static ResponseApp CargaUsuario()
    {
      if (HttpContext.Current.Session["id_usuario"] == null)
        HttpContext.Current.Response.Redirect("../../Default.aspx");
      List<UsuarioDomain> source = UsuarioDataAccess.Listar();
      return new ResponseApp()
      {
        Data = (object) source,
        Ejecutado = source.Any<UsuarioDomain>(),
        Mensaje = string.Empty
      };
    }

    protected void btnRegresar_Click(object sender, EventArgs e)
    {
      if (this.Session["id_usuario"] == null)
        this.Response.Redirect("../../Default.aspx");
      this.Response.Redirect("Buscador.aspx");
    }

    [WebMethod]
    public static ResponseApp InsertUpdateFiltro(ResponseFiltro filtro)
    {
      if (HttpContext.Current.Session["id_usuario"] == null)
        HttpContext.Current.Response.Redirect("../../Default.aspx");
      try
      {
        int num1 = int.Parse(HttpContext.Current.Session["idFiltro"].ToString());
        long num2 = FiltroDataAccess.InsertOrUpdate(new FiltroDomain()
        {
          id_filtro = (long) num1,
          nombre = filtro.Nombre,
          id_estado = filtro.IdEstado,
          tipo_filtro = "General"
        });
        HttpContext.Current.Session["idFiltro"] = (object) num2;
        FiltroUsuarioAsignadoDataAccess.Delete(num2);
        FiltroInstitucionDataAccess.DeleteByIdFiltro(num2);
        FiltroTipoUrgenciaDataAccess.DeleteByIdFiltro(num2);
        FiltroModalidadDataAccess.DeleteByIdFiltro(num2);
        FiltroEstadoDataAccess.DeleteByIdFiltro(num2);
        foreach (int usuariosAsignado in filtro.UsuariosAsignados)
          FiltroUsuarioAsignadoDataAccess.Insert(num2, (long) usuariosAsignado);
        foreach (int institucione in filtro.Instituciones)
          FiltroInstitucionDataAccess.Insert(num2, institucione);
        foreach (int atencione in filtro.Atenciones)
          FiltroTipoUrgenciaDataAccess.Insert(num2, atencione);
        foreach (int modalidade in filtro.Modalidades)
          FiltroModalidadDataAccess.Insert(num2, modalidade);
        foreach (int estadosExamene in filtro.EstadosExamenes)
          FiltroEstadoDataAccess.Insert(num2, estadosExamene);
        return new ResponseApp()
        {
          Data = (object) null,
          Mensaje = "",
          Ejecutado = true
        };
      }
      catch (Exception ex)
      {
        return new ResponseApp()
        {
          Data = (object) null,
          Mensaje = ex.ToString(),
          Ejecutado = false
        };
      }
    }

    [WebMethod]
    public static ResponseApp Get()
    {
      if (HttpContext.Current.Session["id_usuario"] == null)
        HttpContext.Current.Response.Redirect("../../Default.aspx");
      long num = (long) int.Parse(HttpContext.Current.Session["idFiltro"].ToString());
      if (num == 0L)
        return new ResponseApp()
        {
          Data = (object) null,
          Ejecutado = false,
          Mensaje = string.Empty
        };
      FiltroDomain byId = FiltroDataAccess.GetById(num);
      List<FiltroUsuarioAsignadoDomain> usuarioAsignadoDomainList = FiltroUsuarioAsignadoDataAccess.Listar(num);
      List<FiltroInstitucionDomain> institucionDomainList = FiltroInstitucionDataAccess.Listar(num);
      List<FiltroTipoUrgenciaDomain> tipoUrgenciaDomainList = FiltroTipoUrgenciaDataAccess.Listar(num);
      List<FiltroModalidadDomain> filtroModalidadDomainList = FiltroModalidadDataAccess.Listar(num);
      List<FiltroEstadoDomain> filtroEstadoDomainList = FiltroEstadoDataAccess.Listar(num);
      List<long> longList1 = new List<long>();
      List<long> longList2 = new List<long>();
      List<long> longList3 = new List<long>();
      List<long> longList4 = new List<long>();
      List<long> longList5 = new List<long>();
      foreach (FiltroInstitucionDomain institucionDomain in institucionDomainList)
        longList1.Add((long) institucionDomain.id_institucion);
      foreach (FiltroTipoUrgenciaDomain tipoUrgenciaDomain in tipoUrgenciaDomainList)
        longList2.Add((long) tipoUrgenciaDomain.id_tipo_urgencia);
      foreach (FiltroModalidadDomain filtroModalidadDomain in filtroModalidadDomainList)
        longList3.Add((long) filtroModalidadDomain.id_modalidad);
      foreach (FiltroEstadoDomain filtroEstadoDomain in filtroEstadoDomainList)
        longList4.Add((long) filtroEstadoDomain.id_estado_examen);
      foreach (FiltroUsuarioAsignadoDomain usuarioAsignadoDomain in usuarioAsignadoDomainList)
        longList5.Add(usuarioAsignadoDomain.id_usuario);
      ResponseFiltro responseFiltro = new ResponseFiltro()
      {
        IdFiltro = byId.id_filtro,
        IdEstado = byId.id_estado,
        Nombre = byId.nombre,
        Instituciones = longList1,
        Atenciones = longList2,
        Modalidades = longList3,
        EstadosExamenes = longList4,
        UsuariosAsignados = longList5
      };
      return new ResponseApp()
      {
        Data = (object) responseFiltro,
        Ejecutado = true,
        Mensaje = string.Empty
      };
    }
  }
}