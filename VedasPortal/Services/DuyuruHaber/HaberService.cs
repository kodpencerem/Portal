using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VedasPortal.Data;
using VedasPortal.Models.YayinDurumlari;

namespace VedasPortal.Services.DuyuruHaber
{
    public class HaberService
    {
        #region Property
        private readonly VedasDbContext _vedasDbContext;
        #endregion

        #region Constructor
        public HaberService(VedasDbContext vedasDbContext)
        {
            _vedasDbContext = vedasDbContext;
        }
        #endregion

        #region Haber Listesini Getir
        public async Task<List<Yayin>> TumHaberleriGetir()
        {
            return await _vedasDbContext.Yayinlar.ToListAsync();
        }
        #endregion

        #region Haber Ekle
        public async Task<bool> HaberEkle(Yayin haber)
        {
            await _vedasDbContext.Yayinlar.AddAsync(haber);
            await _vedasDbContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Haber Getir(Id İle)
        public async Task<Yayin> HaberGetir(int Id)
        {
            Yayin employee = await _vedasDbContext.Yayinlar.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return employee;
        }
        #endregion

        #region Haber Güncelle
        public async Task<bool> HaberGuncelle(Yayin haber)
        {
            _vedasDbContext.Yayinlar.Update(haber);
            await _vedasDbContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Haber Sil
        public async Task<bool> HaberSil(Yayin haber)
        {
            _vedasDbContext.Remove(haber);
            await _vedasDbContext.SaveChangesAsync();
            return true;
        }
        #endregion
    }
}