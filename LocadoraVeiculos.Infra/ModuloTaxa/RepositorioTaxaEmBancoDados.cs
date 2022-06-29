using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloTaxa;
using LocadoraVeiculos.Infra.Compartilhado;
using System;


namespace LocadoraVeiculos.Infra.ModuloTaxa
{
    public class RepositorioTaxaEmBancoDados : RepositorioBase<Taxa, ValidaTaxa, MapeadorTaxa>
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBTAXA]
                (
                    [EQUIPAMENTO],       
                    [VALOR],                     
                    [TAXADIARIA]
                )
            VALUES
                (
                    @EQUIPAMENTO,
                    @VALOR,                    
                    @TAXADIARIA
                ); SELECT SCOPE_IDENTITY();";

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



    }
}
