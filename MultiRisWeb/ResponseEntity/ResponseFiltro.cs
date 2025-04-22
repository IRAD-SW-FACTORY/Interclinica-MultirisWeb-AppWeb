using System;
using System.Collections.Generic;

namespace MultiRisWeb.ResponseEntity
{
    public class ResponseFiltro
    {
        public long IdFiltro { get; set; }
        public int IdEstado { get; set; }
        public string Nombre { get; set; }
        public List<long> Instituciones { get; set; }
        public List<long> Modalidades { get; set; }
        public List<long> Atenciones { get; set; }
        public List<long> EstadosExamenes { get; set; }
        public List<long> UsuariosAsignados { get; set; }
    }
}