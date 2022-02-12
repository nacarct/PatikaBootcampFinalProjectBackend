using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Response;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.ControllerBase
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiBaseController<TInterface, T, TDto> : Microsoft.AspNetCore.Mvc.ControllerBase where TInterface : IService<T, TDto> where T : Entity where TDto : Dto
    {
        private readonly TInterface _genericService;

        public ApiBaseController(TInterface genericService)
        {
            _genericService = genericService;
        }

        [HttpGet("GetAll")]
        public IResponse<List<TDto>> GetAll()
        {
            try
            {
                var data = _genericService.GetAll();

                return data;
            }
            catch (Exception e)
            {
                return new Response<List<TDto>>()
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error : {e.Message}",
                    Data = null
                };
            }
        }
    }
}