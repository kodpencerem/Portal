using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Components.ModalComponents;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Entities.Models.Egitim;
using VedasPortal.Entities.Models.ToplantiTakvimi.ToplantiNotu;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.ToplantiOdalari.Admin
{
    public class ToplantiNotuModeli : ComponentBase
    {

        [Inject]
        public IBaseRepository<ToplantiNotu> ToplantiNotu { get; set; }

        [Inject]
        public IBaseRepository<Dosya> ToplantiNotDosya { get; set; }

        [Parameter]
        public int ToplantiNotId { get; set; }

        protected string Title = "Ekle";
        public ToplantiNotu ToplantiNot = new();
        public Dosya GetDosya = new();

        protected IEnumerable<ToplantiNotu> ToplantiNotlari { get; set; }

        protected IEnumerable<ToplantiNotu> TumNotlarilariGetir()
        {
            ToplantiNotlari = ToplantiNotu.GetAll();
            return ToplantiNotlari;
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
            ToplantiNotu.Add(ToplantiNot);
            var fileName = SaveFileToUploaded.FileName.Split(".");
            var filePath = SaveFileToUploaded.ImageUploadedPath;
            var dosya = new Dosya()
            {
                Adi = fileName[0],
                Yolu = filePath,
                Uzanti = fileName[1],
                Kategori = DosyaKategori.Jpg,
                AktifPasif = true,
                ToplantiNotuId= ToplantiNot.Id,

            };
            ToplantiNotDosya.Add(dosya);
        }
        protected override void OnParametersSet()
        {
            if (ToplantiNotId != 0)
            {
                Title = "Duzenle";
                ToplantiNot = ToplantiNotu.Get(ToplantiNotId);
                //DuyuruDosya = duyuru.Dosya.FirstOrDefault();
            }
        }

        protected void SilmeyiOnayla(int ToplantiNotId)
        {
            ModalDialog.Open();
            ToplantiNot = ToplantiNotlari.FirstOrDefault(x => x.Id == ToplantiNotId);
        }
        public ModalComponent ModalDialog { get; set; }
        protected string DialogGorunur { get; set; } = "none";

        protected void Sil()
        {
            if (ToplantiNot.Id == 0)
                return;

            ToplantiNotu.Remove(ToplantiNot.Id);
            ToplantiNot = new ToplantiNotu();
            TumNotlarilariGetir();
            TumBirimleriGetir();
        }

        protected override Task OnInitializedAsync()
        {
            TumNotlarilariGetir();
            TumBirimleriGetir();
            return Task.CompletedTask;
        }

        public void Temizle()
        {
            ToplantiNot = null;
            GetDosya = null;
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
