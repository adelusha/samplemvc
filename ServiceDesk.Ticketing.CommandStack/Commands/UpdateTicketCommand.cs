using System;
using ServiceDesk.Infrastructure;

namespace ServiceDesk.Ticketing.CommandStack.Commands
{
    public class UpdateTicketCommand : Command
    {
        public int TicketNo { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int Status { get; private set; }
        public int Priority { get; private set; }
        public int Type { get; private set; }
        public DateTime? DueDate { get; private set; }
        public string ResolutionComments { get; private set; }
        public string AssignedToLoginName { get; private set; }
        public string Category { get; private set; }

        public UpdateTicketCommand(int id, string title, string description, int status, int priority, int type,
            DateTime? dueDate, string resolutionComments, string assignedToLoginName, string category)
        {
            TicketNo = id;
            Title = title;
            Description = description;
            Status = status;
            Priority = priority;
            Type = type;
            DueDate = dueDate;
            ResolutionComments = resolutionComments;
            AssignedToLoginName = assignedToLoginName;
            Category = category;
        }
    }
}
