// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.PerfilVisualizacionDataAccess
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using IradDBNet;
using IradDBNet.Dto;
using MultiRisWeb.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data;

namespace MultiRisWeb.Data.DataAccess
{
  public class PerfilVisualizacionDataAccess
  {
    public static PerfilVisualizacioDomain GetById(int id_perfil_visualizacion) => DataBaseProcedure.GetEntidad<PerfilVisualizacioDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (id_perfil_visualizacion),
        Type = DbType.Int32,
        Value = (object) id_perfil_visualizacion
      }
    }, "sp_perfilVisualizacion_GetById", "CN_RISPACS");

    public static IList<PerfilVisualizacioDomain> ListAll() => (IList<PerfilVisualizacioDomain>) DataBaseProcedure.ListEntidad<PerfilVisualizacioDomain>(new List<Parameter>(), "sp_perfilVisualizacion_ListAll", "CN_RISPACS");

    private static PerfilVisualizacioDomain BuildFunction(IDataReader row) => new PerfilVisualizacioDomain()
    {
      id_perfil_visualizacion = row["id_perfil_visualizacion"] != DBNull.Value ? (int) row["id_perfil_visualizacion"] : 0,
      nombre = row["nombre"] != DBNull.Value ? (string) row["nombre"] : string.Empty,
      descripcion = row["descripcion"] != DBNull.Value ? (string) row["descripcion"] : string.Empty
    };
  }
}
