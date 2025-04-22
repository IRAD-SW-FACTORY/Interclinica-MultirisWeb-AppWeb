// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.WSChillan.ServiceMultirisSoapClient
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace MultiRisWeb.Data.WSChillan
{
  [DebuggerStepThrough]
  [GeneratedCode("System.ServiceModel", "4.0.0.0")]
  public class ServiceMultirisSoapClient : ClientBase<ServiceMultirisSoap>, ServiceMultirisSoap
  {
    public ServiceMultirisSoapClient()
    {
    }

    public ServiceMultirisSoapClient(string endpointConfigurationName)
      : base(endpointConfigurationName)
    {
    }

    public ServiceMultirisSoapClient(string endpointConfigurationName, string remoteAddress)
      : base(endpointConfigurationName, remoteAddress)
    {
    }

    public ServiceMultirisSoapClient(
      string endpointConfigurationName,
      EndpointAddress remoteAddress)
      : base(endpointConfigurationName, remoteAddress)
    {
    }

    public ServiceMultirisSoapClient(Binding binding, EndpointAddress remoteAddress)
      : base(binding, remoteAddress)
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    InsertExamenResponse ServiceMultirisSoap.InsertExamen(InsertExamenRequest request) => this.Channel.InsertExamen(request);

    public bool InsertExamen(
      string credenciales,
      RisExamenDomain ris_Examen,
      RisPrestacionDomain[] ris_prestacion)
    {
      InsertExamenRequest request = new InsertExamenRequest()
      {
        Body = new InsertExamenRequestBody()
      };
      request.Body.credenciales = credenciales;
      request.Body.ris_Examen = ris_Examen;
      request.Body.ris_prestacion = ris_prestacion;
      return ((ServiceMultirisSoap) this).InsertExamen(request).Body.InsertExamenResult;
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    Task<InsertExamenResponse> ServiceMultirisSoap.InsertExamenAsync(InsertExamenRequest request) => this.Channel.InsertExamenAsync(request);

    public Task<InsertExamenResponse> InsertExamenAsync(
      string credenciales,
      RisExamenDomain ris_Examen,
      RisPrestacionDomain[] ris_prestacion)
    {
      InsertExamenRequest request = new InsertExamenRequest()
      {
        Body = new InsertExamenRequestBody()
      };
      request.Body.credenciales = credenciales;
      request.Body.ris_Examen = ris_Examen;
      request.Body.ris_prestacion = ris_prestacion;
      return ((ServiceMultirisSoap) this).InsertExamenAsync(request);
    }
  }
}
