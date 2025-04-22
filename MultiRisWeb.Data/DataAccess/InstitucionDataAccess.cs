// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.InstitucionDataAccess
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
  public class InstitucionDataAccess
  {
    public static void UpdateFlagComentarios(int id_institucion, int tipoEntrada) => StoredProcedure.EjecutarProcedure(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (id_institucion),
        Type = DbType.Int32,
        Value = (object) id_institucion
      },
      new Parameter()
      {
        Name = nameof (tipoEntrada),
        Type = DbType.Int32,
        Value = (object) tipoEntrada
      }
    }, "sp_RisWeb_UpdateInstitucionFlagComentarios", "CN_RISPACS");

    public static long Save(InstitucionDomain institucion) => (long) DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "id_institucion",
        Type = DbType.Int32,
        Value = (object) institucion.id_institucion
      },
      new Parameter()
      {
        Name = "nombre",
        Type = DbType.String,
        Value = (object) institucion.nombre
      },
      new Parameter()
      {
        Name = "descripcion",
        Type = DbType.String,
        Value = (object) institucion.descripcion
      },
      new Parameter()
      {
        Name = "estado",
        Type = DbType.Int32,
        Value = (object) institucion.estado
      },
      new Parameter()
      {
        Name = "url_pagina",
        Type = DbType.String,
        Value = (object) institucion.url_pagina
      },
      new Parameter()
      {
        Name = "aetitle",
        Type = DbType.String,
        Value = (object) institucion.aetitle
      },
      new Parameter()
      {
        Name = "url_descarga",
        Type = DbType.String,
        Value = (object) institucion.url_descarga
      },
      new Parameter()
      {
        Name = "url_base",
        Type = DbType.String,
        Value = (object) institucion.url_base
      },
      new Parameter()
      {
        Name = "id_tipo_conexion",
        Type = DbType.Int32,
        Value = (object) institucion.id_tipo_conexion
      },
      new Parameter()
      {
        Name = "addendum",
        Type = DbType.Int32,
        Value = (object) institucion.addendum
      },
      new Parameter()
      {
        Name = "formulario_unico",
        Type = DbType.Int32,
        Value = (object) institucion.formulario_unico
      },
      new Parameter()
      {
        Name = "url_informe_oit",
        Type = DbType.String,
        Value = (object) institucion.url_informe_oit
      },
      new Parameter()
      {
        Name = "flag_contingencia",
        Type = DbType.Int32,
        Value = (object) institucion.flagContingencia
      }
    }, "sp_RisWeb_UpdateInstitucion", "CN_RISPACS");

    public static long SaveModal(InstitucionDomain institucion) => (long) DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "id_institucion",
        Type = DbType.Int32,
        Value = (object) institucion.id_institucion
      },
      new Parameter()
      {
        Name = "nombre",
        Type = DbType.String,
        Value = (object) institucion.nombre
      },
      new Parameter()
      {
        Name = "descripcion",
        Type = DbType.String,
        Value = (object) institucion.descripcion
      },
      new Parameter()
      {
        Name = "estado",
        Type = DbType.Int32,
        Value = (object) institucion.estado
      },
      new Parameter()
      {
        Name = "url_pagina",
        Type = DbType.String,
        Value = (object) institucion.url_pagina
      },
      new Parameter()
      {
        Name = "aetitle",
        Type = DbType.String,
        Value = (object) institucion.aetitle
      },
      new Parameter()
      {
        Name = "url_descarga",
        Type = DbType.String,
        Value = (object) institucion.url_descarga
      },
      new Parameter()
      {
        Name = "url_base",
        Type = DbType.String,
        Value = (object) institucion.url_base
      },
      new Parameter()
      {
        Name = "id_tipo_conexion",
        Type = DbType.Int32,
        Value = (object) institucion.id_tipo_conexion
      },
      new Parameter()
      {
        Name = "addendum",
        Type = DbType.Int32,
        Value = (object) institucion.addendum
      },
      new Parameter()
      {
        Name = "formulario_unico",
        Type = DbType.Int32,
        Value = (object) institucion.formulario_unico
      },
      new Parameter()
      {
        Name = "url_informe_oit",
        Type = DbType.String,
        Value = (object) institucion.url_informe_oit
      },
      new Parameter()
      {
        Name = "url_informe",
        Type = DbType.String,
        Value = (object) institucion.url_informe
      },
      new Parameter()
      {
        Name = "id_institucion_padre",
        Type = DbType.Int32,
        Value = (object) institucion.id_institucion_padre
      },
      new Parameter()
      {
        Name = "logo",
        Type = DbType.String,
        Value = (object) institucion.logo
      },
      new Parameter()
      {
        Name = "estructura",
        Type = DbType.String,
        Value = (object) institucion.estructura
      },
      new Parameter()
      {
        Name = "margen_superior",
        Type = DbType.Int32,
        Value = (object) institucion.margen_superior
      },
      new Parameter()
      {
        Name = "margen_inferior",
        Type = DbType.Int32,
        Value = (object) institucion.margen_inferior
      },
      new Parameter()
      {
        Name = "margen_izquierda",
        Type = DbType.Int32,
        Value = (object) institucion.margen_izquierda
      },
      new Parameter()
      {
        Name = "margen_derecha",
        Type = DbType.Int32,
        Value = (object) institucion.margen_derecha
      },
      new Parameter()
      {
        Name = "codigo_qr",
        Type = DbType.String,
        Value = (object) institucion.codigo_qr
      },
      new Parameter()
      {
        Name = "id_tipo_becado",
        Type = DbType.Int32,
        Value = (object) institucion.id_tipo_becado
      },
      new Parameter()
      {
        Name = "id_grupo",
        Type = DbType.Int32,
        Value = (object) institucion.id_grupo
      },
      new Parameter()
      {
        Name = "correo_patologia_critica",
        Type = DbType.String,
        Value = (object) institucion.correo_patologia_critica
      },
      new Parameter()
      {
        Name = "correo_cc_patologia_critica",
        Type = DbType.String,
        Value = (object) institucion.correo_patologia_critica
      },
      new Parameter()
      {
        Name = "url_wsInstitucion",
        Type = DbType.String,
        Value = (object) institucion.url_wsInstitucion
      }
    }, "sp_Instituciones_Save", "CN_RISPACS");

    public static int Create(InstitucionDomain institucion) => DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "id_institucion",
        Type = DbType.Int32,
        Value = (object) institucion.id_institucion
      },
      new Parameter()
      {
        Name = "nombre",
        Type = DbType.String,
        Value = (object) institucion.nombre
      },
      new Parameter()
      {
        Name = "descripcion",
        Type = DbType.String,
        Value = (object) institucion.descripcion
      },
      new Parameter()
      {
        Name = "estado",
        Type = DbType.Int32,
        Value = (object) institucion.estado
      },
      new Parameter()
      {
        Name = "url_pagina",
        Type = DbType.String,
        Value = (object) institucion.url_pagina
      },
      new Parameter()
      {
        Name = "aetitle",
        Type = DbType.String,
        Value = (object) institucion.aetitle
      },
      new Parameter()
      {
        Name = "url_descarga",
        Type = DbType.String,
        Value = (object) institucion.url_descarga
      },
      new Parameter()
      {
        Name = "url_informe",
        Type = DbType.String,
        Value = (object) institucion.url_informe
      },
      new Parameter()
      {
        Name = "url_base",
        Type = DbType.String,
        Value = (object) institucion.url_base
      },
      new Parameter()
      {
        Name = "id_tipo_conexion",
        Type = DbType.Int32,
        Value = (object) institucion.id_tipo_conexion
      },
      new Parameter()
      {
        Name = "addendum",
        Type = DbType.Int32,
        Value = (object) institucion.addendum
      },
      new Parameter()
      {
        Name = "formulario_unico",
        Type = DbType.Int32,
        Value = (object) institucion.formulario_unico
      },
      new Parameter()
      {
        Name = "url_informe_oit",
        Type = DbType.String,
        Value = (object) institucion.url_informe_oit
      }
    }, "sp_RisWeb_CreateInstitucion", "CN_RISPACS");

    public static InstitucionDomain GetById(int id_institucion)
    {
      List<Parameter> parameters = new List<Parameter>();
      parameters.Add(new Parameter()
      {
        Name = nameof (id_institucion),
        Type = DbType.Int32,
        Value = (object) id_institucion
      });
      InstitucionDomain institucionDomain = new InstitucionDomain();
      return DataBaseProcedure.GetEntidad<InstitucionDomain>(parameters, "sp_institucion_GetById") ?? new InstitucionDomain();
    }

    public static string getURLInforme() => DataBaseProcedure.GetString(new List<Parameter>(), "sp_obtenerConfiguracion", "CN_RISPACS");

    public static InstitucionDomain GetByIdAdmin(int id_institucion)
    {
      List<Parameter> parameters = new List<Parameter>();
      parameters.Add(new Parameter()
      {
        Name = nameof (id_institucion),
        Type = DbType.Int32,
        Value = (object) id_institucion
      });
      InstitucionDomain institucionDomain = new InstitucionDomain();
      return DataBaseProcedure.GetEntidad<InstitucionDomain>(parameters, "sp_institucion_GetByID_Admin") ?? new InstitucionDomain();
    }

    public static InstitucionDomain GetByIdConComentarios(int id_institucion)
    {
      List<Parameter> parameters = new List<Parameter>();
      parameters.Add(new Parameter()
      {
        Name = nameof (id_institucion),
        Type = DbType.Int32,
        Value = (object) id_institucion
      });
      InstitucionDomain institucionDomain = new InstitucionDomain();
      return DataBaseProcedure.GetEntidad<InstitucionDomain>(parameters, "sp_institucion_GetById") ?? new InstitucionDomain();
    }

    public static IList<InstitucionDomain> GetAllFiltro(string filtro) => (IList<InstitucionDomain>) DataBaseProcedure.ListEntidad<InstitucionDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (filtro),
        Type = DbType.String,
        Value = (object) filtro
      }
    }, "sp_institucion_GetAll", "CN_RISPACS");

    public static IList<InstitucionDomain> GetAll() => (IList<InstitucionDomain>) DataBaseProcedure.ListEntidad<InstitucionDomain>(new List<Parameter>(), "sp_institucion_GetAll", "CN_RISPACS");

    public static DataTable GetAllDataTable() => StoredProcedure.EjecutarProcedure(new List<Parameter>(), "sp_institucion_GetAll", "CN_RISPACS");

    public static InstitucionDomain GetByAetitle(string Aetitle)
    {
      List<Parameter> parameters = new List<Parameter>();
      parameters.Add(new Parameter()
      {
        Name = "aetitle",
        Type = DbType.String,
        Value = (object) Aetitle
      });
      InstitucionDomain institucionDomain = new InstitucionDomain();
      return DataBaseProcedure.GetEntidad<InstitucionDomain>(parameters, "sp_institucion_GetByAetitle") ?? new InstitucionDomain();
    }

    public static IList<InstitucionDomain> GetByState(int estado) => (IList<InstitucionDomain>) DataBaseProcedure.ListEntidad<InstitucionDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (estado),
        Type = DbType.Int32,
        Value = (object) estado
      }
    }, "sp_institucion_GetByState", "CN_RISPACS");

    private static InstitucionDomain BuildFunction(IDataReader row) => new InstitucionDomain()
    {
      id_institucion = row["id_institucion"] != DBNull.Value ? (int) row["id_institucion"] : 0,
      nombre = row["nombre"] != DBNull.Value ? (string) row["nombre"] : string.Empty,
      descripcion = row["descripcion"] != DBNull.Value ? (string) row["descripcion"] : string.Empty,
      estado = row["estado"] != DBNull.Value ? (int) row["estado"] : 0,
      url_pagina = row["url_pagina"] != DBNull.Value ? (string) row["url_pagina"] : string.Empty,
      aetitle = row["aetitle"] != DBNull.Value ? (string) row["aetitle"] : string.Empty,
      url_descarga = row["url_descarga"] != DBNull.Value ? (string) row["url_descarga"] : string.Empty,
      url_informe = row["url_informe"] != DBNull.Value ? (string) row["url_informe"] : string.Empty,
      url_base = row["url_base"] != DBNull.Value ? (string) row["url_base"] : string.Empty,
      id_tipo_conexion = row["id_tipo_conexion"] != DBNull.Value ? (int) row["id_tipo_conexion"] : 0,
      addendum = row["addendum"] != DBNull.Value ? (int) row["addendum"] : 0,
      formulario_unico = row["formulario_unico"] != DBNull.Value ? (int) row["formulario_unico"] : 0,
      url_informe_oit = row["url_informe_oit"] != DBNull.Value ? (string) row["url_informe_oit"] : string.Empty,
      estructura = row["estructura"] != DBNull.Value ? (string) row["estructura"] : string.Empty,
      margen_superior = row["margen_superior"] != DBNull.Value ? (int) row["margen_superior"] : 0,
      margen_inferior = row["margen_inferior"] != DBNull.Value ? (int) row["margen_inferior"] : 0,
      margen_izquierda = row["margen_izquierda"] != DBNull.Value ? (int) row["margen_izquierda"] : 0,
      margen_derecha = row["margen_derecha"] != DBNull.Value ? (int) row["margen_derecha"] : 0,
      logo = row["logo"] != DBNull.Value ? (string) row["logo"] : string.Empty,
      codigo_qr = row["codigo_qr"] != DBNull.Value ? (string) row["codigo_qr"] : string.Empty,
      id_tipo_becado = row["id_tipo_becado"] == DBNull.Value ? 1 : (int) row["id_tipo_becado"],
      id_grupo = row["id_grupo"] != DBNull.Value ? (int) row["id_grupo"] : 0,
      flagContingencia = row["flag_Contingencia"] != DBNull.Value ? (int) row["flag_Contingencia"] : 0
    };

    private static InstitucionDomain BuildFunction1(IDataReader row) => new InstitucionDomain()
    {
      id_institucion = row["id_institucion"] != DBNull.Value ? (int) row["id_institucion"] : 0,
      nombre = row["nombre"] != DBNull.Value ? (string) row["nombre"] : string.Empty,
      descripcion = row["descripcion"] != DBNull.Value ? (string) row["descripcion"] : string.Empty,
      estado = row["estado"] != DBNull.Value ? (int) row["estado"] : 0,
      url_pagina = row["url_pagina"] != DBNull.Value ? (string) row["url_pagina"] : string.Empty,
      aetitle = row["aetitle"] != DBNull.Value ? (string) row["aetitle"] : string.Empty,
      url_descarga = row["url_descarga"] != DBNull.Value ? (string) row["url_descarga"] : string.Empty,
      url_informe = row["url_informe"] != DBNull.Value ? (string) row["url_informe"] : string.Empty,
      url_base = row["url_base"] != DBNull.Value ? (string) row["url_base"] : string.Empty,
      id_tipo_conexion = row["id_tipo_conexion"] != DBNull.Value ? (int) row["id_tipo_conexion"] : 0,
      addendum = row["addendum"] != DBNull.Value ? (int) row["addendum"] : 0,
      formulario_unico = row["formulario_unico"] != DBNull.Value ? (int) row["formulario_unico"] : 0,
      url_informe_oit = row["url_informe_oit"] != DBNull.Value ? (string) row["url_informe_oit"] : string.Empty,
      estructura = row["estructura"] != DBNull.Value ? (string) row["estructura"] : string.Empty,
      margen_superior = row["margen_superior"] != DBNull.Value ? (int) row["margen_superior"] : 0,
      margen_inferior = row["margen_inferior"] != DBNull.Value ? (int) row["margen_inferior"] : 0,
      margen_izquierda = row["margen_izquierda"] != DBNull.Value ? (int) row["margen_izquierda"] : 0,
      margen_derecha = row["margen_derecha"] != DBNull.Value ? (int) row["margen_derecha"] : 0,
      logo = row["logo"] != DBNull.Value ? (string) row["logo"] : string.Empty,
      codigo_qr = row["codigo_qr"] != DBNull.Value ? (string) row["codigo_qr"] : string.Empty,
      id_tipo_becado = row["id_tipo_becado"] == DBNull.Value ? 1 : (int) row["id_tipo_becado"],
      id_grupo = row["id_grupo"] != DBNull.Value ? (int) row["id_grupo"] : 0,
      flagObtenerComentarios = row["flagObtenerComentarios"] != DBNull.Value ? (int) row["flagObtenerComentarios"] : 0
    };
  }
}
