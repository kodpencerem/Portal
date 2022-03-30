namespace VedasPortal.Entities.Models.Kanban
{
    public class GorevSecenek : Base.BaseEntity
    {
        public string GorevAdi { get; set; }
        public GorevOncelligi Oncellik { get; set; }
    }

    public enum GorevOncelligi
    {
        Yuksek,
        Orta,
        Dusuk
    }
}
