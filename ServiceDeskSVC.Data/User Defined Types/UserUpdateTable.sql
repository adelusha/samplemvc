CREATE TYPE [dbo].[UserUpdateTable] AS TABLE
(
	[SID] NVARCHAR(50) NOT NULL, 
    [UserName] NVARCHAR(30) NOT NULL, 
    [FirstName] NVARCHAR(20) NOT NULL, 
    [LastName] NVARCHAR(20) NOT NULL, 
    [EMail] NVARCHAR(50) NOT NULL, 
    [LocationId] INT NULL, 
    [DepartmentId] INT NULL
)
