// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.InstitucionCredencialesDataAccess
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
  public class InstitucionCredencialesDataAccess
  {
    public static InstitucionCredencialesDomain Login(
      string username,
      string password,
      string aetitle)
    {
      List<Parameter> parameters = new List<Parameter>();
      parameters.Add(new Parameter()
      {
        Name = nameof (username),
        Type = DbType.String,
        Value = (object) username
      });
      parameters.Add(new Parameter()
      {
        Name = nameof (password),
        Type = DbType.String,
        Value = (object) password
      });
      parameters.Add(new Parameter()
      {
        Name = nameof (aetitle),
        Type = DbType.String,
        Value = (object) aetitle
      });
      InstitucionCredencialesDomain credencialesDomain = new InstitucionCredencialesDomain();
      return DataBaseProcedure.GetEntidad<InstitucionCredencialesDomain>(parameters, "sp_InstitucionCredenciales_Login") ?? new InstitucionCredencialesDomain();
    }

    public static InstitucionCredencialesDomain GetById(int id_institucion)
    {
      List<Parameter> parameters = new List<Parameter>();
      parameters.Add(new Parameter()
      {
        Name = nameof (id_institucion),
        Type = DbType.Int32,
        Value = (object) id_institucion
      });
      InstitucionCredencialesDomain credencialesDomain = new InstitucionCredencialesDomain();
      return DataBaseProcedure.GetEntidad<InstitucionCredencialesDomain>(parameters, "sp_InstitucionCredenciales_GetById") ?? new InstitucionCredencialesDomain();
    }

    public static InstitucionCredencialesDomain BasicAuthentication(
      string username,
      string password)
    {
      List<Parameter> parameters = new List<Parameter>();
      parameters.Add(new Parameter()
      {
        Name = nameof (username),
        Type = DbType.Int32,
        Value = (object) username
      });
      parameters.Add(new Parameter()
      {
        Name = nameof (password),
        Type = DbType.Int32,
        Value = (object) password
      });
      InstitucionCredencialesDomain credencialesDomain = new InstitucionCredencialesDomain();
      return DataBaseProcedure.GetEntidad<InstitucionCredencialesDomain>(parameters, "sp_InstitucionCredenciales_BasicAuthentication") ?? new InstitucionCredencialesDomain();
    }

    private static InstitucionCredencialesDomain BuildFunction(IDataReader row) => new InstitucionCredencialesDomain()
    {
      id_institucion_credenciales = row["id_institucion_credenciales"] != DBNull.Value ? (int) row["id_institucion_credenciales"] : 0,
      username = row["username"] != DBNull.Value ? (string) row["username"] : string.Empty,
      password = row["password"] != DBNull.Value ? (string) row["password"] : string.Empty,
      estado = row["estado"] != DBNull.Value ? (int) row["estado"] : 0,
      id_institucion = row["id_institucion"] != DBNull.Value ? (int) row["id_institucion"] : 0
    };
  }
}
