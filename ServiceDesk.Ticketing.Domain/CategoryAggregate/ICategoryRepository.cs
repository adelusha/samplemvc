namespace ServiceDesk.Ticketing.Domain.CategoryAggregate
{
    public interface ICategoryRepository: IRepository<Category>
    {
        Category GetByName(string name);
    }

}
