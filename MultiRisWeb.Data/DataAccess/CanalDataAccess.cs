using IradDBNet;
using IradDBNet.Dao;
using IradDBNet.Dto;
using MultiRisWeb.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiRisWeb.Data.DataAccess
{
    public class CanalDataAccess
    {
        public static CanalDomain Get(string ris_examen, int usuario)
        {
            List<Parameter> parameters = new List<Parameter>();

            parameters.Add(new Parameter() { Name = "@IDRISEXAMEN", Type = DbType.String, Value = ris_examen });
            parameters.Add(new Parameter() { Name = "@IDUSUARIO", Type = DbType.String, Value = usuario });


            return DataBaseProcedure.GetEntidad<CanalDomain>(parameters, "SP_LISTA_CANAL_COMUNICACION_PENDIENTE_CRM", "CN_RISPACS") ?? new CanalDomain();
        }

        public static long Set(ChatDomain chatMultiris) => (long)DataBaseProcedure.GetInt(new List<Parameter>() {
            new Parameter() { Name = "@RISEXAMEN", Type = DbType.Int32, Value = chatMultiris.risExamen },
            new Parameter() { Name = "@USUARIOCREADOR", Type = DbType.Int32, Value = chatMultiris.usuarioCreador },
            new Parameter() { Name = "@CATEGORIA", Type = DbType.Int32, Value = chatMultiris.categoriaId },
            new Parameter() { Name = "@FECHACREACION", Type = DbType.String, Value = chatMultiris.fechaCreacion },
            new Parameter() { Name = "@MENSAJE", Type = DbType.String, Value = (object) chatMultiris.mensaje },
            new Parameter() { Name = "@TIPO", Type = DbType.Int32, Value = (object) chatMultiris.tipoMensajeId }
        }, "SP_INSERTA_CANAL_COMUNICACION_PENDIENTE_CRM", "CN_RISPACS");

        public static DataTable Get(Int32 ris_examen)
        {
            List<Parameter> parameters = new List<Parameter>();

            Parameter param = new Parameter() { Name = "@RISEXAMEN", Type = DbType.Int32, Value = ris_examen };

            parameters.Add(param);

            return StoredProcedure.EjecutarProcedure(parameters, "SP_LISTA_CHAT_COMUNICACION_PENDIENTE_CRM", "CN_RISPACS") ?? new DataTable();
        }
       
        /// <summary>
        /// Metodo de grabación, actualiza los estados a cerrados y pone fecha de cierre de la comunicacion 
        /// </summary>
        /// <param name="ris_examen"></param>
        /// <param name="estado"></param>
        /// <param name="usuario"></param>
        /// <returns>0/1</returns>
        public static long Set(string ris_examen, int estado, int usuario ) => (long)DataBaseProcedure.GetInt(new List<Parameter>() {
            new Parameter() { Name = "@RISEXAMEN", Type = DbType.Int32, Value = ris_examen },
            new Parameter() { Name = "@ESTADO", Type = DbType.Int32, Value = estado },
            new Parameter() { Name = "@USUARIOCIERRE", Type = DbType.Int32, Value = usuario }
        }, "SP_UPDATE_ESTADO_PENDIENTE_CRM", "CN_RISPACS");
    }
}
