using System;
using System.Collections.Generic;
using System.Globalization;

namespace VedasPortal.Entities.Models.ToplantiTakvimi
{
    public class AylikToplanti
    {
        readonly string ay;
        readonly int ilkGunlariAtla;
        public readonly int gunSayisi;
        readonly Calendar takvim;
        readonly GunlukToplanti[] toplantiliGun;

        public AylikToplanti(DateTime toplantiTarihi)
        {
            takvim = CultureInfo.InvariantCulture.Calendar;
            ay = toplantiTarihi.ToString("MMMM", CultureInfo.CreateSpecificCulture("tr-TR"));
            gunSayisi = takvim.GetDaysInMonth(toplantiTarihi.Year, toplantiTarihi.Month);

            ilkGunlariAtla = (int)new DateTime(takvim.GetYear(toplantiTarihi), takvim.GetMonth(toplantiTarihi), 1).DayOfWeek - 1;

            // Sunday
            if (ilkGunlariAtla < 0) ilkGunlariAtla = 6;

            toplantiliGun = new GunlukToplanti[gunSayisi];

            for (int i = 0; i < gunSayisi; i++)
            {
                int j = i;
                toplantiliGun[i] = new GunlukToplanti(new DateTime(takvim.GetYear(toplantiTarihi), takvim.GetMonth(toplantiTarihi), j + 1), new List<Toplanti>());
            }
        }

        public GunlukToplanti this[int i]
        {
            get { return toplantiliGun[i]; }
            set { toplantiliGun[i] = value; }
        }

        public string AdiniGetir => ay;

        public int GunAtla => ilkGunlariAtla;

        public double Satirlar { get { return Math.Ceiling((ilkGunlariAtla + gunSayisi) / 7.0); } }
    }
}
