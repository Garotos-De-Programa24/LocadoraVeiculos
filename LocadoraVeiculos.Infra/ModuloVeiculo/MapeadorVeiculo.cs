using System;
using System.Data.SqlClient;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculos.Infra.Compartilhado;
using LocadoraVeiculos.Infra.ModuloAgrupamento;

namespace LocadoraVeiculos.Infra.ModuloVeiculo
{
    public class MapeadorVeiculo : MapeadorBase<Veiculo>
    {
        public override void ConfigurarParametros(Veiculo registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.Cor);
            //comando.Parameters.AddWithValue("FOTO", registro.Foto);
            comando.Parameters.AddWithValue("VEICULONOME", registro.VeiculoNome);
            comando.Parameters.AddWithValue("MARCA", registro.Marca);
            comando.Parameters.AddWithValue("ANO", registro.Ano);
            comando.Parameters.AddWithValue("PLACA", registro.Placa);
            comando.Parameters.AddWithValue("CAPACIDADETANQUE", registro.CapacidadeTanque);
            comando.Parameters.AddWithValue("KMPERCORRIDO", registro.KmPercorridos);
            comando.Parameters.AddWithValue("COMBUSTIVEL", registro.Combustivel);
            comando.Parameters.AddWithValue("COR", registro.Cor);
            comando.Parameters.AddWithValue("AGRUPAMENTO_ID", registro.Agrupamento.Id);
        }

        public override Veiculo ConverterRegistro(SqlDataReader leitorRegistro)
        {
            if (leitorRegistro["ID"] == DBNull.Value)
                return null;

            //var foto = (byte[])(leitorRegistro["FOTO"]);
            var id = Guid.Parse(leitorRegistro["ID"].ToString());
            var veiculoNome = Convert.ToString(leitorRegistro["VEICULONOME"]);
            var marca = Convert.ToString(leitorRegistro["MARCA"]);
            var ano = Convert.ToString(leitorRegistro["ANO"]);
            var placa = Convert.ToString(leitorRegistro["PLACA"]);
            var capacidadetanque = Convert.ToString(leitorRegistro["CAPACIDADETANQUE"]);
            var kmpercorrido = Convert.ToString(leitorRegistro["KMPERCORRIDO"]);
            var combustivel = Convert.ToString(leitorRegistro["COMBUSTIVEL"]);
            var cor = Convert.ToString(leitorRegistro["COR"]);
            var agrupamento = new MapeadorAgrupamento().ConverterRegistro(leitorRegistro);
            

            Veiculo veiculo = new Veiculo()
            {
                //Foto = foto,
                Id = id,
                Marca = marca,
                VeiculoNome = veiculoNome,
                Ano = ano,
                Placa = placa,
                CapacidadeTanque = capacidadetanque,
                KmPercorridos = kmpercorrido,
                Combustivel = combustivel,
                Cor = cor,
            };

            veiculo.Agrupamento = agrupamento;

            return veiculo;
        }
    }
}
          
        
    

