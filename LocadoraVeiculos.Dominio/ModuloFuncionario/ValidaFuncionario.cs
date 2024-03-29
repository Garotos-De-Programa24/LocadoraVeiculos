﻿using FluentValidation;
using System;

namespace LocadoraVeiculos.Dominio.ModuloFuncionario
{
    public class ValidaFuncionario : AbstractValidator<Funcionario>
    {
        public ValidaFuncionario()
        {

            RuleFor(x => x.Nome)
           .NotNull().NotEmpty().MinimumLength(3);

            RuleFor(x => x.Login)
           .NotNull().NotEmpty().MinimumLength(3);

            RuleFor(x => x.Senha)
           .NotNull().NotEmpty().MinimumLength(3);

            RuleFor(x => x.Salario)
           .NotNull().NotEmpty().MinimumLength(3);

            RuleFor(x => x.DataAdmissao)
           .NotEqual(DateTime.MinValue);

     
        }
    }
}
