using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Components.ShowModalComponent;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Entities.Models.HaberDuyuru;
using VedasPortal.Enums;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.Duyurular.Admin
{
    public class DuyuruEkleDuzenleModel : ComponentBase
    {

        [Inject]
        public IBaseRepository<HaberDuyuru> DuyuruServisi { get; set; }

        [Inject]
        public IBaseRepository<ImageFile> DuyuruDosyaServisi { get; set; }

        [Parameter]
        public int DuyuruId { get; set; }

        [Parameter]
        public int DuyuruDosyaId { get; set; }

        protected string Title = "Ekle";
        public HaberDuyuru duyuru = new();

        public ImageFile DuyuruDosya = new();

        protected IEnumerable<HaberDuyuru> Duyurular { get; set; }

        protected IEnumerable<HaberDuyuru> TumDuyurulariGetir()
        {
            Duyurular = DuyuruServisi.GetAll().AsQueryable().Include(s => s.ImageFile).ToList();
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
        [CascadingParameter]
        public Task<AuthenticationState> State { get; set; }
        protected async Task KayitAsync()
        {
            var authState = await State;
            duyuru.KaydedenKullanici = authState.User.Identity.Name;
            DuyuruServisi.Add(duyuru);
            var fileName = SaveFileToUploaded.FileName.Split(".");
            var filePath = SaveFileToUploaded.ImageUploadedPath;
            var dosya = new ImageFile()
            {
                Adi = fileName[0],
                Yolu = filePath,
                Uzanti = fileName[1],
                Kategori = DosyaKategori.Jpg,
                AktifPasif = true,
                HaberDuyuruId = duyuru.Id,
                KaydedenKullanici = authState.User.Identity.Name

            };
            DuyuruDosyaServisi.Add(dosya);
            TumDuyurulariGetir();
            
            duyuru = new HaberDuyuru();
        }
        protected override void OnParametersSet()
        {
            if (DuyuruId != 0 || DuyuruDosya.Yolu != null)
            {
                Title = "Duzenle";
                duyuru = DuyuruServisi.Get(DuyuruId);
                DuyuruDosya = DuyuruDosyaServisi.Get(DuyuruDosyaId);
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
            DuyuruDosya.Yolu = duyuru.ImageFile?.FirstOrDefault().Yolu;
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