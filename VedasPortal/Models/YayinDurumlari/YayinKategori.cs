using VedasPortal.Models.Base;

namespace VedasPortal.Models.YayinDurumlari
{
    public class YayinKategori : BaseEntity
    {
        public string YayinKategoriAdi { get; set; }

        public bool YayinKategoriDurumu { get; set; }
    }
}
