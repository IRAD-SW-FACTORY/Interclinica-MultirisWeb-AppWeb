// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Web.Examen.SeleccionarPrestacion
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using MultiRisWeb.Data.DataAccess;
using MultiRisWeb.Data.Domain;
using MultiRisWeb.Data.Util;
using System;
using System.Text;
using System.Web.UI;

namespace MultiRisWeb.Web.Examen
{
  public class SeleccionarPrestacion : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      try
      {
        ParamUtil.GetParamString((object) this.Request.Params["codexamen"], "");
        string paramString = ParamUtil.GetParamString((object) this.Request.Params["codexamen"], "");
        long paramLong = ParamUtil.GetParamLong((object) this.Request.Params["idexamen"], 0L);
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("<b>Seleccione las prestaciones que desea informar en un sólo informe</b><br />");
        stringBuilder.Append("<input type='hidden' name='p_codexamen' id='p_codexamen' value='" + paramString + "' />");
        stringBuilder.Append("<input type='hidden' name='p_idexamen' id='p_idexamen' value='" + paramLong.ToString() + "' />");
      }
      catch (Exception ex)
      {
        ex.ToString();
        ApiErrorDataAccess.Save(new ApiErrorDomain()
        {
          staktrace = "Page_Load (SeleccionarPrestacion.aspx): \n\n" + ex.ToString()
        });
      }
    }
  }
}
