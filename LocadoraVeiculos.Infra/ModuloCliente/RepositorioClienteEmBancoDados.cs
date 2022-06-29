using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Infra.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LocadoraVeiculos.Infra.ModuloCliente
{
    public class RepositorioClienteEmBancoDados : RepositorioBase<Cliente,MapeadorCliente>,IRepositorioCliente
    {        
        protected override string sqlInserir =>
            @"INSERT INTO [TBCLIENTE] 
                (
                    [NOME],
                    [CPF],
                    [ENDERECO],
                    [CNHCONDUTOR],
                    [VALIDADECNH],
                    [EMAIL],
                    [TELEFONE]
	            )
	            VALUES
                (
                    @NOME,
                    @CPF,
                    @ENDERECO,
                    @CNHCONDUTOR,
                    @VALIDADECNH,
                    @EMAIL,
                    @TELEFONE
                );SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
            @"UPDATE [TBCLIENTE]	
		        SET
			        [NOME] = @NOME,
			        [CPF] = @CPF,
                    [ENDERECO] = @ENDERECO,
                    [CNHCONDUTOR] = @CNHCONDUTOR,
                    [VALIDADECNH] = @VALIDADECNH,
                    [EMAIL] = @EMAIL,
                    [TELEFONE] = @TELEFONE
		        WHERE
			        [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBCLIENTE]			        
		        WHERE
			        [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
		            [ID],
                    [NOME],
                    [CPF],
                    [ENDERECO],
                    [CNHCONDUTOR],
                    [VALIDADECNH],
                    [EMAIL],
                    [TELEFONE]
	            FROM 
		            [TBCLIENTE]
		        WHERE
                    [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
		            [ID],
		            [NOME],
                    [CPF],
                    [ENDERECO],
                    [CNHCONDUTOR],
                    [VALIDADECNH],
                    [EMAIL],
                    [TELEFONE]
	            FROM 
		            [TBCLIENTE]";
        protected string sqlSelecionarPorNome =>
            @"SELECT 
		            [ID],
                    [NOME],
                    [CPF],
                    [ENDERECO],
                    [CNHCONDUTOR],
                    [VALIDADECNH],
                    [EMAIL],
                    [TELEFONE]
	            FROM 
		            [TBCLIENTE]
		        WHERE
                    [NOME] = @NOME";
        public Cliente SelecionarClientePorNome(string nome)
        {
            return SelecionarPorParametro(sqlSelecionarPorNome, new SqlParameter("NOME", nome));
        }
    }
}
