﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculos.Infra.Compartilhado;

namespace LocadoraVeiculos.Infra.ModuloVeiculo
{
    public class MapeadorVeiculo : MapeadorBase<Veiculo>
    {
        public override void ConfigurarParametros(Veiculo registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.Id);
            comando.Parameters.AddWithValue("CLIENTE_ID", registro.Cliente.Id);
            comando.Parameters.AddWithValue("NOME", registro.Nome);
            comando.Parameters.AddWithValue("CPF", registro.Cpf);
            comando.Parameters.AddWithValue("ENDERECO", registro.Endereco);
            comando.Parameters.AddWithValue("CNHCONDUTOR", registro.CnhCondutor);
            comando.Parameters.AddWithValue("VALIDADECNH", registro.ValidadeCnh);
            comando.Parameters.AddWithValue("EMAIL", registro.Email);
            comando.Parameters.AddWithValue("TELEFONE", registro.Telefone);
        }

        public override Veiculo ConverterRegistro(SqlDataReader leitorRegistro)
        {
            if (leitorRegistro["ID"] == DBNull.Value)
                return null;

            //cria o condutor
            var id = Convert.ToInt32(leitorRegistro["ID"]);
            var nome = Convert.ToString(leitorRegistro["NOME"]);
            var cpf = Convert.ToString(leitorRegistro["CPF"]);
            var endereco = Convert.ToString(leitorRegistro["ENDERECO"]);
            var cnhCondutor = Convert.ToString(leitorRegistro["CNHCONDUTOR"]);
            var validadeCnh = Convert.ToDateTime(leitorRegistro["VALIDADECNH"]);
            var email = Convert.ToString(leitorRegistro["EMAIL"]);
            var telefone = Convert.ToString(leitorRegistro["TELEFONE"])



            Condutor condutor = new Condutor()
            {
                Id = id,
                Nome = nome,
                Cpf = cpf,
                Email = email,
                Telefone = telefone,
                Endereco = endereco,
                CnhCondutor = cnhCondutor,
                ValidadeCnh = validadeCnh,
            };

            //cria o cliente
            var cliente_id = Convert.ToInt32(leitorRegistro["CLIENTE_ID"]);
            var cliente_nome = Convert.ToString(leitorRegistro["CLIENTE_NOME"]);
            var cliente_cpfcnpj = Convert.ToString(leitorRegistro["CPFCNPJ"]);
            var cliente_endereco = Convert.ToString(leitorRegistro["CLIENTE_ENDERECO"]);
            var cliente_email = Convert.ToString(leitorRegistro["CLIENTE_EMAIL"]);
            var cliente_telefone = Convert.ToString(leitorRegistro["CLIENTE_TELEFONE"]);

            condutor.Cliente = new Cliente()
            {
                Id = cliente_id,
                Nome = cliente_nome,
                CpfCnpj = cliente_cpfcnpj,
                Endereco = cliente_endereco,
                Email = cliente_email,
                Telefone = cliente_telefone,
            };

            return condutor;
        }
    }
}
