CREATE TYPE [dbo].[LocationUpdateTable] AS TABLE
(
	[LocationCity] NVARCHAR(30) NOT NULL, 
    [LocationState] NVARCHAR(2) NOT NULL, 
    [LocationZip] INT NOT NULL
)
