using VedasPortal.Repository.Interface.Anket;

namespace VedasPortal.Entities.DTOs.Anket
{
    public class AnketSecenekDTO : IAnketSecenekDTO
    {
        public int AnketSecenekId { get; set; }
        public int ApplicationUserId { get; set; }
        public int Fk_AnketId { get; set; }
        public string Aciklama { get; set; }
        public string Resim { get; set; }
        public int ToplamKatilim { get; set; }
    }
}