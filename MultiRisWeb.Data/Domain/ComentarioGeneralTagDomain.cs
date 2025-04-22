// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.ComentarioGeneralTagDomain
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using System;

namespace MultiRisWeb.Data.Domain
{
  public class ComentarioGeneralTagDomain
  {
    public int Id { get; set; }

    public long IdExamen { get; set; }

    public string ComentarioGeneral { get; set; }

    public string Usuario { get; set; }

    public DateTime Fecha { get; set; }

    public string DateTimeText => this.Fecha.ToString("dd-MM-yyyy HH:mm") + " hrs.";
  }
}
