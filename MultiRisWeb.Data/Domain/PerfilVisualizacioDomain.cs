﻿// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.PerfilVisualizacioDomain
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

namespace MultiRisWeb.Data.Domain
{
  public class PerfilVisualizacioDomain
  {
    public int id_perfil_visualizacion { get; set; }

    public string nombre { get; set; }

    public string descripcion { get; set; }

    public PerfilVisualizacioDomain()
    {
      this.id_perfil_visualizacion = 0;
      this.nombre = string.Empty;
      this.descripcion = string.Empty;
    }
  }
}
