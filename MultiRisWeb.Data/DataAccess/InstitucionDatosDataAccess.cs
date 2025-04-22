// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.InstitucionDatosDataAccess
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
    public class InstitucionDatosDataAccess
    {
        public static List<InstitucionDomain> Listar()
        {
            List<Parameter> parameters = new List<Parameter>();
            return DataBaseProcedure.ListEntidad<InstitucionDomain>(parameters, "sp_InstitucionListar", "CN_RISPACS");
        }

        public static InstitucionDatosDomain GetById(int id_institucion_datos)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter()
            {
                Name = nameof(id_institucion_datos),
                Type = DbType.Int32,
                Value = (object)id_institucion_datos
            });
            InstitucionDatosDomain institucionDatosDomain = new InstitucionDatosDomain();
            return DataBaseProcedure.GetEntidad<InstitucionDatosDomain>(parameters, "sp_InstitucionDato_GetById", "CN_RISPACS") ?? new InstitucionDatosDomain();
        }

        public static InstitucionDatosDomain GetByIdMethodAndInstitucion(
          int id_metodo,
          int id_institucion)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter()
            {
                Name = nameof(id_metodo),
                Type = DbType.Int32,
                Value = (object)id_metodo
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(id_institucion),
                Type = DbType.Int32,
                Value = (object)id_institucion
            });
            InstitucionDatosDomain institucionDatosDomain = new InstitucionDatosDomain();
            return DataBaseProcedure.GetEntidad<InstitucionDatosDomain>(parameters, "sp_InstitucionDato_GetByIdMethodAndInstitucion", "CN_RISPACS") ?? new InstitucionDatosDomain();
        }

        private static InstitucionDatosDomain BuildFunction(IDataReader row) => new InstitucionDatosDomain()
        {
            id_institucion_datos = row["id_institucion_datos"] != DBNull.Value ? (long)row["id_institucion_datos"] : 0L,
            id_institucion = row["id_institucion"] != DBNull.Value ? (int)row["id_institucion"] : 0,
            id_metodo = row["id_metodo"] != DBNull.Value ? (int)row["id_metodo"] : 0,
            nombre = row["nombre"] != DBNull.Value ? (string)row["nombre"] : string.Empty,
            url = row["url"] != DBNull.Value ? (string)row["url"] : string.Empty,
            metodo = row["metodo"] != DBNull.Value ? (string)row["metodo"] : string.Empty
        };
    }
}
