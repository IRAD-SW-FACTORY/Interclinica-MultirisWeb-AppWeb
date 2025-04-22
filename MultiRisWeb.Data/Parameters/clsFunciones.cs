// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Parameters.clsFunciones
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using MultiRisWeb.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MultiRisWeb.Data.Parameters
{
  public class clsFunciones
  {
    private clsAccesoBD objConexion = new clsAccesoBD();

    public int indIdPerfil { get; set; }

    public string strNombre { get; set; }

    public string strDescripcion { get; set; }

    public string strMenu { get; set; }

    public List<clsFunciones> BuscarFunciones(string usuario)
    {
      List<clsFunciones> clsFuncionesList = new List<clsFunciones>();
      this.objConexion.ConectarMultiRis();
      try
      {
        SqlCommand sqlCommand = new SqlCommand("sp_buscarFuncionMenu", this.objConexion.cmdBDMultiRis);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@vcUsername", (object) usuario);
        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
        while (sqlDataReader.Read())
          clsFuncionesList.Add(new clsFunciones()
          {
            indIdPerfil = Convert.ToInt32(sqlDataReader["id_perfil"]),
            strNombre = sqlDataReader["nombre"].ToString(),
            strDescripcion = sqlDataReader["descripcion"].ToString(),
            strMenu = sqlDataReader["menu"].ToString()
          });
        return clsFuncionesList;
      }
      catch (Exception ex)
      {
        return clsFuncionesList;
      }
      finally
      {
        this.objConexion.DesconectarMultiRis();
      }
    }
  }
}
