using VedasPortal.Entities.Models.User;

namespace VedasPortal.Entities.Models.Anket
{
    public class AnketUser : Base.BaseEntity
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int? AnketId { get; set; }
        public Anket Anket { get; set; }
    }
}
