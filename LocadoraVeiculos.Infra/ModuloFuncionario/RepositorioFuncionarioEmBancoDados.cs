using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.Infra.Compartilhado;


namespace LocadoraVeiculos.Infra.ModuloFuncionario
{
    public class RepositorioFuncionarioEmBancoDados : RepositorioBase<Funcionario, ValidaFuncionario, MapeadorFuncionario>
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBFUNCIONARIO]
                (
                    [NOME],       
                    [LOGIN], 
                    [SENHA],
                    [SALARIO],                    
                    [DATAADMISSAO],
                    [GERENTE]
                )
            VALUES
                (
                    @NOME,
                    @LOGIN,
                    @SENHA,
                    @SALARIO,
                    @DATAADMISSAO,
                    @GERENTE
                ); SELECT SCOPE_IDENTITY();";

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
                [ADMISSAO],
                [SENHA]                
            FROM
                [TBFUNCIONARIO]";


       
    }
}
