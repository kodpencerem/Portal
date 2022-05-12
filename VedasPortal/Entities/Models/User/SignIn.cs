using System.ComponentModel.DataAnnotations;

namespace VedasPortal.Entities.Models.User
{
    public class SignIn
    {
        [Required]
        [Display(Name = "Kullanıcı Adı:")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Şifre: ")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}
