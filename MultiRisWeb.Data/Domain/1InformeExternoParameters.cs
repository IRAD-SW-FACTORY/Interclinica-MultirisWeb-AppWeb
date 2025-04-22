// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.prestacionesExternasParameters
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

namespace MultiRisWeb.Data.Domain
{
  public class prestacionesExternasParameters
  {
    public int IdInformeExterno { get; set; }

    public int IdPrestacion { get; set; }

    public string CodFonasa { get; set; }

    public string Descripcion { get; set; }

    public prestacionesExternasParameters()
    {
      this.IdInformeExterno = 0;
      this.IdPrestacion = 0;
      this.CodFonasa = string.Empty;
      this.Descripcion = string.Empty;
    }
  }
}
