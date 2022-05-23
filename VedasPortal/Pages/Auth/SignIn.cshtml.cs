using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using VedasPortal.Entities.Models.User;

namespace VedasPortal.Pages.Auth
{
    public class SignInModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> signInManager;

        [BindProperty]
        public SignIn SignInData { get; set; }

        public SignInModel(SignInManager<ApplicationUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                  SignInData.UserName, SignInData.Password, SignInData.RememberMe, false);

                if (result.Succeeded)
                    return Redirect("/");
                else
                    ModelState.AddModelError("", "Yanlýþ Kullanýcý Adý Veya Þifre");
            }

            return Page();
        }
    }
}
