using System;

namespace ServiceDesk.Ticketing.Domain.CategoryAggregate
{
   public class CategoryState
    {
       public Guid Id { get; set; }
       public string Name { get; set; }
       public string Description { get; set; }

       public Category ToCategory()
       {
           return new Category(this);
       }

       public static Category ToCategory(CategoryState state)
       {
           return new Category(state);
       }

    }
}
