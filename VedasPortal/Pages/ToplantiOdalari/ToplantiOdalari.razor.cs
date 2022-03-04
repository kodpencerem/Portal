using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using VedasPortal.Models.ToplantiTakvimi;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.ToplantiOdalari
{
    public class ToplantiOdalariModeli : ComponentBase
    {
        [Inject]
        protected IBaseRepository<ToplantiOdasi> ToplantiOdasi { get; set; }
        protected IEnumerable<ToplantiOdasi> Odalar;

        protected override Task OnInitializedAsync()
        {
            TumOdalariGetir();
            return Task.CompletedTask;
        }

        protected IEnumerable<ToplantiOdasi> TumOdalariGetir()
        {
            Odalar = ToplantiOdasi.GetAll();
            return Odalar;
        }     
    }
}
