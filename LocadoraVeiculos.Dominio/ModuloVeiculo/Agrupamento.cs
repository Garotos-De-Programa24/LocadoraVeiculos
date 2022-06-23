using LocadoraVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.ModuloVeiculo
{
    public class Agrupamento : EntidadeBase<Agrupamento>
    {
        public string NomeAgrupamento { get; set; }
       
        public override void Atualizar(Agrupamento Registro)
        {
            throw new NotImplementedException();
        }
    }
}
