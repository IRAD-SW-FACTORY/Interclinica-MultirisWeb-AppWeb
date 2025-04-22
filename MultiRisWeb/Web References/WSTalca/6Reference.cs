// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.WSTalca.AddendumParameters
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
  public class AddendumParameters
  {
    private long id_addendumField;
    private long id_informeField;
    private string usernameField;
    private string cod_examenField;
    private DateTime fecha_horaField;
    private string addendumField;
    private int estado_visibleField;
    private int estado_bloqueoField;

    public long id_addendum
    {
      get => this.id_addendumField;
      set => this.id_addendumField = value;
    }

    public long id_informe
    {
      get => this.id_informeField;
      set => this.id_informeField = value;
    }

    public string username
    {
      get => this.usernameField;
      set => this.usernameField = value;
    }

    public string cod_examen
    {
      get => this.cod_examenField;
      set => this.cod_examenField = value;
    }

    public DateTime fecha_hora
    {
      get => this.fecha_horaField;
      set => this.fecha_horaField = value;
    }

    public string addendum
    {
      get => this.addendumField;
      set => this.addendumField = value;
    }

    public int estado_visible
    {
      get => this.estado_visibleField;
      set => this.estado_visibleField = value;
    }

    public int estado_bloqueo
    {
      get => this.estado_bloqueoField;
      set => this.estado_bloqueoField = value;
    }
  }
}
