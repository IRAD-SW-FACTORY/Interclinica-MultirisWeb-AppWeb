// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.TipoUrgenciaDataAccess
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
  public class TipoUrgenciaDataAccess
  {
    public static DataTable Listar() => StoredProcedure.EjecutarProcedure(new List<Parameter>(), "sp_TipoUrgencia_ListarTodo", "CN_RISPACS");

    public static DataTable ListarPorEstado(int estado) => StoredProcedure.EjecutarProcedure(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (estado),
        Type = DbType.Int32,
        Value = (object) estado
      }
    }, "sp_TipoUrgencia_ListarPorEstado_CRM", "CN_RISPACS");

    public static List<TipoUrgenciaDomain> Listar(int estado) => DataBaseProcedure.ListEntidad<TipoUrgenciaDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (estado),
        Type = DbType.Int32,
        Value = (object) estado
      }
    }, "sp_TipoUrgencia_ListarPorEstado", "CN_RISPACS");

    public static TipoUrgenciaDomain GetByCod(string codigo)
    {
      List<Parameter> parameters = new List<Parameter>();
      parameters.Add(new Parameter()
      {
        Name = nameof (codigo),
        Type = DbType.String,
        Value = (object) codigo
      });
      TipoUrgenciaDomain tipoUrgenciaDomain = new TipoUrgenciaDomain();
      return DataBaseProcedure.GetEntidad<TipoUrgenciaDomain>(parameters, "sp_TipoUrgencia_GetByCod") ?? new TipoUrgenciaDomain();
    }

    private static TipoUrgenciaDomain BuildFunction(IDataReader fila) => new TipoUrgenciaDomain()
    {
      id_tipo_urgencia = fila["id_tipo_urgencia"] != DBNull.Value ? Convert.ToInt32(fila["id_tipo_urgencia"]) : 0,
      nombre = fila["nombre"] != DBNull.Value ? fila["nombre"].ToString() : string.Empty,
      descripcion = fila["descripcion"] != DBNull.Value ? fila["descripcion"].ToString() : string.Empty,
      estado = fila["estado"] != DBNull.Value ? Convert.ToInt32(fila["estado"]) : 0,
      minutos_entrega = fila["minutos_entrega"] != DBNull.Value ? Convert.ToInt32(fila["minutos_entrega"]) : 0
    };
  }
}
