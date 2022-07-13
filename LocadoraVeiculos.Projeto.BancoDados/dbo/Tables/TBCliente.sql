CREATE TABLE [dbo].[TBCliente] (
    [Id]       UNIQUEIDENTIFIER NOT NULL,
    [Nome]     VARCHAR (200)    NOT NULL,
    [CpfCnpj]  VARCHAR (50)     NOT NULL,
    [Endereco] VARCHAR (200)    NOT NULL,
    [Email]    VARCHAR (200)    NOT NULL,
    [Telefone] VARCHAR (20)     NOT NULL,
    CONSTRAINT [PK_TBCliente_1] PRIMARY KEY CLUSTERED ([Id] ASC)
);

