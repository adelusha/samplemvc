CREATE TABLE [dbo].[AssetManager_AssetStatus]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
	[CreatedDate] DATETIME2(0) NOT NULL, 
    [CreatedById] INT NOT NULL, 
    [ModifiedDate] DATETIME2(0) NULL, 
    [ModifiedById] INT NULL,
	CONSTRAINT [FK_AssetManager_AssetStatus_CreatedById_ToServiceDesk_Users_Id] FOREIGN KEY ([CreatedById]) REFERENCES [ServiceDesk_Users]([Id]),
	CONSTRAINT [FK_AssetManager_AssetStatus_ModifiedById_ToServiceDesk_Users_Id] FOREIGN KEY ([ModifiedById]) REFERENCES [ServiceDesk_Users]([Id])
)
