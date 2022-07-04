using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.ModuloCondutor
{
    public class ValidaCondutor : AbstractValidator<Condutor>
    {
        public ValidaCondutor()
        {
            RuleFor(x => x.Cliente)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Nome)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3);

            RuleFor(x => x.Cpf)
               .NotNull()
               .NotEmpty()
               .MinimumLength(14).WithMessage("Informe um CPF Válido");

            RuleFor(x => x.Endereco)
               .NotNull().NotEmpty().MinimumLength(3);

            RuleFor(x => x.Telefone)
               .NotNull().NotEmpty()
               .MinimumLength(15).WithMessage("Telefone deve conter os 12 Digitos");

            RuleFor(x => x.CnhCondutor)
               .NotNull().NotEmpty().Length(11);

            RuleFor(x => x.ValidadeCnh)
                .GreaterThanOrEqualTo(DateTime.Today);

            RuleFor(x => x.Email)
               .EmailAddress();
        }
        
    }
}
