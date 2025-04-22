// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.InstitucionVisorDomain
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

namespace MultiRisWeb.Data.Domain
{
  public class InstitucionVisorDomain
  {
    public int id_institucion_visor { get; set; }

    public int id_visor { get; set; }

    public int id_institucion { get; set; }

    public string url { get; set; }

    public int id_estado { get; set; }

    public InstitucionVisorDomain()
    {
      this.id_institucion_visor = 0;
      this.id_visor = 0;
      this.id_institucion = 0;
      this.url = string.Empty;
      this.id_estado = 0;
    }
  }
}
