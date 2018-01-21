CREATE TABLE [dbo].[District]
(
	[DistrictId] INT IDENTITY (1, 1) NOT NULL,
	[Name] VARCHAR (50) NOT NULL UNIQUE,
	CONSTRAINT [PK_dbo.District] PRIMARY KEY CLUSTERED ([DistrictId] ASC),
	
)

