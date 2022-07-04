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
            ValorDiario = valorDiario;
            ValorPorKm = valorPorKm;
            LimiteQuilometragem = limiteQuilometragem;
        }

        public string NomePlano { get; set; }
        public Agrupamento GrupoVeiculos { get; set; }
        public EnunPlano TipoPlano { get; set; }
        public decimal ValorDiario { get; set; }
        public decimal ValorPorKm { get; set; }
        public decimal LimiteQuilometragem { get; set; }

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
                plano.ValorDiario.Equals(ValorDiario) &&
                plano.ValorPorKm.Equals(ValorPorKm) &&
                plano.LimiteQuilometragem.Equals(LimiteQuilometragem);
        }
    }
}
