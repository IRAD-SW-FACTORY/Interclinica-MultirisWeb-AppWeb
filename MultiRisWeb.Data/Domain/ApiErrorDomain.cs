// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.ApiErrorDomain
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

namespace MultiRisWeb.Data.Domain
{
  public class ApiErrorDomain
  {
    public long id_api_error { get; set; }

    public string staktrace { get; set; }

    public int id_institucion { get; set; }

    public ApiErrorDomain()
    {
      this.id_api_error = 0L;
      this.staktrace = string.Empty;
      this.id_institucion = 0;
    }
  }
}
