// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.UsuarioInstitucionDataAccess
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
  public class UsuarioInstitucionDataAccess
  {
    public static long Save(UsuarioInstitucionDomain usuarioInstitucion) => (long) DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "id_usuario_institucion",
        Type = DbType.Int32,
        Value = (object) usuarioInstitucion.id_usuario_institucion
      },
      new Parameter()
      {
        Name = "id_usuario",
        Type = DbType.Int32,
        Value = (object) usuarioInstitucion.id_usuario
      },
      new Parameter()
      {
        Name = "id_institucion",
        Type = DbType.Int32,
        Value = (object) usuarioInstitucion.id_institucion
      },
      new Parameter()
      {
        Name = "id_tipo_firma",
        Type = DbType.Int32,
        Value = (object) usuarioInstitucion.id_tipo_firma
      }
    }, "sp_UsuarioInstitucion_Save", "CN_RISPACS");

    public static DataTable ListAll() => StoredProcedure.EjecutarProcedure(new List<Parameter>(), "sp_UsuarioInstitucion_ListAll", "CN_RISPACS");

    public static DataTable ListByUser(long id_usuario) => StoredProcedure.EjecutarProcedure(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (id_usuario),
        Type = DbType.Int32,
        Value = (object) id_usuario
      }
    }, "sp_UsuarioInstitucion_ListByUser", "CN_RISPACS");

    public static DataTable ListByUserAndInstActive(long id_usuario) => StoredProcedure.EjecutarProcedure(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (id_usuario),
        Type = DbType.Int32,
        Value = (object) id_usuario
      }
    }, "sp_UsuarioInstitucion_ListByUserAndInstActive", "CN_RISPACS");

    public static UsuarioInstitucionDomain GetByUserAndInst(long id_usuario, int id_institucion)
    {
      List<Parameter> parameters = new List<Parameter>();
      parameters.Add(new Parameter()
      {
        Name = nameof (id_usuario),
        Type = DbType.Int32,
        Value = (object) id_usuario
      });
      parameters.Add(new Parameter()
      {
        Name = nameof (id_institucion),
        Type = DbType.Int32,
        Value = (object) id_institucion
      });
      UsuarioInstitucionDomain institucionDomain = new UsuarioInstitucionDomain();
      return DataBaseProcedure.GetEntidad<UsuarioInstitucionDomain>(parameters, "sp_UsuarioInstitucion_GetByUserAndInst", "CN_RISPACS") ?? new UsuarioInstitucionDomain();
    }

        public static List<UsuarioInstitucionDomain> ListarUsuarioInstitucion(string usuario)
        {
            List<Parameter> parameters = new List<Parameter>();
      
            parameters.Add(new Parameter() { Name = "username", Type = DbType.String, Value = (object) usuario });
            UsuarioInstitucionDomain institucionDomain = new UsuarioInstitucionDomain();
      
            return DataBaseProcedure.ListEntidad<UsuarioInstitucionDomain>(parameters, "spListInstitucionesUsuario", "CN_RISPACS");
        }

        public static List<UsuarioInstitucionDomain> Get(string username)
        {
            List<Parameter> parameters = new List<Parameter>(); 

            parameters.Add(new Parameter() { Name = "username", Type = DbType.String, Value = username });

            UsuarioInstitucionDomain institucionDomain = new UsuarioInstitucionDomain();

            return DataBaseProcedure.ListEntidad<UsuarioInstitucionDomain>(parameters, "SP_SOLADDEMDUM_LISTARINST_CRM", "CN_RISPACS");
        }

        //

        public static int DeleteByIdUser(long id_usuario) => DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (id_usuario),
        Type = DbType.Int32,
        Value = (object) id_usuario
      }
    }, "sp_UsuarioInstitucion_DeleteByIdUser", "CN_RISPACS");

    private static UsuarioInstitucionDomain BuildFunction(IDataReader row) => new UsuarioInstitucionDomain()
    {
      id_usuario_institucion = row["id_usuario"] != DBNull.Value ? (long) row["id_usuario"] : 0L,
      id_usuario = row["id_usuario"] != DBNull.Value ? (long) row["id_usuario"] : 0L,
      id_institucion = row["id_institucion"] != DBNull.Value ? (int) row["id_institucion"] : 0,
      id_tipo_firma = row["id_tipo_firma"] != DBNull.Value ? (int) row["id_tipo_firma"] : 3
    };
  }
}
