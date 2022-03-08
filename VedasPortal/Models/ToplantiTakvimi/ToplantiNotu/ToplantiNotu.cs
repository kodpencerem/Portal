﻿using System.ComponentModel.DataAnnotations;
using VedasPortal.Models.Video;

namespace VedasPortal.Models.ToplantiTakvimi.ToplantiNotu
{
    public class ToplantiNotu : Base.BaseEntity
    {
        public string Baslik { get; set; }
        public string AltBaslik { get; set; }
        public string Konu { get; set; }
        public string Aciklama { get; set; }
        public bool AktifPasif { get; set; }

        [DataType(DataType.Text)]
        public Birimler Birimler { get; set; }
        public ToplantiMerkezi ToplantiMerkezi { get; set; }
        public Dosya.Dosya GetDosya { get; set; }
    }
}