using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloAgrupamento;
using Serilog;

namespace LocadoraVeiculos.Aplicacao.ModuloAgrupamento
{
    public class ServicoAgrupamento
    {
        private IRepositorioAgrupamento repositorioAgrupamento;
        public ServicoAgrupamento(IRepositorioAgrupamento repositorioAgrupamento)
        {
            this.repositorioAgrupamento = repositorioAgrupamento;
        }
        public ValidationResult Inserir(Agrupamento agrupamento)
        {
            Log.Logger.Information("Tentando inserir no Grupo de Veiculos @{agrupamento", agrupamento);
            ValidationResult resultadoValidacao = Validar(agrupamento);

            if (resultadoValidacao.IsValid) { 
            repositorioAgrupamento.Inserir(agrupamento);
                Log.Logger.Information("Grupo de Veiculos {AgrupamentoNome} inserido com sucesso.", agrupamento.Nome);
            }
            else
            {
                foreach(var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir Grupo de Veiculos {AgrupamentoNome} -> Motivo: {erro}", agrupamento.Nome, erro.ErrorMessage);
                }
            }
            return resultadoValidacao;
        }

        public ValidationResult Editar(Agrupamento agrupamento)
        {
            Log.Logger.Information("Tentando editar no Grupo de Veiculos @{agrupamento", agrupamento);

            ValidationResult resultadoValidacao = Validar(agrupamento);

            if (resultadoValidacao.IsValid)
            {
                repositorioAgrupamento.Editar(agrupamento);
                Log.Logger.Information("Grupo de Veiculos {AgrupamentoNome} editado com sucesso.", agrupamento.Nome);

            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar Grupo de Veiculos {AgrupamentoNome} -> Motivo: {erro}", agrupamento.Nome, erro.ErrorMessage);
                }
            }
            return resultadoValidacao;
        }

        private ValidationResult Validar(Agrupamento agrupamento)
        {
            var validador = new ValidaAgrupamento();

            var resultadoValidacao = validador.Validate(agrupamento);

            if (NomeDuplicado(agrupamento))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "Nome duplicado"));

            return resultadoValidacao;
        }

        private bool NomeDuplicado(Agrupamento agrupamento)
        {
            var agrupamentoEncontrado = repositorioAgrupamento.SelecionarAgrupamentoPorNome(agrupamento.Nome);

            return agrupamentoEncontrado != null &&
                   agrupamentoEncontrado.Nome == agrupamento.Nome &&
                   agrupamentoEncontrado.Id != agrupamento.Id;
        }

       
    }
}
