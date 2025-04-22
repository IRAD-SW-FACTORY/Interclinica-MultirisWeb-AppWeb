// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Util.ParamUtil
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using System;
using System.Text;
using System.Web.UI.WebControls;

namespace MultiRisWeb.Data.Util
{
  public class ParamUtil
  {
    public static string GetParam(string param) => param == null ? string.Empty : param.Trim().Replace("'", "''");

    public static string[] GetValoresStrListbox(ListBox control)
    {
      string[] valoresStrListbox = new string[0];
      int length = 0;
      if (control.Items.Count > 0)
      {
        for (int index = 0; index < control.Items.Count; ++index)
        {
          if (control.Items[index].Selected)
            ++length;
        }
        valoresStrListbox = new string[length];
        int index1 = 0;
        for (int index2 = 0; index2 < control.Items.Count; ++index2)
        {
          if (control.Items[index2].Selected)
          {
            valoresStrListbox[index1] = control.Items[index2].Value;
            ++index1;
          }
        }
      }
      return valoresStrListbox;
    }

    public static string GetParamString(object valor, string valordefault) => valor == null ? valordefault : valor.ToString();

    public static long GetParamLong(object valor, long valordefault)
    {
      long paramLong = valordefault;
      if (valor != null)
      {
        try
        {
          paramLong = (long) Convert.ToInt32(valor);
        }
        catch (Exception ex)
        {
          ex.ToString();
          paramLong = valordefault;
        }
      }
      return paramLong;
    }

    public static float GetParamFloat(object valor, float valordefault)
    {
      float paramFloat = valordefault;
      if (valor != null)
      {
        try
        {
          paramFloat = (float) Convert.ToInt32(valor);
        }
        catch (Exception ex)
        {
          ex.ToString();
          paramFloat = valordefault;
        }
      }
      return paramFloat;
    }

    public static string GetString(long[] value)
    {
      string str1 = "";
      string str2 = "";
      for (int index = 0; index < value.Length; ++index)
      {
        str1 = str1 + str2 + value[index].ToString();
        str2 = ",";
      }
      return str1;
    }

    public static string[] GetParamStringValues(object valor, string[] valordefault)
    {
      string[] paramStringValues = valordefault;
      if (valor != null)
      {
        if (valor.ToString().Length > 0)
        {
          try
          {
            paramStringValues = valor.ToString().Split(',');
          }
          catch (Exception ex)
          {
            ex.ToString();
            paramStringValues = valordefault;
          }
        }
      }
      return paramStringValues;
    }

    public static long[] GetParamLongValues(object valor, long[] valordefault)
    {
      long[] paramLongValues = valordefault;
      if (valor != null)
      {
        if (valor.ToString().Length > 0)
        {
          try
          {
            string[] strArray = valor.ToString().Split(',');
            paramLongValues = new long[strArray.Length];
            for (int index = 0; index < paramLongValues.Length; ++index)
            {
              try
              {
                paramLongValues[index] = (long) Convert.ToUInt32(strArray[index].Trim());
              }
              catch (Exception ex)
              {
                ex.ToString();
                paramLongValues[index] = 0L;
              }
            }
          }
          catch (Exception ex)
          {
            ex.ToString();
            paramLongValues = valordefault;
          }
        }
      }
      return paramLongValues;
    }

    public static int GetParamInt(object valor, int valordefault)
    {
      int paramInt = valordefault;
      if (valor != null)
      {
        try
        {
          paramInt = (int) Convert.ToInt16(valor);
        }
        catch (Exception ex)
        {
          ex.ToString();
          paramInt = valordefault;
        }
      }
      return paramInt;
    }

    public static string CalculateAgeDicom(DateTime Bday, DateTime Cday)
    {
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      if (Cday.Year - Bday.Year > 0 || Cday.Year - Bday.Year == 0 && (Bday.Month < Cday.Month || Bday.Month == Cday.Month && Bday.Day <= Cday.Day))
      {
        int num4 = DateTime.DaysInMonth(Bday.Year, Bday.Month);
        int num5 = Cday.Day + (num4 - Bday.Day);
        if (Cday.Month > Bday.Month)
        {
          num1 = Cday.Year - Bday.Year;
          num2 = Cday.Month - (Bday.Month + 1) + Math.Abs(num5 / num4);
          num3 = (num5 % num4 + num4) % num4;
        }
        else if (Cday.Month == Bday.Month)
        {
          if (Cday.Day >= Bday.Day)
          {
            num1 = Cday.Year - Bday.Year;
            num2 = 0;
            num3 = Cday.Day - Bday.Day;
          }
          else
          {
            num1 = Cday.Year - 1 - Bday.Year;
            num2 = 11;
            num3 = DateTime.DaysInMonth(Bday.Year, Bday.Month) - (Bday.Day - Cday.Day);
          }
        }
        else
        {
          num1 = Cday.Year - 1 - Bday.Year;
          num2 = Cday.Month + (11 - Bday.Month) + Math.Abs(num5 / num4);
          num3 = (num5 % num4 + num4) % num4;
        }
      }
      return num1 <= 0 ? (num1 != 0 || num2 <= 0 ? (num1 != 0 || num2 != 0 || num3 <= 0 ? ParamUtil.DicomValue(0, "Y") : ParamUtil.DicomValue(num3, "D")) : ParamUtil.DicomValue(num2, "M")) : ParamUtil.DicomValue(num1, "Y");
    }

    public static string DicomValue(int value, string sufijo)
    {
      string str = "000" + sufijo;
      if (value < 10)
        str = "00" + value.ToString() + sufijo;
      if (value >= 10 && value < 100)
        str = "0" + value.ToString() + sufijo;
      if (value > 100)
        str = value.ToString() + sufijo;
      return str;
    }

    public static string DecodeFrom64(string encodedData) => Encoding.ASCII.GetString(Convert.FromBase64String(encodedData));

    public static string GetInParam(string[] valor)
    {
      string inParam = "";
      if (valor.Length != 0)
      {
        string str1 = "";
        string str2 = "";
        for (int index = 0; index < valor.Length; ++index)
        {
          str1 = str1 + str2 + valor[index];
          str2 = ",";
        }
        inParam = str1;
      }
      return inParam;
    }

    public static string FormatTime(long minutos)
    {
      if (minutos == 0L)
        return "";
      TimeSpan timeSpan = new TimeSpan(0, (int) minutos, 0);
      return string.Format("{0}d:{1}h:{2}m", (object) timeSpan.Days, (object) timeSpan.Hours, (object) timeSpan.Minutes);
    }
  }
}
