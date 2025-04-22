// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Base.DataBaseJson
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MultiRisWeb.Data.Base
{
  public class DataBaseJson
  {
    public static List<T> ListRegistros<T>(DataTable dataTable)
    {
      List<Dictionary<string, object>> dictionaryList = new List<Dictionary<string, object>>();
      if (dataTable == null)
        return new List<T>();
      foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
      {
        Dictionary<string, object> dictionary = new Dictionary<string, object>();
        foreach (DataColumn column in (InternalDataCollectionBase) dataTable.Columns)
          dictionary.Add(column.ColumnName, row[column]);
        dictionaryList.Add(dictionary);
      }
      string str = JsonConvert.SerializeObject((object) dictionaryList);
      return str != null ? JsonConvert.DeserializeObject<List<T>>(str) : new List<T>();
    }

    public static T GetRegistro<T>(DataTable dataTable)
    {
      List<Dictionary<string, object>> source = new List<Dictionary<string, object>>();
      if (dataTable == null)
        return default (T);
      foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
      {
        Dictionary<string, object> dictionary = new Dictionary<string, object>();
        foreach (DataColumn column in (InternalDataCollectionBase) dataTable.Columns)
          dictionary.Add(column.ColumnName, row[column]);
        source.Add(dictionary);
      }
      if (!source.Any<Dictionary<string, object>>())
        return default (T);
      string str = JsonConvert.SerializeObject((object) source);
      return str != null ? JsonConvert.DeserializeObject<List<T>>(str)[0] : default (T);
    }

    public static int GetInt(DataTable dataTable)
    {
      List<Dictionary<string, object>> dictionaryList = new List<Dictionary<string, object>>();
      if (dataTable == null)
        return 0;
      foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
      {
        Dictionary<string, object> dictionary = new Dictionary<string, object>();
        foreach (DataColumn column in (InternalDataCollectionBase) dataTable.Columns)
          dictionary.Add("Data", row[column]);
        dictionaryList.Add(dictionary);
      }
      return int.Parse(dictionaryList[0]["Data"].ToString());
    }
  }
}
