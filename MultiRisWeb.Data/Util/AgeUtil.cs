// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Util.AgeUtil
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using System;

namespace MultiRisWeb.Data.Util
{
  public class AgeUtil
  {
    public string calculateAge(DateTime fecha_nacimiento)
    {
      DateTime now = DateTime.Now;
      int num = now.Year - fecha_nacimiento.Year;
      if (now < fecha_nacimiento.AddYears(num))
        --num;
      return num.ToString();
    }

    public string calculateAgeExamen(DateTime fecha_nacimiento, DateTime fecha_examen)
    {
      int num = fecha_examen.Year - fecha_nacimiento.Year;
      if (fecha_examen < fecha_nacimiento.AddYears(num))
        --num;
      return num.ToString();
    }
  }
}
