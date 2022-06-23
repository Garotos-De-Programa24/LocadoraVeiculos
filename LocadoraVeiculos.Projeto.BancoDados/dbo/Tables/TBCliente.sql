CREATE TABLE [dbo].[TBCliente] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Nome]        VARCHAR (200) NOT NULL,
    [CpfCnpj]     INT           NOT NULL,
    [Endereco]    VARCHAR (200) NOT NULL,
    [CnhCondutor] INT           NOT NULL,
    [Email]       VARCHAR (200) NOT NULL,
    [Telefone]    INT           NOT NULL,
    CONSTRAINT [PK_TBCliente] PRIMARY KEY CLUSTERED ([Id] ASC)
);

