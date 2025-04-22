// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.ExamenTagDomain
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using MultiRisWeb.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiRisWeb.Data.Domain
{
  public class ExamenTagDomain
  {
    public long Id { get; set; }

    public int Instancias { get; set; }

    public string NumeroAcceso { get; set; }

    public string Institucion { get; set; }

    public int IdInstitucion { get; set; }

    public string CodExamen { get; set; }

    public string TipoAtencion { get; set; }

    public DateTime FechaExamen { get; set; }

    public DateTime FechaAsignacion { get; set; }

    public DateTime FechaValidacion { get; set; }

    public int Tiempo { get; set; }

    public string Paciente { get; set; }

    public string NombrePaciente { get; set; }

    public string Edad { get; set; }

    public string Descripcion { get; set; }

    public string Modalidad { get; set; }

    public string Ejecutante { get; set; }

    public string Estado { get; set; }

    public string ComentarioTag { get; set; }

    public int tagExamen { get; set; }

    public string usuario { get; set; }

    public string FechaExamenText => this.FechaExamen.ToString("dd-MM-yyyy HH:mm:ss");

    public string FechaAsignacionText => this.FechaAsignacion.ToString("dd-MM-yyyy HH:mm:ss");

    public string FechaValidacionText => this.FechaValidacion.ToString("dd-MM-yyyy HH:mm:ss");

    public string TiempoText
    {
      get
      {
        TimeSpan timeSpan = new TimeSpan(0, this.Tiempo, 0);
        return timeSpan.Days.ToString() + "d " + timeSpan.Hours.ToString() + "h " + timeSpan.Minutes.ToString() + "m " + timeSpan.Seconds.ToString() + "s";
      }
    }

    public string Tags
    {
      get
      {
        List<TagExamenListarDomain> source = TagExamenDataAccess.ObtieneExamenTag(this.CodExamen, this.tagExamen);
        if (!source.Any<TagExamenListarDomain>())
          return "<label class='col-12'>No Existen Tags</label>";
        string tags = string.Empty;
        foreach (TagExamenListarDomain examenListarDomain in source)
          tags = tags + "<label class='col-12'>" + examenListarDomain.TagExamen + "</label>";
        return tags;
      }
    }
  }
}
