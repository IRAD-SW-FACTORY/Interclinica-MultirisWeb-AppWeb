// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.VocaliDataAccess
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
  public class VocaliDataAccess
  {
    public static VocaliDomain GetById(int id_vocali)
    {
      List<Parameter> parameters = new List<Parameter>();
      parameters.Add(new Parameter()
      {
        Name = nameof (id_vocali),
        Type = DbType.Int32,
        Value = (object) id_vocali
      });
      VocaliDomain vocaliDomain = new VocaliDomain();
      return DataBaseProcedure.GetEntidad<VocaliDomain>(parameters, "sp_Vocali_GetById", "CN_RISPACS") ?? new VocaliDomain();
    }

    private static VocaliDomain BuildFunction(IDataReader row) => new VocaliDomain()
    {
      id_vocali = row["id_vocali"] != DBNull.Value ? (int) row["id_vocali"] : 0,
      puerto = row["puerto"] != DBNull.Value ? (int) row["puerto"] : 0,
      direccion_url = row["direccion_url"] != DBNull.Value ? (string) row["direccion_url"] : string.Empty,
      estado = row["estado"] != DBNull.Value ? (int) row["estado"] : 0
    };
  }
}
