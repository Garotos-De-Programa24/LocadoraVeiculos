using LocadoraVeiculos.Dominio.Compartilhado;
using System;

namespace LocadoraVeiculos.Dominio.ModuloVeiculo
{
    public class Agrupamento : EntidadeBase<Agrupamento>
    {
        public Agrupamento() { }
        public Agrupamento(string nomeGrupo)
        {
            NomeAgrupamento = nomeGrupo;
        }
        public string NomeAgrupamento { get; set; }
       
        public override void Atualizar(Agrupamento Registro)
        {
            throw new NotImplementedException();
        }
    }
}
