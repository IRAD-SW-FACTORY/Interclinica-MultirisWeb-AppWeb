using IradDBNet;
using IradDBNet.Dao;
using IradDBNet.Dto;
using MultiRisWeb.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiRisWeb.Data.DataAccess
{
    public class CategoriaDataAccess
    {
        public static IList<CategoriaDomain> GetAll() => (IList<CategoriaDomain>) DataBaseProcedure.ListEntidad<CategoriaDomain>(new List<Parameter>(), "SP_LISTA_CATEGORIA_PENDIENTE_CRM", "CN_RISPACS");
    }
}
