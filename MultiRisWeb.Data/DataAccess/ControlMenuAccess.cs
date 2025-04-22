// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.ControlMenuAccess
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
  public class ControlMenuAccess
  {
    public static void SavePreparar(int idPerfil) => StoredProcedure.EjecutarProcedure(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (idPerfil),
        Type = DbType.Int32,
        Value = (object) idPerfil
      }
    }, "sp_ControlMenuAccesoPreparar", "CN_RISPACS");

    public static long SaveMenu(int idPerfil, int idMenu, bool estado) => (long) DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (idPerfil),
        Type = DbType.Int32,
        Value = (object) idPerfil
      },
      new Parameter()
      {
        Name = nameof (idMenu),
        Type = DbType.Int32,
        Value = (object) idMenu
      },
      new Parameter()
      {
        Name = nameof (estado),
        Type = DbType.Int32,
        Value = (object) estado
      }
    }, "sp_ControlMenuAcceso_Save", "CN_RISPACS");

    public static long SaveSubMenu(int idMenu, int idSubMenuGrupo, bool estado, int idPerfil) => (long) DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (idMenu),
        Type = DbType.Int32,
        Value = (object) idMenu
      },
      new Parameter()
      {
        Name = nameof (idSubMenuGrupo),
        Type = DbType.Int32,
        Value = (object) idSubMenuGrupo
      },
      new Parameter()
      {
        Name = nameof (estado),
        Type = DbType.Int32,
        Value = (object) estado
      },
      new Parameter()
      {
        Name = nameof (idPerfil),
        Type = DbType.Int32,
        Value = (object) idPerfil
      }
    }, "sp_ControlSubMenuAcceso_Save", "CN_RISPACS");

    public static DataTable GetControlMenuAcceso() => StoredProcedure.EjecutarProcedure(new List<Parameter>(), "sp_ControlMenuAcceso", "CN_RISPACS");

    public static DataSet GetControlMenu(int idPerfil) => StoredProcedure.EjecutarProcedureDataSet(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (idPerfil),
        Type = DbType.Int32,
        Value = (object) idPerfil
      }
    }, "sp_ControlMenu", "CN_RISPACS");

    public static DataSet GetControlSubMenuGrupo1(int idPerfil) => StoredProcedure.EjecutarProcedureDataSet(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (idPerfil),
        Type = DbType.Int32,
        Value = (object) idPerfil
      }
    }, "sp_ControlSubMenuGrupo", "CN_RISPACS");

    public static DataSet GetControlSubMenuGrupo2(int idPerfil) => StoredProcedure.EjecutarProcedureDataSet(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (idPerfil),
        Type = DbType.Int32,
        Value = (object) idPerfil
      }
    }, "sp_ControlSubMenuGrupo2", "CN_RISPACS");

    public static DataSet GetControlSubMenuGrupoSitio(int idPerfil) => StoredProcedure.EjecutarProcedureDataSet(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (idPerfil),
        Type = DbType.Int32,
        Value = (object) idPerfil
      }
    }, "sp_ControlSubMenuSitio", "CN_RISPACS");

    private static ApiErrorDomain BuildFunction(IDataReader row) => new ApiErrorDomain()
    {
      id_api_error = row["id_api_error"] != DBNull.Value ? (long) row["id_api_error"] : 0L,
      staktrace = row["staktrace"] != DBNull.Value ? (string) row["staktrace"] : string.Empty,
      id_institucion = row["id_institucion"] != DBNull.Value ? (int) row["id_institucion"] : 0
    };
  }
}
