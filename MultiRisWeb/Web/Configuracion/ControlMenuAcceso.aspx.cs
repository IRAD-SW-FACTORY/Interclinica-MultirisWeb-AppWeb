// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Web.Configuracion.ControlMenuAcceso
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using MultiRisWeb.Data.DataAccess;
using MultiRisWeb.Data.Domain;
using MultiRisWeb.Data.Parameters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultiRisWeb.Web.Configuracion
{
  public class ControlMenuAcceso : Page
  {
    private string filtro;
    private clsAccesoBD objConexion = new clsAccesoBD();
    private List<clsInstitucion> Lista = new List<clsInstitucion>();
    protected DropDownList ddrPerfil;
    protected Button Button1;

    protected void Page_Load(object sender, EventArgs e)
    {
      try
      {
        if (this.Request.UrlReferrer == (Uri) null)
          this.Response.Redirect("../../Default.aspx");
        if (this.IsPostBack)
          return;
        this.Session["direction"] = (object) "Asc";
        this.cargarDatos();
        this.cargarPerfil();
        this.ddrPerfil.Attributes["onchange"] = "cargarPerfilMenu();";
        this.ddrPerfil.SelectedValue = "0";
      }
      catch (Exception ex)
      {
        this.LogError(ex, nameof (Page_Load));
      }
    }

    public void LogError(Exception ex, string paginaEvento) => ControlErrorDataAccess.ControlErrorSave(ex.HResult, ex.GetType().Name, ex.Message, 1, paginaEvento, int.Parse(this.Session["id_usuario"].ToString()));

    public static void LogErrorMetodo(Exception ex, string paginaEvento) => ControlErrorDataAccess.ControlErrorSave(ex.HResult, ex.GetType().Name, ex.Message, 1, paginaEvento, 1);

    private void cargarDatos()
    {
      DataTable dataTable = new DataTable();
      ControlMenuAccess.GetControlMenuAcceso();
    }

    protected void btnRegresar_Click(object sender, EventArgs e)
    {
      try
      {
        this.Response.Redirect("ListaExamen.aspx", false);
      }
      catch (Exception ex)
      {
        this.LogError(ex, "btnPendiente_Click");
      }
    }

    private void cargarPerfil()
    {
      IList<PerfilDomain> all = PerfilDataAccess.GetAll();
      List<KeyValuePair<int, string>> keyValuePairList = new List<KeyValuePair<int, string>>();
      foreach (PerfilDomain perfilDomain in (IEnumerable<PerfilDomain>) all)
      {
        KeyValuePair<int, string> keyValuePair = new KeyValuePair<int, string>(int.Parse(perfilDomain.id_perfil.ToString()), perfilDomain.nombre);
        keyValuePairList.Add(keyValuePair);
      }
      KeyValuePair<int, string> keyValuePair1 = new KeyValuePair<int, string>(0, "Seleccionar");
      keyValuePairList.Add(keyValuePair1);
      this.ddrPerfil.DataValueField = "Key";
      this.ddrPerfil.DataTextField = "Value";
      this.ddrPerfil.DataSource = (object) keyValuePairList;
      this.ddrPerfil.DataBind();
      this.ddrPerfil.SelectedIndex = 0;
      this.ddrPerfil.DataBind();
    }

    protected void btnCrearPrestacion_Click(object sender, EventArgs e)
    {
    }

    protected void btnFiltrar_Click(object sender, EventArgs e)
    {
    }

    protected void gvDatos_Sorting(object sender, GridViewSortEventArgs e)
    {
      this.Session["direction"].ToString();
      if (this.Session["direction"].ToString() == "Asc")
        this.Session["direction"] = (object) "Desc";
      else if (this.Session["direction"].ToString() == "Desc")
        this.Session["direction"] = (object) "Asc";
      DataTable dataTable = new DataTable();
      new DataView(ControlMenuAccess.GetControlMenuAcceso()).Sort = e.SortExpression + " " + this.Session["direction"].ToString();
    }

    protected void gvDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      DataTable dataTable = new DataTable();
      ControlMenuAccess.GetControlMenuAcceso();
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
    }

    protected void LinkButton1_Click(object sender, EventArgs e) => this.cargarDatos();

    protected void ddrPerfil_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    [WebMethod]
    public static string PerfilesModal()
    {
      IList<PerfilDomain> all = PerfilDataAccess.GetAll();
      string str = "<table><tr><td>";
      foreach (PerfilDomain perfilDomain in (IEnumerable<PerfilDomain>) all)
      {
        str += "<label>";
        string[] strArray = new string[6]
        {
          str,
          "<input type=\"radio\" name=\"perfil\" id=\"check",
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

    [WebMethod]
    public static string MenuModal(int idPerfil)
    {
      DataSet controlMenu = ControlMenuAccess.GetControlMenu(idPerfil);
      List<MenuDomain> menuDomainList1 = new List<MenuDomain>();
      List<MenuDomain> menuDomainList2 = new List<MenuDomain>();
      List<MenuDomain> source = new List<MenuDomain>();
      foreach (DataRow row in (InternalDataCollectionBase) controlMenu.Tables[0].Rows)
        menuDomainList2.Add(new MenuDomain()
        {
          Id_menu = int.Parse(row.ItemArray[0].ToString()),
          Menu = row.ItemArray[1].ToString()
        });
      foreach (DataRow row in (InternalDataCollectionBase) controlMenu.Tables[1].Rows)
        source.Add(new MenuDomain()
        {
          Id_menu = int.Parse(row.ItemArray[0].ToString()),
          Menu = row.ItemArray[1].ToString()
        });
      string str1 = "<table><tr><td>";
      foreach (MenuDomain menuDomain in menuDomainList2)
      {
        MenuDomain menuForeach = menuDomain;
        int num = source.Where<MenuDomain>((System.Func<MenuDomain, bool>) (n => n.Id_menu == menuForeach.Id_menu)).Count<MenuDomain>();
        string str2 = !num.Equals(0) ? "checked" : "";
        str1 += "<label>";
        string[] strArray = new string[8];
        strArray[0] = str1;
        strArray[1] = "<input type=\"checkbox\" name=\"Menu\" id=\"check";
        num = menuForeach.Id_menu;
        strArray[2] = num.ToString();
        strArray[3] = "\" value=\"";
        num = menuForeach.Id_menu;
        strArray[4] = num.ToString();
        strArray[5] = "\" ";
        strArray[6] = str2;
        strArray[7] = ">";
        str1 = string.Concat(strArray);
        str1 += menuForeach.Menu;
        str1 += "&nbsp;&nbsp;&nbsp;";
        str1 += "</label>";
      }
      return str1 + "</td></tr></table>";
    }

    [WebMethod]
    public static string SubMenuModalGrupo1(int idPerfil)
    {
      DataSet controlSubMenuGrupo1 = ControlMenuAccess.GetControlSubMenuGrupo1(idPerfil);
      List<SubMenuDomain> subMenuDomainList = new List<SubMenuDomain>();
      List<SubMenuDomain> source = new List<SubMenuDomain>();
      foreach (DataRow row in (InternalDataCollectionBase) controlSubMenuGrupo1.Tables[0].Rows)
        subMenuDomainList.Add(new SubMenuDomain()
        {
          id_Submenu = int.Parse(row.ItemArray[0].ToString()),
          subMenu = row.ItemArray[1].ToString()
        });
      foreach (DataRow row in (InternalDataCollectionBase) controlSubMenuGrupo1.Tables[1].Rows)
        source.Add(new SubMenuDomain()
        {
          id_Submenu = int.Parse(row.ItemArray[0].ToString()),
          subMenu = row.ItemArray[1].ToString()
        });
      string str1 = "<table><tr><td>";
      foreach (SubMenuDomain subMenuDomain in subMenuDomainList)
      {
        SubMenuDomain menuForeach = subMenuDomain;
        string str2 = !source.Where<SubMenuDomain>((System.Func<SubMenuDomain, bool>) (n => n.id_Submenu == menuForeach.id_Submenu)).Count<SubMenuDomain>().Equals(0) ? "checked" : "";
        str1 += "<label>";
        str1 = str1 + "<input type=\"checkbox\" name=\"SubMenu1\" id=\"check" + menuForeach.id_Submenu.ToString() + "\" value=\"" + menuForeach.id_Submenu.ToString() + "\" " + str2 + ">";
        str1 += menuForeach.subMenu;
        str1 += "&nbsp;&nbsp;&nbsp;";
        str1 += "</label>";
      }
      return str1 + "</td></tr></table>";
    }

    [WebMethod]
    public static string SubMenuModalGrupo2(int idPerfil)
    {
      DataSet controlSubMenuGrupo2 = ControlMenuAccess.GetControlSubMenuGrupo2(idPerfil);
      List<SubMenuDomain> subMenuDomainList = new List<SubMenuDomain>();
      List<SubMenuDomain> source = new List<SubMenuDomain>();
      foreach (DataRow row in (InternalDataCollectionBase) controlSubMenuGrupo2.Tables[0].Rows)
        subMenuDomainList.Add(new SubMenuDomain()
        {
          id_Submenu = int.Parse(row.ItemArray[0].ToString()),
          subMenu = row.ItemArray[1].ToString()
        });
      foreach (DataRow row in (InternalDataCollectionBase) controlSubMenuGrupo2.Tables[1].Rows)
        source.Add(new SubMenuDomain()
        {
          id_Submenu = int.Parse(row.ItemArray[0].ToString()),
          subMenu = row.ItemArray[1].ToString()
        });
      string str1 = "<table><tr><td>";
      foreach (SubMenuDomain subMenuDomain in subMenuDomainList)
      {
        SubMenuDomain menuForeach = subMenuDomain;
        string str2 = !source.Where<SubMenuDomain>((System.Func<SubMenuDomain, bool>) (n => n.id_Submenu == menuForeach.id_Submenu)).Count<SubMenuDomain>().Equals(0) ? "checked" : "";
        str1 += "<label>";
        str1 = str1 + "<input type=\"checkbox\" name=\"SubMenu2\" id=\"check" + menuForeach.id_Submenu.ToString() + "\" value=\"" + menuForeach.id_Submenu.ToString() + "\" " + str2 + ">";
        str1 += menuForeach.subMenu;
        str1 += "&nbsp;&nbsp;&nbsp;";
        str1 += "</label>";
      }
      return str1 + "</td></tr></table>";
    }

    [WebMethod]
    public static int guardarControlMenuAcceso(
      int id_perfil,
      string menu,
      string subMenuGestion_1,
      string subMenuGestion_2)
    {
      int num1 = 0;
      try
      {
        string[] strArray1 = menu.Split(',');
        int num2 = 0;
        ControlMenuAccess.SavePreparar(id_perfil);
        foreach (string s in strArray1)
        {
          ControlMenuAccess.SaveMenu(id_perfil, int.Parse(s), true);
          ++num2;
        }
        string[] strArray2 = subMenuGestion_1.Split(',');
        string[] strArray3 = subMenuGestion_2.Split(',');
        if (!subMenuGestion_1.Equals(string.Empty))
        {
          foreach (string s in strArray2)
            ControlMenuAccess.SaveSubMenu(3, int.Parse(s), true, id_perfil);
        }
        if (!subMenuGestion_2.Equals(string.Empty))
        {
          foreach (string s in strArray3)
            ControlMenuAccess.SaveSubMenu(4, int.Parse(s), true, id_perfil);
        }
      }
      catch (Exception ex)
      {
        ControlMenuAcceso.LogErrorMetodo(ex, nameof (guardarControlMenuAcceso));
      }
      return num1;
    }
  }
}
