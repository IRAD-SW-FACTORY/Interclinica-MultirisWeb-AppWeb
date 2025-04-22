// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.WSCuc.RisPrestacionDomain
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
  [DataContract(Name = "RisPrestacionDomain", Namespace = "http://tempuri.org/")]
  [Serializable]
  public class RisPrestacionDomain : IExtensibleDataObject, INotifyPropertyChanged
  {
    [NonSerialized]
    private ExtensionDataObject extensionDataField;
    private long id_prestacionField;
    private long id_prestacion_remotoField;
    [OptionalField]
    private string aetitleField;
    private int id_institucionField;
    [OptionalField]
    private string nombreField;
    private bool oitField;

    [Browsable(false)]
    public ExtensionDataObject ExtensionData
    {
      get => this.extensionDataField;
      set => this.extensionDataField = value;
    }

    [DataMember(IsRequired = true)]
    public long id_prestacion
    {
      get => this.id_prestacionField;
      set
      {
        if (this.id_prestacionField.Equals(value))
          return;
        this.id_prestacionField = value;
        this.RaisePropertyChanged(nameof (id_prestacion));
      }
    }

    [DataMember(IsRequired = true)]
    public long id_prestacion_remoto
    {
      get => this.id_prestacion_remotoField;
      set
      {
        if (this.id_prestacion_remotoField.Equals(value))
          return;
        this.id_prestacion_remotoField = value;
        this.RaisePropertyChanged(nameof (id_prestacion_remoto));
      }
    }

    [DataMember(EmitDefaultValue = false, Order = 2)]
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

    [DataMember(IsRequired = true, Order = 3)]
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

    [DataMember(EmitDefaultValue = false, Order = 4)]
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

    [DataMember(IsRequired = true, Order = 5)]
    public bool oit
    {
      get => this.oitField;
      set
      {
        if (this.oitField.Equals(value))
          return;
        this.oitField = value;
        this.RaisePropertyChanged(nameof (oit));
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
