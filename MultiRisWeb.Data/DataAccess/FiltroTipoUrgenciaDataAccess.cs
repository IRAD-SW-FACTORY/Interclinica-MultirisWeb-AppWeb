// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.FiltroTipoUrgenciaDataAccess
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
  public class FiltroTipoUrgenciaDataAccess
  {
    public static long Save(string filtro_tipo_urgencia, int id_filtro, int sw) => (long) DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "id_filtro_tipo_urgencia",
        Type = DbType.Int32,
        Value = (object) sw
      },
      new Parameter()
      {
        Name = "id_tipo_urgencia",
        Type = DbType.String,
        Value = (object) filtro_tipo_urgencia
      },
      new Parameter()
      {
        Name = nameof (id_filtro),
        Type = DbType.Int32,
        Value = (object) id_filtro
      }
    }, "sp_FiltroTipoUrgencia_Save_Full", "CN_RISPACS");

    public static long Save(FiltroTipoUrgenciaDomain filtro_tipo_urgencia) => (long) DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "id_filtro_tipo_urgencia",
        Type = DbType.Int32,
        Value = (object) filtro_tipo_urgencia.id_filtro_tipo_urgencia
      },
      new Parameter()
      {
        Name = "id_tipo_urgencia",
        Type = DbType.Int32,
        Value = (object) filtro_tipo_urgencia.id_tipo_urgencia
      },
      new Parameter()
      {
        Name = "id_filtro",
        Type = DbType.Int32,
        Value = (object) filtro_tipo_urgencia.id_filtro
      }
    }, "sp_FiltroTipoUrgencia_Save", "CN_RISPACS");

    public static FiltroTipoUrgenciaDomain GetById(long id_filtro_tipo_urgencia)
    {
      List<Parameter> parameters = new List<Parameter>();
      parameters.Add(new Parameter()
      {
        Name = nameof (id_filtro_tipo_urgencia),
        Type = DbType.Int32,
        Value = (object) id_filtro_tipo_urgencia
      });
      FiltroTipoUrgenciaDomain tipoUrgenciaDomain = new FiltroTipoUrgenciaDomain();
      return DataBaseProcedure.GetEntidad<FiltroTipoUrgenciaDomain>(parameters, "sp_FiltroTipoUrgencia_GetById") ?? new FiltroTipoUrgenciaDomain();
    }

    public static IList<FiltroTipoUrgenciaDomain> GetCollectionByIdFiltro(long id_filtro) => (IList<FiltroTipoUrgenciaDomain>) DataBaseProcedure.ListEntidad<FiltroTipoUrgenciaDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (id_filtro),
        Type = DbType.Int32,
        Value = (object) id_filtro
      }
    }, "sp_FiltroTipoUrgencia_GetCollectionByIdFiltro", "CN_RISPACS");

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
      }, "sp_FiltroTipoUrgencia_DeleteByIdFiltro", "CN_RISPACS");
      return 0;
    }

        public static bool Insert(long idFiltro, int idTipoUrgencia)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter() { Name = "@idFiltro", Type = DbType.Int64, Value = idFiltro });
            parameters.Add(new Parameter() { Name = "@idTipoUrgencia", Type = DbType.Int32, Value = idTipoUrgencia });

            return IradDBNet.DataBaseProcedure.GetInt(parameters, "sp_FiltroTipoUrgenciaInsert", "CN_RISPACS") > 0;
        }

        public static List<FiltroTipoUrgenciaDomain> Listar(long idFiltro)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter() { Name = "@id_filtro", Type = DbType.Int64, Value = idFiltro });         

            return IradDBNet.DataBaseProcedure.ListEntidad<FiltroTipoUrgenciaDomain>(parameters, "sp_FiltroTipoUrgencia_listar", "CN_RISPACS");
        }

        public static FiltroTipoUrgenciaDomain getByIdFiltro(long id_filtro)    
    {
      List<Parameter> parameters = new List<Parameter>();
      parameters.Add(new Parameter()
      {
        Name = nameof (id_filtro),
        Type = DbType.Int32,
        Value = (object) id_filtro
      });
      FiltroTipoUrgenciaDomain tipoUrgenciaDomain = new FiltroTipoUrgenciaDomain();
      return DataBaseProcedure.GetEntidad<FiltroTipoUrgenciaDomain>(parameters, "sp_FiltroTipoUrgencia_getByIdFiltro") ?? new FiltroTipoUrgenciaDomain();
    }

    private static FiltroTipoUrgenciaDomain BuildFunction(IDataReader row) => new FiltroTipoUrgenciaDomain()
    {
      id_filtro_tipo_urgencia = row["id_filtro_tipo_urgencia"] != DBNull.Value ? (long) row["id_filtro_tipo_urgencia"] : 0L,
      id_tipo_urgencia = row["id_tipo_urgencia"] != DBNull.Value ? (int) row["id_tipo_urgencia"] : 0,
      id_filtro = row["id_filtro"] != DBNull.Value ? (long) row["id_filtro"] : 0L
    };
  }
}
