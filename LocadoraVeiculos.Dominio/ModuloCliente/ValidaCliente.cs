using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.ModuloCliente
{
    public class ValidaCliente : AbstractValidator<Cliente>
    {
        public ValidaCliente() 
        {
            RuleFor(x => x.Nome)
           .NotNull().NotEmpty().MinimumLength(3);

            RuleFor(x => x.Cpf)
           .NotNull()
           .NotEmpty()
           .MinimumLength(14).WithMessage("CPF deve conter 11 Digitos");

            RuleFor(x => x.Endereco)
           .NotNull().NotEmpty().MinimumLength(3);

            RuleFor(x => x.Telefone)
           .NotNull().NotEmpty()
           .MinimumLength(15).WithMessage("Telefone deve conter os 12 Digitos");

            RuleFor(x => x.CnhCondutor)
           .NotNull().NotEmpty().MinimumLength(10).MaximumLength(11);

            RuleFor(x => x.ValidadeCnh)
            .GreaterThanOrEqualTo(DateTime.Today);

            RuleFor(x => x.Email)
           .EmailAddress();
        }
    }
}
