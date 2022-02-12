using System;
using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.Mapper;
using Business.Response;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class PolicyManager:IPolicyService
    {
        private readonly IPolicyRepository _policyRepository;

        public PolicyManager(IPolicyRepository policyRepository)
        {
            _policyRepository = policyRepository;
        }

        public IResponse AddPolicy(PolicyDto policyDto)
        {
            try
            {
                var policyNo = _policyRepository.AddPolicy(ObjectMapper.Mapper.Map<Policy>(policyDto));

                var result = _policyRepository.GetAllPolicy().FirstOrDefault(p => p.PolicyNo == policyNo);

                return new Response.Response
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = result
                };
            }
            catch (Exception e)
            {
                return new Response.Response
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error : {e.Message}",
                    Data = null
                };
            }
        }

        public IResponse<List<PolicyDto>> GetAll()
        {
            try
            {
                var result = _policyRepository.GetAllPolicy();

                return new Response<List<PolicyDto>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = $"Success",
                    Data = ObjectMapper.Mapper.Map<List<PolicyDto>>(result)
                };
            }
            catch (Exception e)
            {
                return new Response<List<PolicyDto>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error : {e.Message}",
                    Data = null
                };
            }
        }

        public IResponse<List<PolicyViewDto>> GetAllPolicyView()
        {
            try
            {
                var result = _policyRepository.GetAllPolicyView();

                return new Response<List<PolicyViewDto>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = $"Success",
                    Data = ObjectMapper.Mapper.Map<List<PolicyViewDto>>(result)
                };
            }
            catch (Exception e)
            {
                return new Response<List<PolicyViewDto>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error : {e.Message}",
                    Data = null
                };
            }
        }
    }
}