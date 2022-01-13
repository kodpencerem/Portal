using System.Collections.Generic;
using VedasPortal.Models.YayinDurumlari;

namespace VedasPortal.Repository.Interface
{
    public interface IDuyuru
    {
        public List<Yayin> TumDuyurulariGetir();
        public void DuyuruEkle(Yayin duyuru);
        public void DuyuruDuzenle(Yayin duyuru);
        public Yayin DuyuruGetir(int id);
        public void DuyuruSil(int id);
    }
}
