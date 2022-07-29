using FluentResults;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloCondutor;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Aplicacao.ModuloCondutor
{
    public class ServicoCondutor
    {
        private IRepositorioCondutor repositorioCondutor;
        private IContextoPersistencia contextoDados;

        public ServicoCondutor(IRepositorioCondutor repositorioCondutor, IContextoPersistencia contextoDados)
        {
            this.contextoDados = contextoDados;
            this.repositorioCondutor = repositorioCondutor;
        }

        public Result<Condutor> Inserir(Condutor condutor)
        {
            Log.Logger.Information("Tentando inserir no Condutor @{condutor}", condutor);

            Result resultadoValidacao = ValidarCondutor(condutor);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir Condutor {CondutorNome}" +
                        " -> Motivo: {erro}", condutor.Id, erro.Message);
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
                repositorioCondutor.Inserir(condutor);
                contextoDados.GravarDados();
                Log.Logger.Information("Condutor {CondutorId} inserido com sucesso.", condutor.Id);

                return Result.Ok(condutor);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar cadastrar um novo condutor";


                Log.Logger.Error(ex, msgErro + "{CondutorId}", condutor.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Condutor> Editar(Condutor condutor)
        {
            Log.Logger.Information("Tentando editar Condutor @{condutor}", condutor);

            Result resultadoValidacao = ValidarEdicaoCondutor(condutor);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar Condutor {CondutorId}" +
                        " -> Motivo: {erro}", condutor.Id, erro.Message);
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
                repositorioCondutor.Editar(condutor);
                contextoDados.GravarDados();

                Log.Logger.Information("Condutor {CondutorId} editado com sucesso.", condutor.Id);

                return Result.Ok(condutor);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar condutor";

                Log.Logger.Error(ex, msgErro + "{CondutorId}", condutor.Id);

                return Result.Fail(msgErro);
            }
        }

        

        public Result<Condutor> Excluir(Condutor condutor)
        {
            Log.Logger.Information("Tentando excluir o Condutor @{condutor}", condutor);
            
            try
            {
                repositorioCondutor.Excluir(condutor);
                contextoDados.GravarDados();

                Log.Logger.Information("Condutor {CondutorId} excluido com sucesso.", condutor.Id);

                return Result.Ok(condutor);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir condutor";

                Log.Logger.Error(ex, msgErro + "{CondutorId}", condutor.Id);

                return Result.Fail(msgErro);
            }
        }

        private Result ValidarEdicaoCondutor(Condutor condutor)
        {
            var validador = new ValidaCondutor();

            var resultadoValidacao = validador.Validate(condutor);

            List<Error> erros = new List<Error>();

            foreach (ValidationFailure item in resultadoValidacao.Errors)
            {
                erros.Add(new Error(item.ErrorMessage));
            }

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private Result ValidarCondutor(Condutor condutor)
        {
            var validador = new ValidaCondutor();

            var resultadoValidacao = validador.Validate(condutor);

            List<Error> erros = new List<Error>();

            foreach (ValidationFailure item in resultadoValidacao.Errors)
            {
                erros.Add(new Error(item.ErrorMessage));
            }

            if (NomeDuplicado(condutor))
                erros.Add(new Error("Nome duplicado"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private bool NomeDuplicado(Condutor condutor)
        {
            var funcionarioEncontrado = repositorioCondutor.SelecionarCondutorPorNome(condutor.Nome);

            return funcionarioEncontrado != null &&
                   funcionarioEncontrado.Nome == condutor.Nome &&
                   funcionarioEncontrado.Id != condutor.Id;
        }

        public Result<List<Condutor>> SelecionarTodos()
        {
            
            try
            {
                return Result.Ok(repositorioCondutor.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no Sistema ao tentar selecionar todos os condutores";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
            
        }

        public Result<Condutor> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioCondutor.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no Sistema ao tentar selecionar o condutor";

                Log.Logger.Error(ex, msgErro + "{CondutorId}", id);

                return Result.Fail(msgErro);
            }
        }        
    }
}
