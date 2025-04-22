using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiRisWeb.Data.Domain
{
    public class ArchivoDomain
    {
        public long id_ris_examen_canal { get; set; }
        public long id_archivo { get; set; }
        public string nombre { get; set; }
        public string fechaEnvio { get; set; }
        public long usuarioEnvio { get; set; }
        public string nombreUsuarioEnvio { get; set; }
        public string fechalectura { get; set; }
        public long usuarioLectura { get; set; }
        public string nombreUsuarioLectura { get; set; }
        public int tipoMensajeId { get; set; }

        public static List<ArchivoDomain> ConvertTo(DataTable table) 
        {
            var lista = new List<ArchivoDomain>();

            foreach (DataRow row in table.Rows)
                lista.Add(new ArchivoDomain()
                {
                    id_ris_examen_canal = Convert.ToInt64(row["id_ris_examen_canal"].ToString()),
                    id_archivo = Convert.ToInt64(row["id_archivo"].ToString()),
                    nombre = row["nombre"].ToString(),
                    fechaEnvio = row["fecha_envio"].ToString(),
                    usuarioEnvio = Convert.ToInt64(row["id_usuario_envio"].ToString()),
                    nombreUsuarioEnvio = row["usuarioenvio"].ToString(),
                    fechalectura = row["fecha_lectura"].ToString(),
                    usuarioLectura = Convert.ToInt64(row["id_usuario_lectura"].ToString()),
                    nombreUsuarioLectura = row["usuariolectura"].ToString(),
                    tipoMensajeId = Convert.ToInt16(row["id_tipo_mensaje"].ToString())
                });

            return lista;
        }
    }
}
