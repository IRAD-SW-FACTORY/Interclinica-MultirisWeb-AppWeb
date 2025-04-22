// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Base.DataBaseParametro
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using System.Data;

namespace MultiRisWeb.Data.Base
{
  public class DataBaseParametro
  {
    public string Nombre { get; set; }

    public DbType Tipo { get; set; }

    public object Valor { get; set; }
  }
}
