using System.ComponentModel.DataAnnotations;

namespace odev3.Models.Product
{
    public class UpdateProductModel : IProductModel
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Display Name is required.")]
        public string DisplayName { get; set; }
        [Required(ErrorMessage = "Price is required.")]
        public decimal Price { get; set; }
    }
}