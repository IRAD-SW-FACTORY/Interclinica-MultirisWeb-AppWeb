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
    public class FiltroUsuarioAsignadoDataAccess
    {
        public static bool Insert(long idFiltro, long idUsuario)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter() { Name = "@idFiltro", Type = DbType.Int64, Value = idFiltro });
            parameters.Add(new Parameter() { Name = "@idUsuario", Type = DbType.Int64, Value = idUsuario });

            return IradDBNet.DataBaseProcedure.GetInt(parameters, "sp_FiltroUsuarioAsignadoInsert", "CN_RISPACS") > 0;
        }

        public static bool Delete(long idFiltro)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter() { Name = "@idFiltro", Type = DbType.Int64, Value = idFiltro });

            return IradDBNet.DataBaseProcedure.GetInt(parameters, "sp_FiltroUsuarioAsignadoDelete", "CN_RISPACS") > 0;
        }

        public static List<FiltroUsuarioAsignadoDomain> Listar(long idFiltro)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter() { Name = "@idFiltro", Type = DbType.Int64, Value = idFiltro });

            return IradDBNet.DataBaseProcedure.ListEntidad<FiltroUsuarioAsignadoDomain>(parameters, "sp_UsuarioAsignadoListar", "CN_RISPACS");
        }
    }
}
