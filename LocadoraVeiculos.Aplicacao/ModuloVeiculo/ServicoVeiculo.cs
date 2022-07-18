using FluentResults;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Aplicacao.ModuloVeiculo
{
    public class ServicoVeiculo
    {
        private IRepositorioVeiculo repositorioVeiculo;

        public ServicoVeiculo(IRepositorioVeiculo repositorioVeiculo)
        {
            this.repositorioVeiculo = repositorioVeiculo;
        }

        public Result<Veiculo> Inserir(Veiculo veiculo)
        {
            Log.Logger.Debug("Tentando inserir Veiculo {@veiculo}", veiculo);

            Result resultadoValidacao = ValidarVeiculo(veiculo);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir um Veiculos {VeiculoId} - {Motivo}",
                       veiculo.Id, erro.Message);
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
                repositorioVeiculo.Inserir(veiculo);

                Log.Logger.Information("Veículo {VeiculoId} inserido com sucesso", veiculo.Id);
                return Result.Ok(veiculo);

            }
            catch (Exception ex)
            {
                string mensagemErro = "Falha no sistema ao tentar selecionar o Veículo";
                Log.Logger.Error(ex, mensagemErro + "{VeículoId}", veiculo.Id);
                return Result.Fail(mensagemErro);
            }
        }

        public Result<Veiculo> Editar(Veiculo veiculo)
        {
            Log.Logger.Debug("Tentando editar veiculo {@veiculo}", veiculo);

            Result resultadoValidacao = ValidarVeiculo(veiculo);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar um Veiculo {VeiculoId} - {Motivo}", veiculo.Id, erro.Message);
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
                repositorioVeiculo.Editar(veiculo);

                Log.Logger.Information("Veiculo {VeiculoID} editado com sucesso", veiculo.Id);

                return Result.Ok(veiculo);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar a Veiculo";

                Log.Logger.Error(ex, msgErro + "{VeiculoId}", veiculo.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Veiculo> Excluir(Veiculo veiculo)
        {
            Log.Logger.Information("Tentando excluir o Veiculo @{veiculo}", veiculo);

            Result resultadoValidacao = ValidarVeiculo(veiculo);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar excluir Veiculo {VeiculoId}" +
                        " -> Motivo: {erro}", veiculo.Id, erro.Message);
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
                repositorioVeiculo.Excluir(veiculo);
                Log.Logger.Information("Veiculo {VeiculoId} inserido com sucesso.", veiculo.Id);

                return Result.Ok(veiculo);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir veiculo";

                Log.Logger.Error(ex, msgErro + "{VeiculoId}", veiculo.Id);

                return Result.Fail(msgErro);
            }

        }

        public Result<List<Veiculo>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioVeiculo.SelecionarTodos());

            }
            catch (Exception ex)
            {
                string mensagemErro = "Falha no sistema ao tentar selecionar todos os Veiculos";
                Log.Logger.Error(ex, mensagemErro);
                return Result.Fail(mensagemErro);
            }
        }

        public Result<Veiculo> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioVeiculo.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string mensagemErro = "Falha no sistema ao tentar selecionar a Taxa";
                Log.Logger.Error(ex, mensagemErro + "{TaxaId}", id);
                return Result.Fail(mensagemErro);
            }
        }

        private Result ValidarVeiculo(Veiculo veiculo)
        {
            var validador = new ValidaVeiculo();

            var resultadoValidacao = validador.Validate(veiculo);

            List<Error> erros = new List<Error>(); //Fluent Result <<<<<<<<<<

            foreach (ValidationFailure item in resultadoValidacao.Errors) //Fluent Validation <<<<<<<<<
            {
                Log.Logger.Warning(item.ErrorMessage);
                erros.Add(new Error(item.ErrorMessage));
            }

            if (NomeDuplicado(veiculo))
                erros.Add(new Error("Nome duplicado"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private bool NomeDuplicado(Veiculo veiculo)
        {
            var veiculoEncontrado = repositorioVeiculo.SelecionarVeiculoPeloNome(veiculo.VeiculoNome);

            return veiculoEncontrado != null &&
                   veiculoEncontrado.VeiculoNome == veiculo.VeiculoNome;
                   
        }
    }
    
}
