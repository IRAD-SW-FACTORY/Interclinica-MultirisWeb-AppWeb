// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.WSTalca.Respuesta
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
  public class Respuesta
  {
    private bool respuestaWSField;
    private string mensajeField;

    public bool RespuestaWS
    {
      get => this.respuestaWSField;
      set => this.respuestaWSField = value;
    }

    public string Mensaje
    {
      get => this.mensajeField;
      set => this.mensajeField = value;
    }
  }
}
