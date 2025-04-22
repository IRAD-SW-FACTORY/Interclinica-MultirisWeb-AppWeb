// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.SeriesDataAccess
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
  public class SeriesDataAccess
  {
    public static IList<SeriesDomain> GetByStudyInsanceUIDAndAETITLE(
      string studyinstanceuid,
      string aetitle)
    {
      return (IList<SeriesDomain>) DataBaseProcedure.ListEntidad<SeriesDomain>(new List<Parameter>()
      {
        new Parameter()
        {
          Name = nameof (studyinstanceuid),
          Type = DbType.String,
          Value = (object) studyinstanceuid
        },
        new Parameter()
        {
          Name = nameof (aetitle),
          Type = DbType.String,
          Value = (object) aetitle
        }
      }, "sp_Series_GetByStudyInsanceUIDAndAETITLE", "CN_RISPACS");
    }

    private static SeriesDomain BuildFunction(IDataReader row) => new SeriesDomain()
    {
      GUID = row["GUID"] != DBNull.Value ? (string) row["GUID"] : string.Empty,
      ServerPartitionGUID = row["ServerPartitionGUID"] != DBNull.Value ? (string) row["ServerPartitionGUID"] : string.Empty,
      StudyGUID = row["StudyGUID"] != DBNull.Value ? (string) row["StudyGUID"] : string.Empty,
      SeriesInstanceUid = row["SeriesInstanceUid"] != DBNull.Value ? (string) row["SeriesInstanceUid"] : string.Empty,
      Modality = row["Modality"] != DBNull.Value ? (string) row["Modality"] : string.Empty,
      SeriesNumber = row["SeriesNumber"] != DBNull.Value ? (string) row["SeriesNumber"] : string.Empty,
      SeriesDescription = row["SeriesDescription"] != DBNull.Value ? (string) row["SeriesDescription"] : string.Empty,
      NumberOfseriesRelatedInstances = row["NumberOfseriesRelatedInstances"] != DBNull.Value ? (string) row["NumberOfseriesRelatedInstances"] : string.Empty,
      PerformedProcedureStepStartDate = row["PerformedProcedureStepStartDate"] != DBNull.Value ? (string) row["PerformedProcedureStepStartDate"] : string.Empty,
      PerformedProcedureStepStartTime = row["PerformedProcedureStepStartTime"] != DBNull.Value ? (string) row["PerformedProcedureStepStartTime"] : string.Empty,
      SourceApplicationEntityTitle = row["SourceApplicationEntityTitle"] != DBNull.Value ? (string) row["SourceApplicationEntityTitle"] : string.Empty
    };
  }
}
