CREATE TABLE [dbo].[Users]
(
	[Id]              INT           IDENTITY (1, 1) NOT NULL,
    [UserName]        NVARCHAR (80) NULL,
    [Email]           NVARCHAR (60) NOT NULL,
    [EmailVerifiedAt] DATETIME2 (7) NULL,
    [Password]        varbinary(150)NULL,
    [Domain]          NVARCHAR (60) NULL,
    [RememberToken]   NVARCHAR (60) NULL,
    [Created]         DATETIME2 (7) NULL,
    [IdUserCompany]   INT           DEFAULT 0,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC)
)
