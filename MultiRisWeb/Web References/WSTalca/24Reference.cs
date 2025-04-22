// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.WSTalca.GetComentariosCompletedEventArgs
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;

namespace MultiRisWeb.WSTalca
{
  [GeneratedCode("System.Web.Services", "4.8.9032.0")]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  public class GetComentariosCompletedEventArgs : AsyncCompletedEventArgs
  {
    private object[] results;

    internal GetComentariosCompletedEventArgs(
      object[] results,
      Exception exception,
      bool cancelled,
      object userState)
      : base(exception, cancelled, userState)
    {
      this.results = results;
    }

    public DataTable Result
    {
      get
      {
        this.RaiseExceptionIfNecessary();
        return (DataTable) this.results[0];
      }
    }
  }
}
