// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.RisPatologiaCriticaDomain
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

namespace MultiRisWeb.Data.Domain
{
  public class RisPatologiaCriticaDomain
  {
    public long id_patologia_critica { get; set; }

    public string nombre { get; set; }

    public bool estado { get; set; }

    public int id_institucion { get; set; }

    public int marca_leyenda_informe { get; set; }

    public int tipo_envio_notificacion { get; set; }

    public RisPatologiaCriticaDomain()
    {
      this.id_patologia_critica = 0L;
      this.nombre = string.Empty;
      this.estado = false;
      this.id_institucion = 0;
      this.tipo_envio_notificacion = 0;
      this.marca_leyenda_informe = 0;
    }
  }
}
