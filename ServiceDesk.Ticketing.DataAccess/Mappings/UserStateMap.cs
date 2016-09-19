using System.Data.Entity.ModelConfiguration;
using ServiceDesk.Ticketing.Domain.UserAggregate;

namespace ServiceDesk.Ticketing.DataAccess.Mappings
{
    public class UserStateMap : EntityTypeConfiguration<UserState>
    {
        public UserStateMap()
        {
            ToTable("Users");
        }
    }
}
