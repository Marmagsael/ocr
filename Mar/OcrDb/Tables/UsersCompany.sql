CREATE TABLE [dbo].[UsersCompany]
(
	[Id]              INT          IDENTITY (1, 1) NOT NULL,
    [CompanyName]     VARCHAR (80) NULL,
    [Address1]        VARCHAR (80) NULL,
    [Address2]        VARCHAR (80) NULL,
    [City]            VARCHAR (80) NULL,
    [CountryId]       INT          NULL,
    [ProvinceStateId] INT          NULL,
    [Phone]           VARCHAR (60) NULL,
    [Mobile]          VARCHAR (60) NULL,
    [Website]         VARCHAR (80) NULL,
    [PostalCode]      VARCHAR (10) NULL,
    [CurrencyCode]    VARCHAR (60) NULL,
    [UsersId]         INT          NULL,
    [CurencyId]       INT          NULL,
    CONSTRAINT [PK_UsersCompany] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UsersCompany_Country_CountryId] FOREIGN KEY ([CountryId]) REFERENCES [dbo].[Country] ([Id]),
    CONSTRAINT [FK_UsersCompany_Currency_CurencyId] FOREIGN KEY ([CurencyId]) REFERENCES [dbo].[Currency] ([Id]),
    CONSTRAINT [FK_UsersCompany_ProvinceState_ProvinceStateId] FOREIGN KEY ([ProvinceStateId]) REFERENCES [dbo].[ProvinceState] ([Id]),
    CONSTRAINT [FK_UsersCompany_Users_UsersId] FOREIGN KEY ([UsersId]) REFERENCES [dbo].[Users] ([Id])
)
