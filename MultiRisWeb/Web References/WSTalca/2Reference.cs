// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.WSTalca.PrestacionesExternasParameters
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
  public class PrestacionesExternasParameters
  {
    private int idInformeExternoField;
    private int idPrestacionField;
    private string codFonasaField;
    private string descripcionField;

    public int IdInformeExterno
    {
      get => this.idInformeExternoField;
      set => this.idInformeExternoField = value;
    }

    public int IdPrestacion
    {
      get => this.idPrestacionField;
      set => this.idPrestacionField = value;
    }

    public string CodFonasa
    {
      get => this.codFonasaField;
      set => this.codFonasaField = value;
    }

    public string Descripcion
    {
      get => this.descripcionField;
      set => this.descripcionField = value;
    }
  }
}
