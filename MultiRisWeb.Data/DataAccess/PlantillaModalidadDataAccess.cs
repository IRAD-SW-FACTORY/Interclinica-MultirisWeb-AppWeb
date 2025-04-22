// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.PlantillaModalidadDataAccess
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using IradDBNet;
using IradDBNet.Dao;
using IradDBNet.Dto;
using MultiRisWeb.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data;

namespace MultiRisWeb.Data.DataAccess
{
  public class PlantillaModalidadDataAccess
  {
    public static void Save(PlantillaModalidadDomain plantillaModalidad) => StoredProcedure.EjecutarProcedure(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "id_plantilla",
        Type = DbType.Int32,
        Value = (object) plantillaModalidad.id_plantilla
      },
      new Parameter()
      {
        Name = "id_modalidad",
        Type = DbType.Int32,
        Value = (object) plantillaModalidad.id_modalidad
      }
    }, "sp_PlantillaModalidad_Save", "CN_RISPACS");

    public static IList<PlantillaModalidadDomain> GetByPlantilla(long id_plantilla) => (IList<PlantillaModalidadDomain>) DataBaseProcedure.ListEntidad<PlantillaModalidadDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (id_plantilla),
        Type = DbType.String,
        Value = (object) id_plantilla
      }
    }, "sp_PlantillaModalidad_GetByPlantilla", "CN_RISPACS");

    public static void DeleteById(long id_plantilla_modalidad) => StoredProcedure.EjecutarProcedure(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (id_plantilla_modalidad),
        Type = DbType.Int32,
        Value = (object) id_plantilla_modalidad
      }
    }, "sp_PlantillaModalidad_DeleteById", "CN_RISPACS");

    public static PlantillaModalidadDomain GetByPlantillaModalidad(
      long id_plantilla,
      int id_modalidad)
    {
      List<Parameter> parameters = new List<Parameter>();
      parameters.Add(new Parameter()
      {
        Name = nameof (id_plantilla),
        Type = DbType.Int32,
        Value = (object) id_plantilla
      });
      parameters.Add(new Parameter()
      {
        Name = nameof (id_modalidad),
        Type = DbType.Int32,
        Value = (object) id_modalidad
      });
      PlantillaModalidadDomain plantillaModalidadDomain = new PlantillaModalidadDomain();
      return DataBaseProcedure.GetEntidad<PlantillaModalidadDomain>(parameters, "sp_PlantillaModalidad_GetByPlantillaModalidad", "CN_RISPACS") ?? new PlantillaModalidadDomain();
    }

    private static PlantillaModalidadDomain BuildFunction(IDataReader row) => new PlantillaModalidadDomain()
    {
      id_plantilla_modalidad = row["id_plantilla_modalidad"] != DBNull.Value ? (long) row["id_plantilla_modalidad"] : 0L,
      id_plantilla = row["id_plantilla"] != DBNull.Value ? (long) row["id_plantilla"] : 0L,
      id_modalidad = row["id_modalidad"] != DBNull.Value ? (int) row["id_modalidad"] : 0
    };
  }
}
