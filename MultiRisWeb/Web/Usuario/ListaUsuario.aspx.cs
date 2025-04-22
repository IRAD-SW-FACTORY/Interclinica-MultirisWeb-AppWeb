// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Web.Usuario.ListaUsuario
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

namespace MultiRisWeb.Web.Usuario
{
  public class ListaUsuario : Page
  {
    protected GridView gvDatos;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.IsPostBack)
        return;
      if (this.Request.UrlReferrer == (Uri) null)
        this.Response.Redirect("../../Default.aspx");
      UsuarioDomain byId = UsuarioDataAccess.GetById(Convert.ToInt64(this.Session["id_usuario"]));
      if (byId.id_perfil == 1 && byId.estado == 1)
        this.cargarDatos();
      else
        this.Response.Redirect("../Control/CerrarSesion.aspx");
    }

    private void cargarDatos()
    {
      this.gvDatos.DataSource = (object) UsuarioDataAccess.GetAllUser();
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
          "<input type=\"radio\" name=\"perfil\" id=\"rbtnPerfil",
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
      }
      return str + "</td></tr></table>";
    }

    public static string Visores()
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

    protected void gvDatos_Sorting(object sender, GridViewSortEventArgs e)
    {
      this.Session["direction"].ToString();
      if (this.Session["direction"].ToString() == "Asc")
        this.Session["direction"] = (object) "Desc";
      else if (this.Session["direction"].ToString() == "Desc")
        this.Session["direction"] = (object) "Asc";
      this.gvDatos.DataSource = (object) new DataView(UsuarioDataAccess.GetAllUser())
      {
        Sort = (e.SortExpression + " " + this.Session["direction"].ToString())
      };
      this.gvDatos.DataBind();
    }

    [WebMethod]
    public static ArrayList cargarUsuario(int id_usuario)
    {
      ArrayList arrayList = new ArrayList();
      UsuarioDomain byId = UsuarioDataAccess.GetById((long) id_usuario);
      string str1 = ListaUsuario.Perfiles();
      string str2 = ListaUsuario.Visores();
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
        tablaVisores = str2
      });
      return arrayList;
    }

    [WebMethod]
    public static bool guardarUsuario(
      long id_usuario,
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
      int id_visor)
    {
      bool flag = false;
      UsuarioDomain byId = UsuarioDataAccess.GetById(id_usuario);
      byId.nombre = nombre;
      byId.apellido_paterno = apellido_paterno;
      byId.apellido_materno = apellido_materno;
      byId.estado = estado;
      byId.username = username;
      byId.password = password;
      byId.id_perfil = id_perfil;
      byId.rut = rut;
      byId.email1 = email1;
      byId.email2 = email2;
      byId.telefono1 = telefono1;
      byId.telefono2 = telefono2;
      byId.dias_examenes = dias_examenes;
      byId.vocali = vocali;
      byId.agente_vocali = agente_vocali;
      byId.id_visor = id_visor;
      if (UsuarioDataAccess.Save(byId) > 0L)
        flag = true;
      return flag;
    }
  }
}
