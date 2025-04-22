// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Web.Examen.JsonImportStudy
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using MultiRisWeb.ConsumirServicios;
using MultiRisWeb.Data.DataAccess;
using MultiRisWeb.Data.Domain;
using System;
using System.Web.UI;

namespace MultiRisWeb.Web.Examen
{
  public class JsonImportStudy : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      string empty = string.Empty;
      string str = this.Request["codexamen"].ToString();
      InstitucionDomain byId1 = InstitucionDataAccess.GetById(Convert.ToInt32(this.Request["id_institucion"].ToString()));
      UsuarioDomain byId2 = UsuarioDataAccess.GetById(Convert.ToInt64(6.ToString()));
      RisExamenDomain byCodExamen = RisExamenDataAccess.GetByCodExamen(str);
      try
      {
        ConsumirWS.SolicitarImagenes(byId1.id_institucion, str, byId2);
        if (byCodExamen.id_ris_examen <= 0L)
          return;
        RisLogDataAccess.SaveReturn(new RisLogDomain()
        {
          sistema = "MULTIRISWEB",
          observacion = "Se realiza solicitud de imagenes de estudio con codexamen " + str,
          id_institucion = byId1.id_institucion,
          codexamen = str,
          id_usuario = byId2.id_usuario,
          id_ris_examen = byCodExamen.id_ris_examen
        });
      }
      catch (Exception ex)
      {
        if (byCodExamen.id_ris_examen <= 0L)
          return;
        RisLogDataAccess.SaveReturn(new RisLogDomain()
        {
          sistema = "MULTIRISWEB",
          observacion = "Error -Solicitd de imagenes fallida, codexamen " + str + " - stacktrace: " + ex.ToString(),
          id_institucion = byId1.id_institucion,
          codexamen = str,
          id_usuario = byId2.id_usuario,
          id_ris_examen = byCodExamen.id_ris_examen
        });
      }
    }
  }
}
