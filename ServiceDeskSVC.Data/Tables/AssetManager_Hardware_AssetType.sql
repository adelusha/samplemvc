CREATE TABLE [dbo].[AssetManager_Hardware_AssetType]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [DescriptionNotes] NVARCHAR(MAX) NULL, 
    [EndOfLifeMo] INT NULL, 
    [CategoryCode] INT NOT NULL
)
