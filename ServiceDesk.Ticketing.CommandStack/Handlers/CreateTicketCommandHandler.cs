using ServiceDesk.Infrastructure;
using ServiceDesk.Ticketing.CommandStack.Commands;
using ServiceDesk.Ticketing.Domain.CategoryAggregate;
using ServiceDesk.Ticketing.Domain.TicketAggregate;
using ServiceDesk.Ticketing.Domain.UserAggregate;

namespace ServiceDesk.Ticketing.CommandStack.Handlers
{
    public class CreateTicketCommandHandler : IMessageHandler<CreateTicketCommand>
    {
        private readonly IBus _bus;
        private readonly ITicketRepository _ticketRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CreateTicketCommandHandler(IBus bus, ITicketRepository ticketRepository, IUserRepository userRepository, ICategoryRepository categoryRepository)
        {
            _ticketRepository = ticketRepository;
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
            _bus = bus;
        }

        public void Handle(CreateTicketCommand message)
        {
            User requestor = _userRepository.GetByLoginName(message.RequestorLoginName);
            User assignedTo = _userRepository.GetByLoginName(message.AssignedToLoginName);
            Category category = _categoryRepository.GetByName(message.Category);

            var ticket = new Ticket(message.Title, message.Description, (TicketStatus)message.Status, (TicketPriority)message.Priority, (TicketType)message.Type,
            message.DueDate, message.ResolutionComments, requestor, assignedTo, category);

            _ticketRepository.Add(ticket);
        }
    }
}
