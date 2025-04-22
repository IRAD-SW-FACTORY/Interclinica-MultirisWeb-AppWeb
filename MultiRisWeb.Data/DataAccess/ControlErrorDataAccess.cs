// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.ControlErrorDataAccess
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
  public class ControlErrorDataAccess
  {
    public static DataTable Listar() => StoredProcedure.EjecutarProcedure(new List<Parameter>(), "sp_TipoUrgencia_ListarTodo", "CN_RISPACS");

    public static void ControlErrorSave(
      int Numero,
      string DescripcionError,
      string Descripcion,
      int Modulo,
      string evento,
      int id_usuario)
    {
      StoredProcedure.EjecutarProcedure(new List<Parameter>()
      {
        new Parameter()
        {
          Name = nameof (Numero),
          Type = DbType.Int32,
          Value = (object) Numero
        },
        new Parameter()
        {
          Name = nameof (DescripcionError),
          Type = DbType.String,
          Value = (object) DescripcionError
        },
        new Parameter()
        {
          Name = nameof (Descripcion),
          Type = DbType.String,
          Value = (object) Descripcion
        },
        new Parameter()
        {
          Name = nameof (Modulo),
          Type = DbType.Int32,
          Value = (object) Modulo
        },
        new Parameter()
        {
          Name = nameof (evento),
          Type = DbType.String,
          Value = (object) evento
        },
        new Parameter()
        {
          Name = nameof (id_usuario),
          Type = DbType.Int32,
          Value = (object) id_usuario
        }
      }, "sp_Error_Save", "CN_RISPACS");
    }

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
      return DataBaseProcedure.GetEntidad<TipoUrgenciaDomain>(parameters, "sp_TipoUrgencia_GetByCod", "CN_RISPACS") ?? new TipoUrgenciaDomain();
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
