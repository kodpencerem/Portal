using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Entities.Models.ToplantiTakvimi.ToplantiNotu;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.ToplantiOdalari
{
    public class ToplantiNotlariVeKararlarModeli : ComponentBase
    {
        [Inject]
        protected IBaseRepository<ToplantiNotu> ToplantiNotu { get; set; }
        protected IEnumerable<ToplantiNotu> NotlarVeKararlar { get; set; } = new List<ToplantiNotu>();

        public string SearchText = "";

        public List<ToplantiNotu> FilteredToplantiNotu => NotlarVeKararlar.Where(
            x => x.Baslik.ToLower().Contains(SearchText.ToLower())
            || x.AltBaslik.ToLower().Contains(SearchText.ToLower())
            || x.Aciklama.ToLower().Contains(SearchText.ToLower())
            ).ToList();

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
