using System;
using System.Collections.Generic;
using VedasPortal.Entities.Models.User;
using VedasPortal.Repository.Interface.Anket;

namespace VedasPortal.Entities.DTOs.Anket
{
    public class AnketDTO : IAnketDTO
    {
        public int AnketId { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public string AnketSorusu { get; set; }
        public int ToplamKatilim { get; set; }
        public bool SecilenAnketMi { get; set; }
        public int ToplamAlinanSure { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }
        public List<AnketSecenekDTO> AnketSecenekleri { get; set; }
        public string ApplicationUserId { get ; set; }
    }
}
