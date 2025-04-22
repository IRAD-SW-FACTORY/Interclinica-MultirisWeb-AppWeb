using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultiRisWeb.ResponseEntity
{
    public class Documentos
    {
        public string id { get; set; }
        public string descripcion { get; set; }
        public string filename { get; set; }
        public string webfolder { get; set; }
        public string fecha { get; set; }
        public string size { get; set; }
        public string archivo { get; set; }
        public string url { get; set; }
    }
}