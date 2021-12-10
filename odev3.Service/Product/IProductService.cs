using odev3.Models.Product;

namespace odev3.Service.Product
{
    //Product Service için interface
    public interface IProductService
    {
        public bool Insert(odev3.DB.Models.Product newProduct);
        public ProductListModel<ProductViewModel> Get();
        public bool Update(UpdateProductModel updatedProduct, int id);
        public bool Delete(int id);
    }
}