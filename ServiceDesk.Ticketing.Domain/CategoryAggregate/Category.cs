using System;
using ServiceDesk.Infrastructure;

namespace ServiceDesk.Ticketing.Domain.CategoryAggregate
{
    public class Category : AggregateRoot
    {
        internal CategoryState State { get; set; }

        public Guid Id
        {
            get { return State.Id; }
        }

        public Category(string name, string description)
        {
            State = new CategoryState
            {
                Id = SequencialGuidGenerator.NewSequentialGuid(),
                Name = name,
                Description = description

            };
        }

        internal Category(CategoryState state)
        {
            State = state;
        }
    }
}
