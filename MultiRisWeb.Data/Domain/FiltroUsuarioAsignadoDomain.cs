using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiRisWeb.Data.Domain
{
    public class FiltroUsuarioAsignadoDomain
    {
        public int id { get; set; }
        public long id_usuario { get; set; }
        public long id_filtro { get; set; }
    }
}
