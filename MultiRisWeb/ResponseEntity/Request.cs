// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.ResponseEntity.Request
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using Newtonsoft.Json;
using System;

namespace MultiRisWeb.ResponseEntity
{
	[JsonObject]
	[Serializable]
	public class Request
	{
		public int pagina { get; set; }

		public string usuario { get; set; }

		public string visualiza { get; set; }

		public string perfil { get; set; }

		public string numeroAcceso { get; set; }

		public string paciente { get; set; }

		public string nombre { get; set; }

		public int rangoEtario { get; set; }

		public string fechaDesde { get; set; }

		public string fechaHasta { get; set; }

		public string descripcion { get; set; }

		public string periodo { get; set; }

		public int cantidad { get; set; }

		public int opfiltro { get; set; }

		public Generico[] institucion { get; set; }

		public Generico[] modalidad { get; set; }

		public Generico[] medico { get; set; }

		public Generico[] atencion { get; set; }

		public Generico[] estado { get; set; }
	
        public int pendiente { get; set; }
	}
}
