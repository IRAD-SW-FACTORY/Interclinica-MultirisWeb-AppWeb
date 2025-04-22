// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.RisPlantillaDataAccess
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
  public class RisPlantillaDataAccess
  {
    public static long Save(RisPlantillaDomain plantilla) => (long) DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "id_plantilla",
        Type = DbType.Int32,
        Value = (object) plantilla.id_plantilla
      },
      new Parameter()
      {
        Name = "nombre",
        Type = DbType.String,
        Value = (object) plantilla.nombre
      },
      new Parameter()
      {
        Name = "titulo",
        Type = DbType.String,
        Value = (object) plantilla.titulo
      },
      new Parameter()
      {
        Name = "tecnica",
        Type = DbType.String,
        Value = (object) plantilla.tecnica
      },
      new Parameter()
      {
        Name = "hallazgos",
        Type = DbType.String,
        Value = (object) plantilla.hallazgos
      },
      new Parameter()
      {
        Name = "impresion",
        Type = DbType.String,
        Value = (object) plantilla.impresion
      },
      new Parameter()
      {
        Name = "id_usuario",
        Type = DbType.Int32,
        Value = (object) plantilla.id_usuario
      },
      new Parameter()
      {
        Name = "id_modalidad",
        Type = DbType.Int32,
        Value = (object) plantilla.id_modalidad
      }
    }, "sp_RisPlantilla_Save", "CN_RISPACS");

    public static RisPlantillaDomain GetById(long id_plantilla)
    {
      List<Parameter> parameters = new List<Parameter>();
      parameters.Add(new Parameter()
      {
        Name = nameof (id_plantilla),
        Type = DbType.String,
        Value = (object) id_plantilla
      });
      RisPlantillaDomain risPlantillaDomain = new RisPlantillaDomain();
      return DataBaseProcedure.GetEntidad<RisPlantillaDomain>(parameters, "sp_RisPlantilla_GetById", "CN_RISPACS") ?? new RisPlantillaDomain();
    }

    public static RisPlantillaDomain GetByUsuarioModalidad(int id_modalidad, int id_usuario)
    {
      List<Parameter> parameters = new List<Parameter>();
      parameters.Add(new Parameter()
      {
        Name = nameof (id_modalidad),
        Type = DbType.Int32,
        Value = (object) id_modalidad
      });
      parameters.Add(new Parameter()
      {
        Name = nameof (id_usuario),
        Type = DbType.Int32,
        Value = (object) id_usuario
      });
      RisPlantillaDomain risPlantillaDomain = new RisPlantillaDomain();
      return DataBaseProcedure.GetEntidad<RisPlantillaDomain>(parameters, "sp_RisPlantilla_GetByUsuarioModalidad", "CN_RISPACS") ?? new RisPlantillaDomain();
    }

    public static IList<RisPlantillaDomain> ListByNameUser(
      long id_usuario,
      string nombre,
      long id_plantilla)
    {
      return (IList<RisPlantillaDomain>) DataBaseProcedure.ListEntidad<RisPlantillaDomain>(new List<Parameter>()
      {
        new Parameter()
        {
          Name = nameof (id_usuario),
          Type = DbType.Int32,
          Value = (object) id_usuario
        },
        new Parameter()
        {
          Name = nameof (nombre),
          Type = DbType.String,
          Value = (object) nombre
        },
        new Parameter()
        {
          Name = nameof (id_plantilla),
          Type = DbType.String,
          Value = (object) id_plantilla
        }
      }, "sp_RisPlantilla_ListByNameUser", "CN_RISPACS");
    }

    public static IList<RisPlantillaDomain> ListByUser(long id_usuario) => (IList<RisPlantillaDomain>) DataBaseProcedure.ListEntidad<RisPlantillaDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (id_usuario),
        Type = DbType.Int32,
        Value = (object) id_usuario
      }
    }, "sp_RisPlantilla_ListByUser", "CN_RISPACS");

    public static DataTable ListByUserState(long id_usuario, int id_estado) => StoredProcedure.EjecutarProcedure(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (id_usuario),
        Type = DbType.Int32,
        Value = (object) id_usuario
      },
      new Parameter()
      {
        Name = nameof (id_estado),
        Type = DbType.Int32,
        Value = (object) id_estado
      }
    }, "sp_RisPlantilla_ListByUserState", "CN_RISPACS");

    public static DataTable ListByUserStateAndModalidad(long id_usuario, string modalidad) => StoredProcedure.EjecutarProcedure(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (id_usuario),
        Type = DbType.Int32,
        Value = (object) id_usuario
      },
      new Parameter()
      {
        Name = nameof (modalidad),
        Type = DbType.String,
        Value = (object) modalidad
      }
    }, "sp_RisPlantilla_ListByUserStateAndModalidad", "CN_RISPACS");

    public static RisPlantillaDomain GetByPlantillaUser(long id_plantilla, long id_usuario)
    {
      List<Parameter> parameters = new List<Parameter>();
      parameters.Add(new Parameter()
      {
        Name = nameof (id_plantilla),
        Type = DbType.Int32,
        Value = (object) id_plantilla
      });
      parameters.Add(new Parameter()
      {
        Name = nameof (id_usuario),
        Type = DbType.Int32,
        Value = (object) id_usuario
      });
      RisPlantillaDomain risPlantillaDomain = new RisPlantillaDomain();
      return DataBaseProcedure.GetEntidad<RisPlantillaDomain>(parameters, "sp_RisPlantilla_GetByPlantillaUser", "CN_RISPACS") ?? new RisPlantillaDomain();
    }

    public static long DeleteByIdPlantilla(long id_plantilla)
    {
      StoredProcedure.EjecutarProcedure(new List<Parameter>()
      {
        new Parameter()
        {
          Name = nameof (id_plantilla),
          Type = DbType.Int32,
          Value = (object) id_plantilla
        }
      }, "sp_Plantilla_DeleteByIdPlantilla", "CN_RISPACS");
      return 0;
    }

    public static List<RisPlantillaDomain> Listar(int idUsuario, string modalidad) => DataBaseProcedure.ListEntidad<RisPlantillaDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "@modalidad",
        Type = DbType.String,
        Value = (object) modalidad
      },
      new Parameter()
      {
        Name = "@id_usuario",
        Type = DbType.Int32,
        Value = (object) idUsuario
      }
    }, "sp_RisPlantilla_Get", "CN_RISPACS");

    private static RisPlantillaDomain BuildFunction(IDataReader fila) => new RisPlantillaDomain()
    {
      id_plantilla = fila["id_plantilla"] != DBNull.Value ? (long) Convert.ToInt32(fila["id_plantilla"]) : 0L,
      nombre = fila["nombre"] != DBNull.Value ? fila["nombre"].ToString() : string.Empty,
      titulo = fila["titulo"] != DBNull.Value ? fila["titulo"].ToString() : string.Empty,
      tecnica = fila["tecnica"] != DBNull.Value ? fila["tecnica"].ToString() : string.Empty,
      hallazgos = fila["hallazgos"] != DBNull.Value ? fila["hallazgos"].ToString() : string.Empty,
      impresion = fila["impresion"] != DBNull.Value ? fila["impresion"].ToString() : string.Empty,
      id_modalidad = fila["id_modalidad"] != DBNull.Value ? Convert.ToInt32(fila["id_modalidad"]) : 0,
      id_usuario = fila["id_usuario"] != DBNull.Value ? (long) Convert.ToInt32(fila["id_usuario"]) : 0L
    };
  }
}
