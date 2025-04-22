// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Web.Examen.VerInforme
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using MultiRisWeb.Data.DataAccess;
using MultiRisWeb.Data.Domain;
using MultiRisWeb.Data.Util;
using MultiRisWeb.Util;
using System;
using System.IO;
using System.Web.UI;

namespace MultiRisWeb.Web.Examen
{
  public class VerInforme : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      RisInformeDomain byId = RisInformeDataAccess.GetByID(ParamUtil.GetParamLong((object) this.Request["idinforme"], 0L));
      InstitucionDomain byAetitle = InstitucionDataAccess.GetByAetitle(ParamUtil.GetParamString((object) this.Request["aetitle"], string.Empty));
      if (byId.id_ris_informe <= 0L)
        return;
      MemoryStream pdfInforme = InformeUtil.createPDFInforme(byAetitle, byId);
      byte[] array = pdfInforme.ToArray();
      pdfInforme.Flush();
      pdfInforme.Close();
      this.Response.Clear();
      this.Response.ContentType = "application/pdf";
      this.Response.AddHeader("Content-Disposition", "inline; filename=informeAMIS." + byId.id_ris_informe.ToString() + ".pdf");
      this.Response.AddHeader("Content-Length", array.Length.ToString());
      this.Response.BinaryWrite(array);
    }
  }
}
