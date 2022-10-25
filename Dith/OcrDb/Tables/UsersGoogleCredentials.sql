CREATE TABLE [dbo].[UsersGoogleCredentials]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [NameIdentifier] NCHAR(80) NULL, 
    [Name]      NCHAR(80) NULL, 
    [GiveName]  NCHAR(60) NULL, 
    [SurName]   NCHAR(60) NULL, 
    [Email]     NCHAR(80) NULL,
    [PictureAddress]   NCHAR(120) NULL, 


)
