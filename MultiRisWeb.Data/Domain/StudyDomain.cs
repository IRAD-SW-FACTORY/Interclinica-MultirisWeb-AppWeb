// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.StudyDomain
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

namespace MultiRisWeb.Data.Domain
{
  public class StudyDomain
  {
    public string GUID { get; set; }

    public string ServerPartitionGUID { get; set; }

    public string StudyStorageGUID { get; set; }

    public string PatientGUID { get; set; }

    public string StudyInstanceUid { get; set; }

    public string PatientsName { get; set; }

    public string PatientId { get; set; }

    public string PatientsSex { get; set; }

    public string StudyDate { get; set; }

    public string StudyTime { get; set; }

    public string AccessionNumber { get; set; }

    public string StudyDescription { get; set; }

    public string NumberOfStudyRelatedSeries { get; set; }

    public string NumberOfStudyRelatedInstances { get; set; }

    public string StudySizeInKB { get; set; }

    public StudyDomain()
    {
      this.GUID = string.Empty;
      this.ServerPartitionGUID = string.Empty;
      this.StudyStorageGUID = string.Empty;
      this.PatientGUID = string.Empty;
      this.StudyInstanceUid = string.Empty;
      this.PatientsName = string.Empty;
      this.PatientId = string.Empty;
      this.PatientsSex = string.Empty;
      this.StudyDate = string.Empty;
      this.StudyTime = string.Empty;
      this.AccessionNumber = string.Empty;
      this.StudyDescription = string.Empty;
      this.NumberOfStudyRelatedSeries = string.Empty;
      this.NumberOfStudyRelatedInstances = string.Empty;
      this.StudySizeInKB = string.Empty;
    }
  }
}
