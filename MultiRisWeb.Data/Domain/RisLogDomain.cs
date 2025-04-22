// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.RisLogDomain
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using System;

namespace MultiRisWeb.Data.Domain
{
  public class RisLogDomain
  {
    public long id_log { get; set; }

    public string sistema { get; set; }

    public string observacion { get; set; }

    public int id_institucion { get; set; }

    public string codexamen { get; set; }

    public long id_ris_examen { get; set; }

    public DateTime fecha { get; set; }

    public long id_usuario { get; set; }

    public long tipoAccion { get; set; }

    public RisLogDomain()
    {
      this.id_log = 0L;
      this.sistema = string.Empty;
      this.observacion = string.Empty;
      this.id_institucion = 0;
      this.codexamen = string.Empty;
      this.id_ris_examen = 0L;
      this.fecha = DateTime.Now;
      this.id_usuario = 0L;
      this.tipoAccion = 0L;
    }
  }
}
