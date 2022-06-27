using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.ModuloTaxa
{
    public class ValidaTaxa : AbstractValidator<Taxa>
    {
        public ValidaTaxa()
        {
            RuleFor(x => x.Descricao)
           .NotNull().NotEmpty().MinimumLength(3);

            RuleFor(x => x.Equipamento)
           .NotNull().NotEmpty().MinimumLength(3);

            RuleFor(x => x.Valor) 
           .NotNull().NotEmpty();
        }
    }
}
