// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.SolicitudAddendumInstitucionDomain
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using System;

namespace MultiRisWeb.Data.Domain
{
    public class SolicitudAddendumInstitucionDomain
    {
        public int Id { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Usuario { get; set; }
        public string UsuarioMail { get; set; }
        public int UsuarioInstitucion { get; set; }
        public long IdRisExamen { get; set; }
        public string Detalle { get; set; }
        public int EstadoSolicitudAdedemdum { get; set; }
        public DateTime FechaResolucion { get; set; }
        public DateTime FechaProceso { get; set; }
        public int TipoSolicitud { get; set; }
        public string Nombre { get; set; }
        public string estado { get; set; }
        public string paciente { get; set; }
        public string NomTipoSolicitud { get; set; }
        public string Comentario { get; set; }
        public int Nuevas { get; set; }
        public string Adjunto { get; set; }
        public string FechaIngresoText => this.FechaIngreso.ToString("dd-MM-yyyy HH:mm");
        public string UsuarioInformadorExamen { get; set; }
        public string UsuarioValidadorExamen { get; set; }
        public string UsuarioValidadorAddendum { get; set; }
        public string FechaResolucionText
        {
            get
            {
                DateTime fechaResolucion = this.FechaResolucion;
                return this.FechaResolucion.ToString("dd-MM-yyyy HH:mm");
            }
        }
        public string FechaProcesoText
        {
            get
            {
                DateTime fechaProceso = this.FechaProceso;
                return this.FechaProceso.ToString("dd-MM-yyyy HH:mm");
            }
        }
    }
}
