using ServiceDesk.Infrastructure;
using ServiceDesk.Ticketing.CommandStack.Commands;
using ServiceDesk.Ticketing.Domain.TicketAggregate;
using ServiceDesk.Ticketing.Domain.UserAggregate;
using TaskStatus = ServiceDesk.Ticketing.Domain.TaskAggregate.TaskStatus;

namespace ServiceDesk.Ticketing.CommandStack.Handlers
{
    public class UpdateTaskCommandHandler : IMessageHandler<UpdateTaskCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITicketRepository _ticketRepository;

        public UpdateTaskCommandHandler(IUserRepository userRepository, ITicketRepository ticketRepository)
        {
            _userRepository = userRepository;
            _ticketRepository = ticketRepository;
        }

        public void Handle(UpdateTaskCommand message)
        {
            User assignedUser = _userRepository.GetByLoginName(message.AssignedTo);
            Ticket ticket = _ticketRepository.GetByTicketNumber(message.TicketNumber);
       
            ticket.UpdateTask(message.Title,message.Description, assignedUser,(TaskStatus) message.Status, message.TaskNumber);
            _ticketRepository.Update(ticket);
        }
    }
}
