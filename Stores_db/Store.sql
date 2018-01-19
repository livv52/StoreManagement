CREATE TABLE [dbo].[Store]
(
	[StoreId] INT IDENTITY (1, 1) NOT NULL,
	[Name]   VARCHAR(50) NOT NULL,
	[DistrictId]  INT NOT NULL,
	CONSTRAINT [PK_dbo.Store] PRIMARY KEY CLUSTERED ([StoreId] ASC),
	CONSTRAINT [FK_dbo.Store_dbo.District_DistrictId] FOREIGN KEY ([DistrictId]) REFERENCES [dbo].[District] ([DistrictId])
)

GO
CREATE NONCLUSTERED INDEX [IX_DistrictId]
    ON [dbo].[Store]([DistrictId] ASC);
