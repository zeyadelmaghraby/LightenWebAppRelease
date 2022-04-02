using System.ComponentModel.DataAnnotations;

namespace LightenWebApp.Models.Category
{
    public class Category : BaseModel
    {
        [Required]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category Name is required")]
        public string CategoryName { get; set; }      

        public ICollection<Product.Product> Products { get; set; }

    }
}
