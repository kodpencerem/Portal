using Microsoft.AspNetCore.Components;
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
using VedasPortal.Services.Pdf;

namespace VedasPortal.Pages.FaydaliIcerikler.Egitimler.Admin
{
    public class EgitimModeli : ComponentBase
    {

        [Inject]
        public IBaseRepository<Egitim> EgitimServisi { get; set; }

        [Inject]
        public IBaseRepository<Dosya> VideoServisi { get; set; }

        [Parameter]
        public int EgitimId { get; set; }

        protected string Title = "Ekle";
        public Egitim egitim = new();

        public Dosya vidyo = new();

        public Dosya VideoDosya = new();

        [CascadingParameter]
        public Task<AuthenticationState> State { get; set; }

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

        protected async Task KayitAsync()
        {
            var authState = await State;
            egitim.KaydedenKullanici = authState.User.Identity.Name;

            EgitimServisi.Add(egitim);

            var videoName = SaveFileToUploaded.FileName.Split(".");
            var videoPath = SaveFileToUploaded.FileUploadedPath;
            if (egitim.Id != 0)
            {
                var video = new Dosya()
                {
                    Adi = videoName[0],
                    Yolu = videoPath,
                    Uzanti = videoName[1],
                    Kategori = DosyaKategori.Mp4,
                    AktifPasif = true,
                    Aciklama = egitim.Aciklama,
                    EgitimId = egitim.Id,
                    AltBaslik = egitim.AltBaslik,
                    Birimler = egitim.Birimler,
                    IzlenmeDurumu = egitim.IzlenmeDurumu,
                    KayitTarihi = egitim.KayitTarihi,
                    KaydedenKullanici = authState.User.Identity.Name,
                    VideoKategori = vidyo.VideoKategori,
                };
                VideoServisi.Add(video);
            }           
            TumEgitimleriGetir();
            egitim = new Egitim();

        }
        protected override void OnParametersSet()
        {
            if (EgitimId != 0)
            {
                Title = "Duzenle";
                VideoDosya.Yolu = egitim.Dosya.FirstOrDefault()?.Yolu;
                egitim = EgitimServisi.Get(EgitimId);

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
            if (egitim.Id == vidyo.EgitimId)
            {
                VideoServisi.Remove(vidyo.Id);
            }
            EgitimServisi.Remove(egitim.Id);
            egitim = new Egitim();
            TumEgitimleriGetir();

        }

        protected override Task OnInitializedAsync()
        {
            TumBirimleriGetir();
            TumEgitimleriGetir();
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
