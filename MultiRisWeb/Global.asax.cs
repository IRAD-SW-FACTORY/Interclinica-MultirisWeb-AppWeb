// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Global
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using MultiRisWeb.Util;
using System;
using System.Web;
using System.Web.Security;

namespace MultiRisWeb
{
  public class Global : HttpApplication
  {
    protected void Application_Start(object sender, EventArgs e)
    {
    }

    protected void Session_Start(object sender, EventArgs e)
    {
    }

    protected void Application_BeginRequest(object sender, EventArgs e)
    {
    }

    protected void Application_AuthenticateRequest(object sender, EventArgs e)
    {
    }

    protected void Application_Error(object sender, EventArgs e)
    {
      Exception baseException = this.Server.GetLastError().GetBaseException();
      string str = DateTime.Now.ToString("ddMMyyyyHHmmss");
      LogApp logApp = new LogApp("Id : " + str + " Fecha : " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + " - Error Multiris : " + baseException.ToString(), "logErrorMultiris.log");
      FormsAuthentication.SignOut();
      this.Response.Redirect("~/ErrorPage.aspx?id=" + str);
    }

    protected void Session_End(object sender, EventArgs e)
    {
    }

    protected void Application_End(object sender, EventArgs e)
    {
    }
  }
}
