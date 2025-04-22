using MultiRisWeb.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiRisWeb.Data.DataAccess
{
    public class LogMeddreamsDataAccess
    {
        public static bool Insertar(LogMeddreamsDomain logMeddreams)
        {
            List<IradDBNet.Dto.Parameter> parameters = new List<IradDBNet.Dto.Parameter>();
            parameters.Add(new IradDBNet.Dto.Parameter() { Name = "@usuario", Type = System.Data.DbType.String, Value = logMeddreams.Usuario });
            parameters.Add(new IradDBNet.Dto.Parameter() { Name = "@fecha", Type = System.Data.DbType.DateTime, Value = logMeddreams.Fecha });
            parameters.Add(new IradDBNet.Dto.Parameter() { Name = "@codExamen", Type = System.Data.DbType.String, Value = logMeddreams.CodExamen });
            parameters.Add(new IradDBNet.Dto.Parameter() { Name = "@idPaciente", Type = System.Data.DbType.String, Value = logMeddreams.IdPaciente });
            parameters.Add(new IradDBNet.Dto.Parameter() { Name = "@NombrePaciente", Type = System.Data.DbType.String, Value = logMeddreams.NombrePaciente });
            parameters.Add(new IradDBNet.Dto.Parameter() { Name = "@TipoAtencion", Type = System.Data.DbType.String, Value = logMeddreams.TipoAtencion });
            parameters.Add(new IradDBNet.Dto.Parameter() { Name = "@EsInformeActual", Type = System.Data.DbType.Int32, Value = logMeddreams.EsInformeActual });
            parameters.Add(new IradDBNet.Dto.Parameter() { Name = "@FechaExamen", Type = System.Data.DbType.DateTime, Value = logMeddreams.FechaExamen });
            parameters.Add(new IradDBNet.Dto.Parameter() { Name = "@FechaAsignacion", Type = System.Data.DbType.DateTime, Value = logMeddreams.FechaAsignacion });

            return IradDBNet.DataBaseProcedure.GetInt(parameters, "sp_LogMeddreams_Insert", "CN_RISPACS") > 0;
        }
    }
}
