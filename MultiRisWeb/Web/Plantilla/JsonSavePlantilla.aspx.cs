// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Web.Plantilla.JsonSavePlantilla
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using MultiRisWeb.Data.DataAccess;
using MultiRisWeb.Data.Domain;
using MultiRisWeb.Data.Util;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace MultiRisWeb.Web.Plantilla
{
  public class JsonSavePlantilla : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Session["id_usuario"] == null)
        return;
      string empty = string.Empty;
      long paramLong = ParamUtil.GetParamLong((object) this.Request["id_plantilla"], 0L);
      string paramString1 = ParamUtil.GetParamString((object) this.Request["nombre"], string.Empty);
      string paramString2 = ParamUtil.GetParamString((object) this.Request["titulo"], string.Empty);
      string paramString3 = ParamUtil.GetParamString((object) this.Request["tecnica"], string.Empty);
      string paramString4 = ParamUtil.GetParamString((object) this.Request["hallazgos"], string.Empty);
      string paramString5 = ParamUtil.GetParamString((object) this.Request["impresion"], string.Empty);
      string paramString6 = ParamUtil.GetParamString((object) this.Request["modalidad"], string.Empty);
      bool flag = false;
      ModalidadDomain byName = ModalidadDataAccess.GetByName(paramString6);
      string str;
      if (paramString1.Length > 0 && byName.id_modalidad > 0)
      {
        if (paramLong == 0L)
        {
          try
          {
            foreach (RisPlantillaDomain risPlantillaDomain in (IEnumerable<RisPlantillaDomain>) RisPlantillaDataAccess.ListByUser(Convert.ToInt64(this.Session["id_usuario"].ToString())))
            {
              if (risPlantillaDomain.nombre == paramString1)
                flag = true;
            }
          }
          catch (Exception ex)
          {
            ex.ToString();
          }
        }
        else
        {
          foreach (RisPlantillaDomain risPlantillaDomain in (IEnumerable<RisPlantillaDomain>) RisPlantillaDataAccess.ListByNameUser(Convert.ToInt64(this.Session["id_usuario"].ToString()), paramString1, paramLong))
          {
            if (risPlantillaDomain.nombre == paramString1)
              flag = true;
          }
        }
        if (!flag)
        {
          RisPlantillaDomain byId = RisPlantillaDataAccess.GetById(paramLong);
          byId.nombre = paramString1;
          byId.titulo = paramString2;
          byId.tecnica = paramString3;
          byId.hallazgos = paramString4;
          byId.impresion = paramString5;
          byId.id_modalidad = byName.id_modalidad;
          byId.id_usuario = Convert.ToInt64(this.Session["id_usuario"].ToString());
          RisPlantillaDataAccess.Save(byId);
          str = empty + "\"out\":\"ok\"" + ",\"mensaje\":\"Plantilla Insertada\"";
        }
        else
          str = empty + "\"out\":\"error\"" + ",\"mensaje\":\"Ya existe una plantilla con ese nombre\"";
      }
      else
        str = empty + "\"out\":\"error\"" + ",\"mensaje\":\"Favor ingresar un nombre a la plantilla.\"";
      string s = "{" + str + "}";
      this.Response.Clear();
      this.Response.ContentType = "text/plain";
      this.Response.Write(s);
    }
  }
}
