namespace VedasPortal.Entities.Models.DovizKurlari
{
    public class DovizKurlari
    {
        public string DovizAdi { get; }
        public string DovizKodu { get; }
        public string CaprazKurAdi { get; }
        public double DovizAlis { get; }
        public double DovizSatis { get; }
        public double EfektifAlis { get; }
        public double EfektifSatis { get; }

        public DovizKurlari(string dovizAdi, string dovizKodu, string caprazKurAdi, double dovizAlis, double dovizSatis, double efektifAlis, double efektifSatis)
        {
            DovizAdi = dovizAdi;
            DovizKodu = dovizKodu;
            CaprazKurAdi = caprazKurAdi;
            DovizAlis = dovizAlis;
            DovizSatis = dovizSatis;
            EfektifAlis = efektifAlis;
            EfektifSatis = efektifSatis;

        }
    }
}