CREATE TABLE [dbo].[DistrictSalesperson]
(
	[DistrictSalespersonId] INT IDENTITY (1, 1) NOT NULL,
	[SPId] INT NOT NULL,
	[DistrictId] INT NOT NULL,
	[Position] VARCHAR(50) NOT NULL,
	CONSTRAINT [PK_dbo.DistrictSalesperson] PRIMARY KEY CLUSTERED ([DistrictSalespersonId] ASC),
    CONSTRAINT [FK_dbo.DistrictSalesperson_dbo.Salesperson_SPId] FOREIGN KEY ([SPId]) REFERENCES [dbo].[Salesperson] ([SPId]),
	CONSTRAINT [FK_dbo.DistrictSalesperson_dbo.District_DistrictId] FOREIGN KEY ([DistrictId]) REFERENCES [dbo].[District] ([DistrictId]),
	CONSTRAINT chk_Position CHECK (Position IN ('Primary', 'Secondary'))

)
GO
CREATE NONCLUSTERED INDEX [IX_SPId]
    ON [dbo].[DistrictSalesperson]([SPId] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_DistrictId]
    ON [dbo].[DistrictSalesperson]([DistrictId] ASC);