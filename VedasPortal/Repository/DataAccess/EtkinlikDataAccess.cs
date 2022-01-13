using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using VedasPortal.Data;
using VedasPortal.Models.Etkinlik;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Repository.DataAccess
{
    public class EtkinlikDataAccess : IEtkinlik
    {

        private VedasDbContext _vPortalDbContext;

        public EtkinlikDataAccess(VedasDbContext vPortalDbContext)
        {
            _vPortalDbContext = vPortalDbContext;
        }

        public void EtkinlikDuzenle(EtkinlikDurum etkinlik)
        {
            try
            {
                _vPortalDbContext.Entry(etkinlik).State = EntityState.Modified;
                _vPortalDbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void EtkinlikEkle(EtkinlikDurum etkinlik)
        {
            try
            {
                _vPortalDbContext.EtkinlikDurumlari.Add(etkinlik);
                _vPortalDbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        public EtkinlikDurum EtkinlikGetir(int id)
        {
            try
            {
                var etkinlikGetir = _vPortalDbContext.EtkinlikDurumlari.Find(id);
                _vPortalDbContext.Entry(etkinlikGetir).State = EntityState.Detached;
                return etkinlikGetir;
            }
            catch
            {
                throw;
            }
        }

        public void EtkinlikSil(int id)
        {
            try
            {
                EtkinlikDurum etkinlik = _vPortalDbContext.EtkinlikDurumlari.Find(id);
                _vPortalDbContext.EtkinlikDurumlari.Remove(etkinlik);
                _vPortalDbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public List<EtkinlikDurum> TumEtkinlikleriGetir()
        {
            try
            {
                return _vPortalDbContext.EtkinlikDurumlari.AsNoTracking().ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
