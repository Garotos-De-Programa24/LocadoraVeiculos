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
            Taxas = new List<Taxa>();
        }

        public Locacao(Funcionario funcionario,Cliente cliente, Condutor condutor,Agrupamento agrupamento,
            Veiculo veiculo,PlanoCobranca planoCobranca)
        {

            this.Funcionario = funcionario;
            Cliente = cliente;
            Condutor = condutor;
            Agrupamento = agrupamento;
            Veiculo = veiculo;
            Plano = planoCobranca;
                 
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
        public Guid TaxasId { get; set; }
        public DateTime DataLocacao { get; set; }

        public DateTime DataDevolucao { get; set; }

        public DateTime? DataEntrega { get; set; }
        
        public decimal ValorInicio { get; set; }
        public decimal? ValorFinal { get; set; }

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
                   TaxasId.Equals(locacao.TaxasId) &&
                   DataLocacao == locacao.DataLocacao &&
                   DataDevolucao == locacao.DataDevolucao &&
                   DataEntrega == locacao.DataEntrega &&
                   ValorInicio == locacao.ValorInicio &&
                   ValorFinal == locacao.ValorFinal;
        }
    }
}
