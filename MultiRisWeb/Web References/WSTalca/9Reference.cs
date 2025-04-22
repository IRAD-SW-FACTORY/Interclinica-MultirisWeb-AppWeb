// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.WSTalca.InformePrestacionParameters
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
  public class InformePrestacionParameters
  {
    private int idField;
    private int idInformeField;
    private int id_prestacionField;
    private string codhl7Field;
    private DateTime fechaField;

    public int id
    {
      get => this.idField;
      set => this.idField = value;
    }

    public int idInforme
    {
      get => this.idInformeField;
      set => this.idInformeField = value;
    }

    public int id_prestacion
    {
      get => this.id_prestacionField;
      set => this.id_prestacionField = value;
    }

    public string codhl7
    {
      get => this.codhl7Field;
      set => this.codhl7Field = value;
    }

    public DateTime fecha
    {
      get => this.fechaField;
      set => this.fechaField = value;
    }
  }
}
