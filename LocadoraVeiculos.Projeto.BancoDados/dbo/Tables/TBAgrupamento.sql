CREATE TABLE [dbo].[TBAgrupamento] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Agrupamento] VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_TBAgrupamento] PRIMARY KEY CLUSTERED ([Id] ASC)
);

