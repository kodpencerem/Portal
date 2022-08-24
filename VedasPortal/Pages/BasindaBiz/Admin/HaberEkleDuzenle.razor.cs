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
using VedasPortal.Entities.Models.HaberDuyuru;
using VedasPortal.Enums;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.BasindaBiz.Admin
{

    public class HaberEkleDuzenleModel : ComponentBase
    {

        [Inject]
        public IBaseRepository<HaberDuyuru> HaberServisi { get; set; }

        [Inject]
        public IBaseRepository<ImageFile> HaberDosyaServisi { get; set; }

        [Parameter]
        public int HaberId { get; set; }

        protected string Title = "Ekle";
        public HaberDuyuru haber = new();

        public ImageFile HaberDosya = new();
        [CascadingParameter]
        public Task<AuthenticationState> State { get; set; }
        protected IEnumerable<HaberDuyuru> Haberler { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected IEnumerable<HaberDuyuru> TumHaberleriGetir()
        {
            Haberler = HaberServisi.GetAll().AsQueryable().Include(s => s.ImageFile).ToList();
            return Haberler;
        }
        public Dictionary<HaberDuyuruKategori, string> Kategoriler { get; set; }
        protected void TumKategorileriGetir()
        {
            var list = new Dictionary<HaberDuyuruKategori, string>();
            foreach (HaberDuyuruKategori item in Enum.GetValues(typeof(HaberDuyuruKategori)))
            {
                list.Add(item, item.TextHaberDuyuru());
            }
            Kategoriler = list;
        }

        protected async Task HaberKayitAsync()
        {
            var authState = await State;
            haber.KaydedenKullanici = authState.User.Identity.Name;
            HaberServisi.Add(haber);

            var fileName = SaveFileToUploaded.FileName?.Split(".");
            var imagePath = SaveFileToUploaded.ImageUploadedPath;

            var dosya = new ImageFile()
            {
                Adi = fileName[0],
                Yolu = imagePath,
                Uzanti = fileName[1],
                Kategori = DosyaKategori.Jpg,
                AktifPasif = true,
                HaberDuyuruId = haber.Id,
                KaydedenKullanici = authState.User.Identity.Name
            };
            HaberDosyaServisi.Add(dosya);
            TumHaberleriGetir();
            haber = new HaberDuyuru();

        }
        protected override void OnParametersSet()
        {
            if (HaberId != 0 || HaberDosya.Yolu != null)
            {
                Title = "Duzenle";
                haber = HaberServisi.Get(HaberId);
            }
        }

        protected void SilmeyiOnayla(int haberId)
        {
            ModalDialog.Open();
            haber = Haberler.FirstOrDefault(x => x.Id == haberId);
        }

        protected void HaberSil()
        {
            if (haber.Id == 0 && HaberDosya.Id == 0)
                return;
            HaberServisi.Remove(haber.Id);
            HaberDosyaServisi.Remove(HaberDosya.Id);
            haber = new HaberDuyuru();
            TumHaberleriGetir();
        }
        public ModalComponent ModalDialog { get; set; }
        protected string DialogGorunur { get; set; } = "none";

        protected override Task<Task> OnInitializedAsync()
        {

            TumHaberleriGetir();
            TumKategorileriGetir();
            return Task.FromResult(Task.CompletedTask);
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