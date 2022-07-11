using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraVeiculos.Dominio.ModuloAgrupamento;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculos.Infra.Compartilhado;

namespace LocadoraVeiculos.Infra.ModuloVeiculo
{
    public class MapeadorVeiculo : MapeadorBase<Veiculo>
    {
        public override void ConfigurarParametros(Veiculo registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.Cor);
            comando.Parameters.AddWithValue("CLIENTE_ID", registro.VeiculoNome);
            comando.Parameters.AddWithValue("MARCA", registro.Marca);
            comando.Parameters.AddWithValue("ANO", registro.Ano);
            comando.Parameters.AddWithValue("PLACA", registro.Placa);
            comando.Parameters.AddWithValue("CAPACIDADETANQUE", registro.CapacidadeTanque);
            comando.Parameters.AddWithValue("KMPERCORRIDO", registro.KmPercorridos);
            comando.Parameters.AddWithValue("COMBUSTIVEL", registro.Combustivel);
            comando.Parameters.AddWithValue("AGRUPAMENTO", registro.Agrupamento);
        }

        public override Veiculo ConverterRegistro(SqlDataReader leitorRegistro)
        {
            if (leitorRegistro["ID"] == DBNull.Value)
                return null;


            var cor = Convert.ToString(leitorRegistro["COR"]);
            var veiculoNome = Convert.ToString(leitorRegistro["VEICULONOME"]);
            var marca = Convert.ToString(leitorRegistro["MARCA"]);
            var ano = Convert.ToString(leitorRegistro["ANO"]);
            var placa = Convert.ToString(leitorRegistro["PLACA"]);
            var capacidadetanque = Convert.ToString(leitorRegistro["CAPACIDADETANQUE"]);
            var kmpercorrido = Convert.ToString(leitorRegistro["KMPERCORRIDO"]);
            var combustivel = Convert.ToString(leitorRegistro["COMBUSTIVEL"]);
            var agrupamento = Convert.ToInt32(leitorRegistro["AGRUPAMENTO_ID"]);



            Veiculo veiculo = new Veiculo()
            {
                Marca = marca,
                VeiculoNome = veiculoNome,
                Ano = ano,
                Placa = placa,
                CapacidadeTanque = capacidadetanque,
                KmPercorridos = kmpercorrido,
                Combustivel = combustivel,
                Cor = cor,

            }
            ;
            veiculo.Agrupamento = new Agrupamento();
            return veiculo;
        }
    }
}
          
        
    

