// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.clsAccesoBD
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using System;
using System.Configuration;
using System.Data.SqlClient;

namespace MultiRisWeb.Data.DataAccess
{
  public class clsAccesoBD
  {
    private static string strConexionBDMultiRis = ConfigurationManager.AppSettings["CN_RISPACS2"];
    public SqlConnection cmdBDMultiRis = new SqlConnection(clsAccesoBD.strConexionBDMultiRis);

    public void ConectarMultiRis()
    {
      try
      {
        this.cmdBDMultiRis.Open();
      }
      catch (Exception ex)
      {
      }
    }

    public void DesconectarMultiRis()
    {
      try
      {
        this.cmdBDMultiRis.Close();
      }
      catch (Exception ex)
      {
      }
    }
  }
}
