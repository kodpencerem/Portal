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
    public class DogumGunuModeli : ComponentBase
    {
        [Inject]
        protected IBaseRepository<PersonelDurum> DogumGunuServisi { get; set; }
        protected IEnumerable<PersonelDurum> DogumGunleri;

        public ImageFile PersonelDosya { get; set; } = new ImageFile();

        protected override Task OnInitializedAsync()
        {
            TumDoganlariGetir();
            return Task.CompletedTask;
        }

        protected IEnumerable<PersonelDurum> TumDoganlariGetir()
        {
            DogumGunleri = DogumGunuServisi.GetAll().AsQueryable().Include(s => s.Dosya).ToList();
            return DogumGunleri;
        }
    }
}
