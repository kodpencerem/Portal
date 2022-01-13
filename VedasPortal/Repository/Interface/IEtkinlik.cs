using System.Collections.Generic;
using VedasPortal.Models.Etkinlik;
using VedasPortal.Models.YayinDurumlari;

namespace VedasPortal.Repository.Interface
{
    public interface IEtkinlik
    {
        public List<EtkinlikDurum> TumEtkinlikleriGetir();
        public void EtkinlikEkle(EtkinlikDurum etkinlikDurum);
        public void EtkinlikDuzenle(EtkinlikDurum etkinlikDurum);
        public EtkinlikDurum EtkinlikGetir(int id);
        public void EtkinlikSil(int id);
    }
}
