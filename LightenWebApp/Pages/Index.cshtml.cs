using LightenWebApp.Models;
using LightenWebApp.Models.Authentication;
using LightenWebApp.Models.Product;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace LightenWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public IndexModel(UserManager<ApplicationUser> userManager, ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public IList<Product> Product { get; set; }

        [BindProperty]
        public string Username { get; set; }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                Username = User.FindFirstValue(ClaimTypes.Name); // will give the user's userName

                Product = await _context.Products.ToListAsync();

                #region HARD CODED RESPOSE

                //Product = new List<Product>()
                //{
                //    new Product
                //    {
                //        ProductName = "LG OLED R",
                //        ProductDescription = "The world's first and only rollable TV has arrived.",
                //        ProductPrice = 10000
                //    },
                //    new Product
                //    {
                //        ProductName = "LG OLED",
                //        ProductDescription = "The world's first and only rollable TV has arrived.",
                //        ProductPrice = 10500
                //    },
                //    new Product
                //    {
                //        ProductName = "LG OLED 8K TV 88 Inch",
                //        ProductDescription = "The world's first and only rollable TV has arrived.",
                //        ProductPrice = 50000
                //    }
                //};

                #endregion
            }
            catch
            {
                return RedirectToPage("./Error");
            }

            return null;
        }
    }
}