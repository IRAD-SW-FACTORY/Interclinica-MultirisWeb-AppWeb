// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.ResponseEntity.RequestFiltro
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using Newtonsoft.Json;
using System;

namespace MultiRisWeb.ResponseEntity
{
  [JsonObject]
  [Serializable]
  public class RequestFiltro
  {
    public string usuario { get; set; }

    public string filtroId { get; set; }

    public string nombre { get; set; }

    public Generico[] institucion { get; set; }

    public Generico[] modalidad { get; set; }

    public Generico[] medico { get; set; }

    public Generico[] atencion { get; set; }

    public Generico[] estado { get; set; }
  }
}
