
/****** Object: Table [dbo].[Products] Script Date: 4/3/2017 12:37:00 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Products];


GO
CREATE TABLE [dbo].[Products] (
    [ProductID]     INT             IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (100)  NOT NULL,
    [Description]   NVARCHAR (500)  NOT NULL,
    [Price]         DECIMAL (16, 2) NOT NULL,
    [ImageData]     VARBINARY (MAX) NULL,
    [ImageMimeType] VARCHAR (50)    NULL,
    [CategoryId]    INT             NULL,
    [TypeId]        INT             NULL,
    [ImageUrl]      NVARCHAR (250)  NULL
);


