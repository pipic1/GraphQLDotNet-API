using GraphQL.Types;

namespace TodoList.Types
{
    public class PriorityEnum : EnumerationGraphType<Priority>
    {
        public PriorityEnum()
        {
            Name = "Status";
            Description = "Status of a task.";
            AddValue("LOW", "The task is not started yet", 1);
            AddValue("MEDIUM", "The task has been started", 2);
            AddValue("HIGH", "The task is finished.", 3);
        }
    }

    public enum Priority
    {
        LOW  = 1,
        MEDIUM  = 2,
        HIGH  = 3
    }
}
