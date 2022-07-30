using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloAgrupamento;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloCondutor;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraVeiculos.Dominio.ModuloTaxa;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Dominio.ModuloLocação
{
    public class Locacao : EntidadeBase<Locacao>
    {
        public Locacao()
        {
            Funcionario = new Funcionario();
            Cliente = new Cliente();
            Condutor = new Condutor();
            Agrupamento = new Agrupamento();
            Veiculo = new Veiculo();
            Plano = new PlanoCobranca();
            Taxas = new List<Taxa>();            
        }

        public Funcionario Funcionario { get; set; }
        public Guid FuncionarioId { get; set; }

        public Cliente Cliente { get; set; }
        public Guid ClienteId { get; set; }
        public Condutor Condutor { get; set; }
        public Guid CondutorId { get; set; }
        public Agrupamento Agrupamento { get; set; }
        public Guid AgrupamentoId { get; set; }
        public Veiculo Veiculo { get; set; }
        public Guid VeiculoId { get; set; }
        public PlanoCobranca Plano { get; set; }
        public Guid PlanoId { get; set; }
        public List<Taxa> Taxas { get; set; }
        public Guid TaxaId { get; set; }
        public DateTime DataLocacao { get; set; }

        public DateTime DataDevolucao { get; set; }

        public decimal ValorInicio { get; set; }
        public decimal ValorFinal { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Locacao locacao &&
                   Id.Equals(locacao.Id) &&
                   EqualityComparer<Funcionario>.Default.Equals(Funcionario, locacao.Funcionario) &&
                   FuncionarioId.Equals(locacao.FuncionarioId) &&
                   EqualityComparer<Cliente>.Default.Equals(Cliente, locacao.Cliente) &&
                   ClienteId.Equals(locacao.ClienteId) &&
                   EqualityComparer<Condutor>.Default.Equals(Condutor, locacao.Condutor) &&
                   CondutorId.Equals(locacao.CondutorId) &&
                   EqualityComparer<Agrupamento>.Default.Equals(Agrupamento, locacao.Agrupamento) &&
                   AgrupamentoId.Equals(locacao.AgrupamentoId) &&
                   EqualityComparer<Veiculo>.Default.Equals(Veiculo, locacao.Veiculo) &&
                   VeiculoId.Equals(locacao.VeiculoId) &&
                   EqualityComparer<PlanoCobranca>.Default.Equals(Plano, locacao.Plano) &&
                   PlanoId.Equals(locacao.PlanoId) &&
                   EqualityComparer<List<Taxa>>.Default.Equals(Taxas, locacao.Taxas) &&
                   TaxaId.Equals(locacao.TaxaId) &&
                   DataLocacao == locacao.DataLocacao &&
                   DataDevolucao == locacao.DataDevolucao &&
                   ValorInicio == locacao.ValorInicio &&
                   ValorFinal == locacao.ValorFinal;
        }



        //public override bool Equals(object obj)
        //{
        //    Locacao locacao = obj as Locacao;

        //    if (locacao == null)
        //        return false;

        //    return
        //        locacao.Funcionario.Id.Equals(Funcionario.Id) &&
        //        locacao.Cliente.Id.Equals(Cliente.Id) &&
        //        locacao.Agrupamento.Id.Equals(Agrupamento.Id) &&
        //        locacao.Veiculo.Id.Equals(Veiculo.Id) &&
        //        locacao.Plano.Id.Equals(Plano.Id) &&
        //        locacao.Taxas.Id.Equals(Taxa.Id) &&
        //        locacao.DataLocacao.Equals(DataLocacao) &&
        //        locacao.DataDevolucao.Equals(DataDevolucao);                
        //}
    }
}
