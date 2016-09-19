namespace ServiceDesk.Ticketing.Domain.UserAggregate
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByLoginName(string loginName);
    }
}
