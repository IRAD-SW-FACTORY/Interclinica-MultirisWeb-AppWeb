// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.UsuarioInstitucionDomain
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

namespace MultiRisWeb.Data.Domain
{
  public class UsuarioInstitucionDomain
  {
    public long id_usuario_institucion { get; set; }

    public long id_usuario { get; set; }

    public int id_institucion { get; set; } 

    public int id_tipo_firma { get; set; }

    public string nombre_institucion { get; set; }

    public UsuarioInstitucionDomain()
    {
      this.id_usuario_institucion = 0L;
      this.id_usuario = 0L;
      this.id_institucion = 0;
      this.id_tipo_firma = 3;
      this.nombre_institucion = string.Empty;
    }
  }
}
