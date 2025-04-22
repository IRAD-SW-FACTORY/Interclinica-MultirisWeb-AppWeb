// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.WSTalca.ComentariosParameters
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
  public class ComentariosParameters
  {
    private int idField;
    private int idInformeField;
    private string codExamenField;
    private int cantidadField;
    private DateTime fechaField;
    private string aetitleField;
    private string textoField;
    private string usernameField;

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

    public string codExamen
    {
      get => this.codExamenField;
      set => this.codExamenField = value;
    }

    public int cantidad
    {
      get => this.cantidadField;
      set => this.cantidadField = value;
    }

    public DateTime fecha
    {
      get => this.fechaField;
      set => this.fechaField = value;
    }

    public string aetitle
    {
      get => this.aetitleField;
      set => this.aetitleField = value;
    }

    public string texto
    {
      get => this.textoField;
      set => this.textoField = value;
    }

    public string username
    {
      get => this.usernameField;
      set => this.usernameField = value;
    }
  }
}
