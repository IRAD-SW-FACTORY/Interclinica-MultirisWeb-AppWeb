// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.RisInformeDatoDataAccess
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
  public class RisInformeDatoDataAccess
  {
    public static long Save(RisInformeDatoDomain ris_informe_dato) => (long) DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "id_informe_dato",
        Type = DbType.Int32,
        Value = (object) ris_informe_dato.id_informe_dato
      },
      new Parameter()
      {
        Name = "id_informe_dato_remoto",
        Type = DbType.Int32,
        Value = (object) ris_informe_dato.id_informe_dato_remoto
      },
      new Parameter()
      {
        Name = "cod_examen",
        Type = DbType.String,
        Value = (object) ris_informe_dato.cod_examen
      },
      new Parameter()
      {
        Name = "id_dato",
        Type = DbType.Int32,
        Value = (object) ris_informe_dato.id_dato
      },
      new Parameter()
      {
        Name = "valor",
        Type = DbType.String,
        Value = (object) ris_informe_dato.valor
      },
      new Parameter()
      {
        Name = "fecha",
        Type = DbType.DateTime,
        Value = (object) ris_informe_dato.fecha
      },
      new Parameter()
      {
        Name = "id_informe",
        Type = DbType.Int32,
        Value = (object) ris_informe_dato.id_informe
      },
      new Parameter()
      {
        Name = "posicion",
        Type = DbType.Int32,
        Value = (object) ris_informe_dato.posicion
      },
      new Parameter()
      {
        Name = "id_institucion",
        Type = DbType.Int32,
        Value = (object) ris_informe_dato.id_institucion
      }
    }, "sp_RisInformeDato_Save", "CN_RISPACS");

    public static RisInformeDatoDomain GetById(long id) => DataBaseProcedure.GetEntidad<RisInformeDatoDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "id_dato",
        Type = DbType.Int32,
        Value = (object) id
      }
    }, "sp_RisInformeDato_GetById", "CN_RISPACS");

    public static RisInformeDatoDomain GetByMultuple(
      long id_informe,
      int id_institucion,
      string codExamen,
      int id_dato)
    {
      List<Parameter> parameters = new List<Parameter>();
      parameters.Add(new Parameter()
      {
        Name = nameof (id_informe),
        Type = DbType.Int32,
        Value = (object) id_informe
      });
      parameters.Add(new Parameter()
      {
        Name = nameof (id_institucion),
        Type = DbType.Int32,
        Value = (object) id_institucion
      });
      parameters.Add(new Parameter()
      {
        Name = nameof (codExamen),
        Type = DbType.String,
        Value = (object) codExamen
      });
      parameters.Add(new Parameter()
      {
        Name = nameof (id_dato),
        Type = DbType.String,
        Value = (object) id_dato
      });
      RisInformeDatoDomain informeDatoDomain = new RisInformeDatoDomain();
      return DataBaseProcedure.GetEntidad<RisInformeDatoDomain>(parameters, "sp_RisInformeDato_GetByMultuple", "CN_RISPACS") ?? new RisInformeDatoDomain();
    }

    private static RisInformeDatoDomain BuildFunction(IDataReader row) => new RisInformeDatoDomain()
    {
      id_informe_dato = row["id_informe_dato"] != DBNull.Value ? (long) row["id_informe_dato"] : 0L,
      id_informe_dato_remoto = row["id_informe_dato_remoto"] != DBNull.Value ? (long) row["id_informe_dato_remoto"] : 0L,
      cod_examen = row["cod_examen"] != DBNull.Value ? (string) row["cod_examen"] : string.Empty,
      id_dato = row["id_dato"] != DBNull.Value ? (int) row["id_dato"] : 0,
      valor = row["valor"] != DBNull.Value ? (string) row["valor"] : string.Empty,
      fecha = row["fecha"] != DBNull.Value ? (DateTime) row["fecha"] : new DateTime(1900, 1, 1),
      id_informe = row["id_informe"] != DBNull.Value ? (long) row["id_informe"] : 0L,
      posicion = row["posicion"] != DBNull.Value ? (int) row["posicion"] : 0,
      id_institucion = row["id_institucion"] != DBNull.Value ? (int) row["id_institucion"] : 0
    };
  }
}
