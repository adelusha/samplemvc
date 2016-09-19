using ServiceDesk.Infrastructure;
using ServiceDesk.Ticketing.CommandStack.Commands;
using ServiceDesk.Ticketing.Domain.TaskAggregate;
using ServiceDesk.Ticketing.Domain.TicketAggregate;
using ServiceDesk.Ticketing.Domain.UserAggregate;

namespace ServiceDesk.Ticketing.CommandStack.Handlers
{
    public class CreateTaskCommandHandler : IMessageHandler<CreateTaskCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITicketRepository _ticketRepository;

        public CreateTaskCommandHandler(IUserRepository userRepository, ITicketRepository ticketRepository)
        {
            _userRepository = userRepository;
            _ticketRepository = ticketRepository;
        }

        public void Handle(CreateTaskCommand message)
        {
            User assignedUser = _userRepository.GetByLoginName(message.AssignedTo);
            Ticket ticket = _ticketRepository.GetByTicketNumber(message.TicketNumber);

            ticket.AddTask(message.Title, message.Description, assignedUser, (TaskStatus)message.Status);
            _ticketRepository.Update(ticket);
        }
    }
}