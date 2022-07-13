﻿CREATE TABLE [dbo].[TBPlano] (
    [Id]               UNIQUEIDENTIFIER NOT NULL,
    [NomePlano]        VARCHAR (100)    NOT NULL,
    [TipoPlano]        INT              NOT NULL,
    [Valor_Livre]      VARCHAR (50)     NULL,
    [Valor_Diario]     VARCHAR (50)     NULL,
    [Valor_Controlado] VARCHAR (50)     NULL,
    [Agrupamento_Id]   INT              NOT NULL,
    CONSTRAINT [PK_TBPlano_1] PRIMARY KEY CLUSTERED ([Id] ASC)
);

