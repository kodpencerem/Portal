using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Entities.Models.IKUygulama;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.InsanKaynaklariUygulamalari
{
    public class IKUygulamalariModeli : ComponentBase
    {
        [Inject]
        protected IBaseRepository<IkUygulama> IkUygulamaServisi { get; set; }
        protected IEnumerable<IkUygulama> IkUygulamalari;

        protected override Task OnInitializedAsync()
        {
            TumIkUygulamalariniGetir();
            return Task.CompletedTask;
        }

        protected IEnumerable<IkUygulama> TumIkUygulamalariniGetir()
        {
            IkUygulamalari = IkUygulamaServisi.GetAll().AsQueryable().Include(s => s.Dosya).ToList();

            return IkUygulamalari;

        }

    }
}
