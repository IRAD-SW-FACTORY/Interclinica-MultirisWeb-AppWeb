// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.FiltroInstitucionDataAccess
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
  public class FiltroInstitucionDataAccess
  {
    public static long Save(string filtro_institucion, int id_filtro, int sw) => (long) DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "id_filtro_institucion",
        Type = DbType.Int32,
        Value = (object) sw
      },
      new Parameter()
      {
        Name = "id_institucion",
        Type = DbType.String,
        Value = (object) filtro_institucion
      },
      new Parameter()
      {
        Name = nameof (id_filtro),
        Type = DbType.Int32,
        Value = (object) id_filtro
      }
    }, "sp_FiltroInstitucion_Save_Full", "CN_RISPACS");

    public static long Save(FiltroInstitucionDomain filtro_institucion) => (long) DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "id_filtro_institucion",
        Type = DbType.Int32,
        Value = (object) filtro_institucion.id_filtro_institucion
      },
      new Parameter()
      {
        Name = "id_institucion",
        Type = DbType.Int32,
        Value = (object) filtro_institucion.id_institucion
      },
      new Parameter()
      {
        Name = "id_filtro",
        Type = DbType.Int32,
        Value = (object) filtro_institucion.id_filtro
      }
    }, "sp_FiltroInstitucion_Save", "CN_RISPACS");

    public static FiltroInstitucionDomain GetById(long id_filtro_institucion)
    {
      List<Parameter> parameters = new List<Parameter>();
      parameters.Add(new Parameter()
      {
        Name = nameof (id_filtro_institucion),
        Type = DbType.Int32,
        Value = (object) id_filtro_institucion
      });
      FiltroInstitucionDomain institucionDomain = new FiltroInstitucionDomain();
      return DataBaseProcedure.GetEntidad<FiltroInstitucionDomain>(parameters, "sp_FiltroInstitucion_GetById") ?? new FiltroInstitucionDomain();
    }

    public static IList<FiltroInstitucionDomain> GetCollectionByIdFiltro(long id_filtro) => (IList<FiltroInstitucionDomain>) DataBaseProcedure.ListEntidad<FiltroInstitucionDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (id_filtro),
        Type = DbType.Int32,
        Value = (object) id_filtro
      }
    }, "sp_FiltroInstitucion_GetCollectionByIdFiltro", "CN_RISPACS");

    public static FiltroInstitucionDomain getByIdFiltro(long id_filtro) => DataBaseProcedure.GetEntidad<FiltroInstitucionDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (id_filtro),
        Type = DbType.Int32,
        Value = (object) id_filtro
      }
    }, "sp_FiltroInstitucion_getByIdFiltro");

    public static long DeleteByIdFiltro(long id_filtro)
    {
      StoredProcedure.EjecutarProcedure(new List<Parameter>()
      {
        new Parameter()
        {
          Name = nameof (id_filtro),
          Type = DbType.Int32,
          Value = (object) id_filtro
        }
      }, "sp_FiltroInstitucion_DeleteByIdFiltro", "CN_RISPACS");
      return 0;
    }

        public static bool Insert(long idFiltro, int idInstitucion)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter() { Name = "@idFiltro", Type = DbType.Int64, Value = idFiltro });
            parameters.Add(new Parameter() { Name = "@idInstitucion", Type = DbType.Int32, Value = idInstitucion });

            return IradDBNet.DataBaseProcedure.GetInt(parameters, "sp_FiltroInstitucionInsert", "CN_RISPACS") > 0;
        }

        public static List<FiltroInstitucionDomain> Listar(long idFiltro)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter() { Name = "@id_filtro", Type = DbType.Int64, Value = idFiltro });

            return IradDBNet.DataBaseProcedure.ListEntidad<FiltroInstitucionDomain>(parameters, "sp_FiltroInstitucion_listar", "CN_RISPACS");
        }

        private static FiltroInstitucionDomain BuildFunction(IDataReader row) => new FiltroInstitucionDomain()
    {
      id_filtro_institucion = row["id_filtro_institucion"] != DBNull.Value ? (long) row["id_filtro_institucion"] : 0L,
      id_institucion = row["id_institucion"] != DBNull.Value ? (int) row["id_institucion"] : 0,
      id_filtro = row["id_filtro"] != DBNull.Value ? (long) row["id_filtro"] : 0L
    };
  }
}
