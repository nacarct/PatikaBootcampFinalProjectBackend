using System.Collections.Generic;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IProductRepository
    {
        public List<Product> GetAllProducts();
        public void AddProduct(Product product);
    }
}