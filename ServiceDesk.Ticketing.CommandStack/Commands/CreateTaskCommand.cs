using ServiceDesk.Infrastructure;

namespace ServiceDesk.Ticketing.CommandStack.Commands
{
    public class CreateTaskCommand : Command
    {
        public string Title;
        public string Description;
        public int Status;
        public string AssignedTo;
        public int TicketNumber { get; set; }

        public CreateTaskCommand(string title, string description, int status, string assignedToLoginName, int ticketNumber)
        {
            Title = title;
            Description = description;
            Status = status;
            AssignedTo = assignedToLoginName;
            TicketNumber = ticketNumber;
        }

    }
}