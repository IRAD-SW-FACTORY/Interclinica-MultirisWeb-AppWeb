// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Parameters.Prestacion
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

namespace MultiRisWeb.Data.Parameters
{
  public class Prestacion
  {
    public long id_prestacion { get; set; }

    public long id_prestacion_remoto { get; set; }

    public string aetitle { get; set; }

    public int id_institucion { get; set; }

    public string nombre { get; set; }

    public bool oit { get; set; }

    public Prestacion()
    {
      this.id_prestacion = 0L;
      this.id_prestacion_remoto = 0L;
      this.aetitle = string.Empty;
      this.id_institucion = 0;
      this.nombre = string.Empty;
      this.oit = false;
    }
  }
}
