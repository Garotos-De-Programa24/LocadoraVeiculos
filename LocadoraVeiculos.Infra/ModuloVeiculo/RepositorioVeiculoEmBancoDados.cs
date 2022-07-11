using System;
using System.Data.SqlClient;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculos.Infra.Compartilhado;

namespace LocadoraVeiculos.Infra.ModuloVeiculo
{
    public class RepositorioVeiculoEmBancoDados : RepositorioBase<Veiculo, MapeadorVeiculo>, IRepositorioVeiculo
    {
        protected override string sqlInserir => 
            @"INSERT INTO [TBVEICULO]
                (
                    [FOTO],
                    [VEICULONOME],
                    [MARCA],
                    [ANO],
                    [PLACA],
                    [CAPACIDADETANQUE],
                    [KMPERCORRIDO],
                    [COMBUSTIVEL],
                    [COR],
                    [AGRUPAMENTO_ID]
                )
            VALUES
                (
                    @FOTO,
                    @VEICULONOME,
                    @MARCA,
                    @ANO,
                    @PLACA,
                    @CAPACIDADETANQUE,
                    @KMPERCORRIDO,
                    @COMBUSTIVEL,
                    @COR,
                    @AGRUPAMENTO_ID
                ); SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
            @" UPDATE [TBVEICULO]
                SET 
                    [FOTO] = @FOTO,
                    [VEICULONOME] = @VEICULONOME,
                    [MARCA] = @MARCA,
                    [ANO] = @ANO,
                    [PLACA] = @PLACA,
                    [CAPACIDADETANQUE] = @CAPACIDADETANQUE,
                    [KMPERCORRIDO] = @KMPERCORRIDO,
                    [COMBUSTIVEL] = @COMBUSTIVEL,
                    [COR] = @COR,
                    [AGRUPAMENTO_ID] = @AGRUPAMENTO_ID
                WHERE [ID] = @ID";

        protected override string sqlExcluir => 
            @"DELETE FROM [TBVEICULO] 
                WHERE [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
                VEIC.[ID],
                VEIC.[FOTO],
                VEIC.[VEICULONOME],
                VEIC.[MARCA],
                VEIC.[ANO],
                VEIC.[PLACA],
                VEIC.[CAPACIDADETANQUE],
                VEIC.[KMPERCORRIDO],
                VEIC.[COMBUSTIVEL],
                VEIC.[COR],
                VEIC.[AGRUPAMENTO_ID],
                GRUPO.[AGRUPAMENTO]
            FROM 
		            [TBVEICULO] AS VEIC INNER JOIN [TBAGRUPAMENTO] AS GRUPO
                ON
                    GRUPO.ID = VEIC.AGRUPAMENTO_ID
            WHERE
                [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
                VEIC.[ID],
                VEIC.[FOTO],
                VEIC.[VEICULONOME],
                VEIC.[MARCA],
                VEIC.[ANO],
                VEIC.[PLACA],
                VEIC.[CAPACIDADETANQUE],
                VEIC.[KMPERCORRIDO],
                VEIC.[COMBUSTIVEL],
                VEIC.[COR],
                VEIC.[AGRUPAMENTO_ID],
                GRUPO.[AGRUPAMENTO]
            FROM 
		            [TBVEICULO] AS VEIC INNER JOIN [TBAGRUPAMENTO] AS GRUPO
                ON
                    GRUPO.ID = VEIC.AGRUPAMENTO_ID";

        protected string sqlSelecionarPorNome =>
            @"SELECT 
                VEIC.[ID],
                VEIC.[FOTO],
                VEIC.[VEICULONOME],
                VEIC.[MARCA],
                VEIC.[ANO],
                VEIC.[PLACA],
                VEIC.[CAPACIDADETANQUE],
                VEIC.[KMPERCORRIDO],
                VEIC.[COMBUSTIVEL],
                VEIC.[COR],
                VEIC.[AGRUPAMENTO_ID],
                GRUPO.[AGRUPAMENTO]
            FROM 
		            [TBVEICULO] AS VEIC INNER JOIN [TBAGRUPAMENTO] AS GRUPO
                ON
                    GRUPO.ID = VEIC.AGRUPAMENTO_ID
            WHERE 
                VEIC.[VEICULONOME] = @VEICULONOME";


        public Veiculo SelecionarVeiculoPeloNome(string nome)
        {
            return SelecionarPorParametro(sqlSelecionarPorNome, new SqlParameter("VEICULONOME", nome));
        }
    }
}
