using ServiceDesk.Infrastructure;
using ServiceDesk.Ticketing.CommandStack.Commands;
using ServiceDesk.Ticketing.Domain.UserAggregate;

namespace ServiceDesk.Ticketing.CommandStack.Handlers
{
    public class RefreshUsersCommandHandler : IMessageHandler<RefreshUsersCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRefreshUsers _refreshUsers;

        public RefreshUsersCommandHandler(IUserRepository userRepository, IRefreshUsers refreshUsers)
        {
            _userRepository = userRepository;
            _refreshUsers = refreshUsers;
        }

        public void Handle(RefreshUsersCommand message)
        {
            _refreshUsers.RefreshUsersFromAD(_userRepository);
        }
    }
}
