using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloAgrupamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Aplicacao.ModuloAgrupamento
{
    public class ServicoAgrupamento
    {
        private IRepositorioAgrupamento repositorioAgrupamento;
        public ServicoAgrupamento(IRepositorioAgrupamento repositorioAgrupamento)
        {
            this.repositorioAgrupamento = repositorioAgrupamento;
        }
        public ValidationResult Inserir(Agrupamento agrupamento)
        {
            ValidationResult resultadoValidacao = Validar(agrupamento);

            if (resultadoValidacao.IsValid)
                repositorioAgrupamento.Inserir(agrupamento);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Agrupamento funcionario)
        {
            ValidationResult resultadoValidacao = Validar(funcionario);

            if (resultadoValidacao.IsValid)
                repositorioAgrupamento.Editar(funcionario);

            return resultadoValidacao;
        }

        private ValidationResult Validar(Agrupamento agrupamento)
        {
            var validador = new ValidaAgrupamento();

            var resultadoValidacao = validador.Validate(agrupamento);

            if (NomeDuplicado(agrupamento))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "Nome duplicado"));

            return resultadoValidacao;
        }

        private bool NomeDuplicado(Agrupamento agrupamento)
        {
            var agrupamentoEncontrado = repositorioAgrupamento.SelecionarAgrupamentoPorNome(agrupamento.Nome);

            return agrupamentoEncontrado != null &&
                   agrupamentoEncontrado.Nome == agrupamento.Nome &&
                   agrupamentoEncontrado.Id != agrupamento.Id;
        }

       
    }
}
