﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Components.ModalComponents;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Entities.Models.Mevzuat;
using VedasPortal.Entities.Models.Video;
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
        public Mevzuat mevzuat = new Mevzuat();

        protected IEnumerable<Mevzuat> Mevzuatlar { get; set; }

        protected IEnumerable<Mevzuat> TumMevzuatlariGetir()
        {
            Mevzuatlar = MevzuatServisi.GetAll();

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

        protected void Kayit()
        {
            MevzuatServisi.AddUpdate(mevzuat);

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


        public Dosya MevzuatDosya { get; set; } = new Dosya();
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

            UrlNavigationManager.NavigateTo("/duyuru/ekle");
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
