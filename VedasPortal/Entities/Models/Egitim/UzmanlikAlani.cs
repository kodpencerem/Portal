using System.Collections.Generic;
using VedasPortal.Entities.Models.User;

namespace VedasPortal.Entities.Models.Egitim
{
    public class UzmanlikAlani : Base.BaseEntity
    {
        public string Adi { get; set; }
        public int UzmanlikSeviyesi { get; set; }
    }
}
