using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Components.ShowModalComponent;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Entities.Models.Oneri;
using VedasPortal.Enums;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.OneriSistemi.Admin
{
    public class OneriEklemeModeli : ComponentBase
    {

        [Inject]
        public IBaseRepository<Oneri> OneriServisi { get; set; }

        [Inject]
        public IBaseRepository<ImageFile> OneriDosyaServisi { get; set; }

        [Parameter]
        public int OneriId { get; set; }

        protected string Title = "Ekle";
        public Oneri oneri = new();

        public ImageFile OneriDosya = new();

        protected IEnumerable<Oneri> Oneriler { get; set; }

        protected IEnumerable<Oneri> TumOnerileriGetir()
        {
            Oneriler = OneriServisi.GetAll().AsQueryable().Include(s => s.Dosya).ToList();
            return Oneriler;
        }

        public Dictionary<OnemDerecesi, string> OnemDereceleri { get; set; }
        protected void TumDereceleriGetir()
        {
            var list = new Dictionary<OnemDerecesi, string>();
            foreach (OnemDerecesi item in Enum.GetValues(typeof(OnemDerecesi)))
            {
                list.Add(item, item.TextOnemDerecesi());
            }
            OnemDereceleri = list;
        }


        public Dictionary<Odul, string> Oduller { get; set; }
        protected void TumOdulleriGetir()
        {
            var list = new Dictionary<Odul, string>();
            foreach (Odul item in Enum.GetValues(typeof(Odul)))
            {
                list.Add(item, item.TextOdul());
            }
            Oduller = list;
        }


        public Dictionary<OneriKategori, string> OneriKategorileri { get; set; }
        protected void TumKategorileriGetir()
        {
            var list = new Dictionary<OneriKategori, string>();
            foreach (OneriKategori item in Enum.GetValues(typeof(OneriKategori)))
            {
                list.Add(item, item.TextOneriKategori());
            }
            OneriKategorileri = list;
        }

        protected void Kayit()
        {

            OneriServisi.Add(oneri);
            var fileName = SaveFileToUploaded.FileName.Split(".");
            var filePath = SaveFileToUploaded.ImageUploadedPath;
            var dosya = new ImageFile()
            {
                Adi = fileName[0],
                Yolu = filePath,
                Uzanti = fileName[1],
                Kategori = DosyaKategori.Jpg,
                AktifPasif = true,
                OneriId = oneri.Id,

            };
            OneriDosyaServisi.Add(dosya);
            TumOnerileriGetir();
            oneri = new Oneri();
        }
        protected override void OnParametersSet()
        {
            if (OneriId != 0 || OneriDosya.Yolu != null)
            {
                Title = "Duzenle";
                oneri = OneriServisi.Get(OneriId);
            }
        }

        protected void SilmeyiOnayla(int OneriId)
        {
            ModalDialog.Open();

            oneri = Oneriler.FirstOrDefault(x => x.Id == OneriId);
        }
        public ModalComponent ModalDialog { get; set; }
        protected string DialogGorunur { get; set; } = "none";

        protected void Sil()
        {
            if (oneri.Id == 0)
                return;
            OneriDosya.Yolu = oneri.Dosya?.FirstOrDefault().Yolu;
            OneriDosyaServisi.Remove(OneriDosya.Id);
            OneriServisi.Remove(oneri.Id);
            oneri = new Oneri();
            TumKategorileriGetir();
            TumOnerileriGetir();
            TumDereceleriGetir();
            TumOdulleriGetir();
        }

        protected override Task OnInitializedAsync()
        {
            TumKategorileriGetir();
            TumOnerileriGetir();
            TumDereceleriGetir();
            TumOdulleriGetir();

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