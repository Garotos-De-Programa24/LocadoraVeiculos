CREATE TABLE [dbo].[TBTaxa] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Equipamento] VARCHAR (100)  NOT NULL,
    [Valor]       DECIMAL (7, 2) NOT NULL,
    [Descricao]   VARCHAR (300)  NOT NULL,
    CONSTRAINT [PK_TBTaxa] PRIMARY KEY CLUSTERED ([Id] ASC)
);

