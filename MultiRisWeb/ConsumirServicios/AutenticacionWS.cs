// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.ConsumirServicios.AutenticacionWS
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using MultiRisWeb.ResponseEntity;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace MultiRisWeb.ConsumirServicios
{
  public class AutenticacionWS
  {
    public static async Task<ResponseSmsWs> GetToken()
    {
      ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
      RestClient restClient = new RestClient(new RestClientOptions("https://ws.sentraland.net")
      {
        MaxTimeout = -1
      });
      RestRequest request1 = new RestRequest("/token/index.ams", Method.Post);
      request1.AddHeader("Content-Type", "application/x-www-form-urlencoded");
      request1.AddParameter("institucion", "10809");
      request1.AddParameter("tipo_servicio", "3");
      request1.AddParameter("password", "HM2ILSJs");
      request1.AddParameter("usuario", "patricio.abella@irad.cl");
      RestRequest request2 = request1;
      CancellationToken cancellationToken = new CancellationToken();
      return JsonConvert.DeserializeObject<ResponseSmsWs>((await restClient.ExecuteAsync(request2, cancellationToken)).Content);
    }

    public static async Task<ResponseSmsWs> EnviarSms(string token, string telefono, string codigo)
    {
      RestClient restClient = new RestClient(new RestClientOptions("https://ws.sentraland.net")
      {
        MaxTimeout = -1
      });
      RestRequest request1 = new RestRequest("/tkFinanciero/index.ams", Method.Post);
      request1.AddHeader("Content-Type", "application/x-www-form-urlencoded");
      request1.AddParameter("institucion", "10809");
      request1.AddParameter("usuario", "patricio.abella@irad.cl");
      request1.AddParameter("password", "HM2ILSJs");
      request1.AddParameter("tipo_servicio", "3");
      request1.AddParameter(nameof (token), token);
      request1.AddParameter("fono", telefono);
      request1.AddParameter("mensaje", "Estimado(a) Usuario(a) AMIS su codigo de seguridad es " + codigo + ", Tiene una vigencia de 6 hrs. Este codigo es personal e instransferible.");
      RestRequest request2 = request1;
      CancellationToken cancellationToken = new CancellationToken();
      return JsonConvert.DeserializeObject<ResponseSmsWs>((await restClient.ExecuteAsync(request2, cancellationToken)).Content);
    }
  }
}
