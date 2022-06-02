using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Components.ShowModalComponent;
using VedasPortal.Entities.Models.ToplantiTakvimi;
using VedasPortal.Entities.ViewModels;
using VedasPortal.Repository.Interface;


namespace VedasPortal.Pages.ToplantiOdalari.Admin
{
    public class ToplantiOdasiModeli : ComponentBase
    {

        [Inject]
        public IBaseRepository<ToplantiOdasi> ToplantiOdasi { get; set; }

        protected ToplantiTakvimVm takvimVm { get; set; } = new ToplantiTakvimVm();

        [Inject]
        public IToplantiTakvimi _toplanti { get; set; }

        [Parameter]
        public int OdaId { get; set; }

        protected string Title = "Ekle";

        public ToplantiOdasi Oda = new();

        protected IEnumerable<ToplantiOdasi> Odalar { get; set; }

        protected IEnumerable<ToplantiOdasi> TumOdalariGetir()
        {
            Odalar = ToplantiOdasi.GetAll();
            return Odalar;
        }
        
        protected void Kayit()
        {
            var oda = new ToplantiOdasi()
            {
                Aciklama = Oda.Aciklama,
                Adi = Oda.Adi,
                Adres = Oda.Adres,
                AktifPasif = Oda.AktifPasif,
                Id = Oda.Id,
                DuzenlemeTarihi = Oda.DuzenlemeTarihi,
                DuzenleyenKullanici = Oda.DuzenleyenKullanici,
                Kapasite = Oda.Kapasite,
                KaydedenKullanici = Oda.KaydedenKullanici,
                KayitTarihi = Oda.KayitTarihi,
                Kod = Oda.Kod,
                VideoKonferansMi = Oda.VideoKonferansMi,
                RezervDurumu = Oda.RezervDurumu,
                SilenKullanici = Oda.SilenKullanici,
                SilmeTarihi = Oda.SilmeTarihi,
                ToplantiMerkeziId = Convert.ToInt32(takvimVm.MerkezId)
            };
            ToplantiOdasi.Add(oda);
            TumOdalariGetir();
            Oda = new ToplantiOdasi();

        }
        protected override void OnParametersSet()
        {
            if (OdaId != 0)
            {
                Title = "Duzenle";
                Oda = ToplantiOdasi.Get(OdaId);
                //DuyuruDosya = duyuru.Dosya.FirstOrDefault();
            }
        }
        
        protected void SilmeyiOnayla(int OdaId)
        {
            ModalDialog.Open();
            Oda = Odalar.FirstOrDefault(x => x.Id == OdaId);
        }
        public ModalComponent ModalDialog { get; set; }
        protected string DialogGorunur { get; set; } = "none";

        protected void Sil()
        {
            if (Oda.Id == 0)
                return;

            ToplantiOdasi.Remove(Oda.Id);
            Oda = new ToplantiOdasi();
            TumOdalariGetir();
        }

        protected override Task OnInitializedAsync()
        {
            takvimVm.ListofToplantiMerkezleri = _toplanti.ToplantiMerkezleri();
            TumOdalariGetir();
            return Task.CompletedTask;
        }
        protected void OnMerkezChange(string value)
        {
            if (value != null)
            {
                takvimVm.MerkezId = value;
            }
        }

        public void Temizle()
        {
            Oda = null;
            takvimVm = null;
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
