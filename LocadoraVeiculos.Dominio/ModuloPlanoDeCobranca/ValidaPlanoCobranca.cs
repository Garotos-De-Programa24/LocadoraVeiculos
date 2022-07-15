using FluentValidation;

namespace LocadoraVeiculos.Dominio.ModuloPlanoDeCobranca
{
    public class ValidaPlanoCobranca : AbstractValidator<PlanoCobranca>
    {
        public ValidaPlanoCobranca() 
        {
            RuleFor(x => x.GrupoVeiculos).NotNull().NotEmpty();

            RuleFor(x => x.NomePlano).NotNull().NotEmpty().MinimumLength(3);

            RuleFor(x => x.ValorDiario).NotNull();

            RuleFor(x => x.ValorPorKm).NotNull();

            RuleFor(x => x.LimiteQuilometragem).NotNull();
        }
    }
}
