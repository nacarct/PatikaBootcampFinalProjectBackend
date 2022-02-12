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
    public class PaymentManager:IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentManager(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public IResponse<List<PaymentDto>> GetAll()
        {
            try
            {
                var result = _paymentRepository.GetAllPayments();

                return new Response<List<PaymentDto>>()
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = ObjectMapper.Mapper.Map<List<PaymentDto>>(result)
                };
            }
            catch (Exception e)
            {
                return new Response<List<PaymentDto>>()
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error : {e.Message}",
                    Data = null
                };
            }
        }

        public IResponse<List<PaymentDto>> GetPaymentByPolicyId(int policyId)
        {
            try
            {
                var result = _paymentRepository.GetPaymentByPolicyId(policyId);

                return new Response<List<PaymentDto>>()
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = ObjectMapper.Mapper.Map<List<PaymentDto>>(result)
                };
            }
            catch (Exception e)
            {
                return new Response<List<PaymentDto>>()
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error : {e.Message}",
                    Data = null
                };
            }
        }

        public IResponse AddPayment(PaymentDto paymentDto)
        {
            try
            {
                _paymentRepository.AddPayment(ObjectMapper.Mapper.Map<Payment>(paymentDto));

                return new Response.Response()
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = _paymentRepository.GetPaymentByPolicyId(paymentDto.PolicyId)
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