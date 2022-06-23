using FluentValidation;

namespace LocadoraVeiculos.Dominio.ModuloVeiculo
{
    public class ValidaAgrupamentoVeiculo : AbstractValidator<Agrupamento>
    {
        public ValidaAgrupamentoVeiculo() 
        {
            RuleFor(x => x.NomeAgrupamento)
            .NotNull().NotEmpty().MinimumLength(3);

        
        }
    }
}
