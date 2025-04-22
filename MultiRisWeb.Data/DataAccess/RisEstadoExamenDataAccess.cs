// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.RisEstadoExamenDataAccess
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
    public class RisEstadoExamenDataAccess
    {
        public static RisEstadoExamenDomain GetById(int id_estado)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter()
            {
                Name = nameof(id_estado),
                Type = DbType.Int32,
                Value = (object)id_estado
            });
            RisEstadoExamenDomain estadoExamenDomain = new RisEstadoExamenDomain();
            return DataBaseProcedure.GetEntidad<RisEstadoExamenDomain>(parameters, "sp_RisEstadoExamen_GetById", "CN_RISPACS") ?? new RisEstadoExamenDomain();
        }

        public static DataTable ListarTodo() => StoredProcedure.EjecutarProcedure(new List<Parameter>(), "sp_RisEstadoExamen_ListarTodo", "CN_RISPACS");

        public static List<RisEstadoExamenDomain> ListarTodoEntidad() => IradDBNet.DataBaseProcedure.ListEntidad<RisEstadoExamenDomain>(new List<Parameter>(), "sp_RisEstadoExamen_ListarTodo", "CN_RISPACS");

        private static RisEstadoExamenDomain BuildFunction(IDataReader fila) => new RisEstadoExamenDomain()
        {
            id_estado_examen = fila["id_estado_examen"] != DBNull.Value ? Convert.ToInt32(fila["id_estado_examen"]) : 0,
            nombre = fila["nombre"] != DBNull.Value ? fila["nombre"].ToString() : string.Empty,
            codigo = fila["codigo"] != DBNull.Value ? fila["codigo"].ToString() : string.Empty
        };
    }
}
