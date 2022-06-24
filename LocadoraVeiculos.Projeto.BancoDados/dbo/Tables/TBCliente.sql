CREATE TABLE [dbo].[TBCliente] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Nome]        VARCHAR (200) NOT NULL,
    [Cpf]     VARCHAR(100)           NOT NULL,
    [Endereco]    VARCHAR (200) NOT NULL,
    [CnhCondutor] VARCHAR(100)           NOT NULL,
    [Email]       VARCHAR (200) NOT NULL,
    [Telefone]    VARCHAR(100)           NOT NULL,
    [ValidadeCnh] DATE NULL, 
    CONSTRAINT [PK_TBCliente] PRIMARY KEY CLUSTERED ([Id] ASC)
);

