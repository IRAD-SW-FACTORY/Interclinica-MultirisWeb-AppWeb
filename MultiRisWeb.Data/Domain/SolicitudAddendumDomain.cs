// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.SolicitudAddendumDomain
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using System;

namespace MultiRisWeb.Data.Domain
{
  public class SolicitudAddendumDomain
  {
    public long id_solicitud_addendum { get; set; }

    public int id_institucion { get; set; }

    public string codexamen { get; set; }

    public long id_ris_examen { get; set; }

    public string usuario { get; set; }

    public string motivo { get; set; }

    public int id_estado_addendum { get; set; }

    public DateTime fecha_solicitud { get; set; }

    public DateTime fecha_resolucion { get; set; }

    public SolicitudAddendumDomain()
    {
      this.id_solicitud_addendum = 0L;
      this.id_institucion = 0;
      this.codexamen = string.Empty;
      this.id_ris_examen = 0L;
      this.usuario = string.Empty;
      this.motivo = string.Empty;
      this.id_estado_addendum = 0;
      this.fecha_solicitud = new DateTime(1900, 1, 1);
      this.fecha_resolucion = new DateTime(1900, 1, 1);
    }
  }
}
