using FluentResults;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloLocação;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Aplicacao.ModuloLocacao
{
    public class ServicoLocacao
    {
        private IRepositorioLocacao repositorioLocacao;
        private IContextoPersistencia contextoDados;

        public ServicoLocacao(IRepositorioLocacao repositorioLocacao,IContextoPersistencia contextoDados)
        {
            this.repositorioLocacao = repositorioLocacao;
            this.contextoDados = contextoDados;
        }

        public Result<Locacao> Inserir(Locacao locacao)
        {
            Log.Logger.Information("Tentando inserir no Locacao @{locacao}", locacao);

            Result resultadoValidacao = ValidarLocacao(locacao);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir Locacao {LocacaoClienteNome}" +
                        " -> Motivo: {erro}", locacao.Cliente.Nome, erro.Message);
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
                repositorioLocacao.Inserir(locacao);

                contextoDados.GravarDados();

                Log.Logger.Information("Locacao {LocacaoClienteNome} inserido com sucesso.", locacao.Cliente.Nome);

                return Result.Ok(locacao);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar cadastrar uma nova locacao";

                Log.Logger.Error(ex, msgErro + "{LocacaoId}", locacao.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Locacao> Editar(Locacao locacao)
        {
            Log.Logger.Information("Tentando editar Locacao @{locacao}", locacao);

            Result resultadoValidacao = ValidarEdicaoLocacao(locacao);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar Locacao {LocacaoId}" +
                        " -> Motivo: {erro}", locacao.Id, erro.Message);
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
                repositorioLocacao.Editar(locacao);

                contextoDados.GravarDados();

                Log.Logger.Information("Locacao {LocacaoId} editado com sucesso.", locacao.Id);

                return Result.Ok(locacao);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar locacao";

                Log.Logger.Error(ex, msgErro + "{LocacaoId}", locacao.Id);

                return Result.Fail(msgErro);
            }
        }
        public Result<Locacao> Excluir(Locacao locacao)
        {
            Log.Logger.Information("Tentando excluir o Locacao @{locacao}", locacao);

            try
            {
                repositorioLocacao.Excluir(locacao);

                contextoDados.GravarDados();

                Log.Logger.Information("Locacao {LocacaoId} excluido com sucesso.", locacao.Id);

                return Result.Ok(locacao);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir locacao";

                Log.Logger.Error(ex, msgErro + "{LocacaoId}", locacao.Id);

                return Result.Fail(msgErro);
            }
        }

        private Result ValidarEdicaoLocacao(Locacao locacao)
        {
            var validador = new ValidaLocacao();

            var resultadoValidacao = validador.Validate(locacao);

            List<Error> erros = new List<Error>();

            foreach (ValidationFailure item in resultadoValidacao.Errors)
            {
                erros.Add(new Error(item.ErrorMessage));
            }

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private Result ValidarLocacao(Locacao locacao)
        {
            var validador = new ValidaLocacao();

            var resultadoValidacao = validador.Validate(locacao);

            List<Error> erros = new List<Error>();

            foreach (ValidationFailure item in resultadoValidacao.Errors)
            {
                erros.Add(new Error(item.ErrorMessage));
            }

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        public Result<List<Locacao>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioLocacao.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no Sistema ao tentar selecionar todos as locações";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }

        }

        public Result<Locacao> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioLocacao.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no Sistema ao tentar selecionar locação";

                Log.Logger.Error(ex, msgErro + "{LocacaoId}", id);

                return Result.Fail(msgErro);
            }
        }
    }
}
