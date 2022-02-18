namespace VedasPortal.Models
{

    public class Rehber : Base.BaseEntity
    {
        public Dosya.Dosya ProfilResmi { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Unvani { get; set; }
        public long TelefonNo { get; set; }
		public string Email { get; set; }

	}
}
