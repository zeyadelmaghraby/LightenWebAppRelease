using LightenWebApp.Models;
using LightenWebApp.Models.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace LightenWebApp.Pages
{
    public class ProductListingModel : PageModel
    {
        private readonly ILogger<ProductListingModel> _logger;
        private readonly ApplicationDbContext _context;


        public ProductListingModel(ILogger<ProductListingModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public IList<Product> ProductList { get; set; }

        [BindProperty]
        public string Username { get; set; }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                Username = User.FindFirstValue(ClaimTypes.Name); // will give the user's userName

                ProductList = await _context.Products.ToListAsync();

                #region HardCodedResponse

                //ProductList = new List<Product>()
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