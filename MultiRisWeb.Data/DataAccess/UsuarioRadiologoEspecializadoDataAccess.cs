// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.UsuarioRadiologoEspecializadoDataAccess
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
  public class UsuarioRadiologoEspecializadoDataAccess
  {
    public static List<UsuarioRadiologoEspecializadoDomain> Listar(long idUsuarioEspecializado) => DataBaseProcedure.ListEntidad<UsuarioRadiologoEspecializadoDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "@idUsuarioEspecializado",
        Type = DbType.Int64,
        Value = (object) idUsuarioEspecializado
      }
    }, "spListarRadiologosEspecializado", "CN_RISPACS");
  }
}
