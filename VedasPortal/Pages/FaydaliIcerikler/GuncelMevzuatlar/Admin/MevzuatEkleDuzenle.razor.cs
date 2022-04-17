using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Components.ModalComponents;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Entities.Models.Egitim;
using VedasPortal.Entities.Models.Mevzuat;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.FaydaliIcerikler.GuncelMevzuatlar.Admin
{
    public class MevzuatModel : ComponentBase
    {

        [Inject]
        public IBaseRepository<Mevzuat> MevzuatServisi { get; set; }

        [Inject]
        public NavigationManager UrlNavigationManager { get; set; }

        [Parameter]
        public int MevzuatId { get; set; }

        protected string Title = "Ekle";
        public Mevzuat mevzuat = new();
        public Dosya MevzuatDosya { get; set; } = new();

        protected IEnumerable<Mevzuat> Mevzuatlar { get; set; }

        protected IEnumerable<Mevzuat> TumMevzuatlariGetir()
        {
            Mevzuatlar = MevzuatServisi.GetAll().AsQueryable().Include(s => s.Dosya).ToList();

            return Mevzuatlar;

        }
        public Dictionary<MevzuatKategori, string> Kategoriler { get; set; }
        protected void TumKategorileriGetir()
        {
            var list = new Dictionary<MevzuatKategori, string>();
            foreach (MevzuatKategori item in Enum.GetValues(typeof(MevzuatKategori)))
            {
                list.Add(item, item.TextMevzuat());
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

        [Inject]
        public IBaseRepository<Dosya> MevzuatDosyaServisi { get; set; }
        protected void Kayit()
        {
            MevzuatServisi.Add(mevzuat);

            var fileName = SaveFileToUploaded.FileName.Split(".");
            var filePath = SaveFileToUploaded.ImageUploadedPath;
            var dosya = new Dosya()
            {
                Adi = fileName[0],
                Yolu = filePath,
                Uzanti = fileName[1],
                Kategori = DosyaKategori.Jpg,
                AktifPasif = true,
                MevzuatId = mevzuat.Id,

            };
            MevzuatDosyaServisi.Add(dosya);

        }
        protected override void OnParametersSet()
        {
            if (MevzuatId != 0)
            {
                Title = "Duzenle";
                mevzuat = MevzuatServisi.Get(MevzuatId);
            }
        }

        protected void SilmeyiOnayla(int duyuruId)
        {
            ModalDialog.Open();
            mevzuat = Mevzuatlar.FirstOrDefault(x => x.Id == duyuruId);
        }
        public ModalComponent ModalDialog { get; set; }
        protected string DialogGorunur { get; set; } = "none";

        protected void Sil()
        {
            if (mevzuat.Id == 0)
                return;

            MevzuatServisi.Remove(mevzuat.Id);
            mevzuat = new Mevzuat();
            TumMevzuatlariGetir();
            TumBirimleriGetir();
            TumKategorileriGetir();
        }

        protected override Task OnInitializedAsync()
        {
            TumMevzuatlariGetir();
            TumBirimleriGetir();
            TumKategorileriGetir();
            return Task.CompletedTask;
        }

        public void Temizle()
        {
            mevzuat = null;

            UrlNavigationManager.NavigateTo("/mevzuat/ekle");
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
