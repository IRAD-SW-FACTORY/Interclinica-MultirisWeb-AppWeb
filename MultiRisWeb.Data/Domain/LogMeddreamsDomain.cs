using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiRisWeb.Data.Domain
{
    public class LogMeddreamsDomain
    {
        public int IdLogMeddreams { get; set; }
        public string Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public string CodExamen { get; set; }
        public string IdPaciente { get; set; }
        public string NombrePaciente { get; set; }
        public string TipoAtencion { get; set; }
        public int EsInformeActual { get; set; }
        public DateTime FechaExamen { get; set; }
        public DateTime FechaAsignacion { get; set; }
    }
}
