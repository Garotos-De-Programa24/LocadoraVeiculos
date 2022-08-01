using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloAgrupamento;
using System;


namespace LocadoraVeiculos.Dominio.ModuloPlanoDeCobranca
{
    public class PlanoCobranca : EntidadeBase <PlanoCobranca>
    {
        public PlanoCobranca(){}

        public PlanoCobranca(Agrupamento grupoVeiculo,string nomePlano, EnunPlano tipoPlano, decimal valorDiario, decimal valorPorKm, decimal limiteQuilometragem)
        {
            this.GrupoVeiculos = grupoVeiculo;
            NomePlano = nomePlano;
            TipoPlano = tipoPlano;
            this.valorDiario = valorDiario;
            this.valorPorKm = valorPorKm;
            this.limiteQuilometragem = limiteQuilometragem;
        }

        public Guid? GrupoVeiculosId { get; set; }

        public string NomePlano { get; set; }

        public Agrupamento GrupoVeiculos { get; set; }

        public EnunPlano TipoPlano { get; set; }

        public decimal ValorDiario { get => valorDiario; }

        public decimal ValorPorKm { get => valorPorKm;  }

        public decimal LimiteQuilometragem { get => limiteQuilometragem;}

        private decimal valorDiario;
        private decimal valorPorKm;
        private decimal limiteQuilometragem;
        public void SetValorDiario(string valorDiario)
        {
            string valor = LimparString(valorDiario);
            if (valor == "")
                valor = "0";
            this.valorDiario = Convert.ToDecimal(valor);
        }
        public void SetValorPorKm(string valorPorKm)
        {
            string valor = LimparString(valorPorKm);
            if (valor == "")
                valor = "0";
            this.valorPorKm = Convert.ToDecimal(valor);
        }
        public void SetLimiteQuilometragem(string limiteQuilometragem)
        {
            string valor = LimparString(limiteQuilometragem);
            if (valor == "")
                valor = "0";
            this.limiteQuilometragem = Convert.ToDecimal(valor);
        }

        private string LimparString(string valorBrutoSemFormatar)
        {
            string strValor = valorBrutoSemFormatar;
            string[] charsToRemove = new string[] { ",", ".", "-" ," "};
            foreach (var c in charsToRemove)
            {
                strValor = strValor.Replace(c, string.Empty);
            }
            return strValor;
        }

        
        public override bool Equals(object obj)
        {
            PlanoCobranca plano = obj as PlanoCobranca;

            if (plano == null)
                return false;

            return
                plano.Id.Equals(Id) &&
                plano.NomePlano.Equals(NomePlano) &&
                plano.GrupoVeiculos.Equals(GrupoVeiculos) &&
                plano.TipoPlano.Equals(TipoPlano) &&
                plano.valorDiario.Equals(valorDiario) &&
                plano.valorPorKm.Equals(valorPorKm) &&
                plano.limiteQuilometragem.Equals(limiteQuilometragem);
        }
        private string ToStringDiario()
        {
            return string.Format("Nome do Plano: {0}\n Tipo do Plano: {1}\n" +
                "Valor Diario: R${2}\n",NomePlano,TipoPlano,ValorDiario);
        }
        private string ToStringPorKm()
        {
            return string.Format("Nome do Plano: {0}\n Tipo do Plano: {1}\n" +
                "Valor Diario: R${2}\n Valor por Km: R${3}", NomePlano, TipoPlano, ValorDiario,ValorPorKm);
        }
        private string ToStringLimiteQuilometragem()
        {
            return string.Format("Nome do Plano: {0}\nTipo do Plano: {1}\n" +
                "Valor Diario: R${2}\nValor por Km: R${3}\nLimite Quilometragem\n",NomePlano, TipoPlano, ValorDiario, ValorPorKm,LimiteQuilometragem);
        }
        public override string ToString()
        {
            if (this.TipoPlano == EnunPlano.Livre)
                return ToStringDiario();
            if (this.TipoPlano == EnunPlano.Diario)
                return ToStringPorKm();
            if (this.TipoPlano == EnunPlano.Controlado)
                return ToStringLimiteQuilometragem();

            return "Sem Tipo";
        }

    }
}
