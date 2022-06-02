using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Components.ShowModalComponent;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Entities.Models.Egitim;
using VedasPortal.Enums;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.FaydaliIcerikler.Egitimler.Admin
{
    public class EgitimModeli : ComponentBase
    {

        [Inject]
        public IBaseRepository<Egitim> EgitimServisi { get; set; }

        [Inject]
        public IBaseRepository<Dosya> EgitimDosyaServisi { get; set; }

        [Parameter]
        public int EgitimId { get; set; }

        protected string Title = "Ekle";
        public Egitim egitim = new();

        public Dosya EgitimDosya = new();

        protected IEnumerable<Egitim> Egitimler { get; set; }

        protected IEnumerable<Egitim> TumEgitimleriGetir()
        {
            Egitimler = EgitimServisi.GetAll().AsQueryable().Include(s => s.Dosya).ToList();
            return Egitimler;

        }

        public Dictionary<EgitimKategori, string> Kategoriler { get; set; }
        protected void TumKategorileriGetir()
        {
            var list = new Dictionary<EgitimKategori, string>();
            foreach (EgitimKategori item in Enum.GetValues(typeof(EgitimKategori)))
            {
                list.Add(item, item.TextEgitim());
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

        protected void Kayit()
        {
            EgitimServisi.Add(egitim);
            
            var fileName = SaveFileToUploaded.FileName.Split(".");
            var filePath = SaveFileToUploaded.FileUploadedPath;            
            var dosya = new Dosya()
            {
                Adi = fileName[0],
                Yolu = filePath,
                Uzanti = fileName[1],
                Kategori = DosyaKategori.Jpg,
                AktifPasif = true,
                EgitimId = egitim.Id,

            };
            EgitimDosyaServisi.Add(dosya);
            
            TumEgitimleriGetir();
            egitim = new Egitim();

        }
        protected override void OnParametersSet()
        {
            if (EgitimId != 0)
            {
                Title = "Duzenle";
                egitim = EgitimServisi.Get(EgitimId);
                EgitimDosya.Yolu = egitim.Dosya.FirstOrDefault()?.Yolu;
            }
        }



        protected void SilmeyiOnayla(int egitimId)
        {
            ModalDialog.Open();
            egitim = Egitimler.FirstOrDefault(x => x.Id == egitimId);
        }
        public ModalComponent ModalDialog { get; set; }
        protected string DialogGorunur { get; set; } = "none";

        protected void Sil()
        {
            if (egitim.Id == 0)
                return;

            EgitimServisi.Remove(egitim.Id);
            EgitimDosyaServisi.Remove(EgitimDosya.Id);
            egitim = new Egitim();
            TumEgitimleriGetir();
            TumBirimleriGetir();
        }



        protected override Task OnInitializedAsync()
        {
            TumBirimleriGetir();
            TumEgitimleriGetir();
            TumKategorileriGetir();
            return Task.CompletedTask;
        }

        public void Temizle()
        {
            egitim = null;

            EgitimDosya = null;
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
