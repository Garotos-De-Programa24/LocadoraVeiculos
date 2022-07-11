using FluentValidation;

namespace LocadoraVeiculos.Dominio.ModuloVeiculo
{
    public class ValidaVeiculo : AbstractValidator<Veiculo>
    {
        public ValidaVeiculo()
        {
            RuleFor(x => x.VeiculoNome)
           .NotNull().NotEmpty().MinimumLength(3);

            RuleFor(x => x.Ano)
           .NotNull().NotEmpty().MinimumLength(4);
        }
    }
}
