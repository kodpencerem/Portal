﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
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

namespace VedasPortal.Pages.FaydaliIcerikler.Videolar.Admin
{
    public class VideoEklemeModeli : ComponentBase
    {

        [Inject]
        public IBaseRepository<Dosya> VideoServisi { get; set; }

        [Parameter]
        public int VideoId { get; set; }

        protected string Title = "Ekle";
        public Dosya video = new();

        protected IEnumerable<Dosya> Videolar { get; set; }

        protected IEnumerable<Dosya> TumVideolariGetir()
        {
            Videolar = VideoServisi.GetAll();
            return Videolar;

        }
        public Dictionary<VideoKategori, string> Kategoriler { get; set; }
        protected void TumKategorileriGetir()
        {
            var list = new Dictionary<VideoKategori, string>();
            foreach (VideoKategori item in Enum.GetValues(typeof(VideoKategori)))
            {
                list.Add(item, item.TextVideo());
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
            var fileName = SaveFileToUploaded.FileName.Split(".");
            var filePath = SaveFileToUploaded.FileUploadedPath;
            var dosya = new Dosya()
            {
                Adi = fileName[0],
                Yolu= filePath,
                Uzanti = fileName[1],
                Kategori = video.Kategori,
                AltBaslik = video.AltBaslik,
                Aciklama = video.Aciklama,
                Birimler = video.Birimler,
                Boyutu = video.Boyutu,
                AktifPasif = true,
                KaydedenKullanici = authState.User.Identity.Name
            };
            VideoServisi.Add(dosya);
            TumVideolariGetir();
            video = new Dosya();
        }
        protected override void OnParametersSet()
        {
            if (VideoId != 0)
            {
                Title = "Duzenle";
                video = VideoServisi.Get(VideoId);
            }
        }



        protected void SilmeyiOnayla(int videoId)
        {
            ModalDialog.Open();
            video = Videolar.FirstOrDefault(x => x.Id == videoId);
        }
        public ModalComponent ModalDialog { get; set; }
        protected string DialogGorunur { get; set; } = "none";

        protected void Sil()
        {
            if (video.Id == 0)
                return;

            VideoServisi.Remove(video.Id);
            TumVideolariGetir();
            TumBirimleriGetir();
        }
        protected override Task OnInitializedAsync()
        {
            TumBirimleriGetir();
            TumVideolariGetir();
            TumKategorileriGetir();
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
