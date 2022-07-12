CREATE TABLE [dbo].[TBVeiculo] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [Foto]             VARCHAR (MAX) NULL,
    [Marca]            VARCHAR (50)  NOT NULL,
    [Ano]              VARCHAR (50)  NOT NULL,
    [Placa]            VARCHAR (50)  NOT NULL,
    [CapacidadeTanque] VARCHAR (50)  NOT NULL,
    [KmPercorrido]     VARCHAR (50)  NOT NULL,
    [Combustivel]      VARCHAR (50)  NOT NULL,
    [Agrupamento_Id]   INT           NOT NULL,
    [VeiculoNome]      VARCHAR (100) NOT NULL,
    [Cor]              VARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_TBVeiculo] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBVeiculo_TBAgrupamento] FOREIGN KEY ([Id]) REFERENCES [dbo].[TBAgrupamento] ([Id])
);


GO
ALTER TABLE [dbo].[TBVeiculo] NOCHECK CONSTRAINT [FK_TBVeiculo_TBAgrupamento];

