CREATE TABLE [dbo].[Salesperson]
(
	[SPId] INT IDENTITY (1, 1) NOT NULL,
	[Firstname] VARCHAR(50) NOT NULL,
	[Lastname] VARCHAR(50) NOT NULL,
	[Description] NVARCHAR(MAX) NULL,
	[Position] VARCHAR(50) NOT NULL,
	CONSTRAINT [PK_dbo.Salesperson] PRIMARY KEY CLUSTERED ([SPId] ASC)
)
