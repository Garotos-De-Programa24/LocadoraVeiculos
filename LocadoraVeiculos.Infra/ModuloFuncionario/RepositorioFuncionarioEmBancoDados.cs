using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.Infra.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.ModuloFuncionario
{
    public class RepositorioFuncionarioEmBancoDados : RepositorioBase<Funcionario, ValidaFuncionario, MapeadorFuncionario>, IRepositorioFuncionario
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBFUNCIONARIO]
                (
                    [NOME],       
                    [LOGIN], 
                    [SENHA],
                    [SALARIO],                    
                    [ADMISSAO],
                    [GERENTE]
                )
            VALUES
                (
                    @NOME,
                    @LOGIN,
                    @SENHA,
                    @SALARIO,
                    @ADMISSAO,
                    @GERENTE
                ); SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
                 @" UPDATE [TBFUNCIONARIO]
                    SET 
                        [NOME] = @NOME, 
                        [LOGIN] = @LOGIN, 
                        [SENHA] = @SENHA,
                        [SALARIO] = @SALARIO, 
                        [ADMISSAO] = @ADMISSAO,
                        [GERENTE] = @GERENTE
                    WHERE [ID] = @ID";


        protected override string sqlExcluir =>
              @"DELETE FROM [TBFUNCIONARIO] 
                    WHERE [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
                [ID] FUNCIONARIO_ID,       
                [NOME] FUNCIONARIO_NOME,
                [LOGIN] FUNCIONARIO_LOGIN,
                [SENHA] FUNCIONARIO_SENHA,
                [SALARIO] FUNCIONARIO_SALARIO,
                [ADMISSAO] FUNCIONARIO_SENHA,
                [SENHA] FUNCIONARIO_SENHA
                
            FROM
                [TBFUNCIONARIO]
            WHERE
                [ID] = @ID";

        protected override string sqlSelecionarTodos => throw new NotImplementedException();

        public Funcionario SelecionarPorNumero(int numero)
        {
            throw new NotImplementedException();
        }

        ValidationResult IRepositorio<Funcionario>.Excluir(Funcionario registro)
        {
            throw new NotImplementedException();
        }
    }
}
