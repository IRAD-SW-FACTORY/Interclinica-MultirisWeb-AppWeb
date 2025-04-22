// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.InformeDomain
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using System.Collections.Generic;

namespace MultiRisWeb.Data.Domain
{
    public class InformeDomain
    {
        public long IdInforme { get; set; }
        public string Titulo { get; set; }
        public string AntecedentesClinicos { get; set; }
        public string Hallazgos { get; set; }
        public string Impresion { get; set; }
        public string Tecnica { get; set; }
        public int SeleccionPatologiaCritica { get; set; }
        public int IdPatologiaCritica { get; set; }
        public string PatologiaCritica { get; set; }
        public string Aetitle { get; set; }
        public int Estado { get; set; }
        public List<int> IdTags { get; set; }
        public string CodExamen { get; set; }
        public int IdInstitucion { get; set; }   
        public string IdPrestaciones { get; set; }
    }
}
