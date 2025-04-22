using MultiRisWeb.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiRisWeb.Data.DataAccess
{
    public class FiltroGeneralDataAccess
    {
        public static List<FiltroGeneralDomain> Listar(long idUsuario, int idEstado)
        {
            List<IradDBNet.Dto.Parameter> parameters = new List<IradDBNet.Dto.Parameter>();
            parameters.Add(new IradDBNet.Dto.Parameter() { Name = "@idUsuario", Type = System.Data.DbType.Int64, Value = idUsuario });
            parameters.Add(new IradDBNet.Dto.Parameter() { Name = "@idEstado", Type = System.Data.DbType.Int32, Value = idEstado });

            return IradDBNet.DataBaseProcedure.ListEntidad<FiltroGeneralDomain>(parameters, "sp_FiltroListar", "CN_RISPACS");
        }
    }
}
