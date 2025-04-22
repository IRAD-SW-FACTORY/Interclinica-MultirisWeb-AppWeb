// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.VisorDataAccess
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
  public class VisorDataAccess
  {
    public static IList<VisorDomain> GetAllForState(int id_estado) => (IList<VisorDomain>) DataBaseProcedure.ListEntidad<VisorDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (id_estado),
        Type = DbType.Int32,
        Value = (object) id_estado
      }
    }, "sp_Visor_GetAllForState", "CN_RISPACS");

    public static DataTable GetAllDataTable() => StoredProcedure.EjecutarProcedure(new List<Parameter>(), "sp_Visor_GetAllDataTable", "CN_RISPACS");

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
