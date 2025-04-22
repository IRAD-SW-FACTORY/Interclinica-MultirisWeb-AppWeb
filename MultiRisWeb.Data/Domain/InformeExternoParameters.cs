// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.InformeExternoCabeceraParameters
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using System;
using System.Collections.Generic;

namespace MultiRisWeb.Data.Domain
{
  public class InformeExternoCabeceraParameters
  {
    public long IdInforme { get; set; }

    public string CodigoHis { get; set; }

    public string NombreInforme { get; set; }

    public string CodExamen { get; set; }

    public string IdPaciente { get; set; }

    public DateTime FechaValidacion { get; set; }

    public int IdEstado { get; set; }

    public string Estado { get; set; }

    public int IdRadiologo { get; set; }

    public string UserNameRadiologo { get; set; }

    public string NombreRadiologo { get; set; }

    public int FlagPatologiaGrave { get; set; }

    public string PatologiaGrave { get; set; }

    public List<prestacionesExternasParameters> prestacionesExternas { get; set; }

    public InformeExternoCabeceraParameters()
    {
      this.IdInforme = 0L;
      this.CodigoHis = string.Empty;
      this.NombreInforme = string.Empty;
      this.CodExamen = string.Empty;
      this.IdPaciente = string.Empty;
      this.FechaValidacion = DateTime.Now;
      this.IdEstado = 0;
      this.Estado = string.Empty;
      this.IdRadiologo = 0;
      this.UserNameRadiologo = string.Empty;
      this.NombreRadiologo = string.Empty;
      this.FlagPatologiaGrave = 0;
      this.PatologiaGrave = string.Empty;
      this.prestacionesExternas = new List<prestacionesExternasParameters>();
    }
  }
}
