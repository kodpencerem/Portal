using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using VedasPortal.Models.ToplantiTakvimi.ToplantiNotu;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.ToplantiOdalari
{
    public class ToplantiNotlariVeKararlarModeli : ComponentBase
    {
        [Inject]
        protected IBaseRepository<ToplantiNotu> ToplantiNotu { get; set; }
        protected IEnumerable<ToplantiNotu> NotlarVeKararlar;

        protected override Task OnInitializedAsync()
        {
            TumNotVeKararlariGetir();
            return Task.CompletedTask;
        }

        protected IEnumerable<ToplantiNotu> TumNotVeKararlariGetir()
        {
            NotlarVeKararlar = ToplantiNotu.GetAll();
            return NotlarVeKararlar;
        }     
    }
}
