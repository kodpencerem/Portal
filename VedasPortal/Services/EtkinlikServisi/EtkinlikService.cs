using System.Collections.Generic;
using System.Threading.Tasks;
using VedasPortal.Data;
using VedasPortal.Models.Etkinlik;
using Microsoft.EntityFrameworkCore;

namespace VedasPortal.Services.EtkinlikServisi
{
    public class EtkinlikService
    {
        private readonly VedasDbContext _vedasDbContext;

        public EtkinlikService(VedasDbContext vedasDbContext)
        {
            _vedasDbContext = vedasDbContext;
        }

        public async Task<List<EtkinlikDurum>> TumEtkinlikleriGetir()
        {
            return await _vedasDbContext.EtkinlikDurumlari.ToListAsync();
        }

        public async Task<bool> EtkinlikEkle(EtkinlikDurum etkinlikDurum)
        {
            await _vedasDbContext.EtkinlikDurumlari.AddAsync(etkinlikDurum);
            await _vedasDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<EtkinlikDurum> EtkinlikGetir(int Id)
        {
            EtkinlikDurum etkinlikDurum = await _vedasDbContext.EtkinlikDurumlari.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return etkinlikDurum;
        }

        public async Task<bool> EtkinlikDuzenle(EtkinlikDurum etkinlikDurum)
        {
            _vedasDbContext.EtkinlikDurumlari.Update(etkinlikDurum);
            await _vedasDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EtkinlikSil(EtkinlikDurum etkinlikDurum)
        {
            _vedasDbContext.Remove(etkinlikDurum);
            await _vedasDbContext.SaveChangesAsync();
            return true;
        }
    }
}
