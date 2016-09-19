CREATE TABLE [dbo].[HelpDesk_Tasks_RelatedTasks]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [TaskID] INT NOT NULL, 
    [RelatedTaskID] INT NOT NULL
)
