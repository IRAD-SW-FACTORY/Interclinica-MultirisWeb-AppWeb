// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.ConsumirServicios.ConsumirApi
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using MultiRisWeb.Data.DataAccess;
using MultiRisWeb.Data.Domain;
using Newtonsoft.Json;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MultiRisWeb.ConsumirServicios
{
  public class ConsumirApi
  {
    public long ApiObtenerIdRemoto(string url, string metodo, string json, int id_institucion)
    {
      long num = 0;
      try
      {
        InstitucionCredencialesDomain byId = InstitucionCredencialesDataAccess.GetById(id_institucion);
        HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(new Uri(url));
        httpWebRequest.Accept = "application/json";
        httpWebRequest.ContentType = "application/json";
        httpWebRequest.Method = metodo;
        httpWebRequest.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(byId.username + ":" + byId.password)));
        byte[] bytes = new ASCIIEncoding().GetBytes(json);
        Stream requestStream = httpWebRequest.GetRequestStream();
        requestStream.Write(bytes, 0, bytes.Length);
        requestStream.Close();
        num = Convert.ToInt64(new StreamReader(httpWebRequest.GetResponse().GetResponseStream()).ReadToEnd());
      }
      catch (Exception ex)
      {
        ex.ToString();
        ApiErrorDataAccess.Save(new ApiErrorDomain()
        {
          staktrace = ex.ToString(),
          id_institucion = id_institucion
        });
      }
      return num;
    }

    public string ApiObtenerString(string url, string metodo, string json, int id_institucion)
    {
      try
      {
        InstitucionCredencialesDomain byId = InstitucionCredencialesDataAccess.GetById(id_institucion);
        HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(new Uri(url));
        httpWebRequest.Accept = "application/json";
        httpWebRequest.ContentType = "application/json";
        httpWebRequest.Method = metodo;
        httpWebRequest.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(byId.username + ":" + byId.password)));
        byte[] bytes = new ASCIIEncoding().GetBytes(json);
        Stream requestStream = httpWebRequest.GetRequestStream();
        requestStream.Write(bytes, 0, bytes.Length);
        requestStream.Close();
        return new StreamReader(httpWebRequest.GetResponse().GetResponseStream()).ReadToEnd().ToString();
      }
      catch (Exception ex)
      {
        ex.ToString();
        ApiErrorDataAccess.Save(new ApiErrorDomain()
        {
          staktrace = ex.ToString(),
          id_institucion = id_institucion
        });
        return "";
      }
    }

    public DataTable ApiObtenerDataTable(
      string url,
      string metodo,
      string json,
      int id_institucion)
    {
      DataTable dataTable = new DataTable();
      try
      {
        InstitucionCredencialesDomain byId = InstitucionCredencialesDataAccess.GetById(id_institucion);
        HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(new Uri(url));
        httpWebRequest.Accept = "application/json";
        httpWebRequest.ContentType = "application/json";
        httpWebRequest.Method = metodo;
        httpWebRequest.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(byId.username + ":" + byId.password)));
        byte[] bytes = new ASCIIEncoding().GetBytes(json);
        Stream requestStream = httpWebRequest.GetRequestStream();
        requestStream.Write(bytes, 0, bytes.Length);
        requestStream.Close();
        dataTable = (DataTable) JsonConvert.DeserializeObject(new StreamReader(httpWebRequest.GetResponse().GetResponseStream()).ReadToEnd(), typeof (DataTable));
      }
      catch (Exception ex)
      {
        ex.ToString();
        ApiErrorDataAccess.Save(new ApiErrorDomain()
        {
          staktrace = ex.ToString(),
          id_institucion = id_institucion
        });
      }
      return dataTable;
    }

    public async Task<DataTable> ApiDataTable(
      string url,
      string metodo,
      string json,
      int id_institucion)
    {
      DataTable dt = new DataTable();
      try
      {
        InstitucionCredencialesDomain byId = InstitucionCredencialesDataAccess.GetById(id_institucion);
        HttpWebRequest http = (HttpWebRequest) WebRequest.Create(new Uri(url));
        http.Accept = "application/json";
        http.ContentType = "application/json";
        http.Method = metodo;
        http.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(byId.username + ":" + byId.password)));
        byte[] bytes = new ASCIIEncoding().GetBytes(json);
        Stream requestStreamAsync = await http.GetRequestStreamAsync();
        requestStreamAsync.Write(bytes, 0, bytes.Length);
        requestStreamAsync.Close();
        dt = (DataTable) JsonConvert.DeserializeObject(new StreamReader(http.GetResponse().GetResponseStream()).ReadToEnd(), typeof (DataTable));
        http = (HttpWebRequest) null;
        bytes = (byte[]) null;
        http = (HttpWebRequest) null;
        bytes = (byte[]) null;
      }
      catch (Exception ex)
      {
        ex.ToString();
        ApiErrorDataAccess.Save(new ApiErrorDomain()
        {
          staktrace = ex.ToString(),
          id_institucion = id_institucion
        });
      }
      DataTable dataTable1 = dt;
      dt = (DataTable) null;
      DataTable dataTable2 = dataTable1;
      dt = (DataTable) null;
      return dataTable2;
    }
  }
}
