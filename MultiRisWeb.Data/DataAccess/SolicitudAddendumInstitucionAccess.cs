// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.SolicitudAddendumInstitucionAccess
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using IradDBNet;
using IradDBNet.Dto;
using MultiRisWeb.Data.Domain;
using System.Collections.Generic;
using System.Data;

namespace MultiRisWeb.Data.DataAccess
{
  public class SolicitudAddendumInstitucionAccess
  {
    public static bool Insertar(SolicitudAddendumInstitucionDomain solicitud) => DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "@usuario",
        Type = DbType.String,
        Value = (object) solicitud.Usuario
      },
      new Parameter()
      {
        Name = "@usuarioMail",
        Type = DbType.String,
        Value = (object) solicitud.UsuarioMail
      },
      new Parameter()
      {
        Name = "@usuarioInstitucion",
        Type = DbType.Int32,
        Value = (object) solicitud.UsuarioInstitucion
      },
      new Parameter()
      {
        Name = "@idExamen",
        Type = DbType.Int64,
        Value = (object) solicitud.IdRisExamen
      },
      new Parameter()
      {
        Name = "@detalle",
        Type = DbType.String,
        Value = (object) solicitud.Detalle
      },
      new Parameter()
      {
        Name = "@tipoSolicitud",
        Type = DbType.Int32,
        Value = (object) solicitud.TipoSolicitud
      },
      new Parameter()
      {
        Name = "@adjunto",
        Type = DbType.String,
        Value = (object) solicitud.Adjunto
      }
    }, "sp_SolAddemdum_Insert", "CN_RISPACS") > 0;

    public static bool Update(int id, int idEstado, string sComentario) => DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "@id",
        Type = DbType.Int32,
        Value = (object) id
      },
      new Parameter()
      {
        Name = "@idEstado",
        Type = DbType.Int32,
        Value = (object) idEstado
      },
      new Parameter()
      {
        Name = "@comentario",
        Type = DbType.String,
        Value = (object) sComentario
      }
    }, "sp_SolAddemdum_Update", "CN_RISPACS") > 0;

    public static bool Delete(int id) => DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "@id",
        Type = DbType.Int32,
        Value = (object) id
      }
    }, "sp_SolAddemdum_Delete", "CN_RISPACS") > 0;

    public static List<SolicitudAddendumInstitucionDomain> Listar(int idInstitucion, int idEstado) => DataBaseProcedure.ListEntidad<SolicitudAddendumInstitucionDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "@idInstitucion",
        Type = DbType.Int32,
        Value = (object) idInstitucion
      },
      new Parameter()
      {
        Name = "@idEstadolSol",
        Type = DbType.String,
        Value = (object) idEstado
      }
    }, "sp_SolAddemdum_listar", "CN_RISPACS");

    public static SolicitudAddendumInstitucionDomain Detalle(int id) => DataBaseProcedure.GetEntidad<SolicitudAddendumInstitucionDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "@id",
        Type = DbType.Int32,
        Value = (object) id
      }
    }, "sp_SolAddemdum_Detalle", "CN_RISPACS");

    public static List<SolicitudAddendumInstitucionDomain> Instituciones() => DataBaseProcedure.ListEntidad<SolicitudAddendumInstitucionDomain>(new List<Parameter>(), "sp_SolAddemdum_listarInst", "CN_RISPACS");

    public static List<SolicitudAddendumInstitucionDomain> ListarSolicitudAdd(int idInstitucion, int idEstado, int idPerfil, string usuario, int idUsuarioValidador)
    {
      if (idPerfil == 3)
        idEstado = 2;
      return DataBaseProcedure.ListEntidad<SolicitudAddendumInstitucionDomain>(new List<Parameter>()
      {
        new Parameter()
        {
          Name = "@idInstitucion",
          Type = DbType.Int32,
          Value = (object) idInstitucion
        },
        new Parameter()
        {
          Name = "@idEstadolSol",
          Type = DbType.Int32,
          Value = (object) idEstado
        },
        new Parameter()
        {
          Name = "@idPerfil",
          Type = DbType.Int32,
          Value = (object) idPerfil
        },
        new Parameter()
        {
          Name = "@idUsuarioInformador",
          Type = DbType.Int32,
          Value = (object) idUsuarioValidador
        },
        new Parameter()
        {
          Name = "@username",
          Type = DbType.String,
          Value = (object) usuario
        }
      }, "sp_SolAddemdum_listarv2", "CN_RISPACS");
    }

    public static SolicitudAddendumInstitucionDomain GetById(long IdExamen, int IdSolicitud)
    {
      List<Parameter> parameters = new List<Parameter>();
      parameters.Add(new Parameter()
      {
        Name = "@IdExamen",
        Type = DbType.Int32,
        Value = (object) IdExamen
      });
      parameters.Add(new Parameter()
      {
        Name = "@IdSolicitud",
        Type = DbType.Int32,
        Value = (object) IdSolicitud
      });
      SolicitudAddendumInstitucionDomain institucionDomain = new SolicitudAddendumInstitucionDomain();
      SolicitudAddendumInstitucionDomain byId = DataBaseProcedure.GetEntidad<SolicitudAddendumInstitucionDomain>(parameters, "sp_SolicitudAddendum_GetByIdExamen", "CN_RISPACS");
      if (byId == null)
      {
        byId = new SolicitudAddendumInstitucionDomain();
        byId.TipoSolicitud = 0;
        byId.Detalle = "";
        byId.estado = "Nueva";
        byId.EstadoSolicitudAdedemdum = 0;
      }
      return byId;
    }

    public static int Nuevas(int idPerfil, string usuario) => DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "@idPerfil",
        Type = DbType.Int32,
        Value = (object) idPerfil
      },
      new Parameter()
      {
        Name = "@username",
        Type = DbType.String,
        Value = (object) usuario
      }
    }, "sp_SolAddemdum_nuevas", "CN_RISPACS");

    public static bool UpdateFinalizacion(long idExamen) => DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "@id_ris_examen",
        Type = DbType.Int32,
        Value = (object) idExamen
      }
    }, "sp_RisAddendumSolicitud_Save", "CN_RISPACS") > 0;

    public static SolicitudAddendumInstitucionDomain GetByIdExa(long IdExamen)
    {
      List<Parameter> parameters = new List<Parameter>();
      parameters.Add(new Parameter()
      {
        Name = "@IdExamen",
        Type = DbType.Int32,
        Value = (object) IdExamen
      });
      SolicitudAddendumInstitucionDomain institucionDomain = new SolicitudAddendumInstitucionDomain();
      SolicitudAddendumInstitucionDomain byIdExa = DataBaseProcedure.GetEntidad<SolicitudAddendumInstitucionDomain>(parameters, "sp_SolicitudAddendum_GetByIdExamenProc", "CN_RISPACS");
      if (byIdExa == null)
      {
        byIdExa = new SolicitudAddendumInstitucionDomain();
        byIdExa.TipoSolicitud = 0;
        byIdExa.Detalle = "";
        byIdExa.estado = "Nueva";
        byIdExa.EstadoSolicitudAdedemdum = 0;
      }
      return byIdExa;
    }

        public static List<SolicitudAddendumInstitucionDomain> ListaSolicitudes(int idInstitucion, int idEstado, int idPerfil, string usuario)
        {
            if (idPerfil == 3) idEstado = 2;
              
            return DataBaseProcedure.ListEntidad<SolicitudAddendumInstitucionDomain>(new List<Parameter>() {
                new Parameter() { Name = "@idInstitucion", Type = DbType.Int32, Value = (object) idInstitucion },
                new Parameter() { Name = "@idEstadolSol", Type = DbType.Int32, Value = (object) idEstado },
                new Parameter() { Name = "@idPerfil", Type = DbType.Int32, Value = (object) idPerfil },
                new Parameter() { Name = "@username", Type = DbType.String, Value = (object) usuario }
            }, "sp_SolAddemdum_listarv2", "CN_RISPACS");
        }
    }
}
