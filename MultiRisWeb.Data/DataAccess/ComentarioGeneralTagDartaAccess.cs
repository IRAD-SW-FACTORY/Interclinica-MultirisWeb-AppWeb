// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.ComentarioGeneralTagDartaAccess
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
  public class ComentarioGeneralTagDartaAccess
  {
    public static ComentarioGeneralTagDomain Get(string usuario, long idExamen) => DataBaseProcedure.GetEntidad<ComentarioGeneralTagDomain>(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "@usuario",
        Type = DbType.String,
        Value = (object) usuario
      },
      new Parameter()
      {
        Name = "@idExamen",
        Type = DbType.Int64,
        Value = (object) idExamen
      }
    }, "spComentarioGeneralTagGet", "CN_RISPACS");

    public static bool InsertOrUpdate(ComentarioGeneralTagDomain comentarioGeneralTag) => DataBaseProcedure.GetInt(new List<Parameter>()
    {
      new Parameter()
      {
        Name = "@idExamen",
        Type = DbType.Int64,
        Value = (object) comentarioGeneralTag.IdExamen
      },
      new Parameter()
      {
        Name = "@comentario",
        Type = DbType.String,
        Value = (object) comentarioGeneralTag.ComentarioGeneral
      },
      new Parameter()
      {
        Name = "@usuario",
        Type = DbType.String,
        Value = (object) comentarioGeneralTag.Usuario
      }
    }, "spComentarioGeneralTagInsertOrUpdate", "CN_RISPACS") > 0;
  }
}
