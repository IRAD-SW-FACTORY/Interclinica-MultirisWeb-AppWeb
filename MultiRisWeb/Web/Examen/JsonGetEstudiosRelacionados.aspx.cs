// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Web.Examen.JsonGetEstudiosRelacionados
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using MultiRisWeb.ConsumirServicios;
using MultiRisWeb.Data.DataAccess;
using MultiRisWeb.Data.Domain;
using MultiRisWeb.Data.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Web.UI;

namespace MultiRisWeb.Web.Examen
{
	public class JsonGetEstudiosRelacionados : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (this.Session["id_usuario"] == null) return;
      
			string empty = string.Empty;
			string codExamen = this.Request["codexamen"].ToString();
			int int32 = Convert.ToInt32(this.Request["id_institucion"].ToString());
			
			RisExamenDomain byCodExamen = RisExamenDataAccess.GetByCodExamen(codExamen);
			InstitucionDomain byId = InstitucionDataAccess.GetById(int32);
			string str1 = string.Empty + "<table cellspacing='0' rules='all' border='1' id='tableEstudiosAnteriores' style='width: 100%; border-collapse: collapse;'>" + "<tr>" + "<th style='width: 10%'><b>Centro</b></th>" + "<th style='width: 20%'><b>Fecha Ex.</b></th>" + "<th style='width: 30%'><b>Desc.</b></th>" + "<th style='width: 10%'><b>Mod.</b></th>" + "<th style='width: 10%'><b>Doc.</b></th>" + "<th style='width: 20%'><b>Visores</b></th>" + "</tr>";
			
			if (ConfigurationManager.AppSettings["ActivarWSAPISalida"].ToString().Equals("1") && byId.id_institucion > 0 && byCodExamen.id_ris_examen > 0L)
			{
				if (byId.id_grupo == 0)
				{
					DataTable dtEstudios = ConsumirWS.GetEstudiosRelacionados(byCodExamen.idpaciente, byId.id_institucion);
                   
                    if (dtEstudios.Rows.Count > 0)
					{
						DataView defaultView = dtEstudios.DefaultView;
						defaultView.Sort = "Fecha_examen DESC";
						dtEstudios = defaultView.ToTable();
					}
					str1 += this.NormalizarEstudios(dtEstudios, byId, byCodExamen);
				} else {
					foreach (InstitucionDomain institucion in (IEnumerable<InstitucionDomain>) InstitucionDataAccess.GetAll())
					{
						if (byId.id_grupo == institucion.id_grupo)
						{
							DataTable dtEstudios = ConsumirWS.GetEstudiosRelacionados(byCodExamen.idpaciente, institucion.id_institucion);
							
							if (dtEstudios.Rows.Count > 0)
							{
								DataView defaultView = dtEstudios.DefaultView;
								defaultView.Sort = "Fecha_examen DESC";
								dtEstudios = defaultView.ToTable();
							}
							str1 += this.NormalizarEstudios(dtEstudios, institucion, byCodExamen);
						}
					}
				}
			}
			
			string str2 = str1 + "</table>";
			string s = empty + "{" + "\"out\": \"ok\"" + ",\"estudios_anteriores\": \"" + str2 + "\"" + "}";
			
			this.Response.Clear();
			this.Response.ContentType = "text/plain";
			this.Response.Write(s);
		}

    public string NormalizarEstudios(
      DataTable dtEstudios,
      InstitucionDomain institucion,
      RisExamenDomain examen)
    {
      string str = string.Empty;
      MeddreamsUtil meddreamsUtil = new MeddreamsUtil();
      foreach (DataRow row in (InternalDataCollectionBase) dtEstudios.Rows)
      {
        if (row["descripcion"].ToString() == "Estudio Solo Con Imagenes")
        {
          str += "<tr>";
          str += "<td>";
          str += institucion.nombre;
          str += "</td>";
          str += "<td>";
          str += row["fecha_examen"].ToString();
          str += "</td>";
          str += "<td>";
          str += row["descripcion"].ToString();
          str += "</td>";
          str += "<td>";
          str += row["modalidad"].ToString();
          str += "</td>";
          str += "<td>";
          str = str ?? "";
          str += "</td>";
          str += "<td>";
          str += meddreamsUtil.generarStringVisores(row["codexamen"].ToString(), institucion.id_institucion, false, Convert.ToInt64(this.Session["id_usuario"].ToString()));
          str += "</td>";
          str += "</tr>";
        }
        else
        {
          str += "<tr>";
          str += "<td>";
          str += institucion.nombre;
          str += "</td>";
          str += "<td>";
          str += row["fecha_examen"].ToString();
          str += "</td>";
          str += "<td>";
          str += row["descripcion"].ToString();
          str += "</td>";
          str += "<td>";
          str += row["modalidad"].ToString();
          str += "</td>";
          str += "<td>";
          str = str + "<a href='#' data-toggle='modal' data-target='#modalVerInforme' onclick='ObtenerTodosInformesPrevios(&#34;" + examen.idpaciente + "&#34;, " + institucion.id_institucion.ToString() + ", &#34;" + institucion.url_informe.Replace("#AETITLE#", institucion.aetitle).Replace("#CODEXAMEN#", row["codexamen"].ToString()).Replace("#IDINFORME#", row["idinforme"].ToString()) + "&#34;); return false;' target='_blank' title='Ver Informe'><img style='width: 13px;' src='../icon/pdf.png' /></a>";
          str += "</td>";
          str += "<td>";
          str += meddreamsUtil.generarStringVisores(row["codexamen"].ToString(), institucion.id_institucion, false, Convert.ToInt64(this.Session["id_usuario"].ToString()));
          str += "</td>";
          str += "</tr>";
        }
      }
      return str;
    }
  }
}
