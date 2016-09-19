CREATE TABLE [dbo].[AssetManager_Companies]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Website] NVARCHAR(100) NULL, 
    [PhoneNumber] NVARCHAR(30) NULL, 
    [Street] NVARCHAR(100) NULL, 
    [City] NVARCHAR(50) NULL, 
    [State] NVARCHAR(2) NULL, 
    [Zip] NVARCHAR(10) NULL
)
