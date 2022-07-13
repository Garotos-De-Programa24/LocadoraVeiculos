CREATE TABLE [dbo].[TBFuncionario] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [Nome]         VARCHAR (100)    NOT NULL,
    [Salario]      VARCHAR (50)     NOT NULL,
    [DataAdmissao] DATE             NOT NULL,
    [Login]        VARCHAR (100)    NOT NULL,
    [Senha]        VARCHAR (100)    NOT NULL,
    [Gerente]      BIT              NOT NULL,
    CONSTRAINT [PK_TBFuncionario_1] PRIMARY KEY CLUSTERED ([Id] ASC)
);

