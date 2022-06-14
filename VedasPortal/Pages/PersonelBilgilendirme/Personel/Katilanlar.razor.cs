using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Entities.Models.PersonelDurumlari;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.PersonelBilgilendirme.Personel
{
    public class KatilisModel : ComponentBase
    {
        [Inject]
        protected IBaseRepository<PersonelDurum> PersonelServisi { get; set; }
        protected IEnumerable<PersonelDurum> KatilanPersonel;

        public ImageFile PersonelDosya { get; set; } = new ImageFile();

        protected override Task OnInitializedAsync()
        {
            TumKatilanlariGetir();
            return Task.CompletedTask;
        }

        protected IEnumerable<PersonelDurum> TumKatilanlariGetir()
        {
            KatilanPersonel = PersonelServisi.GetAll().AsQueryable().Include(s => s.Dosya).ToList();
            return KatilanPersonel;
        }
    }
}
