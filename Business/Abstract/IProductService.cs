using System.Collections.Generic;
using Business.Response;
using Entities.Concrete;
using Entities.Dto;

namespace Business.Abstract
{
    public interface IProductService:IService<Product,ProductDto>
    {
        IResponse AddProduct(ProductDto productDto);
    }
}