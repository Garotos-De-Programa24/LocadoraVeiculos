using LocadoraVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraVeiculos.Infra.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.ModuloPlanoDeCobranca
{
    public class RepositorioPlanoCobrancaEmBancoDados : RepositorioBase<PlanoCobranca, MapeadorPlanoCobranca>, IRepositorioPlanoCobranca
    {
        protected override string sqlInserir =>
             @"INSERT INTO [TBPLANO]
                (
                    [NOMEPLANO],       
                    [TIPOPLANO], 
                    [VALOR_LIVRE],
                    [VALOR_DIARIO],                    
                    [VALOR_CONTROLADO],
                    [AGRUPAMENTO_ID]
                )
            VALUES
                (
                    @NOMEPLANO,
                    @TIPOPLANO,
                    @VALOR_LIVRE,
                    @VALOR_DIARIO,
                    @VALOR_CONTROLADO,
                    @AGRUPAMENTO_ID
                ); SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
            @"UPDATE [TBPLANO]	
		        SET
                    [NOMEPLANO] = @NOMEPLANO,                    
			        [TIPOPLANO] = @TIPOPLANO,
			        [VALOR_LIVRE] = @VALOR_LIVRE,
                    [VALOR_DIARIO] = @VALOR_DIARIO,
                    [VALOR_CONTROLADO] = @VALOR_CONTROLADO,
                    [AGRUPAMENTO_ID] = @AGRUPAMENTO_ID
		        WHERE
			        [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBPLANO]			        
		        WHERE
			        [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT
                    PLANO.[ID],
                    PLANO.[NOMEPLANO],
                    PLANO.[TIPOPLANO],
                    PLANO.[VALOR_LIVRE],
                    PLANO.[VALOR_DIARIO],
                    PLANO.[VALOR_CONTROLADO],
                    PLANO.[AGRUPAMENTO_ID],
                    GRUPO.[AGRUPAMENTO]
	            FROM 
		            [TBPLANO] AS PLANO INNER JOIN [TBAGRUPAMENTO] AS GRUPO
                ON
                    GRUPO.ID = PLANO.AGRUPAMENTO_ID
		        WHERE
                    PLANO.[ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT
                    PLANO.[ID],
                    PLANO.[NOMEPLANO],
                    PLANO.[TIPOPLANO],
                    PLANO.[VALOR_LIVRE],
                    PLANO.[VALOR_DIARIO],
                    PLANO.[VALOR_CONTROLADO],
                    PLANO.[AGRUPAMENTO_ID] ,
                    GRUPO.[AGRUPAMENTO]
	            FROM 
		            [TBPLANO] AS PLANO INNER JOIN [TBAGRUPAMENTO] AS GRUPO
                ON
                    GRUPO.ID = PLANO.AGRUPAMENTO_ID";

        private string sqlSelecionarPorNome =>
             @"SELECT
                    PLANO.[ID],
                    PLANO.[NOMEPLANO],
                    PLANO.[TIPOPLANO],
                    PLANO.[VALOR_LIVRE],
                    PLANO.[VALOR_DIARIO],
                    PLANO.[VALOR_CONTROLADO],
                    PLANO.[AGRUPAMENTO_ID],
                    GRUPO.[AGRUPAMENTO] 
	            FROM 
		            [TBPLANO] AS PLANO INNER JOIN [TBAGRUPAMENTO] AS GRUPO
                ON
                    GRUPO.ID = PLANO.AGRUPAMENTO_ID
		        WHERE
                    PLANO.[NOMEPLANO] = @NOMEPLANO";
        public PlanoCobranca SelecionarPlanoPorNome(string nome)
        {
            return SelecionarPorParametro(sqlSelecionarPorNome, new SqlParameter("NOMEPLANO", nome));
        }
    }
}
