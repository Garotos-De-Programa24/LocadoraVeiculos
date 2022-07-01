CREATE TABLE [dbo].[TBCondutor] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Cliente_Id]  INT           NOT NULL,
    [Nome]        VARCHAR (100) NOT NULL,
    [Cpf]         VARCHAR (50)  NOT NULL,
    [Endereco]    VARCHAR (100) NOT NULL,
    [CnhCondutor] VARCHAR (50)  NOT NULL,
    [ValidadeCnh] DATE          NOT NULL,
    [Email]       VARCHAR (100) NOT NULL,
    [Telefone]    VARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_TBCondutor] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBCondutor_TBCliente] FOREIGN KEY ([Id]) REFERENCES [dbo].[TBCliente] ([Id])
);

