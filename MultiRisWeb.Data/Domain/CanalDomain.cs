using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiRisWeb.Data.Domain
{
    public class CanalDomain
	{
        public Int64 id_ris_examen_canal { get; set; }
        public int id_usuario_creador { get; set; }
        public string nombre_usuario_creador { get; set; }
        public int id_categoria { get; set; }
        public string descripcion_categoria { get; set; }
        public string fecha_creacion { get; set; }
        public string fecha_cierre { get; set; }
        public int id_usuario_cierre { get; set; }
        public string nombre_usuario_cierre { get; set; }
        public int tiempo_transcurrido { get; set; }
        public int comunicate { get; set; }
    }
}
