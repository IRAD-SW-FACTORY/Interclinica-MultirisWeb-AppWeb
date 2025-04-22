// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Error.Error
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using Serilog;
using System;
using System.Net;
using System.Web.Mvc;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultiRisWeb.Error
{
  public class Error : Page
  {
    protected Label lblCodError;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.IsPostBack)
        return;
      this.lblCodError.Text = this.Request.QueryString["cError"].ToString();
    }

    [WebMethod(EnableSession = true)]
    [HttpPost]
    public static HttpStatusCode AddErrorJs(string errmsg, string url, string error)
    {
      Log.Error<string>(error, errmsg + url);
      return HttpStatusCode.OK;
    }
  }
}
