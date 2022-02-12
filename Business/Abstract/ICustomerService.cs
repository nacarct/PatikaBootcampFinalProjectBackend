using Business.Response;
using Entities.Concrete;
using Entities.Dto;

namespace Business.Abstract
{
    public interface ICustomerService:IService<Customer,CustomerDto>
    {
        IResponse AddCustomer(CustomerDto customerDto);
        IResponse UpdateCustomer(Customer customer);
        IResponse GetByTcKn(string tcKn);
    }
}