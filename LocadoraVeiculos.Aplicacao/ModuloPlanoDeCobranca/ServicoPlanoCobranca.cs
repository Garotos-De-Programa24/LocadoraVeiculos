using FluentResults;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloPlanoDeCobranca;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Aplicacao.ModuloPlanoDeCobranca
{
    public class ServicoPlanoCobranca
    {
        private IRepositorioPlanoCobranca repositorioPlano;
        private IContextoPersistencia contextoDados;

        public ServicoPlanoCobranca(IRepositorioPlanoCobranca repositorioPlano, IContextoPersistencia contextoDados)
        {
            this.repositorioPlano = repositorioPlano;
            this.contextoDados = contextoDados;
        }
        public Result<PlanoCobranca> Inserir(PlanoCobranca planoCobranca)
        {
            Log.Logger.Debug("Tentando inserir novo Plano de Cobrança {@planoCobranca}", planoCobranca);

            Result resultadoValidacao = ValidarPlano(planoCobranca);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir um Plano de Cobrança {PlanoId} - {Motivo}",
                       planoCobranca.NomePlano, erro.Message);
                }
                return Result.Fail(resultadoValidacao.Errors);
            }
            List<Error> erros = new List<Error>();
            foreach (ValidationFailure item in resultadoValidacao.Errors)
            {
                erros.Add(new Error(item.ErrorMessage));
            }
            try
            {
                repositorioPlano.Inserir(planoCobranca);
                contextoDados.GravarDados();
                Log.Logger.Information("Funcionário {PlanoId} inserido com sucesso", planoCobranca.Id);
                return Result.Ok(planoCobranca);

            }
            catch (Exception ex)
            {
                string mensagemErro = "Falha no sistema ao tentar selecionar o Plano de Cobrança";
                Log.Logger.Error(ex, mensagemErro + "{PlanoId}", planoCobranca.Id);
                return Result.Fail(mensagemErro);
            }
        }

        public Result<PlanoCobranca> Editar(PlanoCobranca planoCobranca)
        {
            Log.Logger.Debug("Tentando editar Plano de Cobrança {@planodeCobrança}", planoCobranca);

            Result resultadoValidacao = ValidarEdicaoPlano(planoCobranca);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar um Plano de cobrança {PlanoId} - {Motivo}", planoCobranca.Id, erro.Message);
                }
                return Result.Fail(resultadoValidacao.Errors);
            }
            List<Error> erros = new List<Error>();
            foreach (ValidationFailure item in resultadoValidacao.Errors)
            {
                erros.Add(new Error(item.ErrorMessage));
            }
            try
            {
                repositorioPlano.Editar(planoCobranca);
                contextoDados.GravarDados();
                Log.Logger.Information("Funcionário {PlanoId} editado com sucesso", planoCobranca.Id);

                return Result.Ok(planoCobranca);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o Plano de cobrança";

                Log.Logger.Error(ex, msgErro + "{PlanaId}", planoCobranca.Id);

                return Result.Fail(msgErro);
            }
        }
        public Result<PlanoCobranca> Excluir(PlanoCobranca planoCobranca)
        {
            Log.Logger.Information("Tentando excluir o Plano de Cobrança @{planocobrança}", planoCobranca);
                        
            try
            {
                repositorioPlano.Excluir(planoCobranca);
                contextoDados.GravarDados();
                Log.Logger.Information("Plano de Cobrança {PlanoId} excluido com sucesso.", planoCobranca.Id);

                return Result.Ok(planoCobranca);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir Plano de Cobrança";

                Log.Logger.Error(ex, msgErro + "{PlanoId}", planoCobranca.Id);

                return Result.Fail(msgErro);
            }

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
        public Result<PlanoCobranca> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioPlano.SelecionarPorId(id));

            }
            catch (Exception ex)
            {
                string mensagemErro = "Falha no sistema ao tentar selecionar o Plano de Cobrança";
                Log.Logger.Error(ex, mensagemErro + "{PlanoId}", id);
                return Result.Fail(mensagemErro);
            }
        }

        private Result ValidarEdicaoPlano(PlanoCobranca plano)
        {
            var validador = new ValidaPlanoCobranca();

            var resultadoValidacao = validador.Validate(plano);

            List<Error> erros = new List<Error>();

            foreach (ValidationFailure item in resultadoValidacao.Errors)
            {
                erros.Add(new Error(item.ErrorMessage));
            }

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private Result ValidarPlano(PlanoCobranca planoCobranca)
        {
            var validador = new ValidaPlanoCobranca();

            var resultadoValidacao = validador.Validate(planoCobranca);

            List<Error> erros = new List<Error>(); //Fluent Result <<<<<<<<<<

            foreach (ValidationFailure item in resultadoValidacao.Errors) //Fluent Validation <<<<<<<<<
            {
                Log.Logger.Warning(item.ErrorMessage);
                erros.Add(new Error(item.ErrorMessage));
            }

            if (NomeDuplicado(planoCobranca))
                erros.Add(new Error("Nome duplicado"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
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
