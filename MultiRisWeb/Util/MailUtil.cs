// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Util.MailUtil
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace MultiRisWeb.Util
{
    public class MailUtil
    {
        public static void SendMail(string emailname, string emailfrom, string emailpass, string emailto, string emailcc, string asunto, string cuerpo)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            
            SmtpClient smtpClient = new SmtpClient() {
                Port = 587,
                Host = "outlook.office365.com",
                EnableSsl = true,
                Timeout = 60000,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = (ICredentialsByHost) new NetworkCredential(emailfrom, emailpass)
            };
      
            MailMessage message = new MailMessage();
            
            if (emailfrom.Length > 0) message.From = new MailAddress(emailfrom, emailname);
      
            string str = emailto;
            string[] separator = new string[1]{ ";" };
      
            foreach (string addresses in str.Split(separator, StringSplitOptions.RemoveEmptyEntries)) message.To.Add(addresses);
            
            if(!emailcc.Equals(string.Empty)) message.CC.Add(emailcc);
            
            message.Subject = asunto;
            message.Body = cuerpo;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            
            smtpClient.Send(message);
        }
    }
}
