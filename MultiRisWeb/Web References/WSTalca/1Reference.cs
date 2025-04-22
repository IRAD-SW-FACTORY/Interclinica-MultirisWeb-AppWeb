// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.WSTalca.CredencialesParameters
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
  public class CredencialesParameters
  {
    private string usernameField;
    private string passwordField;

    public string username
    {
      get => this.usernameField;
      set => this.usernameField = value;
    }

    public string password
    {
      get => this.passwordField;
      set => this.passwordField = value;
    }
  }
}
