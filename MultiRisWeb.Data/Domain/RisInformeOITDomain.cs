// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.RisInformeOITDomain
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using System;

namespace MultiRisWeb.Data.Domain
{
  public class RisInformeOITDomain
  {
    private long p_id;
    private long p_idInforme;
    private string p_nombre;
    private string p_idPaciente;
    private DateTime p_fechaRadiografia;
    private string p_numeroRadiografia;
    private string p_radiografiaDigital;
    private long p_idmedico;
    private string p_lecturaNegatoscopio;
    private string p_tecnicaQualidaden;
    private string p_radiografiaNormal;
    private string p_comentario;
    private string p_anormalidadParenquimatosa;
    private string p_primaria1;
    private string p_primaria2;
    private string p_primaria3;
    private string p_secundaria1;
    private string p_secundaria2;
    private string p_secundaria3;
    private string p_zonas1;
    private string p_profusion1;
    private string p_profusion2;
    private string p_profusion3;
    private string p_profusion4;
    private string p_opacidadesPequenas1;
    private string p_anormalidadPleural;
    private string p_placasPleurales;
    private string p_placasPleuralesSitioPerfil;
    private string p_placasPleuralesSitioFrente;
    private string p_placasPleuralesSitioDiagrama;
    private string p_placasPleuralesSitioOtro;
    private string p_placasPleuralesCalcificacionPerfil;
    private string p_placasPleuralesCalcificacionFrente;
    private string p_placasPleuralesCalcificacionDiagrama;
    private string p_placasPleuralesCalcificacionOtro;
    private string p_placasPleuralesExtencionPared1;
    private string p_placasPleuralesExtencionPared2;
    private string p_placasPleuralesAncho1;
    private string p_placasPleuralesAncho2;
    private string p_obliteracionAnguloCostofrenico;
    private string p_engrosamientoPleuralDifuso;
    private string p_engrosamientoPleuralDifusoSitioPerfil;
    private string p_engrosamientoPleuralDifusoSitioFrente;
    private string p_engrosamientoPleuralDifusoCalcificacionPerfil;
    private string p_engrosamientoPleuralDifusoCalcificacionFrente;
    private string p_engrosamientoPleuralDifusoExtencionPared1;
    private string p_engrosamientoPleuralDifusoExtencionPared2;
    private string p_engrosamientoPleuralDifusoAncho1;
    private string p_engrosamientoPleuralDifusoAncho2;
    private string p_otrasAnormalidades;
    private int p_simbolo_aa;
    private int p_simbolo_at;
    private int p_simbolo_ax;
    private int p_simbolo_bu;
    private int p_simbolo_ca;
    private int p_simbolo_cg;
    private int p_simbolo_cn;
    private int p_simbolo_co;
    private int p_simbolo_cp;
    private int p_simbolo_cv;
    private int p_simbolo_di;
    private int p_simbolo_ef;
    private int p_simbolo_em;
    private int p_simbolo_es;
    private int p_simbolo_fr;
    private int p_simbolo_hi;
    private int p_simbolo_ho;
    private int p_simbolo_id;
    private int p_simbolo_ih;
    private int p_simbolo_kl;
    private int p_simbolo_me;
    private int p_simbolo_pa;
    private int p_simbolo_pb;
    private int p_simbolo_pi;
    private int p_simbolo_px;
    private int p_simbolo_ra;
    private int p_simbolo_rp;
    private int p_simbolo_tb;
    private int p_simbolo_od;
    private string p_comentarioGeneral;
    private DateTime p_fechaLectura;
    private string p_codexamen;
    private int p_estado;

    public long id
    {
      get => this.p_id;
      set => this.p_id = value;
    }

    public long idInforme
    {
      get => this.p_idInforme;
      set => this.p_idInforme = value;
    }

    public string nombre
    {
      get => this.p_nombre;
      set => this.p_nombre = value;
    }

    public string idPaciente
    {
      get => this.p_idPaciente;
      set => this.p_idPaciente = value;
    }

    public DateTime fechaRadiografia
    {
      get => this.p_fechaRadiografia;
      set => this.p_fechaRadiografia = value;
    }

    public string numeroRadiografia
    {
      get => this.p_numeroRadiografia;
      set => this.p_numeroRadiografia = value;
    }

    public string radiografiaDigital
    {
      get => this.p_radiografiaDigital;
      set => this.p_radiografiaDigital = value;
    }

    public long idmedico
    {
      get => this.p_idmedico;
      set => this.p_idmedico = value;
    }

    public string lecturaNegatoscopio
    {
      get => this.p_lecturaNegatoscopio;
      set => this.p_lecturaNegatoscopio = value;
    }

    public string tecnicaQualidaden
    {
      get => this.p_tecnicaQualidaden;
      set => this.p_tecnicaQualidaden = value;
    }

    public string radiografiaNormal
    {
      get => this.p_radiografiaNormal;
      set => this.p_radiografiaNormal = value;
    }

    public string comentario
    {
      get => this.p_comentario;
      set => this.p_comentario = value;
    }

    public string anormalidadParenquimatosa
    {
      get => this.p_anormalidadParenquimatosa;
      set => this.p_anormalidadParenquimatosa = value;
    }

    public string primaria1
    {
      get => this.p_primaria1;
      set => this.p_primaria1 = value;
    }

    public string primaria2
    {
      get => this.p_primaria2;
      set => this.p_primaria2 = value;
    }

    public string primaria3
    {
      get => this.p_primaria3;
      set => this.p_primaria3 = value;
    }

    public string secundaria1
    {
      get => this.p_secundaria1;
      set => this.p_secundaria1 = value;
    }

    public string secundaria2
    {
      get => this.p_secundaria2;
      set => this.p_secundaria2 = value;
    }

    public string secundaria3
    {
      get => this.p_secundaria3;
      set => this.p_secundaria3 = value;
    }

    public string zonas1
    {
      get => this.p_zonas1;
      set => this.p_zonas1 = value;
    }

    public string profusion1
    {
      get => this.p_profusion1;
      set => this.p_profusion1 = value;
    }

    public string profusion2
    {
      get => this.p_profusion2;
      set => this.p_profusion2 = value;
    }

    public string profusion3
    {
      get => this.p_profusion3;
      set => this.p_profusion3 = value;
    }

    public string profusion4
    {
      get => this.p_profusion4;
      set => this.p_profusion4 = value;
    }

    public string opacidadesPequenas1
    {
      get => this.p_opacidadesPequenas1;
      set => this.p_opacidadesPequenas1 = value;
    }

    public string anormalidadPleural
    {
      get => this.p_anormalidadPleural;
      set => this.p_anormalidadPleural = value;
    }

    public string placasPleurales
    {
      get => this.p_placasPleurales;
      set => this.p_placasPleurales = value;
    }

    public string placasPleuralesSitioPerfil
    {
      get => this.p_placasPleuralesSitioPerfil;
      set => this.p_placasPleuralesSitioPerfil = value;
    }

    public string placasPleuralesSitioFrente
    {
      get => this.p_placasPleuralesSitioFrente;
      set => this.p_placasPleuralesSitioFrente = value;
    }

    public string placasPleuralesSitioDiagrama
    {
      get => this.p_placasPleuralesSitioDiagrama;
      set => this.p_placasPleuralesSitioDiagrama = value;
    }

    public string placasPleuralesSitioOtro
    {
      get => this.p_placasPleuralesSitioOtro;
      set => this.p_placasPleuralesSitioOtro = value;
    }

    public string placasPleuralesCalcificacionPerfil
    {
      get => this.p_placasPleuralesCalcificacionPerfil;
      set => this.p_placasPleuralesCalcificacionPerfil = value;
    }

    public string placasPleuralesCalcificacionFrente
    {
      get => this.p_placasPleuralesCalcificacionFrente;
      set => this.p_placasPleuralesCalcificacionFrente = value;
    }

    public string placasPleuralesCalcificacionDiagrama
    {
      get => this.p_placasPleuralesCalcificacionDiagrama;
      set => this.p_placasPleuralesCalcificacionDiagrama = value;
    }

    public string placasPleuralesCalcificacionOtro
    {
      get => this.p_placasPleuralesCalcificacionOtro;
      set => this.p_placasPleuralesCalcificacionOtro = value;
    }

    public string placasPleuralesExtencionPared1
    {
      get => this.p_placasPleuralesExtencionPared1;
      set => this.p_placasPleuralesExtencionPared1 = value;
    }

    public string placasPleuralesExtencionPared2
    {
      get => this.p_placasPleuralesExtencionPared2;
      set => this.p_placasPleuralesExtencionPared2 = value;
    }

    public string placasPleuralesAncho1
    {
      get => this.p_placasPleuralesAncho1;
      set => this.p_placasPleuralesAncho1 = value;
    }

    public string placasPleuralesAncho2
    {
      get => this.p_placasPleuralesAncho2;
      set => this.p_placasPleuralesAncho2 = value;
    }

    public string obliteracionAnguloCostofrenico
    {
      get => this.p_obliteracionAnguloCostofrenico;
      set => this.p_obliteracionAnguloCostofrenico = value;
    }

    public string engrosamientoPleuralDifuso
    {
      get => this.p_engrosamientoPleuralDifuso;
      set => this.p_engrosamientoPleuralDifuso = value;
    }

    public string engrosamientoPleuralDifusoSitioPerfil
    {
      get => this.p_engrosamientoPleuralDifusoSitioPerfil;
      set => this.p_engrosamientoPleuralDifusoSitioPerfil = value;
    }

    public string engrosamientoPleuralDifusoSitioFrente
    {
      get => this.p_engrosamientoPleuralDifusoSitioFrente;
      set => this.p_engrosamientoPleuralDifusoSitioFrente = value;
    }

    public string engrosamientoPleuralDifusoCalcificacionPerfil
    {
      get => this.p_engrosamientoPleuralDifusoCalcificacionPerfil;
      set => this.p_engrosamientoPleuralDifusoCalcificacionPerfil = value;
    }

    public string engrosamientoPleuralDifusoCalcificacionFrente
    {
      get => this.p_engrosamientoPleuralDifusoCalcificacionFrente;
      set => this.p_engrosamientoPleuralDifusoCalcificacionFrente = value;
    }

    public string engrosamientoPleuralDifusoExtencionPared1
    {
      get => this.p_engrosamientoPleuralDifusoExtencionPared1;
      set => this.p_engrosamientoPleuralDifusoExtencionPared1 = value;
    }

    public string engrosamientoPleuralDifusoExtencionPared2
    {
      get => this.p_engrosamientoPleuralDifusoExtencionPared2;
      set => this.p_engrosamientoPleuralDifusoExtencionPared2 = value;
    }

    public string engrosamientoPleuralDifusoAncho1
    {
      get => this.p_engrosamientoPleuralDifusoAncho1;
      set => this.p_engrosamientoPleuralDifusoAncho1 = value;
    }

    public string engrosamientoPleuralDifusoAncho2
    {
      get => this.p_engrosamientoPleuralDifusoAncho2;
      set => this.p_engrosamientoPleuralDifusoAncho2 = value;
    }

    public string otrasAnormalidades
    {
      get => this.p_otrasAnormalidades;
      set => this.p_otrasAnormalidades = value;
    }

    public int simbolo_aa
    {
      get => this.p_simbolo_aa;
      set => this.p_simbolo_aa = value;
    }

    public int simbolo_at
    {
      get => this.p_simbolo_at;
      set => this.p_simbolo_at = value;
    }

    public int simbolo_ax
    {
      get => this.p_simbolo_ax;
      set => this.p_simbolo_ax = value;
    }

    public int simbolo_bu
    {
      get => this.p_simbolo_bu;
      set => this.p_simbolo_bu = value;
    }

    public int simbolo_ca
    {
      get => this.p_simbolo_ca;
      set => this.p_simbolo_ca = value;
    }

    public int simbolo_cg
    {
      get => this.p_simbolo_cg;
      set => this.p_simbolo_cg = value;
    }

    public int simbolo_cn
    {
      get => this.p_simbolo_cn;
      set => this.p_simbolo_cn = value;
    }

    public int simbolo_co
    {
      get => this.p_simbolo_co;
      set => this.p_simbolo_co = value;
    }

    public int simbolo_cp
    {
      get => this.p_simbolo_cp;
      set => this.p_simbolo_cp = value;
    }

    public int simbolo_cv
    {
      get => this.p_simbolo_cv;
      set => this.p_simbolo_cv = value;
    }

    public int simbolo_di
    {
      get => this.p_simbolo_di;
      set => this.p_simbolo_di = value;
    }

    public int simbolo_ef
    {
      get => this.p_simbolo_ef;
      set => this.p_simbolo_ef = value;
    }

    public int simbolo_em
    {
      get => this.p_simbolo_em;
      set => this.p_simbolo_em = value;
    }

    public int simbolo_es
    {
      get => this.p_simbolo_es;
      set => this.p_simbolo_es = value;
    }

    public int simbolo_fr
    {
      get => this.p_simbolo_fr;
      set => this.p_simbolo_fr = value;
    }

    public int simbolo_hi
    {
      get => this.p_simbolo_hi;
      set => this.p_simbolo_hi = value;
    }

    public int simbolo_ho
    {
      get => this.p_simbolo_ho;
      set => this.p_simbolo_ho = value;
    }

    public int simbolo_id
    {
      get => this.p_simbolo_id;
      set => this.p_simbolo_id = value;
    }

    public int simbolo_ih
    {
      get => this.p_simbolo_ih;
      set => this.p_simbolo_ih = value;
    }

    public int simbolo_kl
    {
      get => this.p_simbolo_kl;
      set => this.p_simbolo_kl = value;
    }

    public int simbolo_me
    {
      get => this.p_simbolo_me;
      set => this.p_simbolo_me = value;
    }

    public int simbolo_pa
    {
      get => this.p_simbolo_pa;
      set => this.p_simbolo_pa = value;
    }

    public int simbolo_pb
    {
      get => this.p_simbolo_pb;
      set => this.p_simbolo_pb = value;
    }

    public int simbolo_pi
    {
      get => this.p_simbolo_pi;
      set => this.p_simbolo_pi = value;
    }

    public int simbolo_px
    {
      get => this.p_simbolo_px;
      set => this.p_simbolo_px = value;
    }

    public int simbolo_ra
    {
      get => this.p_simbolo_ra;
      set => this.p_simbolo_ra = value;
    }

    public int simbolo_rp
    {
      get => this.p_simbolo_rp;
      set => this.p_simbolo_rp = value;
    }

    public int simbolo_tb
    {
      get => this.p_simbolo_tb;
      set => this.p_simbolo_tb = value;
    }

    public int simbolo_od
    {
      get => this.p_simbolo_od;
      set => this.p_simbolo_od = value;
    }

    public string comentarioGeneral
    {
      get => this.p_comentarioGeneral;
      set => this.p_comentarioGeneral = value;
    }

    public DateTime fechaLectura
    {
      get => this.p_fechaLectura;
      set => this.p_fechaLectura = value;
    }

    public string codexamen
    {
      get => this.p_codexamen;
      set => this.p_codexamen = value;
    }

    public int estado
    {
      get => this.p_estado;
      set => this.p_estado = value;
    }

    public string RadiologoValidador { get; set; }

    public RisInformeOITDomain()
    {
      this.p_id = 0L;
      this.p_idInforme = 0L;
      this.p_nombre = "";
      this.p_idPaciente = "";
      this.p_fechaRadiografia = DateTime.Now;
      this.p_numeroRadiografia = "";
      this.radiografiaDigital = "";
      this.p_idmedico = 0L;
      this.p_lecturaNegatoscopio = "";
      this.p_tecnicaQualidaden = "";
      this.p_tecnicaQualidaden = "";
      this.p_radiografiaNormal = "";
      this.p_comentario = "";
      this.p_anormalidadParenquimatosa = "";
      this.p_primaria1 = "";
      this.p_primaria2 = "";
      this.p_primaria3 = "";
      this.p_secundaria1 = "";
      this.p_secundaria2 = "";
      this.p_secundaria3 = "";
      this.p_zonas1 = "";
      this.p_profusion1 = "";
      this.p_profusion2 = "";
      this.p_profusion3 = "";
      this.p_profusion4 = "";
      this.p_opacidadesPequenas1 = "";
      this.p_anormalidadPleural = "";
      this.p_placasPleurales = "";
      this.p_placasPleuralesSitioPerfil = "";
      this.p_placasPleuralesSitioFrente = "";
      this.p_placasPleuralesSitioDiagrama = "";
      this.p_placasPleuralesSitioOtro = "";
      this.p_placasPleuralesCalcificacionPerfil = "";
      this.p_placasPleuralesCalcificacionFrente = "";
      this.p_placasPleuralesCalcificacionDiagrama = "";
      this.p_placasPleuralesCalcificacionOtro = "";
      this.p_placasPleuralesExtencionPared1 = "";
      this.p_placasPleuralesExtencionPared2 = "";
      this.p_placasPleuralesAncho1 = "";
      this.p_placasPleuralesAncho2 = "";
      this.p_obliteracionAnguloCostofrenico = "";
      this.p_engrosamientoPleuralDifuso = "";
      this.p_engrosamientoPleuralDifusoSitioPerfil = "";
      this.p_engrosamientoPleuralDifusoSitioFrente = "";
      this.p_engrosamientoPleuralDifusoCalcificacionPerfil = "";
      this.p_engrosamientoPleuralDifusoCalcificacionFrente = "";
      this.p_engrosamientoPleuralDifusoExtencionPared1 = "";
      this.p_engrosamientoPleuralDifusoExtencionPared2 = "";
      this.p_engrosamientoPleuralDifusoAncho1 = "";
      this.p_engrosamientoPleuralDifusoAncho2 = "";
      this.p_otrasAnormalidades = "";
      this.p_simbolo_aa = 0;
      this.p_simbolo_at = 0;
      this.p_simbolo_ax = 0;
      this.p_simbolo_bu = 0;
      this.p_simbolo_ca = 0;
      this.p_simbolo_cg = 0;
      this.p_simbolo_cn = 0;
      this.p_simbolo_co = 0;
      this.p_simbolo_cp = 0;
      this.p_simbolo_cv = 0;
      this.p_simbolo_di = 0;
      this.p_simbolo_ef = 0;
      this.p_simbolo_em = 0;
      this.p_simbolo_es = 0;
      this.p_simbolo_fr = 0;
      this.p_simbolo_hi = 0;
      this.p_simbolo_ho = 0;
      this.p_simbolo_id = 0;
      this.p_simbolo_ih = 0;
      this.p_simbolo_kl = 0;
      this.p_simbolo_me = 0;
      this.p_simbolo_pa = 0;
      this.p_simbolo_pb = 0;
      this.p_simbolo_pi = 0;
      this.p_simbolo_px = 0;
      this.p_simbolo_ra = 0;
      this.p_simbolo_rp = 0;
      this.p_simbolo_tb = 0;
      this.p_simbolo_od = 0;
      this.p_comentarioGeneral = "";
      this.p_fechaLectura = DateTime.Now;
      this.p_codexamen = "";
      this.p_estado = 0;
      this.RadiologoValidador = "";
    }
  }
}
