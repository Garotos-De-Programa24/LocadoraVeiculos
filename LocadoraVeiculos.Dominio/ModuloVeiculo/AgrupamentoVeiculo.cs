﻿using LocadoraVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.ModuloVeiculo
{
    public class AgrupamentoVeiculo : EntidadeBase<AgrupamentoVeiculo>
    {
        public string NomeAgrupamento { get; set; }
        public List<Veiculo> Veiculos { get; set; }
       
        public override void Atualizar(AgrupamentoVeiculo Registro)
        {
            throw new NotImplementedException();
        }
    }
}
