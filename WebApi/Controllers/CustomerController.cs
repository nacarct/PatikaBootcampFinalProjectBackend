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
    public class CustomerController : ApiBaseController<ICustomerService,Customer,CustomerDto>
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService genericService) : base(genericService)
        {
            _customerService = genericService;
        }

        [HttpPost("AddCustomer")]
        public IResponse AddCustomer(CustomerDto customerDto)
        {
            return _customerService.AddCustomer(customerDto);
        }

        [HttpPost("UpdateCustomer")]
        public IResponse UpdateCustomer(Customer customer)
        {
            return _customerService.UpdateCustomer(customer);
        }

        [HttpGet("GetByTcKn")]
        public IResponse GetByTcKn(string tcKn)
        {
            return _customerService.GetByTcKn(tcKn);
        }
    }
}
