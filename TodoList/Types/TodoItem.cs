namespace TodoList.Types
{
    public abstract class TodoItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string[] RelatedTo { get; set; }
    }

    public class ImportantTodo : TodoItem
    {
        public int Priority { get; set; }
    }

    public class SecondaryTodo : TodoItem
    {
    }
}
