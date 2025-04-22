// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Web.Configuracion.ConfiguracionesGenerales
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using System;
using System.Web.UI;

namespace MultiRisWeb.Web.Configuracion
{
  public class ConfiguracionesGenerales : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!(this.Request.UrlReferrer == (Uri) null))
        return;
      this.Response.Redirect("../../Default.aspx");
    }
  }
}
