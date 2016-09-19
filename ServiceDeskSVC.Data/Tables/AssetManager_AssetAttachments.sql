CREATE TABLE [dbo].[AssetManager_AssetAttachments]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[FileName] NVARCHAR(50) NOT NULL, 
    [Date] DATETIME2(0) NOT NULL, 
    [Data] VARBINARY(MAX) NOT NULL,
    [FileSize] INT NOT NULL, 
    [HardwareAssetId] INT NULL, 
    [SoftwareAssetId] INT NULL, 
    [ModelId] INT NULL, 
    [CompaniesId] INT NULL, 
    [DescriptionNotes] NVARCHAR(MAX) NULL, 
    [CreatedDate] DATETIME2(0) NOT NULL, 
    [CreatedById] INT NOT NULL,
    [ModifiedDate] DATETIME2(0) NOT NULL, 
    [ModifiedById] INT NOT NULL,
    CONSTRAINT [FK_AssetManager_AssetAttachments_HardwareAssetId_ToAssetManager_Hardware_Id] FOREIGN KEY ([HardwareAssetId]) REFERENCES [AssetManager_Hardware]([Id]),
	CONSTRAINT [FK_AssetManager_AssetAttachments_SoftwareAssetId_ToAssetManager_Software_Id] FOREIGN KEY ([SoftwareAssetId]) REFERENCES [AssetManager_Software]([Id]),
	CONSTRAINT [FK_AssetManager_AssetAttachments_ModelId_ToAssetManager_Models_Id] FOREIGN KEY ([ModelId]) REFERENCES [AssetManager_Models]([Id]),
	CONSTRAINT [FK_AssetManager_AssetAttachments_CompaniesId_ToAssetManager_Companies_Id] FOREIGN KEY ([CompaniesId]) REFERENCES [AssetManager_Companies]([Id]),
	CONSTRAINT [FK_AssetManager_AssetAttachments_CreatedById_ToServiceDesk_Users_Id] FOREIGN KEY ([CreatedById]) REFERENCES [ServiceDesk_Users]([Id]),
	CONSTRAINT [FK_AssetManager_AssetAttachments_ModifiedById_ToServiceDesk_Users_Id] FOREIGN KEY ([ModifiedById]) REFERENCES [ServiceDesk_Users]([Id])

)
