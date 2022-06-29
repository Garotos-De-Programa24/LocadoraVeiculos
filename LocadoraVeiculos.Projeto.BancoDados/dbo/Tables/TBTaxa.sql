CREATE TABLE [dbo].[TBTaxa] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Equipamento] VARCHAR (100) NOT NULL,
    [Valor]       VARCHAR (100) NOT NULL,
    [TaxaDiaria]  BIT           NOT NULL,
    CONSTRAINT [PK_TBTaxa] PRIMARY KEY CLUSTERED ([Id] ASC)
);

