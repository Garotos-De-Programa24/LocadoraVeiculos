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
        public Equipamento Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }

        public override void Atualizar(Taxa Registro)
        {
            throw new NotImplementedException();
        }
    }
}
