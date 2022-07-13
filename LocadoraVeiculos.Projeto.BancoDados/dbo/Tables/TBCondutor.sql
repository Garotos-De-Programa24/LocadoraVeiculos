CREATE TABLE [dbo].[TBCondutor] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [Cliente_Id]  UNIQUEIDENTIFIER NOT NULL,
    [Nome]        VARCHAR (100)    NOT NULL,
    [Cpf]         VARCHAR (50)     NOT NULL,
    [Endereco]    VARCHAR (100)    NOT NULL,
    [CnhCondutor] VARCHAR (50)     NOT NULL,
    [ValidadeCnh] DATE             NOT NULL,
    [Email]       VARCHAR (100)    NOT NULL,
    [Telefone]    VARCHAR (50)     NOT NULL,
    CONSTRAINT [PK_TBCondutor_1] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBCondutor_TBCliente] FOREIGN KEY ([Id]) REFERENCES [dbo].[TBCliente] ([Id])
);

