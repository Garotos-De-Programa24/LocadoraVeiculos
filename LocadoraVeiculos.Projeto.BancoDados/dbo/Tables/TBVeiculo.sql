CREATE TABLE [dbo].[TBVeiculo] (
    [Id]               UNIQUEIDENTIFIER NOT NULL,
    [Marca]            VARCHAR (50)     NOT NULL,
    [Ano]              VARCHAR (50)     NOT NULL,
    [Placa]            VARCHAR (50)     NOT NULL,
    [CapacidadeTanque] VARCHAR (50)     NOT NULL,
    [KmPercorrido]     VARCHAR (50)     NOT NULL,
    [Combustivel]      VARCHAR (50)     NOT NULL,
    [Agrupamento_Id]   INT              NOT NULL,
    [VeiculoNome]      VARCHAR (100)    NOT NULL,
    [Cor]              VARCHAR (50)     NOT NULL,
    CONSTRAINT [PK_TBVeiculo_1] PRIMARY KEY CLUSTERED ([Id] ASC)
);

