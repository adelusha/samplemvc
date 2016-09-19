CREATE TABLE [dbo].[HelpDesk_TicketComments]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY NONCLUSTERED, 
    [TicketID] INT NOT NULL, 
    [CommentDateTime] DATETIME2(3) NOT NULL, 
    [Author] INT NOT NULL, 
    [CommentTypeID] INT NOT NULL, 
    [Comment] NVARCHAR(4000) NOT NULL, 
    CONSTRAINT [FK_TicketCommentsTicketID_ToTicketsID] FOREIGN KEY ([TicketID]) REFERENCES [HelpDesk_Tickets]([Id]),
	CONSTRAINT [FK_TicketCommentsTicketID_Author_ToUsers_Id] FOREIGN KEY ([Author]) REFERENCES [ServiceDesk_Users]([Id])
)

GO
CREATE CLUSTERED INDEX [IX_HelpDesk_TicketComments_TicketID] ON [dbo].[HelpDesk_TicketComments] ([TicketID],[CommentDateTime])

