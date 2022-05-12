using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using VedasPortal.Entities.Models.User;

namespace VedasPortal.Pages.Auth
{
    [Authorize]
    public class SignOutModel : PageModel
    {
        private readonly SignInManager<Kullanici> signinManager;

        public SignOutModel(SignInManager<Kullanici> signInManager)
        {
            signinManager = signInManager;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            await signinManager.SignOutAsync();
            return RedirectToPage("/Auth/SignIn");
        }
    }
}
