using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;

namespace MediatrExample.EventSourcingHandler
{
    public class EventStoreProcessor<TRequest>
        : IRequestPreProcessor<TRequest>
        where TRequest : IEvent
    {
        public EventStoreProcessor()
        {
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Save Event.");
        }
    }
}