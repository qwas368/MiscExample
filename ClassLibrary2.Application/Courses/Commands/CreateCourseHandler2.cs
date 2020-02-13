using LanguageExt;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static LanguageExt.Prelude;

namespace ClassLibrary2.Application.Courses.Commands
{

    public class CreateCourseHandler2 : IRequestHandler<CreateCourse, Either<Error, int>>
    {
        private readonly List<CreateCourse> _courseRepository;

        public CreateCourseHandler2()
        {
            _courseRepository = new List<CreateCourse>();
        }

        public Task<Either<Error, int>> Handle(CreateCourse request, CancellationToken cancellationToken)
        {
            _courseRepository.Add(request);
            return Task.FromResult(Right<Error, int>(456));
        }
    }
}
