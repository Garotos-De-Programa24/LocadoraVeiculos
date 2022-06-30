using LocadoraVeiculos.Dominio.ModuloCondutor;
using LocadoraVeiculos.Infra.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.ModuloCondutor
{
    public class RepositorioCondutorEmBancoDados : RepositorioBase<Condutor, MapeadorCondutor>, IRepositorioCondutor
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBCONDUTOR] 
                (
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
                    @CLIENTE_ID,
                    @NOME,
                    @CPF,
                    @ENDERECO,
                    @CNHCONDUTOR,
                    @VALIDADECNH,
                    @EMAIL,
                    @TELEFONE
                );SELECT SCOPE_IDENTITY();";

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
		            [ID],
                    [CLIENTE_ID],
                    [NOME],
                    [CPF],
                    [ENDERECO],
                    [CNHCONDUTOR],
                    [VALIDADECNH],
                    [EMAIL],
                    [TELEFONE]
	            FROM 
		            [TBCONDUTOR]
		        WHERE
                    [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
		            [ID],
                    [CLIENTE_ID],
		            [NOME],
                    [CPF],
                    [ENDERECO],
                    [CNHCONDUTOR],
                    [VALIDADECNH],
                    [EMAIL],
                    [TELEFONE]
	            FROM 
		            [TBCONDUTOR]";
        protected string sqlSelecionarPorNome =>
            @"SELECT 
		            [ID],
                    [CLIENTE_ID],
                    [NOME],
                    [CPF],
                    [ENDERECO],
                    [CNHCONDUTOR],
                    [VALIDADECNH],
                    [EMAIL],
                    [TELEFONE]
	            FROM 
		            [TBCONDUTOR]
		        WHERE
                    [NOME] = @NOME";
        public Condutor SelecionarCondutorPorNome(string nome)
        {
            return SelecionarPorParametro(sqlSelecionarPorNome, new SqlParameter("NOME", nome));
        }
    }
}
