using LightenWebApp.Models.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LightenWebApp.Pages
{
    [AllowAnonymous]
    public class LogoutPageModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LogoutPageModel> _logger;


        public LogoutPageModel(SignInManager<ApplicationUser> signInManager, ILogger<LogoutPageModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _signInManager.SignOutAsync();
            //Response.Cookies.Delete("Username");
            _logger.LogInformation("User logged out.");
            return RedirectToPage("/Index");
        }
    }
}