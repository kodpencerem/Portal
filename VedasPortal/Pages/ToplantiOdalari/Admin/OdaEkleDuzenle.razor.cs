﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Components.ModalComponents;
using VedasPortal.Entities.Models.ToplantiTakvimi;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.ToplantiOdalari.Admin
{
    public class ToplantiOdasiModeli : ComponentBase
    {

        [Inject]
        public IBaseRepository<ToplantiOdasi> ToplantiOdasi { get; set; }

        [Inject]
        public NavigationManager UrlNavigationManager { get; set; }

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
            ToplantiOdasi.Add(Oda);

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
            TumOdalariGetir();
            return Task.CompletedTask;
        }

        public void Temizle()
        {
            Oda = null;

            UrlNavigationManager.NavigateTo("/oda/ekle");
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
