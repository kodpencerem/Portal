using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VedasPortal.Entities.Models.Base
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime KayitTarihi { get; set; } = DateTime.Now;
        public DateTime? DuzenlemeTarihi { get; set; }
        public DateTime? SilmeTarihi { get; set; }
        public string KaydedenKullanici { get; set; }
        public string DuzenleyenKullanici { get; set; }
        public string SilenKullanici { get; set; }
    }
}