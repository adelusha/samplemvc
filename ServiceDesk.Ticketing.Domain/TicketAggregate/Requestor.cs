using ServiceDesk.Infrastructure;

namespace ServiceDesk.Ticketing.Domain.TicketAggregate
{
    public class Requestor : ValueObject
    {
        public string DisplayName { private set; get; }
        public string Departament { private set; get; }
        public string Location { private set; get; }

        public Requestor()
        {
            
        }
        public Requestor(string displayName, string department, string location)
        {
            DisplayName = displayName;
            Departament = department;
            Location = location;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var requestorItem = obj as Requestor;
            if (requestorItem == null)
            {
                return false;
            }

            return ((requestorItem.DisplayName == this.DisplayName) && (requestorItem.Departament == this.Departament) && (requestorItem.Location == this.Location));
        }

        public override int GetHashCode()
        {
            return new { this.DisplayName, this.Departament, this.Location }.GetHashCode();
        }
    }
}
