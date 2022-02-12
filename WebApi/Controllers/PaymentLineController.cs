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
    public class PaymentLineController : ApiBaseController<IPaymentLineService,PaymentLine,PaymentLineDto>
    {
        private readonly IPaymentLineService _paymentLineService;

        public PaymentLineController(IPaymentLineService genericService) : base(genericService)
        {
            _paymentLineService = genericService;
        }

        [HttpGet("GetPaymentLinesByPaymentId")]
        public IResponse<List<PaymentLineDto>> GetPaymentLinesByPaymentId(int paymentId)
        {
            return _paymentLineService.GetPaymentLinesByPaymentId(paymentId);
        }

        [HttpGet("GetPaymentLineById")]
        public IResponse<PaymentLineDto> GetPaymentLineById(int paymentLineId)
        {
            return _paymentLineService.GetPaymentLineById(paymentLineId);
        }

        [HttpPost("AddPaymentLine")]
        public IResponse AddPaymentLine(PaymentLineDto paymentLineDto)
        {
            return _paymentLineService.AddPaymentLine(paymentLineDto);
        }
    }
}
