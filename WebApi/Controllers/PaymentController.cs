using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Response;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using WebApi.ControllerBase;

namespace WebApi.Controllers
{
    public class PaymentController : ApiBaseController<IPaymentService,Payment,PaymentDto>
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService genericService) : base(genericService)
        {
            _paymentService = genericService;
        }

        [HttpGet("GetPaymentByPolicyId")]
        public IResponse<List<PaymentDto>> GetPaymentByPolicyId(int policyId)
        {
            return _paymentService.GetPaymentByPolicyId(policyId);
        }

        [HttpPost("AddPayment")]
        public IResponse AddPayment(PaymentDto paymentDto)
        {
            return _paymentService.AddPayment(paymentDto);
        }
    }
}
