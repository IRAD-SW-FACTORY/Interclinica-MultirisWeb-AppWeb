// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Web.Examen.JsonGetAddendumsPendientes
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using MultiRisWeb.Data.DataAccess;
using MultiRisWeb.Data.Domain;
using MultiRisWeb.Encrypt.Util;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace MultiRisWeb.Web.Examen
{
  public class JsonGetAddendumsPendientes : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Session["id_usuario"] == null)
        return;
      string empty = string.Empty;
      string str1 = string.Empty;
      int num = 0;
      UsuarioDomain byId1 = UsuarioDataAccess.GetById(Convert.ToInt64(this.Session["id_usuario"].ToString()));
      foreach (SolicitudAddendumDomain solicitudAddendumDomain in (IEnumerable<SolicitudAddendumDomain>) SolicitudAddendumDataAccess.GetByEstado(1))
      {
        bool flag1 = false;
        bool flag2 = false;
        InstitucionDomain byId2 = InstitucionDataAccess.GetById(solicitudAddendumDomain.id_institucion);
        RisExamenDomain institucionCodExamen = RisExamenDataAccess.GetByInstitucionCodExamen((long) solicitudAddendumDomain.id_institucion, byId2.aetitle, solicitudAddendumDomain.codexamen);
        if (byId1.id_perfil == 1)
        {
          flag1 = true;
        }
        else
        {
          foreach (RisInformeDomain risInformeDomain in (IEnumerable<RisInformeDomain>) RisInformeDataAccess.GetByCodExamenValidado(institucionCodExamen.codexamen, 3, institucionCodExamen.numeroacceso, byId2.id_institucion))
          {
            if (risInformeDomain.username_radiologo == byId1.username)
            {
              flag1 = true;
              flag2 = true;
            }
          }
        }
        if (flag1)
        {
          str1 += "{";
          str1 = str1 + "\"motivo\":\"" + solicitudAddendumDomain.motivo + "\"";
          str1 = str1 + ",\"usuario_solicitud\":\"" + solicitudAddendumDomain.usuario + "\"";
          string str2 = str1;
          DateTime dateTime = solicitudAddendumDomain.fecha_solicitud;
          string str3 = dateTime.ToString();
          str1 = str2 + ",\"fecha_solicitud\":\"" + str3 + "\"";
          str1 = str1 + ",\"numero_acceso\":\"" + institucionCodExamen.numeroacceso + "\"";
          str1 = str1 + ",\"institucion\":\"" + byId2.nombre + "\"";
          string str4 = str1;
          dateTime = institucionCodExamen.fechaexamen;
          string str5 = dateTime.ToString();
          str1 = str4 + ",\"fecha_examen\":\"" + str5 + "\"";
          str1 = str1 + ",\"username\":\"" + byId1.username + "\"";
          str1 += flag2 ? ",\"addendum\":\"" + JsonGetAddendumsPendientes.encriptarAddendum("&cod_examen=" + institucionCodExamen.codexamen + "&id_institucion=" + byId2.id_institucion.ToString()) + "\"" : "";
          str1 += "},";
          ++num;
        }
      }
      string s = empty + "{" + "\"out\":\"ok\"" + ",\"solicitudes\":[" + str1.TrimEnd(',') + "]" + ",\"cantidad\":\"" + num.ToString() + "\"" + "}";
      this.Response.Clear();
      this.Response.ContentType = "text/plain";
      this.Response.Write(s);
    }

    private static string encriptarAddendum(string texto)
    {
      ConfiguracionGeneralDomain byId1 = ConfiguracionGeneralDataAccess.GetById(1L);
      ConfiguracionGeneralDomain byId2 = ConfiguracionGeneralDataAccess.GetById(2L);
      return "Addendum.aspx?val=" + EncCode.Encode("clave=" + ConfiguracionGeneralDataAccess.GetById(3L).valor1 + texto, byId1.valor1, byId2.valor1);
    }
  }
}
