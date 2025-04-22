// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.WSTalca.InformeParameters
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
  public class InformeParameters
  {
    private long id_informe_remotoField;
    private int id_estado_informeField;
    private string id_pacienteField;
    private string username_radiologoField;
    private DateTime fecha_validacionField;
    private int flag_patologia_graveField;
    private string patologia_graveField;
    private string descripcionField;
    private long codigo_hisField;
    private int valorField;
    private int estado_sinconizacionField;
    private string codExamenField;
    private string modalidadField;
    private int id_tipo_informeField;

    public long id_informe_remoto
    {
      get => this.id_informe_remotoField;
      set => this.id_informe_remotoField = value;
    }

    public int id_estado_informe
    {
      get => this.id_estado_informeField;
      set => this.id_estado_informeField = value;
    }

    public string id_paciente
    {
      get => this.id_pacienteField;
      set => this.id_pacienteField = value;
    }

    public string username_radiologo
    {
      get => this.username_radiologoField;
      set => this.username_radiologoField = value;
    }

    public DateTime fecha_validacion
    {
      get => this.fecha_validacionField;
      set => this.fecha_validacionField = value;
    }

    public int flag_patologia_grave
    {
      get => this.flag_patologia_graveField;
      set => this.flag_patologia_graveField = value;
    }

    public string patologia_grave
    {
      get => this.patologia_graveField;
      set => this.patologia_graveField = value;
    }

    public string descripcion
    {
      get => this.descripcionField;
      set => this.descripcionField = value;
    }

    public long codigo_his
    {
      get => this.codigo_hisField;
      set => this.codigo_hisField = value;
    }

    public int valor
    {
      get => this.valorField;
      set => this.valorField = value;
    }

    public int estado_sinconizacion
    {
      get => this.estado_sinconizacionField;
      set => this.estado_sinconizacionField = value;
    }

    public string codExamen
    {
      get => this.codExamenField;
      set => this.codExamenField = value;
    }

    public string modalidad
    {
      get => this.modalidadField;
      set => this.modalidadField = value;
    }

    public int id_tipo_informe
    {
      get => this.id_tipo_informeField;
      set => this.id_tipo_informeField = value;
    }
  }
}
