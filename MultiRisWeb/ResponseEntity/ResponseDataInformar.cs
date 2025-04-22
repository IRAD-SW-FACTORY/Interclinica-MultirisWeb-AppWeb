using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultiRisWeb.ResponseEntity
{
    public class ResponseDataInformar
    {
        public long IdUsuario { get; set; }
        public string UserName { get; set; }
        public string Clave { get; set; }
        public int IdInstitucion { get; set; }
        public string CodExamen { get; set; }
        public long IdInforme { get; set; }
        public int SelectedPatologiaCritica { get; set; }
        public long[] IdPrestacion { get; set; }
        public long IdRisExamen { get; set; }
        public string[] Val { get; set; }

        public ResponseDataInformar()
        {
            IdUsuario = 0;
            UserName = string.Empty;
            Clave = string.Empty;
            IdInstitucion = 0;
            CodExamen = string.Empty;
            IdInforme = 0;
            SelectedPatologiaCritica = -2;
            IdPrestacion = null;
            IdRisExamen = 0;
            Val = null;
        }
    }
}