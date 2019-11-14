using GraphQL.Types;

namespace TodoList.Types
{
    public class StatusEnum : EnumerationGraphType
    {
        public StatusEnum()
        {
            Name = "Status";
            Description = "Status of a task.";
            AddValue("OPEN", "The task is not started yet", 4);
            AddValue("STARTED", "The task has been started", 5);
            AddValue("ENDED", "The task is finished.", 6);
        }
    }

    public enum Statuses
    {
        OPEN  = 4,
        STARTED  = 5,
        ENDED  = 6
    }
}
