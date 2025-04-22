// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.RisPatologiaCriticaDataAccess
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using IradDBNet;
using IradDBNet.Bcp;
using IradDBNet.Dao;
using IradDBNet.Dto;
using MultiRisWeb.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data;

namespace MultiRisWeb.Data.DataAccess
{
  public class RisPatologiaCriticaDataAccess
  {
    public static DataTable GetByInstitucion(long id_institucion) => StoredProcedure.EjecutarProcedure(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (id_institucion),
        Type = DbType.String,
        Value = (object) id_institucion
      }
    }, "sp_RisPatologiaCritica_GetByInstitucion", "CN_RISPACS");

    public static List<RisPatologiaCriticaDomain> Listar(long idInstitucion) => DataBaseProcedure.ListEntidad<RisPatologiaCriticaDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "@id_institucion",
        Type = DbType.Int64,
        Value = (object) idInstitucion
      }
    }, "sp_RisPatologiaCritica_GetByInstitucion", "CN_RISPACS");

    public static RisPatologiaCriticaDomain GetById(int id_patologia_critica) => Entidad.Get<RisPatologiaCriticaDomain>(StoredProcedure.EjecutarProcedure(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (id_patologia_critica),
        Type = DbType.Int32,
        Value = (object) id_patologia_critica
      }
    }, "sp_RisPatologiaCritica_GetById", "CN_RISPACS"));

    private static RisPatologiaCriticaDomain BuildFunction(IDataReader row) => new RisPatologiaCriticaDomain()
    {
      id_patologia_critica = row["id_patologia_critica"] != DBNull.Value ? (long) row["id_patologia_critica"] : 0L,
      nombre = row["nombre"] != DBNull.Value ? (string) row["nombre"] : string.Empty,
      estado = row["estado"] != DBNull.Value && (bool) row["estado"],
      id_institucion = row["id_institucion"] != DBNull.Value ? (int) row["id_institucion"] : 0
    };
  }
}
