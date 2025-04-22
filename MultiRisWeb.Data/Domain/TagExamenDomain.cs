// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.TagExamenDomain
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using System;

namespace MultiRisWeb.Data.Domain
{
    public class TagExamenDomain
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public int TagGeneral { get; set; }

        public int IdTag { get; set; }

        public string CodExamen { get; set; }

        public string Usuario { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaEliminacion { get; set; }

        public string UsuarioCreacion { get; set; }

        public string UsuarioEliminacion { get; set; }

        public int Vigente { get; set; }

        public string VigenteText => this.Vigente != 1 ? "No Vigente" : "Vigente";

        public string UsuarioEliminacionText => !string.IsNullOrEmpty(this.UsuarioEliminacion) ? this.UsuarioEliminacion : "--";

        public string FechaCreacionText => this.FechaCreacion.ToString("dd-MM-yyyy HH:mm");

        public string FechaEliminacionText
        {
            get
            {
                DateTime fechaEliminacion = this.FechaEliminacion;
                return this.FechaEliminacion.ToString("dd-MM-yyyy HH:mm");
            }
        }

        public string TagGeneralText => this.TagGeneral != 1 ? "Tipo Tag Personal" : "Tipo Tag General";
    }
}
