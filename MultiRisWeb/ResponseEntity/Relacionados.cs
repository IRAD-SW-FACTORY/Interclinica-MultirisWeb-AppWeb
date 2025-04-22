using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultiRisWeb.ResponseEntity
{
    public class Relacionados
    {
        public string fecha_examen { get; set; }
        public string descripcion { get; set; }
        public string modalidad { get; set; }
        public string informe { get; set; }
        public string descargar_examen { get; set; }
        public string visualizadores { get; set; }
        public string id_institucion { get; set; }
        public string id_paciente { get; set; }
        public string identificador { get; set; }
    }
}