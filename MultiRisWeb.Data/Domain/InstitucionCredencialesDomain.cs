// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.InstitucionCredencialesDomain
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

namespace MultiRisWeb.Data.Domain
{
  public class InstitucionCredencialesDomain
  {
    public int id_institucion_credenciales { get; set; }

    public string username { get; set; }

    public string password { get; set; }

    public int estado { get; set; }

    public int id_institucion { get; set; }

    public InstitucionCredencialesDomain()
    {
      this.id_institucion_credenciales = 0;
      this.username = string.Empty;
      this.password = string.Empty;
      this.estado = 0;
      this.id_institucion = 0;
    }
  }
}
