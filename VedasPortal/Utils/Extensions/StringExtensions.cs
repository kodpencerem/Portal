using VedasPortal.Models.Dosya;
using VedasPortal.Models.DuzelticiFaaliyet;
using VedasPortal.Models.Etkinlik;
using VedasPortal.Models.HaberDuyuru;
using VedasPortal.Models.Mevzuat;
using VedasPortal.Models.Video;

namespace VedasPortal
{
    public static class StringExtensions
    {
        public static string TextEgitim(this EgitimKategori kategori)
        {
            switch (kategori)
            {

                case EgitimKategori.Elektrik:
                    return "Elektrik";
                case EgitimKategori.ElektrikElektronik:
                    return "Elektrik ve Elektronik";
                case EgitimKategori.FotografVeVideo:
                    return "Fotoğraf-Video Çekim Ve Tasarım";

                case EgitimKategori.Isletme:
                    return "İşletme Eğitimi";
                case EgitimKategori.KisiselGelisim:
                    return "Kişisel Gelişim Ve Stres Eğitimi";

                case EgitimKategori.Muhasebe:
                    return "Muhasebe Eğitimi";

                case EgitimKategori.OfisUygulamalari:
                    return "Ofis Uygulamalarının Kullanımı";

                case EgitimKategori.Pazarlama:
                    return "Satış Ve Pazarlama";

                case EgitimKategori.SaglikVeFitnes:
                    return "Sağlıklı Yaşam ve Fitness";

                case EgitimKategori.Tasarim:
                    return "Tasarım Yapma ve Geliştirme";
                case EgitimKategori.YasamTarzi:
                    return "Yaşam Tarzı";

                case EgitimKategori.Yazilim:
                    return "Yazılım Geliştirme Teknolojileri";

                default:
                    return "";
            }
        }


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

        public static string TextMevzuat(this MevzuatKategori kategori)
        {
            switch (kategori)
            {
                case MevzuatKategori.CumhurBaskanligiKararname:
                    return "Cumurbaşkanlığı Kararnamesi";
                case MevzuatKategori.Genelge:
                    return "Genelge";
                case MevzuatKategori.Kanun:
                    return "Kanun";
                case MevzuatKategori.KanunHukmundeKararname:
                    return "Kanun Hükmünde Kararname";
                case MevzuatKategori.Kararname:
                    return "Kararname";
                case MevzuatKategori.Teblig:
                    return "Tebliğ";
                case MevzuatKategori.Tuzuk:
                    return "Tüzük";
                case MevzuatKategori.Yonetmelik:
                    return "Yönetmelik";
                default:
                    return "";
            }
        }

        public static string TextBirimler(this Birimler kategori)
        {
            switch (kategori)
            {
                case Birimler.TumBirimler:
                    return "Tüm Birimler";

                case Birimler.BilgiIslem:
                    return "Bilgi İşlem Müdürlüğü";
                case Birimler.CagriMerkezi:
                    return "Çağrı Merkezi Müdürlüğü";
                case Birimler.Hukuk:
                    return "Hukuk İşleri Müdürlüğü";
                case Birimler.Icra:
                    return "İcra Müdürlüğü";
                case Birimler.InsanKaynaklari:
                    return "İnsan Kaynakları";

                case Birimler.KacakVeTahakkuk:
                    return "Kaçakla Mücadele ve Tahakkuk";

                case Birimler.KaliteMudurlugu:
                    return "Kalite Ve Eğitim Planlama Müdürlüğü";

                case Birimler.KurumsalIletisim:
                    return "Kurumsal İletişim Müdürlüğü";
                case Birimler.Sayac:
                    return "Sayaç Okumaları Müdürlüğü";

                case Birimler.Scada:
                    return "Elektrik ve Arıza Takip Sistemleri Müdürlüğü";

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
