using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Infra.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LocadoraVeiculos.Infra.ModuloCliente
{
    public class RepositorioClienteEmBancoDados : RepositorioBase<Cliente, ValidaCliente,MapeadorCliente>
    {        
        protected override string sqlInserir =>
            @"INSERT INTO [TBCLIENTE] 
                (
                    [NOME],
                    [CPFCNPJ],
                    [ENDERECO],
                    [CNHCONDUTOR],
                    [EMAIL],
                    [TELEFONE]
	            )
	            VALUES
                (
                    @NOME,
                    @CPFCNPJ,
                    @ENDERECO,
                    @CNHCONDUTOR,
                    @EMAIL,
                    @TELEFONE
                );SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
            @"UPDATE [TBCLIENTE]	
		        SET
			        [NOME] = @NOME,
			        [CPFCNPJ] = @CPFCNPJ,
                    [ENDERECO] = @ENDERECO,
                    [CNHCONDUTOR] = @CNHCONDUTOR,
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
                    [CPFCNPJ],
                    [ENDERECO],
                    [CNHCONDUTOR],
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
                    [CPFCNPJ],
                    [ENDERECO],
                    [CNHCONDUTOR],
                    [EMAIL],
                    [TELEFONE]
	            FROM 
		            [TBCLIENTE]";
        
    }
}
