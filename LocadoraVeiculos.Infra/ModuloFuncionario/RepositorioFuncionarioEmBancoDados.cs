using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.Infra.Compartilhado;
using System.Data.SqlClient;

namespace LocadoraVeiculos.Infra.ModuloFuncionario
{
    public class RepositorioFuncionarioEmBancoDados : RepositorioBase<Funcionario, MapeadorFuncionario>,IRepositorioFuncionario
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBFUNCIONARIO]
                (
                    [ID],
                    [NOME],       
                    [LOGIN], 
                    [SENHA],
                    [SALARIO],                    
                    [DATAADMISSAO],
                    [GERENTE]
                )
            VALUES
                (
                    @ID,
                    @NOME,
                    @LOGIN,
                    @SENHA,
                    @SALARIO,
                    @DATAADMISSAO,
                    @GERENTE
                );";

        protected override string sqlEditar =>
                 @" UPDATE [TBFUNCIONARIO]
                    SET 
                        [NOME] = @NOME, 
                        [LOGIN] = @LOGIN, 
                        [SENHA] = @SENHA,
                        [SALARIO] = @SALARIO, 
                        [DATAADMISSAO] = @DATAADMISSAO,
                        [GERENTE] = @GERENTE
                    WHERE [ID] = @ID";


        protected override string sqlExcluir =>
              @"DELETE FROM [TBFUNCIONARIO] 
                    WHERE [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
                [ID],       
                [NOME],
                [LOGIN],
                [SENHA],
                [SALARIO],
                [DATAADMISSAO],
                [GERENTE]
                
            FROM
                [TBFUNCIONARIO]
            WHERE
                [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
                [ID],       
                [NOME],
                [LOGIN],
                [SENHA],
                [SALARIO],
                [DATAADMISSAO],
                [GERENTE]                
            FROM
                [TBFUNCIONARIO]";

        private string sqlSelecionarPorNome =>
               @"SELECT 
                [ID],       
                [NOME],
                [LOGIN],
                [SENHA],
                [SALARIO],
                [DATAADMISSAO],
                [GERENTE]
                
            FROM
                [TBFUNCIONARIO]
            WHERE
                [NOME] = @NOME";

        private string sqlSelecionarPorUsuario =>
            @"SELECT 
                [ID],       
                [NOME],
                [LOGIN],
                [SENHA],
                [SALARIO],
                [DATAADMISSAO],
                [GERENTE]
                
            FROM
                [TBFUNCIONARIO]
            WHERE
                [LOGIN] = @LOGIN";

        public Funcionario SelecionarFuncionarioPorNome(string nome)
        {
            return SelecionarPorParametro(sqlSelecionarPorNome, new SqlParameter("NOME", nome));
        }

        public Funcionario SelecionarFuncionarioPorUsuario(string usuario)
        {
            return SelecionarPorParametro(sqlSelecionarPorUsuario, new SqlParameter("LOGIN", usuario));
        }
    }
}
