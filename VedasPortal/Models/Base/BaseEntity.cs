using System;
using System.ComponentModel.DataAnnotations;

namespace VedasPortal.Models.Base
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime KayitTarihi { get; set; } = DateTime.Now;
        public string KaydedenKullanici { get; set; }
        public DateTime? DuzenlemeTarihi { get; set; }
        public string DuzenleyenKullanici { get; set; }
    }
}
