// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.WSTalca.InformeExternoCabeceraParameters
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MultiRisWeb.WSTalca
{
  [GeneratedCode("System.Xml", "4.8.9032.0")]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(Namespace = "http://tempuri.org/")]
  [Serializable]
  public class InformeExternoCabeceraParameters
  {
    private long idInformeField;
    private string codigoHisField;
    private string nombreInformeField;
    private string codExamenField;
    private string idPacienteField;
    private DateTime fechaValidacionField;
    private int idEstadoField;
    private string estadoField;
    private int idRadiologoField;
    private string userNameRadiologoField;
    private string nombreRadiologoField;
    private int flagPatologiaGraveField;
    private string patologiaGraveField;
    private InformeExternoDetalleParameters prestacionesExternasField;

    public long IdInforme
    {
      get => this.idInformeField;
      set => this.idInformeField = value;
    }

    public string CodigoHis
    {
      get => this.codigoHisField;
      set => this.codigoHisField = value;
    }

    public string NombreInforme
    {
      get => this.nombreInformeField;
      set => this.nombreInformeField = value;
    }

    public string CodExamen
    {
      get => this.codExamenField;
      set => this.codExamenField = value;
    }

    public string IdPaciente
    {
      get => this.idPacienteField;
      set => this.idPacienteField = value;
    }

    public DateTime FechaValidacion
    {
      get => this.fechaValidacionField;
      set => this.fechaValidacionField = value;
    }

    public int IdEstado
    {
      get => this.idEstadoField;
      set => this.idEstadoField = value;
    }

    public string Estado
    {
      get => this.estadoField;
      set => this.estadoField = value;
    }

    public int IdRadiologo
    {
      get => this.idRadiologoField;
      set => this.idRadiologoField = value;
    }

    public string UserNameRadiologo
    {
      get => this.userNameRadiologoField;
      set => this.userNameRadiologoField = value;
    }

    public string NombreRadiologo
    {
      get => this.nombreRadiologoField;
      set => this.nombreRadiologoField = value;
    }

    public int FlagPatologiaGrave
    {
      get => this.flagPatologiaGraveField;
      set => this.flagPatologiaGraveField = value;
    }

    public string PatologiaGrave
    {
      get => this.patologiaGraveField;
      set => this.patologiaGraveField = value;
    }

    public InformeExternoDetalleParameters prestacionesExternas
    {
      get => this.prestacionesExternasField;
      set => this.prestacionesExternasField = value;
    }
  }
}
