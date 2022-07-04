using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraVeiculos.Infra.ModuloPlanoDeCobranca;

namespace LocadoraVeiculos.Aplicacao.ModuloPlanoDeCobranca
{
    public class ServicoPlanoCobranca
    {
        private IRepositorioPlanoCobranca repositorioPlano;

        public ServicoPlanoCobranca(IRepositorioPlanoCobranca repositorioPlano)
        {
            this.repositorioPlano = repositorioPlano;
        }
        public ValidationResult Inserir(PlanoCobranca planoCobranca)
        {
            var resultadoValidacao = ValidarPlano(planoCobranca);

            if (resultadoValidacao.IsValid)
                repositorioPlano.Inserir(planoCobranca);

            return resultadoValidacao;
        }

        public ValidationResult Editar(PlanoCobranca planoCobranca)
        {
            var resultadoValidacao = ValidarPlano(planoCobranca);

            if (resultadoValidacao.IsValid)
                repositorioPlano.Editar(planoCobranca);

            return resultadoValidacao;
        }

        private ValidationResult ValidarPlano(PlanoCobranca planoCobranca)
        {
            ValidaPlanoCobranca validador = new ValidaPlanoCobranca();

            var resultadoValidacao = validador.Validate(planoCobranca);
            if (NomeDuplicado(planoCobranca))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "Nome duplicado"));

            return resultadoValidacao; 
        }

        private bool NomeDuplicado(PlanoCobranca planoCobranca)
        {
            var planoEncontrado = repositorioPlano.SelecionarPlanoPorNome(planoCobranca.NomePlano);

            return planoEncontrado != null &&
                   planoEncontrado.NomePlano == planoCobranca.NomePlano &&
                   planoEncontrado.Id != planoCobranca.Id;
        }
    }
}
