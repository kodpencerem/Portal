using VedasPortal.Models.Anket.Contracts;

namespace VedasPortal.Models.Anket.DTO
{
    public class AnketSecenekDTO : IAnketSecenekDTO
    {
        public int AnketSecenekId { get; set; }
        
        public int Fk_AnketId { get; set; }
        public string Aciklama { get; set; }
        public string Resim { get; set; }
        public int ToplamKatilim { get; set; }


    }
}
