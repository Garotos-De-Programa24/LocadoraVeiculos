using FluentResults;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Aplicacao.ModuloFuncionario
{
    public class ServicoFuncionario
    {
        private IRepositorioFuncionario repositorioFuncionario;
        private IContextoPersistencia contextoDados;
        public ServicoFuncionario(IRepositorioFuncionario repositorioFuncionario,IContextoPersistencia contextoDados)
        {
            this.contextoDados = contextoDados;
            this.repositorioFuncionario = repositorioFuncionario;
        }
        public Result<Funcionario> Inserir(Funcionario funcionario)
        {
            Log.Logger.Debug("Tentando inserir funcionário {@funcionario}", funcionario);

            Result resultadoValidacao = ValidarFuncionario(funcionario);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir um Funcionário {FuncionarioId} - {Motivo}",
                       funcionario.Nome, erro.Message);
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
                repositorioFuncionario.Inserir(funcionario);

                contextoDados.GravarDados();

                Log.Logger.Information("Funcionário {FuncionarioId} inserido com sucesso", funcionario.Id);
                return Result.Ok(funcionario);

            }
            catch (Exception ex)
            {
                string mensagemErro = "Falha no sistema ao tentar selecionar o Funcionario";
                Log.Logger.Error(ex, mensagemErro + "{FuncionarioId}", funcionario.Id);
                return Result.Fail(mensagemErro);
            }
        }

        public Result<Funcionario> Editar(Funcionario funcionario)
        {
            Log.Logger.Debug("Tentando editar funcionário {@funcionario}", funcionario);

            Result resultadoValidacao = ValidarEdicaoFuncionario(funcionario);

            if (resultadoValidacao.IsFailed)
            {
                foreach(var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar um Funcionário {FuncionarioId} - {Motivo}", funcionario.Id, erro.Message);
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
                repositorioFuncionario.Editar(funcionario);

                contextoDados.GravarDados();


                Log.Logger.Information("Funcionário {FuncionarioId} editado com sucesso", funcionario.Id);

                return Result.Ok(funcionario);
            }
            catch(Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o funcionário";

                Log.Logger.Error(ex, msgErro + "{FuncionarioId}", funcionario.Id);

                return Result.Fail(msgErro);
            }
        }
        public Result<Funcionario> Excluir(Funcionario funcionario)
        {
            Log.Logger.Information("Tentando excluir o Funcionario @{funcionario}", funcionario);
                        
            try
            {
                repositorioFuncionario.Excluir(funcionario);

                contextoDados.GravarDados();

                Log.Logger.Information("Funcionario {FuncionarioId} excluido com sucesso.", funcionario.Id);

                return Result.Ok(funcionario);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir funcionario";

                Log.Logger.Error(ex, msgErro + "{FuncionarioId}", funcionario.Id);

                return Result.Fail(msgErro);
            }
           
        }        

        public Result<List<Funcionario>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioFuncionario.SelecionarTodos());

            } 
            catch (Exception ex)
            {
                string mensagemErro = "Falha no sistema ao tentar selecionar todos os Funcionarios";
                Log.Logger.Error(ex, mensagemErro);
                return Result.Fail(mensagemErro);
            }
        }
        public Result<Funcionario> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioFuncionario.SelecionarPorId(id));

            }
            catch (Exception ex)
            {
                string mensagemErro = "Falha no sistema ao tentar selecionar o Funcionario";
                Log.Logger.Error(ex, mensagemErro + "{FuncionarioId}", id);
                return Result.Fail(mensagemErro);
            }
        }

        private Result ValidarEdicaoFuncionario(Funcionario funcionario)
        {
            var validador = new ValidaFuncionario();

            var resultadoValidacao = validador.Validate(funcionario);

            List<Error> erros = new List<Error>();

            foreach (ValidationFailure item in resultadoValidacao.Errors)
            {
                erros.Add(new Error(item.ErrorMessage));
            }

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private Result ValidarFuncionario(Funcionario funcionario)
        {
            var validador = new ValidaFuncionario();

            var resultadoValidacao = validador.Validate(funcionario);

            List<Error> erros = new List<Error>(); //Fluent Result <<<<<<<<<<
             
            foreach(ValidationFailure item in resultadoValidacao.Errors) //Fluent Validation <<<<<<<<<
            {
                Log.Logger.Warning(item.ErrorMessage);
                erros.Add(new Error(item.ErrorMessage));
            }

            if (NomeDuplicado(funcionario))
                erros.Add(new Error("Nome duplicado"));

            if (UsuarioDuplicado(funcionario))
                erros.Add(new Error("Login duplicado"));
            
            if (erros.Any())
                return Result.Fail(erros);
            
            return Result.Ok();
        }

        private bool NomeDuplicado(Funcionario funcionario)
        {
            var funcionarioEncontrado = repositorioFuncionario.SelecionarFuncionarioPorNome(funcionario.Nome);

            return funcionarioEncontrado != null &&
                   funcionarioEncontrado.Nome == funcionario.Nome &&
                   funcionarioEncontrado.Id != funcionario.Id;
        }

        private bool UsuarioDuplicado(Funcionario funcionario)
        {
            var funcionarioEncontrado = repositorioFuncionario.SelecionarFuncionarioPorUsuario(funcionario.Login);

            return funcionarioEncontrado != null &&
                   funcionarioEncontrado.Login == funcionario.Login &&
                   funcionarioEncontrado.Id != funcionario.Id;
        }
    }
}
