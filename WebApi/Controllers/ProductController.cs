using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Response;
using Entities.Concrete;
using Entities.Dto;
using WebApi.ControllerBase;

namespace WebApi.Controllers
{
    public class ProductController : ApiBaseController<IProductService,Product,ProductDto>
    {
        private readonly IProductService _productService;

        public ProductController(IProductService genericService) : base(genericService)
        {
            _productService = genericService;
        }

        [HttpPost("AddProduct")]
        public IResponse AddProduct(ProductDto productDto)
        {
            return _productService.AddProduct(productDto);
        }
    }
}
