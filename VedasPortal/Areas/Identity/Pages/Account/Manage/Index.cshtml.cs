﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using VedasPortal.Entities.Models.User;

namespace VedasPortal.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Telefon No")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Adınız")]
            public string FirstName { get; set; }

            [Display(Name = "Soyadınız")]
            public string LastName { get; set; }

            public string TcKn { get; set; }

            [Display(Name = "Nick Adı")]
            public string NickName { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var applicationUser = await _userManager.GetUserAsync(User);

            Username = applicationUser.UserName;

            Input = new InputModel
            {
                PhoneNumber = applicationUser.PhoneNumber,
                FirstName = applicationUser.FirstName,
                LastName = applicationUser.LastName
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            user.FirstName = Input.FirstName;
            user.LastName = Input.LastName;

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                StatusMessage = "Unexpected error when trying to update records.";
                return RedirectToPage();
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
