// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.ResponseEntity.ExamenShow
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using MultiRisWeb.Data.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MultiRisWeb.ResponseEntity
{
    public class ExamenShow
    {
        public string id_ris_examen { get; set; }

        public string patologia { get; set; }

        public string tipo_patologia { get; set; }

        public string instancias { get; set; }

        public string addsol { get; set; }

        public string registroOcupado { get; set; }

        public string comentarios { get; set; }

        public string acciones { get; set; }

        public string institucion { get; set; }

        public string idInstitucion { get; set; }

        public string antecedenteClinico { get; set; }

        public string nombreTipoUrgencia { get; set; }

        public string fechaExamen { get; set; }

        public string fechaAsignacion { get; set; }

        public string fechaCierre { get; set; }

        public string fechaValidacion { get; set; }

        public string tiempo { get; set; }

        public string idpaciente { get; set; }

        public string nombreFull { get; set; }

        public string edad { get; set; }

        public string modalidad { get; set; }

        public string descripcion { get; set; }

        public string userNameRadiologo { get; set; }

        public string id_examen_remoto { get; set; }

        public string numeroacceso { get; set; }

        public string ejecutante { get; set; }

        public string idEstadoExamen { get; set; }

        public string nombreEstadoExamen { get; set; }

        public string bloqueado { get; set; }

        public string responsables { get; set; }

        public string tipoConexion { get; set; }

        public string metodo { get; set; }

        public string urlMetodo { get; set; }

        public string swComentario { get; set; }

        public string tiempoBloqueo { get; set; }

        public string swInstitucion { get; set; }

        public string codExamen { get; set; }

        public string id_estado_pendiente { get; set; }

        public static List<ExamenShow> ConvertDataTableToOnject(DataTable table)
        {
            IList<ExamenShow> source = (IList<ExamenShow>) new List<ExamenShow>();

            foreach (DataRow row in (InternalDataCollectionBase) table.Rows)
                source.Add(new ExamenShow()
                {
                    id_ris_examen = row[0].ToString(),
                    patologia = row[1].ToString(),
                    tipo_patologia = row[2].ToString(),
                    id_examen_remoto = row[3].ToString(),
                    codExamen = row[4].ToString(),
                    institucion = row[6].ToString(),
                    numeroacceso = row[7].ToString(),
                    idpaciente = row[8].ToString(),
                    nombreFull = row[10].ToString(),
                    edad = row[15].ToString(),
                    fechaExamen = row[16].ToString(),
                    modalidad = row[17].ToString(),
                    descripcion = row[18].ToString(),
                    nombreEstadoExamen = row[21].ToString(),
                    idInstitucion = row[22].ToString(),
                    nombreTipoUrgencia = row[24].ToString(),
                    antecedenteClinico = row[25].ToString(),
                    fechaAsignacion = row[26].ToString(),
                    tiempo = ParamUtil.FormatTime((long) Convert.ToInt32(row[27].ToString())),
                    bloqueado = row[20].ToString() == "0" ? row[28].ToString() : "0",
                    instancias = row[31].ToString(),
                    comentarios = row[32].ToString(),
                    registroOcupado = row[33].ToString(),
                    ejecutante = row[34].ToString(),
                    fechaValidacion = row[35].ToString(),
                    acciones = row[36].ToString(),
                    userNameRadiologo = row[40].ToString(),
                    responsables = (HttpContext.Current.Session["id_perfil"].ToString() == "8" || HttpContext.Current.Session["id_perfil"].ToString() == "4") && row[43].ToString().Contains("V:") ? row[43].ToString().Split('V')[1].ToString().Replace(":","") : row[43].ToString(),
                    addsol = row[44].ToString(),
                    tipoConexion = row[52].ToString(),
                    metodo = row[53].ToString(),
                    urlMetodo = row[54].ToString(),
                    swComentario = row[55].ToString(),
                    tiempoBloqueo = row[56].ToString(),
                    swInstitucion = row[57].ToString(),
                    idEstadoExamen = row[20].ToString(),
                    id_estado_pendiente = row[58].ToString(),
                    fechaCierre = row[59].ToString()
                });

            return source.ToList<ExamenShow>();
        }
    }
}
