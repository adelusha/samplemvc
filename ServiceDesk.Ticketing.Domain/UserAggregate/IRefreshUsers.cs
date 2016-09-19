namespace ServiceDesk.Ticketing.Domain.UserAggregate
{
    public interface IRefreshUsers
    {
        void RefreshUsersFromAD(IUserRepository userRepository);
    }
}
