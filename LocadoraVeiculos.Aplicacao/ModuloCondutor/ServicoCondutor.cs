using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloCondutor;

namespace LocadoraVeiculos.Aplicacao.ModuloCondutor
{
    public class ServicoCondutor
    {
        private IRepositorioCondutor repositorioCondutor;

        public ServicoCondutor(IRepositorioCondutor repositorioCondutor)
        {
            this.repositorioCondutor = repositorioCondutor;
        }

        public ValidationResult Inserir(Condutor arg)
        {
            var resultadoValidacao = ValidaCondutor(arg);

            if (resultadoValidacao.IsValid)
                repositorioCondutor.Inserir(arg);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Condutor arg)
        {
            var resultadoValidacao = ValidarCliente(arg);

            if (resultadoValidacao.IsValid)
                repositorioCondutor.Editar(arg);

            return resultadoValidacao;
        }

        private ValidationResult ValidarCondutor(Condutor condutor)
        {
            ValidaCondutor validador = new ValidaCondutor();

            var resultadoValidacao = validador.Validate(condutor);
            if (NomeDuplicado(condutor))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "Nome duplicado"));

            return resultadoValidacao;
        }
        private bool NomeDuplicado(Condutor condutor)
        {
            var funcionarioEncontrado = repositorioCondutor.SelecionarCondutorPorNome(condutor.Nome);

            return funcionarioEncontrado != null &&
                   funcionarioEncontrado.Nome == condutor.Nome &&
                   funcionarioEncontrado.Id != condutor.Id;
        }
    }
}
