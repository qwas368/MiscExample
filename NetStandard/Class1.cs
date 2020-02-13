using System;

namespace NetStandard
{
    public class Class1
    {
        [Union]
        public interface RobotEvent
        {
            RobotEvent MoveUp();
            RobotEvent MoveDown();
        }
    }
}
