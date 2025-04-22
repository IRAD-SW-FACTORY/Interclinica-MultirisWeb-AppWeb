// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.WSTalca.DocumentosParameters
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
  public class DocumentosParameters
  {
    private string codExamenField;
    private string numeroAccesoField;

    public string codExamen
    {
      get => this.codExamenField;
      set => this.codExamenField = value;
    }

    public string numeroAcceso
    {
      get => this.numeroAccesoField;
      set => this.numeroAccesoField = value;
    }
  }
}
