// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.RisPrestacionDataAccess
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
    public class RisPrestacionDataAccess
    {
        public static long Save(RisPrestacionDomain prestacion) => (long)DataBaseProcedure.GetInt(new List<Parameter>()
        {
            new Parameter() { Name = "id_prestacion", Type = DbType.Int32, Value = (object) prestacion.id_prestacion },
            new Parameter() { Name = "id_prestacion_remoto", Type = DbType.Int32, Value = (object) prestacion.id_prestacion_remoto },
            new Parameter() { Name = "aetitle", Type = DbType.String, Value = (object) prestacion.aetitle },
            new Parameter() { Name = "id_institucion", Type = DbType.Int32, Value = (object) prestacion.id_institucion },
            new Parameter() { Name = "nombre", Type = DbType.String, Value = (object) prestacion.nombre },
            new Parameter() { Name = "oit", Type = DbType.Boolean, Value = (object) prestacion.oit }
        }, "sp_RisPrestacion_save", "CN_RISPACS");

        public static RisPrestacionDomain GetById(long id_prestacion)
        {
            RisPrestacionDomain prestacionDomain = new RisPrestacionDomain();

            return DataBaseProcedure.GetEntidad<RisPrestacionDomain>(new List<Parameter>() {
                    new Parameter() { Name = nameof (id_prestacion), Type = DbType.Int64, Value = (object) id_prestacion }
            }, "sp_ris_prestacion_GetByID", "CN_RISPACS") ?? new RisPrestacionDomain();
        }

        public static List<RisPrestacionDomain> GetByPrestacionIdInforme(long idInforme)
        {
            List<Parameter> listParametro = new List<Parameter>();

            listParametro.Add(new IradDBNet.Dto.Parameter() { Name = "ID_INFORME", Type = DbType.Int64, Value = idInforme });

            return IradDBNet.DataBaseProcedure.ListEntidad<RisPrestacionDomain>(listParametro, "SP_RIS_PRESTACION_INFORMADA_CRM");
        }

        public static RisPrestacionDomain GetByUnique(long id_prestacion)
        {
            RisPrestacionDomain entidad = new RisPrestacionDomain();
            List<Parameter> listParametro = new List<Parameter>();

            listParametro.Add(new IradDBNet.Dto.Parameter() { Name = "id_prestacion", Type = DbType.Int64, Value = id_prestacion });

            entidad = IradDBNet.DataBaseProcedure.GetEntidad<RisPrestacionDomain>(listParametro, "sp_ris_prestacion_GetByID_CRM", "CN_RISPACS");

            if (entidad is null) entidad = new RisPrestacionDomain();

            return entidad;
        }

        public static RisPrestacionDomain GetByIdAndAetitleAndInstitucion(long id_prestacion_remoto, string aetitle, long id_institucion)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter() { Name = nameof(id_prestacion_remoto), Type = DbType.Int32, Value = (object)id_prestacion_remoto });
            parameters.Add(new Parameter() { Name = nameof(aetitle), Type = DbType.String, Value = (object)aetitle });
            parameters.Add(new Parameter() { Name = nameof(id_institucion), Type = DbType.Int32, Value = (object)id_institucion });
            
            RisPrestacionDomain prestacionDomain = new RisPrestacionDomain();

            return DataBaseProcedure.GetEntidad<RisPrestacionDomain>(parameters, "sp_ris_prestacion_GetByIdAndAetitleAndInstitucion", "CN_RISPACS") ?? new RisPrestacionDomain();
        }

        public static IList<RisPrestacionDomain> PrestacionesInformar(string username, int id_institucion, long id_ris_examen, string codExamen, string numeroacceso)
        {
            return DataBaseProcedure.ListEntidad<RisPrestacionDomain>(new List<Parameter>()
            {
                new Parameter() { Name = nameof (username), Type = DbType.String, Value = (object) username },
                new Parameter() { Name = nameof (id_institucion), Type = DbType.Int32, Value = (object) id_institucion },
                new Parameter() { Name = nameof (id_ris_examen), Type = DbType.Int32, Value = (object) id_ris_examen },
                new Parameter() { Name = nameof (codExamen), Type = DbType.String, Value = (object) codExamen },
                new Parameter() { Name = nameof (numeroacceso), Type = DbType.String, Value = (object) numeroacceso }
            }, "sp_RisExamenPrestacion_Informar", "CN_RISPACS");
        }

        public static RisPrestacionDomain PrestacionValidada(string username, int id_institucion, long id_ris_examen, string codExamen, string numeroacceso, long id_prestacion)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter() { Name = nameof(username), Type = DbType.String, Value = (object)username });
            parameters.Add(new Parameter() { Name = nameof(id_institucion), Type = DbType.Int32, Value = (object)id_institucion });
            parameters.Add(new Parameter() { Name = nameof(id_ris_examen), Type = DbType.Int32, Value = (object)id_ris_examen });
            parameters.Add(new Parameter() { Name = nameof(codExamen), Type = DbType.String, Value = (object)codExamen });
            parameters.Add(new Parameter() { Name = nameof(numeroacceso), Type = DbType.String, Value = (object)numeroacceso });
            parameters.Add(new Parameter() { Name = nameof(id_prestacion), Type = DbType.String, Value = (object)id_prestacion });
            RisPrestacionDomain prestacionDomain = new RisPrestacionDomain();
            return DataBaseProcedure.GetEntidad<RisPrestacionDomain>(parameters, "sp_RisExamenPrestacion_Validada") ?? new RisPrestacionDomain();
        }

        private static RisPrestacionDomain BuildFunction(IDataReader row) => new RisPrestacionDomain()
        {
            id_prestacion = row["id_prestacion"] != DBNull.Value ? (long)row["id_prestacion"] : 0L,
            id_prestacion_remoto = row["id_prestacion_remoto"] != DBNull.Value ? (long)row["id_prestacion_remoto"] : 0L,
            aetitle = row["aetitle"] != DBNull.Value ? (string)row["aetitle"] : string.Empty,
            id_institucion = row["id_institucion"] != DBNull.Value ? (int)row["id_institucion"] : 0,
            nombre = row["nombre"] != DBNull.Value ? (string)row["nombre"] : string.Empty,
            oit = row["oit"] != DBNull.Value && (bool)row["oit"]
        };
    }
}
