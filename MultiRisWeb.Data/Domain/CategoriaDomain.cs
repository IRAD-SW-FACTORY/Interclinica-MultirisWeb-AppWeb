using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiRisWeb.Data.Domain
{
    public class CategoriaDomain /*Domains Class Catergoria Pendiente*/
    {
        public int ID_CATEGORIA { get; set; }
        public string DESCRIPCION { get; set; }
        public int ORDEN { get; set; }
        public bool VIGENCIA { get; set; }
    }
}
