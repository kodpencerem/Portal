using VedasPortal.Models.HaberDuyuru;

namespace VedasPortal
{
    public static class StringExtensions
    {
        public static string TextHaberDuyuru(this HaberDuyuruKategori kategori)
        {
            switch (kategori)
            {
                case HaberDuyuruKategori.Duyuru:
                    return "Duyuru";
                case HaberDuyuruKategori.Haber:
                    return "Haber";
                default:
                    return "";
            }
        }
    }
}
