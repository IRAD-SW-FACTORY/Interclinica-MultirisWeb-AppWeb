// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.InstitucionDomain
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

namespace MultiRisWeb.Data.Domain
{
  public class InstitucionDomain
  {
    public int id_institucion { get; set; }

    public string nombre { get; set; }

    public string descripcion { get; set; }

    public int estado { get; set; }

    public string url_pagina { get; set; }

    public string aetitle { get; set; }

    public string url_descarga { get; set; }

    public string url_informe { get; set; }

    public string url_base { get; set; }

    public int id_tipo_conexion { get; set; }

    public int addendum { get; set; }

    public int formulario_unico { get; set; }

    public string url_informe_oit { get; set; }

    public int id_institucion_padre { get; set; }

    public string logo { get; set; }

    public string estructura { get; set; }

    public string estructura_oit { get; set; }

    public int margen_inferior { get; set; }

    public int margen_superior { get; set; }

    public int margen_izquierda { get; set; }

    public int margen_derecha { get; set; }

    public string codigo_qr { get; set; }

    public int id_tipo_becado { get; set; }

    public int id_grupo { get; set; }

    public string correo_patologia_critica { get; set; }

    public string correo_cc_patologia_critica { get; set; }

    public string url_wsInstitucion { get; set; }

    public int flagObtenerComentarios { get; set; }

    public int flagContingencia { get; set; }

    public int EsSoran { get; set; }

    public string correo_pendiente { get; set; }

        public InstitucionDomain()
        {
            this.id_institucion = 0;
            this.nombre = string.Empty;
            this.descripcion = string.Empty;
            this.estado = 0;
            this.url_pagina = string.Empty;
            this.aetitle = string.Empty;
            this.url_descarga = string.Empty;
            this.url_informe = string.Empty;
            this.url_base = string.Empty;
            this.id_tipo_conexion = 0;
            this.addendum = 0;
            this.formulario_unico = 0;
            this.url_informe_oit = string.Empty;
            this.id_institucion_padre = 0;
            this.logo = string.Empty;
            this.estructura = string.Empty;
            this.estructura_oit = string.Empty;
            this.margen_superior = 0;
            this.margen_inferior = 0;
            this.margen_izquierda = 0;
            this.margen_derecha = 0;
            this.codigo_qr = string.Empty;
            this.id_tipo_becado = 1;
            this.correo_cc_patologia_critica = string.Empty;
            this.correo_patologia_critica = string.Empty;
            this.id_grupo = 0;
            this.flagObtenerComentarios = 0;
            this.url_wsInstitucion = string.Empty;
            this.flagContingencia = 0;
            this.EsSoran = 0;
            this.correo_pendiente = "";   
        }
    }
}
