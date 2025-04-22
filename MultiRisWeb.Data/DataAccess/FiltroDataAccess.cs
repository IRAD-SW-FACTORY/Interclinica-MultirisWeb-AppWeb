// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.FiltroDataAccess
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
    public class FiltroDataAccess
    {
        public static long Save(FiltroDomain filtro) => (long)DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "id_filtro",
        Type = DbType.Int32,
        Value = (object) filtro.id_filtro
      },
      new Parameter()
      {
        Name = "nombre",
        Type = DbType.String,
        Value = (object) filtro.nombre
      },
      new Parameter()
      {
        Name = "id_usuario",
        Type = DbType.Int32,
        Value = (object) filtro.id_usuario
      },
      new Parameter()
      {
        Name = "id_estado",
        Type = DbType.Int32,
        Value = (object) filtro.id_estado
      },
      new Parameter()
      {
        Name = "veces_usado",
        Type = DbType.Int32,
        Value = (object) filtro.veces_usado
      },
      new Parameter()
      {
        Name = "tipo_filtro",
        Type = DbType.String,
        Value = (object) filtro.tipo_filtro
      }
    }, "sp_Filtro_Save", "CN_RISPACS");

        public static FiltroDomain GetById(long id_filtro)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter()
            {
                Name = nameof(id_filtro),
                Type = DbType.Int32,
                Value = (object)id_filtro
            });
            FiltroDomain filtroDomain = new FiltroDomain();
            return DataBaseProcedure.GetEntidad<FiltroDomain>(parameters, "sp_Filtro_GetById", "CN_RISPACS") ?? new FiltroDomain();
        }

        public static IList<FiltroDomain> GetByUser(long id_usuario) => (IList<FiltroDomain>)DataBaseProcedure.ListEntidad<FiltroDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (id_usuario),
        Type = DbType.Int32,
        Value = (object) id_usuario
      }
    }, "sp_Filtro_GetByUser", "CN_RISPACS");

        public static FiltroDomain GetByIdAndUser(long id_filtro, long id_usuario)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter()
            {
                Name = nameof(id_filtro),
                Type = DbType.Int32,
                Value = (object)id_filtro
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(id_usuario),
                Type = DbType.Int32,
                Value = (object)id_usuario
            });
            FiltroDomain filtroDomain = new FiltroDomain();
            return DataBaseProcedure.GetEntidad<FiltroDomain>(parameters, "sp_Filtro_GetByIdAndUser") ?? new FiltroDomain();
        }

        public static IList<FiltroDomain> GetByUserAndState(long id_usuario, int id_estado) => (IList<FiltroDomain>)DataBaseProcedure.ListEntidad<FiltroDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (id_usuario),
        Type = DbType.Int32,
        Value = (object) id_usuario
      },
      new Parameter()
      {
        Name = nameof (id_estado),
        Type = DbType.Int32,
        Value = (object) id_estado
      }
    }, "sp_Filtro_GetByUserAndState", "CN_RISPACS");

        public static IList<FiltroDomain> GetByFilter(string filtro, string idUsuario) => (IList<FiltroDomain>)DataBaseProcedure.ListEntidad<FiltroDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "vcFiltro",
        Type = DbType.String,
        Value = (object) filtro
      },
      new Parameter()
      {
        Name = "vcIdUsuario",
        Type = DbType.String,
        Value = (object) idUsuario
      }
    }, "sp_Filtro_GetByFilter", "CN_RISPACS");

        public static DataTable GetDataTableByUser(long id_usuario) => StoredProcedure.EjecutarProcedure(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (id_usuario),
        Type = DbType.Int32,
        Value = (object) id_usuario
      }
    }, "sp_Filtro_GetByIdUser", "CN_RISPACS");


        public static long InsertOrUpdate(FiltroDomain filtro)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter() { Name = "@idFiltro", Type = DbType.Int64, Value = filtro.id_filtro });
            parameters.Add(new Parameter() { Name = "@nombre", Type = DbType.String, Value = filtro.nombre });
            parameters.Add(new Parameter() { Name = "@idEstado", Type = DbType.Int32, Value = filtro.id_estado });
            parameters.Add(new Parameter() { Name = "@tipoFiltro", Type = DbType.String, Value = filtro.tipo_filtro });

            return IradDBNet.DataBaseProcedure.GetLong(parameters, "sp_FiltroInsertOrUpdate", "CN_RISPACS");
        }

        private static FiltroDomain BuildFunction(IDataReader row) => new FiltroDomain()
        {
            id_filtro = row["id_filtro"] != DBNull.Value ? (long)row["id_filtro"] : 0L,
            nombre = row["nombre"] != DBNull.Value ? (string)row["nombre"] : string.Empty,
            id_usuario = row["id_usuario"] != DBNull.Value ? (long)row["id_usuario"] : 0L,
            id_estado = row["id_estado"] != DBNull.Value ? (int)row["id_estado"] : 0,
            veces_usado = row["veces_usado"] != DBNull.Value ? (long)row["veces_usado"] : 0L,
            fecha_ultimo_uso = row["fecha_ultimo_uso"] != DBNull.Value ? (DateTime)row["fecha_ultimo_uso"] : new DateTime(1900, 1, 1)
        };
    }
}
