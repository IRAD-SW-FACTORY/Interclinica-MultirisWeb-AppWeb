// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.PerfilDomain
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

namespace MultiRisWeb.Data.Domain
{
  public class PerfilDomain
  {
    public long id_perfil { get; set; }

    public string nombre { get; set; }

    public string descripcion { get; set; }

    public int id_perfil_visualizacion { get; set; }

    public bool asignar { get; set; }

    public PerfilDomain()
    {
      this.id_perfil = 0L;
      this.nombre = string.Empty;
      this.descripcion = string.Empty;
      this.id_perfil_visualizacion = 0;
      this.asignar = false;
    }
  }
}
