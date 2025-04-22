// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.ExamenPrestacionMantenedorDataAccess
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using IradDBNet;
using IradDBNet.Dto;
using MultiRisWeb.Data.Domain;
using MultiRisWeb.Data.ResponseEntity;
using System.Collections.Generic;
using System.Data;

namespace MultiRisWeb.Data.DataAccess
{
    public class ExamenPrestacionMantenedorDataAccess
    {
        public static ExamenPrestacionMantenedorDomain Get(int idExamen) => DataBaseProcedure.GetEntidad<ExamenPrestacionMantenedorDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "@idExamen",
        Type = DbType.Int32,
        Value = (object) idExamen
      }
    }, "spInfoExamenMantenedorPrestacion", "CN_RISPACS");

        public static List<ExamenPrestacionMantenedorDomain> ListarPrestaciones(int idInstitucion) => DataBaseProcedure.ListEntidad<ExamenPrestacionMantenedorDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "@idInstitucion",
        Type = DbType.Int32,
        Value = (object) idInstitucion
      }
    }, "spListPrestacionMantenedorExamen", "CN_RISPACS");

        public static List<ExamenPrestacionMantenedorDomain> ListarPrestacionesExamen(long idExamen) => DataBaseProcedure.ListEntidad<ExamenPrestacionMantenedorDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "@idExamen",
        Type = DbType.Int64,
        Value = (object) idExamen
      }
    }, "spListExamenPrestacion", "CN_RISPACS");

        public static ResultEjecucion InsertOrDeletePrestacionExamen(
          List<RisExamenPrestacionDomain> prestacionesExamenEliminar,
          List<RisExamenPrestacionDomain> prestacionesExamenInsertar,
          List<ResponseInformePrestacionEliminar> prestacionesInformeEliminar,
          long idExamen,
          string codExamen)
        {
            List<ProcedurePrincipal> procedures = new List<ProcedurePrincipal>();
            int num1 = 0;
            foreach (RisExamenPrestacionDomain prestacionDomain in prestacionesExamenEliminar)
            {
                List<Parameter> parameterList = new List<Parameter>();
                parameterList.Add(new Parameter()
                {
                    Name = "@idExamen",
                    Type = DbType.Int64,
                    Value = (object)prestacionDomain.id_ris_examen
                });
                parameterList.Add(new Parameter()
                {
                    Name = "@idExamenRemoto",
                    Type = DbType.Int64,
                    Value = (object)prestacionDomain.id_examen_prestacion_remoto
                });
                parameterList.Add(new Parameter()
                {
                    Name = "@codExamen",
                    Type = DbType.String,
                    Value = (object)prestacionDomain.codExamen
                });
                parameterList.Add(new Parameter()
                {
                    Name = "@idPrestacion",
                    Type = DbType.Int64,
                    Value = (object)prestacionDomain.id_prestacion
                });
                parameterList.Add(new Parameter()
                {
                    Name = "@idPrestacionRemoto",
                    Type = DbType.Int64,
                    Value = (object)prestacionDomain.id_prestacion_remoto
                });
                parameterList.Add(new Parameter()
                {
                    Name = "@idInstitucion",
                    Type = DbType.Int32,
                    Value = (object)prestacionDomain.id_institucion
                });
                parameterList.Add(new Parameter()
                {
                    Name = "@radiologo",
                    Type = DbType.String,
                    Value = (object)prestacionDomain.username
                });
                parameterList.Add(new Parameter()
                {
                    Name = "@accion",
                    Type = DbType.String,
                    Value = (object)0
                });
                ++num1;
                procedures.Add(new ProcedurePrincipal()
                {
                    IdParametroResult = 0,
                    NombreConexionDb = "CN_RISPACS",
                    NombreProcedure = "spInsertOrDeletePrestacionesExamen",
                    OrdenEjecucion = num1,
                    Parametros = parameterList,
                    NombreParametroResult = "",
                    ProceduresPrincipalSecundario = (List<ProcedurePrincipalSecundario>)null
                });
            }
            foreach (RisExamenPrestacionDomain prestacionDomain in prestacionesExamenInsertar)
            {
                List<Parameter> parameterList = new List<Parameter>();
                parameterList.Add(new Parameter()
                {
                    Name = "@idExamen",
                    Type = DbType.Int64,
                    Value = (object)prestacionDomain.id_ris_examen
                });
                parameterList.Add(new Parameter()
                {
                    Name = "@idExamenRemoto",
                    Type = DbType.Int64,
                    Value = (object)prestacionDomain.id_examen_prestacion_remoto
                });
                parameterList.Add(new Parameter()
                {
                    Name = "@codExamen",
                    Type = DbType.String,
                    Value = (object)prestacionDomain.codExamen
                });
                parameterList.Add(new Parameter()
                {
                    Name = "@idPrestacion",
                    Type = DbType.Int64,
                    Value = (object)prestacionDomain.id_prestacion
                });
                parameterList.Add(new Parameter()
                {
                    Name = "@idPrestacionRemoto",
                    Type = DbType.Int64,
                    Value = (object)prestacionDomain.id_prestacion_remoto
                });
                parameterList.Add(new Parameter()
                {
                    Name = "@idInstitucion",
                    Type = DbType.Int32,
                    Value = (object)prestacionDomain.id_institucion
                });
                parameterList.Add(new Parameter()
                {
                    Name = "@radiologo",
                    Type = DbType.String,
                    Value = (object)prestacionDomain.username
                });
                parameterList.Add(new Parameter()
                {
                    Name = "@accion",
                    Type = DbType.String,
                    Value = (object)1
                });
                ++num1;
                procedures.Add(new ProcedurePrincipal()
                {
                    IdParametroResult = 0,
                    NombreConexionDb = "CN_RISPACS",
                    NombreProcedure = "spInsertOrDeletePrestacionesExamen",
                    OrdenEjecucion = num1,
                    Parametros = parameterList,
                    NombreParametroResult = "",
                    ProceduresPrincipalSecundario = (List<ProcedurePrincipalSecundario>)null
                });
            }
            foreach (ResponseInformePrestacionEliminar prestacionEliminar in prestacionesInformeEliminar)
            {
                List<Parameter> parameterList = new List<Parameter>();
                parameterList.Add(new Parameter()
                {
                    Name = "@idInforme",
                    Type = DbType.Int64,
                    Value = (object)prestacionEliminar.IdInforme
                });
                parameterList.Add(new Parameter()
                {
                    Name = "@idPrestacion",
                    Type = DbType.Int64,
                    Value = (object)prestacionEliminar.IdPrestacion
                });
                ++num1;
                procedures.Add(new ProcedurePrincipal()
                {
                    IdParametroResult = 0,
                    NombreConexionDb = "CN_RISPACS",
                    NombreProcedure = "spDeletePrestacionesInforme",
                    OrdenEjecucion = num1,
                    Parametros = parameterList,
                    NombreParametroResult = "",
                    ProceduresPrincipalSecundario = (List<ProcedurePrincipalSecundario>)null
                });
            }
            List<Parameter> parameterList1 = new List<Parameter>();
            parameterList1.Add(new Parameter()
            {
                Name = "@idExamen",
                Type = DbType.Int64,
                Value = (object)idExamen
            });
            parameterList1.Add(new Parameter()
            {
                Name = "@codExamen",
                Type = DbType.String,
                Value = (object)codExamen
            });
            int num2 = num1 + 1;
            procedures.Add(new ProcedurePrincipal()
            {
                IdParametroResult = 0,
                NombreConexionDb = "CN_RISPACS",
                NombreProcedure = "spUpdateExamenInformePrestacion",
                OrdenEjecucion = num2,
                Parametros = parameterList1,
                NombreParametroResult = "",
                ProceduresPrincipalSecundario = (List<ProcedurePrincipalSecundario>)null
            });
            return DataBaseMultipleProcedure.EjecucionSecuencial(procedures);
        }

        public static ResultEjecucion Insert(RisExamenPrestacionDomain row)
        {
            List<ProcedurePrincipal> procedures = new List<ProcedurePrincipal>();
            int num1 = 0;
            List<Parameter> parameterList = new List<Parameter>();
            parameterList.Add(new Parameter()
            {
                Name = "@idExamen",
                Type = DbType.Int64,
                Value = (object)row.id_ris_examen
            });
            parameterList.Add(new Parameter()
            {
                Name = "@idExamenRemoto",
                Type = DbType.Int64,
                Value = (object)row.id_examen_prestacion_remoto
            });
            parameterList.Add(new Parameter()
            {
                Name = "@codExamen",
                Type = DbType.String,
                Value = (object)row.codExamen
            });
            parameterList.Add(new Parameter()
            {
                Name = "@idPrestacion",
                Type = DbType.Int64,
                Value = (object)row.id_prestacion
            });
            parameterList.Add(new Parameter()
            {
                Name = "@idPrestacionRemoto",
                Type = DbType.Int64,
                Value = (object)row.id_prestacion_remoto
            });
            parameterList.Add(new Parameter()
            {
                Name = "@idInstitucion",
                Type = DbType.Int32,
                Value = (object)row.id_institucion
            });
            parameterList.Add(new Parameter()
            {
                Name = "@radiologo",
                Type = DbType.String,
                Value = (object)row.username
            });
            parameterList.Add(new Parameter()
            {
                Name = "@accion",
                Type = DbType.String,
                Value = (object)0
            });
            int num2 = num1 + 1;
            procedures.Add(new ProcedurePrincipal()
            {
                IdParametroResult = 0,
                NombreConexionDb = "CN_RISPACS",
                NombreProcedure = "spInsertOrDeletePrestacionesExamen",
                OrdenEjecucion = num2,
                Parametros = parameterList,
                NombreParametroResult = "",
                ProceduresPrincipalSecundario = (List<ProcedurePrincipalSecundario>)null
            });
            return DataBaseMultipleProcedure.EjecucionSecuencial(procedures);
        }

        public static int SingleSave(RisExamenPrestacionDomain examenPrestacion) => DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "@institucion",
        Type = DbType.Int32,
        Value = (object) examenPrestacion.id_institucion
      },
      new Parameter()
      {
        Name = "@idExamen",
        Type = DbType.Int64,
        Value = (object) examenPrestacion.id_ris_examen
      },
      new Parameter()
      {
        Name = "@idPrestacion",
        Type = DbType.Int64,
        Value = (object) examenPrestacion.id_prestacion
      }
    }, "SP_RisExamen_InsertPrestacionExamen_CRM", "CN_RISPACS");

        public static int SingleDelete(RisExamenPrestacionDomain examenPrestacion) => DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "@Prestacion",
        Type = DbType.Int64,
        Value = (object) examenPrestacion.id_prestacion
      },
      new Parameter()
      {
        Name = "@Examen",
        Type = DbType.Int64,
        Value = (object) examenPrestacion.id_ris_examen
      }
    }, "SP_RisExamenDeletePrestacionExamen", "CN_RISPACS");

        public static int MantenedorSave(RisExamenPrestacionDomain mantencion, int accion, string estado)
        {
            return DataBaseProcedure.GetInt(new List<Parameter>() {
                    new Parameter() { Name = "@IDPRESTACION", Type = DbType.Int64, Value = (object) mantencion.id_prestacion },
                    new Parameter() { Name = "@ACCION", Type = DbType.String, Value = (object) (char) (accion.Equals(1) ? 73 : 69) },
                    new Parameter() { Name = "@RISEXAMEN", Type = DbType.Int64, Value = (object) mantencion.id_ris_examen },
                    new Parameter() { Name = "@ESTADO", Type = DbType.Int16, Value = (object) int.Parse(estado) },
                    new Parameter() { Name = "@USERNAME", Type = DbType.String, Value = (object) mantencion.username }
            }, "SP_DELETEORINSERTPRESTACION_CRM", "CN_RISPACS");
        }
    }
}
