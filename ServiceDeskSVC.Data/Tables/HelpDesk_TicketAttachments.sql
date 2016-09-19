CREATE TABLE [dbo].[HelpDesk_TicketAttachments]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TicketId] INT NOT NULL, 
    [FileName] NVARCHAR(50) NOT NULL, 
    [Date] DATETIME2(0) NOT NULL, 
    [Data] VARBINARY(MAX) NOT NULL,
    [FileSize] INT NOT NULL, 
    CONSTRAINT [FK_HelpDesk_TicketAttachments_TicketId_ToHelpDesk_Tickets_Id] FOREIGN KEY ([TicketId]) REFERENCES [HelpDesk_Tickets]([Id]),
	
)
