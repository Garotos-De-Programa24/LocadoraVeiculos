using FluentValidation;

namespace LocadoraVeiculos.Dominio.ModuloTaxa
{
    public class ValidaTaxa : AbstractValidator<Taxa>
    {
        public ValidaTaxa()
        {
            RuleFor(x => x.Equipamento)
           .NotNull().NotEmpty().MinimumLength(3);

            RuleFor(x => x.Valor) 
           .NotNull().NotEmpty().MinimumLength(1);
        }
    }
}
