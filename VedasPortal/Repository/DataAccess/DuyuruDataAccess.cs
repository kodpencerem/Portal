using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using VedasPortal.Data;
using VedasPortal.Models.YayinDurumlari;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Repository.DataAccess
{
    public class DuyuruDataAccess : IDuyuru
    {

        private VedasDbContext _vPortalDbContext;

        public DuyuruDataAccess(VedasDbContext vPortalDbContext)
        {
            _vPortalDbContext = vPortalDbContext;
        }

        public void DuyuruDuzenle(Yayin duyuru)
        {
            try
            {
                _vPortalDbContext.Entry(duyuru).State = EntityState.Modified;
                _vPortalDbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void DuyuruEkle(Yayin duyuru)
        {
            try
            {
                _vPortalDbContext.Yayinlar.Add(duyuru);
                _vPortalDbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        public Yayin DuyuruGetir(int id)
        {
            try
            {
                var duyuruGetir = _vPortalDbContext.Yayinlar.Find(id);
                _vPortalDbContext.Entry(duyuruGetir).State = EntityState.Detached;
                return duyuruGetir;
            }
            catch
            {
                throw;
            }
        }

        public void DuyuruSil(int id)
        {
            try
            {
                Yayin duyuru = _vPortalDbContext.Yayinlar.Find(id);
                _vPortalDbContext.Yayinlar.Remove(duyuru);
                _vPortalDbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public List<Yayin> TumDuyurulariGetir()
        {
            try
            {
                return _vPortalDbContext.Yayinlar.AsNoTracking().ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
