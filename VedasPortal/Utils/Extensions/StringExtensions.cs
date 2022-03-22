using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Entities.Models.DuzelticiFaaliyet;
using VedasPortal.Entities.Models.Egitim;
using VedasPortal.Entities.Models.Etkinlik;
using VedasPortal.Entities.Models.HaberDuyuru;
using VedasPortal.Entities.Models.IKUygulama;
using VedasPortal.Entities.Models.Mevzuat;
using VedasPortal.Entities.Models.Oneri;
using VedasPortal.Entities.Models.Video;

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

        public static string TextEgitimDurumu(this EgitimDurumu kategori)
        {
            switch (kategori)
            {
                case EgitimDurumu.IlkOkul:
                    return "İlk Okul";
                case EgitimDurumu.OrtaOkul:
                    return "Orta Okul";
                case EgitimDurumu.Lise:
                    return "Lise";
                case EgitimDurumu.OnLisans:
                    return "Ön Lisans";
                case EgitimDurumu.Lisans:
                    return "Lisans";
                case EgitimDurumu.YuksekLisans:
                    return "Yüksek Lisans";
                case EgitimDurumu.Doktora:
                    return "Doktora";
                case EgitimDurumu.Master:
                    return "Master";

                default:
                    return "";
            }
        }

        public static string TextOneriKategori(this OneriKategori kategori)
        {
            switch (kategori)
            {
                case OneriKategori.Bilgilendirme:
                    return "Bilgilendirme ve Klavuzlar";
                case OneriKategori.CalisanHaklari:
                    return "Çalışan Hakları";
                case OneriKategori.CalismaKosullari:
                    return "Çalışma Koşulları";
                case OneriKategori.CevreAydinlatma:
                    return "Çevre Aydınlatma";
                case OneriKategori.Diger:
                    return "Diğer";
                case OneriKategori.ElektrikUretim:
                    return "Elektrik Üretim";
                case OneriKategori.Gelirler:
                    return "Gelir Kalemleri";
                case OneriKategori.Giderler:
                    return "Gider Kalemleri";
                case OneriKategori.HizmetKalitesi:
                    return "Hizmet Kalitesi";
                case OneriKategori.IsGuvenligi:
                    return "İş Güvenliği";
                case OneriKategori.IsVerenHaklari:
                    return "İş Veren Hakları";
                case OneriKategori.KopruVeKavsakAydinlatma:
                    return "Köprü ve Kavşak Aydınlatma";
                case OneriKategori.Maliyet:
                    return "Maliyet";
                case OneriKategori.Motivasyon:
                    return "İşçi Motivasyonu Artırma";
                case OneriKategori.Proje:
                    return "Proje ve Ürün";
                case OneriKategori.ProsedurVePolitikalar:
                    return "Prosedür ve Politikalar";
                case OneriKategori.Rekabet:
                    return "Rekabeti Artırma";
                case OneriKategori.TesisVeyaKurum:
                    return "Tesis veya Kurum";
                default:
                    return "";
            }
        }

        public static string TextOnemDerecesi(this OnemDerecesi kategori)
        {
            switch (kategori)
            {
                case OnemDerecesi.Dusuk:
                    return "Düşük";
                case OnemDerecesi.Orta:
                    return "Orta";
                case OnemDerecesi.Yuksek:
                    return "Yüksek";
                default:
                    return "";
            }
        }
        public static string TextOdul(this Odul kategori)
        {
            switch (kategori)
            {
                case Odul.IndirimKuponu:
                    return "İndirim Kuponu";
                case Odul.Izin:
                    return "İzin";
                case Odul.Para:
                    return "Para";
                default:
                    return "";
            }
        }

        public static string TextVideo(this VideoKategori kategori)
        {
            switch (kategori)
            {
                case VideoKategori.Belgesel:
                    return "Belgesel";
                case VideoKategori.Egitim:
                    return "Eğitim";

                case VideoKategori.Genel:
                    return "Genel";
                case VideoKategori.Roportaj:
                    return "Röportaj";

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

        public static string TextIkUygulama(this IkUygulamaKategori kategori)
        {
            switch (kategori)
            {
                case IkUygulamaKategori.Bordro:
                    return "Bordro Görüntüleme";
                case IkUygulamaKategori.EgitimYonetimi:
                    return "Eğitim Yönetimi ve Planlama";
                case IkUygulamaKategori.IseAlmaCikarma:
                    return "İşe Alma ve İşten Çıkarma";
                case IkUygulamaKategori.IzinGoruntulemVeBasvuru:
                    return "İzin Görüntüleme ve Başvuru";
                case IkUygulamaKategori.PerformansDegerlendirme:
                    return "Kariyer Planlama ve Performans Değerlendirme";
                default:
                    return "";
            }
        }
    }
}
