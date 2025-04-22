// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.WSChillan.InsertExamenResponse
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
  public class InsertExamenResponse
  {
    [MessageBodyMember(Name = "InsertExamenResponse", Namespace = "http://tempuri.org/", Order = 0)]
    public InsertExamenResponseBody Body;

    public InsertExamenResponse()
    {
    }

    public InsertExamenResponse(InsertExamenResponseBody Body) => this.Body = Body;
  }
}
