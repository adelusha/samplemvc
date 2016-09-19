using System.Data.Entity;

namespace ServiceDesk.Ticketing.Domain.TicketAggregate
{
    public class SequentialNumberGenerator : ISequentialNumberGenerator
    {
        private readonly DbContext _context; 

       public int GenerateSequentialNumber()
       {
           var newNumber = _context.Database.SqlQuery<SequentialNumberState>("NameOfStoredProcedure", 4);
           return 0;
       }
    }
}
