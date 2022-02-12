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
    public class CustomerManager:ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerManager(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IResponse<List<CustomerDto>> GetAll()
        {
            try
            {
                var result = _customerRepository.GetAllCustomers();

                return new Response<List<CustomerDto>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = $"Success",
                    Data = ObjectMapper.Mapper.Map<List<CustomerDto>>(result)
                };
            }
            catch (Exception e)
            {
                return new Response<List<CustomerDto>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error : {e.Message}",
                    Data = null
                };
            }
        }

        public IResponse AddCustomer(CustomerDto customerDto)
        {
            try
            {
                _customerRepository.AddCustomer(ObjectMapper.Mapper.Map<Customer>(customerDto));

                return new Response.Response
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = $"Success",
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

        public IResponse UpdateCustomer(Customer customer)
        {
            try
            {
                _customerRepository.UpdateCustomer(customer);

                return new Response.Response
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = $"Success",
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

        public IResponse GetByTcKn(string tcKn)
        {
            try
            {
                var result  = _customerRepository.GetByTcKn(tcKn);

                return new Response.Response
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = $"Success",
                    Data = result
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