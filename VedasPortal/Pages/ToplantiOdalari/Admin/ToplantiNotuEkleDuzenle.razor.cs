using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Components.ShowModalComponent;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Entities.Models.Egitim;
using VedasPortal.Entities.Models.ToplantiTakvimi;
using VedasPortal.Entities.Models.ToplantiTakvimi.ToplantiNotu;
using VedasPortal.Entities.ViewModels;
using VedasPortal.Enums;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.ToplantiOdalari.Admin
{
    public class ToplantiNotuModeli : ComponentBase
    {

        [Inject]
        public IBaseRepository<ToplantiNotu> ToplantiNotServisi { get; set; }

        [Inject]
        public IToplantiTakvimi toplantiTakvimi { get; set; }

        [Inject]
        public IBaseRepository<ImageFile> ToplantiNotDosyaServisi { get; set; }

        protected ToplantiTakvimVm ToplantiTakvimVm { get; set; } = new ToplantiTakvimVm();

        public Toplanti toplanti { get; set; } = new();

        [Parameter]
        public int TNotId { get; set; }

        protected string Title = "Ekle";
        public ToplantiNotu GetToplantiNotu = new();
        public ImageFile GetDosya = new();

        protected IEnumerable<ToplantiNotu> ToplantiNotlari { get; set; }

        [Inject]
        protected IBaseRepository<Toplanti> ToplantiServisi { get; set; }
        protected IEnumerable<Toplanti> Toplantilar;

        protected IEnumerable<Toplanti> TumToplantilar()
        {
            Toplantilar = ToplantiServisi.GetAll();
            return Toplantilar;
        }

        protected IEnumerable<ToplantiNotu> TumNotlarilariGetir()
        {
            ToplantiNotlari = ToplantiNotServisi.GetAll();
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

            GetToplantiNotu.ToplantiMerkeziId = Convert.ToInt32(ToplantiTakvimVm.MerkezId);
            GetToplantiNotu.ToplantiOdasiId = Convert.ToInt32(ToplantiTakvimVm.OdaId);
           
            ToplantiNotServisi.Add(GetToplantiNotu);

            if(GetToplantiNotu.Id != 0)
            {
                var fileName = SaveFileToUploaded.FileName.Split(".");
                var filePath = SaveFileToUploaded.FileUploadedPath;

                var dosya = new ImageFile()
                {
                    Adi = fileName[0],
                    Yolu = filePath,
                    Uzanti = fileName[1],
                    Kategori = DosyaKategori.Jpg,
                    AktifPasif = true,
                    ToplantiNotuId = GetToplantiNotu.Id,
                };
                ToplantiNotDosyaServisi.Add(dosya);
            }
            TumNotlarilariGetir();
            GetToplantiNotu = new ToplantiNotu();
        }

        protected override void OnParametersSet()
        {
            if (TNotId != 0)
            {
                Title = "Duzenle";
                GetToplantiNotu = ToplantiNotServisi.Get(TNotId);
                //DuyuruDosya = duyuru.Dosya.FirstOrDefault();
            }
        }

        protected void SilmeyiOnayla(int TNotId)
        {
            ModalDialog.Open();
            GetToplantiNotu = ToplantiNotlari.FirstOrDefault(x => x.Id == TNotId);
        }
        public ModalComponent ModalDialog { get; set; }
        protected string DialogGorunur { get; set; } = "none";

        protected void Sil()
        {
            if (GetToplantiNotu.Id == 0)
                return;

            ToplantiNotServisi.Remove(GetToplantiNotu.Id);
            ToplantiNotDosyaServisi.Remove(GetDosya.Id);
            GetToplantiNotu = new ToplantiNotu();
            TumNotlarilariGetir();
            TumBirimleriGetir();
        }

        protected void OnMerkezChange(string value)
        {

            if (value != null)
            {
                ToplantiTakvimVm.MerkezId = value.ToString();
                ToplantiTakvimVm.OdaId = "";
                ToplantiTakvimVm.ListofToplantiOdalari = new List<SelectListItem>()
                {
                    new SelectListItem()
                    {
                        Text = "Seçiniz...",
                        Value = ""
                    }
                };

                ToplantiTakvimVm.ListofToplantiOdalari = toplantiTakvimi.ToplantiOdalari(Convert.ToInt32(ToplantiTakvimVm.MerkezId));
                this.StateHasChanged();
            }
        }

        protected void OnOdaChange(string value)
        {
            if (value != null)
            {
                ToplantiTakvimVm.OdaId = value.ToString();
            }
        }
        protected override Task OnInitializedAsync()
        {
            ToplantiTakvimVm.ListofToplantiMerkezleri = toplantiTakvimi.ToplantiMerkezleri();
            ToplantiTakvimVm.MerkezId = "";
            ToplantiTakvimVm.ListofToplantiOdalari = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "Seçiniz",
                    Value = ""
                }
            };
            TumNotlarilariGetir();
            TumToplantilar();
            TumBirimleriGetir();
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
