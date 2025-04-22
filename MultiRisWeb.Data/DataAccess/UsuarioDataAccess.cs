// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.UsuarioDataAccess
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
    public class UsuarioDataAccess
    {
        public static long Save(UsuarioDomain usuario) => (long)DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "id_usuario",
        Type = DbType.Int32,
        Value = (object) usuario.id_usuario
      },
      new Parameter()
      {
        Name = "nombre",
        Type = DbType.String,
        Value = (object) usuario.nombre
      },
      new Parameter()
      {
        Name = "apellido_paterno",
        Type = DbType.String,
        Value = (object) usuario.apellido_paterno
      },
      new Parameter()
      {
        Name = "apellido_materno",
        Type = DbType.String,
        Value = (object) usuario.apellido_materno
      },
      new Parameter()
      {
        Name = "estado",
        Type = DbType.Int32,
        Value = (object) usuario.estado
      },
      new Parameter()
      {
        Name = "username",
        Type = DbType.String,
        Value = (object) usuario.username
      },
      new Parameter()
      {
        Name = "password",
        Type = DbType.String,
        Value = (object) usuario.password
      },
      new Parameter()
      {
        Name = "id_perfil",
        Type = DbType.Int32,
        Value = (object) usuario.id_perfil
      },
      new Parameter()
      {
        Name = "rut",
        Type = DbType.String,
        Value = (object) usuario.rut
      },
      new Parameter()
      {
        Name = "email1",
        Type = DbType.String,
        Value = (object) usuario.email1
      },
      new Parameter()
      {
        Name = "email2",
        Type = DbType.String,
        Value = (object) usuario.email2
      },
      new Parameter()
      {
        Name = "telefono1",
        Type = DbType.String,
        Value = (object) usuario.telefono1
      },
      new Parameter()
      {
        Name = "telefono2",
        Type = DbType.String,
        Value = (object) usuario.telefono2
      },
      new Parameter()
      {
        Name = "dias_examenes",
        Type = DbType.Int32,
        Value = (object) usuario.dias_examenes
      },
      new Parameter()
      {
        Name = "vocali",
        Type = DbType.Int32,
        Value = (object) usuario.vocali
      },
      new Parameter()
      {
        Name = "agente_vocali",
        Type = DbType.Int32,
        Value = (object) usuario.agente_vocali
      },
      new Parameter()
      {
        Name = "id_visor",
        Type = DbType.Int32,
        Value = (object) usuario.id_visor
      },
      new Parameter()
      {
        Name = "meddreams_automatico",
        Type = DbType.Int32,
        Value = (object) usuario.meddreams_automatico
      },
      new Parameter()
      {
        Name = "firma",
        Type = DbType.String,
        Value = (object) usuario.firma
      },
      new Parameter()
      {
        Name = "id_usuario_referencia",
        Type = DbType.Int32,
        Value = (object) usuario.id_usuario_referencia
      }
    }, "sp_usuario_Save", "CN_RISPACS");

        public static UsuarioDomain GetById(long id_usuario)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter()
            {
                Name = nameof(id_usuario),
                Type = DbType.Int32,
                Value = (object)id_usuario
            });
            UsuarioDomain usuarioDomain = new UsuarioDomain();
            return DataBaseProcedure.GetEntidad<UsuarioDomain>(parameters, "sp_usuario_GetById", "CN_RISPACS") ?? new UsuarioDomain();
        }

        public static IList<UsuarioDomain> GetAll() => (IList<UsuarioDomain>)DataBaseProcedure.ListEntidad<UsuarioDomain>(new List<Parameter>(), "sp_usuario_GetAll", "CN_RISPACS");

        public static DataTable GetAllUser() => StoredProcedure.EjecutarProcedure(new List<Parameter>(), nameof(GetAllUser), "CN_RISPACS");

        public static DataTable GetAllUserAdmin(string nombre) => StoredProcedure.EjecutarProcedure(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (nombre),
        Type = DbType.String,
        Value = (object) nombre
      }
    }, nameof(GetAllUserAdmin), "CN_RISPACS");

        public static UsuarioDomain GetByTecnologo(string tecnologo)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter()
            {
                Name = "tenologo",
                Type = DbType.String,
                Value = (object)tecnologo
            });
            UsuarioDomain usuarioDomain = new UsuarioDomain();
            return DataBaseProcedure.GetEntidad<UsuarioDomain>(parameters, "sp_usuario_GetByTecnologo", "CN_RISPACS") ?? new UsuarioDomain();
        }

        public static UsuarioDomain Login(string username, string password)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter()
            {
                Name = nameof(username),
                Type = DbType.String,
                Value = (object)username
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(password),
                Type = DbType.String,
                Value = (object)password
            });
            UsuarioDomain usuarioDomain = new UsuarioDomain();
            return DataBaseProcedure.GetEntidad<UsuarioDomain>(parameters, "sp_usuario_Login", "CN_RISPACS") ?? new UsuarioDomain();
        }

        public static IList<UsuarioDomain> GetListByPerfilAndEstate(int id_perfil, int id_estado) => (IList<UsuarioDomain>)DataBaseProcedure.ListEntidad<UsuarioDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (id_perfil),
        Type = DbType.Int32,
        Value = (object) id_perfil
      },
      new Parameter()
      {
        Name = nameof (id_estado),
        Type = DbType.Int32,
        Value = (object) id_estado
      }
    }, "sp_usuario_GetListByPerfilAndEstate", "CN_RISPACS");

        public static DataTable GetLitByUsernameAndIdUsuario(string username, long id_usuario) => StoredProcedure.EjecutarProcedure(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (username),
        Type = DbType.String,
        Value = (object) username
      },
      new Parameter()
      {
        Name = nameof (id_usuario),
        Type = DbType.Int32,
        Value = (object) id_usuario
      }
    }, "sp_usuario_GetLitByUsernameAndIdUsuario", "CN_RISPACS");

        public static DataTable GetTableByPerfilAndEstate(int id_perfil, int id_estado) => StoredProcedure.EjecutarProcedure(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (id_perfil),
        Type = DbType.Int32,
        Value = (object) id_perfil
      },
      new Parameter()
      {
        Name = nameof (id_estado),
        Type = DbType.String,
        Value = (object) id_estado
      }
    }, "sp_usuario_GetTableByPerfilAndEstate", "CN_RISPACS");

        public static UsuarioDomain GetByUsername(string Username)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter()
            {
                Name = "username",
                Type = DbType.String,
                Value = (object)Username
            });
            UsuarioDomain usuarioDomain = new UsuarioDomain();
            return DataBaseProcedure.GetEntidad<UsuarioDomain>(parameters, "sp_usuario_GetByUsername", "CN_RISPACS") ?? new UsuarioDomain();
        }

        public static UsuarioDomain GetUsuarioAddendum(string usuario, int idInstitucion) => DataBaseProcedure.GetEntidad<UsuarioDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "@usuario",
        Type = DbType.String,
        Value = (object) usuario
      },
      new Parameter()
      {
        Name = "@idInstitucion",
        Type = DbType.Int32,
        Value = (object) idInstitucion
      }
    }, "sp_usuario_GetUsuarioAddendum", "CN_RISPACS");

        public static DataTable GetTableByUsername(string Username) => StoredProcedure.EjecutarProcedure(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "username",
        Type = DbType.String,
        Value = (object) Username
      }
    }, "sp_usuario_GetTableByUsername", "CN_RISPACS");


        public static List<UsuarioDomain> Listar()
        {
            return IradDBNet.DataBaseProcedure.ListEntidad<UsuarioDomain>(new List<Parameter>(), "sp_UsuarioListar", "CN_RISPACS");
        }

        public static List<UsuarioDomain> ListarMedicosInformadores()
        {
            return IradDBNet.DataBaseProcedure.ListEntidad<UsuarioDomain>(new List<Parameter>(), "sp_MedicosInformadores", "CN_RISPACS");
        }

        private static UsuarioDomain BuildFunction(IDataReader row) => new UsuarioDomain()
        {
            id_usuario = row["id_usuario"] != DBNull.Value ? (long)row["id_usuario"] : 0L,
            nombre = row["nombre"] != DBNull.Value ? (string)row["nombre"] : string.Empty,
            apellido_paterno = row["apellido_paterno"] != DBNull.Value ? (string)row["apellido_paterno"] : string.Empty,
            apellido_materno = row["apellido_materno"] != DBNull.Value ? (string)row["apellido_materno"] : string.Empty,
            estado = row["estado"] != DBNull.Value ? (int)row["estado"] : 0,
            username = row["username"] != DBNull.Value ? (string)row["username"] : string.Empty,
            password = row["password"] != DBNull.Value ? (string)row["password"] : string.Empty,
            id_perfil = row["id_perfil"] != DBNull.Value ? (int)row["id_perfil"] : 0,
            rut = row["rut"] != DBNull.Value ? (string)row["rut"] : string.Empty,
            email1 = row["email1"] != DBNull.Value ? (string)row["email1"] : string.Empty,
            email2 = row["email2"] != DBNull.Value ? (string)row["email2"] : string.Empty,
            telefono1 = row["telefono1"] != DBNull.Value ? (string)row["telefono1"] : string.Empty,
            telefono2 = row["telefono2"] != DBNull.Value ? (string)row["telefono2"] : string.Empty,
            dias_examenes = row["dias_examenes"] != DBNull.Value ? (int)row["dias_examenes"] : 0,
            vocali = row["vocali"] != DBNull.Value ? (int)row["vocali"] : 0,
            agente_vocali = row["agente_vocali"] != DBNull.Value ? (int)row["agente_vocali"] : 0,
            id_visor = row["id_visor"] != DBNull.Value ? (int)row["id_visor"] : 0,
            meddreams_automatico = row["meddreams_automatico"] != DBNull.Value ? (int)row["meddreams_automatico"] : 0,
            firma = row["firma"] != DBNull.Value ? (string)row["firma"] : string.Empty,
            id_usuario_referencia = row["id_usuario_referencia"] != DBNull.Value ? (int)row["id_usuario_referencia"] : 0
        };
    }
}
