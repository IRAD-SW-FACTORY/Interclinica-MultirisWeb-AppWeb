// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.RisDatoDataAccess
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
  public class RisDatoDataAccess
  {
    public static long Save(RisDatoDomain ris_dato) => (long) DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "id_dato",
        Type = DbType.Int32,
        Value = (object) ris_dato.id_dato
      },
      new Parameter()
      {
        Name = "nombre",
        Type = DbType.Int32,
        Value = (object) ris_dato.nombre
      }
    }, "sp_RisDato_Save", "CN_RISPACS");

    public static RisDatoDomain GetById(long id)
    {
      List<Parameter> parameters = new List<Parameter>();
      parameters.Add(new Parameter()
      {
        Name = "id_dato",
        Type = DbType.Int32,
        Value = (object) id
      });
      RisDatoDomain risDatoDomain = new RisDatoDomain();
      return DataBaseProcedure.GetEntidad<RisDatoDomain>(parameters, "sp_RisDato_GetById", "CN_RISPACS") ?? new RisDatoDomain();
    }

    private static RisDatoDomain BuildFunction(IDataReader row) => new RisDatoDomain()
    {
      id_dato = row["id_dato"] != DBNull.Value ? (int) row["id_dato"] : 0,
      nombre = row["nombre"] != DBNull.Value ? (string) row["nombre"] : string.Empty
    };
  }
}
