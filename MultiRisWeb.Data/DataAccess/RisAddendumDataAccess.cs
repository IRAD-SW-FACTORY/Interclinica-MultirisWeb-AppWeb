// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.RisAddendumDataAccess
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
  public class RisAddendumDataAccess
  {
    public static long Save(RisAddendumDomain addendum) => (long) DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "id_addendum",
        Type = DbType.Int32,
        Value = (object) addendum.id_addendum
      },
      new Parameter()
      {
        Name = "id_addendum_remoto",
        Type = DbType.Int32,
        Value = (object) addendum.id_addendum_remoto
      },
      new Parameter()
      {
        Name = "id_informe",
        Type = DbType.Int32,
        Value = (object) addendum.id_informe
      },
      new Parameter()
      {
        Name = "username",
        Type = DbType.String,
        Value = (object) addendum.username
      },
      new Parameter()
      {
        Name = "cod_examen",
        Type = DbType.String,
        Value = (object) addendum.cod_examen
      },
      new Parameter()
      {
        Name = "fecha_hora",
        Type = DbType.DateTime,
        Value = (object) addendum.fecha_hora
      },
      new Parameter()
      {
        Name = nameof (addendum),
        Type = DbType.String,
        Value = (object) addendum.addendum
      },
      new Parameter()
      {
        Name = "estado_visible",
        Type = DbType.Int32,
        Value = (object) addendum.estado_visible
      },
      new Parameter()
      {
        Name = "estado_bloqueo",
        Type = DbType.String,
        Value = (object) addendum.estado_bloqueo
      },
      new Parameter()
      {
        Name = "flag_patologia_grave",
        Type = DbType.Int32,
        Value = (object) addendum.flag_patologia_grave
      },
      new Parameter()
      {
        Name = "patologia_grave",
        Type = DbType.String,
        Value = (object) addendum.patologia_grave
      }
    }, "sp_RisAddendum_Save", "CN_RISPACS");

    public static RisAddendumDomain GetByID(long id_addendum)
    {
      List<Parameter> parameters = new List<Parameter>();
      parameters.Add(new Parameter()
      {
        Name = nameof (id_addendum),
        Type = DbType.Int32,
        Value = (object) id_addendum
      });
      RisAddendumDomain risAddendumDomain = new RisAddendumDomain();
      return DataBaseProcedure.GetEntidad<RisAddendumDomain>(parameters, "sp_RisAddendum_GetByID", "CN_RISPACS") ?? new RisAddendumDomain();
    }

    public static RisAddendumDomain GetlatestByActive(long id_informe)
    {
      List<Parameter> parameters = new List<Parameter>();
      parameters.Add(new Parameter()
      {
        Name = nameof (id_informe),
        Type = DbType.Int32,
        Value = (object) id_informe
      });
      RisAddendumDomain risAddendumDomain = new RisAddendumDomain();
      return DataBaseProcedure.GetEntidad<RisAddendumDomain>(parameters, "sp_RisAddendum_GetlatestByActive", "CN_RISPACS") ?? new RisAddendumDomain();
    }

    public static IList<RisAddendumDomain> GetByCodExamenIDInforme(
      string cod_examen,
      long id_informe)
    {
      return (IList<RisAddendumDomain>) DataBaseProcedure.ListEntidad<RisAddendumDomain>(new List<Parameter>()
      {
        new Parameter()
        {
          Name = nameof (cod_examen),
          Type = DbType.String,
          Value = (object) cod_examen
        },
        new Parameter()
        {
          Name = nameof (id_informe),
          Type = DbType.Int32,
          Value = (object) id_informe
        }
      }, "sp_RisAddendum_GetByCodExamenIDInforme", "CN_RISPACS");
    }

    private static RisAddendumDomain BuildFunction(IDataReader row) => new RisAddendumDomain()
    {
      id_addendum = row["id_addendum"] != DBNull.Value ? (long) row["id_addendum"] : 0L,
      id_addendum_remoto = row["id_addendum_remoto"] != DBNull.Value ? (long) row["id_addendum_remoto"] : 0L,
      id_informe = row["id_informe"] != DBNull.Value ? (long) row["id_informe"] : 0L,
      username = row["username"] != DBNull.Value ? (string) row["username"] : string.Empty,
      cod_examen = row["cod_examen"] != DBNull.Value ? (string) row["cod_examen"] : string.Empty,
      fecha_hora = row["fecha_hora"] != DBNull.Value ? (DateTime) row["fecha_hora"] : new DateTime(1900, 1, 1),
      addendum = row["addendum"] != DBNull.Value ? (string) row["addendum"] : string.Empty,
      estado_visible = row["estado_visible"] != DBNull.Value ? (int) row["estado_visible"] : 0,
      estado_bloqueo = row["estado_bloqueo"] != DBNull.Value ? (int) row["estado_bloqueo"] : 0
    };

    public static int NuevasSolProcesadas(long IdExamen) => DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "@IdExamen",
        Type = DbType.Int32,
        Value = (object) IdExamen
      }
    }, "sp_existenSolAddemdum_proc", "CN_RISPACS");
  }
}
