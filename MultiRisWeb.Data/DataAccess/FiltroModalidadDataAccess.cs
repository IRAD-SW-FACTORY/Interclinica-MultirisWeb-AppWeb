// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.FiltroModalidadDataAccess
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
  public class FiltroModalidadDataAccess
  {
    public static long Save(string filtro_modalidad, int id_filtro, int sw) => (long) DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "id_filtro_modalidad",
        Type = DbType.Int32,
        Value = (object) sw
      },
      new Parameter()
      {
        Name = "id_modalidad",
        Type = DbType.String,
        Value = (object) filtro_modalidad
      },
      new Parameter()
      {
        Name = nameof (id_filtro),
        Type = DbType.Int32,
        Value = (object) id_filtro
      }
    }, "sp_FiltroModalidad_Save_Full", "CN_RISPACS");

    public static long Save(FiltroModalidadDomain filtro_modalidad) => (long) DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "id_filtro_modalidad",
        Type = DbType.Int32,
        Value = (object) filtro_modalidad.id_filtro_modalidad
      },
      new Parameter()
      {
        Name = "id_modalidad",
        Type = DbType.Int32,
        Value = (object) filtro_modalidad.id_modalidad
      },
      new Parameter()
      {
        Name = "id_filtro",
        Type = DbType.Int32,
        Value = (object) filtro_modalidad.id_filtro
      }
    }, "sp_FiltroModalidad_Save", "CN_RISPACS");

    public static FiltroModalidadDomain GetById(long id_filtro_modalidad)
    {
      List<Parameter> parameters = new List<Parameter>();
      parameters.Add(new Parameter()
      {
        Name = nameof (id_filtro_modalidad),
        Type = DbType.Int32,
        Value = (object) id_filtro_modalidad
      });
      FiltroModalidadDomain filtroModalidadDomain = new FiltroModalidadDomain();
      return DataBaseProcedure.GetEntidad<FiltroModalidadDomain>(parameters, "sp_FiltroModalidad_GetById") ?? new FiltroModalidadDomain();
    }

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
      }, "sp_FiltroModalidad_DeleteByIdFiltro", "CN_RISPACS");
      return 0;
    }

    public static IList<FiltroModalidadDomain> GetCollectionByIdFiltro(long id_filtro) => (IList<FiltroModalidadDomain>) DataBaseProcedure.ListEntidad<FiltroModalidadDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (id_filtro),
        Type = DbType.Int32,
        Value = (object) id_filtro
      }
    }, "sp_FiltroModalidad_GetCollectionByIdFiltro", "CN_RISPACS");

    public static FiltroModalidadDomain getByIdFiltro(long id_filtro)
    {
      List<Parameter> parameters = new List<Parameter>();
      parameters.Add(new Parameter()
      {
        Name = nameof (id_filtro),
        Type = DbType.Int32,
        Value = (object) id_filtro
      });
      FiltroModalidadDomain filtroModalidadDomain = new FiltroModalidadDomain();
      return DataBaseProcedure.GetEntidad<FiltroModalidadDomain>(parameters, "sp_FiltroModalidad_getByIdFiltro") ?? new FiltroModalidadDomain();
    }

        public static bool Insert(long idFiltro, int idModalidad)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter() { Name = "@idFiltro", Type = DbType.Int64, Value = idFiltro });
            parameters.Add(new Parameter() { Name = "@idModalidad", Type = DbType.Int32, Value = idModalidad });

            return IradDBNet.DataBaseProcedure.GetInt(parameters, "sp_FiltroModalidadInsert", "CN_RISPACS") > 0;
        }

        public static List<FiltroModalidadDomain> Listar(long idFiltro)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter() { Name = "@id_filtro", Type = DbType.Int64, Value = idFiltro });

            return IradDBNet.DataBaseProcedure.ListEntidad<FiltroModalidadDomain>(parameters, "sp_FiltroModalidad_listar", "CN_RISPACS");
        }

        private static FiltroModalidadDomain BuildFunction(IDataReader row) => new FiltroModalidadDomain()
    {
      id_filtro_modalidad = row["id_filtro_modalidad"] != DBNull.Value ? (long) row["id_filtro_modalidad"] : 0L,
      id_modalidad = row["id_modalidad"] != DBNull.Value ? (int) row["id_modalidad"] : 0,
      id_filtro = row["id_filtro"] != DBNull.Value ? (long) row["id_filtro"] : 0L
    };
  }
}
