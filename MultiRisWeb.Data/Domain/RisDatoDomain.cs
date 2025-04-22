// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.RisDatoDomain
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

namespace MultiRisWeb.Data.Domain
{
  public class RisDatoDomain
  {
    public int id_dato { get; set; }

    public string nombre { get; set; }

    public RisDatoDomain()
    {
      this.id_dato = 0;
      this.nombre = string.Empty;
    }
  }
}
