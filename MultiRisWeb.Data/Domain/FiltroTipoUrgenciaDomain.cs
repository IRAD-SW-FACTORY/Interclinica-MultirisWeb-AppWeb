// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.FiltroTipoUrgenciaDomain
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

namespace MultiRisWeb.Data.Domain
{
  public class FiltroTipoUrgenciaDomain
  {
    public long id_filtro_tipo_urgencia { get; set; }

    public int id_tipo_urgencia { get; set; }

    public long id_filtro { get; set; }

    public FiltroTipoUrgenciaDomain()
    {
      this.id_filtro_tipo_urgencia = 0L;
      this.id_tipo_urgencia = 0;
      this.id_filtro = 0L;
    }
  }
}
