// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Base.DataBase
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MultiRisWeb.Data.Base
{
  public class DataBase
  {
    public static DataTable EjecutarProcedure(
      List<DataBaseParametro> parametros,
      string ProcedimientoAlmacenado)
    {
      DataSet dataSet = new DataSet();
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
      string connectionString = ConfigurationManager.ConnectionStrings["CN_RISPACS"].ConnectionString;
      try
      {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
          using (SqlCommand comando = new SqlCommand(ProcedimientoAlmacenado, connection))
          {
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandTimeout = connection.ConnectionTimeout;
            comando.Parameters.Clear();
            foreach (DataBaseParametro parametro in parametros)
              DataBase.AddParametro(parametro, comando);
            sqlDataAdapter.SelectCommand = comando;
            sqlDataAdapter.Fill(dataSet);
          }
        }
        return dataSet.Tables[0];
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public static DataTable EjecutarProcedure2(
      List<DataBaseParametro> parametros,
      string ProcedimientoAlmacenado)
    {
      DataSet dataSet = new DataSet();
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
      string connectionString = ConfigurationManager.ConnectionStrings["CN_RISPACSNORMALIZAR"].ConnectionString;
      try
      {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
          using (SqlCommand comando = new SqlCommand(ProcedimientoAlmacenado, connection))
          {
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandTimeout = connection.ConnectionTimeout;
            comando.Parameters.Clear();
            foreach (DataBaseParametro parametro in parametros)
              DataBase.AddParametro(parametro, comando);
            sqlDataAdapter.SelectCommand = comando;
            sqlDataAdapter.Fill(dataSet);
          }
        }
        return dataSet.Tables[0];
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public static DataTable EjecutarProcedureServicio(
      List<DataBaseParametro> parametros,
      string ProcedimientoAlmacenado)
    {
      DataSet dataSet = new DataSet();
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
      string connectionString = ConfigurationManager.ConnectionStrings["CN_RISPACSRIS"].ConnectionString;
      try
      {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
          using (SqlCommand comando = new SqlCommand(ProcedimientoAlmacenado, connection))
          {
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandTimeout = connection.ConnectionTimeout;
            comando.Parameters.Clear();
            foreach (DataBaseParametro parametro in parametros)
              DataBase.AddParametro(parametro, comando);
            sqlDataAdapter.SelectCommand = comando;
            sqlDataAdapter.Fill(dataSet);
          }
        }
        return dataSet.Tables[0];
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public static DataSet EjecutarProcedureDataSet(
      List<DataBaseParametro> parametros,
      string ProcedimientoAlmacenado)
    {
      DataSet dataSet = new DataSet();
      string connectionString = ConfigurationManager.ConnectionStrings["CN_RISPACS"].ConnectionString;
      try
      {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
          using (SqlCommand comando = new SqlCommand(ProcedimientoAlmacenado, connection))
          {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandTimeout = connection.ConnectionTimeout;
            comando.Parameters.Clear();
            foreach (DataBaseParametro parametro in parametros)
              DataBase.AddParametro(parametro, comando);
            sqlDataAdapter.SelectCommand = comando;
            sqlDataAdapter.Fill(dataSet);
          }
        }
        return dataSet;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public static void EjecutarProcedureSinResultado(
      List<DataBaseParametro> parametros,
      string ProcedimientoAlmacenado)
    {
      DataSet dataSet = new DataSet();
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
      string connectionString = ConfigurationManager.ConnectionStrings["CN_RISPACS"].ConnectionString;
      try
      {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
          using (SqlCommand comando = new SqlCommand(ProcedimientoAlmacenado, connection))
          {
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandTimeout = connection.ConnectionTimeout;
            comando.Parameters.Clear();
            foreach (DataBaseParametro parametro in parametros)
              DataBase.AddParametro(parametro, comando);
            sqlDataAdapter.SelectCommand = comando;
            sqlDataAdapter.Fill(dataSet);
          }
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public static DataTable EjecutarQuery(string queryEjecutar)
    {
      DataSet dataSet = new DataSet();
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
      string connectionString = ConfigurationManager.ConnectionStrings["CN_RISPACS"].ConnectionString;
      try
      {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
          using (SqlCommand selectCommand = new SqlCommand(queryEjecutar, connection))
          {
            connection.Open();
            new SqlDataAdapter(selectCommand).Fill(dataSet);
            connection.Close();
          }
          return dataSet.Tables[0];
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public static DataSet EjecutarQueryDataSet(string queryEjecutar)
    {
      DataSet dataSet = new DataSet();
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
      string connectionString = ConfigurationManager.ConnectionStrings["CN_RISPACS"].ConnectionString;
      try
      {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
          using (SqlCommand selectCommand = new SqlCommand(queryEjecutar, connection))
          {
            connection.Open();
            new SqlDataAdapter(selectCommand).Fill(dataSet);
            connection.Close();
          }
          return dataSet;
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public static void AddParametro(DataBaseParametro parametro, SqlCommand comando)
    {
      try
      {
        SqlParameterCollection parameters = comando.Parameters;
        SqlParameter sqlParameter = new SqlParameter();
        sqlParameter.ParameterName = parametro.Nombre;
        sqlParameter.Value = parametro.Valor;
        sqlParameter.DbType = parametro.Tipo;
        parameters.Add(sqlParameter);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
