// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.FiltroUsuario
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

namespace MultiRisWeb.Data.Domain
{
  public class FiltroUsuario
  {
    public long id_filtro_usuario { get; set; }

    public long id_usuario { get; set; }

    public long id_filtro { get; set; }

    public FiltroUsuario()
    {
      this.id_filtro_usuario = 0L;
      this.id_usuario = 0L;
      this.id_filtro = 0L;
    }
  }
}
