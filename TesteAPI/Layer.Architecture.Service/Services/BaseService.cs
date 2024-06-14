using AutoMapper;
using FluentValidation;
using Layer.Architecture.Domain.Entities;
using Layer.Architecture.Infra.Data.Interface;
using Layer.Architecture.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Layer.Architecture.Service.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        public void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }
    }
}
