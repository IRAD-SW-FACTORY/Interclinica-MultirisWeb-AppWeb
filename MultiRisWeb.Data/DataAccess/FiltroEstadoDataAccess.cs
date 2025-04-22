// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.FiltroEstadoDataAccess
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
  public class FiltroEstadoDataAccess
  {
    public static long Save(string filtro_estado, int id_filtro, int sw) => (long) DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "id_filtro_estado",
        Type = DbType.Int32,
        Value = (object) sw
      },
      new Parameter()
      {
        Name = "id_estado_examen",
        Type = DbType.String,
        Value = (object) filtro_estado
      },
      new Parameter()
      {
        Name = nameof (id_filtro),
        Type = DbType.Int32,
        Value = (object) id_filtro
      }
    }, "sp_FiltroEstado_Save_Full", "CN_RISPACS");

    public static long Save(FiltroEstadoDomain filtro_estado) => (long) DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "id_filtro_estado",
        Type = DbType.Int32,
        Value = (object) filtro_estado.id_filtro_estado
      },
      new Parameter()
      {
        Name = "id_estado_examen",
        Type = DbType.Int32,
        Value = (object) filtro_estado.id_estado_examen
      },
      new Parameter()
      {
        Name = "id_filtro",
        Type = DbType.Int32,
        Value = (object) filtro_estado.id_filtro
      }
    }, "sp_FiltroEstado_Save", "CN_RISPACS");

    public static FiltroEstadoDomain GetById(long id_filtro_estado)
    {
      List<Parameter> parameters = new List<Parameter>();
      parameters.Add(new Parameter()
      {
        Name = nameof (id_filtro_estado),
        Type = DbType.Int32,
        Value = (object) id_filtro_estado
      });
      FiltroEstadoDomain filtroEstadoDomain = new FiltroEstadoDomain();
      return DataBaseProcedure.GetEntidad<FiltroEstadoDomain>(parameters, "sp_FiltroEstado_GetById") ?? new FiltroEstadoDomain();
    }

    public static IList<FiltroEstadoDomain> GetCollectionByIdFiltro(long id_filtro) => (IList<FiltroEstadoDomain>) DataBaseProcedure.ListEntidad<FiltroEstadoDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (id_filtro),
        Type = DbType.String,
        Value = (object) id_filtro
      }
    }, "sp_FiltroEstado_GetCollectionByIdFiltro", "CN_RISPACS");

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
      }, "sp_FiltroEstado_DeleteByIdFiltro", "CN_RISPACS");
      return 0;
    }

    public static FiltroEstadoDomain getByIdFiltro(long id_filtro)
    {
      List<Parameter> parameters = new List<Parameter>();
      parameters.Add(new Parameter()
      {
        Name = nameof (id_filtro),
        Type = DbType.Int32,
        Value = (object) id_filtro
      });
      FiltroEstadoDomain filtroEstadoDomain = new FiltroEstadoDomain();
      return DataBaseProcedure.GetEntidad<FiltroEstadoDomain>(parameters, "sp_FiltroEstado_getByIdFiltro") ?? new FiltroEstadoDomain();
    }

        public static bool Insert(long idFiltro, int idEstadoExamen)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter() { Name = "@idFiltro", Type = DbType.Int64, Value = idFiltro });
            parameters.Add(new Parameter() { Name = "@idEstadoExamen", Type = DbType.Int32, Value = idEstadoExamen });

            return IradDBNet.DataBaseProcedure.GetInt(parameters, "sp_FiltroEstadoInsert", "CN_RISPACS") > 0;
        }

        public static List<FiltroEstadoDomain> Listar(long idFiltro)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter() { Name = "@id_filtro", Type = DbType.Int64, Value = idFiltro });

            return IradDBNet.DataBaseProcedure.ListEntidad<FiltroEstadoDomain>(parameters, "sp_FiltroEstado_listar", "CN_RISPACS");
        }

        private static FiltroEstadoDomain BuildFunction(IDataReader row) => new FiltroEstadoDomain()
    {
      id_filtro_estado = row["id_filtro_estado"] != DBNull.Value ? (long) row["id_filtro_estado"] : 0L,
      id_estado_examen = row["id_estado_examen"] != DBNull.Value ? (int) row["id_estado_examen"] : 0,
      id_filtro = row["id_filtro"] != DBNull.Value ? (long) row["id_filtro"] : 0L
    };
  }
}
