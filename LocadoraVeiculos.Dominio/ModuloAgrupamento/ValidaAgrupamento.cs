using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.ModuloAgrupamento
{
    public class ValidaAgrupamento : AbstractValidator<Agrupamento>
    {
        public ValidaAgrupamento()
        {
            RuleFor(x => x.Nome)
           .NotNull().NotEmpty().MinimumLength(3);
        }
    }
}
