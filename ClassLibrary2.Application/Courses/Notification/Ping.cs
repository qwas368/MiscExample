using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibrary2.Application.Courses.Notification
{
    static class Robot
    {
        public enum RobotStateEnum
        {
            Up,
            Down,
            Known
        }

        public static RobotStateEnum state = RobotStateEnum.Known;
    }

    public class Robot_Up : INotification { }

    public class Robot_Down : INotification { }

    public class Robot_Up_Handler1 : INotificationHandler<Robot_Up>
    {
        public Task Handle(Robot_Up notification, CancellationToken cancellationToken)
        {
            Robot.state = Robot.RobotStateEnum.Up;
            // Do something
            return Task.CompletedTask;
        }
    }

    public class Robot_Up_Handler2 : INotificationHandler<Robot_Up>
    {
        public Task Handle(Robot_Up notification, CancellationToken cancellationToken)
        {
            // Do something
            return Task.CompletedTask;
        }
    }

    public class Robot_Down_Handler : INotificationHandler<Robot_Down>
    {
        public Task Handle(Robot_Down notification, CancellationToken cancellationToken)
        {
            Robot.state = Robot.RobotStateEnum.Down;
            // Do something
            return Task.CompletedTask;
        }
    }
}
