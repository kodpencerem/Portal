using System;
using System.Collections.Generic;
using VedasPortal.Entities.DTOs.Anket;

namespace VedasPortal.Repository.Interface.Anket
{
    public interface IAnketDTO
    {
        int AnketId { get; set; }
        string Adi { get; set; }
        string Aciklama { get; set; }
        string AnketSorusu { get; set; }
        int ToplamKatilim { get; set; }
        bool SecilenAnketMi { get; set; }
        int ToplamAlinanSure { get; set; }
        DateTime OlusturulmaTarihi { get; set; }
        List<AnketSecenekDTO> AnketSecenekleri { get; set; }
    }
}