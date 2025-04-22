// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Web.Examen.JsonDeleteExamen
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using MultiRisWeb.Data.DataAccess;
using MultiRisWeb.Data.Domain;
using MultiRisWeb.Data.Util;
using System;
using System.Web.UI;

namespace MultiRisWeb.Web.Examen
{
  public class JsonDeleteExamen : Page
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
        if (byId1.id_usuario > 0L)
        {
          if (strArray.Length != 0)
          {
            for (int index = 0; index < strArray.Length; ++index)
            {
              if (strArray[index] != "")
              {
                RisExamenDomain byId2 = RisExamenDataAccess.GetById(Convert.ToInt64(strArray[index]));
                byId2.usernameRadiologo = byId1.username;
                byId2.idradiologo = Convert.ToInt32(byId1.id_usuario);
                RisExamenDataAccess.UpdateEstado(byId2);
              }
            }
            empty += "\"out\":\"ok\"";
            str = empty + ",\"mensaje\":\"Estudios Eliminados\"";
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
        str = empty + "\"out\":\"err\",\"mensaje\":\"Intente nuevamente\"";
      }
      string s = "{" + str + "}";
      this.Response.Clear();
      this.Response.ContentType = "text/plain";
      this.Response.Write(s);
    }
  }
}
