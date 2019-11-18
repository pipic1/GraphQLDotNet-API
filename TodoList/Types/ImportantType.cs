using GraphQL.Types;
using TodoList.Types;

namespace TodoList.Types
{
    public class ImportantType : ObjectGraphType<ImportantTodo>
    {
        public ImportantType(TodoListData data)
        {
            Name = "ImportantTodo";
            Description = "This is an important task.";

            Field(h => h.Id).Description("The id of the Important Task.");
            Field(h => h.Name, nullable: true).Description("The name of the Important task.");
            Field(h => h.Description, nullable: true).Description("The descrition of the Important task.");

            Field<ListGraphType<TodoItemInterface>>(
                "relatedto",
                resolve: context => data.GetRelatedTask(context.Source)
            );

            Field<StatusEnum>("priority","The priority of the tasks");

            Interface<TodoItemInterface>();
        }
    }
}
