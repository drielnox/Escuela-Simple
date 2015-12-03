USE [C:\USERS\PABLO\SOURCE\REPOS\ESCUELASIMPLE\DATOS\DB.MDF]
GO

/****** Objeto: Table [dbo].[Tarea] Fecha del script: 19/08/2015 09:07:10 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Tarea];


GO
CREATE TABLE [dbo].[Tarea] (
    [IdTarea]     INT           IDENTITY (1, 1) NOT NULL,
    [Abreviacion] NVARCHAR (3)  NOT NULL,
    [Descripcion] NVARCHAR (50) NOT NULL
);


