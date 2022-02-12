using System.Collections.Generic;
using Business.Response;
using Entities.Concrete;
using Entities.Dto;

namespace Business.Abstract
{
    public interface IPaymentService:IService<Payment,PaymentDto>
    {
        IResponse<List<PaymentDto>> GetPaymentByPolicyId(int policyId);
        IResponse AddPayment(PaymentDto paymentDto);
    }
}