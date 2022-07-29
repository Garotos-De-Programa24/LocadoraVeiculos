using LocadoraVeiculos.Dominio.ModuloCondutor;
using LocadoraVeiculos.Infra.Compartilhado;
using System;
using System.Data.SqlClient;

namespace LocadoraVeiculos.Infra.ModuloCondutor
{
    public class RepositorioCondutorEmBancoDados : RepositorioBase<Condutor, MapeadorCondutor>, IRepositorioCondutor
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBCONDUTOR] 
                (
                    [ID],
                    [CLIENTE_ID],                    
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
                    @ID,
                    @CLIENTE_ID,                    
                    @NOME,
                    @CPF,
                    @ENDERECO,
                    @CNHCONDUTOR,
                    @VALIDADECNH,
                    @EMAIL,
                    @TELEFONE
                );";

        protected override string sqlEditar =>
            @"UPDATE [TBCONDUTOR]	
		        SET
                    [CLIENTE_ID] = @CLIENTE_ID,                    
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
            @"DELETE FROM [TBCONDUTOR]			        
		        WHERE
			        [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
		            COND.[ID],
                    COND.[CLIENTE_ID],
                    CLI.[NOME] AS CLIENTE_NOME,
                    CLI.[CPFCNPJ],
                    CLI.[ENDERECO] AS CLIENTE_ENDERECO,
                    CLI.[EMAIL] AS CLIENTE_EMAIL,
                    CLI.[TELEFONE] AS CLIENTE_TELEFONE,
                    COND.[NOME],
                    COND.[CPF],
                    COND.[ENDERECO],
                    COND.[CNHCONDUTOR],
                    COND.[VALIDADECNH],
                    COND.[EMAIL],
                    COND.[TELEFONE]
	            FROM 
		            [TBCONDUTOR] AS COND INNER JOIN [TBCLIENTE] AS CLI
                ON
                    CLI.ID = COND.CLIENTE_ID
		        WHERE
                    COND.[ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
		            COND.[ID],
                    COND.[CLIENTE_ID],
                    CLI.[NOME] AS CLIENTE_NOME,
                    CLI.[CPFCNPJ],
                    CLI.[ENDERECO] AS CLIENTE_ENDERECO,
                    CLI.[EMAIL] AS CLIENTE_EMAIL,
                    CLI.[TELEFONE] AS CLIENTE_TELEFONE,
                    COND.[NOME],
                    COND.[CPF],
                    COND.[ENDERECO],
                    COND.[CNHCONDUTOR],
                    COND.[VALIDADECNH],
                    COND.[EMAIL],
                    COND.[TELEFONE]
	            FROM 
		            [TBCONDUTOR] AS COND INNER JOIN [TBCLIENTE] AS CLI
                ON
                    CLI.ID = COND.CLIENTE_ID";
		        
        protected string sqlSelecionarPorNome =>
            @"SELECT 
		            COND.[ID],
                    COND.[CLIENTE_ID],
                    CLI.[NOME] AS CLIENTE_NOME,
                    CLI.[CPFCNPJ],
                    CLI.[ENDERECO] AS CLIENTE_ENDERECO,
                    CLI.[EMAIL] AS CLIENTE_EMAIL,
                    CLI.[TELEFONE] AS CLIENTE_TELEFONE,
                    COND.[NOME],
                    COND.[CPF],
                    COND.[ENDERECO],
                    COND.[CNHCONDUTOR],
                    COND.[VALIDADECNH],
                    COND.[EMAIL],
                    COND.[TELEFONE]
	            FROM 
		            [TBCONDUTOR] AS COND INNER JOIN [TBCLIENTE] AS CLI
                ON
                    CLI.ID = COND.CLIENTE_ID
		        WHERE
                    COND.[NOME] = @NOME";

        protected string sqlSelecionarPorClienteId =>
            @"SELECT 
		            COND.[ID],
                    COND.[CLIENTE_ID],
                    CLI.[NOME] AS CLIENTE_NOME,
                    CLI.[CPFCNPJ],
                    CLI.[ENDERECO] AS CLIENTE_ENDERECO,
                    CLI.[EMAIL] AS CLIENTE_EMAIL,
                    CLI.[TELEFONE] AS CLIENTE_TELEFONE,
                    COND.[NOME],
                    COND.[CPF],
                    COND.[ENDERECO],
                    COND.[CNHCONDUTOR],
                    COND.[VALIDADECNH],
                    COND.[EMAIL],
                    COND.[TELEFONE]
	            FROM 
		            [TBCONDUTOR] AS COND INNER JOIN [TBCLIENTE] AS CLI
                ON
                    CLI.ID = COND.CLIENTE_ID
		        WHERE
                    COND.[CLIENTE_ID] = @CLIENTE_ID";


        public Condutor SelecionarCondutorPorNome(string nome)
        {
            return SelecionarPorParametro(sqlSelecionarPorNome, new SqlParameter("NOME", nome));
        }

        public Condutor SelecionarPorClienteId(Guid id)
        {
            return SelecionarPorParametro(sqlSelecionarPorClienteId, new SqlParameter("CLIENTE_ID", id));
        }
    }
}
