// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Parameters.Examen
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using System;

namespace MultiRisWeb.Data.Parameters
{
  public class Examen
  {
    public long id_ris_examen { get; set; }

    public long id_examen_remoto { get; set; }

    public string codexamen { get; set; }

    public string aetitle { get; set; }

    public string numeroacceso { get; set; }

    public string idpaciente { get; set; }

    public string nombre { get; set; }

    public string apellidopaterno { get; set; }

    public string apellidomaterno { get; set; }

    public DateTime fechanacimiento { get; set; }

    public string sexo { get; set; }

    public DateTime fechaexamen { get; set; }

    public string modalidad { get; set; }

    public string descripcion { get; set; }

    public int idradiologo { get; set; }

    public string nombreradiologo { get; set; }

    public DateTime fechaasignacion { get; set; }

    public string edad { get; set; }

    public string idorden { get; set; }

    public string idtipoorden { get; set; }

    public string medicosolicitante { get; set; }

    public DateTime fechavalidacion { get; set; }

    public string horaexamen { get; set; }

    public int flagimagen { get; set; }

    public string usernameRadiologo { get; set; }

    public int id_estado_examen { get; set; }

    public int id_institucion { get; set; }

    public int id_estado_sincronizado { get; set; }

    public string antecedentes_clinicos { get; set; }

    public int bloqueado { get; set; }

    public DateTime fecha_bloqueo { get; set; }

    public int id_usuario_bloqueo { get; set; }

    public Examen()
    {
      this.id_ris_examen = 0L;
      this.id_examen_remoto = 0L;
      this.codexamen = string.Empty;
      this.aetitle = string.Empty;
      this.numeroacceso = string.Empty;
      this.idpaciente = string.Empty;
      this.nombre = string.Empty;
      this.apellidopaterno = string.Empty;
      this.apellidomaterno = string.Empty;
      this.fechanacimiento = new DateTime(1900, 1, 1);
      this.sexo = string.Empty;
      this.fechaexamen = new DateTime(1900, 1, 1);
      this.modalidad = string.Empty;
      this.descripcion = string.Empty;
      this.idradiologo = 0;
      this.nombreradiologo = string.Empty;
      this.fechaasignacion = new DateTime(1900, 1, 1);
      this.edad = string.Empty;
      this.idorden = string.Empty;
      this.idtipoorden = string.Empty;
      this.medicosolicitante = string.Empty;
      this.fechavalidacion = new DateTime(1900, 1, 1);
      this.horaexamen = string.Empty;
      this.usernameRadiologo = string.Empty;
      this.id_estado_examen = 0;
      this.id_institucion = 0;
      this.id_estado_sincronizado = 0;
      this.antecedentes_clinicos = string.Empty;
      this.bloqueado = 0;
      this.fecha_bloqueo = new DateTime(1900, 1, 1);
      this.id_usuario_bloqueo = 0;
    }
  }
}
