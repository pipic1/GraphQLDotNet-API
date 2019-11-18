using GraphQL.Types;

namespace TodoList.Types
{
    public class SecondaryType : ObjectGraphType<SecondaryTodo>
    {
        public SecondaryType(TodoListData data)
        {
            Name = "SecondaryTodo";

            Field(h => h.Id).Description("The id of the Secondary Task.");
            Field(h => h.Name, nullable: true).Description("The name of the Secondary task.");
            Field(h => h.Description, nullable: true).Description("The descrition of the Secondary task.");

            Field<ListGraphType<TodoItemInterface>>(
                "relatedto",
                resolve: context => data.GetRelatedTask(context.Source)
            );

            Interface<TodoItemInterface>();
        }
    }
}
