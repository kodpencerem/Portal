using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Entities.Models.HaberDuyuru;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.BasindaBiz
{
    public partial class HaberDetay
    {
        [Inject]
        private IBaseRepository<HaberDuyuru> HaberServisi { get; set; }

        [Parameter]
        public int HaberId { get; set; }

        public ImageFile HahberDetayDosya { get; set; } = new();

        private HaberDuyuru HaberDetayGetir { get; set; }

        protected IEnumerable<HaberDuyuru> Haberler { get; set; }

        protected IEnumerable<HaberDuyuru> TumHaberleriGetir()
        {
            Haberler = HaberServisi.GetAll().AsQueryable().Include(s => s.ImageFile).ToList();
            return Haberler;
        }
        
        [Inject]
        public IJSRuntime JsRun { get; set; }
        protected override async void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (firstRender)
            {
                await JsRun.InvokeVoidAsync("lightGallery");
            }
        }

        protected override Task OnInitializedAsync()
        {
            HaberDetayGetir = HaberServisi.Get(HaberId);
            return Task.CompletedTask;
        }
    }
}
