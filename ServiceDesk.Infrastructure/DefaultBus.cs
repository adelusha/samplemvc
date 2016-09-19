
using Autofac;
using System;
using System.Collections.Generic;

namespace ServiceDesk.Infrastructure
{
    public class DefaultBus : IBus
    {
        private readonly IComponentContext _context;

        public DefaultBus(IComponentContext context)
        {
            _context = context;
        }

        void IBus.Send<T>(T command)
        {
            var handler = _context.Resolve<IMessageHandler<T>>();
            if (handler == null)
            {
                throw new InvalidOperationException("Could not get handler for ");
            }
            handler.Handle(command);
        }

        void IBus.RaiseEvent<T>(T @event)
        {
            var handlers = _context.Resolve<IEnumerable<IMessageHandler<T>>>();
            if (handlers == null)
            {
                throw new InvalidOperationException(handlers.ToString());
            }
            foreach (var eventHandler in handlers)
            {
                eventHandler.Handle(@event);
            }
        }
    }
}
