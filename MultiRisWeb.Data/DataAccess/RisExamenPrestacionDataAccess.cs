// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.RisExamenPrestacionDataAccess
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
    public class RisExamenPrestacionDataAccess
    {
        public static long Save(RisExamenPrestacionDomain ris_examen_prestacion) => (long)DataBaseProcedure.GetInt(new List<Parameter>()
        {
            new Parameter() { Name = "id_examen_prestacion", Type = DbType.Int32, Value = (object) ris_examen_prestacion.id_examen_prestacion },
            new Parameter() { Name = "id_examen_prestacion_remoto", Type = DbType.Int32, Value = (object) ris_examen_prestacion.id_examen_prestacion_remoto },
            new Parameter() { Name = "id_prestacion_remoto", Type = DbType.Int32, Value = (object) ris_examen_prestacion.id_prestacion_remoto },
            new Parameter() { Name = "id_prestacion", Type = DbType.Int32, Value = (object) ris_examen_prestacion.id_prestacion },
            new Parameter() { Name = "codExamen", Type = DbType.String, Value = (object) ris_examen_prestacion.codExamen },
            new Parameter() { Name = "username", Type = DbType.String, Value = (object) ris_examen_prestacion.username },
            new Parameter() { Name = "id_ris_examen", Type = DbType.Int32, Value = (object) ris_examen_prestacion.id_ris_examen },
            new Parameter() { Name = "id_institucion", Type = DbType.Int32, Value = (object) ris_examen_prestacion.id_institucion }
        }, "sp_RisExamenPrestacion_Save", "CN_RISPACS");

        public static RisExamenPrestacionDomain GetById(long id_examen_prestacion)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter()
            {
                Name = nameof(id_examen_prestacion),
                Type = DbType.Int32,
                Value = (object)id_examen_prestacion
            });
            RisExamenPrestacionDomain prestacionDomain = new RisExamenPrestacionDomain();
            return DataBaseProcedure.GetEntidad<RisExamenPrestacionDomain>(parameters, "sp_RisExamenPrestacion_GetByID", "CN_RISPACS") ?? new RisExamenPrestacionDomain();
        }

        public static IList<RisExamenPrestacionDomain> Informar(string username, int id_institucion, long id_ris_examen, string codExamen)
        {
            return (IList<RisExamenPrestacionDomain>)DataBaseProcedure.ListEntidad<RisExamenPrestacionDomain>(new List<Parameter>()
            {
                new Parameter() { Name = nameof (username), Type = DbType.String, Value = (object) username },
                new Parameter() { Name = nameof (id_institucion), Type = DbType.Int32, Value = (object) id_institucion },
                new Parameter() { Name = nameof (id_ris_examen), Type = DbType.Int32, Value = (object) id_ris_examen },
                new Parameter() { Name = nameof (codExamen), Type = DbType.String, Value = (object) codExamen }
            }, "sp_RisExamenPrestacion_Informar", "CN_RISPACS");
        }

        public static IList<RisExamenPrestacionDomain> GetByCodExamen(string codExamen) => (IList<RisExamenPrestacionDomain>)DataBaseProcedure.ListEntidad<RisExamenPrestacionDomain>(new List<Parameter>()
        {
            new Parameter() { Name = nameof (codExamen), Type = DbType.String, Value = (object) codExamen }
        }, "sp_RisExamenPrestacion_GetByCodExamen", "CN_RISPACS");

        public static int DeleteExamenPrestacion(long id_examen_prestacion) => DataBaseProcedure.GetInt(new List<Parameter>()
        {
            new Parameter() { Name = nameof (id_examen_prestacion), Type = DbType.Int32, Value = (object) id_examen_prestacion }
        }, "sp_RisExamenPrestacion_DeleteExamenPrestacion", "CN_RISPACS");

        public static RisExamenPrestacionDomain GetByMultiple(int id_institucion, long id_prestacion_remoto, long id_examen_prestacion_remoto, string cod_examen)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter() { Name = nameof(id_institucion), Type = DbType.Int32, Value = (object)id_institucion });
            parameters.Add(new Parameter() { Name = nameof(id_examen_prestacion_remoto), Type = DbType.Int32, Value = (object)id_prestacion_remoto });
            parameters.Add(new Parameter() { Name = "codExamen", Type = DbType.String, Value = (object)cod_examen });
            
            RisExamenPrestacionDomain prestacionDomain = new RisExamenPrestacionDomain();
            
            return DataBaseProcedure.GetEntidad<RisExamenPrestacionDomain>(parameters, "sp_RisExamenPrestacion_GetByMultiple") ?? new RisExamenPrestacionDomain();
        }

        private static RisExamenPrestacionDomain BuildFunction(IDataReader row) => new RisExamenPrestacionDomain()
        {
            id_examen_prestacion = row["id_examen_prestacion"] != DBNull.Value ? (long)row["id_examen_prestacion"] : 0L,
            id_examen_prestacion_remoto = row["id_examen_prestacion_remoto"] != DBNull.Value ? (long)row["id_examen_prestacion_remoto"] : 0L,
            id_prestacion_remoto = row["id_prestacion_remoto"] != DBNull.Value ? (long)row["id_prestacion_remoto"] : 0L,
            id_prestacion = row["id_prestacion"] != DBNull.Value ? (long)row["id_prestacion"] : 0L,
            codExamen = row["codExamen"] != DBNull.Value ? (string)row["codExamen"] : string.Empty,
            username = row["username"] != DBNull.Value ? (string)row["username"] : string.Empty,
            id_ris_examen = row["id_ris_examen"] != DBNull.Value ? (long)row["id_ris_examen"] : 0L,
            id_institucion = row["id_institucion"] != DBNull.Value ? (int)row["id_institucion"] : 0
        };
    }
}
