USE [C:\USERS\PABLO\SOURCE\REPOS\ESCUELASIMPLE\DATOS\DB.MDF]
GO

/****** Objeto: Table [dbo].[Inasistencia] Fecha del script: 19/08/2015 09:06:15 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Inasistencia];


GO
CREATE TABLE [dbo].[Inasistencia] (
    [IdInasistencia] INT            IDENTITY (1, 1) NOT NULL,
    [IdPersonal]     INT            NOT NULL,
    [Articulo]       NVARCHAR (255) NOT NULL,
    [Desde]          DATE           NOT NULL,
    [Hasta]          DATE           NOT NULL
);


