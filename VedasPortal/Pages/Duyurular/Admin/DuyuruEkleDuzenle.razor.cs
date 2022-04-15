using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Components.ModalComponents;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Entities.Models.HaberDuyuru;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.Duyurular.Admin
{
    public class DuyuruEkleDuzenleModel : ComponentBase
    {

        [Inject]
        public IBaseRepository<HaberDuyuru> DuyuruServisi { get; set; }

        [Inject]
        public IBaseRepository<Dosya> DuyuruDosyaServisi { get; set; }

        [Inject]
        public NavigationManager UrlNavigationManager { get; set; }

        [Parameter]
        public int DuyuruId { get; set; }

        protected string Title = "Ekle";
        public HaberDuyuru duyuru = new();

        public Dosya DuyuruDosya = new();

        protected IEnumerable<HaberDuyuru> Duyurular { get; set; }

        protected IEnumerable<HaberDuyuru> TumDuyurulariGetir()
        {
            Duyurular = DuyuruServisi.GetAll().AsQueryable().Include(s => s.Dosya).ToList();
            return Duyurular;
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

        protected void Kayit()
        {

            DuyuruServisi.Add(duyuru);
            var fileName = SaveFileToUploaded.FileName.Split(".");
            var filePath = SaveFileToUploaded.ImageUploadedPath;
            var dosya = new Dosya()
            {
                Adi = fileName[0],
                Yolu = filePath,
                Uzanti = fileName[1],
                Kategori = DosyaKategori.Jpg,
                AktifPasif = true,
                HaberDuyuruId = duyuru.Id,

            };
            DuyuruDosyaServisi.Add(dosya);
        }
        protected override void OnParametersSet()
        {
            if (DuyuruId != 0 || DuyuruDosya.Yolu != null)
            {
                Title = "Duzenle";
                duyuru = DuyuruServisi.Get(DuyuruId);
            }
        }

        protected void SilmeyiOnayla(int DuyuruId)
        {
            ModalDialog.Open();

            duyuru = Duyurular.FirstOrDefault(x => x.Id == DuyuruId);
        }
        public ModalComponent ModalDialog { get; set; }
        protected string DialogGorunur { get; set; } = "none";

        protected void Sil()
        {
            if (duyuru.Id == 0)
                return;
            DuyuruDosya.Yolu = duyuru.Dosya?.FirstOrDefault().Yolu;
            DuyuruServisi.Remove(duyuru.Id);
            duyuru = new HaberDuyuru();
            TumDuyurulariGetir();
        }

        protected override Task OnInitializedAsync()
        {
            TumDuyurulariGetir();
            TumKategorileriGetir();
            return Task.CompletedTask;
        }

        public void Temizle()
        {
            duyuru = null;

            UrlNavigationManager.NavigateTo("/haber/ekle");
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