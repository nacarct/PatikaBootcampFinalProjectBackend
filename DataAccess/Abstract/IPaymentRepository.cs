using System.Collections.Generic;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IPaymentRepository
    {
        public List<Payment> GetAllPayments();
        public Payment GetPaymentByPolicyId(int policyId);
        public void AddPayment(Payment payment);
    }
}