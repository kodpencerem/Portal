using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Components.ShowModalComponent;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Entities.Models.Egitim;
using VedasPortal.Entities.Models.IKUygulama;
using VedasPortal.Enums;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.InsanKaynaklariUygulamalari.Admin
{
    public class IkUygulamaModel : ComponentBase
    {

        [Inject]
        public IBaseRepository<IkUygulama> IkUygulamaServisi { get; set; }

        [Inject]
        public IBaseRepository<ImageFile> IkDosyaServisi { get; set; }

        [Parameter]
        public int IkUygulamaId { get; set; }

        protected string Title = "Ekle";
        public IkUygulama ikUygulama = new();

        protected IEnumerable<IkUygulama> IkUygulamalari { get; set; }

        protected IEnumerable<IkUygulama> TumIkUygulamalariniGetir()
        {
            IkUygulamalari = IkUygulamaServisi.GetAll().AsQueryable().Include(s => s.ImageFile).ToList();

            return IkUygulamalari;

        }
        public Dictionary<IkUygulamaKategori, string> Kategoriler { get; set; }
        protected void TumKategorileriGetir()
        {
            var list = new Dictionary<IkUygulamaKategori, string>();
            foreach (IkUygulamaKategori item in Enum.GetValues(typeof(IkUygulamaKategori)))
            {
                list.Add(item, item.TextIkUygulama());
            }
            Kategoriler = list;
        }

        public Dictionary<Birimler, string> Birimler { get; set; }
        protected void TumBirimleriGetir()
        {
            var list = new Dictionary<Birimler, string>();
            foreach (Birimler item in Enum.GetValues(typeof(Birimler)))
            {
                list.Add(item, item.TextBirimler());
            }
            Birimler = list;
        }

        [CascadingParameter]
        public Task<AuthenticationState> State { get; set; }
        protected async Task KayitAsync()
        {
            var authState = await State;
            ikUygulama.KaydedenKullanici = authState.User.Identity.Name;
            IkUygulamaServisi.Add(ikUygulama);

            var fileName = SaveFileToUploaded.FileName.Split(".");
            var filePath = SaveFileToUploaded.ImageUploadedPath;
            var dosya = new ImageFile()
            {
                Adi = fileName[0],
                Yolu = filePath,
                Uzanti = fileName[1],
                Kategori = DosyaKategori.Jpg,
                AktifPasif = true,
                IkUygulamaId = ikUygulama.Id,
                KaydedenKullanici = authState.User.Identity.Name

            };
            IkDosyaServisi.Add(dosya);
            TumIkUygulamalariniGetir();
            ikUygulama = new IkUygulama();

        }
        protected override void OnParametersSet()
        {
            if (IkUygulamaId != 0)
            {
                Title = "Duzenle";
                ikUygulama = IkUygulamaServisi.Get(IkUygulamaId);
            }
        }



        protected void SilmeyiOnayla(int ikUygulamaId)
        {
            ModalDialog.Open();
            ikUygulama = IkUygulamalari.FirstOrDefault(x => x.Id == ikUygulamaId);
        }
        public ModalComponent ModalDialog { get; set; }
        protected string DialogGorunur { get; set; } = "none";

        protected void Sil()
        {
            if (ikUygulama.Id == 0)
                return;

            IkUygulamaServisi.Remove(ikUygulama.Id);
            IkDosyaServisi.Remove(IkUygulamaDosya.Id);
            ikUygulama = new IkUygulama();
            TumIkUygulamalariniGetir();
            TumKategorileriGetir();
            TumBirimleriGetir();
        }


        public ImageFile IkUygulamaDosya { get; set; } = new ImageFile();
        protected override Task OnInitializedAsync()
        {
            TumIkUygulamalariniGetir();
            TumKategorileriGetir();
            TumBirimleriGetir();
            return Task.CompletedTask;
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
