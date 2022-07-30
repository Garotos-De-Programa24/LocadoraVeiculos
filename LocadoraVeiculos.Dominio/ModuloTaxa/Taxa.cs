using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloLocação;
using System.Collections.Generic;


namespace LocadoraVeiculos.Dominio.ModuloTaxa
{
    public class Taxa : EntidadeBase<Taxa>
    {
        public Taxa(){}
        public Taxa(string equipamento, string valor, bool taxaDiaria)
        {
            Equipamento = equipamento;
            Valor = valor;            
            TaxaDiaria = taxaDiaria;
        }
        public string Equipamento { get; set; }
        public string Valor { get; set; }        
        public bool TaxaDiaria { get; set; }
        public List<Locacao> Locacoes { get; set; }
        public int QuantidadePorLocacao { get; set; }

        
        public override bool Equals(object obj)
        {
            Taxa taxa = obj as Taxa;

            if (taxa == null)
                return false;

            return
                taxa.Id.Equals(Id) &&
                taxa.Equipamento.Equals(Equipamento) &&                
                taxa.Valor.Equals(Valor)&&
                taxa.TaxaDiaria.Equals(TaxaDiaria) &&
                taxa.QuantidadePorLocacao.Equals(QuantidadePorLocacao);
        }
        public override string ToString()
        {
            string tipoTaxa = "";
            if (TaxaDiaria == true)
                tipoTaxa = "Diaria";
            else
                tipoTaxa = "Fixa";
            return string.Format("{0}   R${1}   {2}\n",Equipamento,Valor,tipoTaxa);
        }
    }
}
