// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.TipoUrgenciaDomain
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

namespace MultiRisWeb.Data.Domain
{
    public class TipoUrgenciaDomain
    {
        public int id_tipo_urgencia { get; set; }

        public string nombre { get; set; }

        public string descripcion { get; set; }

        public int estado { get; set; }

        public int minutos_entrega { get; set; }
        public string nombre_corto { get; set; }

        public TipoUrgenciaDomain()
        {
            this.id_tipo_urgencia = 0;
            this.nombre = string.Empty;
            this.descripcion = string.Empty;
            this.estado = 0;
            this.minutos_entrega = 0;
            this.nombre_corto = string.Empty;
        }
    }
}
