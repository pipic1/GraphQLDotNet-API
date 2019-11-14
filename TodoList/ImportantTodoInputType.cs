using GraphQL.Types;
using TodoList.Types;

namespace TodoList
{
    public class ImportantTodoInputType : InputObjectGraphType<ImportantTodo>
    {
        public ImportantTodoInputType()
        {
            Name = "ImportantTodoInput";
            Field(x => x.Name);
            Field(x => x.Description, nullable: true);
            Field(x => x.Priority, nullable: true);
        }
    }
}
