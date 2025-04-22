// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Web.Examen.VerInformeOIT
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using MultiRisWeb.Data.DataAccess;
using MultiRisWeb.Data.Domain;
using MultiRisWeb.Data.Util;
using MultiRisWeb.Util;
using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;

namespace MultiRisWeb.Web.Examen
{
 public class VerInformeOIT : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var dato = VerInformeOIT.Desencriptar(this.Request["codexamen"]);
                
                var examen = RisExamenDataAccess.GetByCodExamen(dato);

                if (examen.codexamen.Equals(DBNull.Value) || examen.codexamen.Equals(string.Empty)) return;

                var instit = InstitucionDataAccess.GetById(examen.id_institucion);
				var informe = RisInformeDataAccess.VerInformeOIT(examen.codexamen);

                MemoryStream pdfInformeOiT2 = InformeUtil.createPDFOIT(informe.Rows[0]);
                byte[] array = pdfInformeOiT2.ToArray();
                
                pdfInformeOiT2.Flush();
                pdfInformeOiT2.Close();
                
                this.Response.Clear();
                this.Response.ContentType = "application/pdf";                
                this.Response.AddHeader("Content-Disposition", "inline; filename=informeOIT." + examen.codexamen + ".pdf");
                this.Response.AddHeader("Content-Length", array.Length.ToString());
                this.Response.BinaryWrite(array);
			}
			catch (Exception ex)
            {
                string str = ex.ToString();
				ApiErrorDataAccess.Save(new ApiErrorDomain() { staktrace = "Error al crear PDF : " + str });
			}
		}
		
		private static string Desencriptar(string cadena)
        {
            return Encoding.Unicode.GetString(Convert.FromBase64String(cadena));
        }
	}
}
