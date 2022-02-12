using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Business.Response;
using Entities.Abstract;

namespace Business.Abstract
{
    public interface IService<T,TDto> where T : IEntity where TDto : IDto
    {
        IResponse<List<TDto>> GetAll();
    }
}