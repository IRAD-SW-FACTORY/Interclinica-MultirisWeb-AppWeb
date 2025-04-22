// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Util.LogApp
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using System;
using System.IO;

namespace MultiRisWeb.Util
{
  public class LogApp
  {
    public string MensajeLog { get; set; }

    public string NombreArchivo { get; set; }

    public LogApp(string mensajeEnviar, string nombreArchivo)
    {
      this.MensajeLog = mensajeEnviar;
      this.NombreArchivo = nombreArchivo;
      this.EscribirLineaFichero();
    }

    public LogApp() => this.EscribirLineaFichero();

    public void EscribirLineaFichero()
    {
      try
      {
        StreamWriter streamWriter = new StreamWriter((Stream) new FileStream(AppDomain.CurrentDomain.BaseDirectory + this.NombreArchivo, FileMode.OpenOrCreate, FileAccess.Write));
        streamWriter.BaseStream.Seek(0L, SeekOrigin.End);
        this.MensajeLog = this.MensajeLog.Replace(Environment.NewLine, " | ");
        this.MensajeLog = this.MensajeLog.Replace("\r\n", " | ").Replace("\n", " | ").Replace("\r", " | ");
        streamWriter.WriteLine(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + " " + this.MensajeLog);
        streamWriter.Flush();
        streamWriter.Close();
      }
      catch
      {
      }
    }
  }
}
