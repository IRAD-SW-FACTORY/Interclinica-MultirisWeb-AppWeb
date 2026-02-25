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
    public class RisArchivoAudioDataAccess
    {
        /// <summary>
        /// Inserta un registro de audio. Retorna id_audio o -1 si se alcanzó el límite de 10.
        /// </summary>
        public static long Set(RisArchivoAudioDomain domain) => (long)DataBaseProcedure.GetInt(new List<Parameter>() {
            new Parameter() 
            { 
                Name = "@ID_RIS_EXAMEN", 
                Type = DbType.Int64, 
                Value = domain.id_ris_examen 
            },
            new Parameter() 
            { 
                Name = "@CODEXAMEN", 
                Type = DbType.String, 
                Value = domain.codexamen 
            },
            new Parameter() 
            { 
                Name = "@ID_INSTITUCION", 
                Type = DbType.Int32, 
                Value = domain.id_institucion 
            },
            new Parameter() 
            { 
                Name = "@NOMBRE_ORIGINAL", 
                Type = DbType.String, 
                Value = domain.nombre_original 
            },
            new Parameter() 
            { 
                Name = "@NOMBRE_ARCHIVO", 
                Type = DbType.String,
                Value = domain.nombre_archivo 
            },
            new Parameter() 
            { 
                Name = "@TIPO_ARCHIVO", 
                Type = DbType.String, 
                Value = domain.tipo_archivo 
            },
            new Parameter() 
            { 
                Name = "@TAMANO_BYTES", 
                Type = DbType.Int64, 
                Value = domain.tamano_bytes 
            },
            new Parameter() { 
                Name = "@ID_USUARIO_CREACION", 
                Type = DbType.Int32, 
                Value = domain.id_usuario_creacion 
            }
        }, "sp_RisAudio_InsertAudioExamen", "CN_RISPACS");

        /// <summary>
        /// Lista audios activos por codexamen e institución.
        /// </summary>
        public static DataTable Get(string codexamen, int id_institucion)
        {
            var parameters = new List<Parameter>()
            {
                new Parameter() 
                { 
                    Name = "@CODEXAMEN", 
                    Type = DbType.String, 
                    Value = codexamen 
                },
                new Parameter() 
                { 
                    Name = "@ID_INSTITUCION", 
                    Type = DbType.Int32, 
                    Value = id_institucion 
                }
            };

            return StoredProcedure.EjecutarProcedure(parameters, "sp_RisAudio_GetByCodExamen", "CN_RISPACS") ?? new DataTable();
        }

        /// <summary>
        /// Soft delete de un audio. Retorna DataTable con nombre_archivo, codexamen, id_institucion para borrado físico.
        /// </summary>
        public static DataTable Delete(long id_archivo_audio, int id_usuario_eliminacion)
        {
            var parameters = new List<Parameter>()
            {
                new Parameter() 
                { 
                    Name = "@ID_ARCHIVO_AUDIO", 
                    Type = DbType.Int64, 
                    Value = id_archivo_audio 
                },
                new Parameter() 
                { 
                    Name = "@ID_USUARIO_ELIMINACION", 
                    Type = DbType.Int32, 
                    Value = id_usuario_eliminacion 
                }
            };

            return StoredProcedure.EjecutarProcedure(parameters, "sp_RisAudio_DeleteByID", "CN_RISPACS") ?? new DataTable();
        }
    }
}
