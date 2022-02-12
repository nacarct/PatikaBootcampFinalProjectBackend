using System.Collections.Generic;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICustomerRepository
    {
        public List<Customer> GetAllCustomers();
        public Customer GetByTcKn(string tcKn);
        public void AddCustomer(Customer customer);
        public void UpdateCustomer(Customer customer);
    }
}