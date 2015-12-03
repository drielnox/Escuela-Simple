USE [C:\USERS\PABLO\SOURCE\REPOS\ESCUELASIMPLE\DATOS\DB.MDF]
GO

/****** Objeto: Table [dbo].[Funcion] Fecha del script: 19/08/2015 09:05:50 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Funcion];


GO
CREATE TABLE [dbo].[Funcion] (
    [IdFuncion]        INT            IDENTITY (1, 1) NOT NULL,
    [Tarea]            INT            NOT NULL,
    [Toma]             DATE           NOT NULL,
    [Cese]             DATE           NULL,
    [SituacionRevista] INT            NOT NULL,
    [Observacion]      NVARCHAR (255) NULL
);


