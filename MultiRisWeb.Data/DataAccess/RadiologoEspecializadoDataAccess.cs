// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.RadiologoEspecializadoDataAccess
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using IradDBNet;
using IradDBNet.Dto;
using System.Collections.Generic;
using System.Data;

namespace MultiRisWeb.Data.DataAccess
{
  public class RadiologoEspecializadoDataAccess
  {
    public static ResultEjecucion ProcesarRelacionRadiologoEspecializado(
      long idMedicoEspecializado,
      List<long> radiologos)
    {
      List<Parameter> parameterList = new List<Parameter>();
      List<ProcedurePrincipal> procedures = new List<ProcedurePrincipal>();
      int num1 = 0;
      parameterList.Add(new Parameter()
      {
        Name = "@idMedicoEspecializado",
        Type = DbType.Int64,
        Value = (object) idMedicoEspecializado
      });
      List<ProcedurePrincipal> procedurePrincipalList = procedures;
      ProcedurePrincipal procedurePrincipal = new ProcedurePrincipal();
      procedurePrincipal.IdParametroResult = 0;
      procedurePrincipal.NombreConexionDb = "CN_RISPACS";
      procedurePrincipal.NombreParametroResult = "";
      procedurePrincipal.NombreProcedure = "spDeleteUsuarioRadiologoEspecializado";
      int num2 = num1;
      int num3 = num2 + 1;
      procedurePrincipal.OrdenEjecucion = num2;
      procedurePrincipal.Parametros = parameterList;
      procedurePrincipal.ProceduresPrincipalSecundario = (List<ProcedurePrincipalSecundario>) null;
      procedurePrincipalList.Add(procedurePrincipal);
      foreach (long radiologo in radiologos)
        procedures.Add(new ProcedurePrincipal()
        {
          IdParametroResult = 0,
          NombreConexionDb = "CN_RISPACS",
          NombreParametroResult = "",
          NombreProcedure = "spInsertUsuarioRadiologoEspecializado",
          OrdenEjecucion = num3++,
          Parametros = new List<Parameter>()
          {
            new Parameter()
            {
              Name = "@idRadiologo",
              Type = DbType.Int64,
              Value = (object) radiologo
            },
            new Parameter()
            {
              Name = "@idMedicoEspecializado",
              Type = DbType.Int64,
              Value = (object) idMedicoEspecializado
            }
          },
          ProceduresPrincipalSecundario = (List<ProcedurePrincipalSecundario>) null
        });
      return DataBaseMultipleProcedure.EjecucionSecuencial(procedures);
    }
  }
}
