using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloTaxa;
using LocadoraVeiculos.Infra.Compartilhado;
using System;
using System.Data.SqlClient;

namespace LocadoraVeiculos.Infra.ModuloTaxa
{
    public class RepositorioTaxaEmBancoDados : RepositorioBase<Taxa, MapeadorTaxa>,IRepositorioTaxa
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBTAXA]
                (
                    [ID],
                    [EQUIPAMENTO],       
                    [VALOR],                     
                    [TAXADIARIA]
                )
            VALUES
                (
                    @ID,
                    @EQUIPAMENTO,
                    @VALOR,
                    @TAXADIARIA
                );";

        protected override string sqlEditar =>
                 @" UPDATE [TBTAXA]
                    SET 
                        [EQUIPAMENTO] = @EQUIPAMENTO, 
                        [VALOR] = @VALOR,
                        [TAXADIARIA] = @TAXADIARIA
                    WHERE [ID] = @ID";

        protected override string sqlExcluir =>
                  @"DELETE FROM [TBTAXA] 
                    WHERE [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
                [ID],       
                [EQUIPAMENTO],
                [VALOR],                
                [TAXADIARIA]
                
            FROM
                [TBTAXA]
            WHERE
                [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
                [ID],       
                [EQUIPAMENTO],
                [VALOR],                
                [TAXADIARIA]                
            FROM
                [TBTAXA]";

        protected string sqlSelecionarPorNome =>
            @"SELECT 
                [ID],       
                [EQUIPAMENTO],
                [VALOR],                
                [TAXADIARIA]                
            FROM
                [TBTAXA]
            WHERE
                [EQUIPAMENTO] = @EQUIPAMENTO";

        public Taxa SelecionarTaxaPeloNome(string nome)
        {
            return SelecionarPorParametro(sqlSelecionarPorNome, new SqlParameter("EQUIPAMENTO", nome));
        }
    }
}
