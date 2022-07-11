using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloCondutor;
using Serilog;

namespace LocadoraVeiculos.Aplicacao.ModuloCondutor
{
    public class ServicoCondutor
    {
        private IRepositorioCondutor repositorioCondutor;

        public ServicoCondutor(IRepositorioCondutor repositorioCondutor)
        {
            this.repositorioCondutor = repositorioCondutor;
        }

        public ValidationResult Inserir(Condutor condutor)
        {
            Log.Logger.Information("Tentando inserir no condutor @{condutor", condutor);

            var resultadoValidacao = ValidarCondutor(condutor);

            if (resultadoValidacao.IsValid)
            {
                repositorioCondutor.Inserir(condutor);
                Log.Logger.Information("Condutor{CondutorNome} inserido com sucesso.", condutor.Nome);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir Condutor {CondutorNome} -> Motivo: {erro}", condutor.Nome, erro.ErrorMessage);
                }
            }
            return resultadoValidacao;
        }

        public ValidationResult Editar(Condutor condutor)
        {
            Log.Logger.Information("Tentando editar no condutor @{condutor", condutor);

            var resultadoValidacao = ValidarCondutor(condutor);

            if (resultadoValidacao.IsValid)
            {
                repositorioCondutor.Editar(condutor);
                Log.Logger.Information("Condutor{CondutorNome} editar com sucesso.", condutor.Nome);

            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar Condutor {CondutorNome} -> Motivo: {erro}", condutor.Nome, erro.ErrorMessage);
                }
            }
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
