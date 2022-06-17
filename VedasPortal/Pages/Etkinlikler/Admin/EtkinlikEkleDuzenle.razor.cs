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
using VedasPortal.Entities.Models.Etkinlik;
using VedasPortal.Enums;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.Etkinlikler.Admin
{
    public class EtkinlikModeli : ComponentBase
    {

        [Inject]
        public IBaseRepository<Etkinlik> EtkinlikServisi { get; set; }

        [Inject]
        public IBaseRepository<ImageFile> EtkinlikDosyaServisi { get; set; }
       
        [Parameter]
        public int EtkinlikId { get; set; }

        protected string Title = "Ekle";
        public Etkinlik etkinlik = new();

        public ImageFile EtkinlikDosya = new();

        protected IEnumerable<Etkinlik> Etkinlikler { get; set; }

        protected IEnumerable<Etkinlik> TumEtkinlikleriGetir()
        {
            Etkinlikler = EtkinlikServisi.GetAll().AsQueryable().Include(s => s.ImageFile).ToList();
            return Etkinlikler;

        }
        public Dictionary<EtkinlikKategori, string> Kategoriler { get; set; }
        protected void TumKategorileriGetir()
        {
            var list = new Dictionary<EtkinlikKategori, string>();
            foreach (EtkinlikKategori item in Enum.GetValues(typeof(EtkinlikKategori)))
            {
                list.Add(item, item.TextEtkinlik());
            }
            Kategoriler = list;
        }

        public Dictionary<KatilimciKategori, string> KatilacakPersonel { get; set; }
        protected void TumKatilimcilariGetir()
        {
            var list = new Dictionary<KatilimciKategori, string>();
            foreach (KatilimciKategori item in Enum.GetValues(typeof(KatilimciKategori)))
            {
                list.Add(item, item.TextKatilimci());
            }
            KatilacakPersonel = list;
        }
        [CascadingParameter]
        public Task<AuthenticationState> State { get; set; }
        protected async Task EtkinlikKayitAsync()
        {
            var authState = await State;
            etkinlik.KaydedenKullanici = authState.User.Identity.Name;
            EtkinlikServisi.Add(etkinlik);
            var fileName = SaveFileToUploaded.FileName?.Split(".");
            var filePath = SaveFileToUploaded.ImageUploadedPath;
            var dosya = new ImageFile()
            {
                Adi = fileName[0],
                Yolu = filePath,
                Uzanti = fileName[1],
                Kategori = DosyaKategori.Jpg,
                AktifPasif = true,
                EtkinlikId = etkinlik.Id,
                KaydedenKullanici= authState.User.Identity.Name

            };
            EtkinlikDosyaServisi.Add(dosya);
            TumEtkinlikleriGetir();
            etkinlik = new Etkinlik();
        }
        protected override void OnParametersSet()
        {
            if (EtkinlikId != 0)
            {
                Title = "Duzenle";
                etkinlik = EtkinlikServisi.Get(EtkinlikId);                
            }
        }



        protected void SilmeyiOnayla(int etkinlikId)
        {
            ModalDialog.Open();
            etkinlik = Etkinlikler.FirstOrDefault(x => x.Id == etkinlikId);
        }
        public ModalComponent ModalDialog { get; set; }
        protected string DialogGorunur { get; set; } = "none";

        protected void EtkinlikSil()
        {
            if (etkinlik.Id == 0)
                return;

            EtkinlikServisi.Remove(etkinlik.Id);
            EtkinlikDosyaServisi.Remove(EtkinlikDosya.Id);
            etkinlik = new Etkinlik();
            TumEtkinlikleriGetir();
        }



        protected override Task OnInitializedAsync()
        {
            TumEtkinlikleriGetir();
            TumKategorileriGetir();
            TumKatilimcilariGetir();
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
