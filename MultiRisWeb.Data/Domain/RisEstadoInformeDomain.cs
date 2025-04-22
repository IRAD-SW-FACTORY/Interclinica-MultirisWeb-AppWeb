// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.RisEstadoInformeDomain
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

namespace MultiRisWeb.Data.Domain
{
  public class RisEstadoInformeDomain
  {
    public int id_estado_informe { get; set; }

    public string nombre { get; set; }

    public string codigo { get; set; }

    public RisEstadoInformeDomain()
    {
      this.id_estado_informe = 0;
      this.nombre = string.Empty;
      this.codigo = string.Empty;
    }
  }
}
