// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.RisAddendumDomain
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using System;

namespace MultiRisWeb.Data.Domain
{
  public class RisAddendumDomain
  {
    public long id_addendum { get; set; }

    public long id_addendum_remoto { get; set; }

    public long id_informe { get; set; }

    public string username { get; set; }

    public string cod_examen { get; set; }

    public DateTime fecha_hora { get; set; }

    public string addendum { get; set; }

    public int estado_visible { get; set; }

    public int estado_bloqueo { get; set; }

    public int flag_patologia_grave { get; set; }

    public string patologia_grave { get; set; }

    public RisAddendumDomain()
    {
      this.id_addendum = 0L;
      this.id_addendum_remoto = 0L;
      this.id_informe = 0L;
      this.username = string.Empty;
      this.cod_examen = string.Empty;
      this.fecha_hora = new DateTime(1900, 1, 1);
      this.addendum = string.Empty;
      this.estado_visible = 1;
      this.estado_bloqueo = 0;
      this.flag_patologia_grave = 0;
      this.patologia_grave = string.Empty;
    }
  }
}
