namespace VedasPortal.Models.Anket.Contracts
{
    public interface IAnketSecenekDTO 
    {
        int AnketSecenekId { get; set; }
        int Fk_AnketId { get; set; }
        string Aciklama { get; set; }
        string Resim { get; set; }
        int ToplamKatilim { get; set; }
    }
}