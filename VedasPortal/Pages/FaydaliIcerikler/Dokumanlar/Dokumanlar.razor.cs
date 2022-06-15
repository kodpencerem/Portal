﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Repository.Interface;
using VedasPortal.Services.FileUploadDownload;
using VedasPortal.Services.Pdf;

namespace VedasPortal.Pages.FaydaliIcerikler.Dokumanlar
{
    public class DosyaModeli : ComponentBase
    {
        [Inject]
        protected IBaseRepository<Dosya> Dokuman { get; set; }
        protected IEnumerable<Dosya> Dokumanlar { get; set; } = new List<Dosya>();    

        public string SearchText = "";

        public List<Dosya> FilteredDokuman => Dokumanlar.Where(
             x => x.Adi.ToLower().Contains(SearchText.ToLower())
            ).ToList();

        protected override Task OnInitializedAsync()
        {
            fileClass.Files = fileService.GetAllPDFs();
            TumDosyalariGetir();
            return Task.CompletedTask;
        }

        protected IEnumerable<Dosya>TumDosyalariGetir()
        {
            Dokumanlar = Dokuman.GetAll();
            return Dokumanlar;
        }

        public Dosya fileClass = new Dosya();
        public string pdfName = "";

        [Inject]
        private IFileService fileService { get; set; }

        public void ShowOnCurrentPage(int fileId)
        {
            pdfName = string.Concat(fileClass.Files.SingleOrDefault(x => x.FileId == fileId)?.Adi, ".",
                fileClass.Files.SingleOrDefault(x => x.FileId == fileId)?.Uzanti);
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
