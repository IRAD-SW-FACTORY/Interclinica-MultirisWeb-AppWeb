// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Api.ConsumoApi
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using MultiRisWeb.Data.DataAccess;
using MultiRisWeb.Data.Domain;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.Text;

namespace MultiRisWeb.Data.Api
{
  public class ConsumoApi
  {
    public static DataTable obtenerDatosExamen(
      string id_paciente,
      int id_institucion,
      string aetitle,
      string codExamen,
      long id_examen_remoto)
    {
      DataTable dataTable = new DataTable();
      InstitucionDomain byId = InstitucionDataAccess.GetById(id_institucion);
      InstitucionDatosDomain methodAndInstitucion = InstitucionDatosDataAccess.GetByIdMethodAndInstitucion(1, byId.id_institucion);
      RisExamenDomain examenAetitleIdExamen = RisExamenDataAccess.GetByCodExamenAetitleIdExamen(codExamen, aetitle, id_examen_remoto);
      if (byId.id_institucion > 0 && methodAndInstitucion.id_institucion_datos > 0L && examenAetitleIdExamen.id_ris_examen > 0L)
      {
        string s = "{" + "\"id_paciente\":\"" + examenAetitleIdExamen.idpaciente + "\"," + "\"aetitle\":\"" + examenAetitleIdExamen.aetitle + "\"," + "\"codExamen\":\"" + examenAetitleIdExamen.codexamen + "\"" + "\"id_examen_remoto\":\"" + examenAetitleIdExamen.id_examen_remoto.ToString() + "\"" + "}";
        try
        {
          HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(new Uri(methodAndInstitucion.url));
          httpWebRequest.Accept = "application/json";
          httpWebRequest.ContentType = "application/json";
          httpWebRequest.Method = methodAndInstitucion.metodo;
          byte[] bytes = new ASCIIEncoding().GetBytes(s);
          Stream requestStream = httpWebRequest.GetRequestStream();
          requestStream.Write(bytes, 0, bytes.Length);
          requestStream.Close();
          new StreamReader(httpWebRequest.GetResponse().GetResponseStream()).ReadToEnd();
        }
        catch (Exception ex)
        {
          ex.ToString();
        }
      }
      return dataTable;
    }

    public static long insertarInforme(RisInformeDomain informe, int id_institucion)
    {
      InstitucionDomain byId = InstitucionDataAccess.GetById(id_institucion);
      InstitucionDatosDomain methodAndInstitucion = InstitucionDatosDataAccess.GetByIdMethodAndInstitucion(1, byId.id_institucion);
      long num = 0;
      if (byId.id_institucion > 0 && methodAndInstitucion.id_institucion_datos > 0L)
      {
        string s = "{" + "\"id_informe\":" + informe.id_informe_remoto.ToString() + "," + "\"codExamen\":" + informe.codExamen + "," + "}";
        try
        {
          HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(new Uri(methodAndInstitucion.url));
          httpWebRequest.Accept = "application/json";
          httpWebRequest.ContentType = "application/json";
          httpWebRequest.Method = methodAndInstitucion.metodo;
          byte[] bytes = new ASCIIEncoding().GetBytes(s);
          Stream requestStream = httpWebRequest.GetRequestStream();
          requestStream.Write(bytes, 0, bytes.Length);
          requestStream.Close();
          num = Convert.ToInt64(new StreamReader(httpWebRequest.GetResponse().GetResponseStream()).ReadToEnd());
        }
        catch (Exception ex)
        {
          ex.ToString();
        }
      }
      return num;
    }
  }
}
