// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.ModalidadDataAccess
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
  public class ModalidadDataAccess
  {
    public static DataTable Listar() => StoredProcedure.EjecutarProcedure(new List<Parameter>(), "sp_Modalidad_ListarAll", "CN_RISPACS");

    public static DataTable ListarPorEstado(int estado) => StoredProcedure.EjecutarProcedure(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (estado),
        Type = DbType.Int32,
        Value = (object) estado
      }
    }, "sp_Modalidad_ListarPorEstado", "CN_RISPACS");

    public static List<ModalidadDomain> Listar(int estado) => DataBaseProcedure.ListEntidad<ModalidadDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (estado),
        Type = DbType.Int32,
        Value = (object) estado
      }
    }, "sp_Modalidad_ListarPorEstado", "CN_RISPACS");

    public static ModalidadDomain GetByID(int id_modalidad)
    {
      List<Parameter> parameters = new List<Parameter>();
      parameters.Add(new Parameter()
      {
        Name = nameof (id_modalidad),
        Type = DbType.Int32,
        Value = (object) id_modalidad
      });
      ModalidadDomain modalidadDomain = new ModalidadDomain();
      return DataBaseProcedure.GetEntidad<ModalidadDomain>(parameters, "sp_Modalidad_GetByID", "CN_RISPACS") ?? new ModalidadDomain();
    }

    public static ModalidadDomain GetByName(string nombre)
    {
      List<Parameter> parameters = new List<Parameter>();
      parameters.Add(new Parameter()
      {
        Name = nameof (nombre),
        Type = DbType.String,
        Value = (object) nombre
      });
      ModalidadDomain modalidadDomain = new ModalidadDomain();
      return DataBaseProcedure.GetEntidad<ModalidadDomain>(parameters, "sp_Modalidad_GetByName", "CN_RISPACS") ?? new ModalidadDomain();
    }

    private static ModalidadDomain BuildFunction(IDataReader fila) => new ModalidadDomain()
    {
      id_modalidad = fila["id_modalidad"] != DBNull.Value ? Convert.ToInt32(fila["id_modalidad"]) : 0,
      nombre = fila["nombre"] != DBNull.Value ? fila["nombre"].ToString() : string.Empty,
      descripcion = fila["descripcion"] != DBNull.Value ? fila["descripcion"].ToString() : string.Empty,
      estado = fila["estado"] != DBNull.Value ? Convert.ToInt32(fila["estado"]) : 0
    };
  }
}
