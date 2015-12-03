USE [C:\USERS\PABLO\SOURCE\REPOS\ESCUELASIMPLE\DATOS\DB.MDF]
GO

/****** Objeto: Table [dbo].[Personal] Fecha del script: 19/08/2015 09:06:29 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Personal];


GO
CREATE TABLE [dbo].[Personal] (
    [IdPersonal]             INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]                 NVARCHAR (255) NOT NULL,
    [Apellido]               NVARCHAR (255) NOT NULL,
    [DNI]                    INT            NOT NULL,
    [FechaNacimiento]        DATE           NOT NULL,
    [Domicilio]              NVARCHAR (255) NULL,
    [Barrio]                 NVARCHAR (255) NULL,
    [Localidad]              NVARCHAR (255) NULL,
    [IngresoDocencia]        DATE           NULL,
    [IngresoEstablecimiento] DATE           NULL,
    [Observacion]            NVARCHAR (255) NULL
);


