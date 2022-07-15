using FluentResults;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using Serilog;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Aplicacao.ModuloFuncionario
{
    public class ServicoFuncionario
    {
        private IRepositorioFuncionario repositorioFuncionario;
        public ServicoFuncionario(IRepositorioFuncionario repositorioFuncionario)
        {
            this.repositorioFuncionario = repositorioFuncionario;
        }
        public ValidationResult Inserir(Funcionario funcionario)
        {
            Log.Logger.Debug("Tentando inserir funcionário {@funcionario}", funcionario);

            ValidationResult resultadoValidacao = Validar(funcionario);

            if (resultadoValidacao.IsValid)
            {
                repositorioFuncionario.Inserir(funcionario);
                Log.Logger.Information("Funcionário {FuncionarioId} inserido com sucesso", funcionario.Id);

            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir um Funcionário {FuncionarioId} - {Motivo}",
                        funcionario.Nome, erro.ErrorMessage);
                }
            }
            return resultadoValidacao;
        }

        public ValidationResult Editar(Funcionario funcionario)
        {
            Log.Logger.Debug("Tentando editar funcionário {@funcionario}", funcionario);

            ValidationResult resultadoValidacao = Validar(funcionario);

            if (resultadoValidacao.IsValid)
            {
                Log.Logger.Information("Funcionário {FuncionarioId} editado com sucesso", funcionario.Id);
                repositorioFuncionario.Editar(funcionario);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar um Funcionário {FuncionarioId} - {Motivo}",funcionario.Id, erro.ErrorMessage);
                }
            }
            return resultadoValidacao;
        }
        public ValidationResult Excluir(Funcionario funcionario)
        {
            Log.Logger.Debug("Tentando excluir funcionário {@funcionario}", funcionario);

            ValidationResult resultadoValidacao = Validar(funcionario);

            if (resultadoValidacao.IsValid)
            {
                Log.Logger.Information("Funcionário {FuncionarioId} excluido com sucesso", funcionario.Id);
                repositorioFuncionario.Excluir(funcionario);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar excluir o Funcionário {FuncionarioId} - {Motivo}", funcionario.Id, erro.ErrorMessage);
                }
            }
            return resultadoValidacao;
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

        private ValidationResult Validar(Funcionario funcionario)
        {
            var validador = new ValidaFuncionario();

            var resultadoValidacao = validador.Validate(funcionario);

            if (NomeDuplicado(funcionario))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "Nome duplicado"));

            if (UsuarioDuplicado(funcionario))
                resultadoValidacao.Errors.Add(new ValidationFailure("Login", "Login duplicado"));

            return resultadoValidacao;
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
