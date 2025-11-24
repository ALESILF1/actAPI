using Alesilf.Totvs.Domain.Entities;
using Alesilf.Totvs.Service.Interface;
using FluentValidation;

namespace Alesilf.Totvs.Service.Services
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
