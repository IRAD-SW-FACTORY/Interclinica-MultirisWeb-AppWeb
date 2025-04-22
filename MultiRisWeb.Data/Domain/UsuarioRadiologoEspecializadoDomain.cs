// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.UsuarioRadiologoEspecializadoDomain
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

namespace MultiRisWeb.Data.Domain
{
  public class UsuarioRadiologoEspecializadoDomain
  {
    public int Id { get; set; }

    public long IdUsuarioEspecializado { get; set; }

    public long IdUsuarioRadiologo { get; set; }

    public string NombreRadiologo { get; set; }
  }
}
