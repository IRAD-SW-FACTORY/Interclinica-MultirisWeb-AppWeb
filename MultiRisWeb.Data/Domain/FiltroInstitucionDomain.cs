// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.FiltroInstitucionDomain
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

namespace MultiRisWeb.Data.Domain
{
  public class FiltroInstitucionDomain
  {
    public long id_filtro_institucion { get; set; }

    public int id_institucion { get; set; }

    public long id_filtro { get; set; }

    public FiltroInstitucionDomain()
    {
      this.id_filtro_institucion = 0L;
      this.id_institucion = 0;
      this.id_filtro = 0L;
    }
  }
}
