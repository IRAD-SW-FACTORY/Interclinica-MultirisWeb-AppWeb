// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Web.Configuracion.UsuariosOld
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using MultiRisWeb.Data.DataAccess;
using MultiRisWeb.Data.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultiRisWeb.Web.Configuracion
{
  public class UsuariosOld : Page
  {
    protected TextBox txtFiltro;
    protected Button btnFiltrar;
    protected GridView gvDatos;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Request.UrlReferrer == (Uri) null)
        this.Response.Redirect("../../Default.aspx");
      try
      {
        if (this.IsPostBack)
          return;
        UsuarioDomain byId = UsuarioDataAccess.GetById(Convert.ToInt64(this.Session["id_usuario"]));
        if (byId.id_perfil == 1 && byId.estado == 1)
          this.cargarDatos(string.Empty);
        else
          this.Response.Redirect("../Control/CerrarSesion.aspx");
      }
      catch (Exception ex)
      {
        this.LogError(ex, nameof (Page_Load));
      }
    }

    public void LogError(Exception ex, string paginaEvento) => ControlErrorDataAccess.ControlErrorSave(ex.HResult, ex.GetType().Name, ex.Message, 1, paginaEvento, int.Parse(this.Session["id_usuario"].ToString()));

    private void cargarDatos(string username)
    {
      DataTable dataTable = new DataTable();
      this.gvDatos.DataSource = !username.Equals(string.Empty) ? (object) UsuarioDataAccess.GetAllUserAdmin(username) : (object) UsuarioDataAccess.GetAllUser();
      this.gvDatos.DataBind();
    }

    public static string Perfiles()
    {
      IList<PerfilDomain> all = PerfilDataAccess.GetAll();
      string str = "<table><tr><td>";
      foreach (PerfilDomain perfilDomain in (IEnumerable<PerfilDomain>) all)
      {
        str += "<label>";
        string[] strArray = new string[6]
        {
          str,
          "<input onclick='MostrarRadiologo(this.value)' type=\"radio\" name=\"perfil\" id=\"rbtnPerfil",
          null,
          null,
          null,
          null
        };
        long idPerfil1 = perfilDomain.id_perfil;
        strArray[2] = idPerfil1.ToString();
        strArray[3] = "\" value=\"";
        long idPerfil2 = perfilDomain.id_perfil;
        strArray[4] = idPerfil2.ToString();
        strArray[5] = "\">";
        str = string.Concat(strArray);
        str += perfilDomain.nombre;
        str += "&nbsp;&nbsp;s";
        str += "</label>";
      }
      return str + "</td></tr></table>";
    }

    public static string Visores()
    {
      IList<VisorDomain> allForState = VisorDataAccess.GetAllForState(1);
      string str1 = "<table><tr><td>";
      foreach (VisorDomain visorDomain in (IEnumerable<VisorDomain>) allForState)
      {
        string str2 = visorDomain.id_visor > 0 ? "checked" : "";
        str1 += "<label>";
        str1 = str1 + "<input type=\"checkbox\" name=\"institucion\" id=\"check" + visorDomain.id_visor.ToString() + "\" value=\"" + visorDomain.id_visor.ToString() + "\" " + str2 + ">";
        str1 += visorDomain.nombre;
        str1 += "&nbsp;&nbsp;&nbsp;";
        str1 += "</label>";
      }
      return str1 + "</td></tr></table>";
    }

    public static string Instituciones(long id_usuario)
    {
      IList<InstitucionDomain> byState = InstitucionDataAccess.GetByState(1);
      string str1 = "<div class='row'>";
      foreach (InstitucionDomain institucionDomain in (IEnumerable<InstitucionDomain>) byState)
      {
        string str2 = UsuarioInstitucionDataAccess.GetByUserAndInst(id_usuario, institucionDomain.id_institucion).id_usuario_institucion > 0L ? "checked" : "";
        str1 += "<div class='col-4'>";
        str1 += "<label>";
        str1 = str1 + "<input type=\"checkbox\" name=\"institucion\" id=\"check" + institucionDomain.id_institucion.ToString() + "\" value=\"" + institucionDomain.id_institucion.ToString() + "\" " + str2 + ">";
        str1 += institucionDomain.nombre;
        str1 += "&nbsp;&nbsp;&nbsp;";
        str1 += "</label>";
        str1 += "</div>";
      }
      return str1 + "</div>";
    }

    public static string Radiologos(long id_usuario)
    {
      List<UsuarioDomain> byPerfilAndEstate = (List<UsuarioDomain>) UsuarioDataAccess.GetListByPerfilAndEstate(3, 1);
      byPerfilAndEstate.AddRange((IEnumerable<UsuarioDomain>) UsuarioDataAccess.GetListByPerfilAndEstate(6, 1));
      List<UsuarioRadiologoBecadoDomain> source = UsuarioRadiologoBecadoDataAccess.Listar(id_usuario);
      string str1 = "<div class='row'>";
      foreach (UsuarioDomain usuarioDomain in byPerfilAndEstate)
      {
        UsuarioDomain usuarioForeach = usuarioDomain;
        string str2 = source.SingleOrDefault<UsuarioRadiologoBecadoDomain>((System.Func<UsuarioRadiologoBecadoDomain, bool>) (s => s.IdUsuarioRadiologo == usuarioForeach.id_usuario)) != null ? "checked" : "";
        str1 += "<div class='col-4'>";
        str1 += "<label>";
        str1 = str1 + "<input type=\"checkbox\" name=\"radiologos\" id=\"check" + usuarioForeach.id_usuario.ToString() + "\" value=\"" + usuarioForeach.id_usuario.ToString() + "\" " + str2 + ">";
        str1 = str1 + usuarioForeach.nombre + " " + usuarioForeach.apellido_paterno;
        str1 += "&nbsp;&nbsp;&nbsp;";
        str1 += "</label>";
        str1 += "</div>";
      }
      return str1 + "</div>";
    }

    public static string RadiologosEspecializado(long id_usuario)
    {
      List<UsuarioDomain> byPerfilAndEstate = (List<UsuarioDomain>) UsuarioDataAccess.GetListByPerfilAndEstate(3, 1);
      byPerfilAndEstate.AddRange((IEnumerable<UsuarioDomain>) UsuarioDataAccess.GetListByPerfilAndEstate(6, 1));
      List<UsuarioRadiologoEspecializadoDomain> source = UsuarioRadiologoEspecializadoDataAccess.Listar(id_usuario);
      string str1 = "<div class='row'>";
      foreach (UsuarioDomain usuarioDomain in byPerfilAndEstate)
      {
        UsuarioDomain usuarioForeach = usuarioDomain;
        string str2 = source.SingleOrDefault<UsuarioRadiologoEspecializadoDomain>((System.Func<UsuarioRadiologoEspecializadoDomain, bool>) (s => s.IdUsuarioRadiologo == usuarioForeach.id_usuario)) != null ? "checked" : "";
        str1 += "<div class='col-4'>";
        str1 += "<label>";
        str1 = str1 + "<input type=\"checkbox\" name=\"radiologos\" id=\"check" + usuarioForeach.id_usuario.ToString() + "\" value=\"" + usuarioForeach.id_usuario.ToString() + "\" " + str2 + ">";
        str1 = str1 + usuarioForeach.nombre + " " + usuarioForeach.apellido_paterno;
        str1 += "&nbsp;&nbsp;&nbsp;";
        str1 += "</label>";
        str1 += "</div>";
      }
      return str1 + "</div>";
    }

    protected void gvDatos_Sorting(object sender, GridViewSortEventArgs e)
    {
      try
      {
        if (this.Session["direction"].ToString().Equals("0"))
          this.Session["direction"] = (object) "Asc";
        else if (this.Session["direction"].ToString() == "Asc")
          this.Session["direction"] = (object) "Desc";
        else if (this.Session["direction"].ToString() == "Desc")
          this.Session["direction"] = (object) "Asc";
        this.gvDatos.DataSource = (object) new DataView(UsuarioDataAccess.GetAllUser())
        {
          Sort = (e.SortExpression + " " + this.Session["direction"].ToString())
        };
        this.gvDatos.DataBind();
      }
      catch (Exception ex)
      {
        this.LogError(ex, "Page_Load");
      }
    }

    protected void gvDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      try
      {
        DataTable allUser = UsuarioDataAccess.GetAllUser();
        this.gvDatos.PageIndex = e.NewPageIndex;
        this.gvDatos.DataSource = (object) allUser;
        this.gvDatos.DataBind();
      }
      catch (Exception ex)
      {
        this.LogError(ex, "Page_Load");
      }
    }

    [WebMethod]
    public static string PerfilesModal()
    {
      IList<PerfilDomain> all = PerfilDataAccess.GetAll();
      string str = "<div class='row'>";
      foreach (PerfilDomain perfilDomain in (IEnumerable<PerfilDomain>) all)
      {
        str += "<div class='col-4'>";
        str += "<label>";
        string[] strArray = new string[6]
        {
          str,
          "<input onclick='MostrarRadiologo(this.value)' type=\"radio\" name=\"perfil\" id=\"rbtnPerfil",
          null,
          null,
          null,
          null
        };
        long idPerfil1 = perfilDomain.id_perfil;
        strArray[2] = idPerfil1.ToString();
        strArray[3] = "\" value=\"";
        long idPerfil2 = perfilDomain.id_perfil;
        strArray[4] = idPerfil2.ToString();
        strArray[5] = "\">";
        str = string.Concat(strArray);
        str += perfilDomain.nombre;
        str += "&nbsp;&nbsp;&nbsp;";
        str += "</label>";
        str += "</div>";
      }
      return str + "</div>";
    }

    [WebMethod]
    public static string RadiologosModal()
    {
      List<UsuarioDomain> byPerfilAndEstate = (List<UsuarioDomain>) UsuarioDataAccess.GetListByPerfilAndEstate(3, 1);
      byPerfilAndEstate.AddRange((IEnumerable<UsuarioDomain>) UsuarioDataAccess.GetListByPerfilAndEstate(6, 1));
      string str = "<div class='row'>";
      foreach (UsuarioDomain usuarioDomain in byPerfilAndEstate)
      {
        str += "<div class='col-4'>";
        str += "<label>";
        string[] strArray = new string[6]
        {
          str,
          "<input type=\"checkbox\" name=\"radiologos\" id=\"check",
          null,
          null,
          null,
          null
        };
        long idUsuario = usuarioDomain.id_usuario;
        strArray[2] = idUsuario.ToString();
        strArray[3] = "\" value=\"";
        idUsuario = usuarioDomain.id_usuario;
        strArray[4] = idUsuario.ToString();
        strArray[5] = "\">";
        str = string.Concat(strArray);
        str = str + usuarioDomain.nombre + " " + usuarioDomain.apellido_paterno;
        str += "&nbsp;&nbsp;&nbsp;";
        str += "</label>";
        str += "</div>";
      }
      return str + "</div>";
    }

    [WebMethod]
    public static string InstitucionesModal()
    {
      IList<InstitucionDomain> byState = InstitucionDataAccess.GetByState(1);
      string str1 = "<div class='row'>";
      foreach (InstitucionDomain institucionDomain in (IEnumerable<InstitucionDomain>) byState)
      {
        string str2 = "";
        str1 += "<div class='col-4'>";
        str1 += "<label>";
        str1 = str1 + "<input type=\"checkbox\" name=\"institucion\" id=\"check" + institucionDomain.id_institucion.ToString() + "\" value=\"" + institucionDomain.id_institucion.ToString() + "\" " + str2 + ">";
        str1 += institucionDomain.nombre;
        str1 += "&nbsp;&nbsp;&nbsp;";
        str1 += "</label>";
        str1 += "</div>";
      }
      return str1 + "</div>";
    }

    [WebMethod]
    public static string VisoresModal()
    {
      IList<VisorDomain> allForState = VisorDataAccess.GetAllForState(1);
      string str = "<table><tr><td>";
      foreach (VisorDomain visorDomain in (IEnumerable<VisorDomain>) allForState)
      {
        str += "<label>";
        str = str + "<input type=\"radio\" name=\"visor\" id=\"rbtnVisor" + visorDomain.id_visor.ToString() + "\" value=\"" + visorDomain.id_visor.ToString() + "\">";
        str += visorDomain.nombre;
        str += "&nbsp;&nbsp;&nbsp;";
        str += "</label>";
      }
      return str + "</td></tr></table>";
    }

    [WebMethod]
    public static ArrayList cargarUsuario(int id_usuario)
    {
      ArrayList arrayList = new ArrayList();
      try
      {
        UsuarioDomain byId = UsuarioDataAccess.GetById((long) id_usuario);
        string str1 = UsuariosOld.Perfiles();
        string str2 = UsuariosOld.Visores();
        string str3 = UsuariosOld.Instituciones(byId.id_usuario);
        string str4 = byId.id_perfil == 10 ? UsuariosOld.RadiologosEspecializado(byId.id_usuario) : UsuariosOld.Radiologos(byId.id_usuario);
        arrayList.Add((object) new
        {
          id_perfil = byId.id_perfil,
          nombre = byId.nombre,
          apellido_paterno = byId.apellido_paterno,
          apellido_materno = byId.apellido_materno,
          estado = byId.estado,
          username = byId.username,
          password = byId.password,
          rut = byId.rut,
          email1 = byId.email1,
          email2 = byId.email2,
          telefono1 = byId.telefono1,
          telefono2 = byId.telefono2,
          dias_examenes = byId.dias_examenes,
          vocali = byId.vocali,
          agente_vocali = byId.agente_vocali,
          id_visor = byId.id_visor,
          tablaPerfiles = str1,
          tablaVisores = str2,
          tablaInstituciones = str3,
          tablaRadiologos = str4
        });
      }
      catch (Exception ex)
      {
        ex.ToString();
        ApiErrorDataAccess.Save(new ApiErrorDomain()
        {
          staktrace = "WebMethod: cargarMisFiltros (ListaExamen.aspx): \n\n" + ex.ToString()
        });
      }
      return arrayList;
    }

    [WebMethod]
    public static int guardarUsuario(
      int id_usuario,
      string nombre,
      string apellido_paterno,
      string apellido_materno,
      int estado,
      string username,
      string password,
      int id_perfil,
      string rut,
      string email1,
      string email2,
      string telefono1,
      string telefono2,
      int dias_examenes,
      int vocali,
      int agente_vocali,
      string instituciones,
      string radiologosBecado,
      int id_visor)
    {
      int num1 = 0;
      try
      {
        if (!UsuariosOld.ValidadGuardaUsuario(username, password, id_perfil, nombre))
          return -2;
        if (!UsuariosOld.ValidadBecadoRadiologo(id_perfil, radiologosBecado))
          return -3;
        UsuarioDomain usuario = new UsuarioDomain();
        usuario.id_usuario = (long) id_usuario;
        usuario.nombre = nombre;
        usuario.apellido_paterno = apellido_paterno;
        usuario.apellido_materno = apellido_materno;
        usuario.estado = estado;
        usuario.username = username;
        usuario.password = password;
        usuario.id_perfil = id_perfil;
        usuario.rut = rut;
        usuario.email1 = email1;
        usuario.email2 = email2;
        usuario.telefono1 = telefono1;
        usuario.telefono2 = telefono2;
        usuario.dias_examenes = dias_examenes;
        usuario.vocali = vocali;
        usuario.agente_vocali = agente_vocali;
        usuario.id_visor = id_visor;
        long num2 = UsuarioDataAccess.Save(usuario);
        if (num2 != -1L)
        {
          if (instituciones != "")
          {
            string[] strArray = new string[0];
            string str1 = instituciones;
            char[] chArray = new char[1]{ ',' };
            foreach (string str2 in str1.Split(chArray))
              UsuarioInstitucionDataAccess.Save(new UsuarioInstitucionDomain()
              {
                id_usuario = num2,
                id_institucion = Convert.ToInt32(str2)
              });
          }
          if (usuario.id_perfil == 3 || usuario.id_perfil == 9)
          {
            List<long> radiologos = new List<long>();
            int index = 0;
            while (true)
            {
              if (index < radiologosBecado.Split(',').Length)
              {
                radiologos.Add(long.Parse(radiologosBecado.Split(',')[index].ToString()));
                ++index;
              }
              else
                break;
            }
            RadiologoBecadoDataAccess.ProcesarRelacionRadiologoBecado(num2, radiologos);
          }
          else if (usuario.id_perfil == 10)
          {
            List<long> radiologos = new List<long>();
            int index = 0;
            while (true)
            {
              if (index < radiologosBecado.Split(',').Length)
              {
                radiologos.Add(long.Parse(radiologosBecado.Split(',')[index].ToString()));
                ++index;
              }
              else
                break;
            }
            RadiologoEspecializadoDataAccess.ProcesarRelacionRadiologoEspecializado(num2, radiologos);
          }
        }
        num1 = int.Parse(num2.ToString());
      }
      catch (Exception ex)
      {
        UsuariosOld.LogError(ex, "Page_Load", id_usuario);
      }
      return num1;
    }

    public static void LogError(Exception ex, string paginaEvento, int id_usuario) => ControlErrorDataAccess.ControlErrorSave(ex.HResult, ex.GetType().Name, ex.Message, 1, paginaEvento, id_usuario);

    private static bool ValidadGuardaUsuario(
      string username,
      string password,
      int id_perfil,
      string nombre)
    {
      return !username.Equals(string.Empty) || !password.Equals(string.Empty) || !id_perfil.Equals(0) || !nombre.Equals(string.Empty);
    }

    private static bool ValidadBecadoRadiologo(int id_perfil, string radiologosBecado)
    {
      if (id_perfil != 7 || id_perfil != 9)
        return true;
      return id_perfil != 10 && !string.IsNullOrEmpty(radiologosBecado);
    }

    protected void btnFiltrar_Click(object sender, EventArgs e) => this.cargarDatos(this.txtFiltro.Text.Trim());
  }
}
