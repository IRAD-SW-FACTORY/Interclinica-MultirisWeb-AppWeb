// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.WSCuc.InsertExamenResponseBody
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace MultiRisWeb.Data.WSCuc
{
  [DebuggerStepThrough]
  [GeneratedCode("System.ServiceModel", "4.0.0.0")]
  [EditorBrowsable(EditorBrowsableState.Advanced)]
  [DataContract(Namespace = "http://tempuri.org/")]
  public class InsertExamenResponseBody
  {
    [DataMember(Order = 0)]
    public bool InsertExamenResult;

    public InsertExamenResponseBody()
    {
    }

    public InsertExamenResponseBody(bool InsertExamenResult) => this.InsertExamenResult = InsertExamenResult;
  }
}
