using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibrary2.Application.Courses.Commands
{
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        public RequestLogger()
        {
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var name = typeof(TRequest).Name;

            Console.WriteLine($"PreLogger1");
            Console.WriteLine($"Request: {request}");

            return Task.CompletedTask;
        }
    }
}
