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
  public partial class Buscador : Page
  {
    protected Button btnCrearFiltro;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (HttpContext.Current.Session["id_usuario"] != null)
        return;
      HttpContext.Current.Response.Redirect("../../Default.aspx");
    }

    protected void btnCrearFiltro_Click(object sender, EventArgs e)
    {
      if (this.Session["id_usuario"] == null)
        this.Response.Redirect("../../Default.aspx");
      this.Response.Redirect("Mantenedor.aspx?id=0");
    }

    [WebMethod]
    public static ResponseApp CargarProfesionales()
    {
      if (HttpContext.Current.Session["id_usuario"] == null)
        HttpContext.Current.Response.Redirect("../../Default.aspx");
      List<UsuarioDomain> source = UsuarioDataAccess.Listar();
      source.Insert(0, new UsuarioDomain()
      {
        id_usuario = 0L,
        nombre_completo = "TODOS"
      });
      return new ResponseApp()
      {
        Data = (object) source,
        Ejecutado = source.Any<UsuarioDomain>(),
        Mensaje = string.Empty
      };
    }

    [WebMethod]
    public static ResponseApp Listar(long idUsuario, int idEstado)
    {
      if (HttpContext.Current.Session["id_usuario"] == null)
        HttpContext.Current.Response.Redirect("../../Default.aspx");
      List<FiltroGeneralDomain> source = FiltroGeneralDataAccess.Listar(idUsuario, idEstado);
      return new ResponseApp()
      {
        Data = (object) source,
        Ejecutado = source.Any<FiltroGeneralDomain>(),
        Mensaje = string.Empty
      };
    }
  }
}