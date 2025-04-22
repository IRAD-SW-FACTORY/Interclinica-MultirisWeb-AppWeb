// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.TagExamenDataAccess
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
  public class TagExamenDataAccess
  {
    public static List<TagExamenDomain> Listar(int tagGeneral, string nombreTag, string usuario) => DataBaseProcedure.ListEntidad<TagExamenDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "@tagGeneral",
        Type = DbType.Int32,
        Value = (object) tagGeneral
      },
      new Parameter()
      {
        Name = "@nombreTag",
        Type = DbType.String,
        Value = (object) nombreTag
      },
      new Parameter()
      {
        Name = "@usuario",
        Type = DbType.String,
        Value = (object) usuario
      }
    }, "spTagExamenListar", "CN_RISPACS");

    public static bool Insertar(TagExamenDomain tagExamen) => DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "@tagGeneral",
        Type = DbType.Int32,
        Value = (object) tagExamen.TagGeneral
      },
      new Parameter()
      {
        Name = "@nombreTag",
        Type = DbType.String,
        Value = (object) tagExamen.Nombre
      },
      new Parameter()
      {
        Name = "@usuario",
        Type = DbType.String,
        Value = (object) tagExamen.Usuario
      },
      new Parameter()
      {
        Name = "@vigente",
        Type = DbType.Int32,
        Value = (object) tagExamen.Vigente
      }
    }, "spTagExamenInsertar", "CN_RISPACS") > 0;

    public static bool Modificar(TagExamenDomain tagExamen) => DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "@id",
        Type = DbType.Int32,
        Value = (object) tagExamen.Id
      },
      new Parameter()
      {
        Name = "@nombreTag",
        Type = DbType.String,
        Value = (object) tagExamen.Nombre
      },
      new Parameter()
      {
        Name = "@usuarioEliminacion",
        Type = DbType.String,
        Value = (object) tagExamen.UsuarioEliminacion
      },
      new Parameter()
      {
        Name = "@vigente",
        Type = DbType.Int32,
        Value = (object) tagExamen.Vigente
      }
    }, "spTagExamenUpdate", "CN_RISPACS") > 0;

    public static TagExamenDomain Get(int id) => DataBaseProcedure.GetEntidad<TagExamenDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "@id",
        Type = DbType.Int32,
        Value = (object) id
      }
    }, "spTagExamenGet", "CN_RISPACS");

    public static List<TagExamenDomain> ListarVigenteUsuario(string usuario) => DataBaseProcedure.ListEntidad<TagExamenDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "@usuario",
        Type = DbType.String,
        Value = (object) usuario
      }
    }, "spTagExamenListarVigenteUsuario", "CN_RISPACS");

    public static List<ExamenTagDomain> ListarExamenesTagProfesional(
      int nroPagina,
      long idInstitucion,
      string modalidad,
      string tipoAtencion,
      string estadoExamen,
      int rangoEtario,
      string idPaciente,
      string nombrePaciente,
      string nroAcceso,
      string usuario,
      DateTime fechaInicio,
      DateTime fechaTermino,
      int tagExamen)
    {
      return DataBaseProcedure.ListEntidad<ExamenTagDomain>(new List<Parameter>()
      {
        new Parameter()
        {
          Name = "@vcPagina",
          Type = DbType.Int32,
          Value = (object) nroPagina
        },
        new Parameter()
        {
          Name = "@idInstitucion",
          Type = DbType.Int64,
          Value = (object) idInstitucion
        },
        new Parameter()
        {
          Name = "@modalidad",
          Type = DbType.String,
          Value = (object) modalidad
        },
        new Parameter()
        {
          Name = "@tipoAtencion",
          Type = DbType.String,
          Value = (object) tipoAtencion
        },
        new Parameter()
        {
          Name = "@estadoExamen",
          Type = DbType.String,
          Value = (object) estadoExamen
        },
        new Parameter()
        {
          Name = "@rangoEtario",
          Type = DbType.Int32,
          Value = (object) rangoEtario
        },
        new Parameter()
        {
          Name = "@idpaciente",
          Type = DbType.String,
          Value = (object) idPaciente
        },
        new Parameter()
        {
          Name = "@nombrePaciente",
          Type = DbType.String,
          Value = (object) nombrePaciente
        },
        new Parameter()
        {
          Name = "@nroAcceso",
          Type = DbType.String,
          Value = (object) nroAcceso
        },
        new Parameter()
        {
          Name = "@usuario",
          Type = DbType.String,
          Value = (object) usuario
        },
        new Parameter()
        {
          Name = "@fechainicio",
          Type = DbType.DateTime,
          Value = (object) fechaInicio
        },
        new Parameter()
        {
          Name = "@fechaTermino",
          Type = DbType.DateTime,
          Value = (object) fechaTermino
        },
        new Parameter()
        {
          Name = "@tagExamen",
          Type = DbType.Int32,
          Value = (object) tagExamen
        }
      }, "spListarExamenTag", "CN_RISPACS");
    }

    public static List<TagExamenVerInformeDomain> ListarInformes(long id) => DataBaseProcedure.ListEntidad<TagExamenVerInformeDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "@id",
        Type = DbType.Int64,
        Value = (object) id
      }
    }, "spTagExamenDatoInforme", "CN_RISPACS");

    public static List<TagExamenListarDomain> ListarExamenTag(string codExamen) => DataBaseProcedure.ListEntidad<TagExamenListarDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "@codExamen",
        Type = DbType.String,
        Value = (object) codExamen
      }
    }, "spExamenTagListar", "CN_RISPACS");

    public static List<TagExamenListarDomain> ObtieneExamenTag(string codExamen, int tagExamen) => DataBaseProcedure.ListEntidad<TagExamenListarDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "@CODEXAMEN",
        Type = DbType.String,
        Value = (object) codExamen
      },
      new Parameter()
      {
        Name = "@TAGID",
        Type = DbType.Int32,
        Value = (object) tagExamen
      }
    }, "sp_ObtieneTagsPorExamen", "CN_RISPACS");
  }
}
