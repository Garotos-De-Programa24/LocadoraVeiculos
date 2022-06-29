using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Infra.ModuloCliente;

namespace LocadoraVeiculos.Aplicacao.ModuloCliente
{
    public class ServicoCliente
    {
        private IRepositorioCliente repositorioCliente;

        public ServicoCliente(IRepositorioCliente repositorioCliente)
        {
            this.repositorioCliente = repositorioCliente;
        }

        public ValidationResult Inserir(Cliente arg)
        {
            var resultadoValidacao = ValidarCliente(arg);

            if (resultadoValidacao.IsValid)
                repositorioCliente.Inserir(arg);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Cliente arg)
        {
            var resultadoValidacao = ValidarCliente(arg);

            if (resultadoValidacao.IsValid)
                repositorioCliente.Editar(arg);

            return resultadoValidacao;
        }

        private ValidationResult ValidarCliente(Cliente taxa)
        {
            ValidaCliente validador = new ValidaCliente();

            var resultadoValidacao = validador.Validate(taxa);
            if (NomeDuplicado(taxa))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "Nome duplicado"));

            return resultadoValidacao;
        }
        private bool NomeDuplicado(Cliente funcionario)
        {
            var funcionarioEncontrado = repositorioCliente.SelecionarClientePorNome(funcionario.Nome);

            return funcionarioEncontrado != null &&
                   funcionarioEncontrado.Nome == funcionario.Nome &&
                   funcionarioEncontrado.Id != funcionario.Id;
        }
    }
}
