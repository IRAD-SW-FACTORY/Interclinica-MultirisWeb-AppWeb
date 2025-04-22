// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.SolicitudAddendumDataAccess
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
  public class SolicitudAddendumDataAccess
  {
    public static SolicitudAddendumDomain Save(SolicitudAddendumDomain solicitudAddendum)
    {
      List<Parameter> parameters = new List<Parameter>();
      parameters.Add(new Parameter()
      {
        Name = "id_solicitud_addendum",
        Type = DbType.Int32,
        Value = (object) solicitudAddendum.id_solicitud_addendum
      });
      parameters.Add(new Parameter()
      {
        Name = "codexamen",
        Type = DbType.String,
        Value = (object) solicitudAddendum.codexamen
      });
      parameters.Add(new Parameter()
      {
        Name = "id_institucion",
        Type = DbType.Int32,
        Value = (object) solicitudAddendum.id_institucion
      });
      parameters.Add(new Parameter()
      {
        Name = "id_ris_examen",
        Type = DbType.Int32,
        Value = (object) solicitudAddendum.id_ris_examen
      });
      parameters.Add(new Parameter()
      {
        Name = "usuario",
        Type = DbType.String,
        Value = (object) solicitudAddendum.usuario
      });
      parameters.Add(new Parameter()
      {
        Name = "motivo",
        Type = DbType.String,
        Value = (object) solicitudAddendum.motivo
      });
      parameters.Add(new Parameter()
      {
        Name = "id_estado_addendum",
        Type = DbType.Int32,
        Value = (object) solicitudAddendum.id_estado_addendum
      });
      parameters.Add(new Parameter()
      {
        Name = "fecha_solicitud",
        Type = DbType.DateTime,
        Value = (object) solicitudAddendum.fecha_solicitud
      });
      parameters.Add(new Parameter()
      {
        Name = "fecha_resolucion",
        Type = DbType.DateTime,
        Value = (object) solicitudAddendum.fecha_resolucion
      });
      SolicitudAddendumDomain solicitudAddendumDomain = new SolicitudAddendumDomain();
      return DataBaseProcedure.GetEntidad<SolicitudAddendumDomain>(parameters, "sp_SolicitudAddendum_Save") ?? new SolicitudAddendumDomain();
    }

    public static SolicitudAddendumDomain GetById(long id_solicitud_addendum)
    {
      List<Parameter> parameters = new List<Parameter>();
      parameters.Add(new Parameter()
      {
        Name = nameof (id_solicitud_addendum),
        Type = DbType.Int32,
        Value = (object) id_solicitud_addendum
      });
      SolicitudAddendumDomain solicitudAddendumDomain = new SolicitudAddendumDomain();
      return DataBaseProcedure.GetEntidad<SolicitudAddendumDomain>(parameters, "sp_SolicitudAddendum_GetById") ?? new SolicitudAddendumDomain();
    }

    public static SolicitudAddendumDomain GetByIdInforme(long id_informe)
    {
      List<Parameter> parameters = new List<Parameter>();
      parameters.Add(new Parameter()
      {
        Name = nameof (id_informe),
        Type = DbType.Int32,
        Value = (object) id_informe
      });
      SolicitudAddendumDomain solicitudAddendumDomain = new SolicitudAddendumDomain();
      return DataBaseProcedure.GetEntidad<SolicitudAddendumDomain>(parameters, "sp_SolicitudAddendum_GetByIdInforme") ?? new SolicitudAddendumDomain();
    }

    public static IList<SolicitudAddendumDomain> GetByCodExamenInstitucion(
      string codexamen,
      int id_institucion)
    {
      return (IList<SolicitudAddendumDomain>) DataBaseProcedure.ListEntidad<SolicitudAddendumDomain>(new List<Parameter>()
      {
        new Parameter()
        {
          Name = nameof (codexamen),
          Type = DbType.String,
          Value = (object) codexamen
        },
        new Parameter()
        {
          Name = nameof (id_institucion),
          Type = DbType.Int32,
          Value = (object) id_institucion
        }
      }, "sp_SolicitudAddendum_GetByCodExamenInstitucion", "CN_RISPACS");
    }

    public static IList<SolicitudAddendumDomain> GetByEstado(int id_estado_addendum) => (IList<SolicitudAddendumDomain>) DataBaseProcedure.ListEntidad<SolicitudAddendumDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (id_estado_addendum),
        Type = DbType.Int32,
        Value = (object) id_estado_addendum
      }
    }, "sp_SolicitudAddendum_GetByEstado", "CN_RISPACS");

    private static SolicitudAddendumDomain BuildFunction(IDataReader row) => new SolicitudAddendumDomain()
    {
      id_solicitud_addendum = row["id_solicitud_addendum"] != DBNull.Value ? (long) row["id_solicitud_addendum"] : 0L,
      codexamen = row["codexamen"] != DBNull.Value ? (string) row["codexamen"] : string.Empty,
      id_institucion = row["id_institucion"] != DBNull.Value ? (int) row["id_institucion"] : 0,
      id_ris_examen = row["id_ris_examen"] != DBNull.Value ? (long) row["id_ris_examen"] : 0L,
      usuario = row["usuario"] != DBNull.Value ? (string) row["usuario"] : string.Empty,
      motivo = row["motivo"] != DBNull.Value ? (string) row["motivo"] : string.Empty,
      id_estado_addendum = row["id_estado_addendum"] != DBNull.Value ? (int) row["id_estado_addendum"] : 0,
      fecha_solicitud = row["fecha_solicitud"] != DBNull.Value ? (DateTime) row["fecha_solicitud"] : new DateTime(1900, 1, 1),
      fecha_resolucion = row["fecha_resolucion"] != DBNull.Value ? (DateTime) row["fecha_resolucion"] : new DateTime(1900, 1, 1)
    };
  }
}
