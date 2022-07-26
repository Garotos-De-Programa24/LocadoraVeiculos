using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloAgrupamento;
using System;


namespace LocadoraVeiculos.Dominio.ModuloPlanoDeCobranca
{
    public class PlanoCobranca : EntidadeBase <PlanoCobranca>
    {
        public PlanoCobranca()
        {
            GrupoVeiculos = new Agrupamento();
        }

        public PlanoCobranca(Agrupamento grupoVeiculo,string nomePlano, EnunPlano tipoPlano, decimal valorDiario, decimal valorPorKm, decimal limiteQuilometragem)
        {
            this.GrupoVeiculos = grupoVeiculo;
            NomePlano = nomePlano;
            TipoPlano = tipoPlano;
            this.valorDiario = valorDiario;
            this.valorPorKm = valorPorKm;
            this.limiteQuilometragem = limiteQuilometragem;
        }

        public Guid GrupoVeiculosId { get; set; }

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

        public override void Atualizar(PlanoCobranca Registro)
        {
            throw new NotImplementedException();
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
    }
}
