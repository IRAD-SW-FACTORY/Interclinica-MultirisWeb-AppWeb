// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.SeriesDomain
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

namespace MultiRisWeb.Data.Domain
{
  public class SeriesDomain
  {
    public string GUID { get; set; }

    public string ServerPartitionGUID { get; set; }

    public string StudyGUID { get; set; }

    public string SeriesInstanceUid { get; set; }

    public string Modality { get; set; }

    public string SeriesNumber { get; set; }

    public string SeriesDescription { get; set; }

    public string NumberOfseriesRelatedInstances { get; set; }

    public string PerformedProcedureStepStartDate { get; set; }

    public string PerformedProcedureStepStartTime { get; set; }

    public string SourceApplicationEntityTitle { get; set; }

    public SeriesDomain()
    {
      this.GUID = string.Empty;
      this.ServerPartitionGUID = string.Empty;
      this.StudyGUID = string.Empty;
      this.SeriesInstanceUid = string.Empty;
      this.Modality = string.Empty;
      this.SeriesNumber = string.Empty;
      this.SeriesDescription = string.Empty;
      this.NumberOfseriesRelatedInstances = string.Empty;
      this.PerformedProcedureStepStartDate = string.Empty;
      this.PerformedProcedureStepStartTime = string.Empty;
      this.SourceApplicationEntityTitle = string.Empty;
    }
  }
}
