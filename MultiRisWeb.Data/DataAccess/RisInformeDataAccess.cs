// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.RisInformeDataAccess
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
using System.Linq;
using System.Reflection;

namespace MultiRisWeb.Data.DataAccess
{
    public class RisInformeDataAccess
    {
        public static long Save(RisInformeDomain informe) => (long)DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "id_ris_informe",
        Type = DbType.Int32,
        Value = (object) informe.id_ris_informe
      },
      new Parameter()
      {
        Name = "id_informe_remoto",
        Type = DbType.Int32,
        Value = (object) informe.id_informe_remoto
      },
      new Parameter()
      {
        Name = "id_estado_informe",
        Type = DbType.Int32,
        Value = (object) informe.id_estado_informe
      },
      new Parameter()
      {
        Name = "id_paciente",
        Type = DbType.String,
        Value = (object) informe.id_paciente
      },
      new Parameter()
      {
        Name = "username_radiologo",
        Type = DbType.String,
        Value = (object) informe.username_radiologo
      },
      new Parameter()
      {
        Name = "fecha_validacion",
        Type = DbType.DateTime,
        Value = (object) informe.fecha_validacion
      },
      new Parameter()
      {
        Name = "flag_patologia_grave",
        Type = DbType.Int32,
        Value = (object) informe.flag_patologia_grave
      },
      new Parameter()
      {
        Name = "patologia_grave",
        Type = DbType.String,
        Value = (object) informe.patologia_grave
      },
      new Parameter()
      {
        Name = "descripcion",
        Type = DbType.String,
        Value = (object) informe.descripcion
      },
      new Parameter()
      {
        Name = "codigo_his",
        Type = DbType.Int32,
        Value = (object) informe.codigo_his
      },
      new Parameter()
      {
        Name = "valor",
        Type = DbType.Int32,
        Value = (object) informe.valor
      },
      new Parameter()
      {
        Name = "estado_sinconizacion",
        Type = DbType.Int32,
        Value = (object) informe.estado_sinconizacion
      },
      new Parameter()
      {
        Name = "codExamen",
        Type = DbType.String,
        Value = (object) informe.codExamen
      },
      new Parameter()
      {
        Name = "modalidad",
        Type = DbType.String,
        Value = (object) informe.modalidad
      },
      new Parameter()
      {
        Name = "id_tipo_informe",
        Type = DbType.Int32,
        Value = (object) informe.id_tipo_informe
      },
      new Parameter()
      {
        Name = "id_institucion",
        Type = DbType.Int32,
        Value = (object) informe.id_institucion
      }
    }, "sp_RisInforme_Save", "CN_RISPACS");

        public static int GetInformeConteo(string codeExamen) => DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "codExamen",
        Type = DbType.String,
        Value = (object) codeExamen
      }
    }, "sp_RisInforme_GetByCodExamenCount", "CN_RISPACS");

        public static DataTable SaveControlado(string codexamen, int id_institucion, int id_informe, int id_estado_informe, string id_prestacion, int id_usuario, int flag_patologia, string patologia_grave, string descripcion, string valortxtAntecedentesClinicos, string valortxthallazgos, string valortxtImpresion, string valortxtTecnica, int id_patologia_grave, List<TagExamenDomain> tagsExamen, long idUsuarioBecado = 0)
        {
            List<Parameter> parameters = new List<Parameter>();
            
            parameters.Add(new Parameter() { Name = nameof(codexamen), Type = DbType.String, Value = (object)codexamen });
            parameters.Add(new Parameter() { Name = nameof(id_institucion), Type = DbType.Int32, Value = (object)id_institucion });
            parameters.Add(new Parameter() { Name = nameof(id_informe), Type = DbType.Int32, Value = (object)id_informe });
            parameters.Add(new Parameter() { Name = nameof(id_estado_informe), Type = DbType.Int32, Value = (object)id_estado_informe });
            parameters.Add(new Parameter() { Name = nameof(id_prestacion), Type = DbType.String, Value = (object)id_prestacion });
            parameters.Add(new Parameter() { Name = nameof(id_usuario), Type = DbType.Int32, Value = (object)id_usuario });
            parameters.Add(new Parameter() { Name = "flag_patologia_grave", Type = DbType.String, Value = (object)flag_patologia });
            parameters.Add(new Parameter() { Name = nameof(patologia_grave), Type = DbType.String, Value = (object)patologia_grave });
            parameters.Add(new Parameter() { Name = nameof(descripcion), Type = DbType.String, Value = (object)descripcion });
            parameters.Add(new Parameter() { Name = nameof(valortxtAntecedentesClinicos), Type = DbType.String, Value = (object)valortxtAntecedentesClinicos });
            parameters.Add(new Parameter() { Name = nameof(valortxthallazgos), Type = DbType.String, Value = (object)valortxthallazgos });
            parameters.Add(new Parameter() { Name = nameof(valortxtImpresion), Type = DbType.String, Value = (object)valortxtImpresion });
            parameters.Add(new Parameter() { Name = nameof(valortxtTecnica), Type = DbType.String, Value = (object)valortxtTecnica });
            parameters.Add(new Parameter() { Name = nameof(id_patologia_grave), Type = DbType.Int32, Value = (object)id_patologia_grave });
            parameters.Add(new Parameter() { Name = "@id_usuario_becado", Type = DbType.Int64, Value = (object)idUsuarioBecado });
            
            DataTable dataTable2 = StoredProcedure.EjecutarProcedure(parameters, "sp_RisInforme_Save_Full", "CN_RISPACS");
            
            if (dataTable2 != null)
            {
                List<ProcedurePrincipal> procedures = new List<ProcedurePrincipal>();

                List<Parameter> parameterList = new List<Parameter>();

                int num1 = 0;

                parameterList.Add(new Parameter() { Name = "@codExamen", Type = DbType.String, Value = (object)codexamen });

                List<ProcedurePrincipal> procedurePrincipalList = procedures;
                
                ProcedurePrincipal procedurePrincipal = new ProcedurePrincipal();
                
                procedurePrincipal.IdParametroResult = 0;
                procedurePrincipal.NombreProcedure = "spTagExamenEliminar";
                procedurePrincipal.NombreConexionDb = "CN_RISPACS";
                procedurePrincipal.NombreParametroResult = "";
                
                int num2 = num1;
                int num3 = num2 + 1;
                
                procedurePrincipal.OrdenEjecucion = num2;
                procedurePrincipal.Parametros = parameterList;
                procedurePrincipal.ProceduresPrincipalSecundario = (List<ProcedurePrincipalSecundario>)null;
                procedurePrincipalList.Add(procedurePrincipal);
                
                if (tagsExamen.Any<TagExamenDomain>())
                {
                    foreach (TagExamenDomain tagExamenDomain in tagsExamen)
                        procedures.Add(new ProcedurePrincipal()
                        {
                            IdParametroResult = 0,
                            NombreProcedure = "spExamenTagInsertar",
                            NombreConexionDb = "CN_RISPACS",
                            NombreParametroResult = "",
                            OrdenEjecucion = num3++,
                            Parametros = new List<Parameter>()
                            {   new Parameter() { Name = "@codExamen", Type = DbType.String, Value = (object) tagExamenDomain.CodExamen },
                                new Parameter() { Name = "@idTag", Type = DbType.Int32, Value = (object) tagExamenDomain.IdTag },
                                new Parameter() { Name = "@usuario", Type = DbType.String, Value = (object) tagExamenDomain.UsuarioCreacion }
                            },
                            ProceduresPrincipalSecundario = (List<ProcedurePrincipalSecundario>)null
                        });
                }

                DataBaseMultipleProcedure.EjecucionSecuencial(procedures);
            }

            if (dataTable2 == null) dataTable2 = new DataTable();
            
            return dataTable2;
        }

        public static RisInformeDomain GetByID(long id_ris_informe)
        {
            RisInformeDomain risInformeDomain = new RisInformeDomain();
            return DataBaseProcedure.GetEntidad<RisInformeDomain>(new List<Parameter>()
      {
        new Parameter()
        {
          Name = nameof (id_ris_informe),
          Type = DbType.Int32,
          Value = (object) id_ris_informe
        }
      }, "sp_RisInforme_GetByID", "CN_RISPACS") ?? new RisInformeDomain();
        }

        public static int GetByIDInforme(int id_prestacion, int id_institucion, string codexamen) => DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (id_prestacion),
        Type = DbType.Int32,
        Value = (object) id_prestacion
      },
      new Parameter()
      {
        Name = nameof (id_institucion),
        Type = DbType.Int32,
        Value = (object) id_institucion
      },
      new Parameter()
      {
        Name = "codExamen",
        Type = DbType.String,
        Value = (object) codexamen
      }
    }, "sp_ValidaInformeExistentes", "CN_RISPACS");

        public static string GetInformeIdInforme(string codeExamen) => DataBaseProcedure.GetString(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "codExamen",
        Type = DbType.String,
        Value = (object) codeExamen
      }
    }, "sp_RisInforme_GetByCodExamenIdInforme", "CN_RISPACS");

        public static string GetInformeCodExamenIdInforme(string codeExamen, long idInforme) => DataBaseProcedure.GetString(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "@codExamen",
        Type = DbType.String,
        Value = (object) codeExamen
      },
      new Parameter()
      {
        Name = "@idInforme",
        Type = DbType.Int64,
        Value = (object) idInforme
      }
    }, "sp_RisInforme_GetCodExamenIdInforme", "CN_RISPACS");

        public static RisInformeDomain GetByIDInformeRemotoAndCodExamen(
          long id_ris_informe_remoto,
          string cod_examen,
          int id_institucion)
        {
            List<Parameter> parameters = new List<Parameter>();
            RisInformeDomain risInformeDomain = new RisInformeDomain();
            parameters.Add(new Parameter()
            {
                Name = nameof(id_ris_informe_remoto),
                Type = DbType.Int32,
                Value = (object)id_ris_informe_remoto
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(cod_examen),
                Type = DbType.String,
                Value = (object)cod_examen
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(id_institucion),
                Type = DbType.Int32,
                Value = (object)id_institucion
            });
            return DataBaseProcedure.GetEntidad<RisInformeDomain>(parameters, "sp_RisInforme_GetByIDInformeRemotoAndCodExamen", "CN_RISPACS") ?? new RisInformeDomain();
        }

        public static IList<prestacionesExternasParameters> GetInformeExternoPrestacion(
          string codeExamen,
          int idInstitucion)
        {
            return (IList<prestacionesExternasParameters>)DataBaseProcedure.ListEntidad<prestacionesExternasParameters>(new List<Parameter>()
      {
        new Parameter()
        {
          Name = nameof (codeExamen),
          Type = DbType.String,
          Value = (object) codeExamen
        },
        new Parameter()
        {
          Name = nameof (idInstitucion),
          Type = DbType.String,
          Value = (object) idInstitucion
        }
      }, "sp_risInformeExternoPrestacion", "CN_RISPACS");
        }

        public static IList<prestacionesExternasParameters> GetInformeExternoPrestacionIdInf(
          long idinforme,
          int idInstitucion)
        {
            return (IList<prestacionesExternasParameters>)DataBaseProcedure.ListEntidad<prestacionesExternasParameters>(new List<Parameter>()
      {
        new Parameter()
        {
          Name = "id_ris_informe",
          Type = DbType.Int32,
          Value = (object) idinforme
        },
        new Parameter()
        {
          Name = nameof (idInstitucion),
          Type = DbType.String,
          Value = (object) idInstitucion
        }
      }, "sp_risInformeExternoPrestacionIdIn", "CN_RISPACS");
        }

        public static void GetRecargaEnvioInforme(int id_ris_examen, string numeroacceso) => DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (id_ris_examen),
        Type = DbType.Int32,
        Value = (object) id_ris_examen
      },
      new Parameter()
      {
        Name = nameof (numeroacceso),
        Type = DbType.String,
        Value = (object) numeroacceso
      }
    }, "sp_ReprocesarEnvioInforme_Save", "CN_RISPACS");

        public static IList<RisInformeDomain> GetByCodExamenNoValidado(
          string codExamen,
          int id_estado_informe,
          string numeroacceso,
          int id_institucion)
        {
            return (IList<RisInformeDomain>)DataBaseProcedure.ListEntidad<RisInformeDomain>(new List<Parameter>()
      {
        new Parameter()
        {
          Name = nameof (codExamen),
          Type = DbType.String,
          Value = (object) codExamen
        },
        new Parameter()
        {
          Name = nameof (numeroacceso),
          Type = DbType.String,
          Value = (object) numeroacceso
        },
        new Parameter()
        {
          Name = nameof (id_estado_informe),
          Type = DbType.Int32,
          Value = (object) id_estado_informe
        },
        new Parameter()
        {
          Name = nameof (id_institucion),
          Type = DbType.Int32,
          Value = (object) id_institucion
        }
      }, "sp_RisInforme_GetByCodExamen", "CN_RISPACS");
        }

        public static IList<RisInformeDomain> GetByCodExamenValidado(
          string codExamen,
          int id_estado_informe,
          string numeroacceso,
          int id_institucion)
        {
            return (IList<RisInformeDomain>)DataBaseProcedure.ListEntidad<RisInformeDomain>(new List<Parameter>()
      {
        new Parameter()
        {
          Name = nameof (codExamen),
          Type = DbType.String,
          Value = (object) codExamen
        },
        new Parameter()
        {
          Name = nameof (numeroacceso),
          Type = DbType.String,
          Value = (object) numeroacceso
        },
        new Parameter()
        {
          Name = nameof (id_estado_informe),
          Type = DbType.Int32,
          Value = (object) id_estado_informe
        },
        new Parameter()
        {
          Name = nameof (id_institucion),
          Type = DbType.Int32,
          Value = (object) id_institucion
        }
      }, "sp_RisInforme_GetByCodExamenValidado", "CN_RISPACS");
        }

        public static IList<RisInformeDomain> GetByCodExamenValidadoServicio(
          string codExamen,
          int id_estado_informe,
          string numeroacceso,
          int id_institucion)
        {
            return (IList<RisInformeDomain>)DataBaseProcedure.ListEntidad<RisInformeDomain>(new List<Parameter>()
      {
        new Parameter()
        {
          Name = nameof (codExamen),
          Type = DbType.String,
          Value = (object) codExamen
        },
        new Parameter()
        {
          Name = nameof (numeroacceso),
          Type = DbType.String,
          Value = (object) numeroacceso
        },
        new Parameter()
        {
          Name = nameof (id_estado_informe),
          Type = DbType.Int32,
          Value = (object) id_estado_informe
        },
        new Parameter()
        {
          Name = nameof (id_institucion),
          Type = DbType.Int32,
          Value = (object) id_institucion
        }
      }, "sp_RisInforme_GetByCodExamenValidadoServicio", "CN_RISPACS");
        }

        public static IList<RisInformeDomain> GetByMultiple(
          string codExamen,
          string numeroacceso,
          int id_institucion)
        {
            return (IList<RisInformeDomain>)DataBaseProcedure.ListEntidad<RisInformeDomain>(new List<Parameter>()
      {
        new Parameter()
        {
          Name = nameof (codExamen),
          Type = DbType.String,
          Value = (object) codExamen
        },
        new Parameter()
        {
          Name = nameof (numeroacceso),
          Type = DbType.String,
          Value = (object) numeroacceso
        },
        new Parameter()
        {
          Name = nameof (id_institucion),
          Type = DbType.Int32,
          Value = (object) id_institucion
        }
      }, "sp_RisInforme_GetByMultiple", "CN_RISPACS");
        }

        public static List<prestacionesExternasParameters> GetInformeExternoPrestacion() => DataBaseProcedure.ListEntidad<prestacionesExternasParameters>(new List<Parameter>(), "sp_risInformeExternoPrestacion", "CN_RISPACS");

        public static RisInformeOITDomain GetByCodExamen(string codExamen)
        {
            RisInformeOITDomain informeOitDomain = new RisInformeOITDomain();
            return DataBaseProcedure.GetEntidad<RisInformeOITDomain>(new List<Parameter>()
      {
        new Parameter()
        {
          Name = "codexamen",
          Type = DbType.String,
          Value = (object) codExamen
        }
      }, "sp_Multiris_RisInformeOIT_GetByCodExamen", "CN_RISPACS") ?? new RisInformeOITDomain();
        }

        public static RisInformeOITDomain GetByIdInforme(string codExamen)
        {
            RisInformeOITDomain informeOitDomain = new RisInformeOITDomain();
            return DataBaseProcedure.GetEntidad<RisInformeOITDomain>(new List<Parameter>()
      {
        new Parameter()
        {
          Name = "codexamen",
          Type = DbType.String,
          Value = (object) codExamen
        }
      }, "sp_Multiris_RisInformeOIT_GetByCodExamen", "CN_RISPACS") ?? new RisInformeOITDomain();
        }

        public static IList<RisInformeDomain> GetByCodExamenValidado2(string codExamen, int id_estado_informe, int id_institucion)
        {
            return (IList<RisInformeDomain>)DataBaseProcedure.ListEntidad<RisInformeDomain>(new List<Parameter>()
      {
        new Parameter()
        {
          Name = nameof (codExamen),
          Type = DbType.String,
          Value = (object) codExamen
        },
        new Parameter()
        {
          Name = nameof (id_estado_informe),
          Type = DbType.Int32,
          Value = (object) id_estado_informe
        },
        new Parameter()
        {
          Name = nameof (id_institucion),
          Type = DbType.Int32,
          Value = (object) id_institucion
        }
      }, "sp_RisInforme_GetByCodExamenValidado2", "CN_RISPACS");
        }

        #region Nuevo para OIT
        public static long SaveOIT(InformeOITDomain informe)
        {
            var propertyNames = new List<string> {
                 "RISEXAMEN", "RISINFORME", "IDESTADO", "IDUSUARIO", "CODEXAMEN", "PRESTACION", "NUMRADIOGRAFIA", "RADIOGRAFIADIG", "NEGASTOCOPIA", "CALIDAD", "RADIOGRAFIANOR", "COMENTARIO", "PARENQUIMATOSA", "OPACIPRIMARIA"
                ,"OPACISECUNDARIA", "OPACIDADZONA", "OPACPROFUSION", "OPACIDAGRANDE", "ANORMALPLEURAL", "PLACAPLEURAL", "PP_SITIOPERFIL", "PP_SITIOFRENTE","PP_SITIODIAGRAMA", "PP_SITIOOTRO", "PP_CALSIFICACIONPERFIL"
                ,"PP_CALSIFICACIONFRENTE", "PP_CALSIFICACIONDIAGRAMA", "PP_CALSIFICACIONOTRO", "PP_EXTENSIONPAREDPERFILOP", "PP_EXTENSIONPAREDPERFILSE", "PP_EXTENSIONPAREDFRENTEOP", "PP_EXTENSIONPAREDFRENTESE"
                ,"PP_ANCHODERECHAOP", "PP_ANCHODERECHASE", "PP_ANCHOIZQUIERDAOP", "PP_ANCHOIZQUIERDASE", "OBLITERACION", "ENGROSAPLERURALDIFUSO", "EPD_SITIOPERFIL", "EPD_SITIOFRENTE", "EPD_CALSIFICACIONPERFIL"
                ,"EPD_CALSIFICACIONFRENTE", "EPD_EXTENSIONPAREDPERFILOP", "EPD_EXTENSIONPAREDPERFILSE", "EPD_EXTENSIONPAREDFRENTEOP", "EPD_EXTENSIONPAREDFRENTESE", "EPD_ANCHODERECHAOP", "EPD_ANCHODERECHASE"
                ,"EPD_ANCHOIZQUIERDAOP", "EPD_ANCHOIZQUIERDASE", "OTRASANORMALIDADES", "SIMBOLO_AA", "SIMBOLO_AT", "SIMBOLO_AX", "SIMBOLO_BU", "SIMBOLO_CA", "SIMBOLO_CG", "SIMBOLO_CN", "SIMBOLO_CO", "SIMBOLO_CP"
                ,"SIMBOLO_CV", "SIMBOLO_DI", "SIMBOLO_EF", "SIMBOLO_EM", "SIMBOLO_ES", "SIMBOLO_FR", "SIMBOLO_HI", "SIMBOLO_HO", "SIMBOLO_ID", "SIMBOLO_IH", "SIMBOLO_KL", "SIMBOLO_ME", "SIMBOLO_PA", "SIMBOLO_PB"
                ,"SIMBOLO_PI", "SIMBOLO_PX", "@SIMBOLO_RA", "SIMBOLO_RP", "SIMBOLO_TB", "SIMBOLO_OD", "COMENTARIOGEN"
            };
	
            var _lparam = new List<Parameter>();

            Type type = typeof(InformeOITDomain);

            foreach (PropertyInfo property in type.GetProperties()) {

                var value = property.GetValue(informe);
                var name = string.Format("@{0}", property.Name);
                var dbtype = GetDbType(property.PropertyType);

                _lparam.Add(new Parameter() { Name = name, Type = dbtype, Value = value });
            }

            return DataBaseProcedure.GetInt(_lparam, "SP_SAVE_RISEXAMEN_INFORME_OIT_CRM", "CN_RISPACS");
        }

        public static InformeOITDomain ObtieneInformeOIT(string codExamen, long informe) 
        {
            var _list = new List<Parameter>();

            _list.Add(new Parameter() { Name = "CODEXAMEN", Type = DbType.String, Value = codExamen });
            _list.Add(new Parameter() { Name = "INFORMEID", Type = DbType.Int64, Value = informe });
            
            return DataBaseProcedure.GetEntidad<InformeOITDomain>(_list, "SP_LISTA_INFORMEOIT_CRM", "CN_RISPACS") ?? new InformeOITDomain();
        }

        public static DataTable VerInformeOIT(string codexamen) {
            var _list = new List<Parameter>();

            _list.Add(new Parameter() { Name = "CODEXAMEN", Type = DbType.String, Value = codexamen });

            return StoredProcedure.EjecutarProcedure(_list, "SP_VER_INFORMEOIT_CRM", "CN_RISPACS") ?? new DataTable();
        }

        public static DbType GetDbType(Type propertyType)
        {
            if (propertyType == typeof(string)) return DbType.String;
            if (propertyType == typeof(int)) return DbType.Int32;
            if (propertyType == typeof(long)) return DbType.Int64;
            if (propertyType == typeof(bool)) return DbType.Boolean;
            if (propertyType == typeof(DateTime)) return DbType.DateTime;
            if (propertyType == typeof(decimal)) return DbType.Decimal;
            if (propertyType == typeof(double)) return DbType.Double;
            if (propertyType == typeof(float)) return DbType.Single;

            return DbType.String; // Asignación predeterminada (o ajusta según tus necesidades)
        }
        #endregion Nuevo para OIT
		
        private static RisInformeDomain BuildFunction(IDataReader row) => new RisInformeDomain()
        {
            id_ris_informe = row["id_ris_informe"] != DBNull.Value ? (long)row["id_ris_informe"] : 0L,
            id_informe_remoto = row["id_informe_remoto"] != DBNull.Value ? (long)row["id_informe_remoto"] : 0L,
            id_paciente = row["id_paciente"] != DBNull.Value ? (string)row["id_paciente"] : string.Empty,
            username_radiologo = row["username_radiologo"] != DBNull.Value ? (string)row["username_radiologo"] : string.Empty,
            fecha_validacion = row["fecha_validacion"] != DBNull.Value ? (DateTime)row["fecha_validacion"] : new DateTime(1900, 1, 1),
            flag_patologia_grave = row["flag_patologia_grave"] != DBNull.Value ? (int)row["flag_patologia_grave"] : 0,
            patologia_grave = row["patologia_grave"] != DBNull.Value ? (string)row["patologia_grave"] : string.Empty,
            descripcion = row["descripcion"] != DBNull.Value ? (string)row["descripcion"] : string.Empty,
            codigo_his = row["codigo_his"] != DBNull.Value ? (long)row["codigo_his"] : 0L,
            valor = row["valor"] != DBNull.Value ? (int)row["valor"] : 0,
            estado_sinconizacion = row["estado_sinconizacion"] != DBNull.Value ? (int)row["estado_sinconizacion"] : 0,
            codExamen = row["codExamen"] != DBNull.Value ? (string)row["codExamen"] : string.Empty,
            id_estado_informe = row["id_estado_informe"] != DBNull.Value ? (int)row["id_estado_informe"] : 0,
            modalidad = row["modalidad"] != DBNull.Value ? (string)row["modalidad"] : string.Empty,
            id_tipo_informe = row["id_tipo_informe"] != DBNull.Value ? (int)row["id_tipo_informe"] : 0,
            id_institucion = row["id_institucion"] != DBNull.Value ? (int)row["id_institucion"] : 0,
            id_prestacion_remoto = row["id_prestacion_remoto"] != DBNull.Value ? (long)row["id_prestacion_remoto"] : 0L
        };
    }
}
