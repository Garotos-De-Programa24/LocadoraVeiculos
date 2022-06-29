using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloTaxa;

namespace LocadoraVeiculos.Aplicacao.ModuloTaxa
{
    public class ServicoTaxa
    {
        private IRepositorioTaxa repositorioTaxa;
        public ServicoTaxa(IRepositorioTaxa repositorioTaxa)
        {
            this.repositorioTaxa = repositorioTaxa;
        }
        public ValidationResult Inserir(Taxa taxa)
        {
            ValidationResult resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsValid)
                repositorioTaxa.Inserir(taxa);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Taxa taxa)
        {
            ValidationResult resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsValid)
                repositorioTaxa.Editar(taxa);

            return resultadoValidacao;
        }

        private ValidationResult Validar(Taxa taxa)
        {
            var validador = new ValidaTaxa();

            var resultadoValidacao = validador.Validate(taxa);

            if (NomeDuplicado(taxa))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "Nome duplicado"));

           
            return resultadoValidacao;
        }

        private bool NomeDuplicado(Taxa taxa)
        {
            var funcionarioEncontrado = repositorioTaxa.SelecionarTaxaPeloNome(taxa.Equipamento);

            return funcionarioEncontrado != null &&
                   funcionarioEncontrado.Equipamento == taxa.Equipamento &&
                   funcionarioEncontrado.Id != taxa.Id;
        }

       
    }
}
