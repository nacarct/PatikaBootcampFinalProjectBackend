using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Mapper;
using Business.Response;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class PaymentLineManager:IPaymentLineService
    {
        private readonly IPaymentLineRepository _paymentLineRepository;

        public PaymentLineManager(IPaymentLineRepository paymentLineRepository)
        {
            _paymentLineRepository = paymentLineRepository;
        }

        public IResponse<List<PaymentLineDto>> GetAll()
        {
            try
            {
                var result = _paymentLineRepository.GetAllPaymentLines();

                return new Response<List<PaymentLineDto>>()
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = ObjectMapper.Mapper.Map<List<PaymentLineDto>>(result)
                };
            }
            catch (Exception e)
            {
                return new Response<List<PaymentLineDto>>()
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error : {e.Message}",
                    Data =null
                };
            }
        }

        public IResponse<List<PaymentLineDto>> GetPaymentLinesByPaymentId(int paymentId)
        {
            try
            {
                var result = _paymentLineRepository.GetPaymentLinesByPaymentId(paymentId);

                return new Response<List<PaymentLineDto>>()
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = ObjectMapper.Mapper.Map<List<PaymentLineDto>>(result)
                };
            }
            catch (Exception e)
            {
                return new Response<List<PaymentLineDto>>()
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error : {e.Message}",
                    Data = null
                };
            }
        }

        public IResponse<PaymentLineDto> GetPaymentLineById(int paymentLineId)
        {
            try
            {
                var result = _paymentLineRepository.GetPaymentLineById(paymentLineId);

                return new Response<PaymentLineDto>()
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = ObjectMapper.Mapper.Map<PaymentLineDto>(result)
                };
            }
            catch (Exception e)
            {
                return new Response<PaymentLineDto>()
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error : {e.Message}",
                    Data = null
                };
            }
        }

        public IResponse AddPaymentLine(PaymentLineDto paymentLine)
        {
            try
            {
                _paymentLineRepository.AddPaymentLine(ObjectMapper.Mapper.Map<PaymentLine>(paymentLine));

                return new Response.Response()
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = null
                };
            }
            catch (Exception e)
            {
                return new Response.Response()
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error : {e.Message}",
                    Data = null
                };
            }
        }
    }
}