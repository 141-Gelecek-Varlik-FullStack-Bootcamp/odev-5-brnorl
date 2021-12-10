using odev3.Models.Product;

namespace odev3.Service.Product
{
    public interface IProductService
    {
        public bool Insert(odev3.DB.Models.Product newProduct);
        public ProductListModel<ProductViewModel> Get();
    }
}