using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiRisWeb.Data.Domain
{
    public class FiltroGeneralDomain
    {
        public long IdFiltro { get; set; }
        public string Nombre { get; set; }
        public int IdEstado { get; set; }
        public long CantidadUso { get; set; }
        public DateTime FechaUltimoAcceso { get; set; }
        public int CantidadAsignado { get; set; }
        public string Estado
        {
            get
            {
                return IdEstado == 1 ? "Vigente" : "No Vigente";
            }
        }
        public string FechaText
        {
            get
            {
                return FechaUltimoAcceso == null || FechaUltimoAcceso.Year == 1900 || CantidadUso == 0 ? "--" : FechaUltimoAcceso.ToString("dd-MM-yyyy HH:mm") + " hrs.";
            }
        }
    }
}
