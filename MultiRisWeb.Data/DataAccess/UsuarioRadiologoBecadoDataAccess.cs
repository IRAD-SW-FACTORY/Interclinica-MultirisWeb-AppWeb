// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.UsuarioRadiologoBecadoDataAccess
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using IradDBNet;
using IradDBNet.Dto;
using MultiRisWeb.Data.Domain;
using System.Collections.Generic;
using System.Data;

namespace MultiRisWeb.Data.DataAccess
{
  public class UsuarioRadiologoBecadoDataAccess
  {
    public static List<UsuarioRadiologoBecadoDomain> Listar(long idUsuarioBecado) => DataBaseProcedure.ListEntidad<UsuarioRadiologoBecadoDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "@idUsuarioBecado",
        Type = DbType.Int64,
        Value = (object) idUsuarioBecado
      }
    }, "spListarRadiologosBecado", "CN_RISPACS");
  }
}
