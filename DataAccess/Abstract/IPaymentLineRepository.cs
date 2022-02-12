using System.Collections.Generic;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IPaymentLineRepository
    {
        public List<PaymentLine> GetAllPaymentLines();
        public List<PaymentLine> GetPaymentLinesByPaymentId(int paymentId);
        public PaymentLine GetPaymentLineById(int paymentLineId);
        public void AddPaymentLine(PaymentLine paymentLine);
    }
}