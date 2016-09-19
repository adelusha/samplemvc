CREATE TABLE [dbo].[ServiceDesk_Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[SID] NVARCHAR(50) NOT NULL, 
    [UserName] NVARCHAR(30) NOT NULL, 
    [FirstName] NVARCHAR(20) NOT NULL, 
    [LastName] NVARCHAR(20) NOT NULL, 
    [EMail] NVARCHAR(50) NOT NULL, 
    [LocationId] INT NULL, 
    [DepartmentId] INT NULL, 
    CONSTRAINT [FK_ServiceDesk_Users_ToNSLocations_Id] FOREIGN KEY ([LocationId]) REFERENCES [NSLocations]([Id]),
	CONSTRAINT [FK_ServiceDesk_Users_ToDepartments_Id] FOREIGN KEY ([DepartmentId]) REFERENCES [Departments]([Id]),

)
