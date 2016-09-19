using ServiceDesk.Infrastructure;

namespace ServiceDesk.Ticketing.CommandStack.Commands
{
    public class UpdateTaskCommand : Command
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int Status { get; private set; }
        public string AssignedTo { get; private set; }
        public int TaskNumber { get; private set; }
        public int TicketNumber { get; private set; }

        public UpdateTaskCommand(string title, string description, int status, string assignedToLoginName, int ticketNumber, int taskNumber)
        {
            TicketNumber = ticketNumber;
            TaskNumber = taskNumber;
            Title = title;
            Description = description;
            Status = status;
            AssignedTo = assignedToLoginName;
        }

    }
}
