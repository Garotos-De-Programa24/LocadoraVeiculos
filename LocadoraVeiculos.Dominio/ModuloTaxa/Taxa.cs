using LocadoraVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.ModuloTaxa
{
    public class Taxa : EntidadeBase<Taxa>
    {
        public Taxa()
        {

        }
        public Taxa(string equipamento, string valor, string descricao,bool taxaDiaria)
        {
            Equipamento = equipamento;
            Valor = valor;
            Descricao = descricao;
            TaxaDiaria = taxaDiaria;
        }
        public string Equipamento { get; set; }
        public string Valor { get; set; }
        public string Descricao { get; set; }
        public bool TaxaDiaria { get; set; }

        public override void Atualizar(Taxa Registro)
        {
            throw new NotImplementedException();
        }
        public override bool Equals(object obj)
        {
            Taxa taxa = obj as Taxa;

            if (taxa == null)
                return false;

            return
                taxa.Id.Equals(Id) &&
                taxa.Equipamento.Equals(Equipamento) &&
                taxa.Descricao.Equals(Descricao) &&
                taxa.Valor.Equals(Valor)&&
                taxa.TaxaDiaria.Equals(TaxaDiaria);
        }
    }
}
