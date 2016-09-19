using System;
using ServiceDesk.Infrastructure;
using ServiceDesk.Ticketing.Domain.TicketAggregate;

namespace ServiceDesk.Ticketing.Domain.UserAggregate
{
    public class User : AggregateRoot
    {
        internal UserState State { get; set; }

        public Guid Id
        {
            get { return State.Id; }
        }

        public User(string SID, string loginName, string displayName, string departament, string location, string email)
        {
            State = new UserState
            {
                Id = SequencialGuidGenerator.NewSequentialGuid(),
                SID = SID,
                LoginName = loginName,
                DisplayName = displayName,
                Department = departament,
                Location = location,
                Email = email
            };
        }

        public Requestor CreateRequestorSnapShot()
        {
            return new Requestor(State.DisplayName,State.Department, State.Location);
        }

        internal User(UserState state)
        {
            State = state;
        }
    }
}
