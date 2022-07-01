using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloAgrupamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.ModuloPlanoDeCobranca
{
    public class PlanoCobranca : EntidadeBase <PlanoCobranca>
    {
        public PlanoCobranca()
        {
        }

        public PlanoCobranca(string nomePlano, Agrupamento grupoVeiculos, TipoPlano tipoPlano, decimal livre, decimal diario, decimal controlado)
        {
            NomePlano = nomePlano;
            GrupoVeiculos = grupoVeiculos;
            Plano = tipoPlano;
            Livre = livre;
            Diario = diario;
            Controlado = controlado;
        }

        public string NomePlano { get; set; }
        public Agrupamento GrupoVeiculos { get; set; }
        public TipoPlano Plano { get; set; }
        public decimal Livre { get; set; }
        public decimal Diario { get; set; }
        public decimal Controlado { get; set; }

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
                plano.Plano.Equals(Plano) &&
                plano.Livre.Equals(Livre) &&
                plano.Diario.Equals(Diario) &&
                plano.Controlado.Equals(Controlado);
        }
    }
}
