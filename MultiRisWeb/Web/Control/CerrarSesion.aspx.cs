// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Web.Control.CerrarSesion
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace MultiRisWeb.Web.Control
{
  public class CerrarSesion : Page
  {
    protected HtmlForm form1;

    protected void Page_Load(object sender, EventArgs e)
    {
      this.Session.Clear();
      this.Session.Abandon();
      this.Session.RemoveAll();
      this.Response.Redirect("../../Default.aspx");
    }
  }
}
