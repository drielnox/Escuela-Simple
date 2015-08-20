USE [C:\USERS\PABLO\SOURCE\REPOS\ESCUELASIMPLE\DATOS\DB.MDF]
GO

/****** Objeto: Table [dbo].[TipoTelefono] Fecha del script: 19/08/2015 09:07:58 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[TipoTelefono];


GO
CREATE TABLE [dbo].[TipoTelefono] (
    [IdTipoTelefono] INT            IDENTITY (1, 1) NOT NULL,
    [Descripcion]    NVARCHAR (255) NOT NULL
);


