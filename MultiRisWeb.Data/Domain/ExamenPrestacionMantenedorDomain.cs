// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.ExamenPrestacionMantenedorDomain
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using System;

namespace MultiRisWeb.Data.Domain
{
  public class ExamenPrestacionMantenedorDomain
  {
    public long IdExamen { get; set; }

    public long IdExamenRemoto { get; set; }

    public string Rut { get; set; }

    public string Nombre { get; set; }

    public string Edad { get; set; }

    public string Institucion { get; set; }

    public DateTime FechaExamen { get; set; }

    public string Radiologo { get; set; }

    public int IdEstado { get; set; }

    public string CodExamen { get; set; }

    public int IdInstitucion { get; set; }

    public long IdPrestacion { get; set; }

    public long IdPrestacionRemoto { get; set; }

    public string NombrePrestacion { get; set; }

    public string CodigoPrestacion { get; set; }

    public long IdExamenPrestacion { get; set; }

    public string FechaExamenText => this.FechaExamen.ToString("dd-MM-yyyy HH:mm");

    public string Estado
    {
      get
      {
        switch (this.IdEstado)
        {
          case 0:
            return "Nuevo";
          case 2:
            return "Informado";
          case 3:
            return "Validado";
          case 6:
            return "Validacion Parcial";
          case 9:
            return "Pendiente";
          case 10:
            return "Eliminado";
          default:
            return "";
        }
      }
    }
  }
}
