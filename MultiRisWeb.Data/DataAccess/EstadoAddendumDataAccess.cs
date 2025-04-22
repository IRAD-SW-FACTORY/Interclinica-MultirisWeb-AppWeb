// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.EstadoAddendumDataAccess
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
  public class EstadoAddendumDataAccess
  {
    public static IList<EstadoAddendumDomain> ListAll() => (IList<EstadoAddendumDomain>) DataBaseProcedure.ListEntidad<EstadoAddendumDomain>(new List<Parameter>(), "sp_EstadoAddendum_ListAll", "CN_RISPACS");

    private static EstadoAddendumDomain BuildFunction(IDataReader row) => new EstadoAddendumDomain()
    {
      id_estado_addendum = row["id_estado_addendum"] != DBNull.Value ? (int) row["id_estado_addendum"] : 0,
      nombre = row["nombre"] != DBNull.Value ? (string) row["nombre"] : string.Empty
    };
  }
}
