// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.TipoInformeDataAccess
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
  public class TipoInformeDataAccess
  {
    public static TipoInformeDomain GetById(int id_tipo_informe)
    {
      List<Parameter> parameters = new List<Parameter>();
      parameters.Add(new Parameter()
      {
        Name = nameof (id_tipo_informe),
        Type = DbType.String,
        Value = (object) id_tipo_informe
      });
      TipoInformeDomain tipoInformeDomain = new TipoInformeDomain();
      return DataBaseProcedure.GetEntidad<TipoInformeDomain>(parameters, "sp_TipoInforme_GetById") ?? new TipoInformeDomain();
    }

    private static TipoInformeDomain BuildFunction(IDataReader row) => new TipoInformeDomain()
    {
      id_tipo_informe = row["id_tipo_informe"] != DBNull.Value ? (int) row["id_tipo_informe"] : 0,
      nombre = row["nombre"] != DBNull.Value ? (string) row["nombre"] : string.Empty,
      descripcion = row["descripcion"] != DBNull.Value ? (string) row["descripcion"] : string.Empty
    };
  }
}
