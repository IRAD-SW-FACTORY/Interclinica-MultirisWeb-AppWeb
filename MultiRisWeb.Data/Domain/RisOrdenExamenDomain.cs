// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.RisOrdenExamenDomain
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

namespace MultiRisWeb.Data.Domain
{
  public class RisOrdenExamenDomain
  {
    public long id_ris_orden_examen { get; set; }

    public long id_orden_examen_remoto { get; set; }

    public int id_institucion { get; set; }

    public string observaciones { get; set; }

    public string antecedentes_clinicos { get; set; }

    public RisOrdenExamenDomain()
    {
      this.id_ris_orden_examen = 0L;
      this.id_orden_examen_remoto = 0L;
      this.id_institucion = 0;
      this.observaciones = string.Empty;
      this.antecedentes_clinicos = string.Empty;
    }
  }
}
