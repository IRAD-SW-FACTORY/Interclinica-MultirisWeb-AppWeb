// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.AutenticacionDataAccess
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
  public class AutenticacionDataAccess
  {
    public static AutenticacionDomain Get(long idUsuario) => DataBaseProcedure.GetEntidad<AutenticacionDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "@idUsuario",
        Type = DbType.Int64,
        Value = (object) idUsuario
      }
    }, "sp_AutenticacionValidar", "CN_RISPACS");

    public static AutenticacionDomain Validar(long idUsuario, int codigo) => DataBaseProcedure.GetEntidad<AutenticacionDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "@idUsuario",
        Type = DbType.Int64,
        Value = (object) idUsuario
      },
      new Parameter()
      {
        Name = "@codigo",
        Type = DbType.Int32,
        Value = (object) codigo
      }
    }, "sp_AutenticacionValidarCodigo", "CN_RISPACS");

    public static bool InsertOrUpdate(AutenticacionDomain autenticacion) => DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "@idUsuario",
        Type = DbType.Int64,
        Value = (object) autenticacion.IdUsuario
      },
      new Parameter()
      {
        Name = "@codigo",
        Type = DbType.Int32,
        Value = (object) autenticacion.Codigo
      },
      new Parameter()
      {
        Name = "@userAgent",
        Type = DbType.String,
        Value = (object) autenticacion.UserAgent
      }
    }, "sp_AutenticacionInsertOrUpdate", "CN_RISPACS") > 0;

    public static bool Update(long idUsuario) => DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "@idUsuario",
        Type = DbType.Int64,
        Value = (object) idUsuario
      }
    }, "sp_AutenticacionUpdate", "CN_RISPACS") > 0;

    public static bool UpdateClaveAcceso(
      long idUsuario,
      string pass,
      DateTime fechaProxModificacion)
    {
      return DataBaseProcedure.GetInt(new List<Parameter>()
      {
        new Parameter()
        {
          Name = "@idUsuario",
          Type = DbType.Int64,
          Value = (object) idUsuario
        },
        new Parameter()
        {
          Name = "@pass",
          Type = DbType.String,
          Value = (object) pass
        },
        new Parameter()
        {
          Name = "@fechaUpdateClave",
          Type = DbType.DateTime,
          Value = (object) fechaProxModificacion
        }
      }, "sp_Update_Clave_Acceso", "CN_RISPACS") > 0;
    }
  }
}
