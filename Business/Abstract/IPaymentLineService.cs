using System.Collections.Generic;
using Business.Response;
using Entities.Concrete;
using Entities.Dto;

namespace Business.Abstract
{
    public interface IPaymentLineService:IService<PaymentLine,PaymentLineDto>
    {
        IResponse<List<PaymentLineDto>> GetPaymentLinesByPaymentId(int paymentId);
        IResponse<PaymentLineDto> GetPaymentLineById(int paymentLineId);
        IResponse AddPaymentLine(PaymentLineDto paymentLine);
    }
}