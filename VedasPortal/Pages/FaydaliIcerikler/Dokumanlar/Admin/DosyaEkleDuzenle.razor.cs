﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Components.ModalComponents;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.FaydaliIcerikler.Dokumanlar.Admin
{
    public class DosyaModel : ComponentBase
    {

        [Inject]
        public IBaseRepository<Dosya> DosyaServisi { get; set; }

        [Inject]
        public NavigationManager UrlNavigationManager { get; set; }

        [Parameter]
        public int DosyaId { get; set; }

        protected string Title = "Ekle";
        public Dosya dokuman = new();

        

        protected IEnumerable<Dosya> Dosyalar { get; set; }

        protected IEnumerable<Dosya> TumDosyalariGetir()
        {
            Dosyalar = DosyaServisi.GetAll();
            return Dosyalar;

        }
        public Dictionary<DosyaKategori, string> Kategoriler { get; set; }
        protected void TumKategorileriGetir()
        {
            var list = new Dictionary<DosyaKategori, string>();
            foreach (DosyaKategori item in Enum.GetValues(typeof(DosyaKategori)))
            {
                list.Add(item, item.TextDosya());
            }
            Kategoriler = list;
        }

        protected void Kayit()
        {
            var fileName = SaveFileToUploaded.FileName.Split(".");
            var filePath = SaveFileToUploaded.ImageUploadedPath;
            var dosya = new Dosya()
            {
                Adi = fileName[0],
                Yolu = filePath,
                Uzanti = fileName[1],
                Kategori = DosyaKategori.Jpg,
                AktifPasif = true,
                Id = dokuman.Id,

            };
            DosyaServisi.Add(dosya);

            

        }
        protected override void OnParametersSet()
        {
            if (DosyaId != 0)
            {
                Title = "Duzenle";
                dokuman = DosyaServisi.Get(DosyaId);
            }
        }



        protected void SilmeyiOnayla(int dosyaId)
        {
            ModalDialog.Open();
            dokuman = Dosyalar.FirstOrDefault(x => x.Id == dosyaId);
        }
        public ModalComponent ModalDialog { get; set; }
        protected string DialogGorunur { get; set; } = "none";

        protected void Sil()
        {
            if (dokuman.Id == 0)
                return;

            DosyaServisi.Remove(dokuman.Id);
            dokuman = new Dosya();
            TumDosyalariGetir();
        }



        protected override Task OnInitializedAsync()
        {
            TumDosyalariGetir();
            TumKategorileriGetir();
            return Task.CompletedTask;
        }

        public void Temizle()
        {
            dokuman = null;

            UrlNavigationManager.NavigateTo("/dosya/ekle");
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
