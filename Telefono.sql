USE [C:\USERS\PABLO\SOURCE\REPOS\ESCUELASIMPLE\DATOS\DB.MDF]
GO

/****** Objeto: Table [dbo].[Telefono] Fecha del script: 19/08/2015 09:07:42 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Telefono];


GO
CREATE TABLE [dbo].[Telefono] (
    [IdTelefono] INT IDENTITY (1, 1) NOT NULL,
    [Tipo]       INT NOT NULL,
    [Numero]     INT NOT NULL,
    [IdPersonal] INT NOT NULL
);


