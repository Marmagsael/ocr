CREATE TABLE [dbo].[Currency]
(
	[Id]     INT           IDENTITY (1, 1) NOT NULL,
    [Code]   NVARCHAR (5)  NULL,
    [Name]   NVARCHAR (45) NULL,
    [Symbol] NVARCHAR (5)  NULL,
    CONSTRAINT [PK_Currency] PRIMARY KEY CLUSTERED ([Id] ASC)
)
