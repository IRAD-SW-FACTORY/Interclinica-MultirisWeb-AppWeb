// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Web.Examen.InformarOIT1
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using MultiRisWeb.ConsumirServicios;
using MultiRisWeb.Data.DataAccess;
using MultiRisWeb.Data.Domain;
using MultiRisWeb.Data.Util;
using MultiRisWeb.Encrypt.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MultiRisWeb.Web.Examen
{
  public class InformarOIT1 : Page
  {
    public static long id_ris_examen = 0;
    public static string codExamen = string.Empty;
    public static long id_institucion = 0;
    public static long id_informe = 0;
    public static long[] id_prestacion = new long[0];
    private static string clave = "";
    private static string p_val = "";
    protected HtmlInputHidden val_actual;
    protected Label lblCentro;
    protected Label lblIdPaciente;
    protected Label lblNombre;
    protected Label lblAcc;
    protected Label lblSexo;
    protected Label lblEdad;
    protected Label lblVisores;
    protected GridView gvPrestaciones;
    protected GridView gvDocumentosRelacionados;
    protected TextBox txtNombrePaciente;
    protected TextBox txtIdentificador;
    protected TextBox txtFechaRadiografia;
    protected TextBox txtNumeroRadiografia;
    protected RadioButtonList rb_radiografia_digital;
    protected ListItem siRadiografiaDigital;
    protected ListItem noRadiografiaDigital;
    protected TextBox txtMedico;
    protected TextBox txtTencologo;
    protected RadioButtonList rb_lectura_Negatoscopio;
    protected ListItem siLecturaEnNegatoscopio;
    protected ListItem noLecturaEnNegatoscopio;
    protected RadioButtonList rb_tecnica_Quialidaden;
    protected ListItem aTecnicaQuilidaden;
    protected ListItem bTecnicaQuilidaden;
    protected ListItem cTecnicaQuilidaden;
    protected ListItem dTecnicaQuilidaden;
    protected RadioButtonList rb_radiografia_Normal;
    protected ListItem siRadiografiaNormal;
    protected ListItem noRadiografiaNormal;
    protected TextBox txtComentario;
    protected RadioButtonList rb_anormalidad_Parenquimatosa;
    protected ListItem siAnormalidadPerenquimatosa;
    protected ListItem noAnormalidadPerequimatosa;
    protected RadioButtonList rb_primaria1;
    protected ListItem pPrimaria1;
    protected ListItem sPrimaria1;
    protected RadioButtonList rb_secundaria1;
    protected ListItem pSecundaria1;
    protected ListItem sSecundaria1;
    protected RadioButtonList rb_primaria2;
    protected ListItem qPrimaria2;
    protected ListItem tPrimaria2;
    protected RadioButtonList rb_secundaria2;
    protected ListItem qSecundaria2;
    protected ListItem tSecundaria2;
    protected RadioButtonList rb_primaria3;
    protected ListItem rPrimaria3;
    protected ListItem uPrimaria3;
    protected RadioButtonList rb_secundaria3;
    protected ListItem rSecundaria3;
    protected ListItem uSecundaria3;
    protected RadioButtonList rb_zonas;
    protected ListItem dZonas;
    protected ListItem iZonas;
    protected RadioButtonList rb_profusion1;
    protected ListItem arb_profusion1;
    protected ListItem brb_profusion1;
    protected RadioButtonList rb_profusion2;
    protected ListItem arb_profusion2;
    protected ListItem brb_profusion2;
    protected ListItem crb_profusion2;
    protected RadioButtonList rb_profusion3;
    protected ListItem arb_profusion3;
    protected ListItem brb_profusion3;
    protected ListItem crb_profusion3;
    protected RadioButtonList rb_profusion4;
    protected ListItem aProfusion4;
    protected ListItem bprofusion4;
    protected RadioButtonList rb_opacidades_Pequenas;
    protected ListItem oOpacidadesPequeñas;
    protected ListItem aOpacidadesPequeñas;
    protected ListItem cOpacidadesPequeñas;
    protected ListItem bOpacidadesPequeñas;
    protected RadioButtonList rb_anormalidad_Pleural;
    protected ListItem siAnormalidadPleural;
    protected ListItem noAnormalidadPleural;
    protected RadioButtonList rb_placas_pleurales;
    protected ListItem siPlacasPleurales;
    protected ListItem noPlacasPleurales;
    protected RadioButtonList rb_placas_pleurales_sitio_perfil;
    protected ListItem oPlacasPleuralesSitioPerfil;
    protected ListItem dPlacasPleuralesSitioPerfil;
    protected ListItem iPlacasPleuralesSitioPerfil;
    protected RadioButtonList rb_placas_pleurales_calcificacion_perfil;
    protected ListItem oPlacasPleuralesCalcificacionPerfil;
    protected ListItem dPlacasPleuralesCalcificacionPerfil;
    protected ListItem iPlacasPleuralesCalcificacionPerfil;
    protected RadioButtonList rb_placas_pleurales_sitio_frente;
    protected ListItem oPlacasPleuralesSitioFrente;
    protected ListItem dPlacasPleuralesSitioFrente;
    protected ListItem iPlacasPleuralesSitioFrente;
    protected RadioButtonList rb_placas_pleurales_calcificacion_frente;
    protected ListItem oPlacasPleuralesCalcificacionFrente;
    protected ListItem dPlacasPleuralesCalcificacionFrente;
    protected ListItem iPlacasPleuralesCalcificacionFrente;
    protected RadioButtonList rb_placas_pleurales_sitio_diagrama;
    protected ListItem oPlacasPleuralesSitioDiagrama;
    protected ListItem dPlacasPleuralesSitioDiagrama;
    protected ListItem iPlacasPleuralesSitioDiagrama;
    protected RadioButtonList rb_placas_pleurales_calcificacion_diagrama;
    protected ListItem oPlacasPleuralesCalcificacionDiagrama;
    protected ListItem dPlacasPleuralesCalcificacionDiagrama;
    protected ListItem iPlacasPleuralesCalcificacionDiagrama;
    protected RadioButtonList rb_placas_pleurales_sitio_otro;
    protected ListItem oPlacasPleuralesSitioOtro;
    protected ListItem dPlacasPleuralesSitioOtro;
    protected ListItem iPlacasPleuralesSitioOtro;
    protected RadioButtonList rb_placas_pleurales_calcificacion_otro;
    protected ListItem oPlacasPleuralesCalcificacionOtro;
    protected ListItem dPlacasPleuralesCalcificacionOtro;
    protected ListItem iPlacasPleuralesCalcificacionOtro;
    protected RadioButtonList rb_placas_pleurales_extencion_pared1;
    protected ListItem oPlacasPleuralesExtenconPared1;
    protected ListItem dPlacasPleuralesExtenconPared1;
    protected ListItem cPlacasPleuralesExtenconPared1;
    protected ListItem gPlacasPleuralesExtenconPared1;
    protected ListItem yPlacasPleuralesExtenconPared1;
    protected RadioButtonList rb_placas_pleurales_extencion_pared2;
    protected ListItem oPlacasPleuralesExtencionPared2;
    protected ListItem iPlacasPleuralesExtencionPared2;
    protected ListItem cPlacasPleuralesExtencionPared2;
    protected ListItem dPlacasPleuralesExtencionPared2;
    protected ListItem ePlacasPleuralesExtencionPared2;
    protected RadioButtonList rb_placas_plurales_ancho1;
    protected ListItem dPlacasPleuralesAncho1;
    protected ListItem aPlacasPleuralesAncho1;
    protected ListItem bPlacasPleuralesAncho1;
    protected ListItem cPlacasPleuralesAncho1;
    protected RadioButtonList rb_placas_plurales_ancho2;
    protected ListItem iPlacasPleuralesAncho2;
    protected ListItem aPlacasPleuralesAncho2;
    protected ListItem bPlacasPleuralesAncho2;
    protected ListItem cPlacasPleuralesAncho2;
    protected RadioButtonList rb_obliteracion_angulo_costofrenico;
    protected ListItem oObliteracionAnguloCostofrenico;
    protected ListItem dObliteracionAnguloCostofrenico;
    protected ListItem iObliteracionAnguloCostofrenico;
    protected RadioButtonList rb_engrosamiento_pleural_difuso;
    protected ListItem siEngrosamientoPleuralDifuso;
    protected ListItem noEngrosamientoPleuralDifuso;
    protected RadioButtonList rb_engrosamiento_pleural_difuso_sitio_perfil;
    protected ListItem oEngrosamientoPleuralDifusoSitioPerfil;
    protected ListItem dEngrosamientoPleuralDifusoSitioPerfil;
    protected ListItem iEngrosamientoPleuralDifusoSitioPerfil;
    protected RadioButtonList rb_engrosamiento_pleural_difuso_calcificacion_perfil;
    protected ListItem oEngrosamientoPleuralDifusoCalcificacionPerfil;
    protected ListItem dEngrosamientoPleuralDifusoCalcificacionPerfil;
    protected ListItem iEngrosamientoPleuralDifusoCalcificacionPerfil;
    protected RadioButtonList rb_engrosamiento_pleural_difuso_sitio_frente;
    protected ListItem oEngrosamientoPleuralDifusoSitioFrente;
    protected ListItem dEngrosamientoPleuralDifusoSitioFrente;
    protected ListItem iEngrosamientoPleuralDifusoSitioFrente;
    protected RadioButtonList rb_engrosamiento_pleural_difuso_calcificacion_frente;
    protected ListItem oEngrosamientoPleuralDifusoCalcificacionFrente;
    protected ListItem dEngrosamientoPleuralDifusoCalcificacionFrente;
    protected ListItem iEngrosamientoPleuralDifusoCalcificacionFrente;
    protected RadioButtonList rb_engrosamiento_pleural_difuso_extencion_pared1;
    protected ListItem oEngrosamientoPleuralDifusoExtencionPared1;
    protected ListItem dEngrosamientoPleuralDifusoExtencionPared1;
    protected ListItem gEngrosamientoPleuralDifusoExtencionPared1;
    protected ListItem hEngrosamientoPleuralDifusoExtencionPared1;
    protected ListItem jEngrosamientoPleuralDifusoExtencionPared1;
    protected RadioButtonList rb_engrosamiento_pleural_difuso_extencion_pared2;
    protected ListItem oEngrosamientoPleuralDifusoExtencionPared2;
    protected ListItem iEngrosamientoPleuralDifusoExtencionPared2;
    protected ListItem gEngrosamientoPleuralDifusoExtencionPared2;
    protected ListItem hEngrosamientoPleuralDifusoExtencionPared2;
    protected ListItem jEngrosamientoPleuralDifusoExtencionPared2;
    protected RadioButtonList rb_engrosamiento_pleural_difuso_ancho1;
    protected ListItem dEngrosamientoPleuralDifusoAncho1;
    protected ListItem aEngrosamientoPleuralDifusoAncho1;
    protected ListItem bEngrosamientoPleuralDifusoAncho1;
    protected ListItem cEngrosamientoPleuralDifusoAncho1;
    protected RadioButtonList rb_engrosamiento_pleural_difuso_ancho2;
    protected ListItem iEngrosamientoPleuralDifusoAncho2;
    protected ListItem aEngrosamientoPleuralDifusoAncho2;
    protected ListItem bEngrosamientoPleuralDifusoAncho2;
    protected ListItem cEngrosamientoPleuralDifusoAncho2;
    protected RadioButtonList rb_otras_anormalidades;
    protected ListItem siOtrasAnormalidades;
    protected ListItem noOtrasAnormalidades;
    protected CheckBox cb_simbolo_aa;
    protected CheckBox cb_simbolo_at;
    protected CheckBox cb_simbolo_ax;
    protected CheckBox cb_simbolo_bu;
    protected CheckBox cb_simbolo_ca;
    protected CheckBox cb_simbolo_cg;
    protected CheckBox cb_simbolo_cn;
    protected CheckBox cb_simbolo_co;
    protected CheckBox cb_simbolo_cp;
    protected CheckBox cb_simbolo_cv;
    protected CheckBox cb_simbolo_di;
    protected CheckBox cb_simbolo_ef;
    protected CheckBox cb_simbolo_em;
    protected CheckBox cb_simbolo_es;
    protected CheckBox cb_simbolo_fr;
    protected CheckBox cb_simbolo_hi;
    protected CheckBox cb_simbolo_ho;
    protected CheckBox cb_simbolo_id;
    protected CheckBox cb_simbolo_ih;
    protected CheckBox cb_simbolo_kl;
    protected CheckBox cb_simbolo_me;
    protected CheckBox cb_simbolo_pa;
    protected CheckBox cb_simbolo_pb;
    protected CheckBox cb_simbolo_pi;
    protected CheckBox cb_simbolo_px;
    protected CheckBox cb_simbolo_ra;
    protected CheckBox cb_simbolo_rp;
    protected CheckBox cb_simbolo_tb;
    protected CheckBox cb_simbolo_od;
    protected TextBox txt_comentario_general;
    protected TextBox txtFechaLectura;
    protected Button btnValidar;
    protected Button btnGuardar1;
    protected Button btnRegresar;

    public string val
    {
      get
      {
        InformarOIT1.p_val = ParamUtil.GetParamString((object) this.Request[nameof (val)], "");
        if (InformarOIT1.p_val != "")
        {
          this.val_actual.Value = InformarOIT1.p_val.ToString();
          ConfiguracionGeneralDomain byId1 = ConfiguracionGeneralDataAccess.GetById(1L);
          ConfiguracionGeneralDomain byId2 = ConfiguracionGeneralDataAccess.GetById(2L);
          string[] strArray = EncCode.Decode(InformarOIT1.p_val.Replace(" ", "+"), byId1.valor1, byId2.valor1).Split('&', '=');
          for (int index = 0; index < strArray.Length; ++index)
          {
            if (strArray[index] == "id_ris_examen")
              InformarOIT1.id_ris_examen = Convert.ToInt64(strArray[index + 1]);
            if (strArray[index] == "codexamen")
              InformarOIT1.codExamen = strArray[index + 1];
            if (strArray[index] == "idInstitucion")
              InformarOIT1.id_institucion = Convert.ToInt64(strArray[index + 1]);
            if (strArray[index] == "id_informe")
              InformarOIT1.id_informe = Convert.ToInt64(strArray[index + 1]);
            if (strArray[index] == "idprestacion")
              InformarOIT1.id_prestacion = ParamUtil.GetParamLongValues((object) strArray[index + 1], new long[0]);
            if (strArray[index] == "clave")
              InformarOIT1.clave = strArray[index + 1];
          }
        }
        else
          InformarOIT1.p_val = ParamUtil.GetParamString((object) this.val_actual.Value, "");
        return InformarOIT1.p_val;
      }
      set
      {
        InformarOIT1.p_val = value;
        this.val_actual.Value = value.ToString();
      }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Session["id_usuario"] != null)
      {
        if (this.IsPostBack)
          return;
        string val = this.val;
        if (ConfiguracionGeneralDataAccess.GetById(3L).valor1 == InformarOIT1.clave)
        {
          this.cargarVisor();
          this.cargarDatos();
        }
        else
          this.Response.Redirect("");
      }
      else
        this.Response.Redirect("../Control/CerrarSesion.aspx");
    }

    private void cargarVisor()
    {
      MeddreamsUtil meddreamsUtil = new MeddreamsUtil();
      InstitucionDomain byId = InstitucionDataAccess.GetById(Convert.ToInt32(InformarOIT1.id_institucion));
      RisExamenDomain institucionCodExamen = RisExamenDataAccess.GetByInstitucionCodExamen(InformarOIT1.id_institucion, byId.aetitle, InformarOIT1.codExamen);
      if (institucionCodExamen.id_ris_examen <= 0L)
        return;
      this.lblVisores.Text = meddreamsUtil.generarStringVisores(institucionCodExamen.codexamen, byId.id_institucion, true, Convert.ToInt64(this.Session["id_usuario"].ToString()));
    }

    private void cargarDatos()
    {
      InstitucionDomain byId1 = InstitucionDataAccess.GetById(Convert.ToInt32(InformarOIT1.id_institucion));
      RisExamenDomain institucionCodExamen = RisExamenDataAccess.GetByInstitucionCodExamen(InformarOIT1.id_institucion, byId1.aetitle, InformarOIT1.codExamen);
      this.lblCentro.Text = byId1.nombre;
      this.cargarEstudiosRelacionados(byId1.id_institucion, institucionCodExamen.idpaciente);
      this.cargarDocumentosRelacionados(byId1.id_institucion, institucionCodExamen.idpaciente, institucionCodExamen.codexamen);
      RisInformeDomain byId2 = RisInformeDataAccess.GetByID(InformarOIT1.id_informe);
      if (institucionCodExamen.id_ris_examen > 0L)
      {
        this.cargarInforme(byId2, institucionCodExamen);
        this.lblIdPaciente.Text = institucionCodExamen.idpaciente;
        this.lblNombre.Text = (institucionCodExamen.nombre + " " + institucionCodExamen.apellidopaterno + " " + institucionCodExamen.apellidomaterno).Replace("^", " ");
        this.lblEdad.Text = institucionCodExamen.edad;
        this.lblAcc.Text = institucionCodExamen.numeroacceso;
        this.lblSexo.Text = institucionCodExamen.sexo;
        this.txtTencologo.Text = institucionCodExamen.tecnologo;
        this.txtNombrePaciente.Text = institucionCodExamen.nombre.Replace("^", " ");
        this.txtIdentificador.Text = institucionCodExamen.idpaciente;
        this.txtFechaRadiografia.Text = institucionCodExamen.fechaexamen.ToString("dd-MM-yyyy");
        UsuarioDomain byId3 = UsuarioDataAccess.GetById((long) Convert.ToInt32(this.Session["id_usuario"].ToString()));
        this.txtMedico.Text = byId3.nombre + " " + byId3.apellido_paterno + " " + byId3.apellido_materno + " / " + byId3.rut;
        InstitucionVisorDataAccess.GetAllForInstitucionAndVisor(byId1.id_institucion, byId3.id_visor);
        if (byId2.id_estado_informe == 2)
          byId1.url_informe.Replace("#AETITLE#", byId1.aetitle).Replace("#CODEXAMEN#", byId2.codExamen.ToString()).Replace("#IDINFORME#", byId2.id_informe_remoto.ToString());
      }
      DataTable dataTable = new DataTable();
      dataTable.Columns.Add("nombrePrestacion");
      if (InformarOIT1.id_prestacion.Length != 0)
      {
        for (int index = 0; index < InformarOIT1.id_prestacion.Length; ++index)
        {
          DataRow row = dataTable.NewRow();
          RisPrestacionDomain byId4 = RisPrestacionDataAccess.GetById(InformarOIT1.id_prestacion[index]);
          row["nombrePrestacion"] = (object) byId4.nombre;
          dataTable.Rows.Add(row);
        }
      }
      else
      {
        foreach (RisInformePrestacionDomain prestacionDomain in (IEnumerable<RisInformePrestacionDomain>) RisInformePrestacionDataAccess.GetByIdInforme(byId2.id_ris_informe))
        {
          DataRow row = dataTable.NewRow();
          RisPrestacionDomain byId5 = RisPrestacionDataAccess.GetById(prestacionDomain.id_prestacion);
          row["nombrePrestacion"] = (object) byId5.nombre;
          dataTable.Rows.Add(row);
        }
      }
      this.gvPrestaciones.DataSource = (object) dataTable;
      this.gvPrestaciones.DataBind();
    }

    private void cargarEstudiosRelacionados(int id_institucion, string id_paciente)
    {
      ConsumirWS consumirWs = new ConsumirWS();
      ConsumirApi consumirApi = new ConsumirApi();
      DataTable dataTable = new DataTable();
      InstitucionDomain byId = InstitucionDataAccess.GetById(id_institucion);
      if (byId.id_institucion > 0)
      {
        InstitucionDatosDomain methodAndInstitucion = InstitucionDatosDataAccess.GetByIdMethodAndInstitucion(9, byId.id_institucion);
        if (byId.id_tipo_conexion == 1)
          dataTable = InformarOIT1.normalizaDataTableEstudiosRelacionados(consumirApi.ApiObtenerDataTable(methodAndInstitucion.url, methodAndInstitucion.metodo, InformarOIT1.jsonEstudiosRelacionados(id_paciente), id_institucion), id_institucion, id_paciente);
        else if (byId.id_tipo_conexion == 2)
          dataTable = InformarOIT1.normalizaDataTableEstudiosRelacionados(ConsumirWS.GetEstudiosRelacionados(id_paciente, id_institucion), id_institucion, id_paciente);
      }
      if (dataTable.Rows.Count <= 0)
        return;
      DataView defaultView = dataTable.DefaultView;
      defaultView.Sort = "Fecha_examen DESC";
      defaultView.ToTable();
    }

    private static DataTable normalizaDataTableEstudiosRelacionados(
      DataTable dtOrigen,
      int id_institucion,
      string id_paciente)
    {
      InstitucionDomain byId = InstitucionDataAccess.GetById(id_institucion);
      IList<VisorDomain> allForState = VisorDataAccess.GetAllForState(1);
      DataTable dataTable = new DataTable();
      int num = 0;
      dataTable.Columns.Add("fecha_examen");
      dataTable.Columns.Add("descripcion");
      dataTable.Columns.Add("modalidad");
      dataTable.Columns.Add("informe");
      dataTable.Columns.Add("descargar_examen");
      dataTable.Columns.Add("visualizadores");
      dataTable.Columns.Add(nameof (id_institucion));
      dataTable.Columns.Add(nameof (id_paciente));
      dataTable.Columns.Add("identificador");
      foreach (DataRow row1 in (InternalDataCollectionBase) dtOrigen.Rows)
      {
        DataRow row2 = dataTable.NewRow();
        ++num;
        string str1 = "btn_identificador" + num.ToString();
        row2["fecha_examen"] = row1["fecha_examen"];
        row2["descripcion"] = (object) row1["descripcion"].ToString().ToUpper();
        row2["modalidad"] = row1["modalidad"];
        row2["descargar_examen"] = (object) byId.url_descarga.Replace("#AETITLE#", byId.aetitle).Replace("#CODEXAMEN#", row1["codexamen"].ToString());
        row2[nameof (id_institucion)] = (object) id_institucion;
        row2[nameof (id_paciente)] = (object) id_paciente;
        row2["identificador"] = (object) str1;
        string str2 = "";
        if (row1["fecha_examen"].ToString() == "1")
        {
          foreach (VisorDomain visorDomain in (IEnumerable<VisorDomain>) allForState)
          {
            InstitucionVisorDomain institucionAndVisor = InstitucionVisorDataAccess.GetAllForInstitucionAndVisor(byId.id_institucion, visorDomain.id_visor);
            str2 = str2 + "&nbsp;<a href='" + institucionAndVisor.url.Replace("#AETITLE#", byId.aetitle).Replace("#CODEXAMEN#", row1["codexamen"].ToString()).Replace("#modalidad#", row1["modalidad"].ToString()) + "' target='_blank' title='Ver con " + visorDomain.nombre + "' ><img class='imgvisor' src='../icon/" + visorDomain.icono + "' ></a>";
          }
        }
        row2["visualizadores"] = (object) str2;
        dataTable.Rows.Add(row2);
      }
      return dataTable;
    }

    private void cargarInforme(RisInformeDomain informe, RisExamenDomain examen)
    {
      if (informe.id_ris_informe <= 0L)
      {
        this.noLecturaEnNegatoscopio.Selected = true;
        this.siRadiografiaDigital.Selected = true;
        this.aTecnicaQuilidaden.Selected = true;
        this.siRadiografiaNormal.Selected = true;
        this.noAnormalidadPerequimatosa.Selected = true;
        this.noOtrasAnormalidades.Selected = true;
      }
      else
      {
        RisInformeOITDomain byIdInforme = RisInformeDataAccess.GetByIdInforme(informe.codExamen);
        UsuarioDataAccess.GetById((long) Convert.ToInt32(this.Session["id_usuario"].ToString()));
        if (byIdInforme.id > 0L)
        {
          if (byIdInforme.radiografiaDigital == "SI")
            this.siRadiografiaDigital.Selected = true;
          else if (byIdInforme.radiografiaDigital == "NO")
            this.noRadiografiaDigital.Selected = true;
          if (byIdInforme.lecturaNegatoscopio == "SI")
            this.siLecturaEnNegatoscopio.Selected = true;
          else if (byIdInforme.lecturaNegatoscopio == "NO")
            this.noLecturaEnNegatoscopio.Selected = true;
          if (byIdInforme.tecnicaQualidaden == "1")
            this.aTecnicaQuilidaden.Selected = true;
          else if (byIdInforme.tecnicaQualidaden == "2")
            this.bTecnicaQuilidaden.Selected = true;
          else if (byIdInforme.tecnicaQualidaden == "3")
            this.cTecnicaQuilidaden.Selected = true;
          else if (byIdInforme.tecnicaQualidaden == "4")
            this.dTecnicaQuilidaden.Selected = true;
          this.txtComentario.Text = byIdInforme.comentario;
          this.txtIdentificador.Text = byIdInforme.idPaciente;
          if (byIdInforme.radiografiaNormal == "SI")
            this.siRadiografiaNormal.Selected = true;
          else if (byIdInforme.radiografiaNormal == "NO")
            this.noRadiografiaNormal.Selected = true;
          this.txtNumeroRadiografia.Text = byIdInforme.numeroRadiografia;
          this.txtMedico.Text = byIdInforme.idmedico.ToString();
          if (byIdInforme.anormalidadParenquimatosa == "SI")
            this.siAnormalidadPerenquimatosa.Selected = true;
          else if (byIdInforme.anormalidadParenquimatosa == "NO")
            this.noAnormalidadPerequimatosa.Selected = true;
          if (byIdInforme.primaria1 == "p")
            this.pPrimaria1.Selected = true;
          else if (byIdInforme.primaria1 == "s")
            this.sPrimaria1.Selected = true;
          if (byIdInforme.secundaria1 == "p")
            this.pSecundaria1.Selected = true;
          else if (byIdInforme.secundaria1 == "s")
            this.sSecundaria1.Selected = true;
          if (byIdInforme.primaria2 == "q")
            this.qPrimaria2.Selected = true;
          else if (byIdInforme.primaria2 == "t")
            this.tPrimaria2.Selected = true;
          if (byIdInforme.secundaria2 == "q")
            this.qSecundaria2.Selected = true;
          else if (byIdInforme.secundaria2 == "t")
            this.tSecundaria2.Selected = true;
          if (byIdInforme.primaria3 == "r")
            this.rPrimaria3.Selected = true;
          else if (byIdInforme.primaria3 == "u")
            this.uPrimaria3.Selected = true;
          if (byIdInforme.secundaria3 == "r")
            this.rSecundaria3.Selected = true;
          else if (byIdInforme.secundaria3 == "u")
            this.uSecundaria3.Selected = true;
          if (byIdInforme.zonas1 == "D")
            this.dZonas.Selected = true;
          else if (byIdInforme.zonas1 == "I")
            this.iZonas.Selected = true;
          if (byIdInforme.profusion1 == "0/0")
            this.arb_profusion1.Selected = true;
          else if (byIdInforme.profusion1 == "0/1")
            this.brb_profusion1.Selected = true;
          if (byIdInforme.profusion2 == "1/0")
            this.arb_profusion2.Selected = true;
          else if (byIdInforme.profusion2 == "1/1")
            this.brb_profusion2.Selected = true;
          else if (byIdInforme.profusion2 == "1/2")
            this.crb_profusion2.Selected = true;
          if (byIdInforme.profusion3 == "2/1")
            this.arb_profusion3.Selected = true;
          else if (byIdInforme.profusion3 == "2/2")
            this.brb_profusion3.Selected = true;
          else if (byIdInforme.profusion3 == "2/3")
            this.crb_profusion3.Selected = true;
          if (byIdInforme.profusion4 == "3/2")
            this.aProfusion4.Selected = true;
          else if (byIdInforme.profusion4 == "3/3")
            this.bprofusion4.Selected = true;
          if (byIdInforme.opacidadesPequenas1 == "O")
            this.oOpacidadesPequeñas.Selected = true;
          else if (byIdInforme.opacidadesPequenas1 == "A")
            this.aOpacidadesPequeñas.Selected = true;
          else if (byIdInforme.opacidadesPequenas1 == "C")
            this.cOpacidadesPequeñas.Selected = true;
          else if (byIdInforme.opacidadesPequenas1 == "B")
            this.bOpacidadesPequeñas.Selected = true;
          if (byIdInforme.anormalidadPleural == "SI")
            this.siAnormalidadPleural.Selected = true;
          else if (byIdInforme.anormalidadPleural == "NO")
            this.noAnormalidadPleural.Selected = true;
          if (byIdInforme.placasPleurales == "SI")
            this.siPlacasPleurales.Selected = true;
          else if (byIdInforme.placasPleurales == "NO")
            this.noPlacasPleurales.Selected = true;
          if (byIdInforme.placasPleuralesSitioPerfil == "O")
            this.oPlacasPleuralesSitioPerfil.Selected = true;
          else if (byIdInforme.placasPleuralesSitioPerfil == "D")
            this.dPlacasPleuralesSitioPerfil.Selected = true;
          else if (byIdInforme.placasPleuralesSitioPerfil == "I")
            this.iPlacasPleuralesSitioPerfil.Selected = true;
          if (byIdInforme.placasPleuralesCalcificacionPerfil == "O")
            this.oPlacasPleuralesCalcificacionPerfil.Selected = true;
          else if (byIdInforme.placasPleuralesCalcificacionPerfil == "D")
            this.dPlacasPleuralesCalcificacionPerfil.Selected = true;
          else if (byIdInforme.placasPleuralesCalcificacionPerfil == "I")
            this.iPlacasPleuralesCalcificacionPerfil.Selected = true;
          if (byIdInforme.placasPleuralesSitioFrente == "O")
            this.oPlacasPleuralesSitioFrente.Selected = true;
          else if (byIdInforme.placasPleuralesSitioFrente == "D")
            this.dPlacasPleuralesSitioFrente.Selected = true;
          else if (byIdInforme.placasPleuralesSitioFrente == "I")
            this.iPlacasPleuralesSitioFrente.Selected = true;
          if (byIdInforme.placasPleuralesCalcificacionFrente == "O")
            this.oPlacasPleuralesCalcificacionFrente.Selected = true;
          else if (byIdInforme.placasPleuralesCalcificacionFrente == "D")
            this.dPlacasPleuralesCalcificacionFrente.Selected = true;
          else if (byIdInforme.placasPleuralesCalcificacionFrente == "I")
            this.iPlacasPleuralesCalcificacionFrente.Selected = true;
          if (byIdInforme.placasPleuralesSitioDiagrama == "O")
            this.oPlacasPleuralesSitioDiagrama.Selected = true;
          else if (byIdInforme.placasPleuralesSitioDiagrama == "D")
            this.dPlacasPleuralesSitioDiagrama.Selected = true;
          else if (byIdInforme.placasPleuralesSitioDiagrama == "I")
            this.iPlacasPleuralesSitioDiagrama.Selected = true;
          if (byIdInforme.placasPleuralesCalcificacionDiagrama == "O")
            this.oPlacasPleuralesCalcificacionDiagrama.Selected = true;
          else if (byIdInforme.placasPleuralesCalcificacionDiagrama == "D")
            this.dPlacasPleuralesCalcificacionDiagrama.Selected = true;
          else if (byIdInforme.placasPleuralesCalcificacionDiagrama == "I")
            this.iPlacasPleuralesCalcificacionDiagrama.Selected = true;
          if (byIdInforme.placasPleuralesSitioOtro == "O")
            this.oPlacasPleuralesSitioOtro.Selected = true;
          else if (byIdInforme.placasPleuralesSitioOtro == "D")
            this.dPlacasPleuralesSitioOtro.Selected = true;
          else if (byIdInforme.placasPleuralesSitioOtro == "I")
            this.iPlacasPleuralesSitioOtro.Selected = true;
          if (byIdInforme.placasPleuralesCalcificacionOtro == "O")
            this.oPlacasPleuralesCalcificacionOtro.Selected = true;
          else if (byIdInforme.placasPleuralesCalcificacionOtro == "D")
            this.dPlacasPleuralesCalcificacionOtro.Selected = true;
          else if (byIdInforme.placasPleuralesCalcificacionOtro == "I")
            this.iPlacasPleuralesCalcificacionOtro.Selected = true;
          if (byIdInforme.placasPleuralesExtencionPared1 == "O")
            this.oPlacasPleuralesExtenconPared1.Selected = true;
          else if (byIdInforme.placasPleuralesExtencionPared1 == "D")
            this.dPlacasPleuralesExtenconPared1.Selected = true;
          else if (byIdInforme.placasPleuralesExtencionPared1 == "1")
            this.cPlacasPleuralesExtenconPared1.Selected = true;
          else if (byIdInforme.placasPleuralesExtencionPared1 == "2")
            this.gPlacasPleuralesExtenconPared1.Selected = true;
          else if (byIdInforme.placasPleuralesExtencionPared1 == "3")
            this.yPlacasPleuralesExtenconPared1.Selected = true;
          if (byIdInforme.placasPleuralesExtencionPared2 == "O")
            this.oPlacasPleuralesExtencionPared2.Selected = true;
          else if (byIdInforme.placasPleuralesExtencionPared2 == "I")
            this.iPlacasPleuralesExtencionPared2.Selected = true;
          else if (byIdInforme.placasPleuralesExtencionPared2 == "1")
            this.cPlacasPleuralesExtencionPared2.Selected = true;
          else if (byIdInforme.placasPleuralesExtencionPared2 == "2")
            this.dPlacasPleuralesExtencionPared2.Selected = true;
          else if (byIdInforme.placasPleuralesExtencionPared2 == "3")
            this.ePlacasPleuralesExtencionPared2.Selected = true;
          if (byIdInforme.placasPleuralesAncho1 == "D")
            this.dPlacasPleuralesAncho1.Selected = true;
          else if (byIdInforme.placasPleuralesAncho1 == "a")
            this.aPlacasPleuralesAncho1.Selected = true;
          else if (byIdInforme.placasPleuralesAncho1 == "b")
            this.bPlacasPleuralesAncho1.Selected = true;
          else if (byIdInforme.placasPleuralesAncho1 == "c")
            this.cPlacasPleuralesAncho1.Selected = true;
          if (byIdInforme.placasPleuralesAncho2 == "I")
            this.iPlacasPleuralesAncho2.Selected = true;
          else if (byIdInforme.placasPleuralesAncho2 == "a")
            this.aPlacasPleuralesAncho2.Selected = true;
          else if (byIdInforme.placasPleuralesAncho2 == "b")
            this.bPlacasPleuralesAncho2.Selected = true;
          else if (byIdInforme.placasPleuralesAncho2 == "c")
            this.cPlacasPleuralesAncho2.Selected = true;
          if (byIdInforme.obliteracionAnguloCostofrenico == "O")
            this.oObliteracionAnguloCostofrenico.Selected = true;
          else if (byIdInforme.obliteracionAnguloCostofrenico == "D")
            this.dObliteracionAnguloCostofrenico.Selected = true;
          else if (byIdInforme.obliteracionAnguloCostofrenico == "I")
            this.iObliteracionAnguloCostofrenico.Selected = true;
          if (byIdInforme.engrosamientoPleuralDifuso == "SI")
            this.siEngrosamientoPleuralDifuso.Selected = true;
          else if (byIdInforme.engrosamientoPleuralDifuso == "NO")
            this.noEngrosamientoPleuralDifuso.Selected = true;
          if (byIdInforme.engrosamientoPleuralDifusoSitioPerfil == "O")
            this.oEngrosamientoPleuralDifusoSitioPerfil.Selected = true;
          else if (byIdInforme.engrosamientoPleuralDifusoSitioPerfil == "D")
            this.dEngrosamientoPleuralDifusoSitioPerfil.Selected = true;
          else if (byIdInforme.engrosamientoPleuralDifusoSitioPerfil == "I")
            this.iEngrosamientoPleuralDifusoSitioPerfil.Selected = true;
          if (byIdInforme.engrosamientoPleuralDifusoCalcificacionPerfil == "O")
            this.oEngrosamientoPleuralDifusoCalcificacionPerfil.Selected = true;
          else if (byIdInforme.engrosamientoPleuralDifusoCalcificacionPerfil == "D")
            this.dEngrosamientoPleuralDifusoCalcificacionPerfil.Selected = true;
          else if (byIdInforme.engrosamientoPleuralDifusoCalcificacionPerfil == "I")
            this.iEngrosamientoPleuralDifusoCalcificacionPerfil.Selected = true;
          if (byIdInforme.engrosamientoPleuralDifusoSitioFrente == "O")
            this.oEngrosamientoPleuralDifusoSitioFrente.Selected = true;
          else if (byIdInforme.engrosamientoPleuralDifusoSitioFrente == "D")
            this.dEngrosamientoPleuralDifusoSitioFrente.Selected = true;
          else if (byIdInforme.engrosamientoPleuralDifusoSitioFrente == "I")
            this.iEngrosamientoPleuralDifusoSitioFrente.Selected = true;
          if (byIdInforme.engrosamientoPleuralDifusoCalcificacionFrente == "O")
            this.oEngrosamientoPleuralDifusoCalcificacionFrente.Selected = true;
          else if (byIdInforme.engrosamientoPleuralDifusoCalcificacionFrente == "D")
            this.dEngrosamientoPleuralDifusoCalcificacionFrente.Selected = true;
          else if (byIdInforme.engrosamientoPleuralDifusoCalcificacionFrente == "I")
            this.iEngrosamientoPleuralDifusoCalcificacionFrente.Selected = true;
          if (byIdInforme.engrosamientoPleuralDifusoExtencionPared1 == "O")
            this.oEngrosamientoPleuralDifusoExtencionPared1.Selected = true;
          else if (byIdInforme.engrosamientoPleuralDifusoExtencionPared1 == "D")
            this.dEngrosamientoPleuralDifusoExtencionPared1.Selected = true;
          else if (byIdInforme.engrosamientoPleuralDifusoExtencionPared1 == "1")
            this.gEngrosamientoPleuralDifusoExtencionPared1.Selected = true;
          else if (byIdInforme.engrosamientoPleuralDifusoExtencionPared1 == "2")
            this.hEngrosamientoPleuralDifusoExtencionPared1.Selected = true;
          else if (byIdInforme.engrosamientoPleuralDifusoExtencionPared1 == "3")
            this.jEngrosamientoPleuralDifusoExtencionPared1.Selected = true;
          if (byIdInforme.engrosamientoPleuralDifusoExtencionPared2 == "O")
            this.oEngrosamientoPleuralDifusoExtencionPared2.Selected = true;
          else if (byIdInforme.engrosamientoPleuralDifusoExtencionPared2 == "I")
            this.iEngrosamientoPleuralDifusoExtencionPared2.Selected = true;
          else if (byIdInforme.engrosamientoPleuralDifusoExtencionPared2 == "1")
            this.gEngrosamientoPleuralDifusoExtencionPared2.Selected = true;
          else if (byIdInforme.engrosamientoPleuralDifusoExtencionPared2 == "2")
            this.hEngrosamientoPleuralDifusoExtencionPared2.Selected = true;
          else if (byIdInforme.engrosamientoPleuralDifusoExtencionPared2 == "3")
            this.jEngrosamientoPleuralDifusoExtencionPared2.Selected = true;
          if (byIdInforme.engrosamientoPleuralDifusoAncho1 == "D")
            this.dEngrosamientoPleuralDifusoAncho1.Selected = true;
          else if (byIdInforme.engrosamientoPleuralDifusoAncho1 == "A")
            this.aEngrosamientoPleuralDifusoAncho1.Selected = true;
          else if (byIdInforme.engrosamientoPleuralDifusoAncho1 == "B")
            this.bEngrosamientoPleuralDifusoAncho1.Selected = true;
          else if (byIdInforme.engrosamientoPleuralDifusoAncho1 == "C")
            this.cEngrosamientoPleuralDifusoAncho1.Selected = true;
          if (byIdInforme.engrosamientoPleuralDifusoAncho2.ToUpper() == "I")
            this.iEngrosamientoPleuralDifusoAncho2.Selected = true;
          else if (byIdInforme.engrosamientoPleuralDifusoAncho2.ToUpper() == "A")
            this.aEngrosamientoPleuralDifusoAncho2.Selected = true;
          else if (byIdInforme.engrosamientoPleuralDifusoAncho2.ToUpper() == "B")
            this.bEngrosamientoPleuralDifusoAncho2.Selected = true;
          else if (byIdInforme.engrosamientoPleuralDifusoAncho2.ToUpper() == "C")
            this.cEngrosamientoPleuralDifusoAncho2.Selected = true;
          if (byIdInforme.otrasAnormalidades == "SI")
            this.siOtrasAnormalidades.Selected = true;
          else if (byIdInforme.otrasAnormalidades == "NO")
            this.noOtrasAnormalidades.Selected = true;
          if (byIdInforme.simbolo_aa == 1)
            this.cb_simbolo_aa.Checked = true;
          if (byIdInforme.simbolo_at == 1)
            this.cb_simbolo_at.Checked = true;
          if (byIdInforme.simbolo_ax == 1)
            this.cb_simbolo_ax.Checked = true;
          if (byIdInforme.simbolo_bu == 1)
            this.cb_simbolo_bu.Checked = true;
          if (byIdInforme.simbolo_ca == 1)
            this.cb_simbolo_ca.Checked = true;
          if (byIdInforme.simbolo_cg == 1)
            this.cb_simbolo_cg.Checked = true;
          if (byIdInforme.simbolo_cn == 1)
            this.cb_simbolo_cn.Checked = true;
          if (byIdInforme.simbolo_co == 1)
            this.cb_simbolo_co.Checked = true;
          if (byIdInforme.simbolo_cp == 1)
            this.cb_simbolo_cp.Checked = true;
          if (byIdInforme.simbolo_cv == 1)
            this.cb_simbolo_cv.Checked = true;
          if (byIdInforme.simbolo_di == 1)
            this.cb_simbolo_di.Checked = true;
          if (byIdInforme.simbolo_ef == 1)
            this.cb_simbolo_ef.Checked = true;
          if (byIdInforme.simbolo_em == 1)
            this.cb_simbolo_em.Checked = true;
          if (byIdInforme.simbolo_es == 1)
            this.cb_simbolo_es.Checked = true;
          if (byIdInforme.simbolo_fr == 1)
            this.cb_simbolo_fr.Checked = true;
          if (byIdInforme.simbolo_hi == 1)
            this.cb_simbolo_hi.Checked = true;
          if (byIdInforme.simbolo_ho == 1)
            this.cb_simbolo_ho.Checked = true;
          if (byIdInforme.simbolo_id == 1)
            this.cb_simbolo_id.Checked = true;
          if (byIdInforme.simbolo_ih == 1)
            this.cb_simbolo_ih.Checked = true;
          if (byIdInforme.simbolo_kl == 1)
            this.cb_simbolo_kl.Checked = true;
          if (byIdInforme.simbolo_me == 1)
            this.cb_simbolo_me.Checked = true;
          if (byIdInforme.simbolo_pa == 1)
            this.cb_simbolo_pa.Checked = true;
          if (byIdInforme.simbolo_pb == 1)
            this.cb_simbolo_pb.Checked = true;
          if (byIdInforme.simbolo_pi == 1)
            this.cb_simbolo_pi.Checked = true;
          if (byIdInforme.simbolo_px == 1)
            this.cb_simbolo_px.Checked = true;
          if (byIdInforme.simbolo_ra == 1)
            this.cb_simbolo_ra.Checked = true;
          if (byIdInforme.simbolo_rp == 1)
            this.cb_simbolo_rp.Checked = true;
          if (byIdInforme.simbolo_tb == 1)
            this.cb_simbolo_tb.Checked = true;
          if (byIdInforme.simbolo_od == 1)
            this.cb_simbolo_od.Checked = true;
          this.txtFechaLectura.Text = byIdInforme.fechaLectura.ToString("dd-MM-yyyy");
          this.txt_comentario_general.Text = byIdInforme.comentarioGeneral;
        }
        else
        {
          this.txtIdentificador.Text = examen.idpaciente;
          this.txtFechaRadiografia.Text = examen.fechaexamen.ToString("dd-MM-yyyy");
          this.txtNombrePaciente.Text = examen.nombre + " " + examen.apellidopaterno + " " + examen.apellidomaterno;
        }
      }
    }

    private void guardarInformeOIT(int id_estado)
    {
      RisInformeDomain byId1 = RisInformeDataAccess.GetByID(InformarOIT1.id_informe);
      InstitucionDomain byId2 = InstitucionDataAccess.GetById(Convert.ToInt32(InformarOIT1.id_institucion));
      RisExamenDomain institucionCodExamen = RisExamenDataAccess.GetByInstitucionCodExamen(InformarOIT1.id_institucion, byId2.aetitle, InformarOIT1.codExamen);
      UsuarioDomain byId3 = UsuarioDataAccess.GetById((long) Convert.ToInt32(this.Session["id_usuario"].ToString()));
      ConsumirApi consumirApi = new ConsumirApi();
      ConsumirWS consumirWs = new ConsumirWS();
      InstitucionDatosDataAccess.GetByIdMethodAndInstitucion(2, byId2.id_institucion);
      byId1.id_paciente = institucionCodExamen.idpaciente;
      byId1.username_radiologo = byId3.username;
      byId1.fecha_validacion = DateTime.Now;
      byId1.descripcion = string.Empty;
      byId1.codExamen = institucionCodExamen.codexamen;
      byId1.id_estado_informe = id_estado;
      byId1.modalidad = institucionCodExamen.modalidad;
      byId1.id_tipo_informe = 3;
      byId1.descripcion = "Informe OIT";
      byId1.id_institucion = byId2.id_institucion;
      long num1 = 0;
      if (byId2.id_tipo_conexion != 1)
      {
        int idTipoConexion1 = byId2.id_tipo_conexion;
      }
      byId1.id_informe_remoto = num1;
      long id_informe = RisInformeDataAccess.Save(byId1);
      InformarOIT1.id_informe = id_informe;
      for (int index = 0; index < InformarOIT1.id_prestacion.Length; ++index)
      {
        InstitucionDatosDataAccess.GetByIdMethodAndInstitucion(3, byId2.id_institucion);
        RisInformePrestacionDomain informeAndIdPrestacion = RisInformePrestacionDataAccess.GetByIDInformeAndIDPrestacion(id_informe, InformarOIT1.id_prestacion[index], byId2.id_institucion);
        RisPrestacionDataAccess.GetById(InformarOIT1.id_prestacion[index]);
        informeAndIdPrestacion.id_informe = id_informe;
        informeAndIdPrestacion.id_prestacion = InformarOIT1.id_prestacion[index];
        informeAndIdPrestacion.fecha = DateTime.Now;
        informeAndIdPrestacion.id_institucion = byId2.id_institucion;
        long num2 = 0;
        if (byId2.id_tipo_conexion != 1)
        {
          int idTipoConexion2 = byId2.id_tipo_conexion;
        }
        if (num2 > 0L)
          informeAndIdPrestacion.id_ris_informe_prestacion_remoto = num2;
        RisInformePrestacionDataAccess.Save(informeAndIdPrestacion);
      }
      if (id_informe <= 0L)
        return;
      RisInformeOITDomain byIdInforme = RisInformeDataAccess.GetByIdInforme(InformarOIT1.codExamen);
      InstitucionDatosDataAccess.GetByIdMethodAndInstitucion(2, byId2.id_institucion);
      byIdInforme.idInforme = id_informe;
      byIdInforme.idInforme = institucionCodExamen.id_ris_examen;
      byIdInforme.nombre = institucionCodExamen.nombre;
      byIdInforme.idPaciente = this.txtIdentificador.Text;
      byIdInforme.fechaRadiografia = institucionCodExamen.fechaexamen;
      byIdInforme.numeroRadiografia = this.txtNumeroRadiografia.Text;
      byIdInforme.radiografiaDigital = this.rb_radiografia_digital.SelectedValue != "" ? this.rb_radiografia_digital.SelectedValue : "0";
      byIdInforme.lecturaNegatoscopio = this.rb_lectura_Negatoscopio.SelectedValue != "" ? this.rb_lectura_Negatoscopio.SelectedValue : "0";
      byIdInforme.tecnicaQualidaden = this.rb_tecnica_Quialidaden.SelectedValue != "" ? this.rb_tecnica_Quialidaden.SelectedValue : "0";
      byIdInforme.radiografiaNormal = this.rb_radiografia_Normal.SelectedValue != "" ? this.rb_radiografia_Normal.SelectedValue : "0";
      byIdInforme.comentario = this.txtComentario.Text;
      byIdInforme.anormalidadParenquimatosa = this.rb_anormalidad_Parenquimatosa.SelectedValue != "" ? this.rb_anormalidad_Parenquimatosa.SelectedValue : "0";
      byIdInforme.primaria1 = this.rb_primaria1.SelectedValue != "" ? this.rb_primaria1.SelectedValue : "0";
      byIdInforme.primaria2 = this.rb_primaria2.SelectedValue != "" ? this.rb_primaria2.SelectedValue : "0";
      byIdInforme.primaria3 = this.rb_primaria3.SelectedValue != "" ? this.rb_primaria3.SelectedValue : "0";
      byIdInforme.secundaria1 = this.rb_secundaria1.SelectedValue != "" ? this.rb_secundaria1.SelectedValue : "0";
      byIdInforme.secundaria2 = this.rb_secundaria2.SelectedValue != "" ? this.rb_secundaria2.SelectedValue : "0";
      byIdInforme.secundaria3 = this.rb_secundaria3.SelectedValue != "" ? this.rb_secundaria3.SelectedValue : "0";
      byIdInforme.zonas1 = this.rb_zonas.SelectedValue != "" ? this.rb_zonas.SelectedValue : "0";
      byIdInforme.profusion1 = this.rb_profusion1.SelectedValue != "" ? this.rb_profusion1.SelectedValue : "0";
      byIdInforme.profusion2 = this.rb_profusion2.SelectedValue != "" ? this.rb_profusion2.SelectedValue : "0";
      byIdInforme.profusion3 = this.rb_profusion3.SelectedValue != "" ? this.rb_profusion3.SelectedValue : "0";
      byIdInforme.profusion4 = this.rb_profusion4.SelectedValue != "" ? this.rb_profusion4.SelectedValue : "0";
      byIdInforme.opacidadesPequenas1 = this.rb_opacidades_Pequenas.SelectedValue != "" ? this.rb_opacidades_Pequenas.SelectedValue : "0";
      byIdInforme.anormalidadPleural = this.rb_anormalidad_Pleural.SelectedValue != "" ? this.rb_anormalidad_Pleural.SelectedValue : "0";
      byIdInforme.placasPleuralesSitioPerfil = this.rb_placas_pleurales_sitio_perfil.SelectedValue != "" ? this.rb_placas_pleurales_sitio_perfil.SelectedValue : "0";
      byIdInforme.placasPleuralesSitioFrente = this.rb_placas_pleurales_sitio_frente.SelectedValue != "" ? this.rb_placas_pleurales_sitio_frente.SelectedValue : "0";
      byIdInforme.placasPleuralesSitioDiagrama = this.rb_placas_pleurales_sitio_diagrama.SelectedValue != "" ? this.rb_placas_pleurales_sitio_diagrama.SelectedValue : "0";
      byIdInforme.placasPleuralesSitioOtro = this.rb_placas_pleurales_sitio_otro.SelectedValue != "" ? this.rb_placas_pleurales_sitio_otro.SelectedValue : "0";
      byIdInforme.placasPleuralesCalcificacionPerfil = this.rb_placas_pleurales_calcificacion_perfil.SelectedValue != "" ? this.rb_placas_pleurales_calcificacion_perfil.SelectedValue : "0";
      byIdInforme.placasPleuralesCalcificacionFrente = this.rb_placas_pleurales_calcificacion_frente.SelectedValue != "" ? this.rb_placas_pleurales_calcificacion_frente.SelectedValue : "0";
      byIdInforme.placasPleuralesCalcificacionDiagrama = this.rb_placas_pleurales_calcificacion_diagrama.SelectedValue != "" ? this.rb_placas_pleurales_calcificacion_diagrama.SelectedValue : "0";
      byIdInforme.placasPleuralesCalcificacionOtro = this.rb_placas_pleurales_calcificacion_otro.SelectedValue != "" ? this.rb_placas_pleurales_calcificacion_otro.SelectedValue : "0";
      byIdInforme.placasPleuralesExtencionPared1 = this.rb_placas_pleurales_extencion_pared1.SelectedValue != "" ? this.rb_placas_pleurales_extencion_pared1.SelectedValue : "0";
      byIdInforme.placasPleuralesExtencionPared2 = this.rb_placas_pleurales_extencion_pared2.SelectedValue != "" ? this.rb_placas_pleurales_extencion_pared2.SelectedValue : "0";
      byIdInforme.placasPleurales = this.rb_placas_pleurales.SelectedValue != "" ? this.rb_placas_pleurales.SelectedValue : "0";
      byIdInforme.obliteracionAnguloCostofrenico = this.rb_obliteracion_angulo_costofrenico.SelectedValue != "" ? this.rb_obliteracion_angulo_costofrenico.SelectedValue : "0";
      byIdInforme.engrosamientoPleuralDifuso = this.rb_engrosamiento_pleural_difuso.SelectedValue != "" ? this.rb_engrosamiento_pleural_difuso.SelectedValue : "0";
      byIdInforme.engrosamientoPleuralDifusoSitioPerfil = this.rb_engrosamiento_pleural_difuso_sitio_perfil.SelectedValue != "" ? this.rb_engrosamiento_pleural_difuso_sitio_perfil.SelectedValue : "0";
      byIdInforme.engrosamientoPleuralDifusoSitioFrente = this.rb_engrosamiento_pleural_difuso_sitio_frente.SelectedValue != "" ? this.rb_engrosamiento_pleural_difuso_sitio_frente.SelectedValue : "0";
      byIdInforme.engrosamientoPleuralDifusoCalcificacionPerfil = this.rb_engrosamiento_pleural_difuso_calcificacion_perfil.SelectedValue != "" ? this.rb_engrosamiento_pleural_difuso_calcificacion_perfil.SelectedValue : "0";
      byIdInforme.engrosamientoPleuralDifusoCalcificacionFrente = this.rb_engrosamiento_pleural_difuso_calcificacion_frente.SelectedValue != "" ? this.rb_engrosamiento_pleural_difuso_calcificacion_frente.SelectedValue : "0";
      byIdInforme.engrosamientoPleuralDifusoExtencionPared1 = this.rb_engrosamiento_pleural_difuso_extencion_pared1.SelectedValue != "" ? this.rb_engrosamiento_pleural_difuso_extencion_pared1.SelectedValue : "0";
      byIdInforme.engrosamientoPleuralDifusoExtencionPared2 = this.rb_engrosamiento_pleural_difuso_extencion_pared2.SelectedValue != "" ? this.rb_engrosamiento_pleural_difuso_extencion_pared2.SelectedValue : "0";
      byIdInforme.engrosamientoPleuralDifusoAncho1 = this.rb_engrosamiento_pleural_difuso_ancho1.SelectedValue != "" ? this.rb_engrosamiento_pleural_difuso_ancho1.SelectedValue : "0";
      byIdInforme.engrosamientoPleuralDifusoAncho2 = this.rb_engrosamiento_pleural_difuso_ancho2.SelectedValue != "" ? this.rb_engrosamiento_pleural_difuso_ancho2.SelectedValue : "0";
      byIdInforme.otrasAnormalidades = this.rb_otras_anormalidades.SelectedValue != "" ? this.rb_otras_anormalidades.SelectedValue : "0";
      byIdInforme.otrasAnormalidades = this.rb_otras_anormalidades.SelectedValue != "" ? this.rb_otras_anormalidades.SelectedValue : "0";
      byIdInforme.otrasAnormalidades = this.rb_otras_anormalidades.SelectedValue != "" ? this.rb_otras_anormalidades.SelectedValue : "0";
      byIdInforme.placasPleuralesAncho1 = this.rb_placas_plurales_ancho1.SelectedValue != "" ? this.rb_placas_plurales_ancho1.SelectedValue : "0";
      byIdInforme.placasPleuralesAncho2 = this.rb_placas_plurales_ancho2.SelectedValue != "" ? this.rb_placas_plurales_ancho2.SelectedValue : "0";
      byIdInforme.simbolo_aa = this.cb_simbolo_aa.Checked ? 1 : 0;
      byIdInforme.simbolo_at = this.cb_simbolo_at.Checked ? 1 : 0;
      byIdInforme.simbolo_ax = this.cb_simbolo_ax.Checked ? 1 : 0;
      byIdInforme.simbolo_bu = this.cb_simbolo_bu.Checked ? 1 : 0;
      byIdInforme.simbolo_ca = this.cb_simbolo_ca.Checked ? 1 : 0;
      byIdInforme.simbolo_cg = this.cb_simbolo_cg.Checked ? 1 : 0;
      byIdInforme.simbolo_cn = this.cb_simbolo_cn.Checked ? 1 : 0;
      byIdInforme.simbolo_co = this.cb_simbolo_co.Checked ? 1 : 0;
      byIdInforme.simbolo_cp = this.cb_simbolo_cp.Checked ? 1 : 0;
      byIdInforme.simbolo_cv = this.cb_simbolo_cv.Checked ? 1 : 0;
      byIdInforme.simbolo_di = this.cb_simbolo_di.Checked ? 1 : 0;
      byIdInforme.simbolo_ef = this.cb_simbolo_ef.Checked ? 1 : 0;
      byIdInforme.simbolo_em = this.cb_simbolo_em.Checked ? 1 : 0;
      byIdInforme.simbolo_es = this.cb_simbolo_es.Checked ? 1 : 0;
      byIdInforme.simbolo_fr = this.cb_simbolo_fr.Checked ? 1 : 0;
      byIdInforme.simbolo_hi = this.cb_simbolo_hi.Checked ? 1 : 0;
      byIdInforme.simbolo_ho = this.cb_simbolo_ho.Checked ? 1 : 0;
      byIdInforme.simbolo_id = this.cb_simbolo_id.Checked ? 1 : 0;
      byIdInforme.simbolo_ih = this.cb_simbolo_ih.Checked ? 1 : 0;
      byIdInforme.simbolo_kl = this.cb_simbolo_kl.Checked ? 1 : 0;
      byIdInforme.simbolo_me = this.cb_simbolo_me.Checked ? 1 : 0;
      byIdInforme.simbolo_pa = this.cb_simbolo_pa.Checked ? 1 : 0;
      byIdInforme.simbolo_pb = this.cb_simbolo_pb.Checked ? 1 : 0;
      byIdInforme.simbolo_pi = this.cb_simbolo_pi.Checked ? 1 : 0;
      byIdInforme.simbolo_px = this.cb_simbolo_px.Checked ? 1 : 0;
      byIdInforme.simbolo_ra = this.cb_simbolo_ra.Checked ? 1 : 0;
      byIdInforme.simbolo_rp = this.cb_simbolo_rp.Checked ? 1 : 0;
      byIdInforme.simbolo_tb = this.cb_simbolo_tb.Checked ? 1 : 0;
      byIdInforme.simbolo_od = this.cb_simbolo_od.Checked ? 1 : 0;
      byIdInforme.comentarioGeneral = this.txt_comentario_general.Text;
      byIdInforme.codexamen = institucionCodExamen.codexamen;
      byIdInforme.estado = id_estado;
      byIdInforme.RadiologoValidador = byId3.username;
      if (byId2.id_tipo_conexion != 1)
      {
        int idTipoConexion3 = byId2.id_tipo_conexion;
      }
      InstitucionDatosDataAccess.GetByIdMethodAndInstitucion(8, byId2.id_institucion);
      institucionCodExamen.id_estado_examen = id_estado;
      institucionCodExamen.entregado = false;
      if (byId2.id_tipo_conexion != 1)
      {
        int idTipoConexion4 = byId2.id_tipo_conexion;
      }
      RisExamenDataAccess.Save(institucionCodExamen);
      RisExamenDataAccess.SaveOIT(byIdInforme);
    }

    protected void btnRegresar_Click(object sender, EventArgs e)
    {
      try
      {
        this.Response.Redirect("ListaExamen.aspx", false);
      }
      catch (Exception ex)
      {
      }
    }

    private string generarJsonExamen(RisExamenDomain risExamen) => "{" + "\"id_paciente\":\"" + risExamen.idpaciente + "\"," + "\"aetitle\":\"" + risExamen.aetitle + "\"," + "\"codExamen\":\"" + risExamen.codexamen + "\"," + "\"id_examen_remoto\":" + risExamen.id_examen_remoto.ToString() + "," + "\"id_estado_examen\":" + risExamen.id_estado_examen.ToString() + "," + "\"fechaValidacion\":\"" + risExamen.fechavalidacion.ToString("yyyy-MM-dd hh:mm") + "\"," + "}";

    private string generarJsonInformePrestacion(
      RisInformePrestacionDomain risInformePrestacion,
      long id_prestacion_remoto,
      long id_informe_remoto)
    {
      return "{" + "\"id\":" + risInformePrestacion.id_ris_informe_prestacion_remoto.ToString() + "," + "\"idInforme\":" + id_informe_remoto.ToString() + "," + "\"id_prestacion\":" + id_prestacion_remoto.ToString() + "}";
    }

    private string generarJsonInformeOIT(RisInformeOITDomain informeOIT) => "{" + "\"id\":" + informeOIT.idInforme.ToString() + "," + "\"nombre\":\"" + informeOIT.nombre + "\"," + "\"fecha_radiografia\":\"" + informeOIT.fechaRadiografia.ToString() + "\"," + "\"numero_radiografia\":\"" + informeOIT.numeroRadiografia + "\"," + "\"radiografia_digital\":" + informeOIT.radiografiaDigital + "," + "\"lectura_negatoscopio\":" + informeOIT.lecturaNegatoscopio + "," + "\"tecnica_qualidaden\":" + informeOIT.tecnicaQualidaden + "," + "\"radiografia_normal\":" + informeOIT.radiografiaNormal + "," + "\"comentario\":\"" + informeOIT.comentario + "\"," + "\"anormalidad_parenquimatosa\":" + informeOIT.anormalidadParenquimatosa + "," + "\"primaria1\":" + informeOIT.primaria1 + "," + "\"primaria2\":" + informeOIT.primaria2 + "," + "\"primaria3\":" + informeOIT.primaria3 + "," + "\"secundaria1\":" + informeOIT.secundaria1 + "," + "\"secundaria2\":" + informeOIT.secundaria2 + "," + "\"secundaria3\":" + informeOIT.secundaria3 + "," + "\"zonas1\":" + informeOIT.zonas1 + "," + "\"profusion1\":" + informeOIT.profusion1 + "," + "\"profusion2\":" + informeOIT.profusion2 + "," + "\"profusion3\":" + informeOIT.profusion3 + "," + "\"profusion4\":" + informeOIT.profusion4 + "," + "\"opacidades_pequenas1\":" + informeOIT.opacidadesPequenas1 + "," + "\"anormalidad_pleural\":" + informeOIT.anormalidadPleural + "," + "\"placas_pleurales\":" + informeOIT.placasPleurales + "," + "\"placas_pleurales_sitio_perfil\":" + informeOIT.placasPleuralesSitioPerfil + "," + "\"placas_pleurales_sitio_frente\":" + informeOIT.placasPleuralesSitioFrente + "," + "\"placas_pleurales_sitio_diagrama\":" + informeOIT.placasPleuralesSitioDiagrama + "," + "\"placas_pleurales_sitio_otro\":" + informeOIT.placasPleuralesSitioOtro + "," + "\"placas_pleurales_calcificacion_perfil\":" + informeOIT.placasPleuralesCalcificacionPerfil + "," + "\"placas_pleurales_calcificacion_frente\":" + informeOIT.placasPleuralesCalcificacionFrente + "," + "\"placas_pleurales_calcificacion_diagrama\":" + informeOIT.placasPleuralesCalcificacionDiagrama + "," + "\"placas_pleurales_calcificacion_otro\":" + informeOIT.placasPleuralesCalcificacionOtro + "," + "\"placas_pleurales_extencion_pared1\":" + informeOIT.placasPleuralesExtencionPared1 + "," + "\"placas_pleurales_extencion_pared2\":" + informeOIT.placasPleuralesExtencionPared2 + "," + "\"placas_pleurales_ancho1\":" + informeOIT.placasPleuralesAncho1 + "," + "\"placas_pleurales_ancho2\":" + informeOIT.placasPleuralesAncho2 + "," + "\"obliteracion_angulo_costofrenico\":" + informeOIT.obliteracionAnguloCostofrenico + "," + "\"engrosamiento_pleural_difuso\":" + informeOIT.engrosamientoPleuralDifuso + "," + "\"engrosamiento_pleural_difuso_sitio_perfil\":" + informeOIT.engrosamientoPleuralDifusoSitioPerfil + "," + "\"engrosamiento_pleural_difuso_sitio_frente\":" + informeOIT.engrosamientoPleuralDifusoSitioFrente + "," + "\"engrosamiento_pleural_difuso_calcificacion_perfil\":" + informeOIT.engrosamientoPleuralDifusoCalcificacionPerfil + "," + "\"engrosamiento_pleural_difuso_calcificacion_frente\":" + informeOIT.engrosamientoPleuralDifusoCalcificacionFrente + "," + "\"engrosamiento_pleural_difuso_extencion_pared1\":" + informeOIT.engrosamientoPleuralDifusoExtencionPared1 + "," + "\"engrosamiento_pleural_difuso_extencion_pared2\":" + informeOIT.engrosamientoPleuralDifusoExtencionPared2 + "," + "\"engrosamiento_pleural_difuso_ancho1\":" + informeOIT.engrosamientoPleuralDifusoAncho1 + "," + "\"engrosamiento_pleural_difuso_ancho2\":" + informeOIT.engrosamientoPleuralDifusoAncho2 + "," + "\"otras_anormalidades\":" + informeOIT.otrasAnormalidades + "," + "\"simbolo_aa\":" + informeOIT.simbolo_aa.ToString() + "," + "\"simbolo_at\":" + informeOIT.simbolo_at.ToString() + "," + "\"simbolo_ax\":" + informeOIT.simbolo_ax.ToString() + "," + "\"simbolo_bu\":" + informeOIT.simbolo_bu.ToString() + "," + "\"simbolo_ca\":" + informeOIT.simbolo_ca.ToString() + "," + "\"simbolo_cg\":" + informeOIT.simbolo_cg.ToString() + "," + "\"simbolo_cn\":" + informeOIT.simbolo_cn.ToString() + "," + "\"simbolo_co\":" + informeOIT.simbolo_co.ToString() + "," + "\"simbolo_cp\":" + informeOIT.simbolo_cp.ToString() + "," + "\"simbolo_cv\":" + informeOIT.simbolo_cv.ToString() + "," + "\"simbolo_di\":" + informeOIT.simbolo_di.ToString() + "," + "\"simbolo_ef\":" + informeOIT.simbolo_ef.ToString() + "," + "\"simbolo_em\":" + informeOIT.simbolo_em.ToString() + "," + "\"simbolo_es\":" + informeOIT.simbolo_es.ToString() + "," + "\"simbolo_fr\":" + informeOIT.simbolo_fr.ToString() + "," + "\"simbolo_hi\":" + informeOIT.simbolo_hi.ToString() + "," + "\"simbolo_ho\":" + informeOIT.simbolo_ho.ToString() + "," + "\"simbolo_id\":" + informeOIT.simbolo_id.ToString() + "," + "\"simbolo_ih\":" + informeOIT.simbolo_ih.ToString() + "," + "\"simbolo_kl\":" + informeOIT.simbolo_kl.ToString() + "," + "\"simbolo_me\":" + informeOIT.simbolo_me.ToString() + "," + "\"simbolo_pa\":" + informeOIT.simbolo_pa.ToString() + "," + "\"simbolo_pb\":" + informeOIT.simbolo_pb.ToString() + "," + "\"simbolo_pi\":" + informeOIT.simbolo_pi.ToString() + "," + "\"simbolo_px\":" + informeOIT.simbolo_px.ToString() + "," + "\"simbolo_ra\":" + informeOIT.simbolo_ra.ToString() + "," + "\"simbolo_rp\":" + informeOIT.simbolo_rp.ToString() + "," + "\"simbolo_tb\":" + informeOIT.simbolo_tb.ToString() + "," + "\"simbolo_od\":" + informeOIT.simbolo_od.ToString() + "," + "\"comentario_general\":" + informeOIT.comentarioGeneral + "," + "\"fecha_lectura\":" + informeOIT.fechaLectura.ToString() + "," + "\"codexamen\":" + informeOIT.codexamen + "," + "\"estado\":" + informeOIT.estado.ToString() + "}";

    private string generarJsonInforme(RisInformeDomain risInforme) => "{" + "\"id_informe_remoto\":" + risInforme.id_informe_remoto.ToString() + "," + "\"id_estado_informe\":" + risInforme.id_estado_informe.ToString() + "," + "\"id_paciente\":\"" + risInforme.id_paciente + "\"," + "\"username_radiologo\":\"" + risInforme.username_radiologo + "\"," + "\"fecha_validacion\":\"" + risInforme.fecha_validacion.ToString("yyyy-MM-dd HH:mm:ss") + "\"," + "\"flag_patologia_grave\":" + risInforme.flag_patologia_grave.ToString() + "," + "\"patologia_grave\":\"" + risInforme.patologia_grave + "\"," + "\"descripcion\":\"" + risInforme.descripcion + "\"," + "\"codigo_his\":" + risInforme.codigo_his.ToString() + "," + "\"valor\":" + risInforme.valor.ToString() + "," + "\"estado_sincronizacion\":" + risInforme.estado_sinconizacion.ToString() + "," + "\"codExamen\":\"" + risInforme.codExamen + "\"," + "\"modalidad\":\"" + risInforme.modalidad + "\"" + "\"id_tipo_informe\":" + risInforme.id_tipo_informe.ToString() + "}";

    [WebMethod]
    public static ArrayList ObtenerDatos()
    {
      ArrayList arrayList = new ArrayList();
      RisExamenDomain risExamenDomain = new RisExamenDomain();
      if (HttpContext.Current.Session["codExamen"] != null)
      {
        RisExamenDomain byCodExamen = RisExamenDataAccess.GetByCodExamen(HttpContext.Current.Session["codExamen"].ToString());
        arrayList.Add((object) new
        {
          codexamen = HttpContext.Current.Session["codExamen"].ToString(),
          id_institucion = byCodExamen.id_institucion
        });
      }
      return arrayList;
    }

    private void cargarDocumentosRelacionados(
      int id_institucion,
      string id_paciente,
      string cod_examen)
    {
      DataTable dtDatos = new DataTable();
      RisExamenDomain byCodExamen = RisExamenDataAccess.GetByCodExamen(InformarOIT1.codExamen);
      InstitucionDomain byId = InstitucionDataAccess.GetById(id_institucion);
      if (byId.id_institucion > 0)
      {
        InstitucionDatosDomain methodAndInstitucion = InstitucionDatosDataAccess.GetByIdMethodAndInstitucion(10, byId.id_institucion);
        if (ConfigurationManager.AppSettings["ActivarWSAPISalida"].ToString().Equals("1"))
        {
          ConsumirWS consumirWs = new ConsumirWS();
          ConsumirApi consumirApi = new ConsumirApi();
          if (byId.id_tipo_conexion == 1)
            dtDatos = consumirApi.ApiObtenerDataTable(methodAndInstitucion.url, methodAndInstitucion.metodo, InformarOIT1.jsonEstudiosRelacionados(id_paciente), id_institucion);
          else if (byId.id_tipo_conexion == 2)
            dtDatos = ConsumirWS.GetDocumentosExamen(byId.id_institucion, cod_examen, byCodExamen.numeroacceso);
        }
      }
      if (dtDatos.Rows.Count <= 0)
        return;
      this.gvDocumentosRelacionados.DataSource = (object) this.normalizaDocumentosDelExamen(dtDatos, byId.id_institucion);
      this.gvDocumentosRelacionados.DataBind();
    }

    private DataTable normalizaDocumentosDelExamen(DataTable dtDatos, int id_institucion)
    {
      InstitucionDomain byId = InstitucionDataAccess.GetById(id_institucion);
      DataTable dataTable = new DataTable();
      dataTable.Columns.Add("id");
      dataTable.Columns.Add("descripcion");
      dataTable.Columns.Add("filename");
      dataTable.Columns.Add("webfolder");
      dataTable.Columns.Add("fecha");
      dataTable.Columns.Add("size");
      dataTable.Columns.Add("archivo");
      foreach (DataRow row1 in (InternalDataCollectionBase) dtDatos.Rows)
      {
        DataRow row2 = dataTable.NewRow();
        row2["id"] = (object) row1["id"].ToString();
        row2["descripcion"] = (object) row1["descripcion"].ToString();
        row2["filename"] = (object) row1["filename"].ToString();
        row2["webfolder"] = (object) row1["webfolder"].ToString();
        row2["fecha"] = (object) row1["fecha"].ToString();
        row2["size"] = (object) row1["size"].ToString();
        if (row1["filename"].ToString().Contains(".pdf"))
          row2["archivo"] = (object) ("<a href='#' onclick='cargarDocumentoPDF(&#34" + byId.url_pagina + row1["webfolder"]?.ToString() + row1["filename"]?.ToString() + "&#34); return false;' target='_blank' title='" + row1["descripcion"]?.ToString() + "'><img src='../icon/visor.sl.png' /></a>");
        else if (row1["filename"].ToString().Contains(".jpg") || row1["filename"].ToString().Contains(".png") || row1["filename"].ToString().Contains(".PNG"))
          row2["archivo"] = (object) ("<a href='#' onclick='cargarDocumento(&#34" + byId.url_pagina + row1["webfolder"]?.ToString() + row1["filename"]?.ToString() + "&#34); return false;' target='_blank' title='" + row1["descripcion"]?.ToString() + "'><img src='../icon/visor.sl.png' /></a>");
        dataTable.Rows.Add(row2);
      }
      return dataTable;
    }

    private static string jsonEstudiosRelacionados(string id_paciente) => "{" + "\"id_paciente\":\"" + id_paciente + "\"" + "}";

    private static DataTable normalizaOrdenMedica(DataTable dt, int id_institucion)
    {
      InstitucionDomain byId = InstitucionDataAccess.GetById(id_institucion);
      for (int index = 0; index <= dt.Rows.Count; ++index)
        dt.Rows[index]["orden_medica"] = (object) (byId.url_base + dt.Rows[index]["orden_medica"]?.ToString());
      return dt;
    }

    protected void btnValidar_Click(object sender, EventArgs e)
    {
      InstitucionDomain byId1 = InstitucionDataAccess.GetById(Convert.ToInt32(InformarOIT1.id_institucion));
      RisExamenDomain institucionCodExamen = RisExamenDataAccess.GetByInstitucionCodExamen(InformarOIT1.id_institucion, byId1.aetitle, InformarOIT1.codExamen);
      UsuarioDomain byId2 = UsuarioDataAccess.GetById((long) Convert.ToInt32(this.Session["id_usuario"].ToString()));
      this.guardarInformeOIT(3);
      this.Response.Redirect("ListaExamen.aspx", false);
      RisLogDataAccess.SaveReturn(new RisLogDomain()
      {
        sistema = "MULTIRISWEB",
        observacion = "Usuario " + byId2.username + " genero un informeOIT asociado al informe " + InformarOIT1.id_informe.ToString() + " estado Validado",
        id_institucion = institucionCodExamen.id_institucion,
        codexamen = institucionCodExamen.codexamen,
        id_ris_examen = institucionCodExamen.id_ris_examen,
        id_usuario = byId2.id_usuario,
        tipoAccion = 4L
      });
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
      InstitucionDomain byId1 = InstitucionDataAccess.GetById(Convert.ToInt32(InformarOIT1.id_institucion));
      RisExamenDomain institucionCodExamen = RisExamenDataAccess.GetByInstitucionCodExamen(InformarOIT1.id_institucion, byId1.aetitle, InformarOIT1.codExamen);
      UsuarioDomain byId2 = UsuarioDataAccess.GetById((long) Convert.ToInt32(this.Session["id_usuario"].ToString()));
      this.guardarInformeOIT(2);
      this.Response.Redirect("ListaExamen.aspx", false);
      RisLogDataAccess.SaveReturn(new RisLogDomain()
      {
        sistema = "MULTIRISWEB",
        observacion = "Usuario " + byId2.username + " genero un informeOIT asociado al informe " + InformarOIT1.id_informe.ToString() + " estado Informado",
        id_institucion = institucionCodExamen.id_institucion,
        codexamen = institucionCodExamen.codexamen,
        id_ris_examen = institucionCodExamen.id_ris_examen,
        id_usuario = byId2.id_usuario,
        tipoAccion = 4L
      });
    }

    [WebMethod]
    public static long actualizarBloqueoExamen()
    {
      RisExamenDomain byCodExamen = RisExamenDataAccess.GetByCodExamen(InformarOIT1.codExamen);
      UsuarioDomain byId = UsuarioDataAccess.GetById(Convert.ToInt64(HttpContext.Current.Session["id_usuario"].ToString()));
      if (byCodExamen.id_ris_examen > 0L)
      {
        byCodExamen.bloqueado = 1;
        byCodExamen.fecha_bloqueo = DateTime.Now;
        byCodExamen.id_usuario_bloqueo = Convert.ToInt32(byId.id_usuario);
        RisExamenDataAccess.Save(byCodExamen);
      }
      return byCodExamen.id_ris_examen;
    }

    [WebMethod]
    public static string ObtenerInformesPrevios(string id_paciente, int id_institucion)
    {
      InstitucionDomain byId = InstitucionDataAccess.GetById(id_institucion);
      DataTable dataTable = new DataTable();
      string urlInforme = InstitucionDataAccess.getURLInforme();
      string str1 = "";
      if (byId.id_institucion > 0)
      {
        ConsumirWS consumirWs = new ConsumirWS();
        ConsumirApi consumirApi = new ConsumirApi();
        InstitucionDatosDomain methodAndInstitucion = InstitucionDatosDataAccess.GetByIdMethodAndInstitucion(9, byId.id_institucion);
        if (byId.id_tipo_conexion == 1)
          dataTable = InformarOIT1.normalizaDataTableEstudiosRelacionados(consumirApi.ApiObtenerDataTable(methodAndInstitucion.url, methodAndInstitucion.metodo, InformarOIT1.jsonEstudiosRelacionados(id_paciente), id_institucion), id_institucion, id_paciente);
        else if (byId.id_tipo_conexion == 2)
          dataTable = InformarOIT1.normalizaDataTableEstudiosRelacionados(ConsumirWS.GetEstudiosRelacionados(id_paciente, id_institucion), id_institucion, id_paciente);
      }
      if (dataTable.Rows.Count > 0)
      {
        DataView defaultView = dataTable.DefaultView;
        defaultView.Sort = "Fecha_examen DESC";
        DataTable table = defaultView.ToTable();
        string str2 = str1 + "<table class=\"table_informes_previos\">";
        int num = 0;
        foreach (DataRow row in (InternalDataCollectionBase) table.Rows)
        {
          ++num;
          string str3 = "btn_identificador" + num.ToString();
          if (!(row["descripcion"].ToString() == "ESTUDIO SOLO CON IMAGENES"))
          {
            str2 += "<tr>";
            str2 += "<td>";
            string codeExamen = row["informe"].ToString().Split('=')[1].Split('&')[0];
            int examenConteo = RisExamenDataAccess.GetExamenConteo(codeExamen);
            string examenAetitle = RisExamenDataAccess.GetExamenAetitle(codeExamen);
            string informeIdInforme = RisInformeDataAccess.GetInformeIdInforme(codeExamen);
            if (examenConteo > 0)
              str2 = str2 + "<button id=\"" + str3 + "\" class=\"btn_informes_previos\" onclick=\"cargarInforme('" + urlInforme.Replace("#IDINFORME#", informeIdInforme).Replace("#AETITLE#", examenAetitle) + "'); return false;\">" + row["descripcion"].ToString().ToUpper() + "</button>";
            else
              str2 = str2 + "<button id=\"" + str3 + "\" class=\"btn_informes_previos\" onclick=\"cargarInforme('" + row["informe"]?.ToString() + "', '" + str3 + "'); return false;\">" + row["descripcion"].ToString().ToUpper() + "</button>";
            str2 += "</td>";
            str2 += "</tr>";
          }
        }
        str1 = str2 + "</table>";
      }
      return str1;
    }
  }
}
