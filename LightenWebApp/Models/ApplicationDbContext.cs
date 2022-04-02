using LightenWebApp.Models.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LightenWebApp.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Category.Category> Categories { get; set; }
        public DbSet<Product.Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // configures one-to-many relationship
            builder.Entity<Product.Product>()
            .HasOne<Category.Category>(s => s.Category)
            .WithMany(g => g.Products)
            .HasForeignKey(s => s.CurrentCategoryId);

        }
    }
}
