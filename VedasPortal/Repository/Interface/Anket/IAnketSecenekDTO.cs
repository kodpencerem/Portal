namespace VedasPortal.Repository.Interface.Anket
{
    public interface IAnketSecenekDTO
    {
        int AnketSecenekId { get; set; }
        public int ApplicationUserId { get; set; }
        int Fk_AnketId { get; set; }
        string Aciklama { get; set; }
        string Resim { get; set; }
        int ToplamKatilim { get; set; }
    }
}