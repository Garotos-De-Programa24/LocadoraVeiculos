CREATE TABLE [dbo].[TBTaxa] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [Equipamento] VARCHAR (100)    NOT NULL,
    [Valor]       VARCHAR (100)    NOT NULL,
    [TaxaDiaria]  BIT              NOT NULL,
    CONSTRAINT [PK_TBTaxa_1] PRIMARY KEY CLUSTERED ([Id] ASC)
);

