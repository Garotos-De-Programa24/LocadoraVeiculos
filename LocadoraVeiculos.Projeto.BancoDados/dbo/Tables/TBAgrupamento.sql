CREATE TABLE [dbo].[TBAgrupamento] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [Agrupamento] VARCHAR (100)    NOT NULL,
    CONSTRAINT [PK_TBAgrupamento] PRIMARY KEY CLUSTERED ([Id] ASC)
);

