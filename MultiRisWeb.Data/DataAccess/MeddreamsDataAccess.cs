// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.MeddreamsDataAccess
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
  public class MeddreamsDataAccess
  {
    public static MeddreamsDomain GetByIdInstitucion(int id_institucion)
    {
      List<Parameter> parameters = new List<Parameter>();
      parameters.Add(new Parameter()
      {
        Name = nameof (id_institucion),
        Type = DbType.Int32,
        Value = (object) id_institucion
      });
      MeddreamsDomain meddreamsDomain = new MeddreamsDomain();
      return DataBaseProcedure.GetEntidad<MeddreamsDomain>(parameters, "sp_meddreams_GetByIdInstitucion", "CN_RISPACS") ?? new MeddreamsDomain();
    }

    private static MeddreamsDomain BuildFunction(IDataReader row) => new MeddreamsDomain()
    {
      id_meddreams = row["id_meddreams"] != DBNull.Value ? (int) row["id_meddreams"] : 0,
      id_institucion = row["id_institucion"] != DBNull.Value ? (int) row["id_institucion"] : 0,
      url = row["url"] != DBNull.Value ? (string) row["url"] : string.Empty,
      json = row["json"] != DBNull.Value ? (string) row["json"] : string.Empty,
      method = row["method"] != DBNull.Value ? (string) row["method"] : string.Empty,
      id_estado = row["id_estado"] != DBNull.Value ? (int) row["id_estado"] : 0
    };
  }
}
