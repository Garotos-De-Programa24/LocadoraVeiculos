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
            comando.Parameters.AddWithValue("VALOR", taxa.Valor);
            comando.Parameters.AddWithValue("TAXADIARIA", taxa.TaxaDiaria);

        }

        public override Taxa ConverterRegistro(SqlDataReader leitorTaxa)
        {
            var id = Guid.Parse(leitorTaxa["ID"].ToString());
            var equipamento = Convert.ToString(leitorTaxa["EQUIPAMENTO"]);            
            var valor = Convert.ToString(leitorTaxa["VALOR"]);
            var taxaDiaria = Convert.ToBoolean(leitorTaxa["TAXADIARIA"]);

            Taxa taxa = new Taxa(equipamento,valor,taxaDiaria);
            taxa.Id = id;

            return taxa;
        }
    }
}
