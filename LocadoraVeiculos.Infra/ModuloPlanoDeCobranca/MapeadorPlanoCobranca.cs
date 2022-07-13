using LocadoraVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraVeiculos.Infra.Compartilhado;
using LocadoraVeiculos.Infra.ModuloAgrupamento;
using System;
using System.Data.SqlClient;

namespace LocadoraVeiculos.Infra.ModuloPlanoDeCobranca
{
    public class MapeadorPlanoCobranca : MapeadorBase<PlanoCobranca>
    {
        public override void ConfigurarParametros(PlanoCobranca registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.Id);
            comando.Parameters.AddWithValue("NOMEPLANO", registro.NomePlano);
            comando.Parameters.AddWithValue("TIPOPLANO", registro.TipoPlano);
            comando.Parameters.AddWithValue("VALOR_LIVRE", registro.ValorDiario);
            comando.Parameters.AddWithValue("VALOR_DIARIO", registro.ValorPorKm);
            comando.Parameters.AddWithValue("VALOR_CONTROLADO", registro.LimiteQuilometragem);
            comando.Parameters.AddWithValue("AGRUPAMENTO_ID", registro.GrupoVeiculos.Id);
        }

        public override PlanoCobranca ConverterRegistro(SqlDataReader leitorRegistro)
        {
            var id = Guid.Parse(leitorRegistro["ID"].ToString());
            var nomePlano = Convert.ToString(leitorRegistro["NOMEPLANO"]);
            var tipoPlano = Convert.ToInt32(leitorRegistro["TIPOPLANO"]);
            var valorLivre = Convert.ToString(leitorRegistro["VALOR_LIVRE"]);
            var valorDiario = Convert.ToString(leitorRegistro["VALOR_DIARIO"]);
            var valorControlado = Convert.ToString(leitorRegistro["VALOR_CONTROLADO"]);
            var agrupamentoId = Guid.Parse(leitorRegistro["AGRUPAMENTO_ID"].ToString());

            var agrupamento = new MapeadorAgrupamento().ConverterRegistro(leitorRegistro);

            PlanoCobranca novoPlano = new PlanoCobranca();
            agrupamento.Id = agrupamentoId;
            novoPlano.Id = id;
            novoPlano.NomePlano = nomePlano;
            novoPlano.TipoPlano = (EnunPlano)tipoPlano;
            novoPlano.SetValorDiario(valorLivre);
            novoPlano.SetValorPorKm(valorDiario);
            novoPlano.SetLimiteQuilometragem(valorControlado);

            novoPlano.GrupoVeiculos = agrupamento;

            return novoPlano;

        }
    }
}
