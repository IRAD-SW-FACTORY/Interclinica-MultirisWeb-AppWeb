// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Util.EanCodeUtil
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using System.Text.RegularExpressions;

namespace MultiRisWeb.Data.Util
{
  public class EanCodeUtil
  {
    public static int CheckSumEan(string code)
    {
      if (code != new Regex("[^0-9]").Replace(code, ""))
        return 0;
      switch (code.Length)
      {
        case 8:
          code = "000000" + code;
          goto case 14;
        case 12:
          code = "00" + code;
          goto case 14;
        case 13:
          code = "0" + code;
          goto case 14;
        case 14:
          int[] numArray1 = new int[13];
          int[] numArray2 = numArray1;
          char ch = code[0];
          int num1 = int.Parse(ch.ToString()) * 3;
          numArray2[0] = num1;
          int[] numArray3 = numArray1;
          ch = code[1];
          int num2 = int.Parse(ch.ToString());
          numArray3[1] = num2;
          int[] numArray4 = numArray1;
          ch = code[2];
          int num3 = int.Parse(ch.ToString()) * 3;
          numArray4[2] = num3;
          int[] numArray5 = numArray1;
          ch = code[3];
          int num4 = int.Parse(ch.ToString());
          numArray5[3] = num4;
          int[] numArray6 = numArray1;
          ch = code[4];
          int num5 = int.Parse(ch.ToString()) * 3;
          numArray6[4] = num5;
          int[] numArray7 = numArray1;
          ch = code[5];
          int num6 = int.Parse(ch.ToString());
          numArray7[5] = num6;
          int[] numArray8 = numArray1;
          ch = code[6];
          int num7 = int.Parse(ch.ToString()) * 3;
          numArray8[6] = num7;
          int[] numArray9 = numArray1;
          ch = code[7];
          int num8 = int.Parse(ch.ToString());
          numArray9[7] = num8;
          int[] numArray10 = numArray1;
          ch = code[8];
          int num9 = int.Parse(ch.ToString()) * 3;
          numArray10[8] = num9;
          int[] numArray11 = numArray1;
          ch = code[9];
          int num10 = int.Parse(ch.ToString());
          numArray11[9] = num10;
          int[] numArray12 = numArray1;
          ch = code[10];
          int num11 = int.Parse(ch.ToString()) * 3;
          numArray12[10] = num11;
          int[] numArray13 = numArray1;
          ch = code[11];
          int num12 = int.Parse(ch.ToString());
          numArray13[11] = num12;
          int[] numArray14 = numArray1;
          ch = code[12];
          int num13 = int.Parse(ch.ToString()) * 3;
          numArray14[12] = num13;
          int num14 = (10 - (numArray1[0] + numArray1[1] + numArray1[2] + numArray1[3] + numArray1[4] + numArray1[5] + numArray1[6] + numArray1[7] + numArray1[8] + numArray1[9] + numArray1[10] + numArray1[11] + numArray1[12]) % 10) % 10;
          ch = code[13];
          return int.Parse(ch.ToString());
        default:
          return 0;
      }
    }
  }
}
