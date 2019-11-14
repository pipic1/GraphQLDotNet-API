using GraphQL.Types;
using TodoList.Types;

namespace TodoList
{
    /// <example>
    /// This is an example JSON request for a mutation
    /// {
    ///   "query": "mutation CreateTaskImportant($task:ImportantTodoInputType!){ createImportantTask(human: $task) { id name } }",
    ///   "variables": {
    ///     "task": {
    ///       "name": "Acheter du lait"
    ///       "description": "2 bouteilles de 1L"
    ///     }
    ///   }
    /// }
    /// </example>
    public class TodoListMutation : ObjectGraphType
    {
        public TodoListMutation(TodoListData data)
        {
            Name = "Mutation";

            Field<ImportantType>(
                "createImportantTask",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ImportantTodoInputType>> {Name = "task"}
                ),
                resolve: context =>
                {
                    var importantTask = context.GetArgument<ImportantTodo>("task");
                    return data.AddImportantTodo(importantTask);
                });
        }
    }
}
