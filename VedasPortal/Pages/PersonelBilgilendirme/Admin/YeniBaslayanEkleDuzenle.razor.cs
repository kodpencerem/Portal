using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using VedasPortal.Components.ShowModalComponent;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Entities.Models.Egitim;
using VedasPortal.Entities.Models.PersonelDurumlari;
using VedasPortal.Enums;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.PersonelBilgilendirme.Admin
{

    public class IseYeniBaslayan : ComponentBase
    {

        [Inject]
        public IBaseRepository<PersonelDurum> PersonelServisi { get; set; }

        [Inject]
        public IBaseRepository<Dosya> PersonelDosyaServisi { get; set; }

        [Inject]
        public AuthenticationStateProvider StateProvider { get; set; }

        [Parameter]
        public int IseBaslayanId { get; set; }

        protected string Title = "Ekle";
        public PersonelDurum personelDurum = new();

        public Dosya PersonelDosya = new();

        private ClaimsPrincipal User;
        public string Message { get; set; }

        protected IEnumerable<PersonelDurum> PersonelDurumlari { get; set; }

        protected IEnumerable<PersonelDurum> TumPersonelleriGetir()
        {
            PersonelDurumlari = PersonelServisi.GetAll().AsQueryable().Include(s => s.Dosya).ToList();
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
                PersonelServisi.Add(personelDurum);
                var fileName = SaveFileToUploaded.FileName.Split(".");
                var filePath = SaveFileToUploaded.ImageUploadedPath;
                var dosya = new Dosya()
                {
                    Adi = fileName[0],
                    Yolu = filePath,
                    Uzanti = fileName[1],
                    Kategori = DosyaKategori.Jpg,
                    AktifPasif = true,
                    PersonelDurumId = personelDurum.Id,

                };
                PersonelDosyaServisi.Add(dosya);
            }
            else
            {
                Message = "Personel ayrılış kaydı oluşturma yetkiniz yoktur!";
            }


        }
        protected override void OnParametersSet()
        {
            if (IseBaslayanId != 0 || PersonelDosya.Yolu != null)
            {
                Title = "Duzenle";
                personelDurum = PersonelServisi.Get(IseBaslayanId);
            }
        }

        protected void SilmeyiOnayla(int IseBaslayanId)
        {
            ModalDialog.Open();

            personelDurum = PersonelDurumlari.FirstOrDefault(x => x.Id == IseBaslayanId);
        }

        protected void Sil()
        {
            if (personelDurum.Id == 0)
                return;
            PersonelServisi.Remove(personelDurum.Id);
            PersonelDosyaServisi.Remove(PersonelDosya.Id);
            personelDurum = new PersonelDurum();
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
            personelDurum = null;
            PersonelDosya = null;
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