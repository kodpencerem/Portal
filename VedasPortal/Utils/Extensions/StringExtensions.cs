using VedasPortal.Models.Etkinlik;
using VedasPortal.Models.HaberDuyuru;

namespace VedasPortal
{
    public static class StringExtensions
    {
        public static string TextHaberDuyuru(this HaberDuyuruKategori kategori)
        {
            switch (kategori)
            {
                case HaberDuyuruKategori.Duyuru:
                    return "Duyuru";
                case HaberDuyuruKategori.Haber:
                    return "Haber";
                default:
                    return "";
            }
        }

        public static string TextEtkinlik(this EtkinlikKategori kategori)
        {
            switch (kategori)
            {
                case EtkinlikKategori.CevreTemizligi:
                    return "Çevre Temizliği";
                case EtkinlikKategori.DogaYuruyusu:
                    return "Doğa Yürüyüşü";

                case EtkinlikKategori.FidanDikimi:
                    return "Fidan Dikimi";

                case EtkinlikKategori.Tanisma:
                    return "Tanışma";

                case EtkinlikKategori.Seminer:
                    return "Seminer";

                case EtkinlikKategori.Konferans:
                    return "Konferans";

                case EtkinlikKategori.Konser:
                    return "Konser";

                case EtkinlikKategori.Tiyatro:
                    return "Tiyatro";

                default:
                    return "";
            }
        }

        public static string TextKatilimci(this KatilimciKategori kategori)
        {
            switch (kategori)
            {
                case KatilimciKategori.TumPersonel:
                    return "Tüm Personel";
                case KatilimciKategori.Scada:
                    return "Scada";

                case KatilimciKategori.BilgiIslem:
                    return "Bilgi İşlem Müdürlüğü";

                case KatilimciKategori.CagriMerkezi:
                    return "Çağrı Merkezi";


                case KatilimciKategori.Hukuk:
                    return "Hukuk Servisi Personeli";

                case KatilimciKategori.InsanKaynaklariPersoneli:
                    return "İnsan Kaynakları Personeli";

                case KatilimciKategori.KaliteMudurlugu:
                    return "Kalite Müdürlüğü";

                case KatilimciKategori.Davetli:
                    return "Davetli veya Misafir";

                default:
                    return "";
            }
        }
    }
}
