// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.ErrorPage
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultiRisWeb
{
  public class ErrorPage : Page
  {
    protected Label lblId;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.IsPostBack)
        return;
      this.lblId.Text = string.IsNullOrEmpty(this.Request.QueryString["id"].ToString()) ? "" : "Ha ocurrido un error en el sistema. Se registro con el numero " + this.Request.QueryString["id"].ToString();
    }
  }
}
