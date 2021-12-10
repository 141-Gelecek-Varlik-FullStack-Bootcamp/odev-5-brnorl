using System.Collections.Generic;

namespace odev3.Models.Product
{
    public class ProductListModel<T>
    {
        public List<T> productList { get; set; }
    }
}
