// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Web.Plantilla.EditarPlantilla
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using MultiRisWeb.Data.DataAccess;
using MultiRisWeb.Data.Domain;
using MultiRisWeb.Data.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MultiRisWeb.Web.Plantilla
{
  public class EditarPlantilla : Page
  {
    private long p_id;
    protected HtmlInputHidden idactual;
    protected TextBox txtNombre;
    protected TextBox txtTitulo;
    protected DropDownList ddlModalidad;
    protected Button btnAsignarModalidad;
    protected GridView gvModalidades;
    protected HtmlGenericControl divMensaje;
    protected Label lblAlertWarning;
    protected Button btnEliminarCancelar;
    protected Button btnEliminarSeguro;
    protected Button btnGuardar;
    protected Button btnVolver;
    protected Button btnEliminar;
    protected TextBox txtTecnica;
    protected TextBox txtHallazgos;
    protected TextBox txtImpresion;
    protected HtmlGenericControl modalInicioPopUpHabil;
    protected HtmlGenericControl modalInicioPopUpNoHabil;

    public long id
    {
      get
      {
        this.p_id = ParamUtil.GetParamLong((object) this.Request[nameof (id)], 0L);
        if (this.p_id > 0L)
          this.idactual.Value = this.p_id.ToString();
        else
          this.p_id = ParamUtil.GetParamLong((object) this.idactual.Value, 0L);
        return this.p_id;
      }
      set
      {
        this.p_id = value;
        this.idactual.Value = value.ToString();
      }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
      this.ocultarMensaje();
      if (this.Session["id_usuario"] == null || this.IsPostBack)
        return;
      this.cargarDesplegables();
      this.eventos();
      if (this.id <= 0L)
        return;
      this.cargarDatos();
    }

    private void cargarDesplegables()
    {
      this.ddlModalidad.DataSource = (object) ModalidadDataAccess.ListarPorEstado(1);
      this.ddlModalidad.DataBind();
    }

    private void eventos() => this.btnGuardar.Click += new EventHandler(this.BtnGuardar_Click);

    private void BtnGuardar_Click(object sender, EventArgs e) => throw new NotImplementedException();

    private void cargarDatos()
    {
      RisPlantillaDomain byPlantillaUser = RisPlantillaDataAccess.GetByPlantillaUser(this.id, Convert.ToInt64(this.Session["id_usuario"]));
      if (byPlantillaUser.id_plantilla <= 0L)
        return;
      this.txtNombre.Text = byPlantillaUser.nombre;
      this.txtTitulo.Text = byPlantillaUser.titulo;
      this.txtTecnica.Text = byPlantillaUser.tecnica;
      this.txtHallazgos.Text = byPlantillaUser.hallazgos;
      this.txtImpresion.Text = byPlantillaUser.impresion;
      this.ddlModalidad.SelectedValue = byPlantillaUser.id_modalidad.ToString();
      this.CargarPlantillaModalidad();
    }

    private void ocultarMensaje()
    {
      this.divMensaje.Visible = false;
      this.btnEliminarCancelar.Visible = false;
      this.btnEliminarSeguro.Visible = false;
    }

    private void Guardar()
    {
      RisPlantillaDataAccess.ListByNameUser(Convert.ToInt64(this.Session["id_usuario"]), this.txtNombre.Text.ToUpper(), this.id);
      RisPlantillaDomain byPlantillaUser = RisPlantillaDataAccess.GetByPlantillaUser(this.id, Convert.ToInt64(this.Session["id_usuario"]));
      byPlantillaUser.nombre = this.txtNombre.Text;
      byPlantillaUser.titulo = this.reemplazarTextoGuardar(this.txtTitulo.Text);
      byPlantillaUser.tecnica = this.reemplazarTextoGuardar(this.txtTecnica.Text);
      byPlantillaUser.hallazgos = this.reemplazarTextoGuardar(this.txtHallazgos.Text);
      byPlantillaUser.impresion = this.reemplazarTextoGuardar(this.txtImpresion.Text);
      byPlantillaUser.id_modalidad = Convert.ToInt32(this.ddlModalidad.SelectedValue);
      byPlantillaUser.id_usuario = Convert.ToInt64(this.Session["id_usuario"]);
      this.id = RisPlantillaDataAccess.Save(byPlantillaUser);
      System.Web.UI.ScriptManager.RegisterStartupScript((Page) this, this.GetType(), "showalert", "alert('Plantilla Almacenada Existosamente');", true);
    }

    protected void btnGuardar_Click(object sender, EventArgs e) => this.Guardar();

    [WebMethod]
    public static ArrayList obtenerCredenciales()
    {
      ArrayList arrayList = new ArrayList();
      VocaliDomain byId1 = VocaliDataAccess.GetById(1);
      UsuarioDomain byId2 = UsuarioDataAccess.GetById(Convert.ToInt64(HttpContext.Current.Session["id_usuario"].ToString()));
      if (byId1.estado == 1 && byId2.vocali == 1)
        arrayList.Add((object) new
        {
          username = byId2.username,
          password = byId2.password,
          host = byId1.direccion_url,
          port = byId1.puerto,
          agent = byId2.agente_vocali,
          urlImagenes = "",
          activarVocali = byId2.vocali
        });
      else
        arrayList.Add((object) new
        {
          username = "",
          password = "",
          host = "",
          port = "",
          agent = "",
          activarVocali = 0
        });
      return arrayList;
    }

    protected void btnVolver_Click(object sender, EventArgs e) => this.Response.Redirect("ListarPlantilla.aspx");

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
      this.divMensaje.Visible = true;
      this.lblAlertWarning.Text = "¿Esta seguro de eliminar esta plantilla? esta acción no se puede revertir.";
      this.btnEliminarCancelar.Visible = true;
      this.btnEliminarSeguro.Visible = true;
    }

    protected void btnEliminarCancelar_Click(object sender, EventArgs e) => this.ocultarMensaje();

    protected void btnEliminarSeguro_Click(object sender, EventArgs e)
    {
      RisPlantillaDomain byPlantillaUser = RisPlantillaDataAccess.GetByPlantillaUser(this.id, Convert.ToInt64(this.Session["id_usuario"]));
      if (!this.gvModalidades.Rows.Count.Equals(0))
      {
        System.Web.UI.ScriptManager.RegisterStartupScript((Page) this, this.GetType(), "showalert", "alert('No puede realizar esta Acción sin desvincular la Modalidad.');", true);
      }
      else
      {
        RisPlantillaDataAccess.DeleteByIdPlantilla(byPlantillaUser.id_plantilla);
        if (RisPlantillaDataAccess.GetByPlantillaUser(this.id, Convert.ToInt64(this.Session["id_usuario"])).id_plantilla != 0L)
          return;
        System.Web.UI.ScriptManager.RegisterStartupScript((Page) this, this.GetType(), "showalert", "alert('Planilla Eliminada Existosamente.');", true);
        this.Response.Redirect("../Plantilla/ListarPlantilla.aspx");
      }
    }

    private string reemplazarTextoGuardar(string texto)
    {
      texto = texto.Replace("&Aacute;", "Á");
      texto = texto.Replace("&aacute;", "á");
      texto = texto.Replace("&Eacute;", "É");
      texto = texto.Replace("&eacute;", "é");
      texto = texto.Replace("&Iacute;", "I");
      texto = texto.Replace("&iacute;", "í");
      texto = texto.Replace("&Oacute;", "Ó");
      texto = texto.Replace("&oacute;", "ó");
      texto = texto.Replace("&Uacute;", "Ú");
      texto = texto.Replace("&uacute;", "ú");
      texto = texto.Replace("&Ntilde;", "Ñ");
      texto = texto.Replace("&ntilde;", "ñ");
      texto = texto.Replace("&nbsp;", " ");
      return texto;
    }

    protected void btnAsignarModalidad_Click(object sender, EventArgs e)
    {
      if (this.id == 0L)
        this.Guardar();
      PlantillaModalidadDomain plantillaModalidad = PlantillaModalidadDataAccess.GetByPlantillaModalidad(this.id, Convert.ToInt32(this.ddlModalidad.SelectedValue));
      if (plantillaModalidad.id_plantilla == 0L)
      {
        plantillaModalidad.id_plantilla = this.id;
        plantillaModalidad.id_modalidad = Convert.ToInt32(this.ddlModalidad.SelectedValue);
        PlantillaModalidadDataAccess.Save(plantillaModalidad);
      }
      this.CargarPlantillaModalidad();
    }

    private void CargarPlantillaModalidad()
    {
      DataTable dataTable = new DataTable();
      dataTable.Columns.Add("id_plantilla_modalidad");
      dataTable.Columns.Add("nombre");
      foreach (PlantillaModalidadDomain plantillaModalidadDomain in (IEnumerable<PlantillaModalidadDomain>) PlantillaModalidadDataAccess.GetByPlantilla(this.id))
      {
        ModalidadDomain byId = ModalidadDataAccess.GetByID(plantillaModalidadDomain.id_modalidad);
        DataRow row = dataTable.NewRow();
        row["id_plantilla_modalidad"] = (object) plantillaModalidadDomain.id_plantilla_modalidad;
        row["nombre"] = (object) byId.nombre;
        dataTable.Rows.Add(row);
      }
      this.gvModalidades.DataSource = (object) dataTable;
      this.gvModalidades.DataBind();
    }

    protected void gvModalidades_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      if (!(e.CommandName == "Eliminar"))
        return;
      Label control = (Label) this.gvModalidades.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Controls[1];
      long result = 0;
      if (long.TryParse(control.Text, out result))
        PlantillaModalidadDataAccess.DeleteById(Convert.ToInt64(control.Text));
      this.CargarPlantillaModalidad();
    }
  }
}
