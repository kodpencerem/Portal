using VedasPortal.Models.Dosya;
using VedasPortal.Models.DuzelticiFaaliyet;
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

        public static string TextDosya(this DosyaKategori kategori)
        {
            switch (kategori)
            {
                case DosyaKategori.Docx:
                    return "Word Dökümanı";
                case DosyaKategori.Mkv:
                    return "Matroska Video";

                case DosyaKategori.Mp4:
                    return "MPEG-4 Video";


                case DosyaKategori.Pdf:
                    return "Pdf Dökümanı";

                case DosyaKategori.Pptx:
                    return "PowerPoint Sunu";


                case DosyaKategori.Pub:
                    return "Microsoft Publiser";

                case DosyaKategori.Rar:
                    return "Arşiv Dosya";

                case DosyaKategori.Xlsx:
                    return "Excel Döküman";

                case DosyaKategori.Zip:
                    return "Sıkıştırılmış Dosya";

                default:
                    return "";
            }
        }

        public static string TextDuzelticiFaaliyet(this DuzelticiFaaliyetKategori kategori)
        {
            switch (kategori)
            {
                case DuzelticiFaaliyetKategori.CevreAydinlatma:
                    return "Çevre Aydınlatma";
                case DuzelticiFaaliyetKategori.KopruKavsakAydinlatma:
                    return "Köprü ve Kavşak Işıkları";

                case DuzelticiFaaliyetKategori.ProsedurVePolitikalar:
                    return "Prosedür ve Politikalar";

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
