// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.InstitucionDatosDomain
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

namespace MultiRisWeb.Data.Domain
{
  public class InstitucionDatosDomain
  {
    public long id_institucion_datos { get; set; }

    public int id_institucion { get; set; }

    public int id_metodo { get; set; }

    public string nombre { get; set; }

    public string url { get; set; }

    public string metodo { get; set; }

    public InstitucionDatosDomain()
    {
      this.id_institucion_datos = 0L;
      this.id_institucion = 0;
      this.id_metodo = 0;
      this.nombre = string.Empty;
      this.url = string.Empty;
      this.metodo = string.Empty;
    }
  }
}
