// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.PerfilDataAccess
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using IradDBNet;
using IradDBNet.Dto;
using MultiRisWeb.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data;

namespace MultiRisWeb.Data.DataAccess
{
  public class PerfilDataAccess
  {
    public static PerfilDomain GetById(int id_perfil)
    {
      List<Parameter> parameters = new List<Parameter>();
      parameters.Add(new Parameter()
      {
        Name = nameof (id_perfil),
        Type = DbType.Int32,
        Value = (object) id_perfil
      });
      PerfilDomain perfilDomain = new PerfilDomain();
      return DataBaseProcedure.GetEntidad<PerfilDomain>(parameters, "sp_Perfil_GetById", "CN_RISPACS") ?? new PerfilDomain();
    }

    public static IList<PerfilDomain> GetAll() => (IList<PerfilDomain>) DataBaseProcedure.ListEntidad<PerfilDomain>(new List<Parameter>(), "sp_Perfil_GetAll", "CN_RISPACS");

    public static int InstExter(long UsuarioExt) => DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "idUsuario",
        Type = DbType.Int32,
        Value = (object) UsuarioExt
      }
    }, "sp_TraeInstitucion_Ext", "CN_RISPACS");

    private static PerfilDomain BuildFunction(IDataReader row) => new PerfilDomain()
    {
      id_perfil = row["id_perfil"] != DBNull.Value ? (long) row["id_perfil"] : 0L,
      nombre = row["nombre"] != DBNull.Value ? (string) row["nombre"] : string.Empty,
      descripcion = row["descripcion"] != DBNull.Value ? (string) row["descripcion"] : string.Empty,
      id_perfil_visualizacion = row["id_perfil_visualizacion"] != DBNull.Value ? (int) row["id_perfil_visualizacion"] : 0,
      asignar = row["asignar"] != DBNull.Value && (bool) row["asignar"]
    };
  }
}
