﻿// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.TagExamenListarDomain
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using System;

namespace MultiRisWeb.Data.Domain
{
  public class TagExamenListarDomain
  {
    public int Id { get; set; }

    public int IdExamen { get; set; }

    public int IdTagExamen { get; set; }

    public string Nombre { get; set; }

    public string TagExamen { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; }
  }
}
