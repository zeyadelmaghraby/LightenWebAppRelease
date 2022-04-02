using System.ComponentModel.DataAnnotations;

namespace LightenWebApp.Models.Product
{
    public class Product : BaseModel
    {
        [Required]
        public string ProductId { get; set; } = Guid.NewGuid().ToString();

        [Required(ErrorMessage = "Product Name is required")]
        public string ProductName { get; set; }

        public string ProductDescription { get; set; }
        
        [Required(ErrorMessage = "Product Price is required")]
        public decimal ProductPrice { get; set; }

        public int CurrentCategoryId { get; set; }
        public Category.Category Category { get; set; }

        public int? RegCustDiscount { get; set; }
        public bool TwoPiecesDiscount { get; set; }
        public int TwoPiecesDiscountPercentage { get; set; }
    }
}