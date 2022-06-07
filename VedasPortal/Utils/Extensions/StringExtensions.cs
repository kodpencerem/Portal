using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Entities.Models.DuzelticiFaaliyet;
using VedasPortal.Entities.Models.Egitim;
using VedasPortal.Entities.Models.Etkinlik;
using VedasPortal.Entities.Models.HaberDuyuru;
using VedasPortal.Entities.Models.IKUygulama;
using VedasPortal.Entities.Models.Mevzuat;
using VedasPortal.Entities.Models.Oneri;
using VedasPortal.Enums;

namespace VedasPortal
{
    public static class StringExtensions
    {
        public static string TextEgitim(this EgitimKategori kategori)
        {
            return kategori switch
            {
                EgitimKategori.Elektrik => "Elektrik",
                EgitimKategori.ElektrikElektronik => "Elektrik ve Elektronik",
                EgitimKategori.FotografVeVideo => "Fotoğraf-Video Çekim Ve Tasarım",
                EgitimKategori.Isletme => "İşletme Eğitimi",
                EgitimKategori.KisiselGelisim => "Kişisel Gelişim Ve Stres Eğitimi",
                EgitimKategori.Muhasebe => "Muhasebe Eğitimi",
                EgitimKategori.OfisUygulamalari => "Ofis Uygulamalarının Kullanımı",
                EgitimKategori.Pazarlama => "Satış Ve Pazarlama",
                EgitimKategori.SaglikVeFitnes => "Sağlıklı Yaşam ve Fitness",
                EgitimKategori.Tasarim => "Tasarım Yapma ve Geliştirme",
                EgitimKategori.YasamTarzi => "Yaşam Tarzı",
                EgitimKategori.Yazilim => "Yazılım Geliştirme Teknolojileri",
                _ => "",
            };
        }

        public static string TextHaberDuyuru(this HaberDuyuruKategori kategori)
        {
            return kategori switch
            {
                HaberDuyuruKategori.Duyuru => "Duyuru",
                HaberDuyuruKategori.Haber => "Haber",
                _ => "",
            };
        }

        public static string TextPersonelDurumu(this PersonelDurumu kategori)
        {
            return kategori switch
            {
                PersonelDurumu.Yeni => "Yeni Personel",
                PersonelDurumu.Ayrilis => "Ayrılacak Personel",
                PersonelDurumu.Vefat => "Vefat Durumu",
                _ => "",
            };
        }

        public static string TextEgitimDurumu(this EgitimDurumu kategori)
        {
            return kategori switch
            {
                EgitimDurumu.IlkOkul => "İlk Okul",
                EgitimDurumu.OrtaOkul => "Orta Okul",
                EgitimDurumu.Lise => "Lise",
                EgitimDurumu.OnLisans => "Ön Lisans",
                EgitimDurumu.Lisans => "Lisans",
                EgitimDurumu.YuksekLisans => "Yüksek Lisans",
                EgitimDurumu.Doktora => "Doktora",
                EgitimDurumu.Master => "Master",
                _ => "",
            };
        }

        public static string TextOneriKategori(this OneriKategori kategori)
        {
            return kategori switch
            {
                OneriKategori.Bilgilendirme => "Bilgilendirme ve Klavuzlar",
                OneriKategori.CalisanHaklari => "Çalışan Hakları",
                OneriKategori.CalismaKosullari => "Çalışma Koşulları",
                OneriKategori.CevreAydinlatma => "Çevre Aydınlatma",
                OneriKategori.Diger => "Diğer",
                OneriKategori.ElektrikUretim => "Elektrik Üretim",
                OneriKategori.Gelirler => "Gelir Kalemleri",
                OneriKategori.Giderler => "Gider Kalemleri",
                OneriKategori.HizmetKalitesi => "Hizmet Kalitesi",
                OneriKategori.IsGuvenligi => "İş Güvenliği",
                OneriKategori.IsVerenHaklari => "İş Veren Hakları",
                OneriKategori.KopruVeKavsakAydinlatma => "Köprü ve Kavşak Aydınlatma",
                OneriKategori.Maliyet => "Maliyet",
                OneriKategori.Motivasyon => "İşçi Motivasyonu Artırma",
                OneriKategori.Proje => "Proje ve Ürün",
                OneriKategori.ProsedurVePolitikalar => "Prosedür ve Politikalar",
                OneriKategori.Rekabet => "Rekabeti Artırma",
                OneriKategori.TesisVeyaKurum => "Tesis veya Kurum",
                _ => "",
            };
        }

        public static string TextOnemDerecesi(this OnemDerecesi kategori)
        {
            return kategori switch
            {
                OnemDerecesi.Dusuk => "Düşük",
                OnemDerecesi.Orta => "Orta",
                OnemDerecesi.Yuksek => "Yüksek",
                _ => "",
            };
        }
        public static string TextOdul(this Odul kategori)
        {
            return kategori switch
            {
                Odul.IndirimKuponu => "İndirim Kuponu",
                Odul.Izin => "İzin",
                Odul.Para => "Para",
                _ => "",
            };
        }

        public static string TextVideo(this VideoKategori kategori)
        {
            return kategori switch
            {
                VideoKategori.Belgesel => "Belgesel",
                VideoKategori.Egitim => "Eğitim",
                VideoKategori.Genel => "Genel",
                VideoKategori.Roportaj => "Röportaj",
                _ => "",
            };
        }

        public static string TextMevzuat(this MevzuatKategori kategori)
        {
            return kategori switch
            {
                MevzuatKategori.CumhurBaskanligiKararname => "Cumurbaşkanlığı Kararnamesi",
                MevzuatKategori.Genelge => "Genelge",
                MevzuatKategori.Kanun => "Kanun",
                MevzuatKategori.KanunHukmundeKararname => "Kanun Hükmünde Kararname",
                MevzuatKategori.Kararname => "Kararname",
                MevzuatKategori.Teblig => "Tebliğ",
                MevzuatKategori.Tuzuk => "Tüzük",
                MevzuatKategori.Yonetmelik => "Yönetmelik",
                _ => "",
            };
        }

        public static string TextBirimler(this Birimler kategori)
        {
            return kategori switch
            {
                Birimler.TumBirimler => "Tüm Birimler",
                Birimler.BilgiIslem => "Bilgi İşlem Müdürlüğü",
                Birimler.CagriMerkezi => "Çağrı Merkezi Müdürlüğü",
                Birimler.Hukuk => "Hukuk İşleri Müdürlüğü",
                Birimler.Icra => "İcra Müdürlüğü",
                Birimler.InsanKaynaklari => "İnsan Kaynakları",
                Birimler.KacakVeTahakkuk => "Kaçakla Mücadele ve Tahakkuk",
                Birimler.KaliteMudurlugu => "Kalite Ve Eğitim Planlama Müdürlüğü",
                Birimler.KurumsalIletisim => "Kurumsal İletişim Müdürlüğü",
                Birimler.Sayac => "Sayaç Okumaları Müdürlüğü",
                Birimler.Scada => "Elektrik ve Arıza Takip Sistemleri Müdürlüğü",
                _ => "",
            };
        }

        public static string TextDosya(this DosyaKategori kategori)
        {
            return kategori switch
            {
                DosyaKategori.Docx => "Word Dökümanı",
                DosyaKategori.Mkv => "Matroska Video",
                DosyaKategori.Mp4 => "MPEG-4 Video",
                DosyaKategori.Pdf => "Pdf Dökümanı",
                DosyaKategori.Pptx => "PowerPoint Sunu",
                DosyaKategori.Pub => "Microsoft Publiser",
                DosyaKategori.Rar => "Arşiv Dosya",
                DosyaKategori.Xlsx => "Excel Döküman",
                DosyaKategori.Zip => "Sıkıştırılmış Dosya",
                DosyaKategori.Jpg => "Jpg Resmi",
                DosyaKategori.Bitmap =>"Bitmap Resmi",
                DosyaKategori.Gif =>  "Hareketli Resim",
                DosyaKategori.Jpeg => "Jpeg Resmi",
                _ => "",
            };
        }

        public static string TextDuzelticiFaaliyet(this DuzelticiFaaliyetKategori kategori)
        {
            return kategori switch
            {
                DuzelticiFaaliyetKategori.CevreAydinlatma => "Çevre Aydınlatma",
                DuzelticiFaaliyetKategori.KopruKavsakAydinlatma => "Köprü ve Kavşak Işıkları",
                DuzelticiFaaliyetKategori.ProsedurVePolitikalar => "Prosedür ve Politikalar",
                _ => "",
            };
        }

        public static string TextEtkinlik(this EtkinlikKategori kategori)
        {
            return kategori switch
            {
                EtkinlikKategori.CevreTemizligi => "Çevre Temizliği",
                EtkinlikKategori.Etkinlik => "Etkinlik",
                EtkinlikKategori.DogaYuruyusu => "Doğa Yürüyüşü",
                EtkinlikKategori.FidanDikimi => "Fidan Dikimi",
                EtkinlikKategori.Tanisma => "Tanışma",
                EtkinlikKategori.Seminer => "Seminer",
                EtkinlikKategori.Konferans => "Konferans",
                EtkinlikKategori.Konser => "Konser",
                EtkinlikKategori.Tiyatro => "Tiyatro",
                _ => "",
            };
        }

        public static string TextKatilimci(this KatilimciKategori kategori)
        {
            return kategori switch
            {
                KatilimciKategori.TumPersonel => "Tüm Personel",
                KatilimciKategori.SadeceErkekPersonel => "Erkek Personel",
                KatilimciKategori.SadeceKadinPersonel => "Kadın Personel",
                KatilimciKategori.Scada => "Scada",
                KatilimciKategori.BilgiIslem => "Bilgi İşlem Müdürlüğü",
                KatilimciKategori.CagriMerkezi => "Çağrı Merkezi",
                KatilimciKategori.Hukuk => "Hukuk Servisi Personeli",
                KatilimciKategori.InsanKaynaklariPersoneli => "İnsan Kaynakları Personeli",
                KatilimciKategori.KaliteMudurlugu => "Kalite Müdürlüğü",
                KatilimciKategori.Davetli => "Davetli veya Misafir",
                _ => "",
            };
        }

        public static string TextIkUygulama(this IkUygulamaKategori kategori)
        {
            return kategori switch
            {
                IkUygulamaKategori.Bordro => "Bordro Görüntüleme",
                IkUygulamaKategori.EgitimYonetimi => "Eğitim Yönetimi ve Planlama",
                IkUygulamaKategori.IseAlmaCikarma => "İşe Alma ve İşten Çıkarma",
                IkUygulamaKategori.IzinGoruntulemVeBasvuru => "İzin Görüntüleme ve Başvuru",
                IkUygulamaKategori.PerformansDegerlendirme => "Kariyer Planlama ve Performans Değerlendirme",
                _ => "",
            };
        }
    }
}