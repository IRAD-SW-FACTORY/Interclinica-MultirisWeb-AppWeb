using IradDBNet;
using IradDBNet.Dao;
using IradDBNet.Dto;
using MultiRisWeb.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiRisWeb.Data.DataAccess
{
    public class EstadoPendienteDataAccess
    {
        public static DataTable GetAll() => StoredProcedure.EjecutarProcedure(new List<Parameter>(), "SP_LISTA_ESTADO_PENDIENTE_CRM", "CN_RISPACS");

        public static List<EstadoPendienteDomain> Get() =>  DataBaseProcedure.ListEntidad<EstadoPendienteDomain>(new List<Parameter>(), "SP_LISTA_ESTADO_PENDIENTE_CRM", "CN_RISPACS");
    }
}
