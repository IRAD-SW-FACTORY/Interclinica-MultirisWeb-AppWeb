// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.MeddreamsDomain
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

namespace MultiRisWeb.Data.Domain
{
  public class MeddreamsDomain
  {
    public int id_meddreams { get; set; }

    public int id_institucion { get; set; }

    public string url { get; set; }

    public string json { get; set; }

    public string method { get; set; }

    public int id_estado { get; set; }

    public MeddreamsDomain()
    {
      this.id_meddreams = 0;
      this.id_institucion = 0;
      this.url = string.Empty;
      this.json = string.Empty;
      this.method = string.Empty;
      this.id_estado = 0;
    }
  }
}
