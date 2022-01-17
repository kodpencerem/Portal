using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VedasPortal.Data;
using VedasPortal.Models.YayinDurumlari;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Services.DuyuruHaber
{
    public class DuyuruHaberService
    {
        private readonly VedasDbContext _objDuyuru;

        public DuyuruHaberService(VedasDbContext objDuyuru)
        {
            _objDuyuru = objDuyuru;
        }

        public async Task<List<Yayin>> TumunuGetir()
        {
            return await _objDuyuru.Yayinlar.ToListAsync();
        }

        public async Task<bool> Ekle(Yayin duyuru)
        {
            await _objDuyuru.Yayinlar.AddAsync(duyuru);
            await _objDuyuru.SaveChangesAsync();
            return true;
        }
        public async Task<Yayin> DetayGetir(int id)
        {
            Yayin yayin = await _objDuyuru.Yayinlar.FirstOrDefaultAsync(c => c.Id.Equals(id));
            return yayin;
        }

        public async Task<bool> Duzenle(Yayin yayin)
        {
            _objDuyuru.Yayinlar.Update(yayin);
            await _objDuyuru.SaveChangesAsync();
            return true;
        }


        public void Sil(int id)
        {
            _objDuyuru.Remove(id);
        }
    }
}
