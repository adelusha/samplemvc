CREATE TABLE [dbo].[HelpDesk_Tasks]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY, 
	[TicketID] INT NOT NULL, 
    [Title] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [StatusID] INT NOT NULL, 
    [CreatedDateTime] DATETIME2(0) DEFAULT (GetDate()) NULL, 
    [StatusChangedDateTime] DATETIME2(0) NULL, 
    [AssignedTo] INT NOT NULL, 
    [RelatedTaskIds] NCHAR(10) NULL, 
    CONSTRAINT [FK_HelpDesk_Tasks_TicketID_ToHelpDesk_Tickets_ID] FOREIGN KEY ([TicketID]) REFERENCES [HelpDesk_Tickets]([ID]), 
	CONSTRAINT [FK_HelpDesk_Tasks_StatusID_ToHelpDesk_TaskStatus_ID] FOREIGN KEY ([StatusID]) REFERENCES [HelpDesk_TaskStatus]([ID]), 
    CONSTRAINT [FK_Tasks_AssignedTo_ToUsers_Id] FOREIGN KEY ([AssignedTo]) REFERENCES [ServiceDesk_Users]([Id])
)

GO

CREATE INDEX [IX_HelpDesk_Tasks_TicketID] ON [dbo].[HelpDesk_Tasks] ([TicketID])
