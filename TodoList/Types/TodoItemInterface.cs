using GraphQL.Types;

namespace TodoList.Types
{
    public class TodoItemInterface : InterfaceGraphType<TodoItem>
    {
        public TodoItemInterface()
        {
            Name = "TodoItem";

            Field(d => d.Id).Description("The id of the todo task.");
            Field(d => d.Name, nullable: true).Description("The name of the todo task.");
            Field(d => d.Description, nullable: true).Description("The description of the todo task.");

            Field<ListGraphType<TodoItemInterface>>("relatedto");
        }
    }
}