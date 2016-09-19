CREATE TABLE [dbo].[NSLocations]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY, 
    [LocationCity] NVARCHAR(30) NOT NULL, 
    [LocationState] NVARCHAR(2) NOT NULL, 
    [LocationZip] INT NOT NULL
)
