using System;

namespace VedasPortal.Models.OpenWeatherMapApi
{
	public class HavaTahmini
	{
		public DateTime Tarih { get; set; }

		public string Sehir { get; set; }

		public int DereceC { get; set; }

		public int DereceF => 32 + (int)(DereceC / 0.5556);

		public string Ozet { get; set; }

		public int BulutOrani { get; set; }

		public int NemOrani { get; set; }

		public int RuzgarHizi { get; set; }

		public int BasincDegeri { get; set; }
	}
}
