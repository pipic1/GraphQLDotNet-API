using GraphQL.Types;
using GraphQL.Utilities;
using System;

namespace TodoList
{
    public class TodoListSchema : Schema
    {
        public TodoListSchema(IServiceProvider provider)
            : base(provider)
        {
            Query = provider.GetRequiredService<TodoListQuery>();
            Mutation = provider.GetRequiredService<TodoListMutation>();
        }
    }
}
