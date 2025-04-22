// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Parameters.InformeDato
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using System;

namespace MultiRisWeb.Data.Parameters
{
  public class InformeDato
  {
    public long id_informe_dato_remoto { get; set; }

    public string cod_examen { get; set; }

    public int id_dato { get; set; }

    public string valor { get; set; }

    public DateTime fecha { get; set; }

    public long id_informe { get; set; }

    public int posicion { get; set; }

    public InformeDato()
    {
      this.id_informe_dato_remoto = 0L;
      this.cod_examen = string.Empty;
      this.id_dato = 0;
      this.valor = string.Empty;
      this.fecha = new DateTime();
      this.id_informe = 0L;
      this.posicion = 0;
    }
  }
}
