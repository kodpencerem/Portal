﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VedasPortal.Models.Base;

namespace VedasPortal.Models.Video
{
    public class Video: BaseEntity
    {
        public virtual Dosya.Dosya Dosya { get; set; }
        public string Baslik { get; set; }
        public string  AltBaslik { get; set; }

        public string Aciklama { get; set; }

        public long Uzunluk { get; set; }

        public bool AktifPasif { get; set; }

        public bool IzlenmeDurumu { get; set; }

        [DataType(DataType.Text)]
        public VideoKategori Kategori { get; set; }

        [DataType(DataType.Text)]
        public Birimler Birimler { get; set; }

        [NotMapped]
        public List<string> Yorumlar { get; set; } = new List<string>();

        public ICollection<HaberDuyuru.HaberDuyuru> HaberDuyuru { get; set; }
    }

    public enum VideoKategori
    {
        Genel,
        Egitim,
        Roportaj,
        Belgesel
    }
}
