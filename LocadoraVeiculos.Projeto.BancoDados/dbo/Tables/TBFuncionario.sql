CREATE TABLE [dbo].[TBFuncionario] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Nome]         VARCHAR (100)  NOT NULL,
    [Salario]      DECIMAL (7, 2) NOT NULL,
    [DataAdmissao] DATE           NOT NULL,
    [Login]        VARCHAR (100)  NOT NULL,
    [Senha]        VARCHAR (100)  NOT NULL,
    [Gerente]      BIT   NOT NULL,
    CONSTRAINT [PK_TBFuncionario] PRIMARY KEY CLUSTERED ([Id] ASC)
);

