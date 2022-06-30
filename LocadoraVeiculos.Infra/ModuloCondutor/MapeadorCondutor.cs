using LocadoraVeiculos.Dominio.ModuloCondutor;
using LocadoraVeiculos.Infra.Compartilhado;
using System;
using System.Data.SqlClient;

namespace LocadoraVeiculos.Infra.ModuloCondutor
{
    public class MapeadorCondutor : MapeadorBase<Condutor>
    {
        public override void ConfigurarParametros(Condutor registro, SqlCommand comando)
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

        public override Condutor ConverterRegistro(SqlDataReader leitorRegistro)
        {
            if (leitorRegistro["ID"] == DBNull.Value)
                return null;

            var id = Convert.ToInt32(leitorRegistro["ID"]);
            var cliente_id = Convert.ToInt32(leitorRegistro["CLIENTE_ID"]);
            var nome = Convert.ToString(leitorRegistro["NOME"]);
            var cpf = Convert.ToString(leitorRegistro["CPF"]);
            var endereco = Convert.ToString(leitorRegistro["ENDERECO"]);
            var cnhCondutor = Convert.ToString(leitorRegistro["CNHCONDUTOR"]);
            var validadeCnh = Convert.ToDateTime(leitorRegistro["VALIDADECNH"]);
            var email = Convert.ToString(leitorRegistro["EMAIL"]);
            var telefone = Convert.ToString(leitorRegistro["TELEFONE"]);

            Condutor condutor = new Condutor();
            condutor.Id = id;
            condutor.Cliente.Id = cliente_id;
            condutor.Nome = nome;
            condutor.Cpf = cpf;
            condutor.Endereco = endereco;
            condutor.CnhCondutor = cnhCondutor;
            condutor.ValidadeCnh = validadeCnh;
            condutor.Email = email;
            condutor.Telefone = telefone;

            return condutor;
        }
    }
}
