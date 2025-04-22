// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.MenuDomain
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

namespace MultiRisWeb.Data.Domain
{
  public class MenuDomain
  {
    public int Id_menu { get; set; }

    public string Menu { get; set; }

    public MenuDomain()
    {
      this.Id_menu = 0;
      this.Menu = string.Empty;
    }
  }
}
