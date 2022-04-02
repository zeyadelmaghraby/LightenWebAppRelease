using LightenWebApp.Models;
using LightenWebApp.Models.Authentication;
using LightenWebApp.Models.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LightenWebApp.Pages
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ProductModel : PageModel
    {
        private readonly ILogger<ProductModel> _logger;
        private readonly ApplicationDbContext _context;

        public ProductModel(ILogger<ProductModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {

        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                _context.Products.Add(Product);
                await _context.SaveChangesAsync();
            }
            catch
            {
                return RedirectToPage("./Error");
            }

            return RedirectToPage("./Index");
        }
    }
}