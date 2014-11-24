using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTrainningSample.Models
{
    public class ProductModel
    {
        public ProductModel()
        {
            ProductList = new List<Product>();
            ProductTypeList = new List<ProductType>();
            ProductDetail = new Product();
        }
        public virtual IList<Product> ProductList { get; set; }
        public virtual Product ProductDetail { get; set; }
        public virtual IList<ProductType> ProductTypeList { get; set; }
    }
}