using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using VedasPortal.Components.ShowModalComponent;
using VedasPortal.Entities.Models.Egitim;
using VedasPortal.Entities.Models.PersonelDurumlari;
using VedasPortal.Enums;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.PersonelBilgilendirme.Admin
{

    public class Vefatlar : ComponentBase
    {

        [Inject]
        public IBaseRepository<VefatDurumu> VefatDurumServisi { get; set; }
      
        [Inject]
        public AuthenticationStateProvider StateProvider { get; set; }

        [Parameter]
        public int VefatDurumId { get; set; }

        protected string Title = "Ekle";
        public VefatDurumu vefatDurumu = new();

        private ClaimsPrincipal User;
        public string Message { get; set; }

        protected IEnumerable<VefatDurumu> PersonelDurumlari { get; set; }

        protected IEnumerable<VefatDurumu> TumPersonelleriGetir()
        {
            PersonelDurumlari = VefatDurumServisi.GetAll();
            return PersonelDurumlari;
        }
        public Dictionary<PersonelDurumu, string> EklemeDurumlari { get; set; }
        protected void TumEklemeDurumlariniGetir()
        {
            var list = new Dictionary<PersonelDurumu, string>();
            foreach (PersonelDurumu item in Enum.GetValues(typeof(PersonelDurumu)))
            {
                list.Add(item, item.TextPersonelDurumu());
            }
            EklemeDurumlari = list;
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

        [Authorize(Roles = "Administrators")]
        protected void Kayit()
        {
            Message = "";
            if (User.Identity.IsAuthenticated && User.IsInRole("Administrators"))
            {
                VefatDurumServisi.Add(vefatDurumu);
            }
            else
            {
                Message = "Personel ayrılış kaydı oluşturma yetkiniz yoktur!";
            }


        }
        protected override void OnParametersSet()
        {
            if (VefatDurumId != 0)
            {
                Title = "Duzenle";
                vefatDurumu = VefatDurumServisi.Get(VefatDurumId);
            }
        }

        protected void SilmeyiOnayla(int VefatDurumId)
        {
            ModalDialog.Open();

            vefatDurumu = PersonelDurumlari.FirstOrDefault(x => x.Id == VefatDurumId);
        }

        protected void Sil()
        {
            if (vefatDurumu.Id == 0)
                return;
            VefatDurumServisi.Remove(vefatDurumu.Id);
            vefatDurumu = new VefatDurumu();
            TumPersonelleriGetir();
            TumEklemeDurumlariniGetir();
            TumBirimleriGetir();
        }
        public ModalComponent ModalDialog { get; set; }
        protected string DialogGorunur { get; set; } = "none";

        protected override async Task<Task> OnInitializedAsync()
        {
            var giris = await StateProvider.GetAuthenticationStateAsync();
            User = giris.User;
            TumPersonelleriGetir();
            TumEklemeDurumlariniGetir();
            TumBirimleriGetir();
            return Task.CompletedTask;
        }

        public void Temizle()
        {
            vefatDurumu = null;
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