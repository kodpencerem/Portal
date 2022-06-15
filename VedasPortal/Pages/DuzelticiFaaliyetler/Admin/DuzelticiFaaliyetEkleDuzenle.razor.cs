using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Components.ShowModalComponent;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Entities.Models.DuzelticiFaaliyet;
using VedasPortal.Enums;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.DuzelticiFaaliyetler
{
    public class DuzelticiFaaliyetModeli : ComponentBase
    {

        [Inject]
        public IBaseRepository<DuzelticiFaaliyet> DuzelticiFaaliyetlerServisi { get; set; }

        [Inject]
        public IBaseRepository<ImageFile> DuzelticiFaaliyetDosya { get; set; }

        [Parameter]
        public int DFaaliyetId { get; set; }

        protected string Title = "Ekle";
        public DuzelticiFaaliyet duzelticiFaaliyet = new();

        public ImageFile DFaaliyetDosya = new();

        protected IEnumerable<DuzelticiFaaliyet> DuzelticiFaaliyetler { get; set; }

        protected IEnumerable<DuzelticiFaaliyet> TumFaaliyetleriGetir()
        {
            DuzelticiFaaliyetler = DuzelticiFaaliyetlerServisi.GetAll().AsQueryable().Include(s => s.Dosya).ToList();
            return DuzelticiFaaliyetler;

        }
        public Dictionary<DuzelticiFaaliyetKategori, string> Kategoriler { get; set; }
        protected void TumKategorileriGetir()
        {
            var list = new Dictionary<DuzelticiFaaliyetKategori, string>();
            foreach (DuzelticiFaaliyetKategori item in Enum.GetValues(typeof(DuzelticiFaaliyetKategori)))
            {
                list.Add(item, item.TextDuzelticiFaaliyet());
            }
            Kategoriler = list;
        }

        protected void DuzelticiFaaliyetKaydet()
        {
            DuzelticiFaaliyetlerServisi.Add(duzelticiFaaliyet);

            var fileName = SaveFileToUploaded.FileName.Split(".");
            var filePath = SaveFileToUploaded.ImageUploadedPath;
            var dosya = new ImageFile()
            {
                Adi = fileName[0],
                Yolu = filePath,
                Uzanti = fileName[1],
                Kategori = DosyaKategori.Jpg,
                AktifPasif = true,
                DuzelticiFaaliyetId = duzelticiFaaliyet.Id,

            };
            DuzelticiFaaliyetDosya.Add(dosya);
            TumFaaliyetleriGetir();
            var aTimer = new System.Timers.Timer();
            aTimer.Interval = 10;
            duzelticiFaaliyet = new DuzelticiFaaliyet();          
        }
        protected override void OnParametersSet()
        {
            if (DFaaliyetId != 0 || DFaaliyetDosya.Yolu!=null)
            {
                Title = "Duzenle";
                duzelticiFaaliyet = DuzelticiFaaliyetlerServisi.Get(DFaaliyetId);               
            }
        }



        protected void SilmeyiOnayla(int dFaaliyetId)
        {
            ModalDialog.Open();
            duzelticiFaaliyet = DuzelticiFaaliyetler.FirstOrDefault(x => x.Id == dFaaliyetId);
        }
        public ModalComponent ModalDialog { get; set; }
        protected string DialogGorunur { get; set; } = "none";

        protected void Sil()
        {
            if (duzelticiFaaliyet.Id == 0)
                return;

            DuzelticiFaaliyetDosya.Remove(DFaaliyetDosya.Id);
            DuzelticiFaaliyetlerServisi.Remove(duzelticiFaaliyet.Id);
            duzelticiFaaliyet = new DuzelticiFaaliyet();
            TumFaaliyetleriGetir();
        }
        protected override Task OnInitializedAsync()
        {
            TumFaaliyetleriGetir();
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
