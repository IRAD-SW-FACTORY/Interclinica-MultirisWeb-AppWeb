// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.WSCuc.RisExamenDomain
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace MultiRisWeb.Data.WSCuc
{
  [DebuggerStepThrough]
  [GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
  [DataContract(Name = "RisExamenDomain", Namespace = "http://tempuri.org/")]
  [Serializable]
  public class RisExamenDomain : IExtensibleDataObject, INotifyPropertyChanged
  {
    [NonSerialized]
    private ExtensionDataObject extensionDataField;
    private long id_ris_examenField;
    private long id_examen_remotoField;
    [OptionalField]
    private string codexamenField;
    [OptionalField]
    private string aetitleField;
    [OptionalField]
    private string numeroaccesoField;
    [OptionalField]
    private string idpacienteField;
    [OptionalField]
    private string nombreField;
    [OptionalField]
    private string apellidopaternoField;
    [OptionalField]
    private string apellidomaternoField;
    private DateTime fechanacimientoField;
    [OptionalField]
    private string sexoField;
    private DateTime fechaexamenField;
    [OptionalField]
    private string modalidadField;
    [OptionalField]
    private string descripcionField;
    private int idradiologoField;
    [OptionalField]
    private string nombreradiologoField;
    private DateTime fechaasignacionField;
    [OptionalField]
    private string edadField;
    [OptionalField]
    private string idordenField;
    [OptionalField]
    private string idtipoordenField;
    [OptionalField]
    private string medicosolicitanteField;
    private DateTime fechavalidacionField;
    [OptionalField]
    private string horaexamenField;
    private int flagimagenField;
    [OptionalField]
    private string usernameRadiologoField;
    private int id_estado_examenField;
    private int id_institucionField;
    private int id_estado_sincronizadoField;
    [OptionalField]
    private string antecedentes_clinicosField;

    [Browsable(false)]
    public ExtensionDataObject ExtensionData
    {
      get => this.extensionDataField;
      set => this.extensionDataField = value;
    }

    [DataMember(IsRequired = true)]
    public long id_ris_examen
    {
      get => this.id_ris_examenField;
      set
      {
        if (this.id_ris_examenField.Equals(value))
          return;
        this.id_ris_examenField = value;
        this.RaisePropertyChanged(nameof (id_ris_examen));
      }
    }

    [DataMember(IsRequired = true, Order = 1)]
    public long id_examen_remoto
    {
      get => this.id_examen_remotoField;
      set
      {
        if (this.id_examen_remotoField.Equals(value))
          return;
        this.id_examen_remotoField = value;
        this.RaisePropertyChanged(nameof (id_examen_remoto));
      }
    }

    [DataMember(EmitDefaultValue = false, Order = 2)]
    public string codexamen
    {
      get => this.codexamenField;
      set
      {
        if ((object) this.codexamenField == (object) value)
          return;
        this.codexamenField = value;
        this.RaisePropertyChanged(nameof (codexamen));
      }
    }

    [DataMember(EmitDefaultValue = false, Order = 3)]
    public string aetitle
    {
      get => this.aetitleField;
      set
      {
        if ((object) this.aetitleField == (object) value)
          return;
        this.aetitleField = value;
        this.RaisePropertyChanged(nameof (aetitle));
      }
    }

    [DataMember(EmitDefaultValue = false, Order = 4)]
    public string numeroacceso
    {
      get => this.numeroaccesoField;
      set
      {
        if ((object) this.numeroaccesoField == (object) value)
          return;
        this.numeroaccesoField = value;
        this.RaisePropertyChanged(nameof (numeroacceso));
      }
    }

    [DataMember(EmitDefaultValue = false, Order = 5)]
    public string idpaciente
    {
      get => this.idpacienteField;
      set
      {
        if ((object) this.idpacienteField == (object) value)
          return;
        this.idpacienteField = value;
        this.RaisePropertyChanged(nameof (idpaciente));
      }
    }

    [DataMember(EmitDefaultValue = false, Order = 6)]
    public string nombre
    {
      get => this.nombreField;
      set
      {
        if ((object) this.nombreField == (object) value)
          return;
        this.nombreField = value;
        this.RaisePropertyChanged(nameof (nombre));
      }
    }

    [DataMember(EmitDefaultValue = false, Order = 7)]
    public string apellidopaterno
    {
      get => this.apellidopaternoField;
      set
      {
        if ((object) this.apellidopaternoField == (object) value)
          return;
        this.apellidopaternoField = value;
        this.RaisePropertyChanged(nameof (apellidopaterno));
      }
    }

    [DataMember(EmitDefaultValue = false, Order = 8)]
    public string apellidomaterno
    {
      get => this.apellidomaternoField;
      set
      {
        if ((object) this.apellidomaternoField == (object) value)
          return;
        this.apellidomaternoField = value;
        this.RaisePropertyChanged(nameof (apellidomaterno));
      }
    }

    [DataMember(IsRequired = true, Order = 9)]
    public DateTime fechanacimiento
    {
      get => this.fechanacimientoField;
      set
      {
        if (this.fechanacimientoField.Equals(value))
          return;
        this.fechanacimientoField = value;
        this.RaisePropertyChanged(nameof (fechanacimiento));
      }
    }

    [DataMember(EmitDefaultValue = false, Order = 10)]
    public string sexo
    {
      get => this.sexoField;
      set
      {
        if ((object) this.sexoField == (object) value)
          return;
        this.sexoField = value;
        this.RaisePropertyChanged(nameof (sexo));
      }
    }

    [DataMember(IsRequired = true, Order = 11)]
    public DateTime fechaexamen
    {
      get => this.fechaexamenField;
      set
      {
        if (this.fechaexamenField.Equals(value))
          return;
        this.fechaexamenField = value;
        this.RaisePropertyChanged(nameof (fechaexamen));
      }
    }

    [DataMember(EmitDefaultValue = false, Order = 12)]
    public string modalidad
    {
      get => this.modalidadField;
      set
      {
        if ((object) this.modalidadField == (object) value)
          return;
        this.modalidadField = value;
        this.RaisePropertyChanged(nameof (modalidad));
      }
    }

    [DataMember(EmitDefaultValue = false, Order = 13)]
    public string descripcion
    {
      get => this.descripcionField;
      set
      {
        if ((object) this.descripcionField == (object) value)
          return;
        this.descripcionField = value;
        this.RaisePropertyChanged(nameof (descripcion));
      }
    }

    [DataMember(IsRequired = true, Order = 14)]
    public int idradiologo
    {
      get => this.idradiologoField;
      set
      {
        if (this.idradiologoField.Equals(value))
          return;
        this.idradiologoField = value;
        this.RaisePropertyChanged(nameof (idradiologo));
      }
    }

    [DataMember(EmitDefaultValue = false, Order = 15)]
    public string nombreradiologo
    {
      get => this.nombreradiologoField;
      set
      {
        if ((object) this.nombreradiologoField == (object) value)
          return;
        this.nombreradiologoField = value;
        this.RaisePropertyChanged(nameof (nombreradiologo));
      }
    }

    [DataMember(IsRequired = true, Order = 16)]
    public DateTime fechaasignacion
    {
      get => this.fechaasignacionField;
      set
      {
        if (this.fechaasignacionField.Equals(value))
          return;
        this.fechaasignacionField = value;
        this.RaisePropertyChanged(nameof (fechaasignacion));
      }
    }

    [DataMember(EmitDefaultValue = false, Order = 17)]
    public string edad
    {
      get => this.edadField;
      set
      {
        if ((object) this.edadField == (object) value)
          return;
        this.edadField = value;
        this.RaisePropertyChanged(nameof (edad));
      }
    }

    [DataMember(EmitDefaultValue = false, Order = 18)]
    public string idorden
    {
      get => this.idordenField;
      set
      {
        if ((object) this.idordenField == (object) value)
          return;
        this.idordenField = value;
        this.RaisePropertyChanged(nameof (idorden));
      }
    }

    [DataMember(EmitDefaultValue = false, Order = 19)]
    public string idtipoorden
    {
      get => this.idtipoordenField;
      set
      {
        if ((object) this.idtipoordenField == (object) value)
          return;
        this.idtipoordenField = value;
        this.RaisePropertyChanged(nameof (idtipoorden));
      }
    }

    [DataMember(EmitDefaultValue = false, Order = 20)]
    public string medicosolicitante
    {
      get => this.medicosolicitanteField;
      set
      {
        if ((object) this.medicosolicitanteField == (object) value)
          return;
        this.medicosolicitanteField = value;
        this.RaisePropertyChanged(nameof (medicosolicitante));
      }
    }

    [DataMember(IsRequired = true, Order = 21)]
    public DateTime fechavalidacion
    {
      get => this.fechavalidacionField;
      set
      {
        if (this.fechavalidacionField.Equals(value))
          return;
        this.fechavalidacionField = value;
        this.RaisePropertyChanged(nameof (fechavalidacion));
      }
    }

    [DataMember(EmitDefaultValue = false, Order = 22)]
    public string horaexamen
    {
      get => this.horaexamenField;
      set
      {
        if ((object) this.horaexamenField == (object) value)
          return;
        this.horaexamenField = value;
        this.RaisePropertyChanged(nameof (horaexamen));
      }
    }

    [DataMember(IsRequired = true, Order = 23)]
    public int flagimagen
    {
      get => this.flagimagenField;
      set
      {
        if (this.flagimagenField.Equals(value))
          return;
        this.flagimagenField = value;
        this.RaisePropertyChanged(nameof (flagimagen));
      }
    }

    [DataMember(EmitDefaultValue = false, Order = 24)]
    public string usernameRadiologo
    {
      get => this.usernameRadiologoField;
      set
      {
        if ((object) this.usernameRadiologoField == (object) value)
          return;
        this.usernameRadiologoField = value;
        this.RaisePropertyChanged(nameof (usernameRadiologo));
      }
    }

    [DataMember(IsRequired = true, Order = 25)]
    public int id_estado_examen
    {
      get => this.id_estado_examenField;
      set
      {
        if (this.id_estado_examenField.Equals(value))
          return;
        this.id_estado_examenField = value;
        this.RaisePropertyChanged(nameof (id_estado_examen));
      }
    }

    [DataMember(IsRequired = true, Order = 26)]
    public int id_institucion
    {
      get => this.id_institucionField;
      set
      {
        if (this.id_institucionField.Equals(value))
          return;
        this.id_institucionField = value;
        this.RaisePropertyChanged(nameof (id_institucion));
      }
    }

    [DataMember(IsRequired = true, Order = 27)]
    public int id_estado_sincronizado
    {
      get => this.id_estado_sincronizadoField;
      set
      {
        if (this.id_estado_sincronizadoField.Equals(value))
          return;
        this.id_estado_sincronizadoField = value;
        this.RaisePropertyChanged(nameof (id_estado_sincronizado));
      }
    }

    [DataMember(EmitDefaultValue = false, Order = 28)]
    public string antecedentes_clinicos
    {
      get => this.antecedentes_clinicosField;
      set
      {
        if ((object) this.antecedentes_clinicosField == (object) value)
          return;
        this.antecedentes_clinicosField = value;
        this.RaisePropertyChanged(nameof (antecedentes_clinicos));
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName)
    {
      PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
      if (propertyChanged == null)
        return;
      propertyChanged((object) this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
