using LightenWebApp.Models;
using LightenWebApp.Models.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LightenWebApp.Pages
{
    [AllowAnonymous]
    public class RegistrationModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;

        public RegistrationModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILogger<RegisterModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        public void OnGet()
        {

        }

        [BindProperty]
        public RegisterModel Register { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ApplicationUser user = new ApplicationUser()
            {
                Email = Register.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = Register.Username,
                PhoneNumber = Register.PhoneNumber,
                FullAddress = Register.FullAddress,
                Birthdate = Register.Birthdate
            };
            
            var result = await _userManager.CreateAsync(user, Register.Password);

            if (result.Succeeded)
            {
                _logger.LogInformation("User created a new account with password.");
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToPage("./Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return RedirectToPage("./Error");

        }
    }
}