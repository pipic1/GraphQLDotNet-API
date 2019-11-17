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
                "important",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the important task." }
                ),
                resolve: context => data.GetImportantTodoByIdAsync(context.GetArgument<string>("id"))
            );
            

            Field<ListGraphType<ImportantType>>(
                "importanttodos",
                resolve: context => data.GetPrimaryTodoAsync()
            );

            Func<ResolveFieldContext, string, object> func = (context, id) => data.GetSecondaryTodoByIdAsync(id);

            FieldDelegate<SecondaryType>(
                "secondary",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the secondary task" }
                ),
                resolve: func
            );

            Field<ListGraphType<SecondaryType>>(
                "secondarytodos",
                resolve: context => data.GetSecondaryTodoAsync()
            );
        }
    }
}
