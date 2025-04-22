// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.WSTalca.InformeDatoParameters
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
  public class InformeDatoParameters
  {
    private long idField;
    private string codexamenField;
    private int iddatoField;
    private string valorField;
    private DateTime fechaField;
    private int idinformeField;
    private int posicionField;

    public long id
    {
      get => this.idField;
      set => this.idField = value;
    }

    public string codexamen
    {
      get => this.codexamenField;
      set => this.codexamenField = value;
    }

    public int iddato
    {
      get => this.iddatoField;
      set => this.iddatoField = value;
    }

    public string valor
    {
      get => this.valorField;
      set => this.valorField = value;
    }

    public DateTime fecha
    {
      get => this.fechaField;
      set => this.fechaField = value;
    }

    public int idinforme
    {
      get => this.idinformeField;
      set => this.idinformeField = value;
    }

    public int posicion
    {
      get => this.posicionField;
      set => this.posicionField = value;
    }
  }
}
