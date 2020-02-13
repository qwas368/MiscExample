using LanguageExt;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Application.Courses.Commands
{
    public class Error : NewType<Error, string>
    {
        public Error(string str) : base(str) { }
        public static implicit operator Error(string str) => New(str);
    }

    public class CreateCourse : Record<CreateCourse>, IRequest<Either<Error, int>>
    {
        public CreateCourse(string title, int credits, int departmentId)
        {
            Title = title;
            Credits = credits;
            DepartmentId = departmentId;
        }

        public string Title { get; }
        public int Credits { get; }
        public int DepartmentId { get; }
    }
}
