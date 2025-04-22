// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.RisInformePrestacionDomain
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using System;

namespace MultiRisWeb.Data.Domain
{
  public class RisInformePrestacionDomain
  {
    public long id_informe_prestacion { get; set; }

    public long id_ris_informe_prestacion_remoto { get; set; }

    public long id_informe { get; set; }

    public long id_prestacion { get; set; }

    public DateTime fecha { get; set; }

    public int id_institucion { get; set; }

    public RisInformePrestacionDomain()
    {
      this.id_informe_prestacion = 0L;
      this.id_ris_informe_prestacion_remoto = 0L;
      this.id_informe = 0L;
      this.id_prestacion = 0L;
      this.fecha = new DateTime();
      this.id_institucion = 0;
    }
  }
}
