CREATE TABLE [dbo].[Country]
(
	[Id]   INT       IDENTITY (1, 1) NOT NULL,
    [Code] CHAR (10) NULL,
    [Name] CHAR (60) NULL,
    CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED ([Id] ASC)
)
