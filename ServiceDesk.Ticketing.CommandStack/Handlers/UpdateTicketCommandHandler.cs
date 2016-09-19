using ServiceDesk.Infrastructure;
using ServiceDesk.Ticketing.CommandStack.Commands;
using ServiceDesk.Ticketing.Domain.CategoryAggregate;
using ServiceDesk.Ticketing.Domain.TicketAggregate;
using ServiceDesk.Ticketing.Domain.UserAggregate;

namespace ServiceDesk.Ticketing.CommandStack.Handlers
{
    public class UpdateTicketCommandHandler : IMessageHandler<UpdateTicketCommand>
    {
        private readonly IBus _bus;
        private readonly ITicketRepository _ticketRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserRepository _userRepository;

        public UpdateTicketCommandHandler(IBus bus, ITicketRepository ticketRepository, IUserRepository userRepository,
            ICategoryRepository categoryRepository)
        {
            _ticketRepository = ticketRepository;
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
            _bus = bus;
        }

        public void Handle(UpdateTicketCommand message)
        {
            User assignedToUser = _userRepository.GetByLoginName(message.AssignedToLoginName);
            Category category = _categoryRepository.GetByName(message.Category);
            Ticket ticket = _ticketRepository.GetByTicketNumber(message.TicketNo);
            ticket.UpdateTicket(message.Title, message.Description, message.Status, message.Priority, message.Type,
                message.DueDate, message.ResolutionComments, assignedToUser, category);
            _ticketRepository.Update(ticket);
        }
    }
}
