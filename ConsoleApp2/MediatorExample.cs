using Autofac;
using ClassLibrary2.Application.Common.Behaviours;
using ClassLibrary2.Application.Courses.Commands;
using ClassLibrary2.Application.Courses.Notification;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class MediatorExample
    {
        static async Task RunAsync()
        {
            IMediator mediator = BuildMediator();
            var a = await mediator.Send(new CreateCourse("", 1, 1));
            await mediator.Publish(new Ping());


            Console.ReadKey();
        }

        static IMediator BuildMediator()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();

            var mediatrOpenTypes = new[]
            {
                typeof(IRequestHandler<,>),
                typeof(INotificationHandler<>)
            };

            foreach (var mediatrOpenType in mediatrOpenTypes)
            {
                builder
                    .RegisterAssemblyTypes(typeof(CreateCourse).GetTypeInfo().Assembly)
                    .AsClosedTypesOf(mediatrOpenType)
                    .AsImplementedInterfaces();
            }


            builder.Register<ServiceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            builder.RegisterGeneric(typeof(RequestLogger2<>)).As(typeof(IRequestPreProcessor<>));
            builder.RegisterGeneric(typeof(RequestLogger<>)).As(typeof(IRequestPreProcessor<>));
            builder.RegisterGeneric(typeof(RequestPerformanceBehaviour<,>)).AsImplementedInterfaces();
            builder.RegisterGeneric(typeof(RequestPreProcessorBehavior<,>)).AsImplementedInterfaces();
            builder.RegisterGeneric(typeof(RequestPostProcessorBehavior<,>)).AsImplementedInterfaces();

            var container = builder.Build();

            var mediator = container.Resolve<IMediator>();

            return mediator;
        }
    }
}
