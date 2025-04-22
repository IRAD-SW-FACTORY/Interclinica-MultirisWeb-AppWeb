// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.TituloPacienteAperturaInformeDataAccess
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using IradDBNet;
using IradDBNet.Dto;
using MultiRisWeb.Data.Models;
using System.Collections.Generic;
using System.Data;

namespace MultiRisWeb.Data.DataAccess
{
  public class TituloPacienteAperturaInformeDataAccess
  {
    public static List<ResponseTituloPacienteInforme> Listar(long idExamen) => DataBaseProcedure.ListEntidad<ResponseTituloPacienteInforme>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "@idExamen",
        Type = DbType.Int64,
        Value = (object) idExamen
      }
    }, "spUpdateInfoTituloPaciente", "CN_RISPACS");

    public static bool AperturarInforme(long idInforme) => DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "@idInforme",
        Type = DbType.Int64,
        Value = (object) idInforme
      }
    }, "spAperturarInforme", "CN_RISPACS") > 0;

    public static bool UpdateTitulo(long idInforme, string titulo) => DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "@idInforme",
        Type = DbType.Int64,
        Value = (object) idInforme
      },
      new Parameter()
      {
        Name = "@titulo",
        Type = DbType.String,
        Value = (object) titulo
      }
    }, "spUpdateTituloInforme", "CN_RISPACS") > 0;

    public static bool UpdatePaciente(
      long idExamen,
      string idPaciente,
      string nombre,
      string paterno,
      string materno,
      string genero)
    {
      return DataBaseProcedure.GetInt(new List<Parameter>()
      {
        new Parameter()
        {
          Name = "@idExamen",
          Type = DbType.Int64,
          Value = (object) idExamen
        },
        new Parameter()
        {
          Name = "@idPaciente",
          Type = DbType.String,
          Value = (object) idPaciente
        },
        new Parameter()
        {
          Name = "@nombre",
          Type = DbType.String,
          Value = (object) nombre
        },
        new Parameter()
        {
          Name = "@paterno",
          Type = DbType.String,
          Value = (object) paterno
        },
        new Parameter()
        {
          Name = "@materno",
          Type = DbType.String,
          Value = (object) materno
        },
        new Parameter()
        {
          Name = "@genero",
          Type = DbType.String,
          Value = (object) genero
        }
      }, "spUpdatePacienteInforme", "CN_RISPACS") > 0;
    }
  }
}
