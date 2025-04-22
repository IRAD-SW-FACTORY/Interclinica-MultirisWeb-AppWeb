// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.ConfiguracionGeneralDataAccess
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
  public class ConfiguracionGeneralDataAccess
  {
    public static ConfiguracionGeneralDomain GetById(long id_configuracion_general)
    {
      List<Parameter> parameters = new List<Parameter>();
      parameters.Add(new Parameter()
      {
        Name = nameof (id_configuracion_general),
        Type = DbType.String,
        Value = (object) id_configuracion_general
      });
      ConfiguracionGeneralDomain configuracionGeneralDomain = new ConfiguracionGeneralDomain();
      return DataBaseProcedure.GetEntidad<ConfiguracionGeneralDomain>(parameters, "sp_ConfiguracionGeneral_GetById", "CN_RISPACS") ?? new ConfiguracionGeneralDomain();
    }

    private static ConfiguracionGeneralDomain BuildFunction(IDataReader row) => new ConfiguracionGeneralDomain()
    {
      id_configuracion_general = row["id_configuracion_general"] != DBNull.Value ? (long) row["id_configuracion_general"] : 0L,
      nombre = row["nombre"] != DBNull.Value ? (string) row["nombre"] : string.Empty,
      descripcion = row["descripcion"] != DBNull.Value ? (string) row["descripcion"] : string.Empty,
      estado = row["estado"] != DBNull.Value ? (int) row["estado"] : 0,
      valor1 = row["valor1"] != DBNull.Value ? (string) row["valor1"] : string.Empty,
      valor2 = row["valor2"] != DBNull.Value ? (string) row["valor2"] : string.Empty
    };
  }
}
