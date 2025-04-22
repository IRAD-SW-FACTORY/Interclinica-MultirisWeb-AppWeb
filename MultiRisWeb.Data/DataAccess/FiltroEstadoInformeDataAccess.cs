// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.FiltroEstadoInformeDataAccess
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
  public class FiltroEstadoInformeDataAccess
  {
    public static long Save(FiltroEstadoInformeDomain filtro_estado) => (long) DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "id_filtro_estado_informe",
        Type = DbType.Int32,
        Value = (object) filtro_estado.id_filtro_estado_informe
      },
      new Parameter()
      {
        Name = "id_estado_informe",
        Type = DbType.Int32,
        Value = (object) filtro_estado.id_estado_informe
      },
      new Parameter()
      {
        Name = "id_filtro",
        Type = DbType.Int32,
        Value = (object) filtro_estado.id_filtro
      }
    }, "sp_FiltroEstadoInforme_Save", "CN_RISPACS");

    public static FiltroEstadoInformeDomain GetById(long id_filtro_estado) => DataBaseProcedure.GetEntidad<FiltroEstadoInformeDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "id_filtro_estado_informe",
        Type = DbType.Int32,
        Value = (object) id_filtro_estado
      }
    }, "sp_FiltroEstadoInforme_GetById");

    public static IList<FiltroEstadoInformeDomain> GetCollectionByIdFiltro(long id_filtro) => (IList<FiltroEstadoInformeDomain>) DataBaseProcedure.ListEntidad<FiltroEstadoInformeDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (id_filtro),
        Type = DbType.Int32,
        Value = (object) id_filtro
      }
    }, "sp_FiltroEstadoInforme_GetCollectionByIdFiltro", "CN_RISPACS");

    public static long DeleteByIdFiltro(long id_filtro)
    {
      StoredProcedure.EjecutarProcedure(new List<Parameter>()
      {
        new Parameter()
        {
          Name = nameof (id_filtro),
          Type = DbType.Int32,
          Value = (object) id_filtro
        }
      }, "sp_FiltroEstadoInforme_DeleteByIdFiltro", "CN_RISPACS");
      return 0;
    }

    public static FiltroEstadoInformeDomain getByIdFiltro(long id_filtro) => DataBaseProcedure.GetEntidad<FiltroEstadoInformeDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (id_filtro),
        Type = DbType.Int32,
        Value = (object) id_filtro
      }
    }, "sp_FiltroEstadoInforme_getByIdFiltro");

    private static FiltroEstadoInformeDomain BuildFunction(IDataReader row) => new FiltroEstadoInformeDomain()
    {
      id_filtro_estado_informe = row["id_filtro_estado_informe"] != DBNull.Value ? (long) row["id_filtro_estado_informe"] : 0L,
      id_estado_informe = row["id_estado_informe"] != DBNull.Value ? (int) row["id_estado_informe"] : 0,
      id_filtro = row["id_filtro"] != DBNull.Value ? (long) row["id_filtro"] : 0L
    };
  }
}
