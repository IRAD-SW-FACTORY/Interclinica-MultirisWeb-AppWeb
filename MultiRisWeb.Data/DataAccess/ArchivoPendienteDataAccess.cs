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
    public class ArchivoPendienteDataAccess
    {
        public static long Set(ArchivoDomain domain) => (long)DataBaseProcedure.GetInt(new List<Parameter>() {
            new Parameter() { Name = "@RISEXAMEN", Type = DbType.Int32, Value = domain.id_ris_examen_canal },
            new Parameter() { Name = "@NOMBREARCHIVO", Type = DbType.String, Value = domain.nombre },
            new Parameter() { Name = "@USUARIOCREACION", Type = DbType.Int32, Value = domain.usuarioEnvio },
            new Parameter() { Name = "@TIPO", Type = DbType.String, Value = domain.tipoMensajeId }
        }, "SP_INSERTA_ARCHIVO_CANAL_PENDIENTE_CRM", "CN_RISPACS");

        public static DataTable Get(ArchivoDomain domain) {
            var parameters = new List<Parameter>() {
                new Parameter() { Name = "@RISEXAMEN", Type = DbType.Int32, Value = domain.id_ris_examen_canal }
            };

            return StoredProcedure.EjecutarProcedure(parameters, "SP_LISTA_CHAT_ARCHIVOS_PENDIENTE_CRM", "CN_RISPACS") ?? new DataTable();
        }

        public static long Put(ArchivoDomain domain) => (long)DataBaseProcedure.GetInt(new List<Parameter>() {
            new Parameter() { Name = "@RISEXAMEN", Type = DbType.Int32, Value = domain.id_ris_examen_canal },
            new Parameter() { Name = "@IDARCHIVO", Type = DbType.String, Value = domain.id_archivo },
            new Parameter() { Name = "@IDUSUARIO", Type = DbType.Int32, Value = domain.usuarioEnvio }
        }, "SP_UPDATE_ARCHIVOS_PENDIENTE_CRM", "CN_RISPACS");
    }
}
