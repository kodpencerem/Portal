﻿namespace VedasPortal.Models.ToplantiTakvimi
{
    public class ToplantiOdasi : Base.BaseEntity
    {
        public string Kod { get; set; }
        public string Adi { get; set; }
        public bool AktifPasif { get; set; }
        public string Aciklama { get; set; }
        public string Adres { get; set; }
        public int Kapasite { get; set; }
        public bool VideoKonferansMi { get; set; }
        public bool RezervDurumu { get; set; }
        public ToplantiMerkezi ToplantiMerkezi { get; set; }     
    }  
}