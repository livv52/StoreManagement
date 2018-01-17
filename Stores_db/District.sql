CREATE TABLE [dbo].[District]
(
	[DistrictId] INT IDENTITY (1, 1) NOT NULL,
	[Name] VARCHAR (50) NOT NULL,
	[StoreId] INT NOT NULL,
	CONSTRAINT [PK_dbo.District] PRIMARY KEY CLUSTERED ([DistrictId] ASC),
	CONSTRAINT [FK_dbo.District_dbo.Store_StoreId] FOREIGN KEY ([StoreId]) REFERENCES [dbo].[Store] ([StoreId])
)

GO
CREATE NONCLUSTERED INDEX [IX_StoreId]
    ON [dbo].[District]([StoreId] ASC);
