using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace LocadoraVeiculos.Dominio.ModuloVeiculo
{
    public class ValidaVeiculo : AbstractValidator<Veiculo>
    {
        public ValidaVeiculo() { }
    }
}
