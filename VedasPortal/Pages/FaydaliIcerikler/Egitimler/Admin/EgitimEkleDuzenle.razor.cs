﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Components.ModalComponents;
using VedasPortal.Models.Dosya;
using VedasPortal.Models.Video;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.FaydaliIcerikler.Egitimler.Admin
{
    public class EgitimModeli : ComponentBase
    {

        [Inject]
        public IBaseRepository<Egitim> EgitimServisi { get; set; }

        [Inject]
        public NavigationManager UrlNavigationManager { get; set; }

        [Parameter]
        public int EgitimId { get; set; }

        protected string Title = "Ekle";
        public Egitim egitim = new Egitim();

        public Dosya EgitimDosya = new Dosya();

        protected IEnumerable<Egitim> Egitimler { get; set; }

        protected IEnumerable<Egitim> TumEgitimleriGetir()
        {
            Egitimler = EgitimServisi.GetAll();
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
            EgitimServisi.AddUpdate(egitim);

            EgitimDosya.Yolu = egitim.Kapak?.Yolu;

            
        }
        protected override void OnParametersSet()
        {
            if (EgitimId != 0)
            {
                Title = "Duzenle";
                egitim = EgitimServisi.Get(EgitimId);
                EgitimDosya.Yolu = egitim.Kapak.Yolu;
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

            UrlNavigationManager.NavigateTo("/egitim/ekle");
        }


        [Inject]
        public IJSRuntime jsRun { get; set; }
        protected override async void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (firstRender)
            {
                await jsRun.InvokeVoidAsync("dataTables");
            }
        }
    }
}