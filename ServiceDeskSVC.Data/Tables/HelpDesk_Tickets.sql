CREATE TABLE [dbo].[HelpDesk_Tickets]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY, 
	[TicketNumber] INT NOT NULL,
    [Title] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [Requestor] INT NOT NULL, 
    [DepartmentID] INT NULL, 
    [LocationID] INT NULL, 
    [RequestDateTime] DATETIME2(0) DEFAULT (GetDate()) NULL, 
    [RequestedDueDate] DATETIME2(0) NULL, 
    [TicketCategoryID] INT NOT NULL, 
    [PriorityCode] TINYINT NOT NULL, 
    [StatusID] INT NOT NULL, 
    [AssignedTo] INT NOT NULL, 
    [VendorID] INT NULL, 
    [VendorTicket] NVARCHAR(30) NULL, 
    [TicketTypeID] INT NOT NULL, 
    [NeedsApproval] BIT NOT NULL, 
    [ApprovedBy] INT NULL, 
    [ApprovedOn] DATETIME2(0) NULL, 
    CONSTRAINT [FK_Tickets_DepartmentID_ToDepartments_ID] FOREIGN KEY ([DepartmentID]) REFERENCES [Departments]([ID]), 
    CONSTRAINT [FK_Tickets_TicketTypeID_ToTicketType_ID] FOREIGN KEY ([TicketTypeID]) REFERENCES [HelpDesk_TicketType]([ID]),
	CONSTRAINT [FK_Tickets_StatusID_ToTicketStatus_ID] FOREIGN KEY ([StatusID]) REFERENCES [HelpDesk_TicketStatus]([ID]),
	CONSTRAINT [FK_Tickets_TicketCategoryID_ToTicketCategory_ID] FOREIGN KEY ([TicketCategoryID]) REFERENCES [HelpDesk_TicketCategory]([ID]),
	CONSTRAINT [FK_Tickets_LocationID_ToNSLocations_ID] FOREIGN KEY ([LocationID]) REFERENCES [NSLocations]([ID]),
	CONSTRAINT [FK_Tickets_VendorID_ToAssetManager_Companies_ID] FOREIGN KEY ([VendorID]) REFERENCES [AssetManager_Companies]([ID]),
	CONSTRAINT [FK_Tickets_Requestor_ToUsers_Id] FOREIGN KEY ([Requestor]) REFERENCES [ServiceDesk_Users]([Id]),
	CONSTRAINT [FK_Tickets_AssignedTo_ToUsers_Id] FOREIGN KEY ([AssignedTo]) REFERENCES [ServiceDesk_Users]([Id]),
	CONSTRAINT [FK_Tickets_ApprovedBy_ToUsers_Id] FOREIGN KEY ([ApprovedBy]) REFERENCES [ServiceDesk_Users]([Id])
)

GO
