using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.ModuloVeiculo
{
    public class Cor
    {
        public string CorNome { get; set; } 

        public Cor(string cor)
        {
            CorNome = cor;
        }
    }
}
