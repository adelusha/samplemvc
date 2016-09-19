using System;

namespace ServiceDesk.Ticketing.Domain.UserAggregate
{
    public class UserState
    {
        public Guid Id { set; get; }
        public string SID { set; get; }
        public string LoginName { set; get; }
        public string DisplayName { set; get; }
        public string Department { set; get; }
        public string Location { set; get; }
        public string Email { set; get; }

        public User ToUser()
        {
            return new User(this);
        }

        public static User ToUser(UserState state)
        {
            return new User(state);
        }
    }
}
