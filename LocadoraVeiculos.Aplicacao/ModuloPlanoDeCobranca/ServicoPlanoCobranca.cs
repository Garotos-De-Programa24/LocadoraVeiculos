using FluentResults;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloPlanoDeCobranca;
using Serilog;
using System;
using System.Collections.Generic;

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
            Log.Logger.Debug("Tentando inserir no Plano de Cobrança @{PlanoCobranca}", planoCobranca);

            var resultadoValidacao = ValidarPlano(planoCobranca);

            if (resultadoValidacao.IsValid)
            {
                repositorioPlano.Inserir(planoCobranca);
                Log.Logger.Information("Plano de Cobrança{PlanoCobrancaId} inserido com sucesso.", planoCobranca.Id);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir Plano de Cobrança {PlanoCobrancaId} -> Motivo: {erro}", planoCobranca.Id, erro.ErrorMessage);
                }
            }
            return resultadoValidacao;
        }

        public ValidationResult Editar(PlanoCobranca planoCobranca)
        {
            Log.Logger.Debug("Tentando editar no Plano de Cobrança @{PlanoCobranca}", planoCobranca);

            var resultadoValidacao = ValidarPlano(planoCobranca);

            if (resultadoValidacao.IsValid)
            {
                repositorioPlano.Editar(planoCobranca);
                Log.Logger.Information("Plano de Cobrança{PlanoCobrancaId} editar com sucesso.", planoCobranca.Id);

            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar Plano de Cobrança {PlanoCobrancaId} -> Motivo: {erro}", planoCobranca.Id, erro.ErrorMessage);
                }
            }
            return resultadoValidacao;
        }
        public Result<List<PlanoCobranca>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioPlano.SelecionarTodos());

            }
            catch (Exception ex)
            {
                string mensagemErro = "Falha no sistema ao tentar selecionar todos os Planos de Cobrança";
                Log.Logger.Error(ex, mensagemErro);
                return Result.Fail(mensagemErro);
            }
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
