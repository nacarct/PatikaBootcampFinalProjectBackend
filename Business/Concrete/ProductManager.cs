using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Mapper;
using Business.Response;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class ProductManager:IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IResponse<List<ProductDto>> GetAll()
        {
            try
            {
                var result = _productRepository.GetAllProducts();
                return new Response<List<ProductDto>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = ObjectMapper.Mapper.Map<List<ProductDto>>(result)
                };
            }
            catch (Exception e)
            {
                return new Response<List<ProductDto>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error : {e.Message}",
                    Data = null
                };
            }
        }

        public IResponse AddProduct(ProductDto productDto)
        {
            try
            {
                _productRepository.AddProduct(ObjectMapper.Mapper.Map<Product>(productDto));

                return new Response.Response
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = null
                };
            }
            catch (Exception e)
            {
                return new Response.Response
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error : {e.Message}",
                    Data = null
                };
            }
        }
    }
}