using LocadoraVeiculos.Apresentacao.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloPlanoDeCobranca;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.Apresentacao.ModuloPlanoDeCobranca
{
    public partial class TelaPlanoCobrancaControl : UserControl
    {
        public TelaPlanoCobrancaControl()
        {
            InitializeComponent();
            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},
                new DataGridViewTextBoxColumn { DataPropertyName = "NOMEPLANO", HeaderText = "Nome do Plano"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Grupo de Veículos", HeaderText = "Grupo de Veículos"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Tipo do Plano", HeaderText = "Tipo do Plano"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Valor da Diaria", HeaderText = "Valor da Diaria"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Valor por Km", HeaderText = "Valor por Km"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Limite de Quilometragem", HeaderText = "Limite de Quilometragem"},
            };
            return colunas;
        }
        public void AtualizarRegistros(List<PlanoCobranca> planoDeCobranca)
        {
            grid.Rows.Clear();

            foreach (var plano in planoDeCobranca)
            {
                if (plano.TipoPlano == EnunPlano.Livre) { 
                grid.Rows.Add(plano.Id, plano.NomePlano, plano.GrupoVeiculos.Nome,
                    plano.TipoPlano, "R$"+plano.ValorDiario,"-","-");
                }else if(plano.TipoPlano == EnunPlano.Diario)
                {
                    grid.Rows.Add(plano.Id, plano.NomePlano, plano.GrupoVeiculos.Nome,
                    plano.TipoPlano,"R$"+plano.ValorDiario,"R$" + plano.ValorPorKm, "-");
                }else if(plano.TipoPlano == EnunPlano.Controlado)
                {
                    grid.Rows.Add(plano.Id, plano.NomePlano, plano.GrupoVeiculos.Nome,
                    plano.TipoPlano,"R$" + plano.ValorDiario, "R$" + plano.ValorPorKm, plano.LimiteQuilometragem );
                }
            }
        }

        public Guid ObtemNumeroPlanoCobrancaSelecionado()
        {
            return grid.SelecionarNumero<Guid>();
        }

    
    }
}
