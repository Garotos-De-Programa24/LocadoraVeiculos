﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.ModuloCliente
{
    public class ValidaCliente : AbstractValidator<Cliente>
    {
        public ValidaCliente() { }
    }
}
