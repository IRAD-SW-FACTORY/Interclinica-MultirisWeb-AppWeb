// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.ConfiguracionGeneralDomain
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

namespace MultiRisWeb.Data.Domain
{
  public class ConfiguracionGeneralDomain
  {
    public long id_configuracion_general { get; set; }

    public string nombre { get; set; }

    public string descripcion { get; set; }

    public int estado { get; set; }

    public string valor1 { get; set; }

    public string valor2 { get; set; }

    public ConfiguracionGeneralDomain()
    {
      this.id_configuracion_general = 0L;
      this.nombre = string.Empty;
      this.descripcion = string.Empty;
      this.estado = 0;
      this.valor1 = string.Empty;
      this.valor2 = string.Empty;
    }
  }
}
