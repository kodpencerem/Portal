using System.Collections.Generic;
using System.Threading.Tasks;
using VedasPortal.Models.YayinDurumlari;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Services.DuyuruHaber
{
    public class DuyuruHaberService
    {
        private readonly IDuyuru _objDuyuru;

        public DuyuruHaberService(IDuyuru objDuyuru)
        {
            _objDuyuru = objDuyuru;
        }

        public Task<List<Yayin>> TumunuGetir()
        {
            return Task.FromResult(_objDuyuru.TumDuyurulariGetir());
        }

        public void Ekle(Yayin duyuru)
        {
            _objDuyuru.DuyuruEkle(duyuru);
        }
        public Task<Yayin> DetayGetir(int id)
        {
            return Task.FromResult(_objDuyuru.DuyuruGetir(id));
        }

        public void Duzenle(Yayin duyuru)
        {
            _objDuyuru.DuyuruDuzenle(duyuru);
        }

        public void Sil(int id)
        {
            _objDuyuru.DuyuruSil(id);
        }
    }
}
