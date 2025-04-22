// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.RisInformePrestacionDataAccess
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
  public class RisInformePrestacionDataAccess
  {
    public static long Save(RisInformePrestacionDomain ris_informe_prestacion) => (long) DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "id_informe_prestacion",
        Type = DbType.Int32,
        Value = (object) ris_informe_prestacion.id_informe_prestacion
      },
      new Parameter()
      {
        Name = "id_ris_informe_prestacion_remoto",
        Type = DbType.Int32,
        Value = (object) ris_informe_prestacion.id_ris_informe_prestacion_remoto
      },
      new Parameter()
      {
        Name = "id_informe",
        Type = DbType.Int32,
        Value = (object) ris_informe_prestacion.id_informe
      },
      new Parameter()
      {
        Name = "id_prestacion",
        Type = DbType.Int32,
        Value = (object) ris_informe_prestacion.id_prestacion
      },
      new Parameter()
      {
        Name = "fecha",
        Type = DbType.DateTime,
        Value = (object) ris_informe_prestacion.fecha
      },
      new Parameter()
      {
        Name = "id_institucion",
        Type = DbType.Int32,
        Value = (object) ris_informe_prestacion.id_institucion
      }
    }, "sp_RisInformePrestacion_Save", "CN_RISPACS");

    public static RisInformePrestacionDomain GetById(long id)
    {
      List<Parameter> parameters = new List<Parameter>();
      parameters.Add(new Parameter()
      {
        Name = nameof (id),
        Type = DbType.Int32,
        Value = (object) id
      });
      RisInformePrestacionDomain prestacionDomain = new RisInformePrestacionDomain();
      return DataBaseProcedure.GetEntidad<RisInformePrestacionDomain>(parameters, "sp_RisInformePrestacion_GetById", "CN_RISPACS") ?? new RisInformePrestacionDomain();
    }

    public static RisInformePrestacionDomain GetByIDInformeAndIDPrestacion(
      long id_informe,
      long id_prestacion,
      int id_institucion)
    {
      RisInformePrestacionDomain prestacionDomain = new RisInformePrestacionDomain();
      return DataBaseProcedure.GetEntidad<RisInformePrestacionDomain>(new List<Parameter>()
      {
        new Parameter()
        {
          Name = nameof (id_informe),
          Type = DbType.Int32,
          Value = (object) id_informe
        },
        new Parameter()
        {
          Name = nameof (id_prestacion),
          Type = DbType.Int32,
          Value = (object) id_prestacion
        },
        new Parameter()
        {
          Name = nameof (id_institucion),
          Type = DbType.Int32,
          Value = (object) id_institucion
        }
      }, "sp_RisInformePrestacion_GetByIDInformeAndIDPrestacion", "CN_RISPACS") ?? new RisInformePrestacionDomain();
    }

    public static IList<RisInformePrestacionDomain> GetByCodExamen(string codExamen) => (IList<RisInformePrestacionDomain>) DataBaseProcedure.ListEntidad<RisInformePrestacionDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (codExamen),
        Type = DbType.String,
        Value = (object) codExamen
      }
    }, "sp_RisInformePrestacion_GetByCodExamen", "CN_RISPACS");

    public static IList<RisInformePrestacionDomain> GetListByIdInforme(long id_ris_informe) => (IList<RisInformePrestacionDomain>) DataBaseProcedure.ListEntidad<RisInformePrestacionDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (id_ris_informe),
        Type = DbType.Int32,
        Value = (object) id_ris_informe
      }
    }, "sp_RisInformePrestacion_GetListByIdInforme", "CN_RISPACS");

    public static IList<RisInformePrestacionDomain> GetByIdInforme(long id_informe) => (IList<RisInformePrestacionDomain>) DataBaseProcedure.ListEntidad<RisInformePrestacionDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (id_informe),
        Type = DbType.Int32,
        Value = (object) id_informe
      }
    }, "sp_RisInformePrestacion_GetByIdInforme", "CN_RISPACS");

    private static RisInformePrestacionDomain BuildFunction(IDataReader row) => new RisInformePrestacionDomain()
    {
      id_informe_prestacion = row["id_informe_prestacion"] != DBNull.Value ? (long) row["id_informe_prestacion"] : 0L,
      id_ris_informe_prestacion_remoto = row["id_ris_informe_prestacion_remoto"] != DBNull.Value ? (long) row["id_ris_informe_prestacion_remoto"] : 0L,
      id_informe = row["id_informe"] != DBNull.Value ? (long) row["id_informe"] : 0L,
      id_prestacion = row["id_prestacion"] != DBNull.Value ? (long) row["id_prestacion"] : 0L,
      fecha = row["fecha"] != DBNull.Value ? (DateTime) row["fecha"] : new DateTime(1900, 1, 1),
      id_institucion = row["id_institucion"] != DBNull.Value ? (int) row["id_institucion"] : 0
    };
  }
}
