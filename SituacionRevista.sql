USE [C:\USERS\PABLO\SOURCE\REPOS\ESCUELASIMPLE\DATOS\DB.MDF]
GO

/****** Objeto: Table [dbo].[SituacionRevista] Fecha del script: 19/08/2015 09:06:49 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[SituacionRevista];


GO
CREATE TABLE [dbo].[SituacionRevista] (
    [IdSituacionRevista] INT            IDENTITY (1, 1) NOT NULL,
    [Abreviacion]        NVARCHAR (3)   NOT NULL,
    [Descripcion]        NVARCHAR (255) NOT NULL
);


