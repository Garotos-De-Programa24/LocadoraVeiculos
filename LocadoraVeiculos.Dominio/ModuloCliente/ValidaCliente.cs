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

            RuleFor(x => x.CpfCnpj)
           .NotNull().NotEmpty();

            RuleFor(x => x.Endereco)
           .NotNull().NotEmpty().MinimumLength(3);

            RuleFor(x => x.Telefone)
           .NotNull().NotEmpty(); 

            RuleFor(x => x.CnhCondutor)
           .NotNull().NotEmpty();

            RuleFor(x => x.Email)
           .NotNull().NotEmpty().MinimumLength(3);

        }
    }
}
