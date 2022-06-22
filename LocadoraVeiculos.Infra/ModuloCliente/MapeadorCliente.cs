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
                    //SÓ EXEMPLO MESMOOOO

            //comando.Parameters.AddWithValue("ID", registro.Id);
            //comando.Parameters.AddWithValue("NOME", registro.Nome);
            //comando.Parameters.AddWithValue("TELEFONE", registro.Telefone);
            //comando.Parameters.AddWithValue("EMAIL", registro.Email);
            //comando.Parameters.AddWithValue("CIDADE", registro.Cidade);
            //comando.Parameters.AddWithValue("ESTADO ", registro.Estado);
        }

        public override Cliente ConverterRegistro(SqlDataReader leitorRegistro)
        {

                    //SÓ EXEMPLO

            //if(leitorRegistro["FORNECEDOR_ID"] == DBNull.Value)
            //    return null;

            //var id = Convert.ToInt32(leitorRegistro["FORNECEDOR_ID"]);
            //var nome = Convert.ToString(leitorRegistro["FORNECEDOR_NOME"]);
            //var telefone = Convert.ToString(leitorRegistro["FORNECEDOR_TELEFONE"]);
            //var email = Convert.ToString(leitorRegistro["FORNECEDOR_EMAIL"]);
            //var cidade = Convert.ToString(leitorRegistro["FORNECEDOR_CIDADE"]);
            //var estado = Convert.ToString(leitorRegistro["FORNECEDOR_ESTADO"]);

            //Fornecedor fornecedor = new Fornecedor();
            //fornecedor.Id = id;
            //fornecedor.Nome = nome;
            //fornecedor.Telefone = telefone;
            //fornecedor.Email = email;
            //fornecedor.Cidade = cidade;
            //fornecedor.Estado = estado;
            Cliente cliente = new Cliente();
            return cliente;
        }
    }
}
