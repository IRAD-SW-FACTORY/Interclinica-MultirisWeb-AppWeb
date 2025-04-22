// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.AutenticacionDomain
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using System;

namespace MultiRisWeb.Data.Domain
{
  public class AutenticacionDomain
  {
    public int Id { get; set; }

    public long IdUsuario { get; set; }

    public DateTime Fecha { get; set; }

    public int Codigo { get; set; }

    public string UserAgent { get; set; }

    public int CodigoValidado { get; set; }
  }
}
