// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.UsuarioDomain
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using System;

namespace MultiRisWeb.Data.Domain
{
  public class UsuarioDomain
  {
    public long id_usuario { get; set; }

    public string nombre { get; set; }

    public string apellido_paterno { get; set; }

    public string apellido_materno { get; set; }

    public int estado { get; set; }

    public string username { get; set; }

    public string password { get; set; }

    public int id_perfil { get; set; }

    public string rut { get; set; }

    public string email1 { get; set; }

    public string email2 { get; set; }

    public string telefono1 { get; set; }

    public string telefono2 { get; set; }

    public int dias_examenes { get; set; }

    public int vocali { get; set; }

    public int agente_vocali { get; set; }

    public int id_visor { get; set; }

    public string nombre_perfil { get; set; }

    public int meddreams_automatico { get; set; }

    public string firma { get; set; }

    public int id_usuario_referencia { get; set; }

    public string nombre_completo { get; set; }

    public int autentica_sms { get; set; }

    public DateTime? fecha_modificacion_pass { get; set; }

    public string password_vocali { get; set; }

    public UsuarioDomain()
    {
      this.id_usuario = 0L;
      this.nombre = string.Empty;
      this.apellido_paterno = string.Empty;
      this.apellido_materno = string.Empty;
      this.estado = 0;
      this.username = string.Empty;
      this.password = string.Empty;
      this.id_perfil = 0;
      this.rut = string.Empty;
      this.email1 = string.Empty;
      this.email2 = string.Empty;
      this.telefono1 = string.Empty;
      this.telefono2 = string.Empty;
      this.dias_examenes = 7;
      this.vocali = 0;
      this.agente_vocali = 0;
      this.id_visor = 0;
      this.nombre_perfil = string.Empty;
      this.meddreams_automatico = 0;
      this.firma = string.Empty;
      this.id_usuario_referencia = 0;
      this.nombre_completo = string.Empty;
      this.fecha_modificacion_pass = new DateTime?();
      this.password_vocali = string.Empty;
    }
  }
}
