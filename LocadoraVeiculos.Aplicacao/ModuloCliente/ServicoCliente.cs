using FluentResults;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloCliente;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Aplicacao.ModuloCliente
{
    public class ServicoCliente
    {
        private IRepositorioCliente repositorioCliente;

        public ServicoCliente(IRepositorioCliente repositorioCliente)
        {
            this.repositorioCliente = repositorioCliente;
        }

        public Result<Cliente> Inserir(Cliente cliente)
        {
            Log.Logger.Information("Tentando inserir no cliente @{cliente", cliente);

            Result resultadoValidacao = ValidarCliente(cliente);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir cliente {ClienteNome}" +
                        " -> Motivo: {erro}", cliente.Id, erro.Message);
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
                repositorioCliente.Inserir(cliente);

                Log.Logger.Information("Cliente {ClienteNome} inserido com sucesso.", cliente.Id);

                return Result.Ok(cliente);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar cadastrar um novo cliente";


                Log.Logger.Error(ex, msgErro + "{ClienteId}", cliente.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Cliente> Editar(Cliente cliente)
        {
            Log.Logger.Information("Tentando inserir no cliente @{cliente", cliente);

            Result resultadoValidacao = ValidarCliente(cliente);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir cliente {ClienteNome}" +
                        " -> Motivo: {erro}", cliente.Id, erro.Message);
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
                repositorioCliente.Editar(cliente);

                Log.Logger.Information("Cliente {ClienteNome} inserido com sucesso.", cliente.Id);

                return Result.Ok(cliente);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar cadastrar um novo cliente";


                Log.Logger.Error(ex, msgErro + "{ClienteId}", cliente.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Cliente> Excluir(Cliente cliente)
        {
            Log.Logger.Information("Tentando inserir no cliente @{cliente", cliente);

            Result resultadoValidacao = ValidarCliente(cliente);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar excluir cliente {ClienteNome}" +
                        " -> Motivo: {erro}", cliente.Id, erro.Message);
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
                repositorioCliente.Excluir(cliente);

                Log.Logger.Information("Cliente {ClienteNome} inserido com sucesso.", cliente.Id);

                return Result.Ok(cliente);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar cadastrar um novo cliente";

                Log.Logger.Error(ex, msgErro + "{ClienteId}", cliente.Id);

                return Result.Fail(msgErro);
            }
        }
        

        private Result ValidarCliente(Cliente cliente)
        {
            var validador = new ValidaCliente();

            var resultadoValidacao = validador.Validate(cliente);

            List<Error> erros = new List<Error>();

            foreach (ValidationFailure item in resultadoValidacao.Errors)
            {
                erros.Add(new Error(item.ErrorMessage));
            }

            if (NomeDuplicado(cliente))
                erros.Add(new Error("Nome duplicado"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private bool NomeDuplicado(Cliente funcionario)
        {
            var funcionarioEncontrado = repositorioCliente.SelecionarClientePorNome(funcionario.Nome);

            return funcionarioEncontrado != null &&
                   funcionarioEncontrado.Nome == funcionario.Nome &&
                   funcionarioEncontrado.Id != funcionario.Id;
        }

        public Result<List<Cliente>>SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioCliente.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no Sistema ao tentar selecionar todos os clientes";

                Log.Logger.Error(ex,msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Cliente> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioCliente.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no Sistema ao tentar selecionar o cliente";

                Log.Logger.Error(ex, msgErro + "{clienteId}", id);

                return Result.Fail(msgErro);
            }
        }
    }
}
