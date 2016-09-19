using ServiceDesk.Infrastructure;

namespace ServiceDesk.Ticketing.CommandStack.Commands
{
    public class CreateTicketCommentCommand : Command
    {
        public string Comment { get; private set; }
        public string User { get; private set; }
        public int TicketNumber { get; private set; }

        public CreateTicketCommentCommand(int ticketNumber, string comment, string userLoginName)
        {
            Comment = comment;
            User = userLoginName;
            TicketNumber = ticketNumber;
        }
    }
}

