using MultiRisWeb.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiRisWeb.Data.DataAccess
{
    public class LogControlAccesoDataAccess
    {
        public static bool Insertar(LogControlAccesoDomain logControlAcceso)
        {
            List<IradDBNet.Dto.Parameter> parameters = new List<IradDBNet.Dto.Parameter>();
            parameters.Add(new IradDBNet.Dto.Parameter() { Name = "@usuario", Type = System.Data.DbType.String, Value = logControlAcceso.Usuario });
            parameters.Add(new IradDBNet.Dto.Parameter() { Name = "@nombre", Type = System.Data.DbType.String, Value = logControlAcceso.Nombre });
            parameters.Add(new IradDBNet.Dto.Parameter() { Name = "@perfil", Type = System.Data.DbType.Int32, Value = logControlAcceso.Perfil });
            parameters.Add(new IradDBNet.Dto.Parameter() { Name = "@userAgent", Type = System.Data.DbType.String, Value = logControlAcceso.UserAgent });
            parameters.Add(new IradDBNet.Dto.Parameter() { Name = "@ip", Type = System.Data.DbType.String, Value = logControlAcceso.Ip });

            return IradDBNet.DataBaseProcedure.GetInt(parameters, "sp_log_control_acceso_insert", "CN_RISPACS") > 0;
        }
    }
}
