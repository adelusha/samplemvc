using System.Data.Entity.ModelConfiguration;
using ServiceDesk.Ticketing.Domain.CategoryAggregate;

namespace ServiceDesk.Ticketing.DataAccess.Mappings
{
    public class CategoryStateMap : EntityTypeConfiguration<CategoryState>
    {
        public CategoryStateMap()
        {
            ToTable("Categories");
        }
    }
}
