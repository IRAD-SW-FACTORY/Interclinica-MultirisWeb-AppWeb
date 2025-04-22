// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.VocaliDomain
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

namespace MultiRisWeb.Data.Domain
{
  public class VocaliDomain
  {
    public int id_vocali { get; set; }

    public int puerto { get; set; }

    public string direccion_url { get; set; }

    public int estado { get; set; }

    public VocaliDomain()
    {
      this.id_vocali = 0;
      this.puerto = 0;
      this.direccion_url = string.Empty;
      this.estado = 0;
    }
  }
}
