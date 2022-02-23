using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VedasPortal.Data;
using VedasPortal.Models.Anket.DTO;
using VedasPortal.Utils.Anket.CustomValidation;

namespace VedasPortal.Models.Anket.ViewModels
{
    public class AnketEkleVm
    {

        #region Properties
        [Required(ErrorMessage = "Anket adı gereklidir!")]
        public string Adi { get; set; }

        [Required(ErrorMessage = "Açıklama gereklidir!")]
        public string Aciklama { get; set; }

        [Required(ErrorMessage = "Anket sorusu gereklidir!")]
        public string AnketSorusu { get; set; }

        public List<SelectListItem> AnketSecenekleri { get; set; } = new List<SelectListItem>() { };

        [RequiredNumberOfItems(RequiredNumberOfRecords = 2, ErrorMessage = "En az 2 seçenek gereklidir!")]
        public List<AnketSecenekDTO> AnketSecenekEkle { get; set; } = new List<AnketSecenekDTO>();

        public VedasDbContext Context { get; }
        public int MaxAnketSecenekId { get; set; }

        public bool SecilenAnketMi { get; set; }


        #endregion


        #region Methods

        public AnketDTO GenerateSurveyToSave()
        {
            return new AnketDTO()
            {
                Adi = Adi,
                Aciklama = Aciklama,
                AnketSorusu = AnketSorusu,
                SecilenAnketMi = SecilenAnketMi,
                ToplamKatilim = 0,
                ToplamAlinanSure = 0,
                OlusturulmaTarihi = DateTime.Now,
                AnketSecenekleri = AnketSecenekEkle
            };
        }
        public void AddSurveyOption(AnketSecenekDTO option, int maxId)
        {
            SelectListItem optionToAdd = new SelectListItem { Selected = false, Text = option.Aciklama, Value = maxId.ToString() };
            AnketSecenekleri.Add(optionToAdd);


        }

        public void RemoveSurveyOption(int optionId)
        {
            string description = AnketSecenekleri.FirstOrDefault(x => x.Value == optionId.ToString()).Text;

            AnketSecenekEkle.Remove(AnketSecenekEkle.FirstOrDefault(x => x.Aciklama == description));

            AnketSecenekleri.Remove(AnketSecenekleri.FirstOrDefault(x => x.Value == optionId.ToString()));


        }

        public int GetMaxId()
        {
            var maxId = AnketSecenekleri.Count == 0 ? 0 : int.Parse(AnketSecenekleri.OrderByDescending(x => x.Value).FirstOrDefault().Value);
            maxId = maxId += 1;
            return maxId;
        }
        #endregion


    }
}
