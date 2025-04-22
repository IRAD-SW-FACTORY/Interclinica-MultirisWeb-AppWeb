// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.FiltroEstadoInformeDomain
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

namespace MultiRisWeb.Data.Domain
{
  public class FiltroEstadoInformeDomain
  {
    public long id_filtro_estado_informe { get; set; }

    public int id_estado_informe { get; set; }

    public long id_filtro { get; set; }

    public FiltroEstadoInformeDomain()
    {
      this.id_filtro_estado_informe = 0L;
      this.id_estado_informe = 0;
      this.id_filtro = 0L;
    }
  }
}
