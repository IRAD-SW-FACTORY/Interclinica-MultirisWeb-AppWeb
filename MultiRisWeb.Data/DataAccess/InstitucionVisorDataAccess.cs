// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.InstitucionVisorDataAccess
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
  public class InstitucionVisorDataAccess
  {
    public static InstitucionVisorDomain GetAllForInstitucionAndVisor(
      int id_institucion,
      int id_visor)
    {
      InstitucionVisorDomain institucionVisorDomain = new InstitucionVisorDomain();
      return DataBaseProcedure.GetEntidad<InstitucionVisorDomain>(new List<Parameter>()
      {
        new Parameter()
        {
          Name = nameof (id_institucion),
          Type = DbType.Int32,
          Value = (object) id_institucion
        },
        new Parameter()
        {
          Name = nameof (id_visor),
          Type = DbType.Int32,
          Value = (object) id_visor
        }
      }, "sp_InstitucionVisor_GetAllForInstitucionAndVisor", "CN_RISPACS") ?? new InstitucionVisorDomain();
    }

    private static InstitucionVisorDomain BuildFunction(IDataReader row) => new InstitucionVisorDomain()
    {
      id_institucion_visor = row["id_institucion_visor"] != DBNull.Value ? (int) row["id_institucion_visor"] : 0,
      id_visor = row["id_visor"] != DBNull.Value ? (int) row["id_visor"] : 0,
      id_institucion = row["id_institucion"] != DBNull.Value ? (int) row["id_institucion"] : 0,
      url = row["url"] != DBNull.Value ? (string) row["url"] : string.Empty,
      id_estado = row["id_estado"] != DBNull.Value ? (int) row["id_estado"] : 0
    };
  }
}
