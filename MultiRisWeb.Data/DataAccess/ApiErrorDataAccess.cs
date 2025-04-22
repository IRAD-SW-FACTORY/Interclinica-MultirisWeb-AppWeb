// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.ApiErrorDataAccess
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
  public class ApiErrorDataAccess
  {
    public static long Save(ApiErrorDomain error) => (long) DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "id_api_error",
        Type = DbType.Int32,
        Value = (object) error.id_api_error
      },
      new Parameter()
      {
        Name = "staktrace",
        Type = DbType.String,
        Value = (object) error.staktrace
      },
      new Parameter()
      {
        Name = "id_institucion",
        Type = DbType.Int32,
        Value = (object) error.id_institucion
      }
    }, "sp_ApiError_Save", "CN_RISPACS");

    private static ApiErrorDomain BuildFunction(IDataReader row) => new ApiErrorDomain()
    {
      id_api_error = row["id_api_error"] != DBNull.Value ? (long) row["id_api_error"] : 0L,
      staktrace = row["staktrace"] != DBNull.Value ? (string) row["staktrace"] : string.Empty,
      id_institucion = row["id_institucion"] != DBNull.Value ? (int) row["id_institucion"] : 0
    };
  }
}
