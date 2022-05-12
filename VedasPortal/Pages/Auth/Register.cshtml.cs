using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using VedasPortal.Entities.Models.User;

namespace VedasPortal.Pages.Auth
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<Kullanici> userManager;
        private readonly RoleManager<AppIdentityRole> roleManager;

        [BindProperty]
        public Register RegisterData { get; set; }

        public RegisterModel(UserManager<Kullanici> userManager, RoleManager<AppIdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                if (!await roleManager.RoleExistsAsync("Manager"))
                {
                    AppIdentityRole role = new AppIdentityRole();
                    role.Name = "Manager";
                    role.Description = "Can perform CRUD operations";
                    IdentityResult roleResult = await roleManager.CreateAsync(role);
                }

                var user = new Kullanici();
                user.UserName = RegisterData.UserName;
                user.Email = RegisterData.Email;
                

                var result = await userManager.CreateAsync(user, RegisterData.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Manager");
                    return RedirectToPage("/Auth/SignIn");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid User Data");
                }
            }

            return Page();
        }
    }
}
