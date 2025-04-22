// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.RisOrdenExamenDataAccess
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
  public class RisOrdenExamenDataAccess
  {
    public static long Save(RisOrdenExamenDomain orden_examen) => (long) DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "id_ris_orden_examen",
        Type = DbType.Int32,
        Value = (object) orden_examen.id_ris_orden_examen
      },
      new Parameter()
      {
        Name = "id_orden_examen_remoto",
        Type = DbType.Int32,
        Value = (object) orden_examen.id_orden_examen_remoto
      },
      new Parameter()
      {
        Name = "id_institucion",
        Type = DbType.Int32,
        Value = (object) orden_examen.id_institucion
      },
      new Parameter()
      {
        Name = "observaciones",
        Type = DbType.String,
        Value = (object) orden_examen.observaciones
      },
      new Parameter()
      {
        Name = "antecedentes_clinicos",
        Type = DbType.String,
        Value = (object) orden_examen.antecedentes_clinicos
      }
    }, "sp_RisOrdenExamen_Save", "CN_RISPACS");

    public static RisOrdenExamenDomain GetByIdOrdenAndInsti(
      long id_orden_examen_remoto,
      int id_institucion)
    {
      List<Parameter> parameters = new List<Parameter>();
      parameters.Add(new Parameter()
      {
        Name = nameof (id_orden_examen_remoto),
        Type = DbType.Int32,
        Value = (object) id_orden_examen_remoto
      });
      parameters.Add(new Parameter()
      {
        Name = nameof (id_institucion),
        Type = DbType.Int32,
        Value = (object) id_institucion
      });
      RisOrdenExamenDomain ordenExamenDomain = new RisOrdenExamenDomain();
      return DataBaseProcedure.GetEntidad<RisOrdenExamenDomain>(parameters, "SP_RisOrdenExamen_GetByIdOrdenAndInsti", "CN_RISPACS") ?? new RisOrdenExamenDomain();
    }

    private static RisOrdenExamenDomain BuildFunction(IDataReader row) => new RisOrdenExamenDomain()
    {
      id_ris_orden_examen = row["id_ris_orden_examen"] != DBNull.Value ? (long) row["id_ris_orden_examen"] : 0L,
      id_orden_examen_remoto = row["id_orden_examen_remoto"] != DBNull.Value ? (long) row["id_orden_examen_remoto"] : 0L,
      id_institucion = row["id_institucion"] != DBNull.Value ? (int) row["id_institucion"] : 0,
      observaciones = row["observaciones"] != DBNull.Value ? (string) row["observaciones"] : string.Empty,
      antecedentes_clinicos = row["antecedentes_clinicos"] != DBNull.Value ? (string) row["antecedentes_clinicos"] : string.Empty
    };
  }
}
