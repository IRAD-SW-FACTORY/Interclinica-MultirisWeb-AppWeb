// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.VisorDomain
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

namespace MultiRisWeb.Data.Domain
{
  public class VisorDomain
  {
    public int id_visor { get; set; }

    public string nombre { get; set; }

    public string descripcion { get; set; }

    public string icono { get; set; }

    public int id_estado { get; set; }

    public VisorDomain()
    {
      this.id_visor = 0;
      this.nombre = string.Empty;
      this.descripcion = string.Empty;
      this.icono = string.Empty;
      this.id_estado = 1;
    }
  }
}
