using LocadoraVeiculos.Dominio.ModuloTaxa;
using LocadoraVeiculos.Infra.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.ModuloTaxa
{
    public class MapeadorTaxa : MapeadorBase<Taxa>
    {
        public override void ConfigurarParametros(Taxa taxa, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", taxa.Id);
            comando.Parameters.AddWithValue("EQUIPAMENTO", taxa.Equipamento);
            comando.Parameters.AddWithValue("DESCRICAO", taxa.Descricao);
            comando.Parameters.AddWithValue("VALOR", taxa.Valor);
            comando.Parameters.AddWithValue("TAXADIARIA", taxa.TaxaDiaria);

        }

        public override Taxa ConverterRegistro(SqlDataReader leitorTaxa)
        {
            var id = Convert.ToInt32(leitorTaxa["ID"]);
            var equipamento = Convert.ToString(leitorTaxa["EQUIPAMENTO"]);
            var descricao = Convert.ToString(leitorTaxa["DESCRICAO"]);
            var valor = Convert.ToString(leitorTaxa["VALOR"]);
            var taxaDiaria = Convert.ToBoolean(leitorTaxa["TAXADIARIA"]);

            Taxa taxa = new Taxa(equipamento,valor,descricao,taxaDiaria);
            taxa.Id = id;

            return taxa;
        }
    }
}
