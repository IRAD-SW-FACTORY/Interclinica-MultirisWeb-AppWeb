using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiRisWeb.Data.Domain
{
    public class EstadoPendienteDomain
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public int orden { get; set; }
        public bool vigencia  { get; set; }
        public bool visible  { get; set; }
    }
}
