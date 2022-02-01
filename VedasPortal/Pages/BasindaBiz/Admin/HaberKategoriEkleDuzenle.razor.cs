﻿using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Components.ModalComponents;
using VedasPortal.Models.HaberDuyuru;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.BasindaBiz.Admin
{
    public class HKategoriEkleDuzenle : ComponentBase
    {
        [Inject]
        public IBaseRepository<HaberDuyuruKategori> YayinKategorisi { get; set; }
        [Inject]
        public NavigationManager UrlNavigationManager { get; set; }

        protected IEnumerable<HaberDuyuruKategori> yayinKategorileri = new List<HaberDuyuruKategori>();

        [Parameter]
        public int kategoriId { get; set; }
        protected string Title = "Ekle";
        public HaberDuyuruKategori haberKategori = new HaberDuyuruKategori();
        protected override void OnParametersSet()
        {
            if (kategoriId != 0)
            {
                Title = "Duzenle";
                haberKategori = YayinKategorisi.Get(kategoriId);

            }
        }

        protected void KategoriKayit()
        {
            YayinKategorisi.AddUpdate(haberKategori);
        }

        protected override Task OnInitializedAsync()
        {
            TumHaberleriGetir();
            return Task.CompletedTask;
        }

        protected IEnumerable<HaberDuyuruKategori> TumHaberleriGetir()
        {
            yayinKategorileri = YayinKategorisi.GetAll();
            return yayinKategorileri;

        }

        protected string DialogGorunur { get; set; } = "none";
        protected void SilmeyiOnayla(int haberId)
        {
            ModalDialog.Open();
            haberKategori = yayinKategorileri.FirstOrDefault(x => x.Id == haberId);
        }
        public ModalComponent ModalDialog { get; set; }
        protected void HaberSil()
        {
            if (haberKategori.Id == 0)
                return;

            YayinKategorisi.Remove(haberKategori.Id);
            haberKategori = new HaberDuyuruKategori();
            TumHaberleriGetir();
        }

        public void Cancel()
        {
            UrlNavigationManager.NavigateTo("/HaberKategoriBilgisi");
        }

        public void Temizle()
        {
            haberKategori = null;
            Cancel();
        }
    }
}
