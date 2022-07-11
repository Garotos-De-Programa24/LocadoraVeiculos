using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Infra.ModuloCliente;
using Serilog;

namespace LocadoraVeiculos.Aplicacao.ModuloCliente
{
    public class ServicoCliente
    {
        private IRepositorioCliente repositorioCliente;

        public ServicoCliente(IRepositorioCliente repositorioCliente)
        {
            this.repositorioCliente = repositorioCliente;
        }

        public ValidationResult Inserir(Cliente cliente)
        {
            Log.Logger.Information("Tentando inserir no cliente @{cliente", cliente);

            var resultadoValidacao = ValidarCliente(cliente);

            if (resultadoValidacao.IsValid)
            {
                repositorioCliente.Inserir(cliente);
                Log.Logger.Information("Cliente{ClienteNome} inserido com sucesso.", cliente.Nome);

            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir Cliente {ClienteNome} -> Motivo: {erro}", cliente.Nome, erro.ErrorMessage);
                }
            }
            return resultadoValidacao;
        }

        public ValidationResult Editar(Cliente cliente)
        {
            Log.Logger.Information("Tentando editar no cliente @{cliente", cliente);

            var resultadoValidacao = ValidarCliente(cliente);

            if (resultadoValidacao.IsValid)
            {
                Log.Logger.Information("Cliente{ClienteNome} editar com sucesso.", cliente.Nome);
                repositorioCliente.Editar(cliente);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar Cliente {ClienteNome} -> Motivo: {erro}", cliente.Nome, erro.ErrorMessage);
                }
            }

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
