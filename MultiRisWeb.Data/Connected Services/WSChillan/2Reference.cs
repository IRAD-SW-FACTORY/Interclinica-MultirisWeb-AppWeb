// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.WSChillan.InsertExamenRequest
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace MultiRisWeb.Data.WSChillan
{
  [DebuggerStepThrough]
  [GeneratedCode("System.ServiceModel", "4.0.0.0")]
  [EditorBrowsable(EditorBrowsableState.Advanced)]
  [MessageContract(IsWrapped = false)]
  public class InsertExamenRequest
  {
    [MessageBodyMember(Name = "InsertExamen", Namespace = "http://tempuri.org/", Order = 0)]
    public InsertExamenRequestBody Body;

    public InsertExamenRequest()
    {
    }

    public InsertExamenRequest(InsertExamenRequestBody Body) => this.Body = Body;
  }
}
