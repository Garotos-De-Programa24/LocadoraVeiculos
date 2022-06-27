using LocadoraVeiculos.Dominio.ModuloAgrupamento;
using LocadoraVeiculos.Infra.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.ModuloAgrupamento
{
    public class MapeadorAgrupamento : MapeadorBase<Agrupamento>
    {
        public override void ConfigurarParametros(Agrupamento registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.Id);
            comando.Parameters.AddWithValue("AGRUPAMENTO", registro.Nome);            
        }

        public override Agrupamento ConverterRegistro(SqlDataReader leitorRegistro)
        {
            if (leitorRegistro["ID"] == DBNull.Value)
                return null;

            var id = Convert.ToInt32(leitorRegistro["ID"]);
            var nome = Convert.ToString(leitorRegistro["AGRUPAMENTO"]);            

            Agrupamento agrupamento = new Agrupamento();
            agrupamento.Id = id;
            agrupamento.Nome = nome;

            return agrupamento;
        }
    }
}
