// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.WSTalca.DatosExamenParameters
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
  public class DatosExamenParameters
  {
    private string id_pacienteField;
    private string aetitleField;
    private string codExamenField;
    private long id_examen_remotoField;
    private int id_estado_examenField;
    private DateTime fechaValidacionField;

    public string id_paciente
    {
      get => this.id_pacienteField;
      set => this.id_pacienteField = value;
    }

    public string aetitle
    {
      get => this.aetitleField;
      set => this.aetitleField = value;
    }

    public string codExamen
    {
      get => this.codExamenField;
      set => this.codExamenField = value;
    }

    public long id_examen_remoto
    {
      get => this.id_examen_remotoField;
      set => this.id_examen_remotoField = value;
    }

    public int id_estado_examen
    {
      get => this.id_estado_examenField;
      set => this.id_estado_examenField = value;
    }

    public DateTime fechaValidacion
    {
      get => this.fechaValidacionField;
      set => this.fechaValidacionField = value;
    }
  }
}
