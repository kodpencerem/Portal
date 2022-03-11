using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Entities.Models.Mevzuat;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.FaydaliIcerikler.GuncelMevzuatlar
{
    public class MevzuatModeli : ComponentBase
    {
        [Inject]
        protected IBaseRepository<Mevzuat> MevzuatServisi { get; set; }
        protected IEnumerable<Mevzuat> mevzuatlar;



        protected string SearchString { get; set; }
        protected override Task OnInitializedAsync()
        {
            TumMevzuatlariGetir();
            return Task.CompletedTask;
        }

        protected IEnumerable<Mevzuat> TumMevzuatlariGetir()
        {
            mevzuatlar = MevzuatServisi.GetAll().AsQueryable().Include(s => s.Dosya).ToList();

            return mevzuatlar;

        }
    }
}
