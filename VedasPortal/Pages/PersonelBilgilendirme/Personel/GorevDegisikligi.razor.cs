using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Entities.Models.PersonelDurumlari;
using VedasPortal.Entities.Models.User;
using VedasPortal.Repository.Interface;
using VedasPortal.Services.AuthServices;

namespace VedasPortal.Pages.PersonelBilgilendirme.Personel
{
    public class GorevDegisiklikModeli : ComponentBase
    {
        [Inject]
        protected IBaseRepository<PersonelDurum> PersonelServisi { get; set; }
        protected IEnumerable<PersonelDurum> GorevDegisiklikDurumlari;

        public ImageFile PersonelDosya { get; set; } = new ImageFile();

        protected override Task OnInitializedAsync()
        {
            GetUsers();
            TumKatilanlariGetir();
            return Task.CompletedTask;
        }

        protected IEnumerable<PersonelDurum> TumKatilanlariGetir()
        {
            GorevDegisiklikDurumlari = PersonelServisi.GetAll().AsQueryable().Include(s => s.ImageFile).ToList();
            return GorevDegisiklikDurumlari;
        }

        [Inject]
        public IManageUsersService _usersService { get; set; }

        // Mevcut kullanıcıları görüntülemek için koleksiyon
        public List<ApplicationUser> _allUsers = new List<ApplicationUser>();

        string strError = "";
        public void GetUsers()
        {
            // Tüm hata mesajlarını temizle
            strError = "";
            // Kullanıcıları tutmak için koleksiyon
            _allUsers = _usersService.GetAllUsers();
        }
    }
}
