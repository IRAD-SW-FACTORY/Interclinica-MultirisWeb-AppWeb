// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.DataAccess.StudyDataAccess
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using IradDBNet;
using IradDBNet.Dao;
using IradDBNet.Dto;
using MultiRisWeb.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data;

namespace MultiRisWeb.Data.DataAccess
{
  public class StudyDataAccess
  {
    public static string ObtenerPath(string studyInstanceUid, string aetitle)
    {
      string empty = string.Empty;
      DataTable dataTable = StoredProcedure.EjecutarProcedure(new List<Parameter>()
      {
        new Parameter()
        {
          Name = nameof (studyInstanceUid),
          Type = DbType.String,
          Value = (object) studyInstanceUid
        },
        new Parameter()
        {
          Name = "AeTitle",
          Type = DbType.String,
          Value = (object) aetitle
        }
      }, "sp_ObtenerPath", "CN_RISPACS");
      if (dataTable.Rows.Count > 0)
        empty = dataTable.Rows[0]["filepath"].ToString();
      return empty;
    }

    public static StudyDomain GetByStudyInstanceUID(string sudyinstanceuid)
    {
      List<Parameter> parameters = new List<Parameter>();
      StudyDomain studyDomain = new StudyDomain();
      parameters.Add(new Parameter()
      {
        Name = nameof (sudyinstanceuid),
        Type = DbType.String,
        Value = (object) sudyinstanceuid
      });
      return DataBaseProcedure.GetEntidad<StudyDomain>(parameters, "sp_Study_GetByStudyInstanceUid") ?? new StudyDomain();
    }

    private static StudyDomain BuildFunction(IDataReader row) => new StudyDomain()
    {
      GUID = row["GUID"] != DBNull.Value ? (string) row["GUID"] : string.Empty,
      ServerPartitionGUID = row["ServerPartitionGUID"] != DBNull.Value ? (string) row["ServerPartitionGUID"] : string.Empty,
      StudyStorageGUID = row["StudyStorageGUID"] != DBNull.Value ? (string) row["StudyStorageGUID"] : string.Empty,
      PatientGUID = row["PatientGUID"] != DBNull.Value ? (string) row["PatientGUID"] : string.Empty,
      StudyInstanceUid = row["StudyInstanceUid"] != DBNull.Value ? (string) row["StudyInstanceUid"] : string.Empty,
      PatientsName = row["PatientsName"] != DBNull.Value ? (string) row["PatientsName"] : string.Empty,
      PatientId = row["PatientId"] != DBNull.Value ? (string) row["PatientId"] : string.Empty,
      PatientsSex = row["PatientsSex"] != DBNull.Value ? (string) row["PatientsSex"] : string.Empty,
      StudyDate = row["StudyDate"] != DBNull.Value ? (string) row["StudyDate"] : string.Empty,
      StudyTime = row["StudyTime"] != DBNull.Value ? (string) row["StudyTime"] : string.Empty,
      AccessionNumber = row["AccessionNumber"] != DBNull.Value ? (string) row["AccessionNumber"] : string.Empty,
      StudyDescription = row["StudyDescription"] != DBNull.Value ? (string) row["StudyDescription"] : string.Empty,
      NumberOfStudyRelatedSeries = row["NumberOfStudyRelatedSeries"] != DBNull.Value ? (string) row["NumberOfStudyRelatedSeries"] : string.Empty,
      NumberOfStudyRelatedInstances = row["NumberOfStudyRelatedInstances"] != DBNull.Value ? (string) row["NumberOfStudyRelatedInstances"] : string.Empty,
      StudySizeInKB = row["StudySizeInKB"] != DBNull.Value ? (string) row["StudySizeInKB"] : string.Empty
    };
  }
}
