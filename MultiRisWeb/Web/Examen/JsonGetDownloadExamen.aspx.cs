// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Web.Examen.JsonGetDownloadExamen
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using MultiRisWeb.Data.DataAccess;
using MultiRisWeb.Data.Domain;
using MultiRisWeb.Data.Util;
using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.UI;

namespace MultiRisWeb.Web.Examen
{
  public class JsonGetDownloadExamen : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Session["id_usuario"] == null)
        return;
      string empty = string.Empty;
      string[] strArray = ParamUtil.GetParamString((object) this.Request["id_asignacion"], string.Empty).Replace("'", "").Split(',');
      UsuarioDomain byId1 = UsuarioDataAccess.GetById(65L);
      UsuarioDataAccess.GetById(Convert.ToInt64(this.Session["id_usuario"].ToString()));
      string str;
      try
      {
        List<string> stringList = new List<string>();
        if (byId1.id_usuario > 0L)
        {
          if (strArray.Length != 0)
          {
            for (int index = 0; index < strArray.Length; ++index)
            {
              if (strArray[index] != "")
              {
                RisExamenDomain byId2 = RisExamenDataAccess.GetById(Convert.ToInt64(strArray[index]));
                ListaExamen listaExamen = new ListaExamen();
                stringList.Add("https://demo.irad.cl/MultiRisWeb_DownLoad/Download.aspx?codexamen=" + byId2.codexamen + "&aetitle=" + byId2.aetitle + "&");
                string script = "pausaplay(1,2);";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock((Page) this, this.GetType(), "script", script, true);
              }
            }
            empty += "\"out\":\"ok\"";
            empty += ",\"mensaje\":\"Estudios Eliminados\"";
            str = empty + ",\"url\":\"id_asignacion\"";
          }
          else
          {
            empty += "\"out\":\"err\"";
            str = empty + ",\"mensaje\":\"Estudios no seleccionados\"";
          }
        }
        else
        {
          empty += "\"out\":\"err\"";
          str = empty + ",\"mensaje\":\"Radiólogo no Seleccionado\"";
        }
      }
      catch (Exception ex)
      {
        ex.ToString();
        str = empty + "\"out\":\"err\"" + ",\"mensaje\":\"Intente nuevamente\"";
      }
      string s = "{" + str + "}";
      this.Response.Clear();
      this.Response.ContentType = "text/plain";
      this.Response.Write(s);
    }

    [WebMethod]
    public static List<string> EnviarCorreo(string id_ris_examen)
    {
      string[] strArray = id_ris_examen.Replace("'", "").Split(',');
      List<string> stringList = new List<string>();
      try
      {
        if (strArray.Length == 0)
          return stringList;
        for (int index = 0; index < strArray.Length; ++index)
        {
          if (strArray[index] != "")
          {
            RisExamenDomain byId = RisExamenDataAccess.GetById(Convert.ToInt64(strArray[index]));
            ListaExamen listaExamen = new ListaExamen();
            stringList.Add("https://demo.irad.cl/MultiRisWeb_DownLoad/Download.aspx?codexamen=" + byId.codexamen + "&aetitle=" + byId.aetitle + "&");
          }
        }
        return stringList;
      }
      catch (Exception ex)
      {
        ex.ToString();
        return stringList;
      }
    }
  }
}
