// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.RisLogDataAccess
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
  public static class RisLogDataAccess
  {
    public static RisLogDomain SaveReturn(RisLogDomain log)
    {
      List<Parameter> parameters = new List<Parameter>();
      parameters.Add(new Parameter()
      {
        Name = "id_log",
        Type = DbType.Int32,
        Value = (object) log.id_log
      });
      parameters.Add(new Parameter()
      {
        Name = "sistema",
        Type = DbType.String,
        Value = (object) log.sistema
      });
      parameters.Add(new Parameter()
      {
        Name = "observacion",
        Type = DbType.String,
        Value = (object) log.observacion
      });
      parameters.Add(new Parameter()
      {
        Name = "id_institucion",
        Type = DbType.Int32,
        Value = (object) log.id_institucion
      });
      parameters.Add(new Parameter()
      {
        Name = "codexamen",
        Type = DbType.String,
        Value = (object) log.codexamen
      });
      parameters.Add(new Parameter()
      {
        Name = "id_ris_examen",
        Type = DbType.Int32,
        Value = (object) log.id_ris_examen
      });
      parameters.Add(new Parameter()
      {
        Name = "fecha",
        Type = DbType.DateTime,
        Value = (object) log.fecha
      });
      parameters.Add(new Parameter()
      {
        Name = "id_usuario",
        Type = DbType.Int32,
        Value = (object) log.id_usuario
      });
      parameters.Add(new Parameter()
      {
        Name = "tipoAccion",
        Type = DbType.Int32,
        Value = (object) log.tipoAccion
      });
      RisLogDomain risLogDomain = new RisLogDomain();
      return DataBaseProcedure.GetEntidad<RisLogDomain>(parameters, "sp_RisLog_Save", "CN_RISPACS") ?? new RisLogDomain();
    }

    public static RisLogDomain GetById(long id_log)
    {
      List<Parameter> parameters = new List<Parameter>();
      parameters.Add(new Parameter()
      {
        Name = nameof (id_log),
        Type = DbType.Int32,
        Value = (object) id_log
      });
      RisLogDomain risLogDomain = new RisLogDomain();
      return DataBaseProcedure.GetEntidad<RisLogDomain>(parameters, "sp_RisLog_GetById", "CN_RISPACS") ?? new RisLogDomain();
    }

    private static RisLogDomain BuildFunction(IDataReader row) => new RisLogDomain()
    {
      id_log = row["id_log"] != DBNull.Value ? (long) row["id_log"] : 0L,
      sistema = row["sistema"] != DBNull.Value ? (string) row["sistema"] : string.Empty,
      observacion = row["observacion"] != DBNull.Value ? (string) row["observacion"] : string.Empty,
      id_institucion = row["id_institucion"] != DBNull.Value ? (int) row["id_institucion"] : 0,
      codexamen = row["codexamen"] != DBNull.Value ? (string) row["codexamen"] : string.Empty,
      id_ris_examen = row["id_ris_examen"] != DBNull.Value ? (long) row["id_ris_examen"] : 0L,
      fecha = row["fecha"] != DBNull.Value ? (DateTime) row["fecha"] : new DateTime(1900, 1, 1),
      id_usuario = row["id_usuario"] != DBNull.Value ? (long) row["id_usuario"] : 0L
    };
  }
}
