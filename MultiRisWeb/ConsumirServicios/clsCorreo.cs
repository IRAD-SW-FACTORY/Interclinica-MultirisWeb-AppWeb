// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.ConsumirServicios.clsCorreo
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using MailKit;
using MailKit.Net.Smtp;
using MimeKit;
using System.Configuration;
using System.Threading;

namespace MultiRisWeb.ConsumirServicios
{
  public class clsCorreo
  {
    public static void EnvioMail(string nombreCentroSalud, string aetitle)
    {
      string str = "<html><body> <h3> Se informa que el centro : " + nombreCentroSalud + " Presento una caida en su WS, favor ver. </h3> </body></html>";
      MimeMessage message = new MimeMessage();
      message.From.Add((InternetAddress) new MailboxAddress("", ConfigurationManager.AppSettings["correoFrom"]));
      message.To.Add((InternetAddress) new MailboxAddress("", ConfigurationManager.AppSettings["correoTo"]));
      message.Subject = "Caida Centro De Salud: " + aetitle;
      message.Body = new BodyBuilder() { HtmlBody = str }.ToMessageBody();
      using (SmtpClient smtpClient = new SmtpClient())
      {
        smtpClient.Connect("mail.notificacioncritica.cl", 465, true, new CancellationToken());
        smtpClient.Authenticate(ConfigurationManager.AppSettings["correoFrom"], ConfigurationManager.AppSettings["correoContraseña"], new CancellationToken());
        smtpClient.Send(message, new CancellationToken(), (ITransferProgress) null);
        smtpClient.Disconnect(true, new CancellationToken());
      }
    }
  }
}
