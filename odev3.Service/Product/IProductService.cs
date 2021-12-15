using System.Collections.Generic;
using odev3.Models.Pagination;
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
        public PagedResponse<List<ProductViewModel>> GetPaged(int pageNumber, int pageSize, List<ProductViewModel> products);
        public List<ProductViewModel> GetFilteredProducts(int maxPrice, int minPrice, List<ProductViewModel> products);

        public List<ProductViewModel> GetSortedProducts(string sortingParameter);
        public PagedResponse<List<ProductViewModel>> GetFPS(string sortingParameter, int maxPrice, int minPrice, int pageNumber, int pageSize);


    }
}