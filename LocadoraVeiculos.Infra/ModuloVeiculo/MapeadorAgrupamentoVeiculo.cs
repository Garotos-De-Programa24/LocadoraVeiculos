using LocadoraVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculos.Infra.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.ModuloVeiculo
{
    public class MapeadorAgrupamentoVeiculo : MapeadorBase<AgrupamentoVeiculo>
    {
        public override void ConfigurarParametros(AgrupamentoVeiculo registro, SqlCommand comando)
        {
            throw new NotImplementedException();
        }

        public override AgrupamentoVeiculo ConverterRegistro(SqlDataReader leitorRegistro)
        {
            throw new NotImplementedException();
        }
    }
}
