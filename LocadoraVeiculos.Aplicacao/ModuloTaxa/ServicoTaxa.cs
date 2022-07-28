using FluentResults;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloTaxa;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Aplicacao.ModuloTaxa
{
    public class ServicoTaxa
    {
        private IRepositorioTaxa repositorioTaxa;
        private IContextoPersistencia contextoDados;
        public ServicoTaxa(IRepositorioTaxa repositorioTaxa, IContextoPersistencia contextoDados)
        {
            this.repositorioTaxa = repositorioTaxa;
            this.contextoDados = contextoDados;
        }
        public Result<Taxa> Inserir(Taxa taxa)
        {
            Log.Logger.Debug("Tentando inserir Taxa {@taxa}", taxa);

            Result resultadoValidacao = ValidarTaxa(taxa);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir um Funcionário {TaxaId} - {Motivo}",
                       taxa.Equipamento, erro.Message);
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
                repositorioTaxa.Inserir(taxa);
                contextoDados.GravarDados();
                Log.Logger.Information("Funcionário {FuncionarioId} inserido com sucesso", taxa.Id);
                return Result.Ok(taxa);

            }
            catch (Exception ex)
            {
                string mensagemErro = "Falha no sistema ao tentar selecionar o Funcionario";
                Log.Logger.Error(ex, mensagemErro + "{FuncionarioId}", taxa.Id);
                return Result.Fail(mensagemErro);
            }
        }

        public Result<Taxa> Editar(Taxa taxa)
        {
            Log.Logger.Debug("Tentando editar taxa {@taxa}", taxa);

            Result resultadoValidacao = ValidarEdicaoTaxa(taxa);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar um Taxa {TaxaId} - {Motivo}", taxa.Id, erro.Message);
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
                repositorioTaxa.Editar(taxa);
                contextoDados.GravarDados();
                Log.Logger.Information("Funcionário {TaxaId} editado com sucesso", taxa.Id);

                return Result.Ok(taxa);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar a Taxa";

                Log.Logger.Error(ex, msgErro + "{TaxaId}", taxa.Id);

                return Result.Fail(msgErro);
            }
        }
        public Result<Taxa> Excluir(Taxa taxa)
        {
            Log.Logger.Information("Tentando excluir o Taxa @{taxa}", taxa);
                        
            try
            {
                repositorioTaxa.Excluir(taxa);
                contextoDados.GravarDados();
                Log.Logger.Information("Taxa {TaxaId} excluido com sucesso.", taxa.Id);

                return Result.Ok(taxa);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir taxa";

                Log.Logger.Error(ex, msgErro + "{TaxaId}", taxa.Id);

                return Result.Fail(msgErro);
            }

        }
        public Result<List<Taxa>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioTaxa.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string mensagemErro = "Falha no sistema ao tentar selecionar todas as Taxas";
                Log.Logger.Error(ex, mensagemErro);
                return Result.Fail(mensagemErro);
            }
        }
        public Result<Taxa> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioTaxa.SelecionarPorId(id));

            }
            catch (Exception ex)
            {
                string mensagemErro = "Falha no sistema ao tentar selecionar a Taxa";
                Log.Logger.Error(ex, mensagemErro + "{TaxaId}", id);
                return Result.Fail(mensagemErro);
            }
        }

        private Result ValidarEdicaoTaxa(Taxa Taxa)
        {
            var validador = new ValidaTaxa();

            var resultadoValidacao = validador.Validate(Taxa);

            List<Error> erros = new List<Error>();

            foreach (ValidationFailure item in resultadoValidacao.Errors)
            {
                erros.Add(new Error(item.ErrorMessage));
            }

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private Result  ValidarTaxa(Taxa taxa)
        {
            var validador = new ValidaTaxa();

            var resultadoValidacao = validador.Validate(taxa);

            List<Error> erros = new List<Error>(); //Fluent Result <<<<<<<<<<

            foreach (ValidationFailure item in resultadoValidacao.Errors) //Fluent Validation <<<<<<<<<
            {
                Log.Logger.Warning(item.ErrorMessage);
                erros.Add(new Error(item.ErrorMessage));
            }

            if (NomeDuplicado(taxa))
                erros.Add(new Error("Nome duplicado"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
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
