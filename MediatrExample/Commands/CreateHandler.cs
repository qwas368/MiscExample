using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrExample.Commands
{
    public class CreateHandler : IRequestHandler<Create>
    {
        private readonly IMediator _mediator;

        public CreateHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Unit> Handle(Create request, CancellationToken cancellationToken)
        {
            Console.WriteLine(request.Message);

            return Unit.Value;
        }
    }
}
