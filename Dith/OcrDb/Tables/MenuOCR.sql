CREATE TABLE [dbo].[MenuOCR]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [IdParent] INT NULL, 
    [Indent] INT NULL, 
    [Type] NCHAR(10) NULL, 
    [Code] NCHAR(10) NULL, 
    [Icon1] VARCHAR(80) NULL, 
    [Icon2] VARCHAR(80) NULL, 
    [DispText] VARCHAR(80) NULL, 
    [IsWithChild] SMALLINT NULL, 
    [Controller] VARCHAR(50) NULL, 
    [Action] VARCHAR(50) NULL, 
    [Odr] SMALLINT NULL DEFAULT 0
)
