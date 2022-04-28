using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using VedasPortal.Entities.Models.Egitim;
using VedasPortal.Entities.Models.PersonelDurumlari;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.FaydaliIcerikler.Egitimler
{
    public partial class EgitimDetay
    {
        [Inject]
        private IBaseRepository<Egitim> EgitimServisi { get; set; }

        [Inject]
        private IBaseRepository<PersonelDurum> PersonelServisi { get; set; }

        [Inject]
        private IBaseRepository<UzmanlikAlani> Uzmanliklar { get; set; }

        [Parameter]
        public int EgitimId { get; set; }

        [Parameter]
        public int PersonelId { get; set; }

        protected Egitim EgitimDetayGetir { get; set; }

        protected PersonelDurum PersonelDurum { get; set; }

        protected IEnumerable<UzmanlikAlani> UzmanlikAlani { get; set; }

        protected override Task OnInitializedAsync()
        {
            EgitimDetayGetir = EgitimServisi.Get(EgitimId);
            PersonelDurum = PersonelServisi.Get(PersonelId);
            UzmanlikAlani = Uzmanliklar.GetAll();
            return Task.CompletedTask;
        }
    }
}
