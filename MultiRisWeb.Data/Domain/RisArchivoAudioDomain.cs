using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiRisWeb.Data.Domain
{
    public class RisArchivoAudioDomain
    {
        public long id_audio { get; set; }
        public long id_ris_examen { get; set; }
        public string codexamen { get; set; }
        public int id_institucion { get; set; }
        public string nombre_original { get; set; }
        public string nombre_archivo { get; set; }
        public string tipo_archivo { get; set; }
        public long tamano_bytes { get; set; }
        public int id_usuario_creacion { get; set; }
        public string fecha_creacion { get; set; }
        public string username { get; set; }
        public string aetitle { get; set; }

        public RisArchivoAudioDomain()
        {
            this.id_audio = 0L;
            this.id_ris_examen = 0L;
            this.codexamen = string.Empty;
            this.id_institucion = 0;
            this.nombre_original = string.Empty;
            this.nombre_archivo = string.Empty;
            this.tipo_archivo = string.Empty;
            this.tamano_bytes = 0L;
            this.id_usuario_creacion = 0;
            this.fecha_creacion = string.Empty;
            this.username = string.Empty;
            this.aetitle = string.Empty;
        }

        public static List<RisArchivoAudioDomain> ConvertTo(DataTable table)
        {
            var lista = new List<RisArchivoAudioDomain>();

            foreach (DataRow row in table.Rows)
                lista.Add(new RisArchivoAudioDomain()
                {
                    id_audio = Convert.ToInt64(row["id_audio"].ToString()),
                    id_ris_examen = Convert.ToInt64(row["id_ris_examen"].ToString()),
                    codexamen = row["codexamen"].ToString(),
                    id_institucion = Convert.ToInt32(row["id_institucion"].ToString()),
                    nombre_original = row["nombre_original"].ToString(),
                    nombre_archivo = row["nombre_archivo"].ToString(),
                    tipo_archivo = row["tipo_archivo"].ToString(),
                    tamano_bytes = Convert.ToInt64(row["tamano_bytes"].ToString()),
                    id_usuario_creacion = Convert.ToInt32(row["id_usuario_creacion"].ToString()),
                    fecha_creacion = row["fecha_creacion"].ToString(),
                    username = row["username"].ToString(),
                    aetitle = table.Columns.Contains("aetitle") ? row["aetitle"].ToString() : string.Empty
                });

            return lista;
        }
    }
}
