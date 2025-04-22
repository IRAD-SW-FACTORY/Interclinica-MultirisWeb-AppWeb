// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.RisEstadoInformeDataAccess
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
  public class RisEstadoInformeDataAccess
  {
    public static RisEstadoInformeDomain GetById(int id_estado)
    {
      List<Parameter> parameters = new List<Parameter>();
      parameters.Add(new Parameter()
      {
        Name = nameof (id_estado),
        Type = DbType.Int32,
        Value = (object) id_estado
      });
      RisEstadoInformeDomain estadoInformeDomain = new RisEstadoInformeDomain();
      return DataBaseProcedure.GetEntidad<RisEstadoInformeDomain>(parameters, "sp_RisEstadoInforme_GetById", "CN_RISPACS") ?? new RisEstadoInformeDomain();
    }

    public static DataTable ListarTodo() => StoredProcedure.EjecutarProcedure(new List<Parameter>(), "sp_RisEstadoInforme_ListarTodo", "CN_RISPACS");

    public static List<RisEstadoExamenDomain> Listar() => DataBaseProcedure.ListEntidad<RisEstadoExamenDomain>(new List<Parameter>(), "sp_RisEstadoInforme_ListarTodo", "CN_RISPACS");

    private static RisEstadoInformeDomain BuildFunction(IDataReader fila) => new RisEstadoInformeDomain()
    {
      id_estado_informe = fila["id_estado_informe"] != DBNull.Value ? Convert.ToInt32(fila["id_estado_informe"]) : 0,
      nombre = fila["nombre"] != DBNull.Value ? fila["nombre"].ToString() : string.Empty,
      codigo = fila["codigo"] != DBNull.Value ? fila["codigo"].ToString() : string.Empty
    };
  }
}
