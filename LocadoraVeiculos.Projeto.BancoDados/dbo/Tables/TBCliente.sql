CREATE TABLE [dbo].[TBCliente] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Nome]        VARCHAR (200) NOT NULL,
    [Cpf]         VARCHAR (50)  NOT NULL,
    [Endereco]    VARCHAR (200) NOT NULL,
    [CnhCondutor] VARCHAR (20)  NOT NULL,
    [Email]       VARCHAR (200) NOT NULL,
    [Telefone]    VARCHAR (20)  NOT NULL,
    [ValidadeCnh] DATE          NULL,
    CONSTRAINT [PK_TBCliente] PRIMARY KEY CLUSTERED ([Id] ASC)
);

