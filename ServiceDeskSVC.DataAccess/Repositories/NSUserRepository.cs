using System;
using System.Collections.Generic;
using System.Linq;
using ILogging;
using ServiceDeskSVC.DataAccess.Models;

namespace ServiceDeskSVC.DataAccess.Repositories
{
    public class NSUserRepository : INSUserRepository
    {
        private readonly ServiceDeskContext _context;
        private readonly ILogger _logger;

        public NSUserRepository(ServiceDeskContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }


        public List<ServiceDesk_Users> GetUserFromSearch(string search, int numResults)
        {
            var users =
                _context.ServiceDesk_Users.Where(u => (u.FirstName + " " + u.LastName).Contains(search))
                    .Take(numResults)
                    .ToList();

            return users;
        }

        public List<ServiceDesk_Users> GetAllUsers()
        {
            var users = _context.ServiceDesk_Users.ToList();
            return users;
        }

        public ServiceDesk_Users GetUserByUserName(string userName)
        {
            var user = _context.ServiceDesk_Users.FirstOrDefault(u => u.UserName == userName);
            return user;
        }

        public ServiceDesk_Users GetUserBySID(string sid)
        {
            var user = _context.ServiceDesk_Users.FirstOrDefault(u=> u.SID == sid);
            return user;
        }
    }
}
