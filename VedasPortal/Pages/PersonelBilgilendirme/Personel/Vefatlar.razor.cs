using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using VedasPortal.Entities.Models.PersonelDurumlari;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.PersonelBilgilendirme.Personel
{
    public class Vefat : ComponentBase
    {
        [Inject]
        protected IBaseRepository<VefatDurumu> VefatDurumServisi { get; set; }
        protected IEnumerable<VefatDurumu> VefatDurum;

        protected override Task OnInitializedAsync()
        {
            TumVefatDurumlariniGetir();
            return Task.CompletedTask;
        }

        protected IEnumerable<VefatDurumu> TumVefatDurumlariniGetir()
        {
            VefatDurum = VefatDurumServisi.GetAll();
            return VefatDurum;
        }
    }
}
