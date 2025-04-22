using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiRisWeb.Data.Domain
{
    public class ChatDomain
    {
        public long risExamen { get; set; }
        public long usuarioCreador { get; set; }
        public int categoriaId { get; set; }
        public string fechaCreacion { get; set; }
        public string mensaje { get; set; }
        public int tipoMensajeId { get; set; }
    }

    public class MessageDomain
    {
        public string mensaje { get; set; }
        public string nombreusuario { get; set; }
        public string fechaHoraEnvio { get; set; }
        public int tipoMensajeId { get; set; }

        public static List<MessageDomain> ConvertTo(DataTable table)
        {
            List<MessageDomain> lista = new List<MessageDomain>();

            foreach (DataRow row in table.Rows)
                lista.Add(new MessageDomain()
                {
                    mensaje = row["texto_mensaje"].ToString(),
                    nombreusuario = row["nombre"].ToString(),
                    fechaHoraEnvio = row["fecha_hora_envio"].ToString(),
                    tipoMensajeId = Convert.ToInt16(row["id_tipo_mensaje"].ToString())
                });

            return lista;
        }

    }
}
