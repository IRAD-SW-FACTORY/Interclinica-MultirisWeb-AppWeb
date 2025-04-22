// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.WSCuc.InsertExamenRequestBody
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
  public class InsertExamenRequestBody
  {
    [DataMember(EmitDefaultValue = false, Order = 0)]
    public string credenciales;
    [DataMember(EmitDefaultValue = false, Order = 1)]
    public RisExamenDomain ris_Examen;
    [DataMember(EmitDefaultValue = false, Order = 2)]
    public RisPrestacionDomain[] ris_prestacion;

    public InsertExamenRequestBody()
    {
    }

    public InsertExamenRequestBody(
      string credenciales,
      RisExamenDomain ris_Examen,
      RisPrestacionDomain[] ris_prestacion)
    {
      this.credenciales = credenciales;
      this.ris_Examen = ris_Examen;
      this.ris_prestacion = ris_prestacion;
    }
  }
}
