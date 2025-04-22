// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Web.QR.GetQR
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using MultiRisWeb.Data.Util;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Web.Caching;

namespace MultiRisWeb.Web.QR
{
  public class GetQR : IHttpHandler
  {
    public void ProcessRequest(HttpContext context)
    {
      string paramString = ParamUtil.GetParamString((object) context.Request["text"], "");
      string str = ParamUtil.GetParamString((object) context.Request["id"], "");
      if (str.Length == 0)
        str = paramString.GetHashCode().ToString().Replace("-", "N");
      Cache cache = HttpRuntime.Cache;
      byte[] byte2;
      if (cache["QR" + str] == null)
      {
        int num;
        switch ("L")
        {
          case "L":
            num = 0;
            break;
          case "M":
            num = 1;
            break;
          case "Q":
            num = 2;
            break;
          default:
            num = 3;
            break;
        }
        QRCodeGenerator.ECCLevel eccLevel = (QRCodeGenerator.ECCLevel) num;
        byte2 = GetQR.ImageToByte2(new QRCode(new QRCodeGenerator().CreateQrCode(paramString, eccLevel)).GetGraphic(20, Color.Black, Color.White, iconSizePercent: 0));
        cache["QR" + str] = (object) byte2;
      }
      else
        byte2 = (byte[]) cache["QR" + str];
      context.Response.Clear();
      context.Response.AddHeader("Content-Disposition", "inline; filename=QR." + str + ".png");
      context.Response.AddHeader("Content-Length", byte2.Length.ToString());
      context.Response.ContentType = "image/png";
      context.Response.BinaryWrite(byte2);
    }

    public static byte[] ImageToByte2(Bitmap img)
    {
      byte[] numArray = new byte[0];
      using (MemoryStream memoryStream = new MemoryStream())
      {
        img.Save((Stream) memoryStream, ImageFormat.Png);
        memoryStream.Close();
        return memoryStream.ToArray();
      }
    }

    public bool IsReusable => false;
  }
}
