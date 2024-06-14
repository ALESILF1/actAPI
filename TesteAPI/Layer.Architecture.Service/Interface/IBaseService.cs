using FluentValidation;
using Layer.Architecture.Domain.Entities;
using System.Collections.Generic;

namespace Layer.Architecture.Service.Interface
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        void Validate(TEntity obj, AbstractValidator<TEntity> validator);
    }
}
