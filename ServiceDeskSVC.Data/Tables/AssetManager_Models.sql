CREATE TABLE [dbo].[AssetManager_Models]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ModelName] NVARCHAR(100) NOT NULL, 
	[CompanyId] INT NOT NULL, 
    [DescriptionNotes] NVARCHAR(MAX) NULL, 
    [SupportWebsite] NVARCHAR(300) NULL, 
    [ManufacturerWebsite] NVARCHAR(300) NULL,
	CONSTRAINT [FK_AssetManager_Models_CompanyId_ToServiceDesk_Companies_Id] FOREIGN KEY ([CompanyId]) REFERENCES [AssetManager_Companies]([Id])
)
