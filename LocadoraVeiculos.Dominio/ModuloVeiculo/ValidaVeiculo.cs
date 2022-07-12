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
                .NotNull().NotEmpty().MaximumLength(4).MinimumLength(4);

            RuleFor(x => x.Marca)
                .NotNull().NotEmpty().MinimumLength(3);

            RuleFor(x => x.Placa)
                .NotNull().NotEmpty().MinimumLength(7);

            RuleFor(x => x.CapacidadeTanque)
                .NotNull().NotEmpty().MinimumLength(1);

            RuleFor(x => x.KmPercorridos)
                .NotNull().NotEmpty().MinimumLength(1);

            RuleFor(x => x.Combustivel)
                .NotNull().NotEmpty();

            RuleFor(x => x.Cor)
                .NotNull().NotEmpty().MinimumLength(3);

            RuleFor(x => x.Agrupamento)
                .NotNull().NotEmpty();
        }
    }
}
