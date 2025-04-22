// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.VisorErrorDataAccess
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
  public class VisorErrorDataAccess
  {
    public static DataTable GetAllDataTable(
      int idTipoSistema,
      int idTipoError,
      DateTime fechaDesde,
      DateTime fechaHasta)
    {
      return StoredProcedure.EjecutarProcedure(new List<Parameter>()
      {
        new Parameter()
        {
          Name = nameof (idTipoSistema),
          Type = DbType.Int32,
          Value = (object) idTipoSistema
        },
        new Parameter()
        {
          Name = nameof (idTipoError),
          Type = DbType.Int32,
          Value = (object) idTipoError
        },
        new Parameter()
        {
          Name = "fechadesde",
          Type = DbType.DateTime,
          Value = (object) fechaDesde
        },
        new Parameter()
        {
          Name = "fechahasta",
          Type = DbType.DateTime,
          Value = (object) fechaHasta
        }
      }, "sp_VisorError", "CN_RISPACS");
    }

    public static IList<TipoErrorDomain> TipoErrorGetAll() => (IList<TipoErrorDomain>) DataBaseProcedure.ListEntidad<TipoErrorDomain>(new List<Parameter>(), "sp_TipoError_GetAll", "CN_RISPACS");

    public static IList<TipoSistemaDomain> TipoSistemaGetAll() => (IList<TipoSistemaDomain>) DataBaseProcedure.ListEntidad<TipoSistemaDomain>(new List<Parameter>(), "sp_TipoSistema_GetAll", "CN_RISPACS");

    private static VisorDomain BuildFunction(IDataReader row) => new VisorDomain()
    {
      id_visor = row["id_visor"] != DBNull.Value ? (int) row["id_visor"] : 0,
      nombre = row["nombre"] != DBNull.Value ? (string) row["nombre"] : string.Empty,
      descripcion = row["descripcion"] != DBNull.Value ? (string) row["descripcion"] : string.Empty,
      icono = row["icono"] != DBNull.Value ? (string) row["icono"] : string.Empty,
      id_estado = row["id_estado"] != DBNull.Value ? (int) row["id_estado"] : 0
    };
  }
}
