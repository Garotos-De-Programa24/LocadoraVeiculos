
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.Infra.Compartilhado;
using System;
using System.Data.SqlClient;

namespace LocadoraVeiculos.Infra.ModuloFuncionario
{
    public class MapeadorFuncionario : MapeadorBase<Funcionario>
    {
        public override void ConfigurarParametros(Funcionario funcionario, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", funcionario.Id);
            comando.Parameters.AddWithValue("NOME", funcionario.Nome);
            comando.Parameters.AddWithValue("SALARIO", funcionario.Salario);
            comando.Parameters.AddWithValue("DATAADMISSAO", funcionario.DataAdmissao);
            comando.Parameters.AddWithValue("LOGIN", funcionario.Login);
            comando.Parameters.AddWithValue("SENHA", funcionario.Senha);
            comando.Parameters.AddWithValue("GERENTE", funcionario.Gerente);

        }

        public override Funcionario ConverterRegistro(SqlDataReader leitorFuncionario)
        {
            var id = Guid.Parse(leitorFuncionario["ID"].ToString());
            var nome = Convert.ToString(leitorFuncionario["NOME"]);
            var salario = Convert.ToString(leitorFuncionario["SALARIO"]);
            var dataadmissao = Convert.ToDateTime(leitorFuncionario["DATAADMISSAO"]);
            var login = Convert.ToString(leitorFuncionario["LOGIN"]);
            var senha = Convert.ToString(leitorFuncionario["SENHA"]);
            var gerente = Convert.ToBoolean(leitorFuncionario["GERENTE"]);


            Funcionario funcionario = new Funcionario(nome,login,senha,salario,dataadmissao,gerente);
            funcionario.Id = id;

            return funcionario;
        }
    }
}
