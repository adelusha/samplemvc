using System.Collections.Generic;
using System.Linq;
using ServiceDesk.Infrastructure;
using ServiceDesk.Ticketing.Domain.UserAggregate;

namespace ServiceDesk.Ticketing.DataAccess.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly TicketingDbContext _context;

        public UserRepository(TicketingDbContext context, IBus bus)
            : base(context, bus)
        {
            _context = context;
        }

        public User GetByLoginName(string loginName)
        {
            return _context.Users.First(u => u.LoginName == loginName).ToUser();
        }

        public List<User> GetAllUsers()
        {
            var allUsers = new List<User>();
            var users = _context.Users;
            foreach (var user in users)
            {
                allUsers.Add(user.ToUser());
            }
            return allUsers;
            //Select(user => user.ToUser()).ToList();
        }

        protected override void AddNew(User aggregate)
        {
            _context.Users.Add(aggregate.State);
        }

    }
}
