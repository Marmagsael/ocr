CREATE TABLE [dbo].[ProvinceState]
(
	[Id]        INT       IDENTITY (1, 1) NOT NULL,
    [Code]      CHAR (10) NOT NULL,
    [Name]      CHAR (60) NOT NULL,
    [CountryId] INT       NOT NULL DEFAULT 0,
    CONSTRAINT [PK_ProvinceState] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ProvinceState_Country_CountryId] FOREIGN KEY ([CountryId]) REFERENCES [dbo].[Country] ([Id])
)
