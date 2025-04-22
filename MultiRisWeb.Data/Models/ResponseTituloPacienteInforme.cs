// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Models.ResponseTituloPacienteInforme
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using System;

namespace MultiRisWeb.Data.Models
{
  public class ResponseTituloPacienteInforme
  {
    public long IdExamen { get; set; }

    public string Rut { get; set; }

    public string Nombre { get; set; }

    public string ApellidoPaterno { get; set; }

    public string ApellidoMaterno { get; set; }

    public string Genero { get; set; }

    public string Institucion { get; set; }

    public DateTime FechaExamen { get; set; }

    public string Radiologo { get; set; }

    public int IdEstadoExamen { get; set; }

    public string TituloInforme { get; set; }

    public long IdInforme { get; set; }

    public string EstadoExamen { get; set; }

    public int IdEstadoInforme { get; set; }

    public string FechaExamenText => this.FechaExamen.ToString("dd-MM-yyyy HH:mm") + " hrs.";
  }
}
