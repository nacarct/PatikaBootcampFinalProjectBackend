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
    public class PolicyController : ApiBaseController<IPolicyService,Policy,PolicyDto>
    {
        private readonly IPolicyService _policyService;

        public PolicyController(IPolicyService genericService) : base(genericService)
        {
            _policyService = genericService;
        }

        [HttpGet("GetAllPolicyView")]
        public IResponse<List<PolicyViewDto>> GetAllPolicyView()
        {
            return _policyService.GetAllPolicyView();
        }

        [HttpPost("AddPolicy")]
        public IResponse AddPolicy(PolicyDto policyDto)
        {
            return _policyService.AddPolicy(policyDto);
        }
    }
}
