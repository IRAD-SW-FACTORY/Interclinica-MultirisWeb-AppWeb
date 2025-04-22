// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.WSTalca.InformePDFParameters
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
  public class InformePDFParameters
  {
    private string codexamenField;
    private DateTime fecha_validacionField;
    private string username_radiologoField;
    private string aetitleField;
    private int id_estado_examenField;
    private string filenameField;
    private int sizeField;
    private byte[] base64Field;
    private int flagPatologiaGraveField;
    private long id_informe_multirisField;
    private string nombre_informeField;
    private long id_prestacion_remotoField;

    public string codexamen
    {
      get => this.codexamenField;
      set => this.codexamenField = value;
    }

    public DateTime fecha_validacion
    {
      get => this.fecha_validacionField;
      set => this.fecha_validacionField = value;
    }

    public string username_radiologo
    {
      get => this.username_radiologoField;
      set => this.username_radiologoField = value;
    }

    public string aetitle
    {
      get => this.aetitleField;
      set => this.aetitleField = value;
    }

    public int id_estado_examen
    {
      get => this.id_estado_examenField;
      set => this.id_estado_examenField = value;
    }

    public string filename
    {
      get => this.filenameField;
      set => this.filenameField = value;
    }

    public int size
    {
      get => this.sizeField;
      set => this.sizeField = value;
    }

    [XmlElement(DataType = "base64Binary")]
    public byte[] base64
    {
      get => this.base64Field;
      set => this.base64Field = value;
    }

    public int flagPatologiaGrave
    {
      get => this.flagPatologiaGraveField;
      set => this.flagPatologiaGraveField = value;
    }

    public long id_informe_multiris
    {
      get => this.id_informe_multirisField;
      set => this.id_informe_multirisField = value;
    }

    public string nombre_informe
    {
      get => this.nombre_informeField;
      set => this.nombre_informeField = value;
    }

    public long id_prestacion_remoto
    {
      get => this.id_prestacion_remotoField;
      set => this.id_prestacion_remotoField = value;
    }
  }
}
