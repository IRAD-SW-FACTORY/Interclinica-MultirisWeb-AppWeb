// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.WSTalca.InformeOITParameters
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MultiRisWeb.WSTalca
{
  [GeneratedCode("System.Xml", "4.8.9032.0")]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(Namespace = "http://tempuri.org/")]
  [Serializable]
  public class InformeOITParameters
  {
    private long idField;
    private string nombreField;
    private string username_radiologoField;
    private string idpacienteField;
    private DateTime fecha_radiografiaField;
    private string numero_radiografiaField;
    private int radiografia_digitalField;
    private int lectura_negatoscopioField;
    private int tecnica_qualidadenField;
    private int radiografia_normalField;
    private string comentarioField;
    private int anormalidad_parenquimatosaField;
    private int primaria1Field;
    private int primaria2Field;
    private int primaria3Field;
    private int secundaria1Field;
    private int secundaria2Field;
    private int secundaria3Field;
    private int zonas1Field;
    private int profusion1Field;
    private int profusion2Field;
    private int profusion3Field;
    private int profusion4Field;
    private int opacidades_pequenas1Field;
    private int anormalidad_pleuralField;
    private int placas_pleuralesField;
    private int placas_pleurales_sitio_perfilField;
    private int placas_pleurales_sitio_frenteField;
    private int placas_pleurales_sitio_diagramaField;
    private int placas_pleurales_sitio_otroField;
    private int placas_pleurales_calcificacion_perfilField;
    private int placas_pleurales_calcificacion_frenteField;
    private int placas_pleurales_calcificacion_diagramaField;
    private int placas_pleurales_calcificacion_otroField;
    private int placas_pleurales_extencion_pared1Field;
    private int placas_pleurales_extencion_pared2Field;
    private int placas_pleurales_ancho1Field;
    private int placas_pleurales_ancho2Field;
    private int obliteracion_angulo_costofrenicoField;
    private int engrosamiento_pleural_difusoField;
    private int engrosamiento_pleural_difuso_sitio_perfilField;
    private int engrosamiento_pleural_difuso_sitio_frenteField;
    private int engrosamiento_pleural_difuso_calcificacion_perfilField;
    private int engrosamiento_pleural_difuso_calcificacion_frenteField;
    private int engrosamiento_pleural_difuso_extencion_pared1Field;
    private int engrosamiento_pleural_difuso_extencion_pared2Field;
    private int engrosamiento_pleural_difuso_ancho1Field;
    private int engrosamiento_pleural_difuso_ancho2Field;
    private int otras_anormalidadesField;
    private int simbolo_aaField;
    private int simbolo_atField;
    private int simbolo_axField;
    private int simbolo_buField;
    private int simbolo_caField;
    private int simbolo_cgField;
    private int simbolo_cnField;
    private int simbolo_coField;
    private int simbolo_cpField;
    private int simbolo_cvField;
    private int simbolo_diField;
    private int simbolo_efField;
    private int simbolo_emField;
    private int simbolo_esField;
    private int simbolo_frField;
    private int simbolo_hiField;
    private int simbolo_hoField;
    private int simbolo_idField;
    private int simbolo_ihField;
    private int simbolo_klField;
    private int simbolo_meField;
    private int simbolo_paField;
    private int simbolo_pbField;
    private int simbolo_piField;
    private int simbolo_pxField;
    private int simbolo_raField;
    private int simbolo_rpField;
    private int simbolo_tbField;
    private int simbolo_odField;
    private string comentario_generalField;
    private DateTime fecha_lecturaField;
    private string codexamenField;
    private int estadoField;

    public long id
    {
      get => this.idField;
      set => this.idField = value;
    }

    public string nombre
    {
      get => this.nombreField;
      set => this.nombreField = value;
    }

    public string username_radiologo
    {
      get => this.username_radiologoField;
      set => this.username_radiologoField = value;
    }

    public string idpaciente
    {
      get => this.idpacienteField;
      set => this.idpacienteField = value;
    }

    public DateTime fecha_radiografia
    {
      get => this.fecha_radiografiaField;
      set => this.fecha_radiografiaField = value;
    }

    public string numero_radiografia
    {
      get => this.numero_radiografiaField;
      set => this.numero_radiografiaField = value;
    }

    public int radiografia_digital
    {
      get => this.radiografia_digitalField;
      set => this.radiografia_digitalField = value;
    }

    public int lectura_negatoscopio
    {
      get => this.lectura_negatoscopioField;
      set => this.lectura_negatoscopioField = value;
    }

    public int tecnica_qualidaden
    {
      get => this.tecnica_qualidadenField;
      set => this.tecnica_qualidadenField = value;
    }

    public int radiografia_normal
    {
      get => this.radiografia_normalField;
      set => this.radiografia_normalField = value;
    }

    public string comentario
    {
      get => this.comentarioField;
      set => this.comentarioField = value;
    }

    public int anormalidad_parenquimatosa
    {
      get => this.anormalidad_parenquimatosaField;
      set => this.anormalidad_parenquimatosaField = value;
    }

    public int primaria1
    {
      get => this.primaria1Field;
      set => this.primaria1Field = value;
    }

    public int primaria2
    {
      get => this.primaria2Field;
      set => this.primaria2Field = value;
    }

    public int primaria3
    {
      get => this.primaria3Field;
      set => this.primaria3Field = value;
    }

    public int secundaria1
    {
      get => this.secundaria1Field;
      set => this.secundaria1Field = value;
    }

    public int secundaria2
    {
      get => this.secundaria2Field;
      set => this.secundaria2Field = value;
    }

    public int secundaria3
    {
      get => this.secundaria3Field;
      set => this.secundaria3Field = value;
    }

    public int zonas1
    {
      get => this.zonas1Field;
      set => this.zonas1Field = value;
    }

    public int profusion1
    {
      get => this.profusion1Field;
      set => this.profusion1Field = value;
    }

    public int profusion2
    {
      get => this.profusion2Field;
      set => this.profusion2Field = value;
    }

    public int profusion3
    {
      get => this.profusion3Field;
      set => this.profusion3Field = value;
    }

    public int profusion4
    {
      get => this.profusion4Field;
      set => this.profusion4Field = value;
    }

    public int opacidades_pequenas1
    {
      get => this.opacidades_pequenas1Field;
      set => this.opacidades_pequenas1Field = value;
    }

    public int anormalidad_pleural
    {
      get => this.anormalidad_pleuralField;
      set => this.anormalidad_pleuralField = value;
    }

    public int placas_pleurales
    {
      get => this.placas_pleuralesField;
      set => this.placas_pleuralesField = value;
    }

    public int placas_pleurales_sitio_perfil
    {
      get => this.placas_pleurales_sitio_perfilField;
      set => this.placas_pleurales_sitio_perfilField = value;
    }

    public int placas_pleurales_sitio_frente
    {
      get => this.placas_pleurales_sitio_frenteField;
      set => this.placas_pleurales_sitio_frenteField = value;
    }

    public int placas_pleurales_sitio_diagrama
    {
      get => this.placas_pleurales_sitio_diagramaField;
      set => this.placas_pleurales_sitio_diagramaField = value;
    }

    public int placas_pleurales_sitio_otro
    {
      get => this.placas_pleurales_sitio_otroField;
      set => this.placas_pleurales_sitio_otroField = value;
    }

    public int placas_pleurales_calcificacion_perfil
    {
      get => this.placas_pleurales_calcificacion_perfilField;
      set => this.placas_pleurales_calcificacion_perfilField = value;
    }

    public int placas_pleurales_calcificacion_frente
    {
      get => this.placas_pleurales_calcificacion_frenteField;
      set => this.placas_pleurales_calcificacion_frenteField = value;
    }

    public int placas_pleurales_calcificacion_diagrama
    {
      get => this.placas_pleurales_calcificacion_diagramaField;
      set => this.placas_pleurales_calcificacion_diagramaField = value;
    }

    public int placas_pleurales_calcificacion_otro
    {
      get => this.placas_pleurales_calcificacion_otroField;
      set => this.placas_pleurales_calcificacion_otroField = value;
    }

    public int placas_pleurales_extencion_pared1
    {
      get => this.placas_pleurales_extencion_pared1Field;
      set => this.placas_pleurales_extencion_pared1Field = value;
    }

    public int placas_pleurales_extencion_pared2
    {
      get => this.placas_pleurales_extencion_pared2Field;
      set => this.placas_pleurales_extencion_pared2Field = value;
    }

    public int placas_pleurales_ancho1
    {
      get => this.placas_pleurales_ancho1Field;
      set => this.placas_pleurales_ancho1Field = value;
    }

    public int placas_pleurales_ancho2
    {
      get => this.placas_pleurales_ancho2Field;
      set => this.placas_pleurales_ancho2Field = value;
    }

    public int obliteracion_angulo_costofrenico
    {
      get => this.obliteracion_angulo_costofrenicoField;
      set => this.obliteracion_angulo_costofrenicoField = value;
    }

    public int engrosamiento_pleural_difuso
    {
      get => this.engrosamiento_pleural_difusoField;
      set => this.engrosamiento_pleural_difusoField = value;
    }

    public int engrosamiento_pleural_difuso_sitio_perfil
    {
      get => this.engrosamiento_pleural_difuso_sitio_perfilField;
      set => this.engrosamiento_pleural_difuso_sitio_perfilField = value;
    }

    public int engrosamiento_pleural_difuso_sitio_frente
    {
      get => this.engrosamiento_pleural_difuso_sitio_frenteField;
      set => this.engrosamiento_pleural_difuso_sitio_frenteField = value;
    }

    public int engrosamiento_pleural_difuso_calcificacion_perfil
    {
      get => this.engrosamiento_pleural_difuso_calcificacion_perfilField;
      set => this.engrosamiento_pleural_difuso_calcificacion_perfilField = value;
    }

    public int engrosamiento_pleural_difuso_calcificacion_frente
    {
      get => this.engrosamiento_pleural_difuso_calcificacion_frenteField;
      set => this.engrosamiento_pleural_difuso_calcificacion_frenteField = value;
    }

    public int engrosamiento_pleural_difuso_extencion_pared1
    {
      get => this.engrosamiento_pleural_difuso_extencion_pared1Field;
      set => this.engrosamiento_pleural_difuso_extencion_pared1Field = value;
    }

    public int engrosamiento_pleural_difuso_extencion_pared2
    {
      get => this.engrosamiento_pleural_difuso_extencion_pared2Field;
      set => this.engrosamiento_pleural_difuso_extencion_pared2Field = value;
    }

    public int engrosamiento_pleural_difuso_ancho1
    {
      get => this.engrosamiento_pleural_difuso_ancho1Field;
      set => this.engrosamiento_pleural_difuso_ancho1Field = value;
    }

    public int engrosamiento_pleural_difuso_ancho2
    {
      get => this.engrosamiento_pleural_difuso_ancho2Field;
      set => this.engrosamiento_pleural_difuso_ancho2Field = value;
    }

    public int otras_anormalidades
    {
      get => this.otras_anormalidadesField;
      set => this.otras_anormalidadesField = value;
    }

    public int simbolo_aa
    {
      get => this.simbolo_aaField;
      set => this.simbolo_aaField = value;
    }

    public int simbolo_at
    {
      get => this.simbolo_atField;
      set => this.simbolo_atField = value;
    }

    public int simbolo_ax
    {
      get => this.simbolo_axField;
      set => this.simbolo_axField = value;
    }

    public int simbolo_bu
    {
      get => this.simbolo_buField;
      set => this.simbolo_buField = value;
    }

    public int simbolo_ca
    {
      get => this.simbolo_caField;
      set => this.simbolo_caField = value;
    }

    public int simbolo_cg
    {
      get => this.simbolo_cgField;
      set => this.simbolo_cgField = value;
    }

    public int simbolo_cn
    {
      get => this.simbolo_cnField;
      set => this.simbolo_cnField = value;
    }

    public int simbolo_co
    {
      get => this.simbolo_coField;
      set => this.simbolo_coField = value;
    }

    public int simbolo_cp
    {
      get => this.simbolo_cpField;
      set => this.simbolo_cpField = value;
    }

    public int simbolo_cv
    {
      get => this.simbolo_cvField;
      set => this.simbolo_cvField = value;
    }

    public int simbolo_di
    {
      get => this.simbolo_diField;
      set => this.simbolo_diField = value;
    }

    public int simbolo_ef
    {
      get => this.simbolo_efField;
      set => this.simbolo_efField = value;
    }

    public int simbolo_em
    {
      get => this.simbolo_emField;
      set => this.simbolo_emField = value;
    }

    public int simbolo_es
    {
      get => this.simbolo_esField;
      set => this.simbolo_esField = value;
    }

    public int simbolo_fr
    {
      get => this.simbolo_frField;
      set => this.simbolo_frField = value;
    }

    public int simbolo_hi
    {
      get => this.simbolo_hiField;
      set => this.simbolo_hiField = value;
    }

    public int simbolo_ho
    {
      get => this.simbolo_hoField;
      set => this.simbolo_hoField = value;
    }

    public int simbolo_id
    {
      get => this.simbolo_idField;
      set => this.simbolo_idField = value;
    }

    public int simbolo_ih
    {
      get => this.simbolo_ihField;
      set => this.simbolo_ihField = value;
    }

    public int simbolo_kl
    {
      get => this.simbolo_klField;
      set => this.simbolo_klField = value;
    }

    public int simbolo_me
    {
      get => this.simbolo_meField;
      set => this.simbolo_meField = value;
    }

    public int simbolo_pa
    {
      get => this.simbolo_paField;
      set => this.simbolo_paField = value;
    }

    public int simbolo_pb
    {
      get => this.simbolo_pbField;
      set => this.simbolo_pbField = value;
    }

    public int simbolo_pi
    {
      get => this.simbolo_piField;
      set => this.simbolo_piField = value;
    }

    public int simbolo_px
    {
      get => this.simbolo_pxField;
      set => this.simbolo_pxField = value;
    }

    public int simbolo_ra
    {
      get => this.simbolo_raField;
      set => this.simbolo_raField = value;
    }

    public int simbolo_rp
    {
      get => this.simbolo_rpField;
      set => this.simbolo_rpField = value;
    }

    public int simbolo_tb
    {
      get => this.simbolo_tbField;
      set => this.simbolo_tbField = value;
    }

    public int simbolo_od
    {
      get => this.simbolo_odField;
      set => this.simbolo_odField = value;
    }

    public string comentario_general
    {
      get => this.comentario_generalField;
      set => this.comentario_generalField = value;
    }

    public DateTime fecha_lectura
    {
      get => this.fecha_lecturaField;
      set => this.fecha_lecturaField = value;
    }

    public string codexamen
    {
      get => this.codexamenField;
      set => this.codexamenField = value;
    }

    public int estado
    {
      get => this.estadoField;
      set => this.estadoField = value;
    }
  }
}
