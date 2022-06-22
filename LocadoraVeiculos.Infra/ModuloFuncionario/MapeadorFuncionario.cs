
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.Infra.Compartilhado;
using System.Data.SqlClient;

namespace LocadoraVeiculos.Infra.ModuloFuncionario
{
    public class MapeadorFuncionario : MapeadorBase<Funcionario>
    {
        public override void ConfigurarParametros(Funcionario registro, SqlCommand comando)
        {
            throw new System.NotImplementedException();
        }

        public override Funcionario ConverterRegistro(SqlDataReader leitorRegistro)
        {
            throw new System.NotImplementedException();
        }
    }
}
