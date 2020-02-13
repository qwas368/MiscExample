using MediatR;
using MediatrExample.EventSourcingHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatrExample.Commands
{
    public class Create : IRequest, IEvent
    {
        public Create(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}
