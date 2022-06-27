using LocadoraVeiculos.Dominio.ModuloAgrupamento;
using LocadoraVeiculos.Infra.Compartilhado;

namespace LocadoraVeiculos.Infra.ModuloAgrupamento
{
    public class RepositorioAgrupamentoEmBancoDados : RepositorioBase<Agrupamento, ValidaAgrupamento, MapeadorAgrupamento>
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBAGRUPAMENTO] 
                (
                    [AGRUPAMENTO]                    
	            )
	            VALUES
                (
                    @AGRUPAMENTO                    
                );SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
            @"UPDATE [TBAGRUPAMENTO]	
		        SET
			        [AGRUPAMENTO] = @AGRUPAMENTO			        
		        WHERE
			        [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBAGRUPAMENTO]			        
		        WHERE
			        [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
		            [ID],
                    [AGRUPAMENTO]                    
	            FROM 
		            [TBAGRUPAMENTO]
		        WHERE
                    [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
		            [ID],
		            [AGRUPAMENTO]                    
	            FROM 
		            [TBAGRUPAMENTO]";
    }
}
