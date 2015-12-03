USE [C:\USERS\PABLO\SOURCE\REPOS\ESCUELASIMPLE\DATOS\DB.MDF]
GO

/****** Objeto: Table [dbo].[Titulo] Fecha del script: 19/08/2015 09:08:14 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Titulo];


GO
CREATE TABLE [dbo].[Titulo] (
    [IdTitulo] INT            IDENTITY (1, 1) NOT NULL,
    [Titulo]   NVARCHAR (255) NOT NULL
);


