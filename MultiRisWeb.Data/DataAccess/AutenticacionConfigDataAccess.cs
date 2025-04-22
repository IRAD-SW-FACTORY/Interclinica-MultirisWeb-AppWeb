// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.AutenticacionConfigDataAccess
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using IradDBNet;
using IradDBNet.Dto;
using MultiRisWeb.Data.Domain;
using System.Collections.Generic;

namespace MultiRisWeb.Data.DataAccess
{
  public class AutenticacionConfigDataAccess
  {
    public static AutenticacionConfigDomain Get() => DataBaseProcedure.GetEntidad<AutenticacionConfigDomain>(new List<Parameter>(), "sp_AutenticacionConfigGet", "CN_RISPACS");
  }
}
