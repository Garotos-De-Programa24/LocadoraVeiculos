using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloAgrupamento;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloCondutor;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraVeiculos.Dominio.ModuloTaxa;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using System;

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
            Taxa = new Taxa();            
        }

        public Funcionario Funcionario { get; set; }

        public Cliente Cliente { get; set; }

        public Condutor Condutor { get; set; }

        public Agrupamento Agrupamento { get; set; }

        public Veiculo Veiculo { get; set; }

        public PlanoCobranca Plano { get; set; }

        public Taxa Taxa { get; set; }

        public DateTime DataLocacao { get; set; }

        public DateTime DataDevolucao { get; set; }

        public override bool Equals(object obj)
        {
            Locacao locacao = obj as Locacao;

            if (locacao == null)
                return false;

            return
                locacao.Funcionario.Id.Equals(Funcionario.Id) &&
                locacao.Cliente.Id.Equals(Cliente.Id) &&
                locacao.Agrupamento.Id.Equals(Agrupamento.Id) &&
                locacao.Veiculo.Id.Equals(Veiculo.Id) &&
                locacao.Plano.Id.Equals(Plano.Id) &&
                locacao.Taxa.Id.Equals(Taxa.Id) &&
                locacao.DataLocacao.Equals(DataLocacao) &&
                locacao.DataDevolucao.Equals(DataDevolucao);                
        }
    }
}
