USE [D:\CODE\ASP.MVC\ASP MVC PRO\BOOKSTORE\WEBUI\APP_DATA\SPORTSSTORE.MDF]
GO

/****** Object: Table [dbo].[Type] Script Date: 4/3/2017 1:17:49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Type];


GO
CREATE TABLE [dbo].[Type] (
    [TypeId]  INT           IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (50) NULL,
    [NameEng] NCHAR (10)    NULL
);


