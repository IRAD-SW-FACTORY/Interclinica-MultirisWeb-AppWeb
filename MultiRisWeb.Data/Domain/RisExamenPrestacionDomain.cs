// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.RisExamenPrestacionDomain
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

namespace MultiRisWeb.Data.Domain
{
  public class RisExamenPrestacionDomain
  {
    public long id_examen_prestacion { get; set; }

    public long id_examen_prestacion_remoto { get; set; }

    public long id_prestacion_remoto { get; set; }

    public long id_prestacion { get; set; }

    public string codExamen { get; set; }

    public string username { get; set; }

    public long id_ris_examen { get; set; }

    public int id_institucion { get; set; }

    public RisExamenPrestacionDomain()
    {
      this.id_examen_prestacion = 0L;
      this.id_examen_prestacion_remoto = 0L;
      this.id_prestacion_remoto = 0L;
      this.id_prestacion = 0L;
      this.codExamen = string.Empty;
      this.username = string.Empty;
      this.id_ris_examen = 0L;
      this.id_institucion = 0;
    }
  }
}
