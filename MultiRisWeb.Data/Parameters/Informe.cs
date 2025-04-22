// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Parameters.Informe
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using System;

namespace MultiRisWeb.Data.Parameters
{
  public class Informe
  {
    public long id_informe_remoto { get; set; }

    public int id_estado_informe { get; set; }

    public string id_paciente { get; set; }

    public DateTime fecha_validacion { get; set; }

    public int flag_patologia_grave { get; set; }

    public string patologia_grave { get; set; }

    public string descripcion { get; set; }

    public int valor { get; set; }

    public string codExamen { get; set; }

    public string modalidad { get; set; }

    public int id_tipo_informe { get; set; }

    public Informe()
    {
      this.id_informe_remoto = 0L;
      this.id_estado_informe = 0;
      this.id_paciente = string.Empty;
      this.fecha_validacion = new DateTime();
      this.flag_patologia_grave = 0;
      this.patologia_grave = string.Empty;
      this.descripcion = string.Empty;
      this.valor = 0;
      this.codExamen = string.Empty;
      this.modalidad = string.Empty;
      this.id_tipo_informe = 0;
    }
  }
}
