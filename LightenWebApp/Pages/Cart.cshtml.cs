using LightenWebApp.Models;
using LightenWebApp.Models.Authentication;
using LightenWebApp.Models.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace LightenWebApp.Pages
{
    [Authorize]
    public class CartModel : PageModel
    {
        private readonly ILogger<CartModel> _logger;
        private readonly ApplicationDbContext _context;


        public CartModel(ILogger<CartModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public IList<Product> CartList { get; set; }

        [BindProperty]
        public string Username { get; set; }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                CartList = new List<Product>();
                Username = User.FindFirstValue(ClaimTypes.Name);
                if (Request.Cookies[Username] != null)
                {
                    var cookieValue = Request.Cookies[Username].Split('/');
                    if (cookieValue.Length > 0)
                    {
                        foreach (var item in cookieValue)
                        {
                            Product product = await _context.Products.Where(a => a.ProductId == item).SingleOrDefaultAsync();
                            if (product != null)
                                CartList.Add(product);
                        }
                    }
                }

                //CartList = new List<Product>()
                //{
                //    new Product
                //    {
                //        ProductName = "LG OLED R",
                //        ProductDescription = "The world's first and only rollable TV has arrived.",
                //        ProductPrice = 10000,
                //        RegCustDiscount = 20,
                //        TwoPiecesDiscount = true,
                //        TwoPiecesDiscountPercentage = 50
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
            }
            catch
            {
                return RedirectToPage("./Error");
            }

            return null;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            return RedirectToPage("./Index");
        }
    }
}