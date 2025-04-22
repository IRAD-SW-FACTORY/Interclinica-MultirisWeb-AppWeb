// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.RisPlantillaDomain
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

namespace MultiRisWeb.Data.Domain
{
    public class RisPlantillaDomain
    {
        public long id_plantilla { get; set; }

        public string nombre { get; set; }

        public string titulo { get; set; }

        public string tecnica { get; set; }

        public string hallazgos { get; set; }

        public string impresion { get; set; }

        public long id_usuario { get; set; }

        public int id_modalidad { get; set; }
        public string CodExamen { get; set; }

        public RisPlantillaDomain()
        {
            this.id_plantilla = 0L;
            this.nombre = string.Empty;
            this.titulo = string.Empty;
            this.tecnica = string.Empty;
            this.hallazgos = string.Empty;
            this.impresion = string.Empty;
            this.id_usuario = 0L;
            this.id_modalidad = 0;
        }
    }
}
