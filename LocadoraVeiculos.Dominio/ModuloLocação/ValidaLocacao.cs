using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.ModuloLocação
{
    public class ValidaLocacao : AbstractValidator<Locacao>
    {
        public ValidaLocacao()
        {
            RuleFor(x => x.Funcionario)
           .NotNull().NotEmpty();

            RuleFor(x => x.Cliente)
           .NotNull().NotEmpty();

            RuleFor(x => x.Condutor)
           .NotNull().NotEmpty();

            RuleFor(x => x.Agrupamento)
           .NotNull().NotEmpty();

            RuleFor(x => x.Veiculo)
           .NotNull().NotEmpty();

            RuleFor(x => x.Plano)
           .NotNull().NotEmpty();

            RuleFor(x => x.Taxas)
           .NotNull().NotEmpty();

            RuleFor(x => x.DataLocacao)
           .GreaterThanOrEqualTo(DateTime.Today);

            RuleFor(x => x.DataDevolucao)
            .LessThanOrEqualTo(DateTime.Today.AddDays(30));
        }
    }
}
