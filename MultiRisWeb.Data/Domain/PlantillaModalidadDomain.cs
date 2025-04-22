// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.PlantillaModalidadDomain
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

namespace MultiRisWeb.Data.Domain
{
  public class PlantillaModalidadDomain
  {
    public long id_plantilla_modalidad { get; set; }

    public long id_plantilla { get; set; }

    public int id_modalidad { get; set; }

    public PlantillaModalidadDomain()
    {
      this.id_plantilla_modalidad = 0L;
      this.id_plantilla = 0L;
      this.id_modalidad = 0;
    }
  }
}
