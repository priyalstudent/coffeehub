using CoffeeHub.IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace CoffeeHub.IdentityServer.Pages.Account.Register
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IndexModel(UserManager<ApplicationUser> userManager,
                          SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public List<string> Errors { get; set; } = new();

        public class InputModel
        {
            [Required]
            public string Username { get; set; }

            [Required, EmailAddress]
            public string Email { get; set; }

            [Required]
            public string Password { get; set; }

            [Required, Compare("Password")]
            public string ConfirmPassword { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Errors.Add("Invalid input");
                    return Page();
                }

                var user = new ApplicationUser
                {
                    UserName = Input.Username,
                    Email = Input.Email,
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(user, Input.Password);

                if (!result.Succeeded)
                {
                    Errors.AddRange(result.Errors.Select(e => e.Description));
                    return Page();
                }

                await _signInManager.SignInAsync(user, isPersistent: false);
                return Redirect("/");
            }
            catch (Exception ex)
            {
                Console.WriteLine("REGISTER ERROR: " + ex);
                Errors.Add(ex.Message);
                return Page();
            }
        }

    }
}
