// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Domain.FiltroDomain
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using System;

namespace MultiRisWeb.Data.Domain
{
    public class FiltroDomain
    {
        public long id_filtro { get; set; }

        public string nombre { get; set; }

        public long id_usuario { get; set; }

        public int id_estado { get; set; }

        public long veces_usado { get; set; }

        public DateTime fecha_ultimo_uso { get; set; }
        public string tipo_filtro { get; set; }

        public FiltroDomain()
        {
            this.id_filtro = 0L;
            this.nombre = string.Empty;
            this.id_usuario = 0L;
            this.id_estado = 0;
            this.veces_usado = 0L;
            this.fecha_ultimo_uso = new DateTime();
        }
    }
}
