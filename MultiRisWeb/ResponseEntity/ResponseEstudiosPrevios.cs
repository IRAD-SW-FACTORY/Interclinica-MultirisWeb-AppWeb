using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultiRisWeb.ResponseEntity
{
    public class ResponseEstudiosPrevios
    {
        public string IdPaciente { get; set; }
        public string Centro { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public string Modalidad { get; set; }
        public string Visores { get; set; }
        public string CodExamen { get; set; }
        public int IdInstitucion { get; set; }
        public string Url { get; set; }
        public string FechaText
        {
            get
            {
                return Fecha.ToString("dd-MM-yyyy HH:mm") + " hrs.";
            }
        }
    }
}