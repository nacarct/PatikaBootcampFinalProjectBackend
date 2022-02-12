using System.Collections.Generic;
using Business.Response;
using Entities.Concrete;
using Entities.Dto;

namespace Business.Abstract
{
    public interface IPolicyService:IService<Policy,PolicyDto>
    {
        IResponse<List<PolicyViewDto>> GetAllPolicyView();
        IResponse AddPolicy(PolicyDto policyDto);
    }
}