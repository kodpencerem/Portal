using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using VedasPortal.Data;
using VedasPortal.Data.Toplanti;
using VedasPortal.Entities.Models.ToplantiTakvimi;
using VedasPortal.Helpers;

namespace VedasPortal.Services.ToplantiServices
{
    public class ToplantiService
    {
        private readonly VedasDbContext _context;

        /// <summary>
        /// IHttpContextAccessor'dan oluşturulan bir örnek. 
        /// </summary>
        private readonly IHttpContextAccessor contextAccessor;

        public ToplantiService(VedasDbContext context, IHttpContextAccessor contextAccessor)
        {
            this._context = context;
            this.contextAccessor = contextAccessor;
        }
        public (bool, int) PostToplanti(Toplanti toplanti)
        {
            int max = -1;
            var ToplantiKodu = PasswordHelper.CreateRandomPassword();
            try
            {
                var email = contextAccessor.HttpContext.User.Identity.Name;
                var gonder = _context.ToplantiMail.Where(temail => temail.Email == email);

                max = gonder.DefaultIfEmpty().Max(toplanti => toplanti == null ? -1 : toplanti.PersonelId);
                MailGonder mailGonder = new();
                mailGonder.Konu = toplanti.Konu;
                mailGonder.Aciklama = toplanti.Aciklama;
                mailGonder.BaslangicTarihi = toplanti.BaslangicTarihi;
                mailGonder.BitisTarihi = toplanti.BitisTarihi;
                mailGonder.ToplantiMerkeziId = toplanti.ToplantiMerkeziId;
                mailGonder.ToplantiOdasiId = toplanti.ToplantiOdasiId;
                mailGonder.AktifPasif = toplanti.AktifPasif;
                mailGonder.AnaSayfadaGoster = toplanti.AnaSayfadaGoster;
                mailGonder.Baslik = toplanti.Baslik;
                mailGonder.BeklenenKatilimSayisi = toplanti.BeklenenKatilimSayisi;
                mailGonder.Id = toplanti.Id;
                mailGonder.DuzenlemeTarihi = toplanti.DuzenlemeTarihi;
                mailGonder.DuzenleyenKullanici = toplanti.DuzenleyenKullanici;
                mailGonder.KaydedenKullanici = toplanti.KaydedenKullanici;
                mailGonder.ToplantiTarihi = toplanti.BaslangicTarihi;
                mailGonder.KayitTarihi = toplanti.KayitTarihi;
                mailGonder.Kod = ToplantiKodu;
                mailGonder.ApplicationUser = toplanti.ApplicationUser;
                mailGonder.Renk = toplanti.Renk;
                mailGonder.ToplantiNotu = toplanti.ToplantiNotu;
                mailGonder.SilenKullanici = toplanti.SilenKullanici;
                mailGonder.SilmeTarihi = toplanti.SilmeTarihi;
                mailGonder.VideoKonferansMi = toplanti.VideoKonferansMi;
                mailGonder.PersonelId = toplanti.PersonelId;
                mailGonder.Email = email;

                _context.Add(mailGonder);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return (false, max);
            }

            return (true, max + 1);
        }

        public bool UpdateToplanti(Toplanti toplanti, int id)
        {
            try
            {
                var entity = _context.ToplantiMail.FirstOrDefault(item => item.Email == contextAccessor.HttpContext.User.Identity.Name && item.PersonelId == id);

                if (entity != null)
                {
                    entity.Konu = toplanti.Konu;
                    entity.Aciklama = toplanti.Aciklama;
                    entity.BaslangicTarihi = toplanti.BaslangicTarihi;
                    entity.BitisTarihi = toplanti.BitisTarihi;
                    entity.ToplantiMerkeziId = toplanti.ToplantiMerkeziId;
                    entity.ToplantiOdasiId = toplanti.ToplantiOdasiId;
                    entity.AktifPasif = toplanti.AktifPasif;
                    entity.AnaSayfadaGoster = toplanti.AnaSayfadaGoster;
                    entity.Baslik = toplanti.Baslik;
                    entity.BeklenenKatilimSayisi = toplanti.BeklenenKatilimSayisi;
                    entity.DuzenlemeTarihi = toplanti.DuzenlemeTarihi;
                    entity.DuzenleyenKullanici = toplanti.DuzenleyenKullanici;
                    entity.KaydedenKullanici = toplanti.KaydedenKullanici;
                    entity.ToplantiTarihi = toplanti.BaslangicTarihi;
                    entity.KayitTarihi = toplanti.KayitTarihi;
                    entity.Kod = toplanti.Kod;
                    entity.ApplicationUser = toplanti.ApplicationUser;
                    entity.Renk = toplanti.Renk;
                    entity.ToplantiNotu = toplanti.ToplantiNotu;
                    entity.SilenKullanici = toplanti.SilenKullanici;
                    entity.SilmeTarihi = toplanti.SilmeTarihi;
                    entity.VideoKonferansMi = toplanti.VideoKonferansMi;
                    
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool DeleteToplanti(int id)
        {
            try
            {
                var entity = _context.ToplantiMail.FirstOrDefault(item => item.Email == contextAccessor.HttpContext.User.Identity.Name && item.PersonelId == id);

                if (entity != null)
                {
                    _context.Remove(entity);

                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
