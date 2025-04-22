// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.FiltroUsuarioDataAccess
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
  public class FiltroUsuarioDataAccess
  {
    public static long Save(string filtro_usuario, int id_filtro, int sw) => (long) DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "id_filtro_usuario",
        Type = DbType.Int32,
        Value = (object) sw
      },
      new Parameter()
      {
        Name = "id_usuario",
        Type = DbType.String,
        Value = (object) filtro_usuario
      },
      new Parameter()
      {
        Name = nameof (id_filtro),
        Type = DbType.Int32,
        Value = (object) id_filtro
      }
    }, "sp_FiltroUsuario_Save_Full", "CN_RISPACS");

    public static long Save(FiltroUsuarioDomain filtro_usuario) => (long) DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "id_filtro_usuario",
        Type = DbType.Int32,
        Value = (object) filtro_usuario.id_filtro_usuario
      },
      new Parameter()
      {
        Name = "id_usuario",
        Type = DbType.Int32,
        Value = (object) filtro_usuario.id_usuario
      },
      new Parameter()
      {
        Name = "id_filtro",
        Type = DbType.Int32,
        Value = (object) filtro_usuario.id_filtro
      }
    }, "sp_FiltroUsuario_Save", "CN_RISPACS");

    public static FiltroUsuarioDomain GetById(long id_filtro_usuario)
    {
      List<Parameter> parameters = new List<Parameter>();
      parameters.Add(new Parameter()
      {
        Name = "id_filtro_estado",
        Type = DbType.Int32,
        Value = (object) id_filtro_usuario
      });
      FiltroUsuarioDomain filtroUsuarioDomain = new FiltroUsuarioDomain();
      return DataBaseProcedure.GetEntidad<FiltroUsuarioDomain>(parameters, "sp_FiltroUsuario_GetById") ?? new FiltroUsuarioDomain();
    }

    public static IList<FiltroUsuarioDomain> GetCollectionByIdFiltro(long id_filtro) => (IList<FiltroUsuarioDomain>) DataBaseProcedure.ListEntidad<FiltroUsuarioDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (id_filtro),
        Type = DbType.Int32,
        Value = (object) id_filtro
      }
    }, "sp_FiltroUsuario_GetCollectionByIdFiltro", "CN_RISPACS");

    public static long DeleteByIdFiltro(long id_filtro) => (long) DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (id_filtro),
        Type = DbType.Int32,
        Value = (object) id_filtro
      }
    }, "sp_FiltroUsuario_DeleteByIdFiltro", "CN_RISPACS");

    public static FiltroUsuarioDomain getByIdFiltro(long id_filtro)
    {
      List<Parameter> parameters = new List<Parameter>();
      parameters.Add(new Parameter()
      {
        Name = nameof (id_filtro),
        Type = DbType.Int32,
        Value = (object) id_filtro
      });
      FiltroUsuarioDomain filtroUsuarioDomain = new FiltroUsuarioDomain();
      return DataBaseProcedure.GetEntidad<FiltroUsuarioDomain>(parameters, "sp_FiltroUsuario_getByIdFiltro") ?? new FiltroUsuarioDomain();
    }

    private static FiltroUsuarioDomain BuildFunction(IDataReader row) => new FiltroUsuarioDomain()
    {
      id_filtro_usuario = row["id_filtro_usuario"] != DBNull.Value ? (long) row["id_filtro_usuario"] : 0L,
      id_usuario = row["id_usuario"] != DBNull.Value ? (long) row["id_usuario"] : 0L,
      id_filtro = row["id_filtro"] != DBNull.Value ? (long) row["id_filtro"] : 0L
    };
  }
}
