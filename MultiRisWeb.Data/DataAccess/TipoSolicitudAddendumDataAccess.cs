// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.TipoSolicitudAddendumDataAccess
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
  public class TipoSolicitudAddendumDataAccess
  {
    public static List<TipoSolicitudAddendumDomain> Listar(int vigente = 1) => DataBaseProcedure.ListEntidad<TipoSolicitudAddendumDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "@vigente",
        Type = DbType.Int32,
        Value = (object) vigente
      }
    }, "sp_SolicitudAddendumListarTipo", "CN_RISPACS");
  }
}
