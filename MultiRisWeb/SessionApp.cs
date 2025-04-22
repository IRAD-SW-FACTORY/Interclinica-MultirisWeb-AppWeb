// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.SessionApp
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using Newtonsoft.Json;
using System.Web;

namespace MultiRisWeb
{
  public class SessionApp
  {
    public const string KeyRadiolpogoBecado = "KeyRadiolpogoBecado";

    public static void Set(string Key, object obj) => HttpContext.Current.Session[Key] = (object) JsonConvert.SerializeObject(obj);

    public static T Get<T>(string key) => JsonConvert.DeserializeObject<T>(HttpContext.Current.Session[key].ToString());
  }
}
