using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using VedasPortal.Data;
using VedasPortal.Data.Toplanti;
using VedasPortal.Entities.Models.ToplantiTakvimi;

namespace VedasPortal.Services.ToplantiServices
{
    public class AylikToplantiService
    {
        private readonly VedasDbContext context;
        private readonly IHttpContextAccessor contextAccessor;

        public AylikToplantiService(VedasDbContext context, IHttpContextAccessor contextAccessor)
        {
            this.context = context;
            this.contextAccessor = contextAccessor;
        }

        public (AylikToplanti, int) GetMonth(DateTime toplantiTarihi)
        {
            string userEmail = contextAccessor.HttpContext.User.Identity.Name;

            IEnumerable<MailGonder> mailler = context.ToplantiMail.Where(toplanti => toplanti.Email == userEmail
            && toplanti.BitisTarihi.Year == toplantiTarihi.Year && toplanti.BaslangicTarihi.Month == toplantiTarihi.Month);

            AylikToplanti aylik = new(toplantiTarihi);

            int maxID = context.ToplantiMail
                .Where(toplanti => toplanti.Email == userEmail)
                .Select(toplanti => toplanti.PersonelId)
                .DefaultIfEmpty()
                .Max();

            foreach (var item in mailler)
            {
                aylik[item.BaslangicTarihi.Day - 1].AddToplanti(item);

            }

            return (aylik, maxID);
        }
    }
}
