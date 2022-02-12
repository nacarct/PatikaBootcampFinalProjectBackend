using AutoMapper;
using Entities.Concrete;
using Entities.Dto;

namespace Business.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Policy, PolicyDto>().ReverseMap();
            CreateMap<PolicyView, PolicyViewDto>();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Payment, PaymentDto>().ReverseMap();
            CreateMap<PaymentLine, PaymentLineDto>().ReverseMap();
        }
    }
}