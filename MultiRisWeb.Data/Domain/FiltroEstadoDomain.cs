// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.FiltroEstadoDomain
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

namespace MultiRisWeb.Data.Domain
{
  public class FiltroEstadoDomain
  {
    public long id_filtro_estado { get; set; }

    public int id_estado_examen { get; set; }

    public long id_filtro { get; set; }

    public FiltroEstadoDomain()
    {
      this.id_filtro_estado = 0L;
      this.id_estado_examen = 0;
      this.id_filtro = 0L;
    }
  }
}
