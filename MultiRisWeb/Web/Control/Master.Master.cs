// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Web.Control.Master
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using MultiRisWeb.Data.DataAccess;
using MultiRisWeb.Data.Domain;
using MultiRisWeb.Data.Parameters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MultiRisWeb.Web.Control
{
  public class Master : MasterPage
  {
    protected ContentPlaceHolder head;
    protected HtmlForm form1;
    protected HiddenField hddVerAddendum;
    protected HtmlAnchor examenes;
    protected HtmlAnchor monitor;
    protected HtmlAnchor plantillas;
    protected HtmlGenericControl tagExamen;
    protected HtmlGenericControl Label1;
    protected HtmlAnchor menuTagExamenProfesional;
    protected HtmlAnchor menuTagListarExamen;
    protected HtmlAnchor A1;
    protected HtmlGenericControl gestion;
    protected HtmlGenericControl lblGestion;
    protected HtmlAnchor menuCumplimientosPorInstitucion;
    protected HtmlAnchor menuCumpliemntoPorProfesional;
    protected HtmlAnchor menuHonorarios;
    protected HtmlAnchor menuMonitoreoDeTiempo;
    protected HtmlGenericControl configuracion;
    protected HtmlGenericControl lblConfiguracion;
    protected HtmlAnchor menuUsuarios;
    protected HtmlAnchor menuInstituciones;
    protected HtmlAnchor menuExamenesTags;
    protected HtmlAnchor menuInstitucion;
    protected HtmlAnchor menuVisorError;
    protected HtmlAnchor menuControlMenu;
    protected HtmlAnchor menuFiltros;
    protected HtmlAnchor btnSoporte;
    protected Label lblUsuario;
    protected ContentPlaceHolder ContentPlaceHolder1;
    protected HtmlGenericControl modalInicioPopUpHabil;
    protected HtmlGenericControl modalInicioPopUpNoHabil;

    protected void Page_Load(object sender, EventArgs e)
    {
      try
      {
        UsuarioDomain byId = UsuarioDataAccess.GetById(Convert.ToInt64(this.Session["id_usuario"]));
        this.hddVerAddendum.Value = byId.id_perfil == 1 || byId.id_perfil == 6 || byId.id_perfil == 3 || byId.id_perfil == 8 ? "true" : "false";
        clsFunciones clsFunciones1 = new clsFunciones();
        int num = SolicitudAddendumInstitucionAccess.Nuevas(byId.id_perfil, byId.username);
        if (num > 0)
        {
          this.A1.InnerText = "ADDENDUM (" + num.ToString() + ")";
          this.A1.Attributes.Add("style", "color:red; bold:true");
        }
        if (this.Session["id_usuario"] != null && byId.estado == 1)
        {
          string usuario = this.Session["username"].ToString();
          if (this.IsPostBack)
            return;
          this.examenes.Visible = false;
          this.monitor.Visible = false;
          this.plantillas.Visible = false;
          this.gestion.Visible = false;
          this.configuracion.Visible = false;
          this.menuCumpliemntoPorProfesional.Visible = false;
          this.menuCumplimientosPorInstitucion.Visible = false;
          this.menuVisorError.Visible = false;
          this.menuControlMenu.Visible = false;
          this.menuUsuarios.Visible = false;
          this.menuInstituciones.Visible = false;
          this.menuHonorarios.Visible = false;
          this.menuInstitucion.Visible = false;
          this.btnSoporte.Visible = false;
          this.menuMonitoreoDeTiempo.Visible = false;
          List<clsFunciones> clsFuncionesList = clsFunciones1.BuscarFunciones(usuario);
          if (!clsFuncionesList.Count.Equals(0))
          {
            DataSet subMenuGrupoSitio = ControlMenuAccess.GetControlSubMenuGrupoSitio(clsFuncionesList[0].indIdPerfil);
            foreach (clsFunciones clsFunciones2 in clsFuncionesList)
            {
              if (clsFunciones2.strMenu.Equals("Examenes"))
                this.examenes.Visible = true;
              if (clsFunciones2.strMenu.Equals("Plantillas"))
                this.plantillas.Visible = true;
              if (clsFunciones2.strMenu.Equals("Gestión"))
              {
                this.gestion.Visible = true;
                foreach (DataRow row in (InternalDataCollectionBase) subMenuGrupoSitio.Tables[0].Rows)
                {
                  if (row.ItemArray[1].Equals((object) "Monitoreo de Tiempo"))
                    this.menuMonitoreoDeTiempo.Visible = true;
                  if (row.ItemArray[1].Equals((object) "Producción"))
                    this.menuHonorarios.Visible = true;
                }
              }
              if (clsFunciones2.strMenu.Equals("Tags"))
              {
                this.tagExamen.Visible = true;
                foreach (DataRow row in (InternalDataCollectionBase) subMenuGrupoSitio.Tables[0].Rows)
                {
                  if (row.ItemArray[1].Equals((object) "Tags Profesional"))
                    this.menuTagExamenProfesional.Visible = true;
                  if (row.ItemArray[1].Equals((object) "Listar Tags"))
                    this.menuTagListarExamen.Visible = true;
                }
              }
              if (clsFunciones2.strMenu.Equals("Configuración"))
              {
                this.configuracion.Visible = true;
                foreach (DataRow row in (InternalDataCollectionBase) subMenuGrupoSitio.Tables[0].Rows)
                {
                  if (row.ItemArray[1].Equals((object) "Tiempo Institución"))
                    this.menuInstitucion.Visible = true;
                  if (byId.telefono2.Equals("654321"))
                  {
                    this.menuVisorError.Visible = true;
                    this.menuControlMenu.Visible = true;
                    this.menuUsuarios.Visible = true;
                    this.menuInstituciones.Visible = true;
                  }
                  else
                  {
                    if (row.ItemArray[1].Equals((object) "Visor Error Log"))
                      this.menuVisorError.Visible = true;
                    if (row.ItemArray[1].Equals((object) "Usuarios"))
                      this.menuUsuarios.Visible = true;
                    if (row.ItemArray[1].Equals((object) "Instituciones"))
                      this.menuInstituciones.Visible = true;
                    if (row.ItemArray[1].Equals((object) "Tags Generales"))
                      this.menuExamenesTags.Visible = true;
                    if (row.ItemArray[1].Equals((object) "Filtros Generales"))
                      this.menuFiltros.Visible = true;
                  }
                }
              }
              if (clsFunciones2.strMenu.Equals("Soporte"))
                this.btnSoporte.Visible = true;
            }
          }
          this.lblUsuario.Text = byId.nombre + " " + byId.apellido_paterno + " " + byId.apellido_materno;
          this.cargarExamenPendiente();
        }
        else
          this.Response.Redirect("../Control/CerrarSesion.aspx");
      }
      catch (Exception ex)
      {
        this.LogError(ex, nameof (Page_Load));
      }
    }

    public void LogError(Exception ex, string paginaEvento) => this.Response.Redirect("../../Default.aspx");

    private void cargarExamenPendiente()
    {
      DataTable quantityUsername = RisExamenDataAccess.GetQuantityUsername(UsuarioDataAccess.GetById(Convert.ToInt64(this.Session["id_usuario"].ToString())).username);
      if (quantityUsername.Rows.Count <= 0)
        return;
      foreach (DataRow row in (InternalDataCollectionBase) quantityUsername.Rows)
        ;
    }

  }
}
