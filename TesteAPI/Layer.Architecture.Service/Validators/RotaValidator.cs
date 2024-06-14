using FluentValidation;
using Layer.Architecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Layer.Architecture.Service.Validators
{
    public class RotaValidator : AbstractValidator<Rota>
    {
        public RotaValidator()
        {
            RuleFor(c => c.Origin)
                    .NotEmpty().WithMessage("Preencha o campo Origem.")
                    .NotNull().WithMessage("Preencha o campo Origem.");

            RuleFor(c => c.Destination)
                    .NotEmpty().WithMessage("Preencha o campo Destino.")
                    .NotNull().WithMessage("Preencha o campo Destino.");
                    

            RuleFor(c => c.Cost)
                    .NotEmpty().WithMessage("Preencha o campo Custo")
                    .NotNull().WithMessage("Preencha o campo Custo.")
                    .When(c => c.Cost < 1  ).WithMessage("Preencha o campo Custo com valor valido");
            
            
        }
    }
}