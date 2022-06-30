using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Infra.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace LocadoraVeiculos.Infra.ModuloCliente
{
    public class MapeadorCliente : MapeadorBase<Cliente>
    {
        public override void ConfigurarParametros(Cliente registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.Id);
            comando.Parameters.AddWithValue("NOME", registro.Nome);
            comando.Parameters.AddWithValue("CPF", registro.Cpf);
            comando.Parameters.AddWithValue("ENDERECO", registro.Endereco);
            comando.Parameters.AddWithValue("EMAIL", registro.Email);
            comando.Parameters.AddWithValue("TELEFONE", registro.Telefone);
        }

        public override Cliente ConverterRegistro(SqlDataReader leitorRegistro)
        {
            if(leitorRegistro["ID"] == DBNull.Value)
                return null;

            var id = Convert.ToInt32(leitorRegistro["ID"]);
            var nome = Convert.ToString(leitorRegistro["NOME"]);
            var cpf = Convert.ToString(leitorRegistro["CPF"]);
            var endereco = Convert.ToString(leitorRegistro["ENDERECO"]);
            var email = Convert.ToString(leitorRegistro["EMAIL"]);
            var telefone = Convert.ToString(leitorRegistro["TELEFONE"]);

            Cliente cliente = new Cliente();
            cliente.Id = id;
            cliente.Nome = nome;
            cliente.Cpf = cpf;
            cliente.Endereco = endereco;
            cliente.Email = email;
            cliente.Telefone = telefone;
            
            return cliente;
        }
    }
}
