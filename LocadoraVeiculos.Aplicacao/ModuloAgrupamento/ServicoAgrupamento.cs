using FluentResults;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloAgrupamento;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Aplicacao.ModuloAgrupamento
{
    public class ServicoAgrupamento
    {
        private IRepositorioAgrupamento repositorioAgrupamento;
        public ServicoAgrupamento(IRepositorioAgrupamento repositorioAgrupamento)
        {
            this.repositorioAgrupamento = repositorioAgrupamento;
        }
        public Result<Agrupamento> Inserir(Agrupamento agrupamento)
        {
            Log.Logger.Information("Tentando inserir no Grupo de Veiculos @{agrupamento", agrupamento);

            Result resultadoValidacao = ValidarAgrupamento(agrupamento);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir Grupo de Veiculos {AgrupamentoId}" +
                        " -> Motivo: {erro}", agrupamento.Id, erro.Message);
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
                repositorioAgrupamento.Inserir(agrupamento);

                Log.Logger.Information("Grupo de Veiculos {AgrupamentoId} inserido com sucesso.", agrupamento.Id);

                return Result.Ok(agrupamento);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar cadastrar um novo agrupamento";
                

                Log.Logger.Error(ex, msgErro + "{AgrupamentoId}", agrupamento.Id);

                return Result.Fail(msgErro);
            }            
        }

        public Result<Agrupamento> Editar(Agrupamento agrupamento)
        {
            Log.Logger.Information("Tentando editar no Grupo de Veiculos @{agrupamento", agrupamento);

            Result resultadoValidacao = ValidarAgrupamento(agrupamento);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar Grupo de Veiculos {AgrupamentoId}" +
                        " -> Motivo: {erro}", agrupamento.Id, erro.Message);
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
                repositorioAgrupamento.Editar(agrupamento);

                Log.Logger.Information("Grupo de Veiculos {AgrupamentoId} editado com sucesso.", agrupamento.Id);

                return Result.Ok(agrupamento);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar agrupamento";

                Log.Logger.Error(ex, msgErro + "{AgrupamentoId}", agrupamento.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Agrupamento> Excluir(Agrupamento agrupamento)
        {
            Log.Logger.Information("Tentando excluir no Grupo de Veiculos @{agrupamento", agrupamento);

            Result resultadoValidacao = ValidarAgrupamento(agrupamento);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar excluir Grupo de Veiculos {AgrupamentoId}" +
                        " -> Motivo: {erro}", agrupamento.Id, erro.Message);
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
                repositorioAgrupamento.Excluir(agrupamento);
                Log.Logger.Information("Grupo de Veiculos {AgrupamentoId} inserido com sucesso.", agrupamento.Id);

                return Result.Ok(agrupamento);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir agrupamento";

                Log.Logger.Error(ex, msgErro + "{AgrupamentoId}", agrupamento.Id);

                return Result.Fail(msgErro);
            }
        }

        private Result ValidarAgrupamento(Agrupamento agrupamento)
        {
            var validador = new ValidaAgrupamento();

            var resultadoValidacao = validador.Validate(agrupamento);

            List<Error> erros = new List<Error>();

            foreach (ValidationFailure item in resultadoValidacao.Errors)
            {
                erros.Add(new Error(item.ErrorMessage));
            }

            if (NomeDuplicado(agrupamento))
                erros.Add(new Error("Nome duplicado"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private bool NomeDuplicado(Agrupamento agrupamento)
        {
            var agrupamentoEncontrado = repositorioAgrupamento.SelecionarAgrupamentoPorNome(agrupamento.Nome);

            return agrupamentoEncontrado != null &&
                   agrupamentoEncontrado.Nome == agrupamento.Nome &&
                   agrupamentoEncontrado.Id != agrupamento.Id;
        }

        public Result<List<Agrupamento>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioAgrupamento.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no Sistema ao tentar selecionar todos os agrupamentos";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Agrupamento> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioAgrupamento.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no Sistema ao tentar selecionar o agrupamento";

                Log.Logger.Error(ex, msgErro + "{AgrupamentoId}",id);

                return Result.Fail(msgErro);
            }
        }
    }
}
