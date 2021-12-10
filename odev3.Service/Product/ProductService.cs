using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using odev3.DB.Models;
using odev3.Models.Product;

namespace odev3.Service.Product
{
    public class ProductService : IProductService
    {
        private readonly IMapper mapper;

        public ProductService(IMapper _mapper)
        {
            mapper = _mapper;
        }

        public bool Insert(odev3.DB.Models.Product newProduct)
        {
            bool result = false;
            using (var srv = new ProjeContext())
            {
                srv.Products.Add(newProduct);
                newProduct.IsActive = true;
                newProduct.IsDeleted = false;
                srv.SaveChanges();
                result = true;
            }
            return result;
        }

        public ProductListModel<ProductViewModel> Get()
        {
            var result = new ProductListModel<ProductViewModel>();
            using (var srv = new ProjeContext())
            {
                var data = srv.Products.Where(
                    p => p.IsActive && !p.IsDeleted).OrderBy(p => p.Id);
                result.productList = mapper.Map<List<ProductViewModel>>(data);

            }
            return result;
        }


    }
}