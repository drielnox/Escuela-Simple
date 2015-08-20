USE [C:\USERS\PABLO\SOURCE\REPOS\ESCUELASIMPLE\DATOS\DB.MDF]
GO

/****** Objeto: Table [dbo].[Cargo] Fecha del script: 19/08/2015 09:05:12 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Cargo];


GO
CREATE TABLE [dbo].[Cargo] (
    [IdCargo]    INT     IDENTITY (1, 1) NOT NULL,
    [IdPersonal] INT     NOT NULL,
    [Secuencia]  TINYINT NOT NULL
);


