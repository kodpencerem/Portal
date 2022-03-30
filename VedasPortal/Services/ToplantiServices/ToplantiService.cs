using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using VedasPortal.Data;
using VedasPortal.Data.Toplanti;
using VedasPortal.Entities.Models.ToplantiTakvimi;

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
            try
            {
                var email = contextAccessor.HttpContext.User.Identity.Name;
                var gonder = _context.ToplantiMail.Where(temail => temail.Email == email);

                max = gonder.DefaultIfEmpty().Max(toplanti => toplanti == null ? -1 : toplanti.PersonelId);
                MailGonder mailGonder = new();
                mailGonder.Konu = toplanti.Konu;
                mailGonder.BaslangicTarihi = toplanti.BaslangicTarihi;
                mailGonder.BitisTarihi = toplanti.BitisTarihi;
                mailGonder.PersonelId = max + 1;
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
                    entity.BaslangicTarihi = toplanti.BaslangicTarihi;
                    entity.BitisTarihi = toplanti.BitisTarihi;
                    entity.Konu = toplanti.Konu;
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
