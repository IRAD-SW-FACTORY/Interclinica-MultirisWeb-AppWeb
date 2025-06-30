// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.RisExamenDataAccess
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
    public static class RisExamenDataAccess
    {
        public static long Save(RisExamenDomain risExamen) => (long)DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "id_ris_examen",
        Type = DbType.Int32,
        Value = (object) risExamen.id_ris_examen
      },
      new Parameter()
      {
        Name = "id_examen_remoto",
        Type = DbType.Int32,
        Value = (object) risExamen.id_examen_remoto
      },
      new Parameter()
      {
        Name = "codexamen",
        Type = DbType.String,
        Value = (object) risExamen.codexamen
      },
      new Parameter()
      {
        Name = "aetitle",
        Type = DbType.String,
        Value = (object) risExamen.aetitle
      },
      new Parameter()
      {
        Name = "numeroacceso",
        Type = DbType.String,
        Value = (object) risExamen.numeroacceso
      },
      new Parameter()
      {
        Name = "idpaciente",
        Type = DbType.String,
        Value = (object) risExamen.idpaciente
      },
      new Parameter()
      {
        Name = "nombre",
        Type = DbType.String,
        Value = (object) risExamen.nombre
      },
      new Parameter()
      {
        Name = "apellidopaterno",
        Type = DbType.String,
        Value = (object) risExamen.apellidopaterno
      },
      new Parameter()
      {
        Name = "apellidomaterno",
        Type = DbType.String,
        Value = (object) risExamen.apellidomaterno
      },
      new Parameter()
      {
        Name = "fechanacimiento",
        Type = DbType.DateTime,
        Value = (object) risExamen.fechanacimiento
      },
      new Parameter()
      {
        Name = "sexo",
        Type = DbType.String,
        Value = (object) risExamen.sexo
      },
      new Parameter()
      {
        Name = "fechaexamen",
        Type = DbType.DateTime,
        Value = (object) risExamen.fechaexamen
      },
      new Parameter()
      {
        Name = "modalidad",
        Type = DbType.String,
        Value = (object) risExamen.modalidad
      },
      new Parameter()
      {
        Name = "descripcion",
        Type = DbType.String,
        Value = (object) risExamen.descripcion
      },
      new Parameter()
      {
        Name = "idradiologo",
        Type = DbType.Int32,
        Value = (object) risExamen.idradiologo
      },
      new Parameter()
      {
        Name = "nombreradiologo",
        Type = DbType.String,
        Value = (object) risExamen.nombreradiologo
      },
      new Parameter()
      {
        Name = "fechaasignacion",
        Type = DbType.DateTime,
        Value = (object) risExamen.fechaasignacion
      },
      new Parameter()
      {
        Name = "edad",
        Type = DbType.String,
        Value = (object) risExamen.edad
      },
      new Parameter()
      {
        Name = "idorden",
        Type = DbType.String,
        Value = (object) risExamen.idorden
      },
      new Parameter()
      {
        Name = "idtipoorden",
        Type = DbType.String,
        Value = (object) risExamen.idtipoorden
      },
      new Parameter()
      {
        Name = "medicosolicitante",
        Type = DbType.String,
        Value = (object) risExamen.medicosolicitante
      },
      new Parameter()
      {
        Name = "fechavalidacion",
        Type = DbType.DateTime,
        Value = (object) risExamen.fechavalidacion
      },
      new Parameter()
      {
        Name = "horaexamen",
        Type = DbType.String,
        Value = (object) risExamen.horaexamen
      },
      new Parameter()
      {
        Name = "flagimagen",
        Type = DbType.Int32,
        Value = (object) risExamen.flagimagen
      },
      new Parameter()
      {
        Name = "usernameRadiologo",
        Type = DbType.String,
        Value = (object) risExamen.usernameRadiologo
      },
      new Parameter()
      {
        Name = "id_estado_examen",
        Type = DbType.Int32,
        Value = (object) risExamen.id_estado_examen
      },
      new Parameter()
      {
        Name = "id_institucion",
        Type = DbType.Int32,
        Value = (object) risExamen.id_institucion
      },
      new Parameter()
      {
        Name = "id_estado_sincronizado",
        Type = DbType.Int32,
        Value = (object) risExamen.id_estado_sincronizado
      },
      new Parameter()
      {
        Name = "bloqueado",
        Type = DbType.Int32,
        Value = (object) risExamen.bloqueado
      },
      new Parameter()
      {
        Name = "fecha_bloqueo",
        Type = DbType.DateTime,
        Value = (object) risExamen.fecha_bloqueo
      },
      new Parameter()
      {
        Name = "id_usuario_bloqueo",
        Type = DbType.Int32,
        Value = (object) risExamen.id_usuario_bloqueo
      },
      new Parameter()
      {
        Name = "instancias",
        Type = DbType.Int32,
        Value = (object) risExamen.instancias
      },
      new Parameter()
      {
        Name = "entregado",
        Type = DbType.Boolean,
        Value = (object) risExamen.entregado
      },
        new Parameter()
      {
        Name = "idasignado",
        Type = DbType.Int32,
        Value = (object) risExamen.asignado
      }
    }, "sp_RisExamen_Save", "CN_RISPACS");

        public static long SaveOIT(RisInformeOITDomain risInformeOIT) => (long)DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "id",
        Type = DbType.Int32,
        Value = (object) risInformeOIT.id
      },
      new Parameter()
      {
        Name = "id_examen",
        Type = DbType.Int32,
        Value = (object) risInformeOIT.idInforme
      },
      new Parameter()
      {
        Name = "nombre",
        Type = DbType.String,
        Value = (object) risInformeOIT.nombre
      },
      new Parameter()
      {
        Name = "idpaciente",
        Type = DbType.String,
        Value = (object) risInformeOIT.idPaciente
      },
      new Parameter()
      {
        Name = "fecha_radiografia",
        Type = DbType.DateTime,
        Value = (object) risInformeOIT.fechaRadiografia
      },
      new Parameter()
      {
        Name = "numero_radiografia",
        Type = DbType.String,
        Value = (object) risInformeOIT.numeroRadiografia
      },
      new Parameter()
      {
        Name = "radiografia_digital",
        Type = DbType.String,
        Value = (object) risInformeOIT.radiografiaDigital
      },
      new Parameter()
      {
        Name = "idmedico",
        Type = DbType.Int32,
        Value = (object) risInformeOIT.idmedico
      },
      new Parameter()
      {
        Name = "lectura_negatoscopio",
        Type = DbType.String,
        Value = (object) risInformeOIT.lecturaNegatoscopio
      },
      new Parameter()
      {
        Name = "tecnica_qualidaden",
        Type = DbType.String,
        Value = (object) risInformeOIT.tecnicaQualidaden
      },
      new Parameter()
      {
        Name = "radiografia_normal",
        Type = DbType.String,
        Value = (object) risInformeOIT.radiografiaNormal
      },
      new Parameter()
      {
        Name = "comentario",
        Type = DbType.String,
        Value = (object) risInformeOIT.comentario
      },
      new Parameter()
      {
        Name = "anormalidad_parenquimatosa",
        Type = DbType.String,
        Value = (object) risInformeOIT.anormalidadParenquimatosa
      },
      new Parameter()
      {
        Name = "primaria1",
        Type = DbType.String,
        Value = (object) risInformeOIT.primaria1
      },
      new Parameter()
      {
        Name = "primaria2",
        Type = DbType.String,
        Value = (object) risInformeOIT.primaria2
      },
      new Parameter()
      {
        Name = "primaria3",
        Type = DbType.String,
        Value = (object) risInformeOIT.primaria3
      },
      new Parameter()
      {
        Name = "secundaria1",
        Type = DbType.String,
        Value = (object) risInformeOIT.secundaria1
      },
      new Parameter()
      {
        Name = "secundaria2",
        Type = DbType.String,
        Value = (object) risInformeOIT.secundaria2
      },
      new Parameter()
      {
        Name = "secundaria3",
        Type = DbType.String,
        Value = (object) risInformeOIT.secundaria3
      },
      new Parameter()
      {
        Name = "zonas1",
        Type = DbType.String,
        Value = (object) risInformeOIT.zonas1
      },
      new Parameter()
      {
        Name = "profusion1",
        Type = DbType.String,
        Value = (object) risInformeOIT.profusion1
      },
      new Parameter()
      {
        Name = "profusion2",
        Type = DbType.String,
        Value = (object) risInformeOIT.profusion2
      },
      new Parameter()
      {
        Name = "profusion3",
        Type = DbType.String,
        Value = (object) risInformeOIT.profusion3
      },
      new Parameter()
      {
        Name = "profusion4",
        Type = DbType.String,
        Value = (object) risInformeOIT.profusion4
      },
      new Parameter()
      {
        Name = "opacidades_pequenas1",
        Type = DbType.String,
        Value = (object) risInformeOIT.opacidadesPequenas1
      },
      new Parameter()
      {
        Name = "anormalidad_pleural",
        Type = DbType.String,
        Value = (object) risInformeOIT.anormalidadPleural
      },
      new Parameter()
      {
        Name = "placas_pleurales",
        Type = DbType.String,
        Value = (object) risInformeOIT.placasPleurales
      },
      new Parameter()
      {
        Name = "placas_pleurales_sitio_perfil",
        Type = DbType.String,
        Value = (object) risInformeOIT.placasPleuralesSitioPerfil
      },
      new Parameter()
      {
        Name = "placas_pleurales_sitio_frente",
        Type = DbType.String,
        Value = (object) risInformeOIT.placasPleuralesSitioFrente
      },
      new Parameter()
      {
        Name = "placas_pleurales_sitio_diagrama",
        Type = DbType.String,
        Value = (object) risInformeOIT.placasPleuralesSitioDiagrama
      },
      new Parameter()
      {
        Name = "placas_pleurales_sitio_otro",
        Type = DbType.String,
        Value = (object) risInformeOIT.placasPleuralesSitioOtro
      },
      new Parameter()
      {
        Name = "placas_pleurales_calcificacion_perfil",
        Type = DbType.String,
        Value = (object) risInformeOIT.placasPleuralesCalcificacionPerfil
      },
      new Parameter()
      {
        Name = "placas_pleurales_calcificacion_frente",
        Type = DbType.String,
        Value = (object) risInformeOIT.placasPleuralesCalcificacionFrente
      },
      new Parameter()
      {
        Name = "placas_pleurales_calcificacion_diagrama",
        Type = DbType.String,
        Value = (object) risInformeOIT.placasPleuralesCalcificacionDiagrama
      },
      new Parameter()
      {
        Name = "placas_pleurales_calcificacion_otro",
        Type = DbType.String,
        Value = (object) risInformeOIT.placasPleuralesCalcificacionOtro
      },
      new Parameter()
      {
        Name = "placas_pleurales_extencion_pared1",
        Type = DbType.String,
        Value = (object) risInformeOIT.placasPleuralesExtencionPared1
      },
      new Parameter()
      {
        Name = "placas_pleurales_extencion_pared2",
        Type = DbType.String,
        Value = (object) risInformeOIT.placasPleuralesExtencionPared2
      },
      new Parameter()
      {
        Name = "placas_pleurales_ancho1",
        Type = DbType.String,
        Value = (object) risInformeOIT.placasPleuralesAncho1
      },
      new Parameter()
      {
        Name = "placas_pleurales_ancho2",
        Type = DbType.String,
        Value = (object) risInformeOIT.placasPleuralesAncho2
      },
      new Parameter()
      {
        Name = "obliteracion_angulo_costofrenico",
        Type = DbType.String,
        Value = (object) risInformeOIT.obliteracionAnguloCostofrenico
      },
      new Parameter()
      {
        Name = "engrosamiento_pleural_difuso",
        Type = DbType.String,
        Value = (object) risInformeOIT.engrosamientoPleuralDifuso
      },
      new Parameter()
      {
        Name = "engrosamiento_pleural_difuso_sitio_perfil",
        Type = DbType.String,
        Value = (object) risInformeOIT.engrosamientoPleuralDifusoSitioPerfil
      },
      new Parameter()
      {
        Name = "engrosamiento_pleural_difuso_sitio_frente",
        Type = DbType.String,
        Value = (object) risInformeOIT.engrosamientoPleuralDifusoSitioFrente
      },
      new Parameter()
      {
        Name = "engrosamiento_pleural_difuso_calcificacion_perfil",
        Type = DbType.String,
        Value = (object) risInformeOIT.engrosamientoPleuralDifusoCalcificacionPerfil
      },
      new Parameter()
      {
        Name = "engrosamiento_pleural_difuso_calcificacion_frente",
        Type = DbType.String,
        Value = (object) risInformeOIT.engrosamientoPleuralDifusoCalcificacionFrente
      },
      new Parameter()
      {
        Name = "engrosamiento_pleural_difuso_extencion_pared1",
        Type = DbType.String,
        Value = (object) risInformeOIT.engrosamientoPleuralDifusoExtencionPared1
      },
      new Parameter()
      {
        Name = "engrosamiento_pleural_difuso_extencion_pared2",
        Type = DbType.String,
        Value = (object) risInformeOIT.engrosamientoPleuralDifusoExtencionPared2
      },
      new Parameter()
      {
        Name = "engrosamiento_pleural_difuso_ancho1",
        Type = DbType.String,
        Value = (object) risInformeOIT.engrosamientoPleuralDifusoAncho1
      },
      new Parameter()
      {
        Name = "engrosamiento_pleural_difuso_ancho2",
        Type = DbType.String,
        Value = (object) risInformeOIT.engrosamientoPleuralDifusoAncho2
      },
      new Parameter()
      {
        Name = "otras_anormalidades",
        Type = DbType.String,
        Value = (object) risInformeOIT.otrasAnormalidades
      },
      new Parameter()
      {
        Name = "simbolo_aa",
        Type = DbType.Int32,
        Value = (object) risInformeOIT.simbolo_aa
      },
      new Parameter()
      {
        Name = "simbolo_at",
        Type = DbType.Int32,
        Value = (object) risInformeOIT.simbolo_at
      },
      new Parameter()
      {
        Name = "simbolo_ax",
        Type = DbType.Int32,
        Value = (object) risInformeOIT.simbolo_ax
      },
      new Parameter()
      {
        Name = "simbolo_bu",
        Type = DbType.Int32,
        Value = (object) risInformeOIT.simbolo_bu
      },
      new Parameter()
      {
        Name = "simbolo_ca",
        Type = DbType.Int32,
        Value = (object) risInformeOIT.simbolo_ca
      },
      new Parameter()
      {
        Name = "simbolo_cg",
        Type = DbType.Int32,
        Value = (object) risInformeOIT.simbolo_cg
      },
      new Parameter()
      {
        Name = "simbolo_cn",
        Type = DbType.Int32,
        Value = (object) risInformeOIT.simbolo_cn
      },
      new Parameter()
      {
        Name = "simbolo_co",
        Type = DbType.Int32,
        Value = (object) risInformeOIT.simbolo_co
      },
      new Parameter()
      {
        Name = "simbolo_cp",
        Type = DbType.Int32,
        Value = (object) risInformeOIT.simbolo_cp
      },
      new Parameter()
      {
        Name = "simbolo_cv",
        Type = DbType.Int32,
        Value = (object) risInformeOIT.simbolo_cv
      },
      new Parameter()
      {
        Name = "simbolo_di",
        Type = DbType.Int32,
        Value = (object) risInformeOIT.simbolo_di
      },
      new Parameter()
      {
        Name = "simbolo_ef",
        Type = DbType.Int32,
        Value = (object) risInformeOIT.simbolo_ef
      },
      new Parameter()
      {
        Name = "simbolo_em",
        Type = DbType.Int32,
        Value = (object) risInformeOIT.simbolo_em
      },
      new Parameter()
      {
        Name = "simbolo_es",
        Type = DbType.Int32,
        Value = (object) risInformeOIT.simbolo_es
      },
      new Parameter()
      {
        Name = "simbolo_fr",
        Type = DbType.Int32,
        Value = (object) risInformeOIT.simbolo_fr
      },
      new Parameter()
      {
        Name = "simbolo_hi",
        Type = DbType.Int32,
        Value = (object) risInformeOIT.simbolo_hi
      },
      new Parameter()
      {
        Name = "simbolo_ho",
        Type = DbType.Int32,
        Value = (object) risInformeOIT.simbolo_ho
      },
      new Parameter()
      {
        Name = "simbolo_id",
        Type = DbType.Int32,
        Value = (object) risInformeOIT.simbolo_id
      },
      new Parameter()
      {
        Name = "simbolo_ih",
        Type = DbType.Int32,
        Value = (object) risInformeOIT.simbolo_ih
      },
      new Parameter()
      {
        Name = "simbolo_kl",
        Type = DbType.Int32,
        Value = (object) risInformeOIT.simbolo_kl
      },
      new Parameter()
      {
        Name = "simbolo_me",
        Type = DbType.Int32,
        Value = (object) risInformeOIT.simbolo_me
      },
      new Parameter()
      {
        Name = "simbolo_pa",
        Type = DbType.Int32,
        Value = (object) risInformeOIT.simbolo_pa
      },
      new Parameter()
      {
        Name = "simbolo_pb",
        Type = DbType.Int32,
        Value = (object) risInformeOIT.simbolo_pb
      },
      new Parameter()
      {
        Name = "simbolo_pi",
        Type = DbType.Int32,
        Value = (object) risInformeOIT.simbolo_pi
      },
      new Parameter()
      {
        Name = "simbolo_px",
        Type = DbType.Int32,
        Value = (object) risInformeOIT.simbolo_px
      },
      new Parameter()
      {
        Name = "simbolo_ra",
        Type = DbType.Int32,
        Value = (object) risInformeOIT.simbolo_ra
      },
      new Parameter()
      {
        Name = "simbolo_rp",
        Type = DbType.Int32,
        Value = (object) risInformeOIT.simbolo_rp
      },
      new Parameter()
      {
        Name = "simbolo_tb",
        Type = DbType.Int32,
        Value = (object) risInformeOIT.simbolo_tb
      },
      new Parameter()
      {
        Name = "simbolo_od",
        Type = DbType.Int32,
        Value = (object) risInformeOIT.simbolo_od
      },
      new Parameter()
      {
        Name = "comentario_general",
        Type = DbType.String,
        Value = (object) risInformeOIT.comentarioGeneral
      },
      new Parameter()
      {
        Name = "fecha_lectura",
        Type = DbType.DateTime,
        Value = (object) risInformeOIT.fechaLectura
      },
      new Parameter()
      {
        Name = "codexamen",
        Type = DbType.String,
        Value = (object) risInformeOIT.codexamen
      },
      new Parameter()
      {
        Name = "estado",
        Type = DbType.Int32,
        Value = (object) risInformeOIT.estado
      },
      new Parameter()
      {
        Name = "radiologoValidador",
        Type = DbType.String,
        Value = (object) risInformeOIT.RadiologoValidador
      }
    }, "sp_Multiris_RisInformeOIT_Save", "CN_RISPACS");

        public static long UpdateEstado(RisExamenDomain risExamen) => (long)DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "id_ris_examen",
        Type = DbType.String,
        Value = (object) risExamen.codexamen
      },
      new Parameter()
      {
        Name = "vcIdRisExamen",
        Type = DbType.Int32,
        Value = (object) risExamen.id_ris_examen
      }
    }, "sp_RisExamen_UpdateEliminar", "CN_RISPACS");

        public static RisExamenDomain GetByIdAndAcc(long id_ris_examen, string numeroacceso)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter()
            {
                Name = nameof(id_ris_examen),
                Type = DbType.Int32,
                Value = (object)id_ris_examen
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(numeroacceso),
                Type = DbType.String,
                Value = (object)numeroacceso
            });
            RisExamenDomain risExamenDomain = new RisExamenDomain();
            return DataBaseProcedure.GetEntidad<RisExamenDomain>(parameters, "sp_RisExamen_GetByIdAndAcc", "CN_RISPACS") ?? new RisExamenDomain();
        }

        public static RisExamenDomain GetByIdAndAcc2(long id_ris_examen)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter()
            {
                Name = nameof(id_ris_examen),
                Type = DbType.Int32,
                Value = (object)id_ris_examen
            });
            RisExamenDomain risExamenDomain = new RisExamenDomain();
            return DataBaseProcedure.GetEntidad<RisExamenDomain>(parameters, "sp_RisExamen_GetByIdAndAcc2", "CN_RISPACS") ?? new RisExamenDomain();
        }

        public static RisExamenDomain GetByInstitucionCodExamen(long id_institucion, string aetitle, string cod_examen)
        {
            List<Parameter> parameters = new List<Parameter>();

            parameters.Add(new Parameter() { Name = nameof(id_institucion), Type = DbType.Int32, Value = (object)id_institucion });
            parameters.Add(new Parameter() { Name = nameof(cod_examen), Type = DbType.String, Value = (object)cod_examen });
            parameters.Add(new Parameter() { Name = nameof(aetitle), Type = DbType.String, Value = (object)aetitle });
            RisExamenDomain risExamenDomain = new RisExamenDomain();
            
            return DataBaseProcedure.GetEntidad<RisExamenDomain>(parameters, "sp_RisExamen_GetByInstitucionCodExamen", "CN_RISPACS") ?? new RisExamenDomain();
        }

        public static DataTable GetQuantityUsername(string username) => StoredProcedure.EjecutarProcedure(new List<Parameter>()
    {
      new Parameter()
      {
        Name = nameof (username),
        Type = DbType.String,
        Value = (object) username
      }
    }, "sp_RisExamen_GetQuantityUsername", "CN_RISPACS");

        public static long SaveAPI(RisExamenDomain risExamen) => (long)DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "id_ris_examen",
        Type = DbType.Int32,
        Value = (object) risExamen.id_ris_examen
      },
      new Parameter()
      {
        Name = "id_examen_remoto",
        Type = DbType.Int32,
        Value = (object) risExamen.id_examen_remoto
      },
      new Parameter()
      {
        Name = "codexamen",
        Type = DbType.String,
        Value = (object) risExamen.codexamen
      },
      new Parameter()
      {
        Name = "aetitle",
        Type = DbType.String,
        Value = (object) risExamen.aetitle
      },
      new Parameter()
      {
        Name = "numeroacceso",
        Type = DbType.String,
        Value = (object) risExamen.numeroacceso
      },
      new Parameter()
      {
        Name = "idpaciente",
        Type = DbType.String,
        Value = (object) risExamen.idpaciente
      },
      new Parameter()
      {
        Name = "nombre",
        Type = DbType.String,
        Value = (object) risExamen.nombre
      },
      new Parameter()
      {
        Name = "apellidopaterno",
        Type = DbType.String,
        Value = (object) risExamen.apellidopaterno
      },
      new Parameter()
      {
        Name = "apellidomaterno",
        Type = DbType.String,
        Value = (object) risExamen.apellidomaterno
      },
      new Parameter()
      {
        Name = "fechanacimiento",
        Type = DbType.DateTime,
        Value = (object) risExamen.fechanacimiento
      },
      new Parameter()
      {
        Name = "sexo",
        Type = DbType.String,
        Value = (object) risExamen.sexo
      },
      new Parameter()
      {
        Name = "fechaexamen",
        Type = DbType.DateTime,
        Value = (object) risExamen.fechaexamen
      },
      new Parameter()
      {
        Name = "modalidad",
        Type = DbType.String,
        Value = (object) risExamen.modalidad
      },
      new Parameter()
      {
        Name = "descripcion",
        Type = DbType.String,
        Value = (object) risExamen.descripcion
      },
      new Parameter()
      {
        Name = "idradiologo",
        Type = DbType.Int32,
        Value = (object) risExamen.idradiologo
      },
      new Parameter()
      {
        Name = "nombreradiologo",
        Type = DbType.String,
        Value = (object) risExamen.nombreradiologo
      },
      new Parameter()
      {
        Name = "fechaasignacion",
        Type = DbType.DateTime,
        Value = (object) risExamen.fechaasignacion
      },
      new Parameter()
      {
        Name = "edad",
        Type = DbType.String,
        Value = (object) risExamen.edad
      },
      new Parameter()
      {
        Name = "idorden",
        Type = DbType.String,
        Value = (object) risExamen.idorden
      },
      new Parameter()
      {
        Name = "idtipoorden",
        Type = DbType.String,
        Value = (object) risExamen.idtipoorden
      },
      new Parameter()
      {
        Name = "medicosolicitante",
        Type = DbType.String,
        Value = (object) risExamen.medicosolicitante
      },
      new Parameter()
      {
        Name = "fechavalidacion",
        Type = DbType.DateTime,
        Value = (object) risExamen.fechavalidacion
      },
      new Parameter()
      {
        Name = "horaexamen",
        Type = DbType.String,
        Value = (object) risExamen.horaexamen
      },
      new Parameter()
      {
        Name = "flagimagen",
        Type = DbType.Int32,
        Value = (object) risExamen.flagimagen
      },
      new Parameter()
      {
        Name = "usernameRadiologo",
        Type = DbType.String,
        Value = (object) risExamen.usernameRadiologo
      },
      new Parameter()
      {
        Name = "id_estado_examen",
        Type = DbType.Int32,
        Value = (object) risExamen.id_estado_examen
      },
      new Parameter()
      {
        Name = "id_institucion",
        Type = DbType.Int32,
        Value = (object) risExamen.id_institucion
      },
      new Parameter()
      {
        Name = "id_estado_sincronizado",
        Type = DbType.Int32,
        Value = (object) risExamen.id_estado_sincronizado
      },
      new Parameter()
      {
        Name = "bloqueado",
        Type = DbType.Int32,
        Value = (object) risExamen.bloqueado
      },
      new Parameter()
      {
        Name = "fecha_bloqueo",
        Type = DbType.DateTime,
        Value = (object) risExamen.fecha_bloqueo
      },
      new Parameter()
      {
        Name = "id_usuario_bloqueo",
        Type = DbType.Int32,
        Value = (object) risExamen.id_usuario_bloqueo
      },
      new Parameter()
      {
        Name = "instancias",
        Type = DbType.Int32,
        Value = (object) risExamen.instancias
      },
      new Parameter()
      {
        Name = "entregado",
        Type = DbType.Boolean,
        Value = (object) risExamen.entregado
      },
      new Parameter()
      {
        Name = "tecnologo",
        Type = DbType.Boolean,
        Value = (object) risExamen.entregado
      }
    }, "sp_RisExamen_SaveAPI", "CN_RISPACS");

        public static DataTable GetByFilterMultiRisWeb(
          int numero,
          string id_usuario,
          string numeroAcceso,
          string idpaciente,
          string nombre,
          string id_institucion,
          string id_estado_examen,
          string id_estado_informe,
          DateTime fechaDesde,
          DateTime fechahasta,
          string id_modalidad,
          string id_tipo_urgencia,
          string descripcion,
          int cantidad,
          int OrderDirection,
          int OrderByField,
          long usuarioConsulta,
          int rangoEtario,
          long usuarioBecado = 0)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter()
            {
                Name = "vcPagina",
                Type = DbType.Int32,
                Value = (object)numero
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(id_usuario),
                Type = DbType.String,
                Value = (object)id_usuario
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(numeroAcceso),
                Type = DbType.String,
                Value = (object)numeroAcceso
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(idpaciente),
                Type = DbType.String,
                Value = (object)idpaciente
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(nombre),
                Type = DbType.String,
                Value = (object)nombre
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(id_estado_examen),
                Type = DbType.String,
                Value = (object)id_estado_examen
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(id_estado_informe),
                Type = DbType.String,
                Value = (object)id_estado_informe
            });
            parameters.Add(new Parameter()
            {
                Name = "fechadesde",
                Type = DbType.DateTime,
                Value = (object)fechaDesde
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(fechahasta),
                Type = DbType.DateTime,
                Value = (object)fechahasta
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(id_institucion),
                Type = DbType.String,
                Value = (object)id_institucion
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(id_modalidad),
                Type = DbType.String,
                Value = (object)id_modalidad
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(id_tipo_urgencia),
                Type = DbType.String,
                Value = (object)id_tipo_urgencia
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(descripcion),
                Type = DbType.String,
                Value = (object)descripcion
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(cantidad),
                Type = DbType.Int32,
                Value = (object)cantidad
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(OrderDirection),
                Type = DbType.Int32,
                Value = (object)OrderDirection
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(OrderByField),
                Type = DbType.Int32,
                Value = (object)OrderByField
            });
            parameters.Add(new Parameter()
            {
                Name = "@usuarioConsulta",
                Type = DbType.Int64,
                Value = (object)usuarioConsulta
            });
            parameters.Add(new Parameter()
            {
                Name = "@usuarioBecado",
                Type = DbType.Int64,
                Value = (object)usuarioBecado
            });
            parameters.Add(new Parameter()
            {
                Name = "@rangoEtario",
                Type = DbType.Int32,
                Value = (object)rangoEtario
            });
            DataTable dataTable = new DataTable();
            return StoredProcedure.EjecutarProcedure(parameters, "sp_RisExamen_GetByFilterMultiRisWeb", "CN_RISPACS") ?? new DataTable();
        }

        public static DataTable GetByFilterMultiRisWebCRM(int perfilID, string userID, int numberPage, int cantidadRg, string numeroAcceso, string pacienteID, string nombre,
                                                          string fechaDesde, string fechaHasta, string institucionID, string estadoExamenID, string estadoInformeID, string modalidadID,
                                                          string tipoUrgenciaID, string descripcion, int rangoEtario, long usuarioConsulta, int pendiente, long usuarioBecado = 0)
        {
            List<Parameter> parameters = new List<Parameter>();

            parameters.Add(new Parameter() { Name = "PERFILID", Type = DbType.Int32, Value = (object)perfilID });
            parameters.Add(new Parameter() { Name = "USUARIOID", Type = DbType.String, Value = (object)userID });
            parameters.Add(new Parameter() { Name = "PAGINA", Type = DbType.Int32, Value = (object)numberPage });
            parameters.Add(new Parameter() { Name = "CANTIDAD", Type = DbType.Int32, Value = (object)cantidadRg });
            parameters.Add(new Parameter() { Name = "NUMACCESO", Type = DbType.String, Value = (object)numeroAcceso });
            parameters.Add(new Parameter() { Name = "PACIENTEID", Type = DbType.String, Value = (object)pacienteID });
            parameters.Add(new Parameter() { Name = "NOMBRE", Type = DbType.String, Value = (object)nombre });
            parameters.Add(new Parameter() { Name = "FECHADESDE", Type = DbType.String, Value = (object)fechaDesde });
            parameters.Add(new Parameter() { Name = "FECHAHASTA", Type = DbType.String, Value = (object)fechaHasta });
            parameters.Add(new Parameter() { Name = "INSTITUCION", Type = DbType.String, Value = (object)institucionID });
            parameters.Add(new Parameter() { Name = "ESTADOEXAMENID", Type = DbType.String, Value = (object)estadoExamenID });
            parameters.Add(new Parameter() { Name = "ESTADOINFORME", Type = DbType.String, Value = (object)estadoInformeID });
            parameters.Add(new Parameter() { Name = "MODALIDAD", Type = DbType.String, Value = (object)modalidadID });
            parameters.Add(new Parameter() { Name = "TIPOURGENCIA", Type = DbType.String, Value = (object)tipoUrgenciaID });
            parameters.Add(new Parameter() { Name = "DESCRIPCION", Type = DbType.String, Value = (object)descripcion });
            parameters.Add(new Parameter() { Name = "RANGOETARIO", Type = DbType.String, Value = (object)rangoEtario });
            parameters.Add(new Parameter() { Name = "REQUESTUSER", Type = DbType.Int64, Value = (object)usuarioConsulta });
            parameters.Add(new Parameter() { Name = "PENDIENTE", Type = DbType.Int32, Value = (object)pendiente });
            parameters.Add(new Parameter() { Name = "USERBECADO", Type = DbType.Int64, Value = (object)usuarioBecado });

            DataTable dataTable = new DataTable();

            return StoredProcedure.EjecutarProcedure(parameters, "SP_RisExamen_GetByFilterMultiRisWeb_CRM", "CN_RISPACS") ?? new DataTable();
        }

        public static DataTable GetMultiRisWebPaginadoCRM(int perfilID, string userID, string numeroAcceso, string pacienteID, string nombre, string institucionID,
                                                          string estadoExamenID, string estadoInformeID, string fechaDesde, string fechaHasta, string modalidadID,
                                                          string tipoUrgenciaID, string descripcion, int rangoEtario, long usuarioConsulta, int pendiente, long becado)
        {
            List<Parameter> parameters = new List<Parameter>();

            parameters.Add(new Parameter() { Name = "PERFILID", Type = DbType.Int32, Value = (object)perfilID });
            parameters.Add(new Parameter() { Name = "USUARIOID", Type = DbType.String, Value = (object)userID });
            parameters.Add(new Parameter() { Name = "NUMACCESO", Type = DbType.String, Value = (object)numeroAcceso });
            parameters.Add(new Parameter() { Name = "PACIENTEID", Type = DbType.String, Value = (object)pacienteID });
            parameters.Add(new Parameter() { Name = "NOMBRE", Type = DbType.String, Value = (object)nombre });
            parameters.Add(new Parameter() { Name = "FECHADESDE", Type = DbType.String, Value = (object)fechaDesde });
            parameters.Add(new Parameter() { Name = "FECHAHASTA", Type = DbType.String, Value = (object)fechaHasta });
            parameters.Add(new Parameter() { Name = "INSTITUCION", Type = DbType.String, Value = (object)institucionID });
            parameters.Add(new Parameter() { Name = "ESTADOEXAMENID", Type = DbType.String, Value = (object)estadoExamenID });
            parameters.Add(new Parameter() { Name = "ESTADOINFORME", Type = DbType.String, Value = (object)estadoInformeID });
            parameters.Add(new Parameter() { Name = "MODALIDAD", Type = DbType.String, Value = (object)modalidadID });
            parameters.Add(new Parameter() { Name = "TIPOURGENCIA", Type = DbType.String, Value = (object)tipoUrgenciaID });
            parameters.Add(new Parameter() { Name = "DESCRIPCION", Type = DbType.String, Value = (object)descripcion });
            parameters.Add(new Parameter() { Name = "RANGOETARIO", Type = DbType.String, Value = (object)rangoEtario });
            parameters.Add(new Parameter() { Name = "REQUESTUSER", Type = DbType.Int64, Value = (object)usuarioConsulta });
            parameters.Add(new Parameter() { Name = "PENDIENTE", Type = DbType.String, Value = (object)pendiente });
            parameters.Add(new Parameter() { Name = "USERBECADO", Type = DbType.Int64, Value = (object)becado });

            DataTable dataTable = new DataTable();

            return StoredProcedure.EjecutarProcedure(parameters, "SP_RisExamen_GetPaginadoMultiRisWeb_CRM", "CN_RISPACS") ?? new DataTable();
        }

        public static DataTable GetByFilterMultiRisWebCalculoTiempo(
          int numero,
          string id_usuario,
          string numeroAcceso,
          string idpaciente,
          string nombre,
          string id_institucion,
          string id_estado_examen,
          string id_estado_informe,
          DateTime fechaDesde,
          DateTime fechahasta,
          string id_modalidad,
          string id_tipo_urgencia,
          string descripcion)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter()
            {
                Name = "vcPagina",
                Type = DbType.Int32,
                Value = (object)numero
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(id_usuario),
                Type = DbType.String,
                Value = (object)id_usuario
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(numeroAcceso),
                Type = DbType.String,
                Value = (object)numeroAcceso
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(idpaciente),
                Type = DbType.String,
                Value = (object)idpaciente
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(nombre),
                Type = DbType.String,
                Value = (object)nombre
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(id_estado_examen),
                Type = DbType.String,
                Value = (object)id_estado_examen
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(id_estado_informe),
                Type = DbType.String,
                Value = (object)id_estado_informe
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(fechaDesde),
                Type = DbType.DateTime,
                Value = (object)fechaDesde
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(fechahasta),
                Type = DbType.DateTime,
                Value = (object)fechahasta
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(id_institucion),
                Type = DbType.String,
                Value = (object)id_institucion
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(id_modalidad),
                Type = DbType.String,
                Value = (object)id_modalidad
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(id_tipo_urgencia),
                Type = DbType.String,
                Value = (object)id_tipo_urgencia
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(descripcion),
                Type = DbType.String,
                Value = (object)descripcion
            });
            DataTable dataTable = new DataTable();
            return StoredProcedure.EjecutarProcedure(parameters, "sp_RisExamen_GetByFilterMultiRisWebCalculoTiempo", "CN_RISPACS") ?? new DataTable();
        }

        public static DataTable GetByFilterMultiRisWebCalculoTiempoPaginado(
          int numero,
          string id_usuario,
          string numeroAcceso,
          string idpaciente,
          string nombre,
          string id_institucion,
          string id_estado_examen,
          string id_estado_informe,
          DateTime fechaDesde,
          DateTime fechahasta,
          string id_modalidad,
          string id_tipo_urgencia,
          string descripcion)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter()
            {
                Name = "vcPagina",
                Type = DbType.Int32,
                Value = (object)numero
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(id_usuario),
                Type = DbType.String,
                Value = (object)id_usuario
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(numeroAcceso),
                Type = DbType.String,
                Value = (object)numeroAcceso
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(idpaciente),
                Type = DbType.String,
                Value = (object)idpaciente
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(nombre),
                Type = DbType.String,
                Value = (object)nombre
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(id_estado_examen),
                Type = DbType.String,
                Value = (object)id_estado_examen
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(id_estado_informe),
                Type = DbType.String,
                Value = (object)id_estado_informe
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(fechaDesde),
                Type = DbType.DateTime,
                Value = (object)fechaDesde
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(fechahasta),
                Type = DbType.DateTime,
                Value = (object)fechahasta
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(id_institucion),
                Type = DbType.String,
                Value = (object)id_institucion
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(id_modalidad),
                Type = DbType.String,
                Value = (object)id_modalidad
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(id_tipo_urgencia),
                Type = DbType.String,
                Value = (object)id_tipo_urgencia
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(descripcion),
                Type = DbType.String,
                Value = (object)descripcion
            });
            DataTable dataTable = new DataTable();
            return StoredProcedure.EjecutarProcedure(parameters, "spMultiRisWebPaginadoExamenes", "CN_RISPACS") ?? new DataTable();
        }

        public static DataTable GetByFilterMultiRisWebParaComentarios(string codExamen)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter()
            {
                Name = "vcCodExamen",
                Type = DbType.String,
                Value = (object)codExamen
            });
            DataTable dataTable = new DataTable();
            return StoredProcedure.EjecutarProcedure(parameters, "sp_RisExamen_GetByFilterMultiRisWebComentarios", "CN_RISPACS") ?? new DataTable();
        }

        public static DataTable GetByFilterMultiRisWebParaAcciones(int id_ris_examen)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter()
            {
                Name = nameof(id_ris_examen),
                Type = DbType.Int32,
                Value = (object)id_ris_examen
            });
            DataTable dataTable = new DataTable();
            return StoredProcedure.EjecutarProcedure(parameters, "sp_RisExamen_GetByFilterMultiRisWebAcciones", "CN_RISPACS") ?? new DataTable();
        }

        public static DataTable GetByFilterHonorariosWeb(DateTime fechaInicio, DateTime fechaFinal, string usuario)
        {
            return StoredProcedure.EjecutarProcedure(new List<Parameter>() {
                new Parameter() { Name = "vcFechaInicio", Type = DbType.DateTime, Value = (object) fechaInicio },
                new Parameter() { Name = "vcFechaFin", Type = DbType.DateTime, Value = (object) fechaFinal },
                new Parameter() { Name = nameof (usuario), Type = DbType.String, Value = (object) usuario }
            }, "sp_RisWeb_ObtenerHonorarios", "CN_RISPACS");
        }

        public static DataTable GetByFilterHonorariosWebPaginado(
          int numero,
          string fechaInicio,
          string fechaFinal,
          string usuario)
        {
            return StoredProcedure.EjecutarProcedure(new List<Parameter>()
      {
        new Parameter()
        {
          Name = "vcPagina",
          Type = DbType.Int32,
          Value = (object) numero
        },
        new Parameter()
        {
          Name = "vcFechaInicio",
          Type = DbType.String,
          Value = (object) fechaInicio
        },
        new Parameter()
        {
          Name = nameof (usuario),
          Type = DbType.String,
          Value = (object) usuario
        }
      }, "sp_RisExamen_GetLogAsignacionPaginado", "CN_RISPACS");
        }

        public static DataTable GetByFilterHonorariosWebPaginadoFecha(
          int numero,
          DateTime fechaInicio,
          DateTime fechaFinal,
          string usuario)
        {
            return StoredProcedure.EjecutarProcedure(new List<Parameter>()
      {
        new Parameter()
        {
          Name = "vcPagina",
          Type = DbType.Int32,
          Value = (object) numero
        },
        new Parameter()
        {
          Name = "vcFechaInicio",
          Type = DbType.DateTime,
          Value = (object) fechaInicio
        },
        new Parameter()
        {
          Name = "vcFechaFin",
          Type = DbType.DateTime,
          Value = (object) fechaFinal
        },
        new Parameter()
        {
          Name = nameof (usuario),
          Type = DbType.String,
          Value = (object) usuario
        }
      }, "sp_RisExamen_GetLogAsignacionPaginado", "CN_RISPACS");
        }

        public static DataTable GetByLogAsignacionesWebPagPaginado(
          int numero,
          string fechaInicio,
          string fechaFinal)
        {
            return StoredProcedure.EjecutarProcedure(new List<Parameter>()
      {
        new Parameter()
        {
          Name = "vcPagina",
          Type = DbType.Int32,
          Value = (object) numero
        },
        new Parameter()
        {
          Name = "vcFechaInicio",
          Type = DbType.String,
          Value = (object) fechaInicio
        },
        new Parameter()
        {
          Name = "vcFechaFin",
          Type = DbType.String,
          Value = (object) fechaFinal
        }
      }, "sp_RisExamen_GetLogAsignacionPaginado", "CN_RISPACS");
        }

        public static DataTable GetByFilterHonorariosWebPag(
          int numero,
          DateTime fechaInicio,
          DateTime fechaFinal,
          string usuario)
        {
            return StoredProcedure.EjecutarProcedure(new List<Parameter>()
      {
        new Parameter()
        {
          Name = "vcPagina",
          Type = DbType.Int32,
          Value = (object) numero
        },
        new Parameter()
        {
          Name = "vcFechaInicio",
          Type = DbType.DateTime,
          Value = (object) fechaInicio
        },
        new Parameter()
        {
          Name = "vcFechaFin",
          Type = DbType.DateTime,
          Value = (object) fechaFinal
        },
        new Parameter()
        {
          Name = nameof (usuario),
          Type = DbType.String,
          Value = (object) usuario
        }
      }, "sp_RisWeb_ObtenerHonorariosPag", "CN_RISPACS");
        }

        public static DataTable GetByLogAsignacionesWebPag(
          int numero,
          string fechaInicio,
          string fechaFinal)
        {
            return StoredProcedure.EjecutarProcedure(new List<Parameter>()
      {
        new Parameter()
        {
          Name = "vcPagina",
          Type = DbType.Int32,
          Value = (object) numero
        },
        new Parameter()
        {
          Name = "vcFechaInicio",
          Type = DbType.String,
          Value = (object) fechaInicio
        },
        new Parameter()
        {
          Name = "vcFechaFin",
          Type = DbType.String,
          Value = (object) fechaFinal
        }
      }, "sp_RisExamen_GetLogAsignacion", "CN_RISPACS");
        }

        public static DataTable GetByFilterMultiRisWebDatosPaginado(
          int numero,
          string id_usuario,
          string numeroAcceso,
          string idpaciente,
          string nombre,
          string id_institucion,
          string id_estado_examen,
          string id_estado_informe,
          DateTime fechaDesde,
          DateTime fechahasta,
          string id_modalidad,
          string id_tipo_urgencia,
          string descripcion,
          int cantidad,
          int rangoEtario)
        {
            return StoredProcedure.EjecutarProcedure(new List<Parameter>()
      {
        new Parameter()
        {
          Name = "vcPagina",
          Type = DbType.Int32,
          Value = (object) numero
        },
        new Parameter()
        {
          Name = nameof (id_usuario),
          Type = DbType.String,
          Value = (object) id_usuario
        },
        new Parameter()
        {
          Name = nameof (numeroAcceso),
          Type = DbType.String,
          Value = (object) numeroAcceso
        },
        new Parameter()
        {
          Name = nameof (idpaciente),
          Type = DbType.String,
          Value = (object) idpaciente
        },
        new Parameter()
        {
          Name = nameof (nombre),
          Type = DbType.String,
          Value = (object) nombre
        },
        new Parameter()
        {
          Name = nameof (id_estado_examen),
          Type = DbType.String,
          Value = (object) id_estado_examen
        },
        new Parameter()
        {
          Name = nameof (id_estado_informe),
          Type = DbType.String,
          Value = (object) id_estado_informe
        },
        new Parameter()
        {
          Name = "fechadesde",
          Type = DbType.DateTime,
          Value = (object) fechaDesde
        },
        new Parameter()
        {
          Name = nameof (fechahasta),
          Type = DbType.DateTime,
          Value = (object) fechahasta
        },
        new Parameter()
        {
          Name = nameof (id_institucion),
          Type = DbType.String,
          Value = (object) id_institucion
        },
        new Parameter()
        {
          Name = nameof (id_modalidad),
          Type = DbType.String,
          Value = (object) id_modalidad
        },
        new Parameter()
        {
          Name = nameof (id_tipo_urgencia),
          Type = DbType.String,
          Value = (object) id_tipo_urgencia
        },
        new Parameter()
        {
          Name = nameof (descripcion),
          Type = DbType.String,
          Value = (object) descripcion
        },
        new Parameter()
        {
          Name = nameof (cantidad),
          Type = DbType.Int32,
          Value = (object) cantidad
        },
        new Parameter()
        {
          Name = nameof (rangoEtario),
          Type = DbType.Int32,
          Value = (object) rangoEtario
        }
      }, "spMultiRisWebPaginadoExamenes", "CN_RISPACS");
        }

        public static DataTable GetByFilterePrestacionesWeb(string filtro) => StoredProcedure.EjecutarProcedure(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "vcFiltro",
        Type = DbType.String,
        Value = (object) filtro
      }
    }, "sp_RisWeb_ObtenerPrestaciones", "CN_RISPACS");

        public static DataTable GetByFilterePrestacionesWebTiempo(string filtro) => StoredProcedure.EjecutarProcedure(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "vcFiltro",
        Type = DbType.String,
        Value = (object) filtro
      }
    }, "sp_RisWeb_ObtenerTiempo", "CN_RISPACS");

        public static int GetByInsertPrestacionesWeb(
          string idPrestacionRemoto,
          string nombreInstitucion,
          string nombrePrestacion,
          string codigo)
        {
            return DataBaseProcedure.GetInt(new List<Parameter>()
      {
        new Parameter()
        {
          Name = "vcIdPrestacionRemoto",
          Type = DbType.String,
          Value = (object) idPrestacionRemoto
        },
        new Parameter()
        {
          Name = "vcNombreInstitucion",
          Type = DbType.String,
          Value = (object) nombreInstitucion
        },
        new Parameter()
        {
          Name = "vcNombrePrestacion",
          Type = DbType.String,
          Value = (object) nombrePrestacion
        },
        new Parameter()
        {
          Name = nameof (codigo),
          Type = DbType.String,
          Value = (object) codigo
        }
      }, "sp_RisWeb_InsertarPrestacion", "CN_RISPACS");
        }

        public static int GetByUpdatePrestacionesWeb(
          string idPrestacion,
          string idPrestacionRemoto,
          string nombreInstitucion,
          string nombrePrestacion,
          string codigo)
        {
            return DataBaseProcedure.GetInt(new List<Parameter>()
      {
        new Parameter()
        {
          Name = "vcIdPrestacionRemoto",
          Type = DbType.String,
          Value = (object) idPrestacionRemoto
        },
        new Parameter()
        {
          Name = "vcNombreInstitucion",
          Type = DbType.String,
          Value = (object) nombreInstitucion
        },
        new Parameter()
        {
          Name = "vcNombrePrestacion",
          Type = DbType.String,
          Value = (object) nombrePrestacion
        },
        new Parameter()
        {
          Name = nameof (codigo),
          Type = DbType.String,
          Value = (object) codigo
        }
      }, "sp_RisWeb_InsertarPrestacion", "CN_RISPACS");
        }

        public static int GetByCreatePrestacionesWebTiempo(
          string nombreInstitucion,
          string nombreUrgencia,
          string tiempo)
        {
            return DataBaseProcedure.GetInt(new List<Parameter>()
      {
        new Parameter()
        {
          Name = "vcNombreInstitucion",
          Type = DbType.String,
          Value = (object) nombreInstitucion
        },
        new Parameter()
        {
          Name = "vcNombreUrgencia",
          Type = DbType.String,
          Value = (object) nombreUrgencia
        },
        new Parameter()
        {
          Name = "vcTiempoInstitucion",
          Type = DbType.String,
          Value = (object) tiempo
        }
      }, "sp_RisWeb_CreatePrestacionTiempo", "CN_RISPACS");
        }

        public static int GetByUpdatePrestacionesWebTiempo(
          string id,
          string nombreInstitucion,
          string nombreUrgencia,
          string tiempo)
        {
            return DataBaseProcedure.GetInt(new List<Parameter>()
      {
        new Parameter()
        {
          Name = "vcId",
          Type = DbType.String,
          Value = (object) id
        },
        new Parameter()
        {
          Name = "vcTiempoInstitucion",
          Type = DbType.String,
          Value = (object) tiempo
        },
        new Parameter()
        {
          Name = "vcNombreInstitucion",
          Type = DbType.String,
          Value = (object) nombreInstitucion
        },
        new Parameter()
        {
          Name = "vcNombreUrgencia",
          Type = DbType.String,
          Value = (object) nombreUrgencia
        }
      }, "sp_RisWeb_UpdatePrestacionTiempo", "CN_RISPACS");
        }

        public static RisExamenDomain GetByCodExamenAetitleIdExamen(
          string codExamen,
          string aetitle,
          long id_examen_remoto)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter()
            {
                Name = nameof(codExamen),
                Type = DbType.String,
                Value = (object)codExamen
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(aetitle),
                Type = DbType.String,
                Value = (object)aetitle
            });
            parameters.Add(new Parameter()
            {
                Name = nameof(id_examen_remoto),
                Type = DbType.Int32,
                Value = (object)id_examen_remoto
            });
            RisExamenDomain risExamenDomain = new RisExamenDomain();
            return DataBaseProcedure.GetEntidad<RisExamenDomain>(parameters, "sp_RisExamen_GetByCodExamenAetitleIdExamen", "CN_RISPACS") ?? new RisExamenDomain();
        }

        public static RisExamenDomain GetByCodExamen(string codExamen)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter()
            {
                Name = nameof(codExamen),
                Type = DbType.String,
                Value = (object)codExamen
            });
            RisExamenDomain risExamenDomain = new RisExamenDomain();
            return DataBaseProcedure.GetEntidad<RisExamenDomain>(parameters, "sp_RisExamen_GetByCodExamen", "CN_RISPACS") ?? new RisExamenDomain();
        }

        public static IList<RisExamenDomain> GetListNoEntregado() => (IList<RisExamenDomain>)DataBaseProcedure.ListEntidad<RisExamenDomain>(new List<Parameter>(), "sp_RisExamen_GetListNoEntregado", "CN_RISPACS");

        public static RisExamenDomain GetById(long id_ris_examen)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter()
            {
                Name = nameof(id_ris_examen),
                Type = DbType.Int32,
                Value = (object)id_ris_examen
            });
            RisExamenDomain risExamenDomain = new RisExamenDomain();
            return DataBaseProcedure.GetEntidad<RisExamenDomain>(parameters, "sp_RisExamen_GetById", "CN_RISPACS") ?? new RisExamenDomain();
        }

        public static int GetExamenConteo(string codeExamen) => DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "codExamen",
        Type = DbType.String,
        Value = (object) codeExamen
      }
    }, "sp_RisInforme_GetByCodExamenCount", "CN_RISPACS");

        public static string GetExamenAetitle(string codeExamen) => DataBaseProcedure.GetString(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "codExamen",
        Type = DbType.String,
        Value = (object) codeExamen
      }
    }, "sp_RisInforme_GetByCodExamenAetitle", "CN_RISPACS");

        private static RisExamenDomain BuildFunction(IDataReader row) => new RisExamenDomain()
        {
            id_ris_examen = row["id_ris_examen"] != DBNull.Value ? (long)row["id_ris_examen"] : 0L,
            id_examen_remoto = row["id_examen_remoto"] != DBNull.Value ? (long)row["id_examen_remoto"] : 0L,
            codexamen = row["codexamen"] != DBNull.Value ? (string)row["codexamen"] : string.Empty,
            aetitle = row["aetitle"] != DBNull.Value ? (string)row["aetitle"] : string.Empty,
            numeroacceso = row["numeroacceso"] != DBNull.Value ? (string)row["numeroacceso"] : string.Empty,
            idpaciente = row["idpaciente"] != DBNull.Value ? (string)row["idpaciente"] : string.Empty,
            nombre = row["nombre"] != DBNull.Value ? (string)row["nombre"] : string.Empty,
            apellidopaterno = row["apellidopaterno"] != DBNull.Value ? (string)row["apellidopaterno"] : string.Empty,
            apellidomaterno = row["apellidomaterno"] != DBNull.Value ? (string)row["apellidomaterno"] : string.Empty,
            fechanacimiento = row["fechanacimiento"] != DBNull.Value ? (DateTime)row["fechanacimiento"] : new DateTime(1900, 1, 1),
            sexo = row["sexo"] != DBNull.Value ? (string)row["sexo"] : string.Empty,
            fechaexamen = row["fechaexamen"] != DBNull.Value ? (DateTime)row["fechaexamen"] : new DateTime(1900, 1, 1),
            modalidad = row["modalidad"] != DBNull.Value ? (string)row["modalidad"] : string.Empty,
            descripcion = row["descripcion"] != DBNull.Value ? (string)row["descripcion"] : string.Empty,
            idradiologo = row["idradiologo"] != DBNull.Value ? (int)row["idradiologo"] : 0,
            nombreradiologo = row["nombreradiologo"] != DBNull.Value ? (string)row["nombreradiologo"] : string.Empty,
            fechaasignacion = row["fechaasignacion"] != DBNull.Value ? (DateTime)row["fechaasignacion"] : new DateTime(1900, 1, 1),
            edad = row["edad"] != DBNull.Value ? (string)row["edad"] : string.Empty,
            idorden = row["idorden"] != DBNull.Value ? (string)row["idorden"] : string.Empty,
            idtipoorden = row["idtipoorden"] != DBNull.Value ? (string)row["idtipoorden"] : string.Empty,
            medicosolicitante = row["medicosolicitante"] != DBNull.Value ? (string)row["medicosolicitante"] : string.Empty,
            fechavalidacion = row["fechavalidacion"] != DBNull.Value ? (DateTime)row["fechavalidacion"] : new DateTime(1900, 1, 1),
            horaexamen = row["horaexamen"] != DBNull.Value ? (string)row["horaexamen"] : string.Empty,
            flagimagen = row["flagimagen"] != DBNull.Value ? (int)row["flagimagen"] : 0,
            usernameRadiologo = row["usernameRadiologo"] != DBNull.Value ? (string)row["usernameRadiologo"] : string.Empty,
            id_estado_examen = row["id_estado_examen"] != DBNull.Value ? (int)row["id_estado_examen"] : 0,
            id_institucion = row["id_institucion"] != DBNull.Value ? (int)row["id_institucion"] : 0,
            bloqueado = row["bloqueado"] != DBNull.Value ? (int)row["bloqueado"] : 0,
            fecha_bloqueo = row["fecha_bloqueo"] != DBNull.Value ? (DateTime)row["fecha_bloqueo"] : new DateTime(1900, 1, 1),
            id_usuario_bloqueo = row["id_usuario_bloqueo"] != DBNull.Value ? (int)row["id_usuario_bloqueo"] : 0,
            instancias = row["instancias"] != DBNull.Value ? (int)row["instancias"] : 0,
            entregado = row["entregado"] != DBNull.Value && (bool)row["entregado"]
        };

        public static bool DesbloqueoExamen(long idExamen)
        {
            List<IradDBNet.Dto.Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter() { Name = "@idExamen", Type = DbType.Int64, Value = idExamen });

            return IradDBNet.DataBaseProcedure.GetInt(parameters, "sp_RisExamen_Desbloqueo", "CN_RISPACS") > 0;
        }
    }
}
