using LocadoraVeiculos.Dominio.ModuloAgrupamento;
using LocadoraVeiculos.Infra.Compartilhado;
using System;
using System.Data.SqlClient;

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

            var id = Guid.Parse(leitorRegistro["ID"].ToString());
            var nome = Convert.ToString(leitorRegistro["AGRUPAMENTO"]);            

            Agrupamento agrupamento = new Agrupamento();
            agrupamento.Id = id;
            agrupamento.Nome = nome;

            return agrupamento;
        }
    }
}
