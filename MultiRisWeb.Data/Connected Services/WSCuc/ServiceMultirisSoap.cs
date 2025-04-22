// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.WSCuc.ServiceMultirisSoap
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using System.CodeDom.Compiler;
using System.ServiceModel;
using System.Threading.Tasks;

namespace MultiRisWeb.Data.WSCuc
{
  [GeneratedCode("System.ServiceModel", "4.0.0.0")]
  [ServiceContract(ConfigurationName = "WSCuc.ServiceMultirisSoap")]
  public interface ServiceMultirisSoap
  {
    [OperationContract(Action = "http://tempuri.org/InsertExamen", ReplyAction = "*")]
    InsertExamenResponse InsertExamen(InsertExamenRequest request);

    [OperationContract(Action = "http://tempuri.org/InsertExamen", ReplyAction = "*")]
    Task<InsertExamenResponse> InsertExamenAsync(InsertExamenRequest request);
  }
}
