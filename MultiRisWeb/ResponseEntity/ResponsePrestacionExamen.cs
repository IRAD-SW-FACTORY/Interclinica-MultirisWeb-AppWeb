// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.ResponseEntity.ResponsePrestacionExamen
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using MultiRisWeb.Data.Domain;
using System.Collections.Generic;

namespace MultiRisWeb.ResponseEntity
{
  public class ResponsePrestacionExamen
  {
    public List<ExamenPrestacionMantenedorDomain> Prestaciones { get; set; }

    public List<ExamenPrestacionMantenedorDomain> PrestacionesExamen { get; set; }
  }
}
