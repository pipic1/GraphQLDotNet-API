using System;
using GraphQL.Types;
using TodoList.Types;

namespace TodoList
{
    public class TodoListQuery : ObjectGraphType<object>
    {
        public TodoListQuery(TodoListData data)
        {
            Name = "Query";

            Field<ImportantType>(
                "importanttodo",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the important task." }
                ),
                resolve: context => data.GetImportantTodoByIdAsync(context.GetArgument<string>("id"))
            );

            Func<ResolveFieldContext, string, object> func = (context, id) => data.GetSecondaryTodoByIdAsync(id);

            FieldDelegate<SecondaryType>(
                "secondarytodo",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the secondary task" }
                ),
                resolve: func
            );
        }
    }
}
