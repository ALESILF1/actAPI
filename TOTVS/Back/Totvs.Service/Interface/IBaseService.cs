using Alesilf.Totvs.Domain.Entities;
using FluentValidation;

namespace Alesilf.Totvs.Service.Interface
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        void Validate(TEntity obj, AbstractValidator<TEntity> validator);
    }
}
