using ServiceDesk.Infrastructure;
using ServiceDesk.Ticketing.CommandStack.Commands;
using ServiceDesk.Ticketing.Domain.TicketAggregate;
using ServiceDesk.Ticketing.Domain.UserAggregate;

namespace ServiceDesk.Ticketing.CommandStack.Handlers
{
    public class CreateTicketCommentCommandHandler : IMessageHandler<CreateTicketCommentCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITicketRepository _ticketRepository;

        public CreateTicketCommentCommandHandler(IUserRepository userRepository, ITicketRepository ticketRepository)
        {
            _userRepository = userRepository;
            _ticketRepository = ticketRepository;
        }

        public void Handle(CreateTicketCommentCommand message)
        {
            User user = _userRepository.GetByLoginName(message.User);
            Ticket ticket = _ticketRepository.GetByTicketNumber(message.TicketNumber);

            ticket.AddComment(message.Comment, user);
            _ticketRepository.Update(ticket);
        }
    }
}
