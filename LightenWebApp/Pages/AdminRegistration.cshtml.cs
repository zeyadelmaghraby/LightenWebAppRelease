using LightenWebApp.Models;
using LightenWebApp.Models.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LightenWebApp.Pages
{
    [Authorize(Roles = UserRoles.Admin)]
    public class AdminRegistrationModel : PageModel
    {
        private readonly ILogger<AdminRegistrationModel> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;

        public AdminRegistrationModel(ILogger<AdminRegistrationModel> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _logger = logger;
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
            _context = context;
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
            
            var userExists = await userManager.FindByNameAsync(Register.Username);
            if (userExists != null)
                return Page();


            ApplicationUser user = new ApplicationUser()
            {
                Email = Register.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = Register.Username,
                PhoneNumber = Register.PhoneNumber,
                FullAddress = Register.FullAddress,
                Birthdate = Register.Birthdate
            };

            var result = await userManager.CreateAsync(user, Register.Password);

            if (!result.Succeeded)
                return RedirectToPage("./Error");

            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await roleManager.RoleExistsAsync(UserRoles.User))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if (await roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await userManager.AddToRoleAsync(user, UserRoles.Admin);
            }

            return RedirectToPage("./Index");
        }
    }
}