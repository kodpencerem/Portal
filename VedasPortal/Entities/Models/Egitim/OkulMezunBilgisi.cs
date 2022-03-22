using System;
using System.ComponentModel.DataAnnotations;

namespace VedasPortal.Entities.Models.Egitim
{
    public class OkulMezunBilgisi : Base.BaseEntity
    {
        public string OkulAdi { get; set; }
        public DateTime BaslamaTarihi { get; set; }
        public DateTime MezuniyetTarihi { get; set; }
        
        [DataType(DataType.Text)]
        public EgitimDurumu EgitimDurumu { get; set; }
    }
    public enum EgitimDurumu
    {
        IlkOkul,
        OrtaOkul,
        Lise,
        OnLisans,
        Lisans,
        YuksekLisans,
        Doktora,
        Master
    }
}
