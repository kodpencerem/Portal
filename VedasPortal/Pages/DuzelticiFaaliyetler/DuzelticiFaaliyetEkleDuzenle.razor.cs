using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Components.ModalComponents;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Entities.Models.DuzelticiFaaliyet;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.DuzelticiFaaliyetler
{
    public class DuzelticiFaaliyetModeli : ComponentBase
    {

        [Inject]
        public IBaseRepository<DuzelticiFaaliyet> DuzelticiFaaliyetlerServisi { get; set; }

        [Inject]
        public NavigationManager UrlNavigationManager { get; set; }

        [Parameter]
        public int DFaaliyetId { get; set; }

        protected string Title = "Ekle";
        public DuzelticiFaaliyet duzelticiFaaliyet = new();

        public Dosya DFaaliyetDosya = new();

        protected IEnumerable<DuzelticiFaaliyet> DuzelticiFaaliyetler { get; set; }

        protected IEnumerable<DuzelticiFaaliyet> TumFaaliyetleriGetir()
        {
            DuzelticiFaaliyetler = DuzelticiFaaliyetlerServisi.GetAll();
            return DuzelticiFaaliyetler;

        }
        public Dictionary<DuzelticiFaaliyetKategori, string> Kategoriler { get; set; }
        protected void TumKategorileriGetir()
        {
            var list = new Dictionary<DuzelticiFaaliyetKategori, string>();
            foreach (DuzelticiFaaliyetKategori item in Enum.GetValues(typeof(DuzelticiFaaliyetKategori)))
            {
                list.Add(item, item.TextDuzelticiFaaliyet());
            }
            Kategoriler = list;
        }

        protected void DuzelticiFaaliyetKaydet()
        {
            DuzelticiFaaliyetlerServisi.Add(duzelticiFaaliyet);

            DFaaliyetDosya.Yolu = duzelticiFaaliyet.Dosya.FirstOrDefault()?.Yolu;

            //var dosya = haber.Dosya.Select(x => new Dosya {
            //    Id= x.Id,
            //    Adi=x.Adi,
            //    Aciklama= x.Aciklama,
            //    Boyutu = x.Boyutu,
            //    Yolu = x.Yolu,
            //    DuzenlemeTarihi= x.DuzenlemeTarihi,
            //    DuzenleyenKullanici = x.DuzenleyenKullanici,
            //    KaydedenKullanici = x.KaydedenKullanici,
            //    KayitTarihi = x.KayitTarihi,
            //    Uzanti= x.Uzanti

            //});
            //haber.Dosya = dosya.ToArray();

        }
        protected override void OnParametersSet()
        {
            if (DFaaliyetId != 0)
            {
                Title = "Duzenle";
                duzelticiFaaliyet = DuzelticiFaaliyetlerServisi.Get(DFaaliyetId);
                DFaaliyetDosya.Yolu = duzelticiFaaliyet.Dosya.FirstOrDefault()?.Yolu;
            }
        }



        protected void SilmeyiOnayla(int dFaaliyetId)
        {
            ModalDialog.Open();
            duzelticiFaaliyet = DuzelticiFaaliyetler.FirstOrDefault(x => x.Id == dFaaliyetId);
        }
        public ModalComponent ModalDialog { get; set; }
        protected string DialogGorunur { get; set; } = "none";

        protected void Sil()
        {
            if (duzelticiFaaliyet.Id == 0)
                return;

            DuzelticiFaaliyetlerServisi.Remove(duzelticiFaaliyet.Id);
            duzelticiFaaliyet = new DuzelticiFaaliyet();
            TumFaaliyetleriGetir();
        }



        protected override Task OnInitializedAsync()
        {
            TumFaaliyetleriGetir();
            TumKategorileriGetir();
            return Task.CompletedTask;
        }

        public void Temizle()
        {
            duzelticiFaaliyet = null;

            UrlNavigationManager.NavigateTo("/duzelticifaaliyet/ekle");
        }


        [Inject]
        public IJSRuntime JsRun { get; set; }
        protected override async void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (firstRender)
            {
                await JsRun.InvokeVoidAsync("dataTables");
            }
        }
    }
}
